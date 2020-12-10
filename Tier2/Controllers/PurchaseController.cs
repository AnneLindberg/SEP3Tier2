using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Data.Purchase;
using Tier2.Models;

namespace Tier2.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : Controller
    {

        private IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService) {
            this.purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PurchaseRequest>>> GetPurchaseRequestAsync([FromQuery] string username) {
            try 
            {
                IList<PurchaseRequest> purchaseRequests = await purchaseService.GetPurchaseRequestAsync(username);

                return Ok(purchaseRequests);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("saleId")]
        public async Task<ActionResult<IList<PurchaseRequest>>> GetPurchaseRequestFromId([FromQuery] int id) {
            try {
                IList<PurchaseRequest> purchaseRequests = await purchaseService.GetPurchaseRequestFromIdAsync(id);
                return Ok(purchaseRequests);
            }
            catch (Exception e) {
                Console.WriteLine(e + "in get purchase from id");
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<IList<PurchaseRequest>>> CreatePurchaseRequestAsync(
            [FromBody] IList<PurchaseRequest> purchaseRequests) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                IList<PurchaseRequest> addedPurchaseRequests =
                    await purchaseService.CreatePurchaseRequestAsync(purchaseRequests);
                return Created($"/{addedPurchaseRequests.Count}", addedPurchaseRequests);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePurchaseRequestsAsync([FromRoute] int id)
        {
            try
            {
                await purchaseService.DeletePurchaseRequestAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}