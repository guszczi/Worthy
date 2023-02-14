import React from "react"
import { useSelector } from "react-redux";
import { Order, Shop } from "../../interfaces/interfaces"
import { RootState } from "../../redux/store";
import './OrdersCard.scss'

export const OrdersCard = ({orders}: any) => {
  const shops: Array<Shop> = useSelector((state: RootState) => {
    return state.allShops.shops;
  })

  return (
    <div className="card orders-card">
      <p>Liczba zamówień dla poszczególnych sklepów:</p>
      {orders?.map((order: Order) => (
        order.orderNumber !== -1 ? 
          <div className="row" key={order.orderId}>
            <div className="col">{shops.find(shop => shop.shopId == order.shopId)?.shopName}
            </div>
            <div className="col text-end">{order.orderNumber}
            </div>
          </div>
          : <div className="row" key={order.orderId}>
            <div className="col">{shops.find(shop => shop.shopId == order.shopId)?.shopName}
            </div>
            <div className="col text-end">Brak danych
            </div>
          </div>
      ))}
    </div>
  )
}