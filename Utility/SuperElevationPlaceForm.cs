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

using Bentley.CifNET.GeometryModel.SDK.Edit;

namespace OpenRoadAddin.Utility
    {
    public partial class SuperElevationPlaceForm : Form
        {
        private IEnumerable<string> m_featureTypes;
        private double m_alignmentLength;
        public SuperElevationPlaceForm(IEnumerable<string> types, double alignmentLength)
            {            
            InitializeComponent();
            m_featureTypes = types;
            m_alignmentLength = alignmentLength;
            }

        private void InitSuperElevationPlaceFormData()
            {
            textBoxSectionName.Text = "Section1";
            textBoxStartDistance.Text = "0";
            double difference = 0.01;
            textBoxEndDistance.Text = (m_alignmentLength- difference).ToString("F2");

            comboBoxSuperElevationType.Items.AddRange(Enum.GetNames(typeof(SuperElevationType)));
            comboBoxSuperElevationType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxSuperElevationType.Items.Count > 0)
                comboBoxSuperElevationType.SelectedIndex = 0;

            comboBoxSide.Items.AddRange(Enum.GetNames(typeof(Side)));
            comboBoxSide.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxSide.Items.Count > 0)
                comboBoxSide.SelectedIndex = 0;

            textBoxLaneName.Text = "Lane1";
            textBoxInsideEdgeOffset.Text = "2.0";
            textBoxWidth.Text = "3.5";
            textBoxSlope.Text = "0.02";
            textBoxLaneStartDistance.Text = "0";
            textBoxLaneEndDistance.Text = (m_alignmentLength - difference).ToString("F2"); 

            textBoxT1Distance.Text = "100";
            if(m_alignmentLength < 100)
                {
                textBoxT1Distance.Text = (m_alignmentLength - difference).ToString("F2");
                }
            textBoxT1Slope.Text = "0.04";
            
            comboBoxT1PivotEdgeType.Items.AddRange(Enum.GetNames(typeof(PivotEdgeType)));
            comboBoxT1PivotEdgeType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT1PivotEdgeType.Items.Count > 0)
                comboBoxT1PivotEdgeType.SelectedIndex = 0;

            comboBoxT1TransitionType.Items.AddRange(Enum.GetNames(typeof(SuperElevationTransitionType)));
            comboBoxT1TransitionType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxT1TransitionType.DropDownWidth = comboBoxT1TransitionType.Width + 70;
            if (comboBoxT1TransitionType.Items.Count > 0)
                comboBoxT1TransitionType.SelectedIndex = 0;

            comboBoxT1SuperPointType.Items.AddRange(Enum.GetNames(typeof(RDSuperPointType)));
            comboBoxT1SuperPointType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT1SuperPointType.Items.Count > 0)
                comboBoxT1SuperPointType.SelectedIndex = 0;

            textBoxT1NonLinearCurveLength.Text = "0";


            textBoxT2Distance.Text = "400";
            if (m_alignmentLength < 400)
                {
                textBoxT2Distance.Text = (m_alignmentLength - difference).ToString("F2");
                }
            textBoxT2Slope.Text = "0.06";

            comboBoxT2PivotEdgeType.Items.AddRange(Enum.GetNames(typeof(PivotEdgeType)));
            comboBoxT2PivotEdgeType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT2PivotEdgeType.Items.Count > 0)
                comboBoxT2PivotEdgeType.SelectedIndex = 0;

            comboBoxT2TransitionType.Items.AddRange(Enum.GetNames(typeof(SuperElevationTransitionType)));
            comboBoxT2TransitionType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxT2TransitionType.DropDownWidth = comboBoxT2TransitionType.Width + 70;
            if (comboBoxT2TransitionType.Items.Count > 0)
                comboBoxT2TransitionType.SelectedIndex = 0;

            comboBoxT2SuperPointType.Items.AddRange(Enum.GetNames(typeof(RDSuperPointType)));
            comboBoxT2SuperPointType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT2SuperPointType.Items.Count > 0)
                comboBoxT2SuperPointType.SelectedIndex = 0;

            textBoxT2NonLinearCurveLength.Text = "0";

            textBoxT3Distance.Text = "600";
            if (m_alignmentLength < 600)
                {
                textBoxT3Distance.Text = (m_alignmentLength - difference).ToString("F2");
                }
            textBoxT3Slope.Text = "0.08";

            comboBoxT3PivotEdgeType.Items.AddRange(Enum.GetNames(typeof(PivotEdgeType)));
            comboBoxT3PivotEdgeType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT3PivotEdgeType.Items.Count > 0)
                comboBoxT3PivotEdgeType.SelectedIndex = 0;

            comboBoxT3TransitionType.Items.AddRange(Enum.GetNames(typeof(SuperElevationTransitionType)));
            comboBoxT3TransitionType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxT3TransitionType.DropDownWidth = comboBoxT3TransitionType.Width + 70;
            if (comboBoxT3TransitionType.Items.Count > 0)
                comboBoxT3TransitionType.SelectedIndex = 0;

            comboBoxT3SuperPointType.Items.AddRange(Enum.GetNames(typeof(RDSuperPointType)));
            comboBoxT3SuperPointType.DropDownStyle = ComboBoxStyle.DropDownList;
            if (comboBoxT3SuperPointType.Items.Count > 0)
                comboBoxT3SuperPointType.SelectedIndex = 0;

            textBoxT3NonLinearCurveLength.Text = "0";

            }
        private void SuperElevationPlaceForm_Load(object sender, EventArgs e)
            {
            Graphics graphic = this.CreateGraphics();

            float width = 140;
            foreach (string type in m_featureTypes)
                {
                width = Math.Max(width, graphic.MeasureString(type, this.Font).Width);
                FeatureDef.Items.Add(type);
                }

            width += 30;
            FeatureDef.DropDownWidth = (int)width;
            FeatureDef.DropDownStyle = ComboBoxStyle.DropDownList;

            if (FeatureDef.Items.Count > 0)
                FeatureDef.SelectedIndex = 0;

            InitSuperElevationPlaceFormData();
            }

        private void buttonOK_Click(object sender, EventArgs e)
            {
            string strTips = "";
            double difference = 0.01;

            if (Math.Abs(m_alignmentLength - getEndDistance() ) <= difference)
                {
                strTips = "\"Section End Distance\" longer than the selected alignment\n";
                }

            if (Math.Abs(m_alignmentLength - getLaneEndDistance()) <= difference)
                {
                strTips += "\"Lane End Distance\" longer than the selected alignment\n";
                }
            if (Math.Abs(m_alignmentLength - getT1Distance()) <= difference)
                {
                strTips += "\"Transition1 Distance\" longer than the selected alignment\n";
                }
            if (Math.Abs(m_alignmentLength - getT2Distance()) <= difference)
                {
                strTips += "\"Transition2 Distance\" longer than the selected alignment\n";
                }
            if (Math.Abs(m_alignmentLength - getT3Distance()) <= difference)
                {
                strTips += "\"Transition3 Distance\" longer than the selected alignment\n";
                }
            if(strTips != "")
                {
                System.Windows.Forms.MessageBox.Show(strTips, "Error");
                DialogResult = DialogResult.None;
                }

            }

        private void buttonCancel_Click(object sender, EventArgs e)
            {

            }

        public string getSectionName()
            {
            return textBoxSectionName.Text;
            }
        public string getFeatureType()
            {
            return FeatureDef.SelectedText;
            }

        public double getStartDistance()
            {
            return Convert.ToDouble(textBoxStartDistance.Text);
            }

        public double getEndDistance()
            {
            return Convert.ToDouble(textBoxEndDistance.Text);
            }

        public SuperElevationType getSuperElevationType()
            {
            return (SuperElevationType)Enum.Parse(typeof(SuperElevationType), comboBoxSuperElevationType.SelectedItem.ToString());
           
            }

        public Side getSuperElevationSide()
            {
            return (Side)Enum.Parse(typeof(Side), comboBoxSide.SelectedItem.ToString());

            }

        public string getLaneName()
            {
            return textBoxLaneName.Text;
            }

        public double getInsideEdgeOffset()
            {
            return Convert.ToDouble(textBoxInsideEdgeOffset.Text);
            }

        public double getWidth()
            {
            return Convert.ToDouble(textBoxWidth.Text);
            }


        public double getSlope()
            {
            return Convert.ToDouble(textBoxSlope.Text);
            }

        public double getLaneStartDistance()
            {
            return Convert.ToDouble(textBoxLaneStartDistance.Text);
            }

        public double getLaneEndDistance()
            {
            return Convert.ToDouble(textBoxLaneEndDistance.Text);
            }

        public double getT1Distance()
            {
            return Convert.ToDouble(textBoxT1Distance.Text);
            }

        public double getT1Slope()
            {
            return Convert.ToDouble(textBoxT1Slope.Text);
            }

        public PivotEdgeType getT1PivotEdgeType()
            {
            return (PivotEdgeType)Enum.Parse(typeof(PivotEdgeType), comboBoxT1PivotEdgeType.SelectedItem.ToString());

            }

        public SuperElevationTransitionType getT1TransitionType()
            {
            return (SuperElevationTransitionType)Enum.Parse(typeof(SuperElevationTransitionType), comboBoxT1TransitionType.SelectedItem.ToString());

            }

        public RDSuperPointType getT1SuperPointType()
            {
            return (RDSuperPointType)Enum.Parse(typeof(RDSuperPointType), comboBoxT1SuperPointType.SelectedItem.ToString());

            }

        public double getT1NonLinearCurveLength()
            {
            return Convert.ToDouble(textBoxT1NonLinearCurveLength.Text);
            }

        public double getT2Distance()
            {
            return Convert.ToDouble(textBoxT2Distance.Text);
            }

        public double getT2Slope()
            {
            return Convert.ToDouble(textBoxT2Slope.Text);
            }

        public PivotEdgeType getT2PivotEdgeType()
            {
            return (PivotEdgeType)Enum.Parse(typeof(PivotEdgeType), comboBoxT2PivotEdgeType.SelectedItem.ToString());

            }

        public SuperElevationTransitionType getT2TransitionType()
            {
            return (SuperElevationTransitionType)Enum.Parse(typeof(SuperElevationTransitionType), comboBoxT2TransitionType.SelectedItem.ToString());

            }

        public RDSuperPointType getT2SuperPointType()
            {
            return (RDSuperPointType)Enum.Parse(typeof(RDSuperPointType), comboBoxT2SuperPointType.SelectedItem.ToString());

            }

        public double getT2NonLinearCurveLength()
            {
            return Convert.ToDouble(textBoxT2NonLinearCurveLength.Text);
            }

        public double getT3Distance()
            {
            return Convert.ToDouble(textBoxT3Distance.Text);
            }

        public double getT3Slope()
            {
            return Convert.ToDouble(textBoxT3Slope.Text);
            }

        public PivotEdgeType getT3PivotEdgeType()
            {
            return (PivotEdgeType)Enum.Parse(typeof(PivotEdgeType), comboBoxT3PivotEdgeType.SelectedItem.ToString());

            }

        public SuperElevationTransitionType getT3TransitionType()
            {
            return (SuperElevationTransitionType)Enum.Parse(typeof(SuperElevationTransitionType), comboBoxT3TransitionType.SelectedItem.ToString());

            }

        public RDSuperPointType getT3SuperPointType()
            {
            return (RDSuperPointType)Enum.Parse(typeof(RDSuperPointType), comboBoxT3SuperPointType.SelectedItem.ToString());

            }

        public double getT3NonLinearCurveLength()
            {
            return Convert.ToDouble(textBoxT3NonLinearCurveLength.Text);
            }

        }
    }
