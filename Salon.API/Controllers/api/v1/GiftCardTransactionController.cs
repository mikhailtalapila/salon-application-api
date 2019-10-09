using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salon.Data.Entities;
using Salon.Domain;
using Salon.Service.Interfaces;

namespace Salon.API.Controllers.api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GiftCardTransactionController : ControllerBase
    {
        private readonly IGiftCardTransactionService _giftCardTransactionService;
        public GiftCardTransactionController(IGiftCardTransactionService giftCardTransactionService)
        {
            _giftCardTransactionService = giftCardTransactionService;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<GiftCardTransactionViewModel> GetTransactionById(int id)
        {
            var transaction = _giftCardTransactionService.GetGiftCardTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        [HttpGet]
        [Route("giftcard/{id}")]
        public ActionResult<IEnumerable<GiftCardTransactionViewModel>> GetTransactionsByGiftCardId(int id)
        {
            var transactions = _giftCardTransactionService.GetTransactionsByGiftCardId(id);
            return Ok(transactions);
        }
        [HttpPost]
        public ActionResult<GiftCardTransaction> AddTransactionForGiftCard(GiftCardTransactionViewModel transaction)
        {
            var trans = _giftCardTransactionService.CreateTransactionForGiftCard(transaction);
            return Ok(trans);
        }
        /// <summary>
        /// Get gift card transactions for the last 2 years
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<GiftCardTransactionViewModel>> GetTransactions()
        {
            var trans = _giftCardTransactionService.GetTransactions();
            return Ok(trans);
        }

    }
}