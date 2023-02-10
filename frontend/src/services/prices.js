import axios from "axios";

class PricesService {
  getPricesByProductId(id) {
    return axios
      .get("https://localhost:5001/api/Prices/byProductId?id="+id)
      .then(res => res.data);
  }
}

export default new PricesService();