using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace MonitorDemo
{
    public partial class MonitorDemo : Form
    {
        VideoCapture capture = new VideoCapture(1); //create a camera captue
        Image<Bgr, Byte> img;
        HumanFace hf = new HumanFace();
        Rectangle[] rects;
        int[] labels;

        public MonitorDemo()
        {
            InitializeComponent();
            img = new Image<Bgr, Byte>(imageBox1.Size);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Idle += new EventHandler(processFrame);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(processFrame);
        }

        public void processFrame(object sender, EventArgs e)
        {
            //run this until application closed (close button click on image viewer)
            img = capture.QueryFrame().ToImage<Bgr, Byte>();
            rects = hf.detectFace(img);
            if (rects.Length > 0)
            {
                //img.Draw(rect, new Bgr(Color.DarkCyan), 4);

                labels = hf.recognizeFace(img, rects);
                // update information
            }
            double scaleW = 1.0 * imageBox1.Width / img.Width;
            double scaleH = 1.0 * imageBox1.Height / img.Height;
            double scale = scaleW < scaleH ? scaleW : scaleH;

            img = img.Resize(scale, Inter.Linear);
            imageBox1.Image = img;
        }
    }
}
