/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
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
using Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin.Utility
    {
    public partial class PIForm : Form
        {
        private double m_curveRadius;
        private string m_featureDefinition;
        private IEnumerable<string> m_featureTypes;
        bool selectByMouse = false;

        public PIForm(IEnumerable<string> types)
            {
            m_featureTypes = types;
            InitializeComponent();
            }

        private void PIForm_Load(object sender, EventArgs e)
            {
            Graphics graphic = this.CreateGraphics();
            m_curveRadius = (double)CurveRadius.Value;

            float width = 140;
            foreach(string type in m_featureTypes)
                {
                width = Math.Max(width, graphic.MeasureString(type, this.Font).Width);
                FeatureDef.Items.Add(type);
                }

            width += 30;
            FeatureDef.DropDownWidth = (int)width;
            FeatureDef.DropDownStyle = ComboBoxStyle.DropDownList;

            if (FeatureDef.Items.Count > 0)
                FeatureDef.SelectedIndex = 0;
            }
        
        private void CurveRadius_ValueChanged(object sender, EventArgs e)
            {
            m_curveRadius = (double)CurveRadius.Value;
            }

        private void FeatureDef_SelectedIndexChanged(object sender, EventArgs e)
            {
            m_featureDefinition = (string)FeatureDef.SelectedItem;
            }
        
        public double GetCurveRadius()
            {
            return m_curveRadius;
            }
        
        public string GetFeatureDefinition()
            {
            return m_featureDefinition;
            }

        private void quickBoxs_Enter(object sender, EventArgs e)
            {
            NumericUpDown curBox = sender as NumericUpDown;
            curBox.Select();
            curBox.Select(0, curBox.Text.Length);
            if (MouseButtons == MouseButtons.Left)
                {
                selectByMouse = true;
                }
            }

        private void quickBoxs_MouseDown(object sender, MouseEventArgs e)
            {
            NumericUpDown curBox = sender as NumericUpDown;
            if (selectByMouse)
                {
                curBox.Select(0, curBox.Text.Length);
                selectByMouse = false;
                }
            }
        }
    }
