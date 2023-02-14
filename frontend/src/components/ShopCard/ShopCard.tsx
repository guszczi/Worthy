import React from 'react'
import { useSelector } from 'react-redux';
import { Link, Price, Shop } from '../../interfaces/interfaces';
import { RootState } from '../../redux/store';

import './ShopCard.scss'

export const ShopCard = (props: Price) => {
  const shops: Array<Shop> = useSelector((state: RootState) => {
    return state.allShops.shops;
  })

  const links: Array<Link> = useSelector((state: RootState) => {
    return state.allLinks.links;
  })

  const {priceValue, productId, shopId} = props;

  const shop = shops?.find(shop => shop?.shopId == shopId)
  const link = links?.find(link => link?.shopId == shopId && link?.productId == productId)
  
  return (
    <div className="card my-4">
      <div className="card-body shop-card-body row">
        <div className='col-4 d-flex align-items-center shop-name'>{shop?.shopName}</div>
        <div className='col d-flex align-items-center justify-content-end'>{priceValue.toFixed(2)} zł</div>
        <div className='col text-end'><a href={link?.linkUrl}><button type='button' className='btn btn-primary'>Idź do sklepu</button></a></div>
      </div>
    </div>
  )
}