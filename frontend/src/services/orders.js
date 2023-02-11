import axios from "axios";

class OrdersService {
  getOrdersByProductId(id) {
    return axios.get("https://localhost:5001/api/Orders/byProductId?productId="+id)
      .then(res => res.data);
  }
  getOrders() {
    return axios.get("https://localhost:5001/api/Orders")
      .then(res => res.data)
  }
}

export default new OrdersService();