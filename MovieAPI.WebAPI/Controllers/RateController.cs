using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Interfaces;

namespace MovieAPI.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class RateController : Controller
{
    private readonly IRateService _rateService;
    public RateController(IRateService rateService)
    {
        _rateService = rateService;
    }
}
