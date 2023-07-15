namespace CarsAPI.Services
{
    public interface IRandomAPIService
    {
        Task<int> GetRandomNumber(int start, int end);
    }

    public class RandomAPIService : IRandomAPIService
    {
        public const string RandomAPIUrl = "RandomAPIUrl";
        public const string RandomAPIAuthKey = "RandomAPIAuthKey";
        private readonly HttpClient _randomApiClient;

        public RandomAPIService(IConfiguration configuration)
        {
            var randomApiUrl = configuration.GetValue<string>(RandomAPIUrl);
            var randomApiAuthKey = configuration.GetValue<string>(RandomAPIAuthKey);

            _randomApiClient = new HttpClient
            {
                BaseAddress = new Uri(randomApiUrl)
            };
            _randomApiClient.DefaultRequestHeaders.Accept.Clear();
            _randomApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            _randomApiClient.DefaultRequestHeaders.Add("", randomApiAuthKey);
        }

        public async Task<int> GetRandomNumber(int start, int end) // użyć tego gdzieś do losowania, ewentualnie dodać sprawdzanie błędów
        {
            var response = await _randomApiClient.GetAsync($"api/random?start={start}&end={end}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return int.Parse(responseBody);
            }
            else
            {
                // w razie błędu coś zrób
            }

            return default;
        }
    }
}