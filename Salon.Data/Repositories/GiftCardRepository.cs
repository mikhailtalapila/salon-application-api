﻿using AutoMapper;
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
    public class GiftCardRepository: EntityMappingRepository<GiftCard, GiftCardViewModel>, IGiftCardRepository
    {
        public GiftCardRepository(SalonContext salonContext, IMapper mapper) : base(salonContext, mapper) { }

        public IEnumerable<GiftCardViewModel> GetAllGiftCards()
        {
            return _context.Set<GiftCard>().Where(x => x.IsDeleted == false).Include(x => x.Customer).Include(x => x.GiftCardTransactions).Select(x => MapFrom(x));
        }

        public GiftCardViewModel GetGiftCardById(int id)
        {
            var entity = _context.Set<GiftCard>().Include(x => x.Customer).Include(x => x.GiftCardTransactions).Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            return MapFrom(entity);            
        }

        public GiftCardViewModel AddGiftCard(GiftCardViewModel viewModel)
        {
            var entity = MapTo(viewModel);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            
            return MapFrom(entity);
        }

        public GiftCardViewModel UpdateGiftCard(int id, GiftCardViewModel giftCard)
        {
            if (id != giftCard.Id)
            {
                return null;
            }
            _context.Entry(MapTo(giftCard)).State = EntityState.Modified;
            _context.SaveChanges();
            return giftCard;
        }
    }
}
