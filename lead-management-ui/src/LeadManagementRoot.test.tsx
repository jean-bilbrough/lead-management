import React from 'react';
import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import LeadManagementRoot from './LeadManagementRoot';
import nock from 'nock';

nock.disableNetConnect();
afterEach(() => {
    nock.cleanAll();
});

test('renders Invited tab', async () => {
    nock('https://localhost:5001')
    .defaultReplyHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Method': 'Get,Post,Put'
    })
    .options(/.*/)
    .reply(200)
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bill',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    });

    render(<LeadManagementRoot />);

    const invitedElement = screen.getByText('Invited');
    expect(invitedElement).toBeInTheDocument();

    const invitedList = await screen.findByText('Bill');
    expect(invitedList).toBeInTheDocument();
});

test('renders Accepted tab', async () => {
    nock('https://localhost:5001')
    .defaultReplyHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Method': 'Get,Post,Put'
    })
    .options(/.*/)
    .reply(200)
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bill',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    });

    render(<LeadManagementRoot />);

    const invitedElement = screen.getByText('Accepted');
    expect(invitedElement).toBeInTheDocument();

    const invitedList = await screen.findByText('Bill');
    expect(invitedList).toBeInTheDocument();
});

test('renders Invited list initially', async () => {
    nock('https://localhost:5001')
    .defaultReplyHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Method': 'Get,Post,Put'
    })
    .options(/.*/)
    .reply(200)
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bill',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    });

    render(<LeadManagementRoot />);

    const invitedList = await screen.findByText('Bill');
    expect(invitedList).toBeInTheDocument();
});

test('renders Accepted list when Accepted is selected', async () => {
    nock('https://localhost:5001')
    .defaultReplyHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Method': 'Get,Post,Put'
    })
    .options(/.*/)
    .reply(200)
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bill',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    });

    render(<LeadManagementRoot />);

    const invitedList = await screen.findByText('Bill');
    expect(invitedList).toBeInTheDocument();

    const acceptedButton= await screen.findByRole('button', { name: 'Accepted' });
    expect(acceptedButton).toBeInTheDocument();
    userEvent.click(acceptedButton);

    const acceptedList = screen.getByText('The accepted list');
    expect(acceptedList).toBeInTheDocument();
});

test('renders Invited list when Invited is selected after Accepted is selected', async () => {
    nock('https://localhost:5001')
    .defaultReplyHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Method': 'Get,Post,Put'
    })
    .options(/.*/)
    .reply(200)
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bill',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    })
    .get('/')
    .reply(200, {
        id: 'theleads',
        leads: [{
            contactFirstName: 'Bob',
            dateCreated: 'January 4 @ 2:37 pm',
            suburb: 'Yanderra 2574',
            category: 'Painters',
            jobId: 5577421,
            description: 'Need to paint 2 aluminium windows and a sliding glass door',
            price: '$62.00 Lead Invitation'
        }]
    });

    render(<LeadManagementRoot />);

    const firstInvitedList = await screen.findByText('Bill');
    expect(firstInvitedList).toBeInTheDocument();

    const acceptedButton= await screen.findByRole('button', { name: 'Accepted' });
    expect(acceptedButton).toBeInTheDocument();
    userEvent.click(acceptedButton);

    const acceptedList = screen.getByText('The accepted list');
    expect(acceptedList).toBeInTheDocument();

    const invitedButton= await screen.findByRole('button', { name: 'Invited' });
    expect(invitedButton).toBeInTheDocument();
    userEvent.click(invitedButton);

    const secondInvitedList = await screen.findByText('Bob');
    expect(secondInvitedList).toBeInTheDocument();
});