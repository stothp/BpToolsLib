using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public class Page
    {
        BpToolsLib.Page page;

        public Page(BpToolsLib.Page page)
        {
            this.page = page;
        }

        public XmlClasses.Subsheet GetBpSubsheet()
        {
            XmlClasses.Subsheet bpSubsheet = new XmlClasses.Subsheet();

            bpSubsheet.Name = page.Name;
            bpSubsheet.Published = page.Published ? "True" : "False";
            bpSubsheet.SubsheetId = page.Id;
            bpSubsheet.Type = page.Type;
            bpSubsheet.View = new XmlClasses.View();
            bpSubsheet.View.CameraX = page.View.CameraX;
            bpSubsheet.View.CameraY = page.View.CameraY;
            bpSubsheet.View.Zoom = new XmlClasses.Zoom();
            bpSubsheet.View.Zoom.Version = page.View.Version;
            bpSubsheet.View.Zoom.Value = page.View.Zoom;

            return bpSubsheet;
        }
    }
}
