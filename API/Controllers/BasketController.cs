using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepo;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepo = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id){
            var basket = await _basketRepo.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync(CustomerBasket basket){
            var update = await _basketRepo.UpdateBasketAsync(basket);
            return Ok(update);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id) { 
             await _basketRepo.DeleteBasketAsync(id);
        }
    }
}