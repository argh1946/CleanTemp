using AutoMapper;
using Core.Contracts;
using Core.Contracts.AtmCrs;
using Core.DTOs;
using Core.Entities;
using Core.Helper;
using FluentResults;
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
        public async Task<Result<IEnumerable<AtmCrsVM>>> GetAllAtmCrs()
        {
            var data = await _atmCrsService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<AtmCrs>, IEnumerable<AtmCrsVM>>(data);
            return Result.Ok(result);
        } 
        
        [HttpGet("[action]")]
        public async Task<Result<PaginatedList<AtmCrs>>> GetAllPaginated()
        {
            var data = await _atmCrsService.GetAllPaginated();
           // var result = _mapper.Map<IEnumerable<AtmCrs>, IEnumerable<AtmCrsVM>>(data);
            return Result.Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<Result<AtmCrsVM>> GetByIdAtmCrs(int id)
        {
            var data = await _atmCrsService.GetByIdAsync(id);
            var result = _mapper.Map<AtmCrs, AtmCrsVM>(data);
            return Result.Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<Result> AddAtmCrsAsync(AtmCrs AtmCrs)
        {
            await _atmCrsService.AddAsync(AtmCrs);
            return Result.Ok();
        }

        [HttpPut("[action]")]
        public async Task<Result> UpdateAtmCrs(AtmCrs AtmCrs)
        {
            await _atmCrsService.Update(AtmCrs);
            return Result.Ok();
        }

        [HttpDelete("[action]")]
        public async Task<Result> DeleteAtmCrsAsync(int id)
        {           
            await _atmCrsService.DeleteAsync(id);
            return  Result.Ok();
        }
    }

    
}