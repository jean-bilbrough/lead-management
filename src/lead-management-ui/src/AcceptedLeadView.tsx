import React from 'react';
import { Paper, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography } from '@material-ui/core';
import AcceptedLead from './AcceptedLead';

function AcceptedLeadView(lead: AcceptedLead) {
    return(
        <Paper elevation={3}>
            <List>
                <ListItem>
                    <ListItemAvatar>
                        <Avatar>{lead.contactFullName.charAt(0)}</Avatar>
                    </ListItemAvatar>
                    <ListItemText primary={lead.contactFullName} secondary={lead.dateCreated} />
                    <Divider />
                </ListItem>
                <ListItem>
                    <Box mr={3}>{lead.suburb}</Box>
                    <Box mr={3}>{lead.category}</Box>
                    <Box mr={3}>Job ID: {lead.jobId}</Box>
                    <Box mr={3}>{lead.price}</Box>
                </ListItem>
                <Divider light/>                
                <ListItem>
                    <Box mr={3}>{lead.contactPhoneNumber}</Box>
                    <Box mr={3}>{lead.contactEmail}</Box>
                </ListItem>
                <ListItem>
                    <Typography variant='body2' display='block' gutterBottom>{lead.description}</Typography>
                </ListItem>
            </List>
        </Paper>


    );
}

export default AcceptedLeadView;