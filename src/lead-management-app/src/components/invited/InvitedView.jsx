import LeadView from '../LeadView';

function InvitedView(leads, refresh, setRefresh) {
    return (
        <div>
            {!leads || leads.map(function(lead){return <li key={lead.jobId}>{LeadView(lead, refresh, setRefresh)}</li>})}
        </div>
    );
}

export default InvitedView;