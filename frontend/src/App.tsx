import './App.scss';
import React from 'react'
import { Products } from './components/Products/Products';
import { ProductPage } from './components/ProductPage/ProductPage';
import { Navbar } from './components/Navbar/Navbar';
import { Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route path='/' element={<Products />} />
        <Route path='/products/:id' element={<ProductPage />} />
        <Route path='/*' element={<h1>rip</h1>} />
      </Routes>
    </div>
  );
}

export default App;
