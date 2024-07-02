using System;
using System.Text.Json.Serialization;

namespace KkiapayAdminSDK.Net
{
    public class KkiapayTransaction
    {
        [JsonPropertyName("performed_at")]
        public DateTime PerformedAt { get; set; }

        [JsonPropertyName("received_at")]
        public long ReceivedAt { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("source_common_name")]
        public string SourceCommonName { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("fees")]
        public decimal Fees { get; set; }

        [JsonPropertyName("net")]
        public decimal Net { get; set; }

        [JsonPropertyName("externalTransactionId")]
        public string ExternalTransactionId { get; set; }

        [JsonPropertyName("paymentlink")]
        public string PaymentLink { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("failureCode")]
        public string FailureCode { get; set; }

        [JsonPropertyName("failureMessage")]
        public string FailureMessage { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("partnerId")]
        public string PartnerId { get; set; }

        [JsonPropertyName("before_balance")]
        public decimal BeforeBalance { get; set; }

        [JsonPropertyName("after_balance")]
        public decimal AfterBalance { get; set; }

        [JsonPropertyName("is_payout")]
        public bool IsPayout { get; set; }

        [JsonPropertyName("is_counted")]
        public bool IsCounted { get; set; }

        [JsonPropertyName("hasChargeback")]
        public bool HasChargeback { get; set; }

        [JsonPropertyName("wallet")]
        public string Wallet { get; set; }

        [JsonPropertyName("sharedTransaction")]
        public object SharedTransaction { get; set; }

        [JsonPropertyName("initialTransactionReference")]
        public string InitialTransactionReference { get; set; }

        [JsonPropertyName("initialTransactionDate")]
        public DateTime? InitialTransactionDate { get; set; }

        [JsonPropertyName("feeSupportedBy")]
        public string FeeSupportedBy { get; set; }

        [JsonPropertyName("accountPaymentSettings")]
        public AccountPaymentSettings AccountPaymentSettings { get; set; }

        [JsonPropertyName("income")]
        public decimal Income { get; set; }

        [JsonPropertyName("client")]
        public ClientInfo Client { get; set; }

        [JsonPropertyName("payout")]
        public object Payout { get; set; }

        [JsonPropertyName("session")]
        public object Session { get; set; }

        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyName("performedAt")]
        public string PerformedAtFormatted { get; set; }
    }

    public enum TransactionType
    {
        DEBIT,
        CREDIT
    }

    public enum TransactionStatus
    {
        SUCCESS,
        FAILED,
        PENDING
    }

    public enum PaymentSource
    {
        MOBILE_MONEY,
        BANK_ACCOUNT,
        CARD,
        WALLET
    }

    public enum FeeSupportedBy
    {
        customer,
        merchant,
        thirdparty
    }

    public class AccountPaymentSettings
    {
        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; }

        [JsonPropertyName("percentage")]
        public decimal Percentage { get; set; }
    }

    public class ClientInfo
    {
        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("meta_data")]
        public string MetaData { get; set; }

        [JsonPropertyName("isNewGeneration")]
        public bool IsNewGeneration { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("person")]
        public object Person { get; set; }
    }
}
