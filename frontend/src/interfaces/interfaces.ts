export interface Product {
  productId: number,
  productName: string,
  productDescription: string,
  productImageUrl: string,
}

export interface Price {
  priceId: number,
  priceDate: string,
  priceValue: number,
  productId: number,
  shopId: number,
}

export interface Order {
  orderId: number,
  orderNumber: number,
  productId: number,
  shopId: number,
}

export interface Rating {
  ratingId: number,
  ratingNumber: number,
  ratingGrade: number,
  productId: number,
  shopId: number,
}

export interface Shop {
  shopId: number,
  shopName: string,
}

export interface Link {
  linkUrl: string,
  productId: number,
  shopId: number,
}