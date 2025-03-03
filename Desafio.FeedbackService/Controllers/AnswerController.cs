using AutoMapper;
using Desafio.FeedbackService.Data.DTO;
using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.FeedbackService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly AnswerService _answerService;
        private readonly IMapper _mapper;
        public AnswerController(AnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona uma resposta a um feedback
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="201">Retorna a resposta gerada</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerRequest request)
        {
            var answer = _mapper.Map<Answer>(request);
            await _answerService.CreateAnswerAsync(answer);
            return CreatedAtAction(nameof(GetAnswerByFeedbackId), new { feedbackId = answer.FeedbackId }, answer);
        }
        /// <summary>
        /// Retorna a resposta de um Answer mostrando o feedback vinculado
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns code="200"></returns>
        [HttpGet("{feedbackId}")]
        public async Task<IActionResult> GetAnswerByFeedbackId(Guid feedbackId)
        {
            var answer = await _answerService.GetAnswersAsync(feedbackId);
            if (answer == null)
            {
                return NotFound();
            }
            var answerResponse = _mapper.Map<GetAnswerResponse>(answer);
            return Ok(answerResponse);
        }
    }
}
