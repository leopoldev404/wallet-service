using System.Text.Json.Serialization;

namespace WalletService.Api.Requests;

public record CreateWalletRequest(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("currency")] string Currency,
    [property: JsonPropertyName("userId")] string UserId);