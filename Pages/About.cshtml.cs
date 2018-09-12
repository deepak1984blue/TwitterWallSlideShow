using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitterUI.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public JArray objectArray { get; set; }
        public void OnGet()
        {
            //Message = "Your application description page.";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://twitterapidemo.azurewebsites.net/TimelineLINQ/deepak1984blue");
            request.Method = "GET";
            //String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                Message = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            objectArray = JArray.Parse(Message);
        }
    }
}
