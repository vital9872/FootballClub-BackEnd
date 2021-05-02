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
    public class TournamentsController : ControllerBase
    {
        private IUnitOfWork<MatchTournament> _unitOfWork;
 

        public TournamentsController(IUnitOfWork<MatchTournament> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchTournament>>> Get()
        {
            var tournaments = await _unitOfWork.GetRepository().GetAll().ToListAsync();
            return Ok(tournaments);
        }

        // GET api/broadcasts/3
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchTournament>> Get(int id)
        {
            var tournament = await _unitOfWork.GetRepository().FindByIdAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }
    }
}
