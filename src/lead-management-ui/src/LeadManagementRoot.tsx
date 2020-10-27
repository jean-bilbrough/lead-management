import React from 'react';
import { Grid, Tabs, Tab } from '@material-ui/core';
import { WithStyles } from '@material-ui/core/styles';
import styles from './styles';
import Invited from './Invited';
import Accepted from './Accepted';

const selectedView = (selection: number, props: WithStyles<typeof styles>) => {
    return (
        <div>
            {selection === 0 && <Invited {...props} />}
            {selection === 1 && <Accepted {...props} />}
        </div>
    );
};

function LeadManagementRoot(props: WithStyles<typeof styles>) {
    const { classes } = props;       

    const [viewSelection, setViewSelection] = React.useState(0);

    const handleChange = (event: any, newValue: any) => {
        setViewSelection(newValue);
    }

    return (
        <Grid container={true} justify='center' alignContent='stretch' direction='column'>
            <Tabs value={viewSelection} onChange={handleChange} variant='fullWidth'>
                <Tab label='Invited' className={classes.tab} />
                <Tab label='Accepted' className={classes.tab} />
            </Tabs>
            {selectedView(viewSelection, props)}
        </Grid>
    );
}

export default LeadManagementRoot;