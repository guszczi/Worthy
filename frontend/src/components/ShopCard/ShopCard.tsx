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
    <div className="card">
      <div className="card-body shop-card-body">
        <p>{shop?.shopName}</p>
        <p>{priceValue} zł</p>
        <a href={link?.linkUrl}><input type="button" value="Przejdź do sklepu"/></a>
      </div>
    </div>
  )
}