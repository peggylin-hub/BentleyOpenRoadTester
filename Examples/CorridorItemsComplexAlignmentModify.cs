/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2020 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.SDK;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.LinearGeometry;

namespace ManagedSDKExample
    {
    class CorridorItemsComplexAlignmentModify : DgnElementSetTool
        {
        Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit m_con;
        private Alignment m_alignment = null;
        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted for multi data points. A complex horizontal alignment
         *                  is then created from code that contains multi straight line.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        protected override void OnPostInstall()
            {
            base.BeginPickElements();
            Bentley.DgnPlatformNET.AccuSnap.LocateEnabled = true;
            Bentley.DgnPlatformNET.AccuSnap.SnapEnabled = true;
            m_con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if (m_con == null)
                return;
            NotificationManager.OutputPrompt("Select first alignment.");
            base.OnPostInstall();
            }
        public static void InstallNewInstance()
            {
            CorridorItemsComplexAlignmentModify tool = new CorridorItemsComplexAlignmentModify();
            tool.InstallTool();
            }

        protected override bool OnDataButton(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 1);
            Bentley.DgnPlatformNET.Elements.Element selectedElement = hitPath.GetHeadElement();
            if (selectedElement != null)
                {
                m_alignment = Alignment.CreateFromElement(m_con, selectedElement);
                ModifyAlignment();
                }

            return true;
            }
        private bool ModifyAlignment()
            {
            AlignmentEdit alignmentEdit = m_alignment as AlignmentEdit;
            LinearComplex complexAlign = CreateLinearElementList();

            if (alignmentEdit == null || complexAlign == null)
                return false;

            m_con.StartTransientMode();

            alignmentEdit.SetLinearGeometry(complexAlign);

            m_con.PersistTransients();
            return true;
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

            Alignment al = Alignment.CreateFromElement(m_con, element);
            if (al == null)
                {
                cantAcceptReason = "This is not a alignment.";
                return false;
                }

            return true;
            }

        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            EndDynamics();
            ExitTool();
            return true;
            }
        protected override void OnDynamicFrame(DgnButtonEvent ev)
            {

            }
        public override StatusInt OnElementModify(Element element)
            {
            return Bentley.DgnPlatformNET.StatusInt.Error;
            }
        protected override bool WantDynamics()
            {
            return base.WantDynamics();
            }

        protected override void OnRestartTool()
            {
            InstallNewInstance();
            }
        protected override void ExitTool()
            {
            if (m_con != null)
                m_con.Dispose();

            m_alignment = null;
            base.ExitTool();
            }

        private LinearComplex CreateLinearElementList()
            {
            List<LinearElement> inputLinears = new List<LinearElement>();
            double spiralRadiusAtLine = 0.0;
            double spiralRadiusAtArc = 500.0;
            double spiralLength = 100.0;

            DPoint3d point1 = new DPoint3d(0, 0, 0);
            DPoint3d point2 = new DPoint3d(1000, 0, 0);

            Line startLine = Line.Create1(point1, point2);
            Spiral startSpiral = new Spiral(point2, spiralRadiusAtLine, spiralRadiusAtArc, spiralLength, startLine.Direction, SpiralType.Clothoid, Hand.Clockwise);
            Bentley.CifNET.LinearGeometry.CircularArc arc = Bentley.CifNET.LinearGeometry.CircularArc.Create12(startSpiral.EndPoint.Coordinates, startSpiral.EndRadius, startSpiral.Direction + startSpiral.SweepAngle + System.Math.PI / 2.0, (System.Math.PI / 2.0) + (2 * startSpiral.SweepAngle), Hand.Clockwise);
            Spiral endSpiral = new Spiral(arc.EndPoint.Coordinates, arc.Radius, spiralRadiusAtLine, spiralLength, arc.StartDirection + arc.SweepAngle - System.Math.PI / 2.0, SpiralType.Clothoid, Hand.Clockwise);
            Line endLine = Line.Create2(endSpiral.EndPoint.Coordinates, endSpiral.Direction + startSpiral.SweepAngle, startLine.Length);

            inputLinears.Add(startLine);
            inputLinears.Add(startSpiral);
            inputLinears.Add(arc);
            inputLinears.Add(endSpiral);
            inputLinears.Add(endLine);

            LinearComplex complexAlign = LinearComplex.Create1(inputLinears.ToArray(), false, false, 0.001);
            return complexAlign;
            }
        }
    }
