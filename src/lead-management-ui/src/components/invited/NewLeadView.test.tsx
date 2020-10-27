import { render, screen } from '@testing-library/react';
import NewLeadView from './NewLeadView';
import NewLead from './NewLead';

const lead = new NewLead(
    'Bill',
    'January 4 @ 2:37 pm',
    'Yanderra 2574',
    'Painters',
    5577421,
    'Need to paint 2 aluminium windows and a sliding glass door',
    '$62.00 Lead Invitation'
);

test('renders contact first name', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('Bill');
    expect(element).toBeInTheDocument();
});

test('renders date created', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('January 4 @ 2:37 pm');
    expect(element).toBeInTheDocument();
});

test('renders suburb', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('Yanderra 2574');
    expect(element).toBeInTheDocument();
});

test('renders category', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('Painters');
    expect(element).toBeInTheDocument();
});

test('renders job id', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('5577421');
    expect(element).toBeInTheDocument();
});

test('renders description', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('Need to paint 2 aluminium windows and a sliding glass door');
    expect(element).toBeInTheDocument();
});

test('renders price', () => {
    render(NewLeadView(lead));

    const element = screen.getByText('$62.00 Lead Invitation');
    expect(element).toBeInTheDocument();
});

test('renders Accept button', async () => {
    render(NewLeadView(lead));

    const acceptButton= await screen.findByRole('button', { name: 'Accept' });
    expect(acceptButton).toBeInTheDocument();
});

test('renders Decline button', async () => {
    render(NewLeadView(lead));

    const declineButton= await screen.findByRole('button', { name: 'Decline' });
    expect(declineButton).toBeInTheDocument();
});