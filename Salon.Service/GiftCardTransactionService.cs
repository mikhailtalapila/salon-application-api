using Salon.Data.Repositories.Interfaces;
using Salon.Domain;
using Salon.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Service
{
    public class GiftCardTransactionService : IGiftCardTransactionService
    {
        private readonly IGiftCardTransactionRepository _giftCardTransactionRepository;
        private readonly IGiftCardRepository _giftCardRepository;
        public GiftCardTransactionService(IGiftCardTransactionRepository giftCardTransactionRepository, IGiftCardRepository giftCardRepository)
        {
            _giftCardTransactionRepository = giftCardTransactionRepository;
            _giftCardRepository = giftCardRepository;
        }
        public GiftCardTransactionViewModel CreateTransactionForGiftCard(GiftCardTransactionViewModel transaction)
        {
            var giftCard = _giftCardRepository.GetGiftCardById(transaction.GiftCardId);
            if (giftCard.Amount < transaction.AmountUsed)
                return null;
            giftCard.Amount = giftCard.Amount - transaction.AmountUsed;
            _giftCardRepository.UpdateGiftCard(transaction.GiftCardId, giftCard);
            return _giftCardTransactionRepository.CreateTransactionForGiftCard(transaction);
        }

        public GiftCardTransactionViewModel GetGiftCardTransactionById(int id)
        {
            return _giftCardTransactionRepository.GetTransactionById(id);
        }

        public IEnumerable<GiftCardTransactionViewModel> GetTransactions()
        {
            return _giftCardTransactionRepository.GetTransactions();
        }

        public IEnumerable<GiftCardTransactionViewModel> GetTransactionsByGiftCardId(int id)
        {
            return _giftCardTransactionRepository.GetTransactionsByGiftCardId(id);
        }
    }
}
