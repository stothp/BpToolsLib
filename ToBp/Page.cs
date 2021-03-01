using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class Page
    {
        public static BpClasses.Subsheet getXmlSubsheet (BpTools.Page page)
        {
            BpClasses.Subsheet xmlObj = new BpClasses.Subsheet();

            xmlObj.SubsheetId = page.Id;
            xmlObj.Type = page.Type;
            xmlObj.Published = page.Published ? "True" : "False";
            xmlObj.Name = page.Name;
            if (page.View != null)
            {
                xmlObj.View = new BpClasses.View();
                xmlObj.View.CameraX = page.View.CameraX;
                xmlObj.View.CameraY = page.View.CameraY;
                
                xmlObj.View.Zoom = new BpClasses.Zoom();
                xmlObj.View.Zoom.Version = page.View.Version;
                xmlObj.View.Zoom.Value = page.View.Zoom;
            }
            return xmlObj;
        }
    }
}
