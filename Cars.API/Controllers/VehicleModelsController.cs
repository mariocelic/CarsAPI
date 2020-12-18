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
    public class VehicleModelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleModelService _vehicleModelService;
        

        public VehicleModelsController(IMapper mapper, IVehicleModelService vehicleModelService)
        {
            _mapper = mapper;
            _vehicleModelService = vehicleModelService;
            
        }
        // GET: VehicleModels
        [HttpGet(Name = "GetModels")]
        public async Task<IActionResult> Index([FromQuery] SortingParameters sortingParameters, [FromQuery] FilteringParameters filteringParameters,
            [FromQuery] PagingParameters pagingParameters)
        {
            var models = await _vehicleModelService.FindAllModelsPaged(sortingParameters, filteringParameters, pagingParameters);

            Response.AddPagination(models.CurrentPage, models.PageSize, models.TotalCount, models.TotalPages);

            var modelsList = _mapper.Map<IEnumerable<IVehicleModel>>(models.Items);

            return Ok(modelsList);
        }

        // GET: VehicleModels/Details/5        
        [HttpGet("{id}", Name = "GetModel")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _vehicleModelService.FindVehicleModelById(id);
            var modelDto = _mapper.Map<VehicleModelDTO>(model);
            return Ok(modelDto);

        }


        // POST: VehicleModels/Create        
        [HttpPost(Name = "CreateModel")]
        public async Task<IActionResult> Create([FromBody] VehicleModelDTO modelDto)
        {
            if (modelDto == null)
            {
                return BadRequest("Vehicle data not entered");
            }

            var newModel = _mapper.Map<IVehicleModel>(modelDto);
            await _vehicleModelService.CreateAsync(newModel);

            return NoContent();

        }

        // POST: VehicleModels/Edit/5        
        [HttpPut(Name = "UpdateModel")]
        public async Task<IActionResult> Edit(VehicleModelDTO modelDto)
        {
            var editModel = _mapper.Map<IVehicleModel>(modelDto);
            await _vehicleModelService.UpdateAsync(editModel);

            return NoContent();
        }

        // POST: VehicleModels/Delete/5
        [HttpDelete(Name = "DeleteModel")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _vehicleModelService.DeleteAsync(id);

            return Ok();
        }

    }
}
