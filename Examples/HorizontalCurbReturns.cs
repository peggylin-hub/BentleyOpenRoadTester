/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/HorizontalCurbReturns.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.CifNET.LinearGeometry;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.SDK.Edit;

namespace OpenRoadAddin
{
    class HorizontalCurbReturns : DgnElementSetTool
        {
        List<DPoint3d> m_points = new List<DPoint3d>();               

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to place 4 data points, representing 2 lines that cross. 
         *                  The lines are offset by a specified radius to create the center of an arc.
         *                  The program creates an arc from the given radius and returns the beginning of
         *                  the first line, the arc, and then the end of the second line.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateLinesFromPoints()
            {
            //setup
            double UORS_TO_METER = GeometryHelper.ConvertUORToMeter(1.0);
            double MASTER_TO_METER = GeometryHelper.ConvertMasterToMeter(1.0);

            //converting the point coordinates to meters
            DPoint3d firstTangentStartPoint = m_points[0];
            firstTangentStartPoint.X *= UORS_TO_METER;
            firstTangentStartPoint.Y *= UORS_TO_METER;
            firstTangentStartPoint.Z *= UORS_TO_METER;
            DPoint3d firstTangentEndPoint = m_points[1];
            firstTangentEndPoint.X *= UORS_TO_METER;
            firstTangentEndPoint.Y *= UORS_TO_METER;
            firstTangentEndPoint.Z *= UORS_TO_METER;
            DPoint3d lastTangentStartPoint = m_points[2];
            lastTangentStartPoint.X *= UORS_TO_METER;
            lastTangentStartPoint.Y *= UORS_TO_METER;
            lastTangentStartPoint.Z *= UORS_TO_METER;
            DPoint3d lastTangentEndPoint = m_points[3];
            lastTangentEndPoint.X *= UORS_TO_METER;
            lastTangentEndPoint.Y *= UORS_TO_METER;
            lastTangentEndPoint.Z *= UORS_TO_METER;

            double radius = 200 * MASTER_TO_METER;

            //uses the input points and radius to get a list of elements consisting of a starting tangent line, arc, and ending tangent line
            List<LinearElement> linElems = GeometryHelper.GetArcBetweenTwoElements(firstTangentStartPoint, firstTangentEndPoint, lastTangentStartPoint, lastTangentEndPoint, radius);

            if (linElems.Count > 0)
                {
                ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
                //adds elements to alignment to display
                LinearComplex complexAlign = LinearComplex.Create1(linElems.ToArray(), false, false, 0.001);
                con.StartTransientMode();
                AlignmentEdit al = AlignmentEdit.CreateByLinearElement(con, complexAlign, true);
                con.PersistTransients();
                }
            else
                System.Windows.Forms.MessageBox.Show("One or both of the tangents are too short for the given radius. Try again.");
                
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
                BeginDynamics();
                }

            m_points.Add(ev.Point);
            if (m_points.Count == 4)
                {
                    CreateLinesFromPoints();
                    EndDynamics();
                    m_points.Clear();
                    NotificationManager.OutputPrompt("Command complete. Select first data point or pick element selection tool to exit command.");
                }
            else
                {
                NotificationManager.OutputPrompt("Select next data point or right click to cancel the command.");
                }
            return true;
            }

        //terminates command (right click)
        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            EndDynamics();
            m_points.Clear();
            NotificationManager.OutputPrompt("Command terminated. Select first data point or pick element selection tool to exit command.");
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
                LineStringElement lse = new LineStringElement(Session.Instance.GetActiveDgnModel(), null, m_points.GetRange(0, 2).ToArray());
                redraw.DoRedraw(lse);
                if(m_points.Count > 3)
                    {
                    LineStringElement lse2 = new LineStringElement(Session.Instance.GetActiveDgnModel(), null, m_points.GetRange(2, 2).ToArray());
                    redraw.DoRedraw(lse2);
                    }
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
            HorizontalCurbReturns tool = new HorizontalCurbReturns();
            tool.InstallTool();
            }
        }

    
    }
