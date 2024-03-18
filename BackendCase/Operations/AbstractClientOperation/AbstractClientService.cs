using System.Text.Json;

namespace BackendCase.Operations.AbstractClientOperation
{
    public abstract class AbstractClientService
    {
        protected readonly HttpClient _httpClient;

        private readonly string _baseRoute = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Url")["BaseUrl"];  // Get the base url from appsettings.json

        protected AbstractClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<TReturn> GetAsync<TReturn>(string relativeUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_baseRoute}/{relativeUrl}"); // Call the url and get data. If call is success manage the data. else get an error message. and handle it. 

            if (response.IsSuccessStatusCode)
            {
                var responseData = await _httpClient.GetStringAsync($"{_baseRoute}{relativeUrl}");
                return JsonSerializer.Deserialize<TReturn>(responseData);  // Get data and deserialize incoming models.
            }
            else
            {
                string failMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(failMessage);
                throw new Exception(failMessage);
            }
        }

        protected async Task<TReturn> PostAsync<TReturn, TRequest>(string relativeUrl)
        {
            //Hata alıyor. !!
            HttpResponseMessage response = await _httpClient.PostAsync($"{_baseRoute}{relativeUrl}", null); // Call the url and post data If call is success manage the data. else get an error message. and handle it. 
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TReturn>(responseData); // Get data and deserialize incoming models.
            }
            else
            {
                string failMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(failMessage);
                throw new Exception(failMessage);
            }
        }
    }
}
