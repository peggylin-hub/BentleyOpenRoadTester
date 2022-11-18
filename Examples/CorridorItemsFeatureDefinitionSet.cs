/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/CorridorItemsFeatureDefinitionSet.cs $
|
|  $Copyright: (c) 2020 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.CifNET.LinearGeometry;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.GeometryModel.SDK.Edit;

namespace OpenRoadAddin
{
    class CorridorItemsFeatureDefinitionSet : DgnElementSetTool
        {
        private string m_featureDefinition = null;
        private string m_featureName = null;
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a horizontal alignment and select a feature definition.
         *                  Then the feature definition will set to the vertical alignment.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/

        private void SetFeatureDefinition(Bentley.DgnPlatformNET.Elements.Element element)
            {
            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();                
            AlignmentEdit alignmentEdit = (Alignment.CreateFromElement(con, element)) as AlignmentEdit;
            if (alignmentEdit.DomainObject == null)
                return;
            con.StartTransientMode();
            //sets feature definition and feature name
            if (m_featureDefinition != null && m_featureDefinition != string.Empty)
                {
                alignmentEdit.SetFeatureDefinition(m_featureDefinition, m_featureName);
                }
            con.PersistTransients();                
            }

        private void GetFeatureDefinition()
            {
            List<string> featureNames = new List<string>();
            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();                
            FeatureDefinitionManager fdm = FeatureDefinitionManager.Instance;
            featureNames.AddRange(fdm.GetFeatureDefinitions(con, "Alignment"));
            featureNames.Sort();
                
            //ask user for feature name and definition
            Utility.FeatureForm form = new Utility.FeatureForm(featureNames);
            form.ShowDialog();

            m_featureDefinition = form.GetFeatureDefinition();
            m_featureName = form.GetFeatureName();
            }

        protected override void OnPostInstall()
            {
            base.BeginPickElements();
            Bentley.DgnPlatformNET.AccuSnap.LocateEnabled = true;
            Bentley.DgnPlatformNET.AccuSnap.SnapEnabled = true;
            base.OnPostInstall();
            NotificationManager.OutputPrompt("Select a horizontal alignment.");
            }

        protected override bool OnDataButton(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 1);
            if (hitPath == null)
                return false;
            Bentley.DgnPlatformNET.Elements.Element selectedElement = hitPath.GetHeadElement();
            if (selectedElement != null)
                {
                GetFeatureDefinition();
                SetFeatureDefinition(selectedElement);
                NotificationManager.OutputPrompt("Command complete. Select a new horizontal alignment or right click to exit the command.");
                return true;
                }
            return false;
            }

        public static void InstallNewInstance()
            {
            CorridorItemsFeatureDefinitionSet tool = new CorridorItemsFeatureDefinitionSet();
            tool.InstallTool();
            }

        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            ExitTool();
            return true;
            }

        protected override void OnRestartTool()
            {
            InstallNewInstance();
            }

        public override StatusInt OnElementModify(Element element)
            {
            return Bentley.DgnPlatformNET.StatusInt.Error;
            }

        }
    }
