using MediatR;
using WalletService.Application.Models;

namespace WalletService.Application.Queries;

public record GetWalletQuery() : IRequest<Wallet>;

