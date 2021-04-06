using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class Page
    {
        private XmlClasses.Subsheet bpSubsheet;

        public Page(XmlClasses.Subsheet bpSubsheet)
        {
            this.bpSubsheet = bpSubsheet;
        }

        public BpTools.Page GetPage()
        {
            BpTools.Page page = new BpTools.Page();
            page.Id = bpSubsheet.SubsheetId;
            page.Type = bpSubsheet.Type;
            page.Published = bool.Parse(bpSubsheet.Published);
            page.Name = bpSubsheet.Name;
            page.View.CameraX = bpSubsheet.View.CameraX;
            page.View.CameraY = bpSubsheet.View.CameraY;
            page.View.Zoom = bpSubsheet.View.Zoom.Value;

            return page;
        }

    }
}
