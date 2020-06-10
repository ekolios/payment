using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayInsCooperationProductQueryModel Data Structure.
    /// </summary>
    public class AlipayInsCooperationProductQueryModel : AlipayObject
    {
        /// <summary>
        /// product编码;由蚂蚁保险平台分配,商户通过该product编码投保特定的保险product
        /// </summary>
        [JsonPropertyName("prod_code")]
        public string ProdCode { get; set; }
    }
}
