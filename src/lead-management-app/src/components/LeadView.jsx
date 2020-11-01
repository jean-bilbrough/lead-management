import { acceptOrDeclineLead } from '../services/leadManagementServices';

const accept = async (jobId, refresh, setRefresh) => {
    await acceptOrDeclineLead('accept', jobId);
    setRefresh(!refresh);
}

function Lead(lead, refresh, setRefresh) {
    return (
        <div>
            The lead id is {lead.jobId}
            <button onClick={async () => await accept(lead.jobId, refresh, setRefresh)}>Accept</button>
        </div>
    );
}

export default Lead;