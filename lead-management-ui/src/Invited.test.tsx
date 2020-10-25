import React from 'react';
import { render, screen, findAllByTestId } from '@testing-library/react';
import Invited from './Invited';

test('renders one new lead', () => {
    render(<Invited />);

    const element = screen.getByText('Bill');
    expect(element).toBeInTheDocument();
})