import React from "react";
import { useNavigate } from "react-router-dom";
import './ProductCard.scss';
import { Price, Product } from "../../interfaces/interfaces";
import PricesService from "../../services/prices"
import { useQuery } from "@tanstack/react-query";


export const ProductCard = (props: Product) => {
  const {productId, productName, productDescription, productImageUrl} = props;
  const navigate = useNavigate();
  const now = new Date().toISOString().substring(0, 10);

  const goToProduct = () => {
    navigate("/products/"+productId)
  };

  const pricesQuery = useQuery({
    queryKey: ['product', productId],
    queryFn: () => PricesService.getPricesByProductId(productId),
  })

  const prices: Price[] = pricesQuery.data;
  const lowestPrice = prices?.filter(price => price?.priceDate.substring(0, 10) === now)?.sort((x, y) => x.priceValue - y.priceValue)[0]?.priceValue

  return (
    <div className="col-md-3">
      <div className="card product-card" onClick={goToProduct}>
        <div>
          <img src={productImageUrl} className="card-img-top" alt="This is a product's image"/>
        </div>
        <div className="card-body product-content">
          <h5 className="card-title">{productName}</h5>
          <p className="card-text">{productDescription}</p>
          <p className="card-text text-center">Już od {lowestPrice?.toFixed(2)} zł</p>
        </div>
      </div>
    </div>
  )
}