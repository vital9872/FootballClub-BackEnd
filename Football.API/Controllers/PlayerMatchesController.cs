using AutoMapper;
using Football.API.Dto;
using Football.DAL;
using Football.DAL.Entities;
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
    public class PlayerMatchesController : ControllerBase
    {
        private IUnitOfWork<PlayerMatch> _unitOfWork;
        private IMapper _mapper;

        public PlayerMatchesController(IUnitOfWork<PlayerMatch> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET api/broadcasts/3
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PlayerMatchesDto>>> Get(int id)
        {
            var playerMatches = _mapper.Map<PlayerMatchesDto>(await _unitOfWork.GetRepository().GetAll().Where(x => x.MatchId == id)
                .FirstOrDefaultAsync());

            if (playerMatches == null)
            {
                return NotFound();
            }
            return Ok(playerMatches);
        }

        // POST api/broadcasts
        [HttpPost]
        public async Task<ActionResult<PlayerMatch>> Post([FromBody] PlayerMatchesDto playerMatchesDto)
        {
            if (playerMatchesDto == null)
            {
                return BadRequest();
            }

            var playerMatch = _mapper.Map<PlayerMatch>(playerMatchesDto);
            playerMatch.Player = null;
            _unitOfWork.GetRepository().Add(playerMatch);
            _unitOfWork.SaveChanges();
            return Ok(playerMatch);
        }


        // DELETE api/broadcasts/5
        [HttpPost("{id}")]
        public async Task<ActionResult<PlayerMatchesDto>> Delete([FromBody] PlayerMatchesDto dtoToDelete)
        {
            var playerMatch = await _unitOfWork.GetRepository().GetAll().Where(x => x.MatchId == dtoToDelete.MatchId &&
                x.PlayerId == dtoToDelete.Player.Id).FirstOrDefaultAsync();
            if (playerMatch == null)
            {
                return NotFound();
            }

            _unitOfWork.GetRepository().Remove(playerMatch);
            _unitOfWork.SaveChanges();
            return Ok(_mapper.Map<PlayerMatchesDto>(playerMatch));
        }

    }
}
