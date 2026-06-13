using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.DTOs;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        private static readonly string[] ValidCategories =
{
    "Length",
    "Weight",
    "Temperature",
    "Area",
    "Volume",
    "Time"
};

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequest request)
        {
            // Model Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Category Validation
            if (!ValidCategories.Contains(
                    request.Category,
                    StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new
                {
                    Message = "Invalid category. Supported categories are Length, Weight and Temperature."
                });
            }

            // From Unit Validation
            if (string.IsNullOrWhiteSpace(request.FromUnit))
            {
                return BadRequest(new
                {
                    Message = "FromUnit is required."
                });
            }

            // To Unit Validation
            if (string.IsNullOrWhiteSpace(request.ToUnit))
            {
                return BadRequest(new
                {
                    Message = "ToUnit is required."
                });
            }

            // Same Unit Validation
            if (request.FromUnit.Equals(
                    request.ToUnit,
                    StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new
                {
                    Message = "Source and target units cannot be the same."
                });
            }

            var result = _conversionService.Convert(
                request.Category,
                request.FromUnit,
                request.ToUnit,
                request.Value);

            var response = new ConvertResponse
            {
                OriginalValue = request.Value,
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit,
                ConvertedValue = result
            };

            return Ok(response);
        }
    }
}