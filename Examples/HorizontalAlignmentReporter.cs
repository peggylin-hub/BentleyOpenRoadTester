/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/HorizontalAlignmentReporter.cs $
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
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.SDK;
using Bentley.CifNET.LinearGeometry;

namespace OpenRoadAddin
{
    class HorizontalAlignmentReporter
        {
        private DataDisplayHelper m_displayHelper;

        // Report Options | Display data by annotating model
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void AnnotateAllAlignments()
        {
            m_displayHelper = DataDisplayHelper.CreateForAnnotation();
            ReportAllAlignments();
        }

        // Report Options | Run on all alignments in active model 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void ReportAllAlignments()
        {
            if (m_displayHelper == null)
                m_displayHelper = DataDisplayHelper.CreateForReportDialog();

            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if(sdkCon == null)
                return;

            GeometricModel geomModel = sdkCon.GetActiveGeometricModel();
            if (geomModel == null)
                return;

            // Only Generate Header for Report Dialog 
            if (m_displayHelper.IsReportDialog)
            {
                m_displayHelper.SetReportName("Horizontal Alignment Report - All");
                DgnModel dgn = geomModel.DgnModel;
                DgnFile file = dgn.GetDgnFile();
                Dictionary<string, string> fileProperties = new Dictionary<string, string>();
                fileProperties.Add("Project", dgn.ModelName);
                fileProperties.Add("File Name", file.GetFileName());
                fileProperties.Add("Last Accessed", file.LastSaveTimeUtc.ToString());
                m_displayHelper.PrintValueTable(fileProperties);
            }

            // Cycle through Horizontal Alignments 
            bool foundAlignments = false;
            foreach (Alignment al in geomModel.Alignments)
            {
                if (!al.IsFinalElement)
                    continue;

                foundAlignments = true;
                if(m_displayHelper.IsAnnotation)
                    m_displayHelper.SetAnnotationOrigin(al.LinearGeometry.StartPoint);

                ReportAlignment(al);
            }

            if (!foundAlignments)
                m_displayHelper.AddLine("No alignments to display.");

            m_displayHelper.Finished();
        }

        // Report Options | Run on given alignment
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void ReportSingleAlignment(Alignment al)
        {
            m_displayHelper = DataDisplayHelper.CreateForReportDialog();
            m_displayHelper.SetReportName("Horizontal Alignment Report - Single");
            ReportAlignment(al);
            m_displayHelper.Finished();
        }

        // Utility Function | Read and display data for given alignment 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void ReportAlignment(Alignment al)
        {
            // Generate Alignment Header
            string name = "Unnamed", style = "";
            if (al.Name != null && al.Name != "")
                name = al.Name;
            if (al.FeatureName != null)
                style = al.FeatureName;
            m_displayHelper.AddHeader("Alignment Name: " + name + m_displayHelper.NewLineCharacter +
                                "Alignment Style: " + style);

            // Report Elements in Alignment   
            LinearElement[] elements = { };
            try
            {
                LinearComplex alComplex = (LinearComplex)al.LinearGeometry;
                elements = alComplex.GetSubLinearElements();
            }
            catch
            {
                elements = new LinearElement[1];
                elements[0] = al.LinearGeometry;
            }

            AlignmentPropertyReader propReader = new AlignmentPropertyReader(al);
            foreach (LinearElement le in elements)
            {
                Dictionary<string, string> elementProperties = propReader.Read(le);

                if (m_displayHelper.IsAnnotation)
                    m_displayHelper.SetAnnotationOrigin(GeometryHelper.GetCenterPoint(le));

                m_displayHelper.PrintValueTable(elementProperties);
            }
        }

        // Report Options | Run on all alignments in active model 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void ReportAllAlignmentsItemTypes()
        {
            if (m_displayHelper == null)
                m_displayHelper = DataDisplayHelper.CreateForReportDialog();

            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if(sdkCon == null)
                return;

            GeometricModel geomModel = sdkCon.GetActiveGeometricModel();
            if (geomModel == null)
                return;

            List<string> labels = new List<string>() { "Item Type Library Name", "Item Type Name", "Property Name", "Property Type", "Property Value" };

            // Only Generate Header for Report Dialog 
            if (m_displayHelper.IsReportDialog)
                {
                m_displayHelper.SetReportName("Horizontal Alignment Item Type Report - All");
                DgnModel dgn = geomModel.DgnModel;
                DgnFile file = dgn.GetDgnFile();
                Dictionary<string, string> fileProperties = new Dictionary<string, string>();
                fileProperties.Add("Project", dgn.ModelName);
                fileProperties.Add("File Name", file.GetFileName());
                fileProperties.Add("Last Accessed", file.LastSaveTimeUtc.ToString());
                m_displayHelper.PrintValueTable(fileProperties);
                }

            // Cycle through Horizontal Alignments 
            bool foundAlignments = false;
            foreach (Alignment al in geomModel.Alignments)
                {
                if (!al.IsFinalElement)
                    continue;

                foundAlignments = true;

                // Generate Alignment Header
                string name = string.IsNullOrEmpty(al.Name) ? "Unnamed" : al.Name;
                string style = string.IsNullOrEmpty(al.FeatureName) ? "No Feature Definition" : al.FeatureName;

                m_displayHelper.AddHeader("Alignment Name:   " + name + m_displayHelper.NewLineCharacter + 
                                          "Alignment Style:  " + style + m_displayHelper.NewLineCharacter +
                                          "Alignment Length: " + GeometryHelper.FormatDistance(al.LinearGeometry.Length));

                CustomItemHost host = new CustomItemHost(al.Element, true);
                if (host != null && host.CustomItemsCount > 0)
                    {
                    List<string> data = new List<string>();
                    foreach (Bentley.DgnPlatformNET.DgnEC.IDgnECInstance instance in host.CustomItems)
                        {
                        data.Add(string.Format("{0}|{1}|||", instance.ClassDefinition.Schema.NamespacePrefix, instance.ClassDefinition.Name));

                        foreach (Bentley.ECObjects.Instance.IECPropertyValue propertyValue in instance)
                            {
                            string propertyType = propertyValue.Type.DisplayLabel;
                            string value = "";
                            if (propertyValue is Bentley.ECObjects.Instance.IECArrayValue)
                                {
                                Bentley.ECObjects.Instance.IECArrayValue ecArray = propertyValue as Bentley.ECObjects.Instance.IECArrayValue;
                                foreach (Bentley.ECObjects.Instance.IECPropertyValue arrayValue in ecArray.ContainedValues)
                                    {
                                    if (arrayValue.ArrayIndex == 0)
                                        {
                                        propertyType = "Array&lt;" + arrayValue.Type.DisplayLabel + "&gt;";
                                        }
                                    value += GetFormattedPropertyValue(arrayValue);
                                    if (arrayValue.ArrayIndex < ecArray.Count - 1)
                                        {
                                        value += "<br />";
                                        }
                                    }
                                }
                            else
                                {
                                value = GetFormattedPropertyValue(propertyValue);
                                }

                            data.Add(string.Format("||{0}|{1}|{2}", propertyValue.AccessString, propertyType, value));
                            }
                        }
                    m_displayHelper.PrintValueTable(labels, data);
                    }
                else
                    {
                    m_displayHelper.AddLine("No itemtypes to display.");
                    }
                }

            if (!foundAlignments)
                m_displayHelper.AddLine("No alignments to display.");

            m_displayHelper.Finished();
        }

        // Utility Class | Reads properties from linear elements for horizontal alignments.
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal class AlignmentPropertyReader
        {
            private Alignment m_alignment;
            private StationingFormatter sFormatter;

            public AlignmentPropertyReader(Alignment al)
                {
                m_alignment = al;
                sFormatter = new StationingFormatter(m_alignment);
                }

            // Generic read function determines element type and passes to specific read function
            public Dictionary<string, string> Read(LinearElement le)
                {
                Dictionary<string, string> properties = new Dictionary<string, string>();

                if (le is Line)
                    properties = ReadLine(le as Line);
                else if (le is Spiral)
                    properties = ReadSpiral(le as Spiral);
                else if (le is CircularArc)
                    properties = ReadCircularArc(le as CircularArc);

                if (properties.Count == 0)
                    properties.Add("No properties read for element", le.GetType().Name);

                return properties;
                }

            // Reads Bentley.CifNET.LinearGeometry.Line
            internal Dictionary<string, string> ReadLine(Line line)
            {
                Dictionary<string, string> lineProperties = new Dictionary<string, string>();

                lineProperties.Add("Element", line.GetType().Name);
                lineProperties.Add("Start", GeometryHelper.GetStation(m_alignment, line.StartPoint) + " | " + GeometryHelper.FormatCoordinates(line.StartPoint));
                lineProperties.Add("End", GeometryHelper.GetStation(m_alignment, line.EndPoint) + " | " + GeometryHelper.FormatCoordinates(line.EndPoint));
                lineProperties.Add("Tangential Direction", GeometryHelper.FormatDirection(line.Direction));
                lineProperties.Add("Tangential Length", GeometryHelper.FormatDistance(line.Length));

                return lineProperties;
            }

            // Reads Bentley.CifNET.LinearGeometry.Spiral
            internal Dictionary<string, string> ReadSpiral(Spiral spiral)
            {
                Dictionary<string, string> spiralProperties = new Dictionary<string, string>();

                spiralProperties.Add("Element", spiral.SpiralType.ToString());
                spiralProperties.Add("Start", GeometryHelper.GetStation(m_alignment, spiral.StartPoint) + " | " + GeometryHelper.FormatCoordinates(spiral.StartPoint));
                Bentley.GeometryNET.DPoint3d pi = GeometryHelper.GetPI(spiral);
                spiralProperties.Add("SPI", GeometryHelper.GetStation(m_alignment, pi) + " | " + GeometryHelper.FormatCoordinates(pi));
                spiralProperties.Add("End", GeometryHelper.GetStation(m_alignment, spiral.EndPoint) + " | " + GeometryHelper.FormatCoordinates(spiral.EndPoint));
                spiralProperties.Add("Entrance Radius", GeometryHelper.FormatDistance(Math.Abs(spiral.StartRadius)));
                spiralProperties.Add("Exit Radius", GeometryHelper.FormatDistance(Math.Abs(spiral.EndRadius)));
                spiralProperties.Add("Length", GeometryHelper.FormatDistance(spiral.Length));
                spiralProperties.Add("Angle", GeometryHelper.FormatAngleDirection(spiral.SweepAngle));
                spiralProperties.Add("Constant", GeometryHelper.FormatNumber(spiral.Constant));
                spiralProperties.Add("Long Tangent", GeometryHelper.FormatDistance(spiral.LongTangent));
                spiralProperties.Add("Short Tangent", GeometryHelper.FormatDistance(spiral.ShortTangent));
                spiralProperties.Add("Long Chord", GeometryHelper.FormatDistance(spiral.LongChord));
                spiralProperties.Add("Xs", GeometryHelper.FormatNumber(spiral.Xs));
                spiralProperties.Add("Ys", GeometryHelper.FormatNumber(spiral.Ys));
                spiralProperties.Add("P", GeometryHelper.FormatNumber(spiral.PValue));
                spiralProperties.Add("K", GeometryHelper.FormatNumber(spiral.KValue));
                spiralProperties.Add("Tangent Direction (Start)", GeometryHelper.FormatDirection(spiral.StartPoint.TangentDirection));
                spiralProperties.Add("Radial Direction (Start)", GeometryHelper.GetRadialDirection(spiral.StartPoint));
                spiralProperties.Add("Chord Direction", GeometryHelper.GetChordDirection(spiral.StartPoint, spiral.EndPoint));
                spiralProperties.Add("Radial Direction (End)", GeometryHelper.GetRadialDirection(spiral.EndPoint));
                spiralProperties.Add("Tangent Direction (End)", GeometryHelper.FormatDirection(spiral.EndPoint.TangentDirection));

                return spiralProperties;
            }

            // Reads Bentley.CifNET.LinearGeometry.CircularArc
            internal Dictionary<string, string> ReadCircularArc(CircularArc arc)
            {
                Dictionary<string, string> arcProperties = new Dictionary<string, string>();

                arcProperties.Add("Element", arc.GetType().Name);
                arcProperties.Add("Start", GeometryHelper.GetStation(m_alignment, arc.StartPoint) + " | " + GeometryHelper.FormatCoordinates(arc.StartPoint));
                Bentley.GeometryNET.DPoint3d pi = GeometryHelper.GetPI(arc);
                arcProperties.Add("PI", GeometryHelper.Get_PI_Station(m_alignment, arc) + " | " + GeometryHelper.FormatCoordinates(pi));
                arcProperties.Add("CC", " | " + GeometryHelper.FormatCoordinates(arc.CenterPoint));
                arcProperties.Add("End", GeometryHelper.GetStation(m_alignment, arc.EndPoint) + " | " + GeometryHelper.FormatCoordinates(arc.EndPoint));
                arcProperties.Add("Radius", GeometryHelper.FormatDistance(Math.Abs(arc.Radius)));
                arcProperties.Add("Delta", GeometryHelper.FormatAngleDirection(arc.SweepAngle));
                arcProperties.Add("Degree of Curvature (Arc)", GeometryHelper.FormatDegreeOfCurve(arc.Radius));
                arcProperties.Add("Length", GeometryHelper.FormatDistance(arc.Length));
                arcProperties.Add("Tangent", GeometryHelper.FormatDistance(arc.TangentDistance));
                arcProperties.Add("Chord", GeometryHelper.FormatDistance(arc.ChordDistance));
                double delta = Math.Abs(arc.SweepAngle);
                arcProperties.Add("Middle Ordinate", GeometryHelper.FormatDistance((delta >= Math.PI) ? 0.0 : (Math.Abs(arc.Radius) * (1.0 - Math.Cos(0.5 * delta)))));
                arcProperties.Add("External", GeometryHelper.FormatDistance((delta > Math.PI) ? 0.0 : (Math.Abs(arc.TangentDistance) * Math.Tan(0.25 * delta))));
                arcProperties.Add("Tangent Direction (Start)", GeometryHelper.FormatDirection(arc.StartPoint.TangentDirection));
                arcProperties.Add("Radial Direction (Start)", GeometryHelper.GetRadialDirection(arc.StartPoint));
                arcProperties.Add("Chord Direction", GeometryHelper.GetChordDirection(arc.StartPoint, arc.EndPoint));
                arcProperties.Add("Radial Direction (End)", GeometryHelper.GetRadialDirection(arc.EndPoint));
                arcProperties.Add("Tangent Direction (End)", GeometryHelper.FormatDirection(arc.EndPoint.TangentDirection));

                return arcProperties;
            }
        }

        private string GetFormattedPropertyValue(Bentley.ECObjects.Instance.IECPropertyValue property)
            {
            if (Bentley.ECObjects.ECObjects.BooleanType == property.Type ||
                Bentley.ECObjects.ECObjects.IntegerType == property.Type ||
                Bentley.ECObjects.ECObjects.StringType == property.Type)
                {
                return property.StringValue;
                }
            else if (Bentley.ECObjects.ECObjects.DateTimeType == property.Type)
                {
                DateTime? dateTime = property.NativeValue as DateTime?;
                if (dateTime.HasValue)
                    {
                    return dateTime.ToString();
                    }
                }
            else if (Bentley.ECObjects.ECObjects.DoubleType == property.Type)
                {
                return GeometryHelper.FormatNumber(property.DoubleValue);
                }
            else if (Bentley.ECObjects.ECObjects.PointType == property.Type)
                {
                Bentley.GeometryNET.DPoint3d? point = property.NativeValue as Bentley.GeometryNET.DPoint3d?;
                if (point.HasValue)
                    {
                    return "[" + GeometryHelper.FormatNumber(point.Value.X) + ", " + GeometryHelper.FormatNumber(point.Value.Y) + "]";
                    }
                }
            return string.Empty;
            }
        }
    }
