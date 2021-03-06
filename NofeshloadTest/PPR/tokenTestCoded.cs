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


    [DeploymentItem("nofeshloadtest\\dataNofashim.txt", "nofeshloadtest")]
    [DataSource("dataNofesh", "Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\nofeshloadtest\\dataNofashim.txt", Microsoft.VisualStudio.TestTools.WebTesting.DataBindingAccessMethod.Sequential, Microsoft.VisualStudio.TestTools.WebTesting.DataBindingSelectColumns.SelectOnlyBoundColumns, "dataNofashim#txt")]
    [DataBinding("dataNofesh", "dataNofashim#txt", "user", "dataNofesh.dataNofashim#txt.user")]
    [DataBinding("dataNofesh", "dataNofashim#txt", "birth", "dataNofesh.dataNofashim#txt.birth")]
    public class tokenTestCoded : WebTest
    {

        public tokenTestCoded()
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

            WebTestRequest request1 = new WebTestRequest("https://www5.tel-aviv.gov.il/tlvservices/tlvirgunovdim/token");
            request1.Method = "POST";
            request1.Headers.Add(new WebTestRequestHeader("Accept", "application/json, text/plain, */*"));
            request1.Headers.Add(new WebTestRequestHeader("Referer", "https://www5.tel-aviv.gov.il/Tlvirgunovdim/"));
            FormPostHttpBody request1Body = new FormPostHttpBody();
            request1Body.FormPostParameters.Add("username", this.Context["dataNofesh.dataNofashim#txt.user"].ToString());

            request1Body.FormPostParameters.Add("password", String.Format("{0:dd/MM/yyyy}", DateTime.Parse(this.Context["dataNofesh.dataNofashim#txt.birth"].ToString())));
            request1Body.FormPostParameters.Add("grant_type", "password");
            request1Body.FormPostParameters.Add("captchatext", "");
            request1Body.FormPostParameters.Add("capuid", "eacf53edb27944ef9083f71b6694918c");
            request1Body.FormPostParameters.Add("login_type", "0");
            request1.Body = request1Body;

            ExtractText extractionRule1 = new ExtractText();
            extractionRule1.StartsWith = "access_token\":\"";
            extractionRule1.EndsWith = "\"";
            extractionRule1.IgnoreCase = false;
            extractionRule1.UseRegularExpression = false;
            extractionRule1.Required = true;
            extractionRule1.ExtractRandomMatch = false;
            extractionRule1.Index = 0;
            extractionRule1.HtmlDecode = true;
            extractionRule1.SearchInHeaders = false;
            extractionRule1.ContextParameterName = "access_token";
            request1.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule1.Extract);
            yield return request1;
           
            request1 = null;
        }
        void request1_PostRequest(object sender, PostRequestEventArgs e)
        {
            String responseBody = e.Response.BodyString;
        }
    }
}
