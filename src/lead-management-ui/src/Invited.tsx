import React from 'react';
import { Grid } from '@material-ui/core';
import NewLeadView from './NewLeadView';
import NewLead from './NewLead';

const getNewLeads = async () => {
    const response = await fetch('http://localhost:5000', {
        method: 'GET'
    })
    .then(contents => { return contents.json(); })
    .catch(err => {
        console.error('getNewLeads error:', err);
        return err
    });
    return response;
};

function Invited() {
    const [leads, setLeads] = React.useState([]);
    React.useEffect(() => {
        getNewLeads().then(r => r.leads).then(setLeads);
    }, []);

    return (
        <Grid container={true} spacing={5} direction='column' alignContent='stretch'>
            {!leads || leads.map(function(lead: NewLead){return <Grid key={lead.jobId} item>{NewLeadView(lead)}</Grid>})}
        </Grid>
    );
}

export default Invited;