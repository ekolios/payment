using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenAgentSignstatusQueryModel Data Structure.
    /// </summary>
    public class AlipayOpenAgentSignstatusQueryModel : AlipayObject
    {
        /// <summary>
        /// isv要查询签约状态的商户账号，是支付宝账号pid（2088开头）
        /// </summary>
        [JsonPropertyName("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// isv要查询商户签约状态的product码，product码是支付宝内部对product的唯一标识
        /// </summary>
        [JsonPropertyName("product_codes")]
        public List<string> ProductCodes { get; set; }
    }
}
