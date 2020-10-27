import { createStyles } from '@material-ui/core/styles';
import { orange, grey } from '@material-ui/core/colors';

const styles = createStyles({
    root : {
        color: grey[600],
        backgroundColor: grey[200],
        padding: '10, 20, 10, 20'
    },
    tab: {
        backgroundColor: '#ffffff',
        marginTop: 15,
        padding: 0,
        color: grey[800],
        fontWeight: 'bold',
        fontSize: 16
    },
    avatar: {
      color: '#ffffff',
      backgroundColor: orange[400],
    },
    acceptButton: {
        color: '#ffffff',
        fontWeight: 'bold',
        backgroundColor: orange[700],
        marginRight: 15
    },
    declineButton: {
        color: grey[600],
        fontWeight: 'bold',
        backgroundColor: grey[200]
    },
    contactInformation: {
        color: orange[800],
        fontWeight: 'heavy',
    }
  });

  export default styles;