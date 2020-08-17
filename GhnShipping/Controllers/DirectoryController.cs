using AutoMapper;
using GhnShipping.Infrastructure;
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
        private readonly IDirectoryService _directoryService;
        private readonly IMapper _mapper;

        public DirectoryController(IDirectoryService directoryService, IMapper mapper)
        {
            _directoryService = directoryService;
            _mapper = mapper;
        }

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
    }
}
