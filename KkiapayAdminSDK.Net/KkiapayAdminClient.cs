using System;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace KkiapayAdminSDK.Net
{
    public class KkiapayAdminClient
    {
        private readonly string publicKey;
        private readonly string privateKey;
        private readonly string secretKey;
        private readonly bool isSandbox;

        public KkiapayAdminClient(string publicKey, string privateKey, string secretKey, bool isSandbox = false)
        {
            if (string.IsNullOrWhiteSpace(publicKey)) throw new ArgumentNullException(nameof(publicKey));
            if (string.IsNullOrWhiteSpace(privateKey)) throw new ArgumentNullException(nameof(privateKey));
            if (string.IsNullOrWhiteSpace(secretKey)) throw new ArgumentNullException(nameof(secretKey));

            this.publicKey = publicKey;
            this.privateKey = privateKey;
            this.secretKey = secretKey;
            this.isSandbox = isSandbox;
        }


        async public Task<(bool isError, KkiapayTransaction response, string errorType)> VerifyTransaction(string transactionId)
        {
            if (string.IsNullOrWhiteSpace(transactionId)) throw new ArgumentNullException(nameof(transactionId), "the given transaction ID can not be null or empty");

            var httpClient = new HttpClient
            {
                DefaultRequestHeaders = {
                { "accept", "application/json" },
                { "x-api-key", publicKey },
                { "x-secret-key", secretKey },
                { "x-private-key", privateKey },
            },
                BaseAddress = new Uri(isSandbox ? "https://api-sandbox.kkiapay.me" : "https://api.kkiapay.me")
            };

            var verifyResponse = await httpClient.PostAsync("/api/v1/transactions/status",
                                                                new StringContent(JsonSerializer.Serialize(new { transactionId })));

            if (verifyResponse.IsSuccessStatusCode)
            {
                var stringContent = await verifyResponse.Content.ReadAsStringAsync();
                var transaction = JsonSerializer.Deserialize<KkiapayTransaction>(stringContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                return (false, transaction, string.Empty);
            }
            else
            {
                if (verifyResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return (true, null, "Transaction not found");
                }

                if (verifyResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (true, null, "Unauthorized");
                }
            }

            return (true, null, "Unknown error");
        }
    }
}
