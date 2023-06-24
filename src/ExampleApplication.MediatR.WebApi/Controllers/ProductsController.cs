using ExampleApplication.MediatR.WebApi.Commands;
using ExampleApplication.MediatR.WebApi.Entities;
using ExampleApplication.MediatR.WebApi.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApplication.MediatR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Product> _repository;

        public ProductsController(IMediator mediator, IRepository<Product> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = new DeleteProductCommand { Id = id };

            return Ok(await _mediator.Send(obj));
        }
    }
}
