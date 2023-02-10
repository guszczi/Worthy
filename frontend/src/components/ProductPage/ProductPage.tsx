import React from "react";
import {useQuery, useMutation} from '@tanstack/react-query';
import ProductsService from "../../services/products";
import PricesService from "../../services/prices";
import { useParams } from "react-router";

interface Product {
  productId: number;
  productName: string;
  productDescription: string;
  productImageUrl: string;
}

interface Price {
  priceId: number;
  priceDate: Date;
  priceValue: number;
  shopId: number;
}

export const ProductPage = () => {
  const params = useParams();
  const productQuery = useQuery({
    queryKey: ['product', params.id],
    queryFn: () => ProductsService.getProductById(params.id),
  })

  const pricesQuery = useQuery({
    queryKey: ['price'],
    queryFn: () => PricesService.getPricesByProductId(params.id),
  })

  const product: Product = productQuery.data;
  const prices: Array<Price> = pricesQuery.data;

  return (
    <div>
      <h1>{product?.productName}</h1>
      <p>{product?.productDescription}</p>
      <p>{product?.productImageUrl}</p>

      
    </div>
  )
}