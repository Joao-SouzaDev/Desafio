using AutoMapper;
using Desafio.FeedbackService.Data.DTO;
using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace Desafio.FeedbackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly Services.FeedbackService _feedbackService;
        private readonly IMapper _mapper;
        public FeedbackController(Services.FeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona um feedback feedback
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="201">Retorna Feedback criado</returns>
        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeecbackRequest request)
        {
            var feedback = _mapper.Map<Feedback>(request);
            await _feedbackService.CreateFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
        }
        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var feedbacks = await _feedbackService.GetFeedbacksAsync();
            var feedbacksResponse = _mapper.Map<IEnumerable<GetFeedbackResponse>>(feedbacks);
            return Ok(feedbacksResponse);
        }
        [HttpGet("{productId}/feedbacks")]
        public async Task<IActionResult> GetFeedbacksByProductId(Guid productId)
        {
            var feedbacks = (await _feedbackService.GetFeedbacksByProductIdAsync(productId)).ToList();
            var feedbacksResponse = _mapper.Map<List<GetFeedbackResponse>>(feedbacks);
            return Ok(feedbacksResponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(Guid id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            var feedbackResponse = _mapper.Map<GetFeedbackResponse>(feedback);
            return Ok(feedbackResponse);
        }
    }
}
