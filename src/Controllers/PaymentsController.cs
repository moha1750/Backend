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
    [HttpGet(":{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Payment>> FindOne(string id)
    {
      Payment? payment = await _paymentService.FindOne(new Guid(id));
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