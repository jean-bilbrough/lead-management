import React from 'react';
import NewLeadView from './NewLeadView';
import Lead from './Lead';

function Invited() {
    const lead = new Lead(
        'Bill',
        'January 4 @ 2:37 pm',
        'Yanderra 2574',
        'Painters',
        5577421,
        'Need to paint 2 aluminium windows and a sliding glass door',
        '$62.00 Lead Invitation'
    );
    return (
        <div>
            {NewLeadView(lead)}
        </div>
    );
}

export default Invited;