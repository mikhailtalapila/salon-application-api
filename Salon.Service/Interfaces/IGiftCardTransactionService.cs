using Salon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Service.Interfaces
{
    public interface IGiftCardTransactionService
    {
        GiftCardTransactionViewModel GetGiftCardTransactionById(int id);
        IEnumerable<GiftCardTransactionViewModel> GetTransactionsByGiftCardId(int id);
        GiftCardTransactionViewModel CreateTransactionForGiftCard(GiftCardTransactionViewModel transaction);
        IEnumerable<GiftCardTransactionViewModel> GetTransactions();
    }
}
