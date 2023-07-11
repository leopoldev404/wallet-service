using MediatR;

namespace WalletService.Application.Wallets.Commands;

public record InitDBCommand() : IRequest;
