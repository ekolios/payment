using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ProdRelationVO Data Structure.
    /// </summary>
    public class ProdRelationVO : AlipayObject
    {
        /// <summary>
        /// 数量
        /// </summary>
        [JsonPropertyName("num")]
        public long Num { get; set; }

        /// <summary>
        /// 数量类型
        /// </summary>
        [JsonPropertyName("num_type")]
        public string NumType { get; set; }

        /// <summary>
        /// product码
        /// </summary>
        [JsonPropertyName("prod_code")]
        public string ProdCode { get; set; }

        /// <summary>
        /// 关联的product编码
        /// </summary>
        [JsonPropertyName("prod_rel_code")]
        public string ProdRelCode { get; set; }

        /// <summary>
        /// 关联的product名称
        /// </summary>
        [JsonPropertyName("prod_rel_name")]
        public string ProdRelName { get; set; }

        /// <summary>
        /// product关联类型
        /// </summary>
        [JsonPropertyName("prod_rel_type")]
        public string ProdRelType { get; set; }

        /// <summary>
        /// 关联的product版本
        /// </summary>
        [JsonPropertyName("prod_rel_version")]
        public string ProdRelVersion { get; set; }

        /// <summary>
        /// product版本
        /// </summary>
        [JsonPropertyName("prod_version")]
        public string ProdVersion { get; set; }

        /// <summary>
        /// product关联子类型
        /// </summary>
        [JsonPropertyName("sub_prod_rel_type")]
        public string SubProdRelType { get; set; }
    }
}
