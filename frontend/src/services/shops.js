import axios from "axios";

class ShopsService {
  getShops() {
    return axios.get('https://localhost:5001/api/Shops')
      .then(res => res.data)
  }
}

export default new ShopsService();