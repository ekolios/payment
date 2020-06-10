using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// InsProduct Data Structure.
    /// </summary>
    public class InsProduct : AlipayObject
    {
        /// <summary>
        /// 险种列表
        /// </summary>
        [JsonPropertyName("coverages")]
        public InsProdCoverage Coverages { get; set; }

        /// <summary>
        /// 起保时间，格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("effect_date")]
        public string EffectDate { get; set; }

        /// <summary>
        /// 结束时间，格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonPropertyName("invalid_date")]
        public string InvalidDate { get; set; }

        /// <summary>
        /// 是否标准product
        /// </summary>
        [JsonPropertyName("is_sp")]
        public bool IsSp { get; set; }

        /// <summary>
        /// 责任信息
        /// </summary>
        [JsonPropertyName("liabilities")]
        public List<InsLiability> Liabilities { get; set; }

        /// <summary>
        /// 保险机构;当product为标准product时该值为空
        /// </summary>
        [JsonPropertyName("merchant")]
        public InsMerchant Merchant { get; set; }

        /// <summary>
        /// product编码;由蚂蚁保险平台分配,商户通过该product编码投保特定的保险product
        /// </summary>
        [JsonPropertyName("prod_code")]
        public string ProdCode { get; set; }

        /// <summary>
        /// product描述
        /// </summary>
        [JsonPropertyName("prod_desc")]
        public string ProdDesc { get; set; }

        /// <summary>
        /// product名称
        /// </summary>
        [JsonPropertyName("prod_name")]
        public string ProdName { get; set; }

        /// <summary>
        /// 标准product码
        /// </summary>
        [JsonPropertyName("prod_no")]
        public string ProdNo { get; set; }

        /// <summary>
        /// product版本号
        /// </summary>
        [JsonPropertyName("prod_version")]
        public string ProdVersion { get; set; }

        /// <summary>
        /// 实付保费[优惠后的金额]
        /// </summary>
        [JsonPropertyName("real_premium")]
        public string RealPremium { get; set; }

        /// <summary>
        /// 优惠保费
        /// </summary>
        [JsonPropertyName("reduce_premium")]
        public string ReducePremium { get; set; }

        /// <summary>
        /// 资源项
        /// </summary>
        [JsonPropertyName("resources")]
        public List<InsProdResource> Resources { get; set; }

        /// <summary>
        /// product销量，配置了销量统计的product才会有销量信息
        /// </summary>
        [JsonPropertyName("sales")]
        public long Sales { get; set; }

        /// <summary>
        /// product简称
        /// </summary>
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// 标准product编码;标准product是不同保险公司同一类型product的一种抽象
        /// </summary>
        [JsonPropertyName("sp_code")]
        public string SpCode { get; set; }

        /// <summary>
        /// 标记列表
        /// </summary>
        [JsonPropertyName("tags")]
        public List<InsProdTag> Tags { get; set; }

        /// <summary>
        /// 总保费
        /// </summary>
        [JsonPropertyName("total_premium")]
        public string TotalPremium { get; set; }
    }
}
