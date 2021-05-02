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
    public class PaymentController : ControllerBase
    {

        private IUnitOfWork<Payment> _unitOfWork;
        private IUnitOfWork<Match> _matchUnitOfWork;
        private IUnitOfWork<Player> _playerUnitOfWork;
        private IUnitOfWork<MatchBroadcast> _broadcastUnitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;


        public PaymentController(IUnitOfWork<Payment> unitOfWork, IPaginationService paginationService,
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
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            return await _unitOfWork.GetRepository().GetAll().ToListAsync();
        }

        // GET api/matches/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> Get(int id)
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
        public async Task<ActionResult<Payment>> PostMatchPayment()
        {
            var matches = _matchUnitOfWork
                .GetRepository()
                .GetAll()
                .Where(x => x.StartDate.Month == DateTime.Now.Month)
                .Sum(x => x.Outcome);

            Payment payment = new Payment();
           

            payment.Description = "Match monthly payment";
            payment.Date = DateTime.Now;
            payment.Amount = (double)(matches);
            _unitOfWork.GetRepository().Add(payment);
            _unitOfWork.SaveChanges();

            return Ok(payment);
        }

        [HttpPost]
        [Route("player")]
        public async Task<ActionResult<Payment>> PostPlayerPayment()
        {
            var players = _mapper.Map<IEnumerable<PlayerGetDto>>(_playerUnitOfWork
                .GetRepository()
                .GetAll()
                .Include(x => x.Contract));

            var payments = players
                .Sum(x => x.Contract.Salary);

            var bonuses = players.Sum(x => (x.Assists + x.Goals) * x .Contract.Premium);

            Payment payment = new Payment()
            {
                Amount = payments + bonuses,
                Date = DateTime.Now,
                Description = "Players monthly payment"
            };

            _unitOfWork.GetRepository().Add(payment);
            _unitOfWork.SaveChanges();

            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Post(Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            _unitOfWork.GetRepository().Add(payment);
            _unitOfWork.SaveChanges();

            return Ok(payment);
        }

        // PUT api/matches/
        [HttpPut]
        public async Task<ActionResult<Payment>> Put(Payment paymentVM)
        {
            if (paymentVM == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != paymentVM.Id))
            {
                return NotFound();
            }

            _unitOfWork.GetRepository().Update(paymentVM);
            _unitOfWork.SaveChanges();
            return Ok(paymentVM);
        }

        // DELETE api/matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> Delete(int id)
        {
            Payment payment = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            _unitOfWork.GetRepository().Remove(payment);
            _unitOfWork.SaveChanges();
            return Ok(payment);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<Payment>>> GetAllMatches([FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var payments = _unitOfWork.GetRepository().GetAll();
            return await _paginationService.GetPageAsync<Payment, Payment>(payments, fullPaginationQuery);
        }
    }
}
