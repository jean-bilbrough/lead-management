import React from 'react';
import { Grid } from '@material-ui/core';
import { WithStyles } from '@material-ui/core/styles';
import styles from '../../styles';
import AcceptedLeadView from './AcceptedLeadView';
import AcceptedLead from './AcceptedLead';

const getAcceptedLeads = async () => {
    const response = await fetch('http://localhost:5000/accepted', {
        method: 'GET'
    })
    .then(contents => { return contents.json(); })
    .catch(err => {
        console.error('getAcceptedLeads error:', err);
        return err
    });
    return response;
};

function Accepted(props: WithStyles<typeof styles>) {
    const [leads, setLeads] = React.useState([]);
    React.useEffect(() => {
        getAcceptedLeads().then(r => r.leads).then(setLeads);
    }, []);    

    return (
        <Grid container={true} spacing={5} direction='column' alignContent='stretch'>
            {!leads || leads.map(function(lead: AcceptedLead){return <Grid key={lead.jobId} item>{AcceptedLeadView(lead, props)}</Grid>})}
        </Grid>
    );
}

export default Accepted;