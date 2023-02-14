using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Entities.Requests;
using HtmlAgilityPack;

namespace backend.Entities
{
    public class Utils
    {
        public static async Task<List<string>> GetData(ScraperRequest scraperRequest)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                                                                    "AppleWebKit/537.36 (KHTML, like Gecko) " +
                                                                    "Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.62");
                    using (HttpResponseMessage res = await client.GetAsync(scraperRequest.Url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            HtmlDocument htmlDoc = new HtmlDocument();
                            htmlDoc.LoadHtml(data);

                            var productPrice = "";
                            var ratingGrade = "";
                            var ratingNumber = "";
                            var orderNumber = "";

                            switch (scraperRequest.ShopId)
                            {
                                case 1:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='sc-n4n86h-4 jwVRpW']")
                                        .First().GetDirectInnerText();
                                    productPrice = productPrice.Remove(productPrice.Length - 3).Replace(',', '.');

                                    try
                                    {
                                        ratingGrade = htmlDoc.DocumentNode
                                            .SelectNodes("//span[@class='sc-1cbpuwv-1 kkBwHb']")
                                            .First().GetDirectInnerText().Replace(',', '.');
                                        ratingNumber = htmlDoc.DocumentNode.SelectNodes("//span[@class='sc-1ngc1lj-2 eJPDue']")
                                            .First().GetDirectInnerText();
                                        ratingNumber = Regex.Match(ratingNumber, @"\((\d+)\s").Groups[1].Value;
                                    }
                                    catch
                                    {
                                        ratingGrade = "0";
                                        ratingNumber = "0";
                                    }
                                    orderNumber = "-1";
                                    break;
                                case 2:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='product-price']")
                                        .First().Attributes["content"].Value;
                                    try
                                    {
                                        ratingGrade = htmlDoc.DocumentNode.SelectNodes("//div[@class='review-rating-number']")
                                            .First().GetDirectInnerText().Split('/')[0];
                                        ratingNumber = htmlDoc.DocumentNode.SelectNodes("//span[@class='rating-count']")
                                            .First().GetDirectInnerText();
                                        ratingNumber = Regex.Match(ratingNumber, @"\((\d+)\)").Groups[1].Value;
                                    }
                                    catch
                                    {
                                        ratingGrade = "0";
                                        ratingNumber = "0";
                                    }

                                    try
                                    {
                                        orderNumber = htmlDoc.DocumentNode
                                            .SelectNodes("//div[@class='prod-sold btn-get-sold-info text-link-2']")
                                            .First().GetDirectInnerText();
                                        orderNumber = Regex.Match(orderNumber, @"\b(\d+)\b").Groups[1].Value;
                                    }
                                    catch
                                    {
                                        orderNumber = "0";
                                    }
                                    break;
                                case 3:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//span[@class='text-3xl font-bold tests-final-price']")
                                        .First().GetDirectInnerText();
                                    try
                                    {
                                        ratingGrade = htmlDoc.DocumentNode.SelectNodes("//div[@class='text-[2.625rem] leading-4 text-center']")
                                            .First().GetDirectInnerText();
                                        ratingNumber = htmlDoc.DocumentNode.SelectNodes(
                                                "//div[@class='flex space-x-2']//span")
                                            .First().GetDirectInnerText().Split(' ')[0];
                                    }
                                    catch
                                    {
                                        ratingGrade = "0";
                                        ratingNumber = "0";
                                    }
                                    
                                    productPrice = Regex.Replace(productPrice, @"\s+", "");
                                    productPrice = productPrice.Remove(productPrice.Length - 2);
                                    
                                    orderNumber = "-1";
                                    break;
                                case 4:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='prices']")
                                        .First().Attributes["rawprice"].Value;
                                    try
                                    {
                                        ratingGrade = htmlDoc.DocumentNode.SelectNodes("//span[@class='ratingValue']")
                                            .First().GetDirectInnerText();
                                        ratingNumber = htmlDoc.DocumentNode.SelectNodes("//span[@class='ratingCunt']")
                                            .First().GetDirectInnerText();
                                    }
                                    catch
                                    {
                                        ratingGrade = "0";
                                        ratingNumber = "0";
                                    }
                                    orderNumber = "-1";
                                    break;
                                case 5:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//em[@class='main-price']")
                                        .First().GetDirectInnerText();
                                    productPrice = productPrice.Remove(productPrice.Length - 3).Replace(',','.');
                                    ratingGrade = "-1";
                                    ratingNumber = "-1";
                                    orderNumber = "-1";
                                    break;
                            }

                            productPrice = Regex.Replace(productPrice, @"\s+", "");

                            List<string> result = new List<string>();
                            result.Add(productPrice);
                            result.Add(ratingGrade);
                            result.Add(ratingNumber);
                            result.Add(orderNumber);

                            return result;
                        }
                    }
                }
            } catch(Exception ex)
            {
                return null;
            }
        }
    }
}