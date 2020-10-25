import React from 'react';
import NewLeadView from './NewLeadView';
import Lead from './Lead';

const getNewLeads = async () => {
    const response = await fetch('https://localhost:5001', {
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
        <div>
            {!leads || leads.map(function(lead: Lead){return <div key={lead.jobId}>{NewLeadView(lead)}</div>})}
        </div>
    );
}

export default Invited;