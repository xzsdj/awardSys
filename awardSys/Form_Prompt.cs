using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awardSys
{
    public delegate void endChose(bool status);
    public partial class Form_Prompt : Form
    {
        public endChose _endChose;
        public Form_Prompt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _endChose?.Invoke(false);
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _endChose?.Invoke(true);
            this.Close();
        }
    }
}
