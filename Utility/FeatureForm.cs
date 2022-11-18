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
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK;
using BMW = Bentley.MstnPlatformNET.WinForms;

namespace OpenRoadAddin.Utility
    {
    public partial class FeatureForm : BMW.Adapter //Form
        {
        private string m_featureDefinition;
        private string m_featureName;
        private IEnumerable<string> m_featureTypes;
        bool selectByMouse = false;

        public FeatureForm(IEnumerable<string> types)
            {
            m_featureTypes = types;
            InitializeComponent();
            MicrostationDock();
            }

        private void MicrostationDock()
            {
            // Setup the form for MicroStation
            this.Name = "FeatureForm";
            this.Text = "Feature Form";
            // Attach the form to MicroStation
            this.AttachAsTopLevelForm(OpenRoadTester.Instance(), true);
            this.AllowTransparency = true;
            this.NETDockable = true;
            Size minSize = new Size(300, 150);
            this.ClientSize = minSize;
            }

        private void HAForm_Load(object sender, EventArgs e)
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
            }

        private void FeatureDef_SelectedIndexChanged(object sender, EventArgs e)
            {
            m_featureDefinition = FeatureDef.SelectedItem.ToString();

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            IEnumerable<Bentley.CifNET.GeometryModel.SDK.GeometricModel> geometricModels = con.GetAllGeometricModels();
            foreach (Bentley.CifNET.GeometryModel.SDK.GeometricModel gm in geometricModels)
                {
                foreach (Bentley.CifNET.GeometryModel.SDK.FeatureDefinition feature in gm.FeatureDefinitions)
                    {
                    Bentley.CifNET.ContentManagementModel.ObjectSettings obs = feature.DomainObject as Bentley.CifNET.ContentManagementModel.ObjectSettings;
                    if (obs.Name.Equals(m_featureDefinition))
                        {
                        m_featureName = obs.NamePrefix;
                        FeatureName.Text = m_featureName;
                        }
                    }
                }
            }

        private void FeatureName_TextChanged(object sender, EventArgs e)
            {
            m_featureName = FeatureName.Text;
            }

        public string GetFeatureDefinition()
            {
            return m_featureDefinition;
            }

        public string GetFeatureName()
            {
            return m_featureName;
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
