import React from 'react';
import { Paper, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography, Button } from '@material-ui/core';
import PlaceOutlined from '@material-ui/icons/PlaceOutlined';
import CardTravelOutlined from '@material-ui/icons/CardTravelOutlined';
import { WithStyles } from '@material-ui/core/styles';
import styles from './styles';
import NewLead from './NewLead';

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

function NewLeadView(lead: NewLead, props: WithStyles<typeof styles>) { 
    const { classes } = props; 

    return(
        <Paper elevation={3}>
            <List>
                <ListItem>
                    <ListItemAvatar>
                        <Avatar className={classes.avatar}>{lead.contactFirstName.charAt(0)}</Avatar>
                    </ListItemAvatar>
                    <ListItemText primary={lead.contactFirstName} secondary={lead.dateCreated} />                    
                </ListItem>
                <Divider light/>
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
                <Divider light/>
                <ListItem>
                    <Button 
                        onClick={() => acceptOrDeclineLead('accept', lead.jobId)} 
                        variant='contained' className={classes.acceptButton}>
                            Accept
                    </Button>
                    <Button 
                        onClick={() => acceptOrDeclineLead('decline', lead.jobId)} 
                        variant='contained' className={classes.declineButton}>
                            Decline
                    </Button>
                    <Box ml={3}>{lead.price}</Box>
                </ListItem>            
            </List>
        </Paper>
    );
}

export default NewLeadView;