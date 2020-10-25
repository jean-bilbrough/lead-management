import React from 'react';
import { render, screen } from '@testing-library/react';
import Invited from './Invited';

test('renders one new lead', () => {
    render(<Invited />);

    const element = screen.getByText('Bill');
    expect(element).toBeInTheDocument();
});

test('renders a list of leads', () => {
    render(<Invited />);

    const firstElement = screen.getByText('Bill');
    expect(firstElement).toBeInTheDocument();

    const secondElement = screen.getByText('Craig');
    expect(secondElement).toBeInTheDocument();

    const thirdElement = screen.getByText('Susan');
    expect(thirdElement).toBeInTheDocument();
});