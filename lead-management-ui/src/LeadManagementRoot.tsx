import React from 'react';
import Invited from './Invited';
import Accepted from './Accepted';

const SelectedView = (selection: string) => {
    return (
        <div>
            {selection === 'INVITED' && <Invited />}
            {selection === 'ACCEPTED' && <Accepted />}
        </div>
    );
};

function LeadManagementRoot() {
    const [viewSelection, setViewSelection] = React.useState('INVITED');

    return (
        <div>
            <div>
                <button onClick={() => setViewSelection('INVITED')}>Invited</button>
                <button onClick={() => setViewSelection('ACCEPTED')}>Accepted</button>
            </div>
            {SelectedView(viewSelection)}
        </div>
    );
}

export default LeadManagementRoot;