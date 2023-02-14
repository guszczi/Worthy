import React, { useState } from "react";
import { useQuery } from '@tanstack/react-query';
import ProductsService from "../../services/products";
import PricesService from "../../services/prices";
import OrdersService from "../../services/orders";
import RatingsService from "../../services/ratings";
import { useParams } from "react-router";
import { Order, Price, Product, Rating } from "../../interfaces/interfaces";
import './ProductPage.scss';
import { ShopCard } from "../ShopCard/ShopCard";
import { Modal } from "react-bootstrap";
import { Chart } from "../Chart/Chart";
import OverlayTrigger from "react-bootstrap/esm/OverlayTrigger";
import Tooltip from "react-bootstrap/esm/Tooltip";
import { OrdersCard } from "../OrdersCard/OrdersCard";
import { RatingsCard } from "../RatingsCard/RatingsCard";

export const ProductPage = () => {
  const params = useParams();

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  
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

  const dailyPricesQuery = useQuery({
    queryKey: ['dailyPrice', params.id],
    queryFn: () => PricesService.getDailyPricesByProductId(params.id)
  })

  const product: Product = productQuery.data;
  const prices: Array<Price> = pricesQuery.data;
  const orders: Array<Order> = ordersQuery.data;
  const ratings: Array<Rating> = ratingsQuery.data;
  const dailyPrices: any = dailyPricesQuery.data;

  const lowestPrice: Price = prices?.reduce((prev, curr) => prev.priceValue < curr.priceValue ? prev : curr);

  function getOrders() {
    let numberOfOrders = 0;
    
    orders?.filter(order => order?.orderNumber >= 0)?.forEach(order => {
      numberOfOrders += order?.orderNumber;
    })

    return numberOfOrders;
  }

  function getRatings() {
    let numberOfRatings = 0;
    let averageRating = 0;
    
    ratings?.forEach(rating => {
      numberOfRatings += rating?.ratingNumber;
      averageRating += rating?.ratingGrade * rating?.ratingNumber;
    })
    
    averageRating /= numberOfRatings;
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
              <OverlayTrigger 
                placement="right" 
                overlay={<Tooltip><RatingsCard ratings={ratings}/></Tooltip>} 
                delay={{show: 150, hide: 150}}
                
              >
                <i className="bi bi-info-circle"></i>
              </OverlayTrigger>
            </div>
            <div className="orders">
              <span className="py-2">Kupiło {numOrders} osób</span>
              <OverlayTrigger 
                placement="right" 
                overlay={<Tooltip><OrdersCard orders={orders}/></Tooltip>} 
                delay={{show: 150, hide: 150}}
                
              >
                <i className="bi bi-info-circle px-2"></i>
              </OverlayTrigger>
            </div>
            <p className="product-description mt-4">{product?.productDescription}</p>
            <h4 className="price">Najniższa cena: {lowestPrice?.priceValue.toFixed(2)} zł - {lowestPrice?.priceDate.substring(0, 10)}</h4>
            <button 
              type="button" 
              className="btn btn-primary my-4"
              onClick={handleShow}>
              <i className="bi bi-graph-up-arrow px-2"></i>
              Sprawdź historię ceny
            </button>
          </div>
        </div>
      </div>
      <hr />
      <>{actualPrices?.map((price: Price) => (
        <ShopCard key={price.priceId} {...price}/>
      ))}</>
      <Modal show={show} onHide={handleClose} size={'lg'}>
        <Modal.Header closeButton>
          <Modal.Title>Historia cen</Modal.Title>
        </Modal.Header>
        <Modal.Body><div className="modal-chart"><Chart prices={dailyPrices}/></div></Modal.Body>
      </Modal>
      
    </div>
  )
}