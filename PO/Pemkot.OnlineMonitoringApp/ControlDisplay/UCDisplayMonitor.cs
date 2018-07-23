using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pemkot.OnlineMonitoringApp.ControlDisplay
{
    public partial class UCDisplayMonitor : UserControl
    {
        //ad 2  cara
        // lwt properties

        public string LabelStatus
        {
            get
            {
                return lblStatus.Text;
            }
            set
            {
                lblStatus.Text = value;
            }
        }

        public string LabelLastActivity
        {
            get
            {
                return lblLastActivity.Text;
            }
            set
            {
                lblLastActivity.Text = value;
            }
        }

        public string LabelUsername { get { return lblUsername.Text; } set { lblUsername.Text = value; } }

        public string LabelJenisPajak { get { return lblJenisPajak.Text; } set { lblJenisPajak.Text = value; } }
        public string LabelNopTerdaftar { get { return lblNopTerdafatar.Text; } set { lblNopTerdafatar.Text = value; } }

        public Image PictureStatus
        {
            get
            {
                return pictStatusActive.BackgroundImage;
            }
            set
            {
                pictStatusActive.BackgroundImage = value;
            }
        }

        // ato lewat  constructor

        public UCDisplayMonitor()
        {
            InitializeComponent();
        }
    }
}
