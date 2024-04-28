using BackendTeamwork.Abstractions;

namespace BackendTeamwork.Controllers
{
  public class PaymentController : BaseController
  {
    private IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
      _paymentService = paymentService;
    }

  }
}