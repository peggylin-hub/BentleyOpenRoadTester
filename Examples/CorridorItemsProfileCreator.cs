/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2021 Bentley Systems, Incorporated. All rights reserved. $
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
using BCGMSDK = Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin
{
    class CorridorItemsProfileCreator : DgnElementSetTool
        {
        private double UOR_TO_MASTER = GeometryHelper.ConvertUORToMeter(1.0);
        private double METER_TO_MASTER = GeometryHelper.ConvertMeterToMaster(1.0);
        private double mHeigh = 0.0;
        private string mFeatureName = null;
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a horizontal alignment upon which to create a
         *                  vertical alignment. Then the user is prompted to input a constant elevation and
         *                  select a feature definition. Then a vertical alignment with feature definition
         *                  is created and activated.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/

        internal void CreateProfile(Bentley.DgnPlatformNET.Elements.Element element)
            {
            if (element == null)
                return;

            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();                
            BCGMSDK.Alignment alignment = BCGMSDK.Alignment.CreateFromElement(con, element);

            con.StartTransientMode();
            ProfileLine profileLine = new ProfileLine(DPoint3d.FromXYZ(0, mHeigh, 0), DPoint3d.FromXYZ(alignment.LinearGeometry.Length, mHeigh, 0));
            // create profile and active the profile
            BCGMSDK.Edit.ProfileEdit profile = BCGMSDK.Edit.ProfileEdit.CreateByProfileElement(con, alignment, profileLine, true, false);
            profile.SetFeatureDefinition(mFeatureName, null);

            con.PersistTransients();                
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
                Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
                BCGMSDK.Alignment alignment = BCGMSDK.Alignment.CreateFromElement(con, selectedElement);
                if (alignment == null)
                    return true;
                Utility.ProfileForm profileForm = new Utility.ProfileForm();
                profileForm.ShowDialog();
                if (profileForm.GetClickStatus())
                    {
                    mHeigh = profileForm.GetConstantElevation();
                    mHeigh *= METER_TO_MASTER;
                    mFeatureName = profileForm.GetFeatureDefinition();
                    CreateProfile(selectedElement);
                    NotificationManager.OutputPrompt("Command complete. Select a new horizontal alignment or right click to exit the command.");
                    }
                }
            return false; ;
            }

        protected override bool OnPostLocate(HitPath path, out string cantAcceptReason)
            {
            cantAcceptReason = string.Empty;
            Element element = path.GetHeadElement();

            DgnModel activeDgnModel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
            if (activeDgnModel.Is3d)
                return false;

            if (element.ElementType != MSElementType.Line && element.ElementType != MSElementType.LineString && element.ElementType != MSElementType.ComplexString)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }

            return true;
            }

        //calls command on reset (right click)
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
        public static void InstallNewInstance()
            {
            CorridorItemsProfileCreator cmd = new CorridorItemsProfileCreator();
            cmd.InstallTool();
            }
        }
    }
