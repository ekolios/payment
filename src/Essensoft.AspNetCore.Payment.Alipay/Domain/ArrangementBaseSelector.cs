using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Essensoft.AspNetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ArrangementBaseSelector Data Structure.
    /// </summary>
    public class ArrangementBaseSelector : AlipayObject
    {
        /// <summary>
        /// 合约状态列表.01 待生效，02 生效，03失效，04 取消
        /// </summary>
        [JsonPropertyName("ar_statuses")]
        public List<string> ArStatuses { get; set; }

        /// <summary>
        /// product外标类型:01：机构product 02：借款人信息 03：主站product 04： 标准机构product  05：内部业务平台标准product
        /// </summary>
        [JsonPropertyName("mark_type")]
        public string MarkType { get; set; }

        /// <summary>
        /// product编码列表
        /// </summary>
        [JsonPropertyName("pd_codes")]
        public List<string> PdCodes { get; set; }

        /// <summary>
        /// product外标列表
        /// </summary>
        [JsonPropertyName("pd_marks")]
        public List<string> PdMarks { get; set; }

        /// <summary>
        /// 是否查询出product外标
        /// </summary>
        [JsonPropertyName("select_pd_mark")]
        public bool SelectPdMark { get; set; }

        /// <summary>
        /// 是否查询出product名称
        /// </summary>
        [JsonPropertyName("select_pd_name")]
        public bool SelectPdName { get; set; }
    }
}
