/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/ProfileForm.cs $
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
using BMW = Bentley.MstnPlatformNET.WinForms;

namespace OpenRoadAddin.Utility
    {
    public partial class ProfileForm : BMW.Adapter //Form
        {
        private bool m_clicked = false;
        private double m_num = 0.0;
        private string m_featureDefinition = null;

        public ProfileForm()
            {
            InitializeComponent();
            MicrostationDock();
            }
        public string GetFeatureDefinition()
            {
            return m_featureDefinition;
            }

        public double GetConstantElevation()
            {
            return m_num;
            }

        public bool GetClickStatus()
            {
            return m_clicked;
            }

        private void MicrostationDock()
            {
            // Setup the form for MicroStation
            this.Name = "CreateProfileCommands";
            this.Text = "Create Profile Commands";
            // Attach the form to MicroStation
            this.AttachAsTopLevelForm(OpenRoadTester.Instance(), true);
            this.AllowTransparency = true;
            this.NETDockable = true;
            Size minSize = new Size(450, 250);
            this.ClientSize = minSize;
            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (e.KeyChar != 8 && (!Char.IsDigit(e.KeyChar) && e.KeyChar != 46))
                {
                e.Handled = true;
                }
            }

        private void ProfileForm_Load(object sender, EventArgs e)
            {
            List<string> featureNames = new List<string>();
            Bentley.CifNET.GeometryModel.SDK.Edit.FeatureDefinitionManager fdm = Bentley.CifNET.GeometryModel.SDK.Edit.FeatureDefinitionManager.Instance;
            featureNames.AddRange(fdm.GetFeatureDefinitions(Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive(), "Alignment"));
            featureNames.Sort();
            Graphics graphic = this.CreateGraphics();

            float width = 140;
            foreach (string type in featureNames)
                {
                width = Math.Max(width, graphic.MeasureString(type, this.Font).Width);
                comboBox1.Items.Add(type);
                }

            width += 30;
            comboBox1.DropDownWidth = (int)width;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            }

        private void button1_Click(object sender, EventArgs e)
            {
            m_num = Convert.ToDouble(textBox1.Text);
            m_featureDefinition = comboBox1.SelectedItem.ToString();
            m_clicked = true;
            this.Close();
            }

        private void button2_Click(object sender, EventArgs e)
            {
            this.Close();
            }
        }
    }
