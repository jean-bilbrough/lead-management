
export const getNewLeads = async () => {
    const response = await fetch('http://localhost:5000', {
        method: 'GET'
    })
    .then(contents => { return contents.json(); })
    .catch(err => {
        console.error('getNewLeads error:', err);
        return err
    });
    return response;
};

export const getAcceptedLeads = async () => {
    const response = await fetch('http://localhost:5000/accepted', {
        method: 'GET'
    })
    .then(contents => { return contents.json(); })
    .catch(err => {
        console.error('getAcceptedLeads error:', err);
        return err
    });
    return response;
};

export const acceptOrDeclineLead = async (acceptOrDecline, jobId) => {
    await fetch(`http://localhost:5000/${acceptOrDecline}?jobid=${jobId}`, {
        method: 'PUT'
    })
    .catch(err => {
        console.error('acceptLead error:', err);
        return err
    });
};