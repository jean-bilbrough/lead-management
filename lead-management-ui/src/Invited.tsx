import React from 'react';
import NewLeadView from './NewLeadView';
import Lead from './Lead';

function Invited() {
    const leads: Lead[] = [];
    leads.push(new Lead(
        'Bill',
        'January 4 @ 2:37 pm',
        'Yanderra 2574',
        'Painters',
        5577421,
        'Need to paint 2 aluminium windows and a sliding glass door',
        '$62.00 Lead Invitation'
    ));
    leads.push(new Lead(
        'Craig',
        'January 4 @ 1:15 pm',
        'Woolooware 2230',
        'Interior Painters',
        5588872,
        'interior walls 3 colours',
        '$49.00 Lead Invitation'
    ));
    leads.push(new Lead(
        'Susan',
        'January 4 @ 11:00 am',
        'Concorde 2211',
        'Painters',
        5599933,
        'external walls for house',
        '$650.00 Lead Invitation'
    ));

    return (
        <div>
            {leads.map(function(lead: Lead){return <div key={lead.jobId}>{NewLeadView(lead)}</div>})}
        </div>
    );
}

export default Invited;