import React from "react"
import { useSelector } from "react-redux";
import { Rating, Shop } from "../../interfaces/interfaces"
import { RootState } from "../../redux/store";
import './RatingsCard.scss'

export const RatingsCard = ({ratings}: any) => {
  const shops: Array<Shop> = useSelector((state: RootState) => {
    return state.allShops.shops;
  })

  return (
    <div className="card ratings-card">
      <p>Opinie dla poszczególnych sklepów:</p>
      {ratings?.map((rating: Rating) => (
        rating.ratingNumber !== -1 ? 
          <div className="row" key={rating.ratingId}>
            <div className="col">{shops.find(shop => shop.shopId == rating.shopId)?.shopName}
            </div>
            <div className="col text-end">{rating.ratingNumber} ({rating.ratingGrade > 5 ? (rating.ratingGrade * (5/6)).toFixed(2) : rating.ratingGrade})
            </div>
          </div>
          : <div className="row" key={rating.ratingId}>
            <div className="col">{shops.find(shop => shop.shopId == rating.shopId)?.shopName}
            </div>
            <div className="col text-end">Brak danych
            </div>
          </div>
      ))}
    </div>
  )
}