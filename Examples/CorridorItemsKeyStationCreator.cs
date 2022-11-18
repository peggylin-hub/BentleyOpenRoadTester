/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
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

namespace ManagedSDKExample
    {

    class CorridorItemsKeyStationCreator : DgnElementSetTool
        {
        private Bentley.CifNET.GeometryModel.SDK.Edit.CorridorEdit m_corridor;
        private LinearElement m_corridorAlignmentCurve;
        private double m_distanceAlong;
        private string m_commandParams;
        private CommandState m_currentCommandState = CommandState.StartOfCommand;

        private static uint m_color = 6;
        private static double m_crossLineLength = 200;

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to select a corridor. 
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        protected override void OnPostInstall()
            {
            base.BeginPickElements();
            AccuSnap.LocateEnabled = true;
            AccuSnap.SnapEnabled = false;
            base.OnPostInstall();
            NotificationManager.OutputPrompt("Select a corridor.");
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

            Bentley.CifNET.GeometryModel.SDK.Corridor tempCorridor = null;
            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            tempCorridor = Bentley.CifNET.GeometryModel.SDK.Corridor.CreateFromElement(con, el);

            if (tempCorridor == null)
                {
                cantAcceptReason = "This is not a corridor element.";
                return false;
                }

            cantAcceptReason = String.Empty;
            return true;
            }
        enum CommandState
            {
            StartOfCommand = 0,
            LocalCorridor = 1,
            GetDistanceAlong = 2,
            EndOfCommand = 3
            };

        private void MoveToNextState()
            {
            CommandState currentState = m_currentCommandState;
            CommandState nextState = CommandState.EndOfCommand;
            if (currentState < CommandState.EndOfCommand)
                {
                nextState = (CommandState)(((int)currentState) + 1);
                }

            m_currentCommandState = nextState;
            StartNextState(nextState);

            if (m_currentCommandState == CommandState.EndOfCommand)
                {
                bool bret = CreateKeyStation();
                if (bret)
                    {
                    OnRestartTool();
                    }
                else
                    {
                    ExitTool();
                    }
                }
            }

        private void StartNextState(CommandState nextState)
            {
            switch (nextState)
                {
                case CommandState.LocalCorridor:
                    break;
                case CommandState.GetDistanceAlong:
                        {
                        NotificationManager.OutputPrompt("Please input keyStation distance along: ");
                        BeginDynamics();
                        }
                    break;
                }
            }

        protected override void OnDynamicFrame(DgnButtonEvent ev)
            {
            //base.OnDynamicFrame(ev);
            if (!(m_currentCommandState == CommandState.GetDistanceAlong))
                {
                return;
                }

            Bentley.GeometryNET.DPoint3d point = ev.Point;

            Bentley.DgnPlatformNET.DgnModel currentmodel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
            double UPM = currentmodel.GetModelInfo().UorPerMeter;

            point.X /= UPM;
            point.Y /= UPM;
            point.Z /= UPM;

            LinearPoint linePoint = m_corridorAlignmentCurve.ProjectPointOnPerpendicular(point);
            double parameter = linePoint.Parameter;
            double distAlong = linePoint.DistanceAlong;
            distAlong = m_corridorAlignmentCurve.GetDistanceFromParameter(parameter);
            var linePoint1 = m_corridorAlignmentCurve.GetPointAtDistanceOffset(distAlong, m_crossLineLength);
            var linePoint2 = m_corridorAlignmentCurve.GetPointAtDistanceOffset(distAlong, -m_crossLineLength);


            DPoint3d point1 = linePoint1.Coordinates;
            DPoint3d point2 = linePoint2.Coordinates;

            point1.X *= UPM;
            point1.Y *= UPM;
            point1.Z *= UPM;

            point2.X *= UPM;
            point2.Y *= UPM;
            point2.Z *= UPM;

            DPoint3d[] points = new DPoint3d[] { point1, point2 };
            LineStringElement element = new LineStringElement(currentmodel, null, points);

            ElementPropertiesSetter proSetter = new ElementPropertiesSetter();

            proSetter.SetColor(m_color);
            proSetter.Apply(element);

            RedrawElems redrawElems = new RedrawElems();
            redrawElems.SetDynamicsViewsFromActiveViewSet(Bentley.MstnPlatformNET.Session.GetActiveViewport());
            redrawElems.DrawMode = DgnDrawMode.TempDraw;
            redrawElems.DrawPurpose = DrawPurpose.Dynamics;
            redrawElems.DoRedraw(element);

            }

        private bool DoCurrentState(CommandState currentState, Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            bool bRent = false;
            switch (currentState)
                {
                case CommandState.LocalCorridor:
                    bRent = DoLocalCorridor(ev);
                    break;
                case CommandState.GetDistanceAlong:
                    bRent = DoGetDistance(ev);
                    break;
                }
            if (bRent)
                {
                MoveToNextState();
                }
            return bRent;
            }

        private double GetDistanceAtPoint(Bentley.GeometryNET.DPoint3d point)
            {
            Bentley.DgnPlatformNET.DgnModel currentmodel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
            double UPM = currentmodel.GetModelInfo().UorPerMeter;

            point.X /= UPM;
            point.Y /= UPM;
            point.Z /= UPM;


            LinearPoint linePoint = m_corridorAlignmentCurve.ProjectPointOnPerpendicular(point);

            double parameter = linePoint.Parameter;
            double distAlong = linePoint.DistanceAlong;
            distAlong = m_corridorAlignmentCurve.GetDistanceFromParameter(parameter);
            return distAlong;
            }
        private bool DoGetDistance(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            m_distanceAlong = GetDistanceAtPoint(ev.Point);
            return true;
            }

        private bool DoLocalCorridor(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 1);
            if (hitPath == null)
                {
                return false;
                }
            Bentley.DgnPlatformNET.Elements.Element selectedElement = hitPath.GetHeadElement();
            if (selectedElement == null)
                {
                return false;
                }
            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            var tempCorridor = Bentley.CifNET.GeometryModel.SDK.Corridor.CreateFromElement(con, selectedElement);
            m_corridor = tempCorridor as Bentley.CifNET.GeometryModel.SDK.Edit.CorridorEdit;

            if (null == m_corridor)
                {
                return false;
                }
            m_corridorAlignmentCurve = m_corridor.CorridorAlignment.LinearGeometry;
            if (m_corridorAlignmentCurve == null)
                {
                return false;
                }
            return true;
            }
        public static void InstallNewInstance(string unparsed)
            {
            CorridorItemsKeyStationCreator cmd = new CorridorItemsKeyStationCreator(unparsed);
            cmd.InstallTool();
            NotificationManager.OutputPrompt("Please select a corriodr. ");
            }

        public CorridorItemsKeyStationCreator(string unparsed) : base()
            {
            m_commandParams = unparsed;
            }
        protected override bool OnDataButton(Bentley.DgnPlatformNET.DgnButtonEvent ev)
            {
            bool bRent = DoCurrentState(m_currentCommandState, ev);

            return bRent;
            }
        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            ExitTool();
            return true;
            }

        protected override bool OnInstall()
            {
            m_currentCommandState = CommandState.StartOfCommand;
            MoveToNextState();
            return base.OnInstall();
            }

        protected override void ExitTool()
            {
            base.ExitTool();
            }
        protected override void OnRestartTool()
            {
            InstallNewInstance(m_commandParams);
            }

        public override StatusInt OnElementModify(Element element)
            {
            return Bentley.DgnPlatformNET.StatusInt.Error;
            }

        private bool CreateKeyStation()
            {

            Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = m_corridor.Connection as Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit;
            if(null == con)
                {
                return false;
                }

            con.StartTransientMode();

            var newKeyStation = m_corridor.AddKeyStation(m_distanceAlong);

            con.PersistTransients();

            return newKeyStation != null;
            }
        }

    }
