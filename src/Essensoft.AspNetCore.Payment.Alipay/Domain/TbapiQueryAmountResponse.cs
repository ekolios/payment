using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// TbapiQueryAmountResponse Data Structure.
    /// </summary>
    public class TbapiQueryAmountResponse : AlipayObject
    {
        /// <summary>
        /// 指定product码额度
        /// </summary>
        [JsonPropertyName("amt_map")]
        public string AmtMap { get; set; }

        /// <summary>
        /// 可用product组额度
        /// </summary>
        [JsonPropertyName("available_group_amt")]
        public string AvailableGroupAmt { get; set; }
    }
}
