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
    public class PlayerTrainingController : ControllerBase
    {
        private IUnitOfWork<PlayerTraining> _unitOfWork;
        private IMapper _mapper;

        public PlayerTrainingController(IUnitOfWork<PlayerTraining> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET api/broadcasts/3
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PlayerTrainingDto>>> Get(int id)
        {
            var playerTraining = _mapper.Map<PlayerTrainingDto>(await _unitOfWork.GetRepository().GetAll().Where(x => x.TrainingId == id)
                .FirstOrDefaultAsync());

            if (playerTraining == null)
            {
                return NotFound();
            }
            return Ok(playerTraining);
        }

        // POST api/broadcasts
        [HttpPost]
        public async Task<ActionResult<PlayerTraining>> Post([FromBody] PlayerTrainingDto playerTrainingDto)
        {
            if (playerTrainingDto == null)
            {
                return BadRequest();
            }

            var playerTraining = _mapper.Map<PlayerTraining>(playerTrainingDto);
            playerTraining.Player = null;
            _unitOfWork.GetRepository().Add(playerTraining);
            _unitOfWork.SaveChanges();
            return Ok(playerTraining);
        }


        // DELETE api/broadcasts/5
        [HttpPost("{id}")]
        public async Task<ActionResult<PlayerTrainingDto>> Delete([FromBody] PlayerTrainingDto dtoToDelete)
        {
            var playerTraining = await _unitOfWork.GetRepository().GetAll().Where(x => x.TrainingId == dtoToDelete.TrainingId &&
                x.PlayerId == dtoToDelete.Player.Id).FirstOrDefaultAsync();
            if (playerTraining == null)
            {
                return NotFound();
            }

            _unitOfWork.GetRepository().Remove(playerTraining);
            _unitOfWork.SaveChanges();
            return Ok(_mapper.Map<PlayerTrainingDto>(playerTraining));
        }

    }
}
