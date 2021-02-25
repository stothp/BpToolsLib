using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class View
    {
        public int CameraX { get; set; } = 0;
        public int CameraY { get; set; } = 0;
        public double Zoom { get; set; } = 1.25; 
        public string Version { get; set; } = "2";

        public View()
        {            
        }

        public View(int cameraX, int cameraY, double zoom, string version)
        {
            CameraX = cameraX;
            CameraY = cameraY;
            Zoom = zoom;
            Version = version;
        }
    }
}
