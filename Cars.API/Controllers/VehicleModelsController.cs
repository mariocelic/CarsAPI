using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.API.DTO;
using Cars.Data.Models;
using Cars.Repository.Helpers;
using Cars.Repository.Interfaces;
using Cars.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars.API.Controllers
{
    [Route("api/makes/{makeId}/models")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;


        public VehicleModelsController(IUnitOfWork unitOfWork, IMapper mapper, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }
        // GET: VehicleModels
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index([FromQuery] SortingParameters sortingParameters, [FromQuery] FilteringParameters filteringParameters,
            [FromQuery] PagingParameters pagingParameters)
        {
            var SortingParams = new SortingParameters() { SortOrder = sortingParameters.SortOrder };
            var FilteringParams = new FilteringParameters() { CurrentFilter = filteringParameters.CurrentFilter, FilterString = filteringParameters.FilterString };
            var PagingParams = new PagingParameters() { PageNumber = pagingParameters.PageNumber, PageSize = pagingParameters.PageSize ?? 5 };

            //ViewBag.NameSortParam = string.IsNullOrEmpty(sortingParameters.SortOrder) ? "name_desc" : "";

            List<VehicleModel> listOfVehicleModels = _mapper.Map<List<VehicleModel>>(await _vehicleModelService.FindAllModelsPaged(SortingParams, FilteringParams, PagingParams));
            if (listOfVehicleModels == null) return BadRequest();

            return Ok(listOfVehicleModels);

        }

        // GET: VehicleModels/Details/5        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _vehicleModelService.FindVehicleModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            var modelDto = _mapper.Map<VehicleModelDTO>(model);
            return Ok(modelDto);

        }

        
        // POST: VehicleModels/Create        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] VehicleModelDTO modelDto)
        {
            try
            {
                var makes = _unitOfWork.VehicleMake.FindAllAsync();

                var makeItems = makes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.MakeId.ToString()

                });

                modelDto.VehicleMakeList = makeItems.ToList();


                if (!ModelState.IsValid)
                {
                    return Ok(modelDto);
                }


                var model = _mapper.Map<VehicleModelDTO>(modelDto);

                var carModel = _mapper.Map<VehicleModel>(model);
                await _vehicleModelService.CreateAsync(carModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return Ok(modelDto);
            }
        }

        // POST: VehicleModels/Edit/5        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(VehicleModelDTO modelDto)
        {
            try
            {
                var makes = _unitOfWork.VehicleMake.FindAllAsync();

                var makeItems = makes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.MakeId.ToString()

                });

                modelDto.VehicleMakeList = makeItems.ToList();


                if (!ModelState.IsValid)
                {
                    return Ok(modelDto);
                }


                var model = _mapper.Map<VehicleModel>(modelDto);


                _unitOfWork.VehicleModel.Update(model);
                await _unitOfWork.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok(modelDto);
            }
        }

        // POST: VehicleModels/Delete/5
        [HttpDelete, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var model = await _vehicleModelService.FindVehicleModelById(id);
                await _vehicleModelService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
