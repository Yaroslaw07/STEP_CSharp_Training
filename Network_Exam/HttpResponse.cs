using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_Exam
{
    internal class HttpResponse
    {
        public string Url { get; set; }

        public int StatusCode { get; set; }

        public HttpResponse(string url)
        {
            Url = url;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StatusCode = (int)response.StatusCode;
            }
            catch (WebException we)
            {
                StatusCode = (int)((HttpWebResponse)we.Response).StatusCode;
            }
        }

        public HttpResponse(string url,int statusCode)
        {
            Url = url;

            StatusCode = statusCode;
        }
    }
}
