using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Network_Exam
{
    internal class Checker
    {
        public List<string> toCheck  { get; set; }

        public List<HttpResponse> result { get; set; }

        public Checker(List<string> urls)
        {
            toCheck = urls;

            result = new List<HttpResponse>();
        }

        public void CheckUrls()
        {


            foreach (var url in toCheck)
            {

                if (!IsValide(url))
                    result.Add(new HttpResponse(url, 600));
                else
                {
                    HttpResponse response = new HttpResponse(url);
                    result.Add(response);
                }

                
            }

            toCheck = new List<string>();
        }

        protected bool IsValide(string checkUrl)
        {
            //return Uri.IsWellFormedUriString(checkUrl, UriKind.RelativeOrAbsolute);
            const string strRegex = @"[(http):\/\/a-zA-Z0-9@:%._\+~#=|]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&|//=]*)";
            Regex re = new Regex(strRegex);

            return re.IsMatch(checkUrl);
        }

    }
}
