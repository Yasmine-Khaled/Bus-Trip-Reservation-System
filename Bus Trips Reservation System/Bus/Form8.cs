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
    public partial class Form8 : Form
    {
        CrystalReport2 CR;
        public Form8()
        {
            InitializeComponent();

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
            foreach (ParameterDiscreteValue v1 in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v1.Value);
            foreach (ParameterDiscreteValue v2 in CR.ParameterFields[1].DefaultValues)
                comboBox2.Items.Add(v2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
            CR.SetParameterValue(0, comboBox1.Text);
            CR.SetParameterValue(1, (comboBox2.Text));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
