using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
  public class PaymentController : BaseController
  {
    private IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
      _paymentService = paymentService;
    }
    [HttpGet(":{paymentId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Payment>> FindOne(string paymentId)
    {
      Payment? payment = await _paymentService.FindOne(new Guid(paymentId));
      if (payment is not null)
      {
        return Ok(payment);
      }
      return NotFound();
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Payment>> CreateOne([FromBody] Payment newPayment)
    {
      return Ok(await _paymentService.CreateOne(newPayment));
    }
  }
}