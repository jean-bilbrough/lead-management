import React from 'react';
import { render, screen } from '@testing-library/react';
import Invited from './Invited';
import nock from 'nock';

nock.disableNetConnect();
afterEach(() => {
    nock.cleanAll();
});

test('renders one new lead', async () => {
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

    render(<Invited />);

    const element = await screen.findByText('Bill');
    expect(element).toBeInTheDocument();
});

test('renders a list of leads', async () => {
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
        }, {
            contactFirstName: 'Craig',
            dateCreated: 'January 4 @ 1:15 pm',
            suburb: 'Woolooware 2230',
            category: 'Interior Painters',
            jobId: 5588872,
            description: 'interior walls 3 colours',
            price: '$49.00 Lead Invitation'
        }, {
            contactFirstName: 'Susan',
            dateCreated: 'January 4 @ 11:00 am',
            suburb: 'Concorde 2211',
            category: 'Painters',
            jobId: 5599933,
            description: 'external walls for house',
            price: '$650.00 Lead Invitation'
        }]
    });

    render(<Invited />);

    const firstElement = await screen.findByText('Bill');
    expect(firstElement).toBeInTheDocument();

    const secondElement = await screen.findByText('Craig');
    expect(secondElement).toBeInTheDocument();

    const thirdElement = await screen.findByText('Susan');
    expect(thirdElement).toBeInTheDocument();
});