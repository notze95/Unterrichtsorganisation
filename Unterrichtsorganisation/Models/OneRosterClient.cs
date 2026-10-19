using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Unterrichtsorganisation.Models {
    public class OneRosterClient {
        private const string ApiUrl = "https://api.integration.webuntis.dev";

        private readonly string tenantId;
        private readonly string clientId;
        private readonly string password;
        private readonly HttpClient httpClient;

        private string? cachedToken;
        private DateTime tokenExpiry = DateTime.MinValue;

        public OneRosterClient(string tenantId, string clientId, string password) {
            this.tenantId = tenantId;
            this.clientId = clientId;
            this.password = password;

            httpClient = new HttpClient {
                BaseAddress = new Uri(ApiUrl)
            };

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<string> GetAuthTokenAsync() {
            if (cachedToken == null || DateTime.UtcNow >= tokenExpiry) {
                var tokenResponse = await FetchAccessTokenAsync();

                cachedToken = tokenResponse.AccessToken;
                tokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 30);
            }

            return cachedToken;
        }

        private async Task<TokenResponse> FetchAccessTokenAsync() {
            var credentials = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{clientId}:{password}"));

            using var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"/WebUntis/api/sso/v3/{tenantId}/token");

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Basic", credentials);

            request.Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            ]);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TokenResponse>(json)!
                   ?? throw new InvalidOperationException("Token response invalid.");
        }

        public async Task<OneRosterResponse<T>> ListAsync<T>(
            string resource,
            string envelope,
            string? filter = null,
            string? sort = null,
            int limit = 100,
            int offset = 0) {
            var queryParams = new List<string> {
                $"limit={limit}",
                $"offset={offset}"
            };

            if (!string.IsNullOrWhiteSpace(filter))
                queryParams.Add($"filter={Uri.EscapeDataString(filter)}");

            if (!string.IsNullOrWhiteSpace(sort))
                queryParams.Add($"sort={Uri.EscapeDataString(sort)}");

            var uri = $"{resource}?{string.Join("&", queryParams)}";

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    await GetAuthTokenAsync());

            var response = await httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            if ((int)response.StatusCode >= 400 &&
                (int)response.StatusCode < 500) {
                throw new ArgumentException(
                    $"[{(int)response.StatusCode}] {uri}: {json}");
            }

            if ((int)response.StatusCode >= 500) {
                throw new Exception(
                    $"[{(int)response.StatusCode}] {uri}: {json}");
            }

            response.EnsureSuccessStatusCode();

            using var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty(
                    envelope,
                    out var envelopeElement)) {
                throw new InvalidOperationException(
                    $"Envelope '{envelope}' not found.");
            }

            var items = JsonSerializer.Deserialize<List<T>>(
                envelopeElement.GetRawText(),
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                })
                ?? [];

            return new OneRosterResponse<T>(items);
        }
        public async Task<JsonDocument> ReadAsStringAsync(
            string resource,
            string envelope,
            string? filter = null,
            string? sort = null,
            int limit = 100,
            int offset = 0) {
            var queryParams = new List<string> {
                $"limit={limit}",
                $"offset={offset}"
            };

            if (!string.IsNullOrWhiteSpace(filter))
                queryParams.Add($"filter={Uri.EscapeDataString(filter)}");

            if (!string.IsNullOrWhiteSpace(sort))
                queryParams.Add($"sort={Uri.EscapeDataString(sort)}");

            var uri = $"{resource}?{string.Join("&", queryParams)}";

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    await GetAuthTokenAsync());

            var response = await httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            if ((int)response.StatusCode >= 400 &&
                (int)response.StatusCode < 500) {
                throw new ArgumentException(
                    $"[{(int)response.StatusCode}] {uri}: {json}");
            }

            if ((int)response.StatusCode >= 500) {
                throw new Exception(
                    $"[{(int)response.StatusCode}] {uri}: {json}");
            }

            response.EnsureSuccessStatusCode();

            return JsonDocument.Parse(json);
        }
    }
}