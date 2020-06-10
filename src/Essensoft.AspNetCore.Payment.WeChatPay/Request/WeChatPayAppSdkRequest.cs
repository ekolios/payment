﻿using System.Collections.Generic;
using Essensoft.AspNetCore.Payment.WeChatPay.Utility;

namespace Essensoft.AspNetCore.Payment.WeChatPay.Request
{
    /// <summary>
    /// APP payment
    /// </summary>
    public class WeChatPayAppSdkRequest : IWeChatPaySdkRequest
    {
        /// <summary>
        /// Prepaid transaction session ID
        /// </summary>
        public string PrepayId { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Package { get; set; } = "Sign=WXPay";

        #region IWeChatPaySdkRequest Members

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new WeChatPayDictionary
            {
                { "prepayid", PrepayId },
                { "package", Package }
            };
            return parameters;
        }

        public void PrimaryHandler(WeChatPayOptions options, WeChatPayDictionary sortedTxtParams)
        {
            sortedTxtParams.Add(WeChatPayConsts.noncestr, WeChatPayUtility.GenerateNonceStr());
            sortedTxtParams.Add(WeChatPayConsts.timestamp, WeChatPayUtility.GetTimeStamp());

            if (!string.IsNullOrEmpty(options.SubAppId) && !string.IsNullOrEmpty(options.SubMchId))
            {
                sortedTxtParams.Add(WeChatPayConsts.appid, options.SubAppId);
                sortedTxtParams.Add(WeChatPayConsts.partnerid, options.SubMchId);
            }
            else
            {
                sortedTxtParams.Add(WeChatPayConsts.appid, options.AppId);
                sortedTxtParams.Add(WeChatPayConsts.partnerid, options.MchId);
            }

            sortedTxtParams.Add(WeChatPayConsts.sign, WeChatPaySignature.SignWithKey(sortedTxtParams, options.Key, WeChatPaySignType.MD5));
        }

        #endregion
    }
}
