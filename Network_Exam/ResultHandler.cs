using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_Exam
{
    internal class ResultHandler
    {
        public List<HttpResponse> UnValid { get; set; }

        public List<HttpResponse> Available { get; set; }

        public List<HttpResponse> UnAvailable { get; set; }

        public List<HttpResponse> Unknown { get; set; }

        public ResultHandler(List<HttpResponse> ToSort)
        {
            Available = new List<HttpResponse>();
            Unknown = new List<HttpResponse>();
            UnAvailable = new List<HttpResponse>();
            UnValid = new List<HttpResponse>();
            Sort(ToSort);
        }

        public void ShowAll()
        {
            ShowResponses(UnValid, "UnValid");
            ShowResponses(Available, "Available");
            ShowResponses(UnAvailable, "UnAvailable");
            ShowResponses(Unknown, "Unknown");
            Console.WriteLine("\n");
        }

        public void ShowResponses(List<HttpResponse> toShow,string name)
        {
            if (toShow.Count == 0)
            {
                return;
            }

            bool isFirst = true;
            Console.Write(name + "[" + toShow.Count + "] : ");
            foreach (var elem in toShow)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                    Console.Write(",");
                Console.Write("{0}[{1}]",elem.Url,elem.StatusCode);
            }
            Console.Write(" | ");
        }

        public void Sort(List<HttpResponse> toSort)
        {
            foreach (HttpResponse res in toSort)
            {
                switch (res.StatusCode)
                {
                    case 600:
                        UnValid.Add(res);
                        break;
                    case >= 200 and < 300:
                        Available.Add(res);
                        break;
                    case >= 400 and < 500:
                        UnAvailable.Add(res);
                        break;
                    default:
                        Unknown.Add(res);
                        break;
                }
            }
        }
    }
}
