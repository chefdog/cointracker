using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://www.blinkingcaret.com/2017/05/03/external-login-providers-in-asp-net-core/"/>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CoinController : Controller
    {
        private IBusinessService<CoinDataTransferModel> _coinBusinessService;
        public CoinController(IBusinessService<CoinDataTransferModel> coinBusinessService)
        {
            _coinBusinessService = coinBusinessService;
        }

        [HttpGet]
        [Route("Coin")]
        public async Task<IActionResult> GetCoinsAsync(Int32? max = 10, Int32? pageNumber = 1, String name = null)
        {
            var response = new ListModelResponse<CoinDataTransferModel>();

            try
            {
                response.PageSize = (Int32)max;
                response.PageNumber = (Int32)pageNumber;
                response.Model = await _coinBusinessService.GetMany(response.PageNumber, 0, response.PageSize);
                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        protected override void Dispose(Boolean disposing)
        {
            _coinBusinessService?.Dispose();

            base.Dispose(disposing);
        }
    }
}