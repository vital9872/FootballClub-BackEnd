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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IUnitOfWork<Player> _unitOfWork;
        private IUnitOfWork<PlayerMatch> _pmUnitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;

        public PlayersController(IUnitOfWork<Player> unitOfWork, IUnitOfWork<PlayerMatch> pmUnitOfWork , 
            IMapper mapper, IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pmUnitOfWork = pmUnitOfWork;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGetDto>>> Get()
        {
            var players = _mapper.Map<IEnumerable<PlayerGetDto>>(await _unitOfWork.GetRepository().GetAll()
                .Include(p => p.Contract)
                .Include(p => p.PlayerMatches)
                .ToListAsync());
            return Ok(players);
        }

        // GET api/players/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = _mapper.Map<PlayerGetDto>(await _unitOfWork.GetRepository().GetAll()
                .Include(p => p.Contract)
                .Include(p => p.PlayerMatches)
                .SingleOrDefaultAsync(p => p.Id == id));

            if (player == null)
            {
                return NotFound();
            }
            return new ObjectResult(player);
        }

        // POST api/players
        [HttpPost]
        public async Task<ActionResult<Player>> Post([FromBody]PlayerDto playerVM)
        {
            if (playerVM == null)
            {
                return BadRequest();
            }

            var player = _mapper.Map<Player>(playerVM);
            _unitOfWork.GetRepository().Add(player);
            _unitOfWork.SaveChanges();
            return Ok(player);
        }

        // PUT api/players/
        [HttpPut]
        public async Task<ActionResult<Player>> Put([FromBody]PlayerDto playerVM)
        {
            if (playerVM == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != playerVM.Id))
            {
                return NotFound();
            }

            var player = _mapper.Map<Player>(playerVM);
            _unitOfWork.GetRepository().Update(player);

            _unitOfWork.SaveChanges();
            return Ok(player);
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> Delete(int id)
        {
            Player player = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            var removedPlayerMatches = _pmUnitOfWork.GetRepository().GetAll().Where(x => x.PlayerId == id);
            _pmUnitOfWork.GetRepository().RemoveRange(removedPlayerMatches);
            _pmUnitOfWork.SaveChanges();

            _unitOfWork.GetRepository().Remove(player);
            _unitOfWork.SaveChanges();
            return Ok(player);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<PlayerDto>>> GetAllPlayers([FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var players =  _unitOfWork.GetRepository().GetAll()
                .Include(p => p.Contract)
                .Include(p => p.PlayerMatches);
            return await _paginationService.GetPageAsync<PlayerDto, Player>(players, fullPaginationQuery);
        }
    }
}
