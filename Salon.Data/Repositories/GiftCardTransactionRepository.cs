using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Salon.Data.Base;
using Salon.Data.Entities;
using Salon.Data.Repositories.Interfaces;
using Salon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salon.Data.Repositories
{
    public class GiftCardTransactionRepository:EntityMappingRepository<GiftCardTransaction, GiftCardTransactionViewModel>, IGiftCardTransactionRepository
    {
        public GiftCardTransactionRepository(SalonContext salonContext, IMapper mapper) : base(salonContext, mapper) { }

        public GiftCardTransactionViewModel CreateTransactionForGiftCard(GiftCardTransactionViewModel giftCardTransaction)
        {
            var entity = MapTo(giftCardTransaction);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return MapFrom(entity);
        }

        public GiftCardTransactionViewModel GetTransactionById(int id)
        {
            var entity = _context.Set<GiftCardTransaction>().Where(x => x.Id == id).Include(x => x.GiftCard).FirstOrDefault();
            return MapFrom(entity);
        }

        public IEnumerable<GiftCardTransactionViewModel> GetTransactions()
        {
            var transactions = _context.Set<GiftCardTransaction>().Include(x => x.GiftCard).OrderByDescending(x => x.TransactionDate).Select(x => MapFrom(x));
            return transactions;
        }

        public IEnumerable<GiftCardTransactionViewModel> GetTransactionsByGiftCardId(int id)
        {
            var transactions = _context.Set<GiftCardTransaction>().Include(x => x.GiftCard).Where(x => x.GiftCardId == id).Select(x => MapFrom(x));
            return transactions;
        }
    }
}
