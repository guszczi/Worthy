import axios from "axios";

class RatingsService {
  getRatingsByProductId(id) {
    return axios.get("https://localhost:5001/api/Ratings/byProductId?productId="+id)
      .then(res => res.data);
  }
  getRatings() {
    return axios.get("https://localhost:5001/api/Ratings")
      .then(res => res.data)
  }
}

export default new RatingsService();