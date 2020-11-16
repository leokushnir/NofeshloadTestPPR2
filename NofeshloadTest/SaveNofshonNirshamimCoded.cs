﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NofeshloadTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;


    [DeploymentItem("nofeshloadtest\\dataNofashim.txt")]
    [DataSource("dataNofesh", "Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\dataNofashim.txt", Microsoft.VisualStudio.TestTools.WebTesting.DataBindingAccessMethod.Sequential, Microsoft.VisualStudio.TestTools.WebTesting.DataBindingSelectColumns.SelectOnlyBoundColumns, "dataNofashim#txt")]
    [DataBinding("dataNofesh", "dataNofashim#txt", "user", "dataNofesh.dataNofashim#txt.user")]
    public class SaveNofshonNirshamimCoded : WebTest
    {

        public SaveNofshonNirshamimCoded()
        {
            this.PreAuthenticate = true;
            this.Proxy = "default";
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            // Initialize validation rules that apply to all requests in the WebTest
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidateResponseUrl validationRule1 = new ValidateResponseUrl();
                this.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule1.Validate);
            }
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidationRuleResponseTimeGoal validationRule2 = new ValidationRuleResponseTimeGoal();
                validationRule2.Tolerance = 0D;
                this.ValidateResponseOnPageComplete += new EventHandler<ValidationEventArgs>(validationRule2.Validate);
            }

            WebTestRequest request1 = new WebTestRequest("https://pre-www5.tel-aviv.gov.il/tlvservices/tlvirgunovdim/api/Nofesh/SaveNofshon" +
                    "Nirshamim");
            request1.Method = "POST";
            request1.Headers.Add(new WebTestRequestHeader("Pragma", "no-cache"));
            request1.Headers.Add(new WebTestRequestHeader("Accept", "application/json, text/plain, */*"));
            request1.Headers.Add(new WebTestRequestHeader("Referer", "https://pre-www5.tel-aviv.gov.il/Tlvirgunovdim/"));
            request1.Headers.Add(new WebTestRequestHeader("Authorization", ("Bearer " + this.Context["access_token"].ToString())));

            StringHttpBody request1Body = new StringHttpBody();
            request1Body.ContentType = "application/json";
            request1Body.InsertByteOrderMark = false;
            request1Body.BodyString = @"{""nirshamim"":[{""ms_zehut_mazmin"":3169,""ms_zehut"":28426187,""tr_leida"":""1971-08-01T00:00:00.000Z"",""shem_prati"":""יניב"",""shem_mishpacha"":""אליעב"",""gender"":2,""header"":""דוקטו"",""ms_cheder"":2,""is_amit"":1,""is_nilve"":0,""is_yeled"":0,""is_tinok"":0,""id_nofesh"":1,""nofesh_type"":3,""phone"":""0542236445"",""ms_darkon"":null,""tr_tokef_darkon"":"""",""shem_prati_loazi"":null,""shem_mishpacha_loazi"":null}]}";
            request1Body.BodyString.Replace("28426187", this.Context["dataNofesh.dataNofashim#txt.user"].ToString());
            request1.Body = request1Body;
            yield return request1;
            request1 = null;
        }
    }
}
