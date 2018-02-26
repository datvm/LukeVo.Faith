using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeVo.Faith.MainWebsite.Models.BibleGatewayApi
{
    public class VotD
    {
        public string text { get; set; }
        public string content { get; set; }
        public string display_ref { get; set; }
        public string reference { get; set; }
        public string permalink { get; set; }
        public string copyright { get; set; }
        public string copyrightlink { get; set; }
        public string audiolink { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string version { get; set; }
        public string version_id { get; set; }
    }

    public class VotDResponse
    {
        public VotD votd { get; set; }
    }
}
