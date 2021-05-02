using AutoMapper;
using Football.API.Dto;
using Football.API.Dto.QueryParams;
using Football.API.Services;
using Football.DAL;
using Football.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastsController : ControllerBase
    {
        private IUnitOfWork<MatchBroadcast> _unitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;

        public BroadcastsController(IUnitOfWork<MatchBroadcast> unitOfWork,
            IMapper mapper, IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchBroadcastDto>>> Get()
        {
            var broadcasts = _mapper.Map<IEnumerable<MatchBroadcastDto>>(await 
                _unitOfWork.GetRepository().GetAll().Include(x => x.MatchTournament).ToListAsync());
            return Ok(broadcasts);
        }

        // GET api/broadcasts/3
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchBroadcastDto>> Get(int id)
        {
            var broadcast = _mapper.Map<MatchBroadcastDto>(await _unitOfWork.GetRepository().GetAll()
                .Include(x => x.MatchTournament).SingleOrDefaultAsync(p => p.Id == id));

            if (broadcast == null)
            {
                return NotFound();
            }
            return Ok(broadcast);
        }

        // POST api/broadcasts
        [HttpPost]
        public async Task<ActionResult<MatchBroadcastDto>> Post([FromBody] MatchBroadcastDto broadcastDto)
        {
            if (broadcastDto == null)
            {
                return BadRequest();
            }

            var matchBroadCastDto = _mapper.Map<MatchBroadcast>(broadcastDto);
            _unitOfWork.GetRepository().Add(matchBroadCastDto);
            _unitOfWork.SaveChanges();
            return Ok(matchBroadCastDto);
        }

        // PUT api/broadcasts/
        [HttpPut]
        public async Task<ActionResult<MatchBroadcastDto>> Put([FromBody] MatchBroadcast matchBroadcastDto)
        {
            if (matchBroadcastDto == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != matchBroadcastDto.Id))
            {
                return NotFound();
            }

            var broadcast = _mapper.Map<MatchBroadcast>(matchBroadcastDto);
            _unitOfWork.GetRepository().Update(broadcast);

            _unitOfWork.SaveChanges();
            return Ok(broadcast);
        }

        // DELETE api/broadcasts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchBroadcastDto>> Delete(int id)
        {
            MatchBroadcast broadCast = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (broadCast == null)
            {
                return NotFound();
            }

            _unitOfWork.GetRepository().Remove(broadCast);
            _unitOfWork.SaveChanges();
            return Ok(_mapper.Map<MatchBroadcastDto>(broadCast));
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<MatchBroadcastDto>>> GetAllBroadcasts(
            [FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var broadcasts = _unitOfWork.GetRepository()
                .GetAll()
                .Include(x => x.MatchTournament);
            return await _paginationService.GetPageAsync<MatchBroadcastDto, MatchBroadcast>(broadcasts, fullPaginationQuery);
        }
    }
}
