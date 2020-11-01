import LeadView from '../LeadView';

function AcceptedView(leads) {
    return (
        <div>
            {!leads || leads.map(function(lead){return <li key={lead.jobId}>{LeadView(lead)}</li>})}
        </div>
    );
}

export default AcceptedView;