import React from 'react';
import { Grid } from '@material-ui/core';
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

function Accepted() {
    const [leads, setLeads] = React.useState([]);
    React.useEffect(() => {
        getAcceptedLeads().then(r => r.leads).then(setLeads);
    }, []);

    return (
        <Grid container spacing={5}>
            {!leads || leads.map(function(lead: AcceptedLead){return <Grid key={lead.jobId} item>{AcceptedLeadView(lead)}</Grid>})}
        </Grid>
    );
}

export default Accepted;