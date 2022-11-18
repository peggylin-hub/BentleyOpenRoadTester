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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Bentley.GeometryNET;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using BMW = Bentley.MstnPlatformNET.WinForms;



namespace OpenRoadAddin.Utility
    {
    public partial class PointForm : BMW.Adapter        //Form
        {
        string m_featureDefinition, m_featureName;
        private IEnumerable<string> m_featureTypes;
        private PointEntity2d m_backsight, m_occupied;
        double m_angle, m_distance;
        public bool exitVar = true;
        public PointForm(PointEntity2d occupied, PointEntity2d backsight, IEnumerable<string> types)
            {
            m_backsight = backsight;
            m_occupied = occupied;
            m_featureTypes = types;
            InitializeComponent();
            textBoxAngle.Text = GeometryHelper.FormatAngle(0);
            textBoxDistance.Text = GeometryHelper.FormatDistance(0);
            }
        public DPoint3d ComputeDPoint3d()
            {
            double y, x, bx, by;
            Bentley.DgnPlatformNET.ModelInfo info = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel().GetModelInfo();
            DVector3d occupiedToBacksight = new DVector3d(m_occupied.Coordinates, m_backsight.Coordinates);
            y = Convert.ToDouble(GeometryHelper.ConvertMeterToMaster(m_distance * Math.Sin(occupiedToBacksight.AngleXY.Radians - m_angle)));
            x = Convert.ToDouble(GeometryHelper.ConvertMeterToMaster(m_distance * Math.Cos(occupiedToBacksight.AngleXY.Radians - m_angle)));

            bx = Convert.ToDouble(GeometryHelper.ConvertMeterToMaster(m_occupied.Coordinates.X / info.UorPerMeter));
            by = Convert.ToDouble(GeometryHelper.ConvertMeterToMaster(m_occupied.Coordinates.Y / info.UorPerMeter));

            DPoint3d dpoint3d = new DPoint3d(GeometryHelper.ConvertMasterToMeter(x + bx), GeometryHelper.ConvertMasterToMeter(y + by));
            return dpoint3d;
            }
        private void ButtonApply_Click(object sender, EventArgs e)
            {
            DPoint3d dpoint3d = ComputeDPoint3d();
            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();

            con.StartTransientMode();
            PointEntity2dEdit point = PointEntity2dEdit.CreateByDPoint3d(con, dpoint3d);

            if (m_featureDefinition != null && m_featureDefinition != string.Empty)
                {
                point.SetFeatureDefinition(m_featureDefinition);
                }
            point.SetDetails(textBoxDescription.Text, textBoxFeatureName.Text);
            con.PersistTransients();

            MDL.UpdateAllViews();
            DialogResult = DialogResult.None;
            }

        private void FeatureDef_SelectedIndexChanged(object sender, EventArgs e)
            {
            m_featureDefinition = comboBoxFeatureDefinition.SelectedItem.ToString();
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
                        textBoxFeatureName.Text = m_featureName;
                        }
                    }
                }
            return;
            }
        private void HAForm_Load(object sender, EventArgs e)
            {
            Graphics graphic = this.CreateGraphics();

            float width = 140;
            foreach (string type in m_featureTypes)
                {
                width = Math.Max(width, graphic.MeasureString(type, this.Font).Width);
                comboBoxFeatureDefinition.Items.Add(type);
                }

            width += 30;
            comboBoxFeatureDefinition.DropDownWidth = (int)width;
            comboBoxFeatureDefinition.DropDownStyle = ComboBoxStyle.DropDownList;

            if (comboBoxFeatureDefinition.Items.Count > 0)
                comboBoxFeatureDefinition.SelectedIndex = 0;
            return;
            }
        private void ButtonCancel_Click(object sender, EventArgs e)
            {
            exitVar = false;
            DialogResult = DialogResult.Cancel;
            }
        private void GetAngle(object sender, EventArgs e)
            {
            double angle;
            try
                {
                angle = (double)Bentley.CifNET.Formatting.FormattingProvidersManager.Instance[Bentley.CifNET.Formatting.ECAngleTypeConverter.FormatGuid].Parse(textBoxAngle.Text, 0);
                m_angle = angle;
                }
            catch
                {
                }
            textBoxAngle.Text = GeometryHelper.FormatAngle(m_angle);
            }
        private void FormatDistance(object sender, EventArgs e)
            {
            m_distance = (double)Bentley.CifNET.Formatting.FormattingProvidersManager.Instance[Bentley.CifNET.Formatting.ECDistanceTypeConverter.FormatGuid].Parse(textBoxDistance.Text, 0);
            textBoxDistance.Text = GeometryHelper.FormatDistance(m_distance);
            }
        }
    }
    
