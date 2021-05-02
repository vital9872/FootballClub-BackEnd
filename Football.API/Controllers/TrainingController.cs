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
    public class TrainingController : ControllerBase
    {
        private IUnitOfWork<Training> _unitOfWork;
        private IMapper _mapper;
        private IPaginationService _paginationService;


        public TrainingController(IUnitOfWork<Training> unitOfWork, IMapper mapper, IPaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> Get()
        {
            //return _trainingData.GetTraininges().ToList();
            return await _unitOfWork.GetRepository().GetAll().ToListAsync();

        }

        // GET api/trainings/3
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDto>> Get(int id)
        {
            var training = _mapper.Map<TrainingDto>(_unitOfWork.GetRepository().GetAll().Include(x => x.PlayerTrainings)
                .ThenInclude(y => y.Player).FirstOrDefault(x => x.Id == id));
            if (training == null)
            {
                return NotFound();
            }
            return new ObjectResult(training);
        }

        // POST api/trainings
        [HttpPost]
        public async Task<ActionResult<Training>> Post(TrainingDto trainingVM)
        {
            if (trainingVM == null)
            {
                return BadRequest();
            }

            var training = _mapper.Map<Training>(trainingVM);
            _unitOfWork.GetRepository().Add(training);
            _unitOfWork.SaveChanges();

            return Ok(training);
        }

        // PUT api/trainings/
        [HttpPut]
        public async Task<ActionResult<Player>> Put(TrainingDto trainingVM)
        {
            if (trainingVM == null)
            {
                return BadRequest();
            }
            if (_unitOfWork.GetRepository().GetAll().All(x => x.Id != trainingVM.Id))
            {
                return NotFound();
            }

            var training = _mapper.Map<Training>(trainingVM);
            _unitOfWork.GetRepository().Update(training);
            _unitOfWork.SaveChanges();
            return Ok(training);
        }

        // DELETE api/trainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Training>> Delete(int id)
        {
            Training training = await _unitOfWork.GetRepository().FindByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            _unitOfWork.GetRepository().Remove(training);
            _unitOfWork.SaveChanges();
            return Ok(training);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDto<TrainingDto>>> GetAllTraining([FromQuery] FullPaginationQueryParams fullPaginationQuery)
        {
            var trainings = _unitOfWork.GetRepository().GetAll();
            return await _paginationService.GetPageAsync<TrainingDto, Training>(trainings, fullPaginationQuery);
        }
    }
}
