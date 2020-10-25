import React from 'react';
import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import LeadManagementRoot from './LeadManagementRoot';

test('renders Invited tab', () => {
    render(<LeadManagementRoot />);

    const invitedElement = screen.getByText('Invited');
    expect(invitedElement).toBeInTheDocument();
});

test('renders Accepted tab', () => {
    render(<LeadManagementRoot />);

    const invitedElement = screen.getByText('Accepted');
    expect(invitedElement).toBeInTheDocument();
});

test('renders Invited list initially', () => {
    render(<LeadManagementRoot />);

    const invitedList = screen.getByText('Bill');
    expect(invitedList).toBeInTheDocument();
});

test('renders Accepted list when Accepted is selected', async () => {
    render(<LeadManagementRoot />);

    const acceptedButton= await screen.findByRole('button', { name: 'Accepted' });
    expect(acceptedButton).toBeInTheDocument();
    userEvent.click(acceptedButton);

    const acceptedList = screen.getByText('The accepted list');
    expect(acceptedList).toBeInTheDocument();
});

test('renders Invited list when Invited is selected after Accepted is selected', async () => {
    render(<LeadManagementRoot />);

    const acceptedButton= await screen.findByRole('button', { name: 'Accepted' });
    expect(acceptedButton).toBeInTheDocument();
    userEvent.click(acceptedButton);

    const acceptedList = screen.getByText('The accepted list');
    expect(acceptedList).toBeInTheDocument();

    const invitedButton= await screen.findByRole('button', { name: 'Invited' });
    expect(invitedButton).toBeInTheDocument();
    userEvent.click(invitedButton);

    const invitedList = screen.getByText('Bill');
    expect(invitedList).toBeInTheDocument();
});