import React from "react";
import './ProductCard.scss';

interface Product {
  name: string;
  description: string;
  cost: number;
  imageUrl: string;
}

export const ProductCard = (props: Product) => {
  const {name, description, cost, imageUrl} = props;

  const showAlert = () => {
    alert(name)
  }

  return (
    <div className="col-sm-3">
      <div className="card">
        <img src={imageUrl} className="card-img-top" onClick={showAlert} alt="This is a product's image"/>
        <div className="card-body">
          <h5 className="card-title">{name}</h5>
          <p className="card-text">{description}</p>
          <p className="card-text">Już od {cost} zł</p>
        </div>
      </div>
    </div>
  )
}