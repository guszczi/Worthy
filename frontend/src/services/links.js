import axios from "axios";

class LinksService {
  getLinksByProductId(id) {
    return axios.get("https://localhost:5001/api/Links/byProductId?id="+id)
      .then(res => res.data);
  }
  getLinks() {
    return axios.get("https://localhost:5001/api/Links")
      .then(res => res.data)
  }
}

export default new LinksService();