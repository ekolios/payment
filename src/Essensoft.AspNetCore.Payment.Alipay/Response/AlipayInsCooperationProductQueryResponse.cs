﻿using System.Text.Json.Serialization;
using Essensoft.AspNetCore.Payment.Alipay.Domain;

namespace Essensoft.AspNetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsCooperationProductQueryResponse.
    /// </summary>
    public class AlipayInsCooperationProductQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 保险product
        /// </summary>
        [JsonPropertyName("product")]
        public InsProduct Product { get; set; }
    }
}
