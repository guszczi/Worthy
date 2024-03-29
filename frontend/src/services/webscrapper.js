import axios from "axios";

class WebScrapperService {
  refreshData() {
    return axios.get("https://localhost:5001/api/WebScraper")
      .then(res => res.data)
  }
  getLastUpdateDate() {
    return axios.get("https://localhost:5001/api/WebScraper/date")
      .then(res => res.data)
  }
}

export default new WebScrapperService();