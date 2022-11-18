/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/VerticalAlignmentCreator.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.CifNET.LinearGeometry;
using Bentley.GeometryNET;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.SDK.Edit;
using System;

namespace ManagedSDKExample
    {
    class VerticalAlignmentCreator : DgnElementSetTool
        {
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a horizontal alignment upon which to create a complex
         *                  vertical alignment. Then the user is prompted to place points within their chosen
         *                  alignment's profile view. As the user places points, they are temporarily linked
         *                  by a visible line. When the user right-clicks, a complex vertical alignment
         *                  is created from the points.
         * 
         * TODO: This example is in progress and currently behaves the same as the Create Parabola example. 
         * It will be completed in a future release. 
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateVerticalAlignment(Element el)
            {
            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            AlignmentEdit al = (Alignment.CreateFromElement(con, el)) as AlignmentEdit;

            DPoint3d[] points = { new DPoint3d(100, 100), new DPoint3d(600, 110), new DPoint3d(1000, 105) };
            ProfileElement element = ProfileElement.Create1(450.0, 750.0, points);
            if (element != null)
                {
                con.StartTransientMode();
                ProfileEdit edit = ProfileEdit.CreateByProfileElement(con, al, element, true, false);
                con.PersistTransients();
                }
            }

        protected override void OnPostInstall()
            {
            base.BeginPickElements();
            AccuSnap.LocateEnabled = true;
            AccuSnap.SnapEnabled = false;
            base.OnPostInstall();
            NotificationManager.OutputPrompt("Select a horizontal alignment.");
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
            if (el.ElementType != MSElementType.LineString && el.ElementType != MSElementType.ComplexString)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            Alignment al = (el.ParentElement == null) ? Alignment.CreateFromElement(con, el) : Alignment.CreateFromElement(con, el.ParentElement);
            if (al == null)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }

            cantAcceptReason = String.Empty;
            return true;
            }

        //gets alignment on click
        protected override bool OnDataButton(DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 0);
            if (hitPath == null)
                return false;

            Element el = hitPath.GetCursorElement();
            if (el == null)
                return false;

            CreateVerticalAlignment(el);
            return true;
            }

        protected override void OnRestartTool()
            {
            InstallNewInstance();
            }

        public override StatusInt OnElementModify(Element element)
            {
            return StatusInt.Error;
            }

        public static void InstallNewInstance()
            {
            VerticalAlignmentCreator tool = new VerticalAlignmentCreator();
            tool.InstallTool();
            }
        }
    }
