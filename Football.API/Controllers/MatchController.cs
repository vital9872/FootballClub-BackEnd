using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Football.API.Dto;
using Football.API.Dto.QueryParams;
using Football.API.Services;
using Football.API.ViewModels;
using Football.DAL;
using Football.DAL.Entities;
using Football.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private IUnitOfWork<Match> _unitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;


        public MatchController(IUnitOfWork<Match> unitOfWork, IMapper mapper, IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> Get()
        {
            //return _matchData.GetMatches().ToList();
            return await _unitOfWork.GetRepository().GetAll().ToListAsync();
            
        }

        // GET api/matches/3
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> Get(int id)
        {
            var match = _mapper.Map<MatchDto>(_unitOfWork.GetRepository().GetAll().Include(x => x.PlayerMatches)
                .ThenInclude(y => y.Player).FirstOrDefault(x => x.Id == id));
            if (match == null)
            {
                return NotFound();
            }
            return new ObjectResult(match);
        }

        // POST api/matches
        [HttpPost]
        public async Task<ActionResult<Match>> Post(MatchDto matchVM)
        {
            if (matchVM == null)
            {
                return BadRequest();
            }

            var match = _mapper.Map<Match>(matchVM);
            _unitOfWork.GetRepository().Add(match);
            _unitOfWork.SaveChanges();

            return Ok(match);
        }

        // PUT api/matches/
        [HttpPut]
        public async Task<ActionResult<Player>> Put(MatchDto matchVM)
        {
            if (matchVM == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != matchVM.Id))
            {
                return NotFound();
            }

            var match = _mapper.Map<Match>(matchVM);
            _unitOfWork.GetRepository().Update(match);
            _unitOfWork.SaveChanges();
            return Ok(match);
        }

        // DELETE api/matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> Delete(int id)
        {
            Match match = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            _unitOfWork.GetRepository().Remove(match);
            _unitOfWork.SaveChanges();
            return Ok(match);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<MatchDto>>> GetAllMatches([FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var matches = _unitOfWork.GetRepository().GetAll().Include(x => x.MatchTournament);
            return await _paginationService.GetPageAsync<MatchDto, Match>(matches, fullPaginationQuery);
        }
    }
}
