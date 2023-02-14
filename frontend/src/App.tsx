import './App.scss';
import React, { useEffect } from 'react'
import { Products } from './components/Products/Products';
import { ProductPage } from './components/ProductPage/ProductPage';
import { Navbar } from './components/Navbar/Navbar';
import { Route, Routes } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
import { setShops } from './redux/slices/shopsSlice';
import { setLinks } from './redux/slices/linksSlice';
import { useDispatch } from 'react-redux';
import ShopsService from "./services/shops"
import LinksService from "./services/links"
import OrdersService from "./services/orders"
import RatingsService from "./services/ratings"
import WebScrapperService from "./services/webscrapper"
import { setOrders } from './redux/slices/ordersSlice';
import { setRatings } from './redux/slices/ratingsSlice';

function App() {
  const dispatch = useDispatch();
  const shopsQuery = useQuery({
    queryKey: ['shops'],
    queryFn: ShopsService.getShops,
  })

  const linksQuery = useQuery({
    queryKey: ['links'],
    queryFn: LinksService.getLinks,
  })

  const ordersQuery = useQuery({
    queryKey: ['orders'],
    queryFn: OrdersService.getOrders,
  })

  const ratingsQuery = useQuery({
    queryKey: ['ratings'],
    queryFn: RatingsService.getRatings,
  })

  useEffect(() => {
    dispatch(setOrders(ordersQuery?.data))
    dispatch(setLinks(linksQuery?.data))
    dispatch(setRatings(ratingsQuery?.data))
    dispatch(setShops(shopsQuery?.data))
  })

  const today = new Date().toISOString().substring(0, 10)

  if (localStorage.getItem('updateDate') != today) {
    WebScrapperService.refreshData();
    localStorage.setItem('updateDate', today)
  }

  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route path='/' element={<Products />} />
        <Route path='/products/:id' element={<ProductPage />} />
        <Route path='/*' element={<h1 className="my-4">Nie znaleziono zasobu.</h1>} />
      </Routes>
    </div>
  );
}

export default App;
