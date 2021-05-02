using Football.API.Dto;
using Football.API.Dto.QueryParams;
using Football.API.Services;
using Football.DAL;
using Football.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Football.API.ViewModels;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {

        private IUnitOfWork<Income> _unitOfWork;
        private IUnitOfWork<Match> _matchUnitOfWork;
        private IUnitOfWork<Player> _playerUnitOfWork;
        private IUnitOfWork<MatchBroadcast> _broadcastUnitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;


        public IncomeController(IUnitOfWork<Income> unitOfWork, IPaginationService paginationService,
            IUnitOfWork<Match> matchUnitOfWork, IUnitOfWork<Player> playerUnitOfWork, IUnitOfWork<MatchBroadcast> broadcastUnitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paginationService = paginationService;
            _matchUnitOfWork = matchUnitOfWork;
            _playerUnitOfWork = playerUnitOfWork;
            _broadcastUnitOfWork = broadcastUnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> Get()
        {
            return await _unitOfWork.GetRepository().GetAll().ToListAsync();
        }

        // GET api/matches/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> Get(int id)
        {
            var match = _unitOfWork.GetRepository().GetAll().FirstOrDefault(x => x.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            return new ObjectResult(match);
        }

        // POST api/matches
        [HttpPost]
        [Route("match")]
        public async Task<ActionResult<Income>> PostMatchIncome()
        {
            var matches = _matchUnitOfWork
                .GetRepository()
                .GetAll()
                .Where(x => x.StartDate.Month == DateTime.Now.Month)
                .Include(x => x.MatchTournament)
                .GroupBy(x => x.MatchTournament.Name);

            Income income = new Income();
            var broadcasts = _broadcastUnitOfWork.GetRepository().GetAll()
                .Include(x => x.MatchTournament)
                .Where(x => matches.Any(y => y.Key == x.MatchTournament.Name))
                .GroupBy(x => x.MatchTournament.Name)
                .Select(cl => new
                {
                    Type = cl.Key,
                    Sum = cl.Sum(x => x.Payment)
                });


            var ticketsSum = _matchUnitOfWork.GetRepository().GetAll()
                    .Where(x => x.StartDate.Month == DateTime.Now.Month)
                    .Sum(x => x.TicketSales);

            var broadcastsSum = broadcasts.Sum(x => x.Sum);

            income.Description = "Match monthly income";
            income.Date = DateTime.Now;
            income.Amount = (double)(ticketsSum + broadcastsSum);
            _unitOfWork.GetRepository().Add(income);
            _unitOfWork.SaveChanges();

            return Ok(income);
        }

        [HttpPost]
        public async Task<ActionResult<Income>> Post(Income income)
        {
            if (income == null)
            {
                return BadRequest();
            }

            _unitOfWork.GetRepository().Add(income);
            _unitOfWork.SaveChanges();

            return Ok(income);
        }

        // PUT api/matches/
        [HttpPut]
        public async Task<ActionResult<Income>> Put(Income incomeVM)
        {
            if (incomeVM == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != incomeVM.Id))
            {
                return NotFound();
            }

            _unitOfWork.GetRepository().Update(incomeVM);
            _unitOfWork.SaveChanges();
            return Ok(incomeVM);
        }

        // DELETE api/matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> Delete(int id)
        {
            Income income = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            _unitOfWork.GetRepository().Remove(income);
            _unitOfWork.SaveChanges();
            return Ok(income);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<Income>>> GetAllMatches([FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var incomes = _unitOfWork.GetRepository().GetAll();
            return await _paginationService.GetPageAsync<Income, Income>(incomes, fullPaginationQuery);
        }
    }
}
