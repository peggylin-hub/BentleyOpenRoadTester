/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/PIAlignmentCreator.cs $
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
using System.Windows.Forms;

namespace OpenRoadAddin
{
    class PIAlignmentCreator : DgnElementSetTool
        {
        private double UOR_TO_METER = GeometryHelper.ConvertUORToMeter(1.0);
        private double MASTER_TO_METER = GeometryHelper.ConvertMasterToMeter(1.0);
        List<HorizontalPI> m_horizontalPI = new List<HorizontalPI>();
        string m_featureDef;

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is prompted to place data points. As the user places points, they are temporarily
         *                  linked by a visible line, and from the second point onward, the user is prompted
         *                  for the arc radius, feature definition, and start and end spiral lengths for the next
         *                  angle. When the user right-clicks, a complex horizontal alignment is created
         *                  from the points where a curve set composed of spirals and arcs is created at each PI.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreatePIAlignmentFromPoints()
            {
            List<LinearElement> linElems = new List<LinearElement>();

            //adjusts x and y values
            for (int i = 0; i < m_horizontalPI.Count; i++)
                {
                m_horizontalPI[i].Coordinate.X *= UOR_TO_METER;
                m_horizontalPI[i].Coordinate.Y *= UOR_TO_METER;
                m_horizontalPI[i].Coordinate.Z *= UOR_TO_METER;
                m_horizontalPI[i].Radius *= MASTER_TO_METER;
                }

            if (m_horizontalPI.Count <= 1)
                return;
            else if (m_horizontalPI.Count == 2)
                {
                linElems.Add(Line.Create1(m_horizontalPI[0].Coordinate, m_horizontalPI[1].Coordinate));
                }
            else
                {
                for (int i = 0; i < m_horizontalPI.Count - 2; i++)
                    {
                    List<LinearElement> tempLinElems = GeometryHelper.GetArcBetweenTwoElements(m_horizontalPI[i].Coordinate, m_horizontalPI[i + 1].Coordinate, m_horizontalPI[i + 1].Coordinate, m_horizontalPI[i + 2].Coordinate, m_horizontalPI[i + 1].Radius);
                    if (tempLinElems.Count > 0)
                        linElems.AddRange(tempLinElems);
                    else
                        {
                        MessageBox.Show("At least one tangent is too short for its given radius. Try again.");
                        return;
                        }
                    }
                }

            //create geometry objects using native objects inside Bentley.CifNET.LinearGeometry
            LinearComplex complexAlign = LinearComplex.Create1(linElems.ToArray(), false, false, 0.001);

            //ConsensusConnectionEdit allows the persistence of civil objects to the DGN file
            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
                //begins mode to persist objects
            con.StartTransientMode();
                //create SDK.Edit alignment objects from native objects
            AlignmentEdit al = AlignmentEdit.CreateByLinearElement(con, complexAlign, true);
                //persists objects created in persist mode
            con.PersistTransients();

                //sets feature definition
                if (m_featureDef != null && m_featureDef != string.Empty)
                    {
                    al.SetFeatureDefinition(m_featureDef);
                    }

            }
 
        private DPoint3d GetMidPoint(DPoint3d pt1, DPoint3d pt2)
            {
            DPoint3d newPt = new DPoint3d();
            newPt.X = (pt1.X + pt2.X) / 2;
            newPt.Y = (pt1.Y + pt2.Y) / 2;
            return newPt;
            }

        protected override void OnPostInstall()
            {
            NotificationManager.OutputPrompt("Select first data point.");
            BeginDynamics();
            }

        //adds points on click
        protected override bool OnDataButton(DgnButtonEvent ev)
            {
            if (m_horizontalPI.Count == 0)
                {
                m_horizontalPI.Add(new HorizontalPI { Coordinate = ev.Point });
                BeginDynamics();
                NotificationManager.OutputPrompt("Select next data point or right click to complete the command.");
                }
            else if (m_horizontalPI.Count > 0)
                {
                FeatureDefinitionManager fdm = FeatureDefinitionManager.Instance;
                ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
                IEnumerable<string> FeatureNames = fdm.GetFeatureDefinitions(con, "Alignment");

                //ask user for spiral lengths and curve radius
                Utility.PIForm form = new Utility.PIForm(FeatureNames);
                form.ShowDialog();

                m_horizontalPI.Add(new HorizontalPI { Coordinate = ev.Point, Radius = form.GetCurveRadius() });
                m_featureDef = form.GetFeatureDefinition();
                }

            return false;
            }

        //calls command on reset (right click)
        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            CreatePIAlignmentFromPoints();
            EndDynamics();
            m_horizontalPI.Clear();
            NotificationManager.OutputPrompt("Command complete. Select first data point or pick element selection tool to exit command.");
            return false;
            }

        //allows preview lines to be drawn
        protected override void OnDynamicFrame(DgnButtonEvent ev)
            {
            RedrawElems redraw = new RedrawElems();
            redraw.DrawMode = DgnDrawMode.TempDraw;
            redraw.DrawPurpose = DrawPurpose.Dynamics;
            redraw.SetViewport(ev.Viewport);

            if (m_horizontalPI.Count > 1)
                {
                List<DPoint3d> points = new List<DPoint3d>();
                foreach (HorizontalPI hpi in m_horizontalPI)
                    points.Add(hpi.Coordinate);

                LineStringElement lse = new LineStringElement(Session.Instance.GetActiveDgnModel(), null, points.ToArray());
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
            PIAlignmentCreator tool = new PIAlignmentCreator();
            tool.InstallTool();
            }
        }
    }
