/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/XSCutPointForm.cs $
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
    public partial class XSCutPointForm : Form
        {
        private Corridor m_corridor;
        private double m_leftWidth;
        private double m_rightWidth;
        private double m_increment;
        private double m_startStation;
        private double m_endStation;
        bool selectByMouse = false;

        public XSCutPointForm(Corridor corInput)
            {
            m_corridor = corInput;
            InitializeComponent();
            }

        public XSCutPointForm()
            {
            InitializeComponent();
            }

        private void LeftWidthNumber_ValueChanged(object sender, EventArgs e)
            {
            m_leftWidth = (double)LeftWidthNumber.Value;
            }
        
        private void RightWidthNumber_ValueChanged(object sender, EventArgs e)
            {
            m_rightWidth = (double)RightWidthNumber.Value;
            }

        private void IncrementNumber_ValueChanged(object sender, EventArgs e)
            {
            m_increment = (double)IncrementNumber.Value;
            }

        private void StartStationNumber_ValueChanged(object sender, EventArgs e)
            {
            m_startStation = (double)StartStationNumber.Value;
            }

        private void EndStationNumber_ValueChanged(object sender, EventArgs e)
            {
            m_endStation = (double)EndStationNumber.Value;
            }

        private void XSCutPointForm_Load(object sender, EventArgs e)
            {
            if (m_corridor != null)
                {
                IncrementNumber.Maximum = (decimal)GeometryHelper.ConvertMeterToMaster(m_corridor.CorridorAlignment.LinearGeometry.Length);
                StartStationNumber.Maximum = (decimal)(GeometryHelper.ConvertMeterToMaster(m_corridor.CorridorAlignment.LinearGeometry.Length) - 1);
                EndStationNumber.Maximum = (decimal)GeometryHelper.ConvertMeterToMaster(m_corridor.CorridorAlignment.LinearGeometry.Length);
                EndStationNumber.Value = (decimal)GeometryHelper.ConvertMeterToMaster(m_corridor.CorridorAlignment.LinearGeometry.Length);
                m_startStation = (double)StartStationNumber.Value;
                m_endStation = (double)EndStationNumber.Value;
                }
            m_leftWidth = (double)LeftWidthNumber.Value;
            m_rightWidth = (double)RightWidthNumber.Value;
            m_increment = (double)IncrementNumber.Value;
            }

        public double GetLeftWidth()
            {
            return m_leftWidth;
            }

        public double GetRighttWidth()
            {
            return m_rightWidth;
            }

        public double GetIncrement()
            {
            return m_increment;
            }

        public double GetStartStation()
            {
            return m_startStation;
            }

        public double GetEndStation()
            {
            return m_endStation;
            }

        public void SetStartStationNotVisible()
            {
            StartStation.Visible = false;
            StartStationNumber.Visible = false;
            }

        public void SetEndStationNotVisible()
            {
            EndStation.Visible = false;
            EndStationNumber.Visible = false;
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
