using AutoMapper;
using GhnShipping.Infrastructure.Directory;
using GhnShipping.Infrastructure.Mvc;
using GhnShipping.Models.Directory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GhnShipping.Controllers
{
    [ApiRoute("directory")]
    public sealed class DirectoryController : BaseController
    {
        #region Fields
        private readonly IDirectoryService _directoryService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public DirectoryController(IDirectoryService directoryService, IMapper mapper)
        {
            _directoryService = directoryService;
            _mapper = mapper;
        }
        #endregion

        #region Province

        /// <summary>
        /// Get available provinces
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1.0/provinces
        ///
        /// </remarks>
        /// <returns>Available provinces</returns>
        /// <response code="200">Get provinces is success</response>
        /// <response code="400">Get provinces is failed</response>
        [HttpGet]
        [Route("provinces")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<ProvinceModel>>> GetProvincesAsync()
        {
            try
            {
                var provinces = await _directoryService.GetProvincesAsync();
                var model = provinces.Select(province => _mapper.Map<ProvinceModel>(province)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get available districts in province
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1.0/provinces/1/districts
        ///
        /// </remarks>
        /// <returns>Available districts in province</returns>
        /// <response code="200">Get districts in province is success</response>
        /// <response code="400">Get districts in province is failed</response>
        [HttpGet]
        [Route("provinces/{provinceId:int}/districts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<DistrictModel>>> GetDistrictsInProvinceAsync(int provinceId)
        {
            try
            {
                var districts = await _directoryService.GetDistrictsAsync(provinceId);
                var model = districts.Select(district => _mapper.Map<DistrictModel>(district)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region District

        /// <summary>
        /// Get available districts
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1.0/districts
        ///
        /// </remarks>
        /// <returns>Available districts</returns>
        /// <response code="200">Get districts is success</response>
        /// <response code="400">Get districts is failed</response>
        [HttpGet]
        [Route("districts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<DistrictModel>>> GetDistrictsAsync()
        {
            try
            {
                var districts = await _directoryService.GetDistrictsAsync(0);
                var model = districts.Select(district => _mapper.Map<DistrictModel>(district)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get available wards in district
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1.0/districts/1/wards
        ///
        /// </remarks>
        /// <returns>Available wards in district</returns>
        /// <response code="200">Get wards in district is success</response>
        /// <response code="400">Get wards in district is failed</response>
        [HttpGet]
        [Route("districts/{districtId:int}/wards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<WardModel>>> GetWardsInDistrictAsync(int districtId)
        {
            try
            {
                var wards = await _directoryService.GetWardsAsync(districtId);
                var model = wards.Select(ward => _mapper.Map<WardModel>(ward)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Ward

        /// <summary>
        /// Get available wards
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1.0/wards
        ///
        /// </remarks>
        /// <returns>Available wards</returns>
        /// <response code="200">Get wards is success</response>
        /// <response code="400">Get wards is failed</response>
        [HttpGet]
        [Route("wards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<WardModel>>> GetWardsAsync()
        {
            try
            {
                var wards = await _directoryService.GetWardsAsync(0);
                var model = wards.Select(ward => _mapper.Map<WardModel>(ward)).ToList();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
