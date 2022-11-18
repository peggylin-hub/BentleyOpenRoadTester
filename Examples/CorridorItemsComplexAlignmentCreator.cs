/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/CorridorItemsComplexAlignmentCreator.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
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

namespace ManagedSDKExample
    {
    class CorridorItemsComplexAlignmentCreator : DgnElementSetTool
        {
        private IList<DPoint3d> mInputPoints = new List<DPoint3d>();
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted for multi data points. A complex horizontal alignment
         *                  is then created from code that contains multi straight line.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        protected override void OnPostInstall()
            {
            NotificationManager.OutputPrompt("Select first data point.");
            }
        public static void InstallNewInstance()
            {
            CorridorItemsComplexAlignmentCreator tool = new CorridorItemsComplexAlignmentCreator();
            tool.InstallTool();
            }

        protected override bool OnDataButton(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            mInputPoints.Add(ev.Point);

            if (mInputPoints.Count == 0)
                {
                NotificationManager.OutputPrompt("Select second data point.");
                }
            else if (mInputPoints.Count == 1)
                {
                BeginDynamics();
                }
            else
                {
                NotificationManager.OutputPrompt("Select next data point or right click to complete the command.");
                }

            return true;
            }

        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            EndDynamics();
            CreateAlignment();
            mInputPoints.Clear();
            NotificationManager.OutputPrompt("Command complete. Select first data point or pick element selection tool to exit command.");
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

        protected override void OnDynamicFrame(DgnButtonEvent ev)
            {
            if (DynamicsStarted && mInputPoints.Count > 0)
                {
                DPoint3d stoppoint = ev.Point;
                DgnModel model = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
                var redraw = new RedrawElems();
                redraw.DrawMode = DgnDrawMode.TempDraw;
                redraw.DrawPurpose = DrawPurpose.Dynamics;
                redraw.SetDynamicsViewsFromActiveViewSet(ev.Viewport);

                Bentley.DgnPlatformNET.Elements.ComplexStringElement polyLine = new ComplexStringElement(model, null);
                for (int i = 1; i < mInputPoints.Count; i++)
                    {
                    DSegment3d seg_ = new DSegment3d(mInputPoints[i - 1], mInputPoints[i]);
                    LineElement line_ = new LineElement(model, null, seg_);
                    polyLine.AddComponentElement(line_);
                    }

                DSegment3d seg = new DSegment3d(mInputPoints[mInputPoints.Count - 1], stoppoint);
                LineElement line = new LineElement(model, null, seg);
                polyLine.AddComponentElement(line);
                polyLine.AddComponentComplete();

                redraw.DoRedraw(polyLine);
                }
            }

        protected override bool WantDynamics()
            {
            return base.WantDynamics();
            }

        private void CreateAlignment()
            {
            if (mInputPoints.Count < 2)
                {
                return;
                }

            Bentley.DgnPlatformNET.DgnModel currentmodel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
            double UPM = currentmodel.GetModelInfo().UorPerMeter;

            List<LinearElement> lines = new List<LinearElement>();
            DPoint3d startPoint = new DPoint3d(mInputPoints[0]);
            startPoint.X /= UPM;
            startPoint.Y /= UPM;
            startPoint.Z /= UPM;
            for (int i = 1; i < mInputPoints.Count; i++)
                {
                DPoint3d endPoint = new DPoint3d(mInputPoints[i]);
                endPoint.X /= UPM;
                endPoint.Y /= UPM;
                endPoint.Z /= UPM;
                Line line = Line.Create1(startPoint, endPoint);
                lines.Add(line);
                startPoint = endPoint;
                }

            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();                
            con.StartTransientMode();
            BCGMSDK.Edit.AlignmentEdit alignmentEdit = BCGMSDK.Edit.AlignmentEdit.CreateByLinearElements(con, lines);
            con.PersistTransients();
            }
        }

    }
