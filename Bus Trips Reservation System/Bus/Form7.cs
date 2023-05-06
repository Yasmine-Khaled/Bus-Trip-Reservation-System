using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Bus
{
    public partial class Form7 : Form
    {
        CrystalReport1 CR;
        public Form7()
        {
            InitializeComponent();

         /*   CR.SetParameterValue(0, comboBox1.Text);
            CR.SetParameterValue(1, Convert.ToDateTime(comboBox2.Text));
            crystalReportViewer1.ReportSource = CR;*/

        }


        private void button2_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            CR.SetParameterValue(1, Convert.ToDateTime(comboBox2.Text));
            crystalReportViewer1.ReportSource = CR;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            CR = new CrystalReport1();
            foreach (ParameterDiscreteValue v1 in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v1.Value);
            foreach (ParameterDiscreteValue v2 in CR.ParameterFields[1].DefaultValues)
                comboBox2.Items.Add(v2.Value);
        }

      
    }
}
