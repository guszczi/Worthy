import React from "react";
import { useNavigate } from "react-router-dom";
import './ProductCard.scss';
import { Product } from "../../interfaces/interfaces";


export const ProductCard = (props: Product) => {
  const {productId, productName, productDescription, productImageUrl} = props;
  const navigate = useNavigate();

  const goToProduct = () => {
    navigate("/products/"+productId)
  };

  return (
    <div className="col-md-3">
      <div className="card product-card" onClick={goToProduct}>
        <img src={productImageUrl} className="card-img-top" alt="This is a product's image"/>
        <div className="card-body product-content">
          <h5 className="card-title">{productName}</h5>
          <p className="card-text">{productDescription}</p>
          <p className="card-text">Już od {12} zł</p>
        </div>
      </div>
    </div>
  )
}