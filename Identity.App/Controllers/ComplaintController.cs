using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Dtos.Complaint;
using CoreLayer.Entities.ComplaintEntity;
using CoreLayer.Interfaces.Service;
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
    public class ComplaintController : BaseController
    {
        private readonly IService<Complaint> _complaintService;
        private readonly IMapper _mapper;
        public ComplaintController(IService<Complaint> complaintService, IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return CreateActionResult<IEnumerable<ComplaintDto>>(CustomResponseDto<IEnumerable<ComplaintDto>>.success(200,_mapper.Map<IEnumerable<ComplaintDto>>(await _complaintService.GetAllAsync())));
        }
        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            return CreateActionResult<ComplaintDto>(CustomResponseDto<ComplaintDto>.success(200, _mapper.Map<ComplaintDto>(await _complaintService.GetByIdAsync(id))));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ComplaintDto complaintDto)
        {
         return CreateActionResult<ComplaintDto>(CustomResponseDto<ComplaintDto>.success(200,_mapper.Map<ComplaintDto>(await _complaintService.AddAsync(_mapper.Map<Complaint>(complaintDto)))));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ComplaintDto complaintDto)
        {
            await _complaintService.Update(_mapper.Map<Complaint>(complaintDto));
            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
