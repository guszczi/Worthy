import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import React from 'react';
import { Price } from '../../interfaces/interfaces';


export const Chart = ({prices}: any) => {
  const data: any = [];

  prices?.map((price: Price) => {
    data.push({
      name: price.priceDate.substring(0, 10),
      cena: price.priceValue,
    })
  })
  
  return (
    <ResponsiveContainer width='100%' aspect={4.0/3.0}>
      <LineChart data={data.slice(-30)}>
        <XAxis dataKey="name" />
        <YAxis domain={[data?.reduce((prev:any, curr:any) => prev.priceValue < curr.priceValue), data?.reduce((prev:any, curr:any) => prev.priceValue > curr.priceValue)]}/>
        <CartesianGrid strokeDasharray="3 3" />
        <Tooltip />
        <Legend />
        <Line type="monotone" dataKey="cena" stroke="#8884d8" activeDot={{ r: 8 }} />
      </LineChart>
    </ResponsiveContainer>
  );
}