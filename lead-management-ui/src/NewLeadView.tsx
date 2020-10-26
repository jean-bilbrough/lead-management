import React from 'react';
import Lead from './Lead';

const acceptOrDeclineLead = async (acceptOrDecline: string, jobId: number) => {
    console.log('acceptLead called');
    await fetch(`https://localhost:5001/${acceptOrDecline}?jobid=${jobId}`, {
        method: 'PUT'
    })
    .catch(err => {
        console.error('acceptLead error:', err);
        return err
    });
    window.location.reload(false);
};

function NewLeadView(lead: Lead) {
    return(
        <div>
            <div>{lead.contactFirstName}</div>
            <div>{lead.dateCreated}</div>
            <div>{lead.suburb}</div>
            <div>{lead.category}</div>
            <div>{lead.jobId}</div>
            <div>{lead.description}</div>
            <div>
                <button onClick={() => acceptOrDeclineLead('accept', lead.jobId)}>Accept</button>
                <button onClick={() => acceptOrDeclineLead('decline', lead.jobId)}>Decline</button>
            </div>
            <div>{lead.price}</div>
        </div>
    );
}

export default NewLeadView;