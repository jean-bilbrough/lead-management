import React from 'react';
import Lead from './Lead';

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
                <button>Accept</button>
                <button>Decline</button>
            </div>
            <div>{lead.price}</div>
        </div>
    );
}

export default NewLeadView;