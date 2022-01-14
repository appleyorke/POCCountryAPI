using IRIExcelWEBAPI.Model;
using IRIExcelWEBAPI.Query;
using IRIExcelWEBAPI.Query.UpdateCountry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIExcelWEBAPI.Controllers
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/Country:validate")]
        public async Task<ActionResult> Get()
        {
            // Process Country export request in background
            var response = await _mediator.Send(new GetCountryQuery());
            return Ok(response);
        }


        [HttpPost]
        [Route("api/v1/UpdateCountry")]
        public async Task<ActionResult> UpdateCountry(List<CountryUpSetRequest> updatedCountries)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, string.Empty);
            // Process Country export request in background
            var response = await _mediator.Send(new UpdateCountryQuery()
            {
                countries = updatedCountries
            }); ;
            return Ok(response);
        }
    }
}
