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
        private ILogger<AtmCrsController> _logger;


        public AtmCrsController(IAtmCrsService atmCrsService,IMapper mapper, ILogger<AtmCrsController> logger)
        {
            _atmCrsService = atmCrsService;
            _mapper = mapper;
            _logger = logger;
        }
       
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAtmCrs()
        {
            try
            {             
                var data = await _atmCrsService.GetAllAsync();
                var result = _mapper.Map<IEnumerable<AtmCrs>, IEnumerable<AtmCrsVM>>(data);
                var reponse = ResponseHelper.CreateReponse(result, true, null);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا");
                string[] err = { ex.Message + " / " + ex.InnerException?.Message };
                var reponse = ResponseHelper.CreateReponse((AtmCrsVM)null, false, err);
                return BadRequest(reponse);
            }            
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAtmCrs(int id)
        {
            try
            {
                var data = await _atmCrsService.GetByIdAsync(id);
                var result = _mapper.Map<AtmCrs, AtmCrsVM>(data);
                var reponse = ResponseHelper.CreateReponse(result, true, null);
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا");
                string[] err = { ex.Message + " / " + ex.InnerException?.Message };
                var reponse = ResponseHelper.CreateReponse((AtmCrsVM)null, false, err);
                return BadRequest(reponse);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAtmCrsAsync(AtmCrs AtmCrs)
        {
            try
            {
                await _atmCrsService.AddAsync(AtmCrs);
                var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا");
                string[] err = { ex.Message + " / " + ex.InnerException?.Message };
                var reponse = ResponseHelper.CreateReponse((AtmCrsVM)null, false, err);
                return BadRequest(reponse);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAtmCrs(AtmCrs AtmCrs)
        {
            try
            {
                await _atmCrsService.Update(AtmCrs);
                var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا");
                string[] err = { ex.Message + " / " + ex.InnerException?.Message };
                var reponse = ResponseHelper.CreateReponse((AtmCrsVM)null, false, err);
                return BadRequest(reponse);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAtmCrsAsync(int id)
        {
            try
            {
                await _atmCrsService.DeleteAsync(id);
                var response = ResponseHelper.CreateReponse((AtmCrsVM)null, true, null);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطا");
                string[] err = { ex.Message + " / " + ex.InnerException?.Message };
                var reponse = ResponseHelper.CreateReponse((AtmCrsVM)null, false, err);
                return BadRequest(reponse);
            }
        }
    }
}