using CoffeeRoom.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeRoom.Services
{
    class ApiServices
    {
        private readonly string url = "http://coffeeroom.gear.host/api/menus";
        public async Task<List<Menu>> GetMenus()
        {
            var httpClient = new HttpClient();
            var jsonResponse = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Menu>>(jsonResponse);
        }

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var httpClient = new HttpClient(); 
            var jsonReservation = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(jsonReservation, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
