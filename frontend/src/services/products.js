import axios from 'axios'

class ProductsService {
  getProducts() {
    return axios
      .get("https://localhost:5001/api/Products")
      .then(res => res.data);
  }
  getProductById(id) {
    return axios
      .get("https://localhost:5001/api/Products/"+id)
      .then(res => res.data);
  }
}

export default new ProductsService();