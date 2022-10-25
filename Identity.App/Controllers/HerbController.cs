using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Dtos.Herb;
using CoreLayer.Entities.HerbEntity;
using CoreLayer.Interfaces.Service.Herb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class HerbController : BaseController
    {
        private readonly IHerbService _herbService;
        private readonly IMapper _mapper;
        public HerbController(IHerbService herbService, IMapper mapper)
        {
            _herbService = herbService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDetail()
        {
            return CreateActionResult<IEnumerable<HerbDto>>(await _herbService.AllDetail());
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var herbs = await _herbService.GetAllAsync();
            var list=herbs.Where(x => x.IsActive == true && x.IsDeleted == false);
            return CreateActionResult<IEnumerable<HerbDto>>(CustomResponseDto<IEnumerable<HerbDto>>.success(200, _mapper.Map<IEnumerable<HerbDto>>(list)));
        }
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            return CreateActionResult<HerbDto>(CustomResponseDto<HerbDto>.success(200, _mapper.Map<HerbDto>(await _herbService.GetByIdAsync(id))));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetail(int id)
        {
            return CreateActionResult<HerbDetailDto>(await _herbService.GetDetail(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(HerbDto herbDto)
        {
            return CreateActionResult<HerbDto>(CustomResponseDto<HerbDto>.success(200, _mapper.Map<HerbDto>(await _herbService.AddAsync(_mapper.Map<Herb>(herbDto)))));
        }
        [HttpPut]
        public async Task<IActionResult> Delete(int id)
        {
            await _herbService.RemoveUpdate(id);
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.success(200));
        }
        [HttpPut]
        public async Task<IActionResult> Update(HerbDto herbDto)
        {
            await _herbService.Update(_mapper.Map<Herb>(herbDto));
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
