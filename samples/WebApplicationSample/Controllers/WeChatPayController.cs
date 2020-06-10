using System.Text.Json;
using System.Threading.Tasks;
using Essensoft.AspNetCore.Payment.WeChatPay;
using Essensoft.AspNetCore.Payment.WeChatPay.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationSample.Models;

namespace WebApplicationSample.Controllers
{
    public class WeChatPayController : Controller
    {
        private readonly IWeChatPayClient _client;
        private readonly IOptions<WeChatPayOptions> _optionsAccessor;

        public WeChatPayController(IWeChatPayClient client, IOptions<WeChatPayOptions> optionsAccessor)
        {
            _client = client;
            _optionsAccessor = optionsAccessor;
        }

        /// <summary>
        /// WeChat Pay guide page
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Credit card payment
        /// </summary>
        [HttpGet]
        public IActionResult MicroPay()
        {
            return View();
        }

        /// <summary>
        /// Credit card payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> MicroPay(WeChatPayMicroPayViewModel viewModel)
        {
            var request = new WeChatPayMicroPayRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                AuthCode = viewModel.AuthCode
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Public account payment
        /// </summary>
        [HttpGet]
        public IActionResult PubPay()
        {
            return View();
        }

        /// <summary>
        /// Public account payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> PubPay(WeChatPayPubPayViewModel viewModel)
        {
            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                NotifyUrl = viewModel.NotifyUrl,
                TradeType = viewModel.TradeType,
                OpenId = viewModel.OpenId
            };

            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            if (response.ReturnCode == WeChatPayCode.Success && response.ResultCode == WeChatPayCode.Success)
            {
                var req = new WeChatPayJsApiSdkRequest
                {
                    Package = "prepay_id=" + response.PrepayId
                };

                var parameter = await _client.ExecuteAsync(req, _optionsAccessor.Value);

                // Give the parameter (parameter) to the front end of the public account and
                // let him transfer the payment in H5 in WeChat(https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_7&index=6)
                ViewData["parameter"] = JsonSerializer.Serialize(parameter);
                ViewData["response"] = response.Body;
                return View();
            }

            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Scan code to pay
        /// </summary>
        [HttpGet]
        public IActionResult QrCodePay()
        {
            return View();
        }

        /// <summary>
        /// Scan code to pay
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> QrCodePay(WeChatPayQrCodePayViewModel viewModel)
        {
            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                NotifyUrl = viewModel.NotifyUrl,
                TradeType = viewModel.TradeType
            };

            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);

            // response.CodeUrl generates a QR code for the front end
            ViewData["qrcode"] = response.CodeUrl;
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// APP payment
        /// </summary>
        [HttpGet]
        public IActionResult AppPay()
        {
            return View();
        }

        /// <summary>
        /// APP payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> AppPay(WeChatPayAppPayViewModel viewModel)
        {
            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                NotifyUrl = viewModel.NotifyUrl,
                TradeType = viewModel.TradeType
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);

            if (response.ReturnCode == WeChatPayCode.Success && response.ResultCode == WeChatPayCode.Success)
            {
                var req = new WeChatPayAppSdkRequest
                {
                    PrepayId = response.PrepayId
                };

                var parameter = await _client.ExecuteAsync(req, _optionsAccessor.Value);

                // Give the parameter (parameter) to the ios / android side and let him call up the WeChat APP
                // (https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=8_5)
                ViewData["parameter"] = JsonSerializer.Serialize(parameter);
                ViewData["response"] = response.Body;
                return View();
            }

            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// H5 payment
        /// </summary>
        [HttpGet]
        public IActionResult H5Pay()
        {
            return View();
        }

        /// <summary>
        /// H5 payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> H5Pay(WeChatPayH5PayViewModel viewModel)
        {
            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                NotifyUrl = viewModel.NotifyUrl,
                TradeType = viewModel.TradeType
            };

            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);

