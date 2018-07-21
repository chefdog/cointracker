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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PortfolioController : Controller
    {
        private IBusinessService<PortfolioDataTransferModel> _portfolioBusinessService;
        public PortfolioController(IBusinessService<PortfolioDataTransferModel> portfolioBusinessService) {
            _portfolioBusinessService = portfolioBusinessService;
        }


        [HttpPost]
        [Route("Portfolio")]
        public async Task<IActionResult> PostPortfolioAsync([FromBody]PortfolioDataTransferModel request)
        {
            var response = new SingleModelResponse<PortfolioDataTransferModel>();
            try
            {
                var entity = await _portfolioBusinessService.Create(request);
                response.Model = entity;
                response.Message = "The data was saved successfully";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new SingleModelResponse<PortfolioDataTransferModel>();
            var request = new PortfolioDataTransferModel { Id = id, UserId = 1 };
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = await _portfolioBusinessService.Find(request);
                    response.Model = entity;
                    response.Message = "The data was found";
                    response.ToHttpResponse();
                }
                var messages = from v in ModelState.Values
                               from e in v.Errors
                               select e.ErrorMessage;
                response.DidError = true;
                response.ErrorMessage = string.Join(".", messages);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        protected override void Dispose(Boolean disposing)
        {
            _portfolioBusinessService?.Dispose();

            base.Dispose(disposing);
        }
    }
}