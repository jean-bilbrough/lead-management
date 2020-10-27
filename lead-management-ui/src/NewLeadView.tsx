import React from 'react';
import { Card, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography } from '@material-ui/core';
import NewLead from './NewLead';
import Button from '@material-ui/core/Button';

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

function NewLeadView(lead: NewLead) {
    return(
        <Card>
            <List>
                <ListItem>
                    <ListItemAvatar>
                        <Avatar>{lead.contactFirstName.charAt(0)}</Avatar>
                    </ListItemAvatar>
                    <ListItemText primary={lead.contactFirstName} secondary={lead.dateCreated} />
                    <Divider />
                </ListItem>
                <ListItem>
                    <Box mr={3}>{lead.suburb}</Box>
                    <Box mr={3}>{lead.category}</Box>
                    <Box mr={3}>Job ID: {lead.jobId}</Box>
                </ListItem>
                <Divider light/>
                <ListItem>
                    <Typography variant='body2' display='block' gutterBottom>{lead.description}</Typography>
                </ListItem>
                <ListItem>
                    <Button onClick={() => acceptOrDeclineLead('accept', lead.jobId)}>Accept</Button>
                    <Button onClick={() => acceptOrDeclineLead('decline', lead.jobId)}>Decline</Button>
                    <Box ml={3}>{lead.price}</Box>
                </ListItem>            
            </List>
        </Card>
    );
}

export default NewLeadView;