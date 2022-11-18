/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/CorridorItemsCorridorCreator.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.GeometryModel.SDK.Edit;

namespace ManagedSDKExample
    {
    class CorridorItemsCorridorCreator : DgnElementSetTool
        {
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a horizontal alignment. The selected alignment
         *                  must contain an active profile, otherwise the corridor can not be created successful.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/

        protected override void OnPostInstall()
            {
            base.BeginPickElements();
            AccuSnap.LocateEnabled = true;
            AccuSnap.SnapEnabled = false;
            base.OnPostInstall();
            NotificationManager.OutputPrompt("Select a horizontal alignment.");
            BeginDynamics();
            }

        protected override bool OnPostLocate(HitPath path, out string cantAcceptReason)
            {
            //checks that hitpath is not null
            if (path == null)
                {
                cantAcceptReason = "HitPath is null.";
                return false;
                }

            //checks that the cursor element is not null
            Element el = path.GetCursorElement();
            if (el == null)
                {
                cantAcceptReason = "There is no element at cursor.";
                return false;
                }

            //checks that the cursor element is a civil element
            if (el.ElementType != MSElementType.Line && el.ElementType != MSElementType.LineString && el.ElementType != MSElementType.ComplexString)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }

            Bentley.CifNET.SDK.ConsensusConnection con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if (con == null)
                {
                cantAcceptReason = "There was an error connecting to the Civil SDK model.";
                return false;
                }

            Alignment al = (el.ParentElement == null) ? Alignment.CreateFromElement(con, el) : Alignment.CreateFromElement(con, el.ParentElement);
            if (al == null)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }
                
            cantAcceptReason = String.Empty;
            return true;
            }

        public static void InstallNewInstance()
            {
            CorridorItemsCorridorCreator cmd = new CorridorItemsCorridorCreator();
            cmd.InstallTool();
            }

        protected override bool OnDataButton(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 1);
            if (hitPath == null)
                return false;

            Element element = hitPath.GetHeadElement();
            if (element == null)
                return false;

            CreateCorridor(element);
            EndDynamics();
            NotificationManager.OutputPrompt("Command complete. Select a new horizontal alignment or pick element selection tool to exit command.");
            return true;
            }

        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            InstallNewInstance();
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

        private void CreateCorridor(Element element)
            {
            if (element == null)
                return;

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            Bentley.CifNET.GeometryModel.SDK.Alignment alignment = Bentley.CifNET.GeometryModel.SDK.Alignment.CreateFromElement(con, element);
            if (alignment == null && alignment.ActiveProfile == null)
                return;

            con.StartTransientMode();
            Bentley.CifNET.GeometryModel.SDK.Edit.CorridorEdit newCorridor = Bentley.CifNET.GeometryModel.SDK.Edit.CorridorEdit.CreateByAlignment(con, "Corridor", alignment);
            con.PersistTransients();

            }
        }
    }
