using System.Text.Json;

namespace BackendCase.Operations.AbstractClientOperation
{
    public abstract class AbstractBookingService<TReturn> : IBookingService<TReturn>
    {
        protected readonly HttpClient _httpClient;

        private readonly string _baseRoute = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Url")["BaseUrl"];  // Get the base url from appsettings.json

        protected AbstractBookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<TReturn> GetAsync(string relativeUrl)
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

        protected async Task<TReturn> GetAsyncPostBehavior(string relativeUrl, HttpContent content)
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

        protected async Task<TReturn> PostAsync(string relativeUrl, HttpContent content)
        {
            //Hata alıyor. !!
            HttpResponseMessage response = await _httpClient.PostAsync($"{_baseRoute}{relativeUrl}", content); // Call the url and post data If call is success manage the data. else get an error message. and handle it. 
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

        public abstract Task<TReturn> Handle();
    }

    public abstract class AbstractBookingService<TInput, TReturn>: AbstractBookingService<TReturn>, IBookingService<TInput, TReturn>
    {
        protected AbstractBookingService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public abstract Task<TReturn> Handle(TInput input);
    }
}
