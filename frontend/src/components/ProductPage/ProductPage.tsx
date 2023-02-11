import React from "react";
import { useQuery } from '@tanstack/react-query';
import ProductsService from "../../services/products";
import PricesService from "../../services/prices";
import OrdersService from "../../services/orders";
import RatingsService from "../../services/ratings";
import { useParams } from "react-router";
import { Price, Product } from "../../interfaces/interfaces";
import './ProductPage.scss';
import { ShopCard } from "../ShopCard/ShopCard";

export const ProductPage = () => {
  const params = useParams();
  const productQuery = useQuery({
    queryKey: ['product', params.id],
    queryFn: () => ProductsService.getProductById(params.id),
  })

  const pricesQuery = useQuery({
    queryKey: ['price', params.id],
    queryFn: () => PricesService.getPricesByProductId(params.id),
  })

  const ordersQuery = useQuery({
    queryKey: ['order', params.id],
    queryFn: () => OrdersService.getOrdersByProductId(params.id),
  })

  const ratingsQuery = useQuery({
    queryKey: ['rating', params.id],
    queryFn: () => RatingsService.getRatingsByProductId(params.id),
  })

  const product: Product = productQuery.data;
  const prices: Array<Price> = pricesQuery.data;
  const orders: Array<any> = ordersQuery.data;
  const ratings: Array<any> = ratingsQuery.data;

  function getOrders() {
    let numberOfOrders = 0;
    orders?.forEach(order => {
      numberOfOrders += order?.orderNumber;
    })

    return numberOfOrders;
  }

  function getRatings() {
    let numberOfRatings = 0;
    let averageRating = 0;
    
    ratings?.forEach(rating => {
      numberOfRatings += rating?.ratingNumber;
      averageRating += rating?.ratingGrade;
    })
    
    averageRating /= ratings?.filter(rating => rating?.ratingNumber > 0).length;
    return [numberOfRatings, averageRating];
  }

  function getPrices() {
    const now = new Date().toISOString().substring(0, 10);
    return prices?.filter(price => {
      return price?.priceDate.substring(0, 10) === now;
    })
  }

  function generateStars(numberOfStars: number) {
    const stars = [];
    for (let i = 1; i <= 5; i++) {
      if (numberOfStars > i) {
        stars.push(<i key={i} className="bi bi-star-fill"></i>)
      }
      else if (numberOfStars / i < 1 && (numberOfStars % 1 >= 0.5)) {
        stars.push(<i key={i} className="bi bi-star-half"></i>)
      }
      else {
        stars.push(<i key={i} className="bi bi-star"></i>)
      }
    }

    return stars;
  }

  const [numRatings, avgRating] = getRatings();
  const numOrders = getOrders();
  const actualPrices = getPrices()?.sort((x, y) => x.priceValue - y.priceValue);
  

  return (
    <div className="container">
      <div className="container-fluid">
        <div className="row">
          <div className="left col-md-6">
            <img src={product?.productImageUrl} />
          </div>
          <div className="d-flex flex-column right col-md-6">
            <h3 className="product-title">{product?.productName}</h3>
            <div className="rating">
              {generateStars(avgRating)}
              <span className="px-2">{numRatings} opinii</span>
              <i className="bi bi-info-circle"></i>
            </div>
            <div className="orders">
              <span className="py-2">Kupiło {numOrders} osób</span>
              <i className="bi bi-info-circle px-2"></i>
            </div>
            <p className="product-description mt-4">{product?.productDescription}</p>
            <h4 className="price">Najniższa cena: 389 zł</h4>
            <button><i className="bi bi-graph-up-arrow px-2"></i>Sprawdź historię ceny</button>
          </div>
        </div>
        <hr />
      </div>
      <>{actualPrices?.map((price: Price) => (
        <ShopCard key={price.priceId} {...price}/>
      ))}</>
    </div>
  )
}