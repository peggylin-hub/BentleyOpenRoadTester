/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/VerticalComplexAlignmentCreator.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.CifNET.LinearGeometry;
using Bentley.GeometryNET;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.SDK.Edit;
using System;

namespace OpenRoadAddin
{
    class VerticalComplexAlignmentCreator : DgnElementSetTool
        {
        private enum CrestSagSelection
            {
            Crest = 1,
            Sag = 2,
            Crest2 = 3,
            Sag2 = 4,
            PIBase = 5,
            ReversePIBase = 6,
            }

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a horizontal alignment upon which to create a complex
         *                  vertical alignment. A complex vertical alignment is then created from code that
         *                  is made up of a entrance tangent, parabola, and exit tangent.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateComplexAlignment(Element el)
            {
            double MASTER_TO_METER = GeometryHelper.ConvertMasterToMeter(1.0);

            List<ProfileElement> profElems = new List<ProfileElement>();
            DPoint3d startPoint = new DPoint3d(100.0 * MASTER_TO_METER, 100.0 * MASTER_TO_METER);
            DPoint3d vPI_Point = new DPoint3d(600.0 * MASTER_TO_METER, 110.0 * MASTER_TO_METER);
            DPoint3d endPoint = new DPoint3d(1000.0 * MASTER_TO_METER, 105.0 * MASTER_TO_METER);
            double lengthOfVerticalCurve = 300.0 * MASTER_TO_METER;

            ProfileLine baseElement1 = new ProfileLine(startPoint, vPI_Point);
            ProfileLine baseElement2 = new ProfileLine(vPI_Point, endPoint);
            ProfileParabola[] profileCurve = null;
            ProfileElement profile = null;
            CrestSagSelection finalType = CrestSagSelection.Crest;
            if (baseElement1 as ProfileLine != null && baseElement2 as ProfileLine != null)
                {
                profileCurve = ProfileParabolaConstructor.CreateTangentParabolaTwoLinesByLength(baseElement1, baseElement2, lengthOfVerticalCurve);
                if (profileCurve.Length > 1)
                    {
                    if (profileCurve[0].KValue < 0 && (finalType == CrestSagSelection.Crest || finalType == CrestSagSelection.Crest2))
                        profile = profileCurve[0];
                    else if (profileCurve[0].KValue < 0 && (finalType == CrestSagSelection.Sag || finalType == CrestSagSelection.Sag2))
                        profile = profileCurve[1];
                    else if (profileCurve[0].KValue > 0 && (finalType == CrestSagSelection.Sag || finalType == CrestSagSelection.Sag2))
                        profile = profileCurve[0];
                    else if (profileCurve[0].KValue > 0 && (finalType == CrestSagSelection.Crest || finalType == CrestSagSelection.Crest2))
                        profile = profileCurve[1];
                    profileCurve = new ProfileParabola[0];
                    }
                }

            //create geometry objects using native objects inside Bentley.CifNET.LinearGeometry
            ProfileLine entranceTangent = new ProfileLine(startPoint, profile.StartPoint.Coordinates);
            profElems.Add(entranceTangent);

            profElems.Add(profile);

            ProfileLine exitTangent = new ProfileLine(profile.EndPoint.Coordinates, endPoint);
            profElems.Add(exitTangent);

            ProfileComplex profileComplex = new ProfileComplex(profElems.ToArray());

            //ConsensusConnectionEdit allows the persistence of civil objects to the dgn
            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
                //create SDK.Edit alignment objects from native objects
                //this AlignmentEdit is created from the one the user selected in graphics
            AlignmentEdit al = (Alignment.CreateFromElement(con, el)) as AlignmentEdit;

            con.StartTransientMode();
                //create SDK.Edit profile objects from native objects to persist into dgn
            ProfileEdit.CreateByProfileElement(con, al, profileComplex, true, true);
            con.PersistTransients();
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
            
            CreateComplexAlignment(el);
            NotificationManager.OutputPrompt("Command complete. Select a new horizontal alignment or pick element selection tool to exit command.");
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
            VerticalComplexAlignmentCreator tool = new VerticalComplexAlignmentCreator();
            tool.InstallTool();
            }
        }
    }
