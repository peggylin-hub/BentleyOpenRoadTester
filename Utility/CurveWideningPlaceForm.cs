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
using System.IO;

using Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin.Utility
    {
    public partial class CurveWideningPlaceForm : Form
        {
        private IDictionary<string, double> mCurveWideningPointsFromTemplate;
        private double m_alignmentLength;
        public CurveWideningPlaceForm(IDictionary<string, double> curveWideningPointsFromTemplate, double alignmentLength)
            {
            InitializeComponent();
            mCurveWideningPointsFromTemplate = curveWideningPointsFromTemplate;
            m_alignmentLength = alignmentLength;
            }

        private void buttonSelect_Click(object sender, EventArgs e)
            {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Please select a *.wid file";
            fileDialog.Filter = "CurveWidening File|*.wid";
            System.Windows.Forms.DialogResult result = fileDialog.ShowDialog();
            if(result == DialogResult.OK)
                {
                textBoxWideningTableFile.Text = fileDialog.FileName;
                }
            }

        private void InitCurveWideningPlaceFormData()
            {
            textBoxStartDistance.Text = "0";
            double difference = 0.01;
            textBoxEndDistance.Text = (m_alignmentLength - difference).ToString("F2");           
            //comboBoxPointName
            IDictionary<string, double> curveWideningPointsFromTemplate = (IDictionary<string, double>)mCurveWideningPointsFromTemplate;
            foreach (string key in curveWideningPointsFromTemplate.Keys)
                {
                comboBoxPointName.Items.Add(key);
                }
            comboBoxPointName.SelectedIndex = 0;

            comboBoxEnabled.Items.Add("true");
            comboBoxEnabled.Items.Add("false");
            if (comboBoxEnabled.Items.Count > 0)
                comboBoxEnabled.SelectedIndex = 0;

            //comboBoxOverlap
            comboBoxOverlap.Items.AddRange(Enum.GetNames(typeof(CurveWideningOverlap)));
            comboBoxOverlap.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOverlap.DropDownWidth = comboBoxOverlap.Width + 100;
            if (comboBoxOverlap.Items.Count > 0)
                comboBoxOverlap.SelectedIndex = 0;

            textBoxPriority.Text = "1";
            }
        private void CurveWideningPlaceForm_Load(object sender, EventArgs e)
            {
            InitCurveWideningPlaceFormData();
            }

        public double getStartDistance()
            {
            return Convert.ToDouble(textBoxStartDistance.Text);
            }
        public double getEndDistance()
            {
            return Convert.ToDouble(textBoxEndDistance.Text);
            }
        public string getPointName()
            {
            return comboBoxPointName.SelectedItem.ToString();
            }
        public bool getEnabled()
            {
            return comboBoxEnabled.SelectedIndex == 0 ? true : false;
            }
        public CurveWideningOverlap getOverlap()
            {
            return (CurveWideningOverlap)Enum.Parse(typeof(CurveWideningOverlap), comboBoxOverlap.SelectedItem.ToString());
            }
        public int getPriority()
            {
            return Convert.ToInt32(textBoxPriority.Text);
            }
        public bool getUseSpiralLengthForTransition()
            {
            return checkBoxUseSpiralLengthForTransition.Checked;
            }
        public string getWideningTableFileName()
            {
            return textBoxWideningTableFile.Text;
            }
        public string getDescription()
            {
            return textBoxDescription.Text;
            }

        private void buttonOK_Click(object sender, EventArgs e)
            {
            string strTips = "";
            
            if (m_alignmentLength - getEndDistance() < 0)
                {
                strTips = "\"End Distance\" longer than the selected alignment\n";
                }

            string wideningTableFile = getWideningTableFileName();
            if(!File.Exists(wideningTableFile))
                {
                strTips += "The Widening Table File does not exist.";
                }

            if (strTips != "")
                {
                System.Windows.Forms.MessageBox.Show(strTips, "Error");
                DialogResult = DialogResult.None;
                }
            }
        }
    }
