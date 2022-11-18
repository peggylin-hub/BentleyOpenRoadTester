/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/GeometryHelper.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.LinearGeometry;
using Bentley.CifNET.Formatting;
using Bentley.DgnPlatformNET;

namespace OpenRoadAddin
{
    public class GeometryHelper
        {
        internal static DgnModel m_activeModel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
        internal static double m_defaultUnitsToMeters = FormatSettingsConstants.GetMasterUnitsToMeters();
        internal static int LinearPrecision { get { return GetDesignFilePrecision(); } }

        /*------------------------------------------------------------------------------------**/
        /* Conversion
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static double ConvertMasterToMeter(double num)
            {
            return num * m_defaultUnitsToMeters;
            }

        public static double ConvertMeterToMaster(double num)
            {
            return num / m_defaultUnitsToMeters;
            }

        public static double ConvertUORToMeter(double num)
            {
            ModelInfo info = m_activeModel.GetModelInfo();
            return num / info.UorPerMeter;
            }

        /*------------------------------------------------------------------------------------**/
        /* Formatting
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal static int GetDesignFilePrecision()
            {
            int precision = 0;

            // Get the precision out of the PrecisionFormat enum
            PrecisionFormat lp = m_activeModel.GetModelInfo().LinearPrecision;
            string[] splitPrec = lp.ToString().Split('_');
            if(splitPrec.Length >= 2)
                int.TryParse(splitPrec[1], out precision);

            if (precision > 0)
                return precision;
            else
                return 3; // Default is 3
            }

        public static string FormatNumber(double num)
            {
            return FormatForDisplay.Double(num);
            }

        public static string FormatCoordinates(LinearPoint point)
            {
            string y = FormatForDisplay.Coordinate(point.Coordinates.Y, m_activeModel);
            string y2 = FormatForDisplay.Coordinate(point.Coordinates.Y);
            string x = FormatForDisplay.Coordinate(point.Coordinates.X, m_activeModel);
            return "( " + y + ", " + x + " )";
            }

        public static string FormatCoordinates(Bentley.GeometryNET.DPoint3d point)
            {
            string y = FormatForDisplay.Coordinate(point.Y, m_activeModel);
            string x = FormatForDisplay.Coordinate(point.X, m_activeModel);
            return "( " + y + ", " + x + " )";
            }

        public static string FormatDirection(double value)
            {
            ModelInfo info = m_activeModel.GetModelInfo();
            return FormatForDisplay.Direction(value, m_activeModel);
            }

        public static string FormatDistance(double value)
            {
            return FormatForDisplay.Distance(value, m_activeModel, LinearPrecision);
            }

        public static string FormatArea (double value)
            {
            ModelInfo info = m_activeModel.GetModelInfo ();
            double metersPerUor = 1.0 / info.UorPerMeter;
            double defaultUnitsToSquareMeters = (metersPerUor * metersPerUor);
            return FormattingProvidersManager.Instance[ECAreaTypeConverter.FormatGuid].FormatValue (value * defaultUnitsToSquareMeters, 0);
            }

        public static string FormatVolume (double value)
            {
            ModelInfo info = m_activeModel.GetModelInfo ();
            double metersPerUor = 1.0 / info.UorPerMeter;
            double defaultUnitsToCubicMeters = (metersPerUor * metersPerUor * metersPerUor);
            return FormattingProvidersManager.Instance[ECVolumeTypeConverter.FormatGuid].FormatValue (value * defaultUnitsToCubicMeters, 0);
            }

        public static string FormatAngle(double valueRadians)
            {
            ModelInfo info = m_activeModel.GetModelInfo();
            return FormatForDisplay.Angle(valueRadians, m_activeModel);
            }

        public static string FormatAngleDirection(double valueRadians)
            {
            string direction = (valueRadians > 0) ? "Left" : "Right";
            return FormatAngle(Math.Abs(valueRadians)) + " " + direction;
            }

        public static string FormatDegreeOfCurve(double radius)
            {
            ModelInfo info = m_activeModel.GetModelInfo();
            double radiusInMasterUnits = radius / (info.UorPerMaster / info.UorPerMeter);
            double valueRadians = 100.0 / (radiusInMasterUnits);
            return FormatForDisplay.Angle(valueRadians, m_activeModel);
            }

        public static string FormatGrade(double value)
            {
            string grade = FormatNumber(100 * value);
            return grade + "%";
            }

        /*------------------------------------------------------------------------------------**/
        /* Alignment property calculations
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static Bentley.GeometryNET.DPoint3d GetPI(LinearElement le)
            {
            double x = 0.0, y = 0.0;
            
            if (le is Spiral)
                {
                Spiral spiral = le as Spiral;
                if (spiral.IsOutgoing)
                    {
                    x = spiral.StartPoint.Coordinates.X + spiral.ShortTangent * Math.Cos(spiral.StartDirection);
                    y = spiral.StartPoint.Coordinates.Y + spiral.ShortTangent * Math.Sin(spiral.StartDirection);
                    }
                else
                    {
                    x = spiral.StartPoint.Coordinates.X + spiral.LongTangent * Math.Cos(spiral.StartDirection);
                    y = spiral.StartPoint.Coordinates.Y + spiral.LongTangent * Math.Sin(spiral.StartDirection);
                    }
                }

            else if (le is CircularArc)
                {
                CircularArc arc = le as CircularArc;
                Bentley.GeometryNET.DPoint3d point;
                arc.PIPoint(out point);
                return point;
                }

            return new Bentley.GeometryNET.DPoint3d(x, y);
            }

        public static string GetChordDirection(LinearPoint p1, LinearPoint p2)
            { 
            double azimuth = 0.0;
            if (p1.Coordinates.X == p2.Coordinates.X)
                azimuth = (p2.Coordinates.Y >= p1.Coordinates.Y) ? 0.0 : Math.PI;
            double stagedValue = Math.Atan2(p2.Coordinates.X - p1.Coordinates.X, p2.Coordinates.Y - p1.Coordinates.Y);
            if (p2.Coordinates.X > p1.Coordinates.X)
                azimuth = stagedValue;
            else
                azimuth = stagedValue + 2.0 * Math.PI;

            double dDir = 0.5 * Math.PI - azimuth;
            return FormatDirection(dDir);
            }

        public static string GetRadialDirection(LinearPoint point)
            {
            double direction = (point.TangentDirection - (Math.PI * 0.5)) % (2.0 * Math.PI);
            if (direction < 0)
                direction = (Math.PI * 2.0) + direction;
            return FormatDirection(direction);
            }

        public static Bentley.GeometryNET.DPoint3d GetCenterPoint(LinearElement le)
            {
            Bentley.GeometryNET.DPoint3d center = new Bentley.GeometryNET.DPoint3d();
            center.X = ((le.StartPoint.Coordinates.X + le.EndPoint.Coordinates.X) / 2);
            center.Y = ((le.StartPoint.Coordinates.Y + le.EndPoint.Coordinates.Y) / 2);
            return center;
            }

        /*------------------------------------------------------------------------------------**/
        /* Station calculation / formatting
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static string GetStation(Alignment al, LinearPoint point)
            {
            return GetStation(al, point.Coordinates);
            }

        public static string GetStation(Alignment al, Bentley.GeometryNET.DPoint3d point)
            {
            LinearPoint stationPoint = al.LinearGeometry.ProjectPointOnPerpendicular(point);
            return GetStationFromPoint(al, stationPoint);
            }

        public static string GetStationFromDistanceAlong(Alignment al, double distanceAlong)
            {
            // Get numerical station
            string stationStr = "";

            // Format it
            StationingFormatter sformatter = new StationingFormatter(al);
            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(m_activeModel);
            sformatter.FormatStation(ref stationStr, distanceAlong, settings);

            return stationStr;
            }

        private static string GetStationFromPoint(Alignment al, LinearPoint point)
            {
            // Get numerical station
            string stationStr = "";
            double stationNum = point.DistanceOnExtension + point.DistanceAlong;

            // Format it
            StationingFormatter sformatter = new StationingFormatter(al);
            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(m_activeModel);
            sformatter.FormatStation(ref stationStr, stationNum, settings);

            return stationStr;
            }

        internal static string Get_PI_Station(Alignment al, CircularArc arc)
            {
            // Get numerical station
            string stationStr = "";
            LinearPoint startPoint = al.LinearGeometry.ProjectPointOnPerpendicular(arc.StartPoint.Coordinates);
            double stationNum = startPoint.DistanceOnExtension + startPoint.DistanceAlong + arc.TangentDistance;

            // Format it
            StationingFormatter sformatter = new StationingFormatter(al);
            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(m_activeModel);
            sformatter.FormatStation(ref stationStr, stationNum, settings);

            return stationStr;
            }

        /*------------------------------------------------------------------------------------**/
        /* Point type calculations
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static string GetVerticalPointType(ProfileElement element1, ProfileElement element2)
            {
            string pointType = string.Empty;

            if (element1 != null && element2 != null) //interior element
                {
                if (element1 is ProfileCircularArc)
                    {
                    if (element2 is ProfileLine)
                        {
                        pointType = "PVT";
                        }
                    else
                        {
                        ProfileCircularArc arc = element1 as ProfileCircularArc;
                        double curvature1 = arc.Radius > 0.0 ? 1.0 : -1.0;
                        double curvature2 = 0.0;
                        if (element2 is ProfileCircularArc)
                            {
                            ProfileCircularArc next = element2 as ProfileCircularArc;
                            curvature2 = next.Radius > 0.0 ? 1.0 : -1.0;
                            }
                        else if (element2 is ProfileParabola)
                            {
                            ProfileParabola next = element2 as ProfileParabola;
                            double projectedLength = GeometryHelper.ConvertMeterToMaster(next.ProjectedLength);
                            double rateOfChange = (projectedLength == 0.0) ? 0.0 : (next.EndSlope - next.StartSlope) / (projectedLength / 100.0);
                            curvature2 = rateOfChange > 0.0 ? 1.0 : -1.0;
                            }
                        pointType = (curvature1 * curvature2 >= 0.0) ? "PVCC" : "PVRC";
                        }
                    }
                else if (element1 is ProfileLine)
                    {
                    if (element2 is ProfileCircularArc || element2 is ProfileParabola)
                        {
                        pointType = "PVC";
                        }
                    else if (element2 is ProfileLine)
                        {
                        pointType = "PVI";
                        }
                    }
                else if (element1 is ProfileParabola)
                    {
                    if (element2 is ProfileLine)
                        {
                        pointType = "PVT";
                        }
                    else
                        {
                        ProfileParabola parabola = element1 as ProfileParabola;
                        double projectedLength = ConvertMeterToMaster(parabola.ProjectedLength);
                        double rateOfChange = (projectedLength == 0.0) ? 0.0 : (parabola.EndSlope - parabola.StartSlope) / (projectedLength / 100.0);
                        double curvature1 = rateOfChange > 0.0 ? 1.0 : -1.0;
                        double curvature2 = 0.0;
                        if (element2 is ProfileCircularArc)
                            {
                            ProfileCircularArc next = element2 as ProfileCircularArc;
                            curvature2 = next.Radius > 0.0 ? 1.0 : -1.0;
                            }
                        else if (element2 is ProfileParabola)
                            {
                            ProfileParabola next = element2 as ProfileParabola;
                            projectedLength = ConvertMeterToMaster(next.ProjectedLength);
                            rateOfChange = (projectedLength == 0.0) ? 0.0 : (next.EndSlope - next.StartSlope) / (projectedLength / 100.0);
                            curvature2 = rateOfChange > 0.0 ? 1.0 : -1.0;
                            }
                        pointType = (curvature1 * curvature2 >= 0.0) ? "PVCC" : "PVRC";
                        }
                    }
                }
            else if (element1 != null) //Last element
                {
                if (element1 is ProfileCircularArc || element2 is ProfileParabola)
                    {
                    pointType = "PVT";
                    }
                else if (element1 is ProfileLine)
                    {
                    pointType = "POE";
                    }
                }
            else if (element2 != null) //First element
                {
                if (element2 is ProfileCircularArc || element2 is ProfileParabola)
                    {
                    pointType = "PVC";
                    }
                else if (element2 is ProfileLine)
                    {
                    pointType = "POB";
                    }
                }

            return pointType;
            }

        /*------------------------------------------------------------------------------------**/
        /* Creation
        /*--------------+---------------+---------------+---------------+---------------+------*/
        //Caller must check that the number of elements in the returned list is greater than 0
        //Expected input data format: meters
        public static List<LinearElement> GetArcBetweenTwoElements(Bentley.GeometryNET.DPoint3d firstTangentStartPoint, Bentley.GeometryNET.DPoint3d firstTangentEndPoint,
            Bentley.GeometryNET.DPoint3d lastTangentStartPoint, Bentley.GeometryNET.DPoint3d lastTangentEndPoint, double arcRadius)
            {
            //setup
            List<LinearElement> linElems = new List<LinearElement>();
            
            //creating the first tangent line            
            Line firstTangentLine = Line.Create1(firstTangentStartPoint, firstTangentEndPoint);

            //creating the last tangent line
            Line lastTangentLine = Line.Create1(lastTangentStartPoint, lastTangentEndPoint);
            
            //getting the angle between lines
            double angleBetweenLines = firstTangentLine.Direction - lastTangentLine.Direction;
            if (angleBetweenLines < 0) angleBetweenLines += 2 * System.Math.PI;

            Hand hand;
            Line firstTangentOffset, lastTangentOffset;
            //If the angle created by the lines is less than 180 degrees, creates a clockwise arc using offset lines in the positive direction to find the center point
            if (angleBetweenLines < System.Math.PI)
                {
                hand = Hand.Clockwise;
                firstTangentOffset = Line.Create1(firstTangentLine.GetPointAtDistanceOffset(0.0, arcRadius).Coordinates, firstTangentLine.GetPointAtDistanceOffset(firstTangentLine.Length, arcRadius).Coordinates);
                lastTangentOffset = Line.Create1(lastTangentLine.GetPointAtDistanceOffset(0.0, arcRadius).Coordinates, lastTangentLine.GetPointAtDistanceOffset(lastTangentLine.Length, arcRadius).Coordinates);
                }
            //If the angle created by the lines is greater than 180 degrees, creates a counterclockwise arc using offset lines in the negative direction to find the center point
            else
                {
                hand = Hand.CounterClockwise;
                firstTangentOffset = Line.Create1(firstTangentLine.GetPointAtDistanceOffset(0.0, -arcRadius).Coordinates, firstTangentLine.GetPointAtDistanceOffset(firstTangentLine.Length, -arcRadius).Coordinates);
                lastTangentOffset = Line.Create1(lastTangentLine.GetPointAtDistanceOffset(0.0, -arcRadius).Coordinates, lastTangentLine.GetPointAtDistanceOffset(lastTangentLine.Length, -arcRadius).Coordinates);
                }

            //getting the intersection of the offset lines
            LinearIntersectionCollection intersectionCollection = firstTangentOffset.Intersect(lastTangentOffset);
            if(intersectionCollection.Count > 0)
                {
                //the intersection of the offset lines is the center point of the arc
                Bentley.GeometryNET.DPoint3d centerPoint = intersectionCollection.Item(0).PointOn1.Coordinates;

                //getting lines perpendicular from the center point to the tangent lines to find the start and end points of the arc
                LinearPoint startPointLinear = firstTangentLine.ProjectPointOnPerpendicular(centerPoint);
                Bentley.GeometryNET.DPoint3d arcStartPoint = startPointLinear.Coordinates;
                Line startDirectionLine = Line.Create1(centerPoint, arcStartPoint);

                LinearPoint endPointLinear = lastTangentLine.ProjectPointOnPerpendicular(centerPoint);
                Bentley.GeometryNET.DPoint3d arcEndPoint = endPointLinear.Coordinates;
                Line endDirectionLine = Line.Create1(centerPoint, arcEndPoint);

                //creating the starting tangent to the arc
                Line startingTangent = Line.Create1(firstTangentStartPoint, arcStartPoint);
                linElems.Add(startingTangent);

                //creating the arc
                Bentley.CifNET.LinearGeometry.CircularArc arc = Bentley.CifNET.LinearGeometry.CircularArc.Create8(centerPoint, arcRadius, startDirectionLine.Direction, endDirectionLine.Direction, hand);
                linElems.Add(arc);

                //creating the ending tangent to the arc
                Line endLine = Line.Create1(arcEndPoint, lastTangentEndPoint);
                linElems.Add(endLine);
                }

            return linElems;
            }

        }
    }
