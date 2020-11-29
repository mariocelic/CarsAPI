using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Common;
using Cars.DAL.Entities;
using Cars.Repository.Common;
using Cars.Service.Common;
using Cars.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleMakesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleMakeService _vehicleMakeService;



        public VehicleMakesController(IUnitOfWork unitOfWork, IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleMakeService = vehicleMakeService;

        }
        // GET: VehicleMakes
        [HttpGet]
        [Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Index([FromQuery]SortingParameters sortingParameters, [FromQuery] FilteringParameters filteringParameters,
            [FromQuery] PagingParameters pagingParameters)
        {
            var sortingParams = new SortingParameters() { SortOrder = sortingParameters.SortOrder };
            var filteringParams = new FilteringParameters() { CurrentFilter = filteringParameters.CurrentFilter, FilterString = filteringParameters.FilterString };
            var pagingParams = new PagingParameters() { PageNumber = pagingParameters.PageNumber, PageSize = pagingParameters.PageSize };

            

            var listOfVehicleMakes = _mapper.Map<IList<VehicleMakeDTO>>(await _vehicleMakeService.FindAllMakesPaged(sortingParams, filteringParams, pagingParams));
            if (listOfVehicleMakes == null) return BadRequest();

            return Ok(listOfVehicleMakes);
        }

        // GET: VehicleMakes/Details/5  
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Details(int id)
        {
            var make = await _vehicleMakeService.FindVehicleMakeById(id);

            if (make == null)
            {
                return NotFound();
            }

            var makeDto = _mapper.Map<VehicleMakeDTO>(make);
            return Ok(makeDto);

        }

        
        // POST: VehicleMakes/Create        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(VehicleMakeDTO makeDto)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return Ok(makeDto);
                }

                var make = _mapper.Map<IVehicleMakeEntity>(makeDto);
                await _vehicleMakeService.CreateAsync(make);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return Ok(makeDto);
            }
        }

        
        // POST: VehicleMakes/Edit/5        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(VehicleMakeDTO makeDto)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return Ok(makeDto);
                }


                var makeItem = _mapper.Map<IVehicleMakeEntity>(makeDto);
                _unitOfWork.VehicleMake.Update(makeItem);
                await _unitOfWork.CommitAsync();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok(makeDto);
            }
        }

        
        // DELETE: VehicleMakes/Delete/5
        [HttpDelete, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var make = await _vehicleMakeService.FindVehicleMakeById(id);
                await _vehicleMakeService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
