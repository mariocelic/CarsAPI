using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Common;
using Cars.Model.Common;
using Cars.Service.Common;
using Cars.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Project.WebAPI.Helpers;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakesController(IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            _mapper = mapper;
            _vehicleMakeService = vehicleMakeService;

        }
        // GET: VehicleMakes
        [HttpGet(Name = "GetMakes")]
        public async Task<IActionResult> Index([FromQuery]SortingParameters sortingParameters, [FromQuery] FilteringParameters filteringParameters,
            [FromQuery] PagingParameters pagingParameters)
        {
            var makes = await _vehicleMakeService.FindAllMakesPaged(sortingParameters, filteringParameters, pagingParameters);

            Response.AddPagination(makes.CurrentPage, makes.PageSize, makes.TotalCount, makes.TotalPages);

            var makesList = _mapper.Map<IEnumerable<IVehicleMake>>(makes.Items);

            return Ok(makesList);
        }

        // GET: VehicleMakes/Details/5  
        [HttpGet("{id}" , Name = "GetMake")]
        public async Task<IActionResult> Details(int id)
        {
            var make = await _vehicleMakeService.FindVehicleMakeById(id);
            var makeDto = _mapper.Map<VehicleMakeDTO>(make);
            return Ok(makeDto);

        }

        
        // POST: VehicleMakes/Create        
        [HttpPost(Name = "CreateMake")]
        public async Task<IActionResult> Create([FromBody] VehicleMakeDTO makeDto)
        {
            if (makeDto == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var newMake =  _mapper.Map<IVehicleMake>(makeDto);
            await _vehicleMakeService.CreateAsync(newMake);
            
            return NoContent();            
           
        }

        
        // POST: VehicleMakes/Edit/5        
        [HttpPut(Name = "UpdateMake")]
        public async Task<IActionResult> Edit([FromBody] VehicleMakeDTO makeDto)
        {
            var editMake = _mapper.Map<IVehicleMake>(makeDto);
            await _vehicleMakeService.UpdateAsync(editMake);

            return NoContent();
        }

        
        // DELETE: VehicleMakes/Delete/5
        [HttpDelete(Name = "DeleteMake")]
        public async Task<IActionResult> Delete(int id)
        {
            
            await _vehicleMakeService.DeleteAsync(id);

            return Ok();
        }

    }
}
