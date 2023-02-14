import React from 'react'
import { useSelector } from "react-redux";
import { RootState } from "../../redux/store";
import { ProductCard } from "../ProductCard/ProductCard";
import { useQuery } from "@tanstack/react-query";
import ProductsService from "../../services/products"
import { Product } from "../../interfaces/interfaces";
import { Filter } from '../Filter/Filter';

export const Products = () => {
  const productsQuery = useQuery({
    queryKey: ['products'],
    queryFn: ProductsService.getProducts,
  })

  const filterBy = useSelector(
    (state: RootState) => state.productFilter.filter
  );

  const products: Array<Product> = productsQuery?.data;
    
  return (
    <div className='mx-4'>
      <Filter />
      <div className="d-flex flex-wrap">
        {products?.filter(product =>
          filterBy ? product.productName.toLowerCase().includes(filterBy) : true    
        )
          .map(product => (
            <ProductCard key={product.productId} {...product} />
          ))}
      </div>
    </div>
  )
}