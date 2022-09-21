using Newtonsoft.Json;
using System.Net;

namespace YouAndYourFood.Models
{
    public class Address
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("addressLocality")]
        public string AddressLocality { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }

    public class RestaurantsData
    {
        [JsonProperty("restaurants")]
        public Restaurant[]? Restaurants { get; set; }
    }

    public class Restaurant
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("priceRange")]
        public string PriceRange { get; set; }

        [JsonProperty("servesCuisine")]
        public string ServesCuisine { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("menu")]
        public Menu Menu { get; set; }

        public int? MinWaitingTime { 
            get 
            {
                int waitingTime = int.MaxValue;
                foreach(Item item in Menu.Items)
                {
                    waitingTime = (int)((item.WaitingTime < waitingTime) ? item.WaitingTime : waitingTime);
                }
                return waitingTime;
            } 
            set { } 
        }

        public int? MaxWaitingTime { 
            get 
            {
                int waitingTime = int.MinValue;
                foreach (Item item in Menu.Items)
                {
                    waitingTime = (int)((item.WaitingTime > waitingTime) ? item.WaitingTime : waitingTime);
                }
                return waitingTime;

            }
            set { } 
        }
    }

    public class Menu
    {
        [JsonProperty("items")]
        public Item[]? Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("cooktimeinminutes")]
        public string Cooktimeinminutes { get; set; }

        [JsonProperty("totalOrders")]
        public string TotalOrders { get; set; }

       public int? WaitingTime { get { return int.Parse(Cooktimeinminutes) * int.Parse(TotalOrders); } set{ } }

       public int? Calories { get; set; }
    }

}
