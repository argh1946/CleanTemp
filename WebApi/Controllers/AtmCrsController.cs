using AutoMapper;
using Core.Contracts;
using Core.Contracts.AtmCrs;
using Core.DTOs;
using Core.Entities;
using Core.Filter;
using Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtmCrsController : ControllerBase
    {

        protected readonly IAtmCrsService _atmCrsService;
        private readonly IMapper _mapper;


        public AtmCrsController(IAtmCrsService atmCrsService, IMapper mapper)
        {
            _atmCrsService = atmCrsService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAtmCrs()
        {

            var data = await _atmCrsService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<AtmCrs>, IEnumerable<AtmCrsVM>>(data);
            var reponse = ResponseHelper.CreateReponse(result, true, null);
            return Ok(reponse);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAtmCrs(int id)
        {

            var data = await _atmCrsService.GetByIdAsync(id);
            var result = _mapper.Map<AtmCrs, AtmCrsVM>(data);
            var reponse = ResponseHelper.CreateReponse(result, true, null);
            return Ok(reponse);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAtmCrsAsync(AtmCrs AtmCrs)
        {

            await _atmCrsService.AddAsync(AtmCrs);
            var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
            return Ok(response);


        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAtmCrs(AtmCrs AtmCrs)
        {

            await _atmCrsService.Update(AtmCrs);
            var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
            return Ok(response);


        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAtmCrsAsync(int id)
        {

            await _atmCrsService.DeleteAsync(id);
            var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
            return Ok(response);


        }
    }
}