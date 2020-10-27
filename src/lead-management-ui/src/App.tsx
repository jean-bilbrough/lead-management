import React from 'react';
import { Container } from '@material-ui/core';
import { withStyles, WithStyles } from '@material-ui/core/styles';
import styles from './styles';
import LeadManagementRoot from './components/LeadManagementRoot';

import {
  createMuiTheme,
  ThemeProvider,
} from '@material-ui/core/styles';
import { orange, grey } from '@material-ui/core/colors';

const theme = createMuiTheme({
  palette: {
    primary: {
      main: grey[200],
    },
    secondary: {
      main: orange[700],
    },
  },
  typography: {
    fontFamily: 'Helvetica',
    fontSize: 14
  },
});

function App(props: WithStyles<typeof styles>) {
  const { classes } = props; 
  
  return(<ThemeProvider theme={theme}><Container className={classes.root} maxWidth='lg'>{LeadManagementRoot(props)}</Container></ThemeProvider>);
}

export default withStyles(styles)(App);