            // mweb_url is the middle page of the WeChat Pay cash register. 
            // You can access the url to pull up the WeChat client to complete the payment. mweb_url is valid for 5 minutes.
            return Redirect(response.MwebUrl);
        }

        /// <summary>
        /// Applet payment
        /// </summary>
        [HttpGet]
        public IActionResult LiteAppPay()
        {
            return View();
        }

        /// <summary>
        /// Applet payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> LiteAppPay(WeChatPayLiteAppPayViewModel viewModel)
        {
            var request = new WeChatPayUnifiedOrderRequest
            {
                Body = viewModel.Body,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                SpBillCreateIp = viewModel.SpBillCreateIp,
                NotifyUrl = viewModel.NotifyUrl,
                TradeType = viewModel.TradeType,
                OpenId = viewModel.OpenId
            };

            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            if (response.ReturnCode == WeChatPayCode.Success && response.ResultCode == WeChatPayCode.Success)
            {
                var req = new WeChatPayLiteAppSdkRequest
                {
                    Package = "prepay_id=" + response.PrepayId
                };

                var parameter = await _client.ExecuteAsync(req, _optionsAccessor.Value);

                // Give the parameter to the front end of the applet and let him call up the payment API
                // (https://pay.weixin.qq.com/wiki/doc/api/wxa/wxa_api.php?chapter=7_7&index=5)
                ViewData["parameter"] = JsonSerializer.Serialize(parameter);
                ViewData["response"] = response.Body;
                return View();
            }

            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// checking order
        /// </summary>
        [HttpGet]
        public IActionResult OrderQuery()
        {
            return View();
        }

        /// <summary>
        /// checking order
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> OrderQuery(WeChatPayOrderQueryViewModel viewModel)
        {
            var request = new WeChatPayOrderQueryRequest
            {
                TransactionId = viewModel.TransactionId,
                OutTradeNo = viewModel.OutTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Cancel the order
        /// </summary>
        [HttpGet]
        public IActionResult Reverse()
        {
            return View();
        }

        /// <summary>
        /// Cancel the order
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> Reverse(WeChatPayReverseViewModel viewModel)
        {
            var request = new WeChatPayReverseRequest
            {
                TransactionId = viewModel.TransactionId,
                OutTradeNo = viewModel.OutTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Close order
        /// </summary>
        [HttpGet]
        public IActionResult CloseOrder()
        {
            return View();
        }

        /// <summary>
        /// Close order
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> CloseOrder(WeChatPayCloseOrderViewModel viewModel)
        {
            var request = new WeChatPayCloseOrderRequest
            {
                OutTradeNo = viewModel.OutTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Request a refund
        /// </summary>
        [HttpGet]
        public IActionResult Refund()
        {
            return View();
        }

        /// <summary>
        /// Request a refund
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> Refund(WeChatPayRefundViewModel viewModel)
        {
            var request = new WeChatPayRefundRequest
            {
                OutRefundNo = viewModel.OutRefundNo,
                TransactionId = viewModel.TransactionId,
                OutTradeNo = viewModel.OutTradeNo,
                TotalFee = viewModel.TotalFee,
                RefundFee = viewModel.RefundFee,
                RefundDesc = viewModel.RefundDesc,
                NotifyUrl = viewModel.NotifyUrl
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Check refund
        /// </summary>
        [HttpGet]
        public IActionResult RefundQuery()
        {
            return View();
        }

        /// <summary>
        /// Check refund
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> RefundQuery(WeChatPayRefundQueryViewModel viewModel)
        {
            var request = new WeChatPayRefundQueryRequest
            {
                RefundId = viewModel.RefundId,
                OutRefundNo = viewModel.OutRefundNo,
                TransactionId = viewModel.TransactionId,
                OutTradeNo = viewModel.OutTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Download statement
        /// </summary>
        [HttpGet]
        public IActionResult DownloadBill()
        {
            return View();
        }

        /// <summary>
        /// Download statement
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> DownloadBill(WeChatPayDownloadBillViewModel viewModel)
        {
            var request = new WeChatPayDownloadBillRequest
            {
                BillDate = viewModel.BillDate,
                BillType = viewModel.BillType,
                TarType = viewModel.TarType
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Download fund flow
        /// </summary>
        [HttpGet]
        public IActionResult DownloadFundFlow()
        {
            return View();
        }

        /// <summary>
        /// Download fund flow
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> DownloadFundFlow(WeChatPayDownloadFundFlowViewModel viewModel)
        {
            var request = new WeChatPayDownloadFundFlowRequest
            {
                BillDate = viewModel.BillDate,
                AccountType = viewModel.AccountType,
                TarType = viewModel.TarType
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Enterprise payment to change
        /// </summary>
        [HttpGet]
        public IActionResult Transfers()
        {
            return View();
        }

        /// <summary>
        /// Enterprise payment to change
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> Transfers(WeChatPayTransfersViewModel viewModel)
        {
            var request = new WeChatPayPromotionTransfersRequest
            {
                PartnerTradeNo = viewModel.PartnerTradeNo,
                OpenId = viewModel.OpenId,
                CheckName = viewModel.CheckName,
                ReUserName = viewModel.ReUserName,
                Amount = viewModel.Amount,
                Desc = viewModel.Desc,
                SpBillCreateIp = viewModel.SpBillCreateIp
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Inquiry of corporate payment
        /// </summary>
        [HttpGet]
        public IActionResult GetTransferInfo()
        {
            return View();
        }

        /// <summary>
        /// Inquiry of corporate payment
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> GetTransferInfo(WeChatPayGetTransferInfoViewModel viewModel)
        {
            var request = new WeChatPayGetTransferInfoRequest
            {
                PartnerTradeNo = viewModel.PartnerTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Corporate payment to bank card
        /// </summary>
        [HttpGet]
        public IActionResult PayBank()
        {
            return View();
        }

        /// <summary>
        /// Corporate payment to bank card
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> PayBank(WeChatPayPayBankViewModel viewModel)
        {
            var request = new WeChatPayPayBankRequest
            {
                PartnerTradeNo = viewModel.PartnerTradeNo,
                BankNo = viewModel.BankNo,
                TrueName = viewModel.TrueName,
                BankCode = viewModel.BankCode,
                Amount = viewModel.Amount,
                Desc = viewModel.Desc
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Inquiry of corporate payment bank card
        /// </summary>
        [HttpGet]
        public IActionResult QueryBank()
        {
            return View();
        }

        /// <summary>
        /// Inquiry of corporate payment bank card
        /// </summary>
        /// <param name="viewModel"></param>
        [HttpPost]
        public async Task<IActionResult> QueryBank(WeChatPayQueryBankViewModel viewModel)
        {
            var request = new WeChatPayQueryBankRequest
            {
                PartnerTradeNo = viewModel.PartnerTradeNo
            };
            var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
            ViewData["response"] = response.Body;
            return View();
        }

        /// <summary>
        /// Obtain RSA encrypted public key
        /// </summary>
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetPublicKey()
        {
            if (Request.Method == "POST")
            {
                var request = new WeChatPayRiskGetPublicKeyRequest();
                var response = await _client.ExecuteAsync(request, _optionsAccessor.Value);
                ViewData["response"] = response.Body;
                return View();
            }

            return View();
        }
    }
}
