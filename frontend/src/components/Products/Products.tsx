import { useState } from "react";
import React from 'react'
import { useSelector } from "react-redux";
import { RootState } from "../../redux/store";
import { ProductCard } from "../ProductCard/ProductCard";

const initialProducts = [
  {name: 'jeden', description: 'xd', cost: 10, imageUrl: 'https://purr.objects-us-east-1.dream.io/i/thirsty.jpg'},
  {name: 'dwa',  description: 'xd', cost: 10, imageUrl: 'https://purr.objects-us-east-1.dream.io/i/thirsty.jpg'},
  {name: 'trzy',  description: 'xd', cost: 10, imageUrl: 'https://purr.objects-us-east-1.dream.io/i/mycat.jpeg'},
  {name: 'cztery',  description: 'xd', cost: 10, imageUrl: 'https://purr.objects-us-east-1.dream.io/i/capturadepantalla2017-12-17alas9.32.51p.m..png'},
  {name: 'pięć',  description: 'xd', cost: 10, imageUrl: 'https://purr.objects-us-east-1.dream.io/i/capturadepantalla2017-12-17alas9.32.51p.m..png'}
];

export const Products = () => {
  const [products] = useState(initialProducts);

  const filterBy = useSelector(
    (state: RootState) => state.productFilter.filter
  );
    
  return (
    <div className="d-flex flex-wrap">
      {products
        .filter(product =>
          filterBy ? product.name.includes(filterBy) : true    
        )
        .map(product => (
          <ProductCard key={product.name} {...product}/>
        ))}
    </div>
  )
}