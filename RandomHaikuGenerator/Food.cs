using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RandomHaikuGenerator
{
    public interface IFood
    {
        public void GetFood(string n);
    }
    public class Food
    {
        IFood _food;
        HttpClient client = new HttpClient();
   
        public Food(IFood food)
        {
            _food = food;
        }
        public void requestPage()
        {
            string userName = "", userPassword = "fe42b4edd631452faedf8d2766c4a5e5";

            var url = @"https://api.spoonacular.com/recipes/complexSearch";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add("x-api-key", userPassword);

            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            _food.GetFood(result);
           

        }
    }
    public class FoodMock : IFood
    {
        public bool foodRequested { set; get;}
        public void GetFood(string n)
        {
            foodRequested = true;
        }
    }
}
