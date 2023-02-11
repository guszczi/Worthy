import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import React from 'react';

const data = [
  { name: 'Jan 1', price: 100 },
  { name: 'Feb 1', price: 120 },
  { name: 'Mar 1', price: 110 },
  { name: 'Apr 1', price: 130 },
  { name: 'May 1', price: 140 },
  { name: 'Jun 1', price: 150 },
  { name: 'Jul 1', price: 145 },
  { name: 'Aug 1', price: 135 },
  { name: 'Sep 1', price: 160 },
  { name: 'Oct 1', price: 170 },
  { name: 'Nov 1', price: 165 },
  { name: 'Dec 1', price: 175 },
];

export const Chart = () => {
  return (
    <LineChart width={1000} height={600} data={data} margin={{ top: 5, right: 30, left: 20, bottom: 5 }}>
      <XAxis dataKey="name" />
      <YAxis />
      <CartesianGrid strokeDasharray="3 3" />
      <Tooltip />
      <Legend />
      <Line type="monotone" dataKey="price" stroke="#8884d8" activeDot={{ r: 8 }} />
    </LineChart>
  );
}