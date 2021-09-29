using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using skirental_bff.Constants;
using skirental_bff.Models;
using skirental_bff.Service;
using System;

namespace skirental_bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class SkiRentalController : ControllerBase
    {

        private readonly ILogger<SkiRentalController> _logger;
        private readonly ISkiRentalService _skiRentalService;

        public SkiRentalController(ILogger<SkiRentalController> logger, ISkiRentalService skiRentalService)
        {
            _logger = logger;
            _skiRentalService = skiRentalService;
        }

        [HttpPost]
        [Route("getSkis")]
        public IActionResult Post([FromBody] SkiRentalRequestDto request)
        {
            _logger.Log(LogLevel.Information, $"Incoming request \n Height: {request.Height}, Age Category: {request.AgeCategory}, Ski Type: {request.SkiType}");

            if (!Enum.IsDefined(typeof(AgeCategories), request.AgeCategory) || !Enum.IsDefined(typeof(SkiTypes), request.SkiType))
            {
                return BadRequest(request);
            }

            var mappedRequest = new SkiRentalModel
            {
                Height = request.Height.GetValueOrDefault(),
                AgeCategory = request.AgeCategory,
                SkiType = request.SkiType,
            };

            var result = _skiRentalService.GetSkiLength(mappedRequest.Height, mappedRequest.AgeCategory, mappedRequest.SkiType);

            return Ok(result);
        }
    }
}