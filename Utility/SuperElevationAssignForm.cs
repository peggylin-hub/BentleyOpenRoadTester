/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRoadAddin.Utility
    {
    public partial class SuperElevationAssignForm : Form
        {
        private IDictionary<string, double> mSuperPointsFromTemplate;
        private double m_alignmentLength;
        public SuperElevationAssignForm(IDictionary<string, double> superPointsFromTemplate, double alignmentLength)
            {
            InitializeComponent();
            mSuperPointsFromTemplate = superPointsFromTemplate;
            m_alignmentLength = alignmentLength;
            }

        private void InitSuperElevationAssignFormData()
            {
            Dictionary<string, double> superPointsFromTemplate = new Dictionary<string, double>(mSuperPointsFromTemplate);
            foreach (string key in superPointsFromTemplate.Keys)
                {
                comboBoxSuperPoint.Items.Add(key);
                comboBoxPivotPoint.Items.Add(key);
                }
            comboBoxSuperPoint.SelectedIndex = 0;
            comboBoxSuperPoint.SelectedIndex = 1;
            textBoxStartDistance.Text = "0";
            double difference = 0.01;
            textBoxEndDistance.Text = (m_alignmentLength - difference).ToString("F2");
            textBoxPriority.Text = "1";
            }
        private void SuperElevationAssignForm_Load(object sender, EventArgs e)
            {
            InitSuperElevationAssignFormData();
            }
        public string getSuperPoint()
            {
            return comboBoxSuperPoint.SelectedText;
            }
        public string getPivotPoint()
            {
            return comboBoxPivotPoint.SelectedText;
            }
        public double getStartDistance()
            {
            return Convert.ToDouble(textBoxStartDistance.Text);
            }
        public double getEndDistance()
            {
            return Convert.ToDouble(textBoxEndDistance.Text);
            }
        public int getPriority()
            {
            return Convert.ToInt32(textBoxPriority.Text);
            }

        private void buttonOK_Click(object sender, EventArgs e)
            {
            string strTips = "";
            double difference = 0.01;

            if (Math.Abs(m_alignmentLength - getEndDistance()) <= difference)
                {
                strTips = "\"End Distance\" longer than the selected alignment\n";
                }
            if (strTips != "")
                {
                System.Windows.Forms.MessageBox.Show(strTips, "Error");
                DialogResult = DialogResult.None;
                }
            }
        }
    }
