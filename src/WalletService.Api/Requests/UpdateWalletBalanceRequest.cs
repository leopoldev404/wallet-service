using System.Text.Json.Serialization;

namespace WalletService.Api.Requests;

public record UpdateWalletBalanceRequest(
    [property: JsonPropertyName("operationType")] string OperationType,
    [property: JsonPropertyName("amount")] double Amount);