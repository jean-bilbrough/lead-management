import { useEffect, useState } from 'react';
import Container from '@material-ui/core/Container';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import InvitedView from './invited/InvitedView';
import AcceptedView from './accepted/AcceptedView';
import { getNewLeads, getAcceptedLeads } from '../services/leadManagementServices';

function selectView(index, leads, refresh, setRefresh) {
    return (
        <div>
            {index === 0 && InvitedView(leads, refresh, setRefresh)}
            {index === 1 && AcceptedView(leads)}
        </div>
    );
}

function LeadManagement() {
    const [tabIndex, setTabIndex] = useState(0);
    const [refresh, setRefresh] = useState(false);
    const [leads, setLeads] = useState([]);
    useEffect(() => {
        if(tabIndex === 0) {
            getNewLeads().then(r => r.leads).then(setLeads);
        }
    }, [tabIndex, refresh]);
    useEffect(() => {
        if(tabIndex === 1) {
            getAcceptedLeads().then(r => r.leads).then(setLeads);
        }
    }, [tabIndex, refresh]); 

    const handleChange = (event, newIndex) => {
        setTabIndex(newIndex);        
    }

    return (        
        <div>
            <Container>
                <Tabs value={tabIndex} onChange={handleChange}>
                    <Tab label="Invited" />
                    <Tab label="Accepted" />
                </Tabs>
            </Container>
            {selectView(tabIndex, leads, refresh, setRefresh)}
        </div>
    );
}

export default LeadManagement;