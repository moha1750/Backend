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
    [ProducesResponseType(204)]
    [ProducesResponseType(200)]
    public ActionResult<Payment> FindOne(string id)
    {
      Payment? payment = _paymentService.FindOne(new Guid(id));
      if (payment is not null)
      {
        return payment;
      }
      return NoContent();
    }


  }
}