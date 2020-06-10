using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ProductBaseVO Data Structure.
    /// </summary>
    public class ProductBaseVO : AlipayObject
    {
        /// <summary>
        /// product业务状态,product中心目前暂时不消费该业务状态，由外围业务消费
        /// </summary>
        [JsonPropertyName("biz_status")]
        public string BizStatus { get; set; }

        /// <summary>
        /// 是否是组合product,默认为false,填02
        /// </summary>
        [JsonPropertyName("is_combinate")]
        public string IsCombinate { get; set; }

        /// <summary>
        /// product环境类型，默认是线上
        /// </summary>
        [JsonPropertyName("prod_env")]
        public string ProdEnv { get; set; }

        /// <summary>
        /// product名称
        /// </summary>
        [JsonPropertyName("prod_name")]
        public string ProdName { get; set; }

        /// <summary>
        /// product模板编码
        /// </summary>
        [JsonPropertyName("prod_template_code")]
        public string ProdTemplateCode { get; set; }

        /// <summary>
        /// product模板版本
        /// </summary>
        [JsonPropertyName("prod_template_version")]
        public string ProdTemplateVersion { get; set; }

        /// <summary>
        /// product类型 :01: 普通product；02：标准product
        /// </summary>
        [JsonPropertyName("prod_type")]
        public string ProdType { get; set; }

        /// <summary>
        /// product编码
        /// </summary>
        [JsonPropertyName("prod_version")]
        public string ProdVersion { get; set; }

        /// <summary>
        /// product管理状态
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 标准product编码
        /// </summary>
        [JsonPropertyName("std_prod_code")]
        public string StdProdCode { get; set; }

        /// <summary>
        /// 标准product版本
        /// </summary>
        [JsonPropertyName("std_prod_version")]
        public string StdProdVersion { get; set; }
    }
}
