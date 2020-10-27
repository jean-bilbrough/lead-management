import React from 'react';
import { Paper, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography } from '@material-ui/core';
import PlaceOutlined from '@material-ui/icons/PlaceOutlined';
import CardTravelOutlined from '@material-ui/icons/CardTravelOutlined';
import NewLead from './NewLead';
import Button from '@material-ui/core/Button';

const acceptOrDeclineLead = async (acceptOrDecline: string, jobId: number) => {
    console.log('acceptLead called');
    await fetch(`http://localhost:5000/${acceptOrDecline}?jobid=${jobId}`, {
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
        <Paper elevation={3}>
            <List>
                <ListItem>
                    <ListItemAvatar>
                        <Avatar>{lead.contactFirstName.charAt(0)}</Avatar>
                    </ListItemAvatar>
                    <ListItemText primary={lead.contactFirstName} secondary={lead.dateCreated} />
                    <Divider />
                </ListItem>
                <ListItem>
                    <PlaceOutlined color='inherit'/>
                    <Box mr={3}><Typography>{lead.suburb}</Typography></Box>
                    <CardTravelOutlined color='inherit' />
                    <Box mr={3}><Typography>{lead.category}</Typography></Box>
                    <Box mr={3}><Typography>Job ID: {lead.jobId}</Typography></Box>
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
        </Paper>
    );
}

export default NewLeadView;