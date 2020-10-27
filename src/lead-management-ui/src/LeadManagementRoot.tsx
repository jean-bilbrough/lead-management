import React from 'react';
import { Grid, Tabs, Tab } from '@material-ui/core';
import Invited from './Invited';
import Accepted from './Accepted';

const selectedView = (selection: number) => {
    return (
        <div>
            {selection === 0 && <Invited />}
            {selection === 1 && <Accepted />}
        </div>
    );
};

function LeadManagementRoot() {
    const [viewSelection, setViewSelection] = React.useState(0);

    const handleChange = (event: any, newValue: any) => {
        setViewSelection(newValue);
    }

    return (
        <Grid container justify='center' alignItems='flex-start'>
            <Tabs value={viewSelection} onChange={handleChange} >
                <Tab label='Invited' />
                <Tab label='Accepted' />
            </Tabs>
            {selectedView(viewSelection)}
        </Grid>
    );
}

export default LeadManagementRoot;