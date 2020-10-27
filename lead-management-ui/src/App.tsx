import React from 'react';
import { ThemeProvider  } from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';
import LeadManagementRoot from './LeadManagementRoot';
import theme from './styles/leadManagementTheme';

function App() {  
  return(<ThemeProvider theme={theme}><Grid container><LeadManagementRoot /></Grid></ThemeProvider>);
}

export default App;