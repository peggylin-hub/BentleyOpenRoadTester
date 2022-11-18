/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/ArcCreator.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin
{
    class ArcCreator : DgnElementSetTool
        {
        private double UOR_TO_MASTER = GeometryHelper.ConvertUORToMeter(1.0);
        List<DPoint3d> m_points = new List<DPoint3d>();

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted for three points, after which an arc is created that passes
        *                  through all the points. The first two points are linked by a temporarily drawn line.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateArcFromPoints()
            {
            if (m_points.Count < 2)
                {
                return;
                }

            //adjusts x and y values
            DPoint3d startPoint = new DPoint3d(m_points[0]);
            startPoint.X *= UOR_TO_MASTER;
            startPoint.Y *= UOR_TO_MASTER;
            startPoint.Z *= UOR_TO_MASTER;
            DPoint3d thruPoint = new DPoint3d(m_points[1]);
            thruPoint.X *= UOR_TO_MASTER;
            thruPoint.Y *= UOR_TO_MASTER;
            thruPoint.Z *= UOR_TO_MASTER;
            DPoint3d endPoint = new DPoint3d(m_points[2]);
            endPoint.X *= UOR_TO_MASTER;
            endPoint.Y *= UOR_TO_MASTER;
            endPoint.Z *= UOR_TO_MASTER;

            //creates new arc
            Bentley.CifNET.LinearGeometry.CircularArc arc = Bentley.CifNET.LinearGeometry.CircularArc.Create3(startPoint, endPoint, thruPoint);

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            con.StartTransientMode();
            AlignmentEdit al = AlignmentEdit.CreateByLinearElement(con, arc, true);
            con.PersistTransients();
            }

        protected override void OnPostInstall()
            {
            NotificationManager.OutputPrompt("Select first data point.");
            BeginDynamics();
            }
        
        //adds points on click
        protected override bool OnDataButton(DgnButtonEvent ev)
            {
            if (m_points.Count == 0)
                {
                m_points.Add(ev.Point);
                BeginDynamics();
                NotificationManager.OutputPrompt("Select second data point.");
                }
            else if (m_points.Count == 1)
                {
                m_points.Add(ev.Point);
                NotificationManager.OutputPrompt("Select third data point.");
                }
            else if (m_points.Count == 2)
                {
                m_points.Add(ev.Point);
                CreateArcFromPoints();
                EndDynamics();
                m_points.Clear();
                NotificationManager.OutputPrompt("Select first data point or pick element selection tool to exit command.");
                }
            
            return false;
            }

        //allows preview lines to be drawn
        protected override void OnDynamicFrame(DgnButtonEvent ev)
            {
            RedrawElems redraw = new RedrawElems();
            redraw.DrawMode = DgnDrawMode.TempDraw;
            redraw.DrawPurpose = DrawPurpose.Dynamics;
            redraw.SetViewport(ev.Viewport);

            if (m_points.Count > 1)
                {
                LineStringElement lse = new LineStringElement(Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel(), null, m_points.ToArray());
                redraw.DoRedraw(lse);
                }
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
            ArcCreator tool = new ArcCreator();
            tool.InstallTool();
            }
        }
    }
