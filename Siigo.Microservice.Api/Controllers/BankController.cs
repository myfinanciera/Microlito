using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siigo.Microservice.Application.Queries.Bank;

namespace Siigo.Microservice.Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public sealed class BankController: ControllerBase
    {
        private readonly IMediator _mediator;
        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        [HttpGet]
        public  async Task<IActionResult> GetBanks()
        {
            return Ok(await _mediator.Send(new BanksQueryRequest()));
        }
        
        
        [HttpGet("{id}")]
        public async Task< IActionResult> GetBankById(string id)
        {
            return Ok(await _mediator.Send(new BankQueryByIdRequest(id)));
        }
    }
}