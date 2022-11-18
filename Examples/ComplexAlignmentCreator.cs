/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/ComplexAlignmentCreator.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
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
    class ComplexAlignmentCreator : DgnElementSetTool
    {
        private double UOR_TO_MASTER = GeometryHelper.ConvertUORToMeter(1.0);
        private double METER_TO_MASTER = GeometryHelper.ConvertMeterToMaster(1.0);
        List<DPoint3d> m_points = new List<DPoint3d>();

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted for two data points. A complex horizontal alignment is then created
         *                  from code that contains a start line (defined by the first two data points),
         *                  start spiral, arc, end spiral, and end line, where the direction and line lengths
         *                  are determined by the user's selected points.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateComplexAlignmentFromPoints()
        {
            List<LinearElement> linElems = new List<LinearElement>();

            double spiralRadiusAtLine = 0.0;
            double spiralRadiusAtArc = 500.0 / METER_TO_MASTER;
            double spiralLength = 100.0 / METER_TO_MASTER;

            //adjusts x and y values
            DPoint3d point1 = new DPoint3d(m_points[0]);
            point1.X *= UOR_TO_MASTER;
            point1.Y *= UOR_TO_MASTER;
            point1.Z *= UOR_TO_MASTER;
            DPoint3d point2 = new DPoint3d(m_points[1]);
            point2.X *= UOR_TO_MASTER;
            point2.Y *= UOR_TO_MASTER;
            point2.Z *= UOR_TO_MASTER;

            //creates the complex alignment with a line, spiral, arc, spiral, and line
            Line startLine = Line.Create1(point1, point2);
            Spiral startSpiral = new Spiral(point2, spiralRadiusAtLine, spiralRadiusAtArc, spiralLength, startLine.Direction, SpiralType.Clothoid, Hand.Clockwise);
            Bentley.CifNET.LinearGeometry.CircularArc arc = Bentley.CifNET.LinearGeometry.CircularArc.Create12(startSpiral.EndPoint.Coordinates, startSpiral.EndRadius, startSpiral.Direction + startSpiral.SweepAngle + System.Math.PI / 2.0, (System.Math.PI / 2.0) + (2 * startSpiral.SweepAngle), Hand.Clockwise);
            Spiral endSpiral = new Spiral(arc.EndPoint.Coordinates, arc.Radius, spiralRadiusAtLine, spiralLength, arc.StartDirection + arc.SweepAngle - System.Math.PI / 2.0, SpiralType.Clothoid, Hand.Clockwise);
            Line endLine = Line.Create2(endSpiral.EndPoint.Coordinates, endSpiral.Direction + startSpiral.SweepAngle, startLine.Length);

            linElems.Add(startLine);
            linElems.Add(startSpiral);
            linElems.Add(arc);
            linElems.Add(endSpiral);
            linElems.Add(endLine);

            LinearComplex complexAlign = LinearComplex.Create1(linElems.ToArray(), false, false, 0.001);

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            con.StartTransientMode();
            AlignmentEdit al = AlignmentEdit.CreateByLinearElement(con, complexAlign, true);
            al.AddStationing(startLine.Length / 10, 1000.0, true);
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
                NotificationManager.OutputPrompt("Select second data point.");
            }
            else if (m_points.Count == 1)
            {
                m_points.Add(ev.Point);
                CreateComplexAlignmentFromPoints();
                m_points.Clear();
                NotificationManager.OutputPrompt("Select first data point or pick element selection tool to exit command.");
            }

            return false;
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
            ComplexAlignmentCreator tool = new ComplexAlignmentCreator();
            tool.InstallTool();
        }
    }
}
