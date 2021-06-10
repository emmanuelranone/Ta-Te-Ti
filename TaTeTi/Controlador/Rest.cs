using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
//using RestSharp;
using System.Net.Http.Headers;

namespace Controlador
{
    public class Rest
    {
        HttpClient client;

        public Rest()
        {
            client = new HttpClient();
        }        

        public async Task<T> getRequest<T>( string url)
        {
            try
            {
                // HttpClient client = new HttpClient();               
                client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var respones = await client.GetAsync(url);
                var json = await respones.Content.ReadAsStringAsync();
                var jsonResult = JsonConvert.DeserializeObject(json).ToString();
                return JsonConvert.DeserializeObject<T>(jsonResult);

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return default(T);
            }
        }

        public async Task<T> postPuntaje<T>(string url, Jugador j)
        {
            string uri = url + "?n=" + j.nombre + "&p=" + j.puntos;
            try
            {                             
                client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var respones = await client.GetAsync(uri);              
                return default(T);

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return default(T);
            }
        }

        public async Task<T> postRequest<T>(string url, Jugador jug)
        {
            try
            {                
                //HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(jug);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;                
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return default(T);
            }
        }
    }
}