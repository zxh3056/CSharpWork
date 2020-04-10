using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderPro;
using OrderWindow;

namespace SonWinForm
{
    public partial class Form1 : Form
    {
        public string ID { get; set; }
        public string CumName { get; set; } 
        public Form1()
        {
            InitializeComponent();
        }
    }
}
