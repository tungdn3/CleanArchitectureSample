using CleanArchitectureSample.Application.Commands;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Queries;
using CleanArchitectureSample.Shared.Abstractions.Commands;
using CleanArchitectureSample.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackingListController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PackingListController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<PackingListDto>> GetByName([FromRoute] string name)
        {
            var query = new GetPackingList(name);
            var result = await _queryDispatcher.Dispatch(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] SearchPackingList query)
        {
            var result = await _queryDispatcher.Dispatch(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePackingListWithItems command)
        {
            await _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(GetByName), new { name = command.Name }, null);
        }

        [HttpPut("{packingListId}/items")]
        public async Task<ActionResult> AddPackingItem([FromBody] AddPackingItem command)
        {
            await _commandDispatcher.Dispatch(command);
            return NoContent();
        }

        [HttpPut("{id}/items/{itemName}/pack")]
        public async Task<ActionResult> PackItem(Guid id, string itemName)
        {
            var command = new PackPackingItem(id, itemName);
            await _commandDispatcher.Dispatch(command);
            return NoContent();
        }

        [HttpDelete("{id}/items/{itemName}")]
        public async Task<ActionResult> RemovePackingItem(Guid id, string itemName)
        {
            var command = new RemovePackingItem(id, itemName);
            await _commandDispatcher.Dispatch(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePackingItem(Guid id)
        {
            var command = new DeletePackingList(id);
            await _commandDispatcher.Dispatch(command);
            return NoContent();
        }
    }
}
