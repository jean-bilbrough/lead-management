import React from 'react';
import { Paper, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography } from '@material-ui/core';
import PlaceOutlined from '@material-ui/icons/PlaceOutlined';
import CardTravelOutlined from '@material-ui/icons/CardTravelOutlined';
import PhoneOutlined from '@material-ui/icons/PhoneOutlined';
import EmailOutlined from '@material-ui/icons/EmailOutlined';
import { WithStyles } from '@material-ui/core/styles';
import styles from '../styles';
import AcceptedLead from './accepted/AcceptedLead';

function AcceptedLeadView(lead: AcceptedLead, props: WithStyles<typeof styles>) {
    const { classes } = props;

    return(        
        <Paper elevation={3}>
            <List>
                <ListItem>
                    <ListItemAvatar>
                        <Avatar className={classes.avatar}>{lead.contactFullName.charAt(0)}</Avatar>
                    </ListItemAvatar>
                    <ListItemText primary={lead.contactFullName} secondary={lead.dateCreated} />                    
                </ListItem>
                <Divider light/>
                <ListItem>
                    <PlaceOutlined color='inherit'/>
                    <Box mr={3}><Typography>{lead.suburb}</Typography></Box>
                    <CardTravelOutlined color='inherit'/>
                    <Box mr={3}><Typography>{lead.category}</Typography></Box>
                    <Box mr={3}><Typography>Job ID: {lead.jobId}</Typography></Box>
                    <Box mr={3}><Typography>{lead.price}</Typography></Box>
                </ListItem>
                <Divider light/>                
                <ListItem>
                    <PhoneOutlined color='inherit'/>
                    <Box mr={3}><Typography className={classes.contactInformation}>{lead.contactPhoneNumber}</Typography></Box>
                    <EmailOutlined color='inherit'/>
                    <Box mr={3}><Typography className={classes.contactInformation}>{lead.contactEmail}</Typography></Box>
                </ListItem>
                <Divider light/> 
                <ListItem>
                    <Typography variant='body2' display='block' gutterBottom>{lead.description}</Typography>
                </ListItem>
            </List>
        </Paper>
    );
}

export default AcceptedLeadView;