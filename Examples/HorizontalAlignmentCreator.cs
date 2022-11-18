/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/HorizontalAlignmentCreator.cs $
|
|  $Copyright: (c) 2020 Bentley Systems, Incorporated. All rights reserved. $
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
using Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin
{
    class HorizontalAlignmentCreator : DgnElementSetTool
        {
        private double UOR_TO_MASTER = GeometryHelper.ConvertUORToMeter(1.0);
        private bool ACTIVE_FEATURE_DEFINITIONS_ONLY = false;
        List<DPoint3d> m_points = new List<DPoint3d>();
        string m_featureDef;
        string m_featureName;

        /*----------------------------------------------------------------------------------------------**/
        /* Write Function | The user is first prompted to select a feature definition and name it. The user
         *                  is then prompted to place data points. As the user places points, they are temporarily
         *                  linked by a visible line. When the user right-clicks, a complex horizontal alignment
         *                  is created from the points.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
        internal void CreateAlignmentFromPoints()
            {
            List<LinearElement> lines = new List<LinearElement>();

            if (m_points.Count < 2)
                {
                return;
                }

            //adjusts x and y values
            DPoint3d startPoint = new DPoint3d(m_points[0]);
            startPoint.X *= UOR_TO_MASTER;
            startPoint.Y *= UOR_TO_MASTER;
            startPoint.Z *= UOR_TO_MASTER;
            for (int i = 1; i < m_points.Count; i++)
                {
                DPoint3d endPoint = new DPoint3d(m_points[i]);
                endPoint.X *= UOR_TO_MASTER;
                endPoint.Y *= UOR_TO_MASTER;
                endPoint.Z *= UOR_TO_MASTER;

                //creates a line between each consectutive pair of points
                Line line = Line.Create1(startPoint, endPoint);
                lines.Add(line);
                startPoint = endPoint;
                }

            LinearComplex complexAlign = LinearComplex.Create1(lines.ToArray(), false, false, 0.001);

            ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
            con.StartTransientMode();
            AlignmentEdit al = AlignmentEdit.CreateByLinearElement(con, complexAlign, true);
            con.PersistTransients();

            //sets feature definition and feature name
            if ( m_featureName != null && m_featureName != string.Empty && m_featureDef != null && m_featureDef != string.Empty )
                {
                al.SetFeatureDefinition(m_featureDef, m_featureName);
                }
            else if (m_featureDef != null && m_featureDef != string.Empty)
                {
                al.SetFeatureDefinition(m_featureDef);
                }
            }

        private void GetFeatureDefinition()
            {
            List<string> featureNames = new List<string>();

            if (ACTIVE_FEATURE_DEFINITIONS_ONLY)
                {
                ConsensusConnectionEdit con = ConsensusConnectionEdit.GetActive();
                    {
                    IEnumerable<Bentley.CifNET.GeometryModel.SDK.GeometricModel> geometricModels = con.GetAllGeometricModels();
                    foreach (Bentley.CifNET.GeometryModel.SDK.GeometricModel gm in geometricModels)
                        {
                        foreach (Bentley.CifNET.GeometryModel.SDK.FeatureDefinition feature in gm.FeatureDefinitions)
                            {
                            Bentley.CifNET.ContentManagementModel.ObjectSettings obs = feature.DomainObject as Bentley.CifNET.ContentManagementModel.ObjectSettings;
                            if (obs.Name.Contains("Alignment"))
                                featureNames.Add(obs.Name);
                            }
                        }
                    }
                }
            else
                {
                FeatureDefinitionManager fdm = FeatureDefinitionManager.Instance;
                featureNames.AddRange(fdm.GetFeatureDefinitions(ConsensusConnectionEdit.GetActive(), "Alignment"));
                }

            //ask user for feature name and definition
            Utility.FeatureForm form = new Utility.FeatureForm(featureNames);
            form.ShowDialog();

            m_featureDef = form.GetFeatureDefinition();
            m_featureName = form.GetFeatureName();
            }

        protected override void OnPostInstall()
            {
            NotificationManager.OutputPrompt("Select first data point.");
            BeginDynamics();
            GetFeatureDefinition();
            }
        
        //adds points on click
        protected override bool OnDataButton(DgnButtonEvent ev)
            {
            if (m_points.Count == 0)
                {
                BeginDynamics();
                }

            m_points.Add(ev.Point);
            NotificationManager.OutputPrompt("Select next data point or right click to complete the command.");
            return true;
            }

        //calls command on reset (right click)
        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            CreateAlignmentFromPoints();
            EndDynamics();
            m_points.Clear();
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

            if (m_points.Count > 1)
                {
                LineStringElement lse = new LineStringElement(Session.Instance.GetActiveDgnModel(), null, m_points.ToArray());
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
            HorizontalAlignmentCreator tool = new HorizontalAlignmentCreator();
            tool.InstallTool();
            }
        }
    }
