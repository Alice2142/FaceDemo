using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace MonitorDemo
{
    class HumanFace
    {
        public HumanFace()
        {

        }

        public Rectangle[] detectFace(Image<Bgr, Byte> img)
        {
            return new Rectangle[1];
        }

        public int[] recognizeFace(Image<Bgr, Byte> img, Rectangle[] rects)
        {
            return new int[1];
        }
    }
}
