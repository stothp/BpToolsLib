using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Action
    {
        public string Vbo { get; set; } = "";
        public string Page { get; set; } = "";

        public Action()
        {
        }

        public Action(string vbo, string page)
        {
            Vbo = vbo;
            Page = page;
        }
    }
}
