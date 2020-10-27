import React from 'react';
import { Paper, List, ListItem, ListItemText, ListItemAvatar, Avatar, Divider, Box, Typography } from '@material-ui/core';
import PlaceOutlined from '@material-ui/icons/PlaceOutlined';
import CardTravelOutlined from '@material-ui/icons/CardTravelOutlined';
import PhoneOutlined from '@material-ui/icons/PhoneOutlined';
import EmailOutlined from '@material-ui/icons/EmailOutlined';
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
                    <Box mr={3}>{lead.contactPhoneNumber}</Box>
                    <EmailOutlined color='inherit'/>
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