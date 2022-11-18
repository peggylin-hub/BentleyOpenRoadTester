/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/VerticalAlignmentReporter.cs $
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
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.LinearGeometry;
using Bentley.CifNET.SDK;

namespace OpenRoadAddin
{
    class VerticalAlignmentReporter
    {
        /*------------------------------------------------------------------------------------**/
        /* Reads profiles and creates report of stations and elevations at an interval.
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void StationElevationsReport()
        {
            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if(sdkCon == null)
                return;

            GeometricModel geomModel = sdkCon.GetActiveGeometricModel();
            if (geomModel == null)
                return;

            ReportResultsForm alignmentReport = new ReportResultsForm();
            alignmentReport.SetReportName("Profile Station and Elevation Report");

            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModelRef() as DgnModel);

            bool foundProfiles = false;          
            foreach (Alignment al in geomModel.Alignments)
                {
                if (!al.IsFinalElement)
                    continue;

                StationingFormatter formatter = new StationingFormatter(al);
                foreach (Profile profile in al.Profiles)
                    {
                    if (!profile.IsFinalElement)
                        continue;

                    foundProfiles = true;
                    alignmentReport.AddHeader("Profile Name: " + profile.Name + alignmentReport.NewLineCharacter +
                                               "Length: " + GeometryHelper.FormatDistance(profile.ProfileGeometry.ProjectedLength));

                    Dictionary<string, string> stations = new Dictionary<string, string>();
                    double interval = GeometryHelper.ConvertMasterToMeter(50.0);
					int loopLength = (int)profile.ProfileGeometry.ProjectedLength; //convert to int to prevent crash
                    for (double station = 0.0; station < loopLength; station += interval)
                        {
                        string stnVal = "";
                        formatter.FormatStation(ref stnVal, station, settings);
                        string ElvVal = GeometryHelper.FormatDistance(profile.ProfileGeometry.GetYAtX(station));
                        stations.Add(stnVal, ElvVal);
                        }

                    string stnVal1 = "";
                    formatter.FormatStation(ref stnVal1, profile.ProfileGeometry.ProjectedLength, settings);
                    string ElvVal1 = GeometryHelper.FormatDistance(profile.ProfileGeometry.GetYAtX(profile.ProfileGeometry.ProjectedLength));
                    stations.Add(stnVal1, ElvVal1);

                    List<string> headers = new List<string>() { "Station", "Elevation" };
                    alignmentReport.PrintValueTable(headers, stations);
                    }
                }

            if (!foundProfiles)
                alignmentReport.AddLine("No profiles to display.");

            alignmentReport.Finished();
        }

        /*------------------------------------------------------------------------------------**/
        /* Reads active profiles and creates report of stations and elevations at an interval also displays cardinal points.
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void ActiveStationElevationAtIntervalReport()
        {
            List<string> labels = new List<string>() { "Type", "Station", "Elevation" };
            SortedDictionary<double, string> data = new SortedDictionary<double, string>();
            double interval = GeometryHelper.ConvertMasterToMeter(50.0);
            StringBuilder sb = new StringBuilder();

            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();

            if (sdkCon == null)
                return;

            GeometricModel geomModel = sdkCon.GetActiveGeometricModel();
            if (geomModel == null)
                return;

            ReportResultsForm report = new ReportResultsForm();
            report.SetReportName("Active Profile Station Elevation at Interval Report");

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("File Name", geomModel.DgnModel.GetDgnFile().GetFileName());
            header.Add("Model Name", geomModel.DgnModel.ModelName);
            report.PrintValueTable(header);

            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModelRef() as DgnModel);
            foreach (Alignment al in geomModel.Alignments)
                {
                if (!al.IsFinalElement)
                    {
                    continue;
                    }

                StationingFormatter formatter = new StationingFormatter(al);
                Profile activeProfile = al.ActiveProfile;

                data.Clear();
                sb.Clear();

                sb.Append("Horizontal Alignment: ");
                sb.Append(string.IsNullOrEmpty(al.Name) ? "Unnamed" : al.Name);
                sb.Append(report.NewLineCharacter);
                sb.Append("Active Vertical Alignment Name: ");
                if (activeProfile != null)
                    {
                    sb.Append(string.IsNullOrEmpty(activeProfile.Name) ? "Unnamed" : activeProfile.Name);
                    }
                else
                    {
                    sb.Append("No Active Vertical Alignment");
                    }
                report.AddHeader(sb.ToString());

                ProfileElement element = activeProfile?.ProfileGeometry;
                if (element != null)
                    {
                    if (element is ProfileComplex)
                        {
                        ProfileComplex complex = element as ProfileComplex;
                        List<ProfileElement> subElements = complex.GetSubProfileElements().ToList();
                        for (int i = 0; i < subElements.Count; i++)
                            {
                            ProfileElement subElement = subElements[i];
                            if (subElement is ProfileCircularArc)
                                {
                                ProfileCircularArc arc = subElement as ProfileCircularArc;
                                if (i == 0)
                                    {
                                    data.Add(arc.StartPoint.Coordinates.X, GetProfilePointData(element, "PVC", arc.StartPoint.Coordinates.X, settings, formatter));
                                    }

                                data.Add(arc.VPIPoint.X, GetProfilePointData(element, "PVI", arc.VPIPoint.X, settings, formatter));

                                string pointType = GeometryHelper.GetVerticalPointType(subElements[i], ((i + 1 < subElements.Count) ? subElements[i + 1] : null));
                                data.Add(arc.EndPoint.Coordinates.X, GetProfilePointData(element, pointType, arc.EndPoint.Coordinates.X, settings, formatter));
                                }
                            else if (subElement is ProfileParabola)
                                {
                                ProfileParabola parabola = subElement as ProfileParabola;
                                if (i == 0)
                                    {
                                    data.Add(parabola.StartPoint.Coordinates.X, GetProfilePointData(element, "PVC", parabola.StartPoint.Coordinates.X, settings, formatter));
                                    }

                                data.Add(parabola.VPIPoint.X, GetProfilePointData(element, "PVI", parabola.VPIPoint.X, settings, formatter));

                                string pointType = GeometryHelper.GetVerticalPointType(subElements[i], ((i + 1 < subElements.Count) ? subElements[i + 1] : null));
                                data.Add(parabola.EndPoint.Coordinates.X, GetProfilePointData(element, pointType, parabola.EndPoint.Coordinates.X, settings, formatter));
                                }
                            else if (subElement is ProfileLine)
                                {
                                ProfileLine line = subElement as ProfileLine;
                                if (i == 0)
                                    {
                                    data.Add(line.StartPoint.Coordinates.X, GetProfilePointData(element, "POB", line.StartPoint.Coordinates.X, settings, formatter));
                                    }

                                string pointType = GeometryHelper.GetVerticalPointType(subElements[i], ((i + 1 < subElements.Count) ? subElements[i + 1] : null));
                                data.Add(line.EndPoint.Coordinates.X, GetProfilePointData(element, pointType, line.EndPoint.Coordinates.X, settings, formatter));
                                }
                            }
                        }
                    else
                        {
                        if (element is ProfileCircularArc)
                            {
                            ProfileCircularArc arc = element as ProfileCircularArc;
                            data.Add(arc.StartPoint.Coordinates.X, GetProfilePointData(element, "PVC", arc.StartPoint.Coordinates.X, settings, formatter));
                            data.Add(arc.VPIPoint.X, GetProfilePointData(element, "PVI", arc.VPIPoint.X, settings, formatter));
                            data.Add(arc.EndPoint.Coordinates.X, GetProfilePointData(element, "PVT", arc.EndPoint.Coordinates.X, settings, formatter));
                            }
                        else if (element is ProfileParabola)
                            {
                            ProfileParabola parabola = element as ProfileParabola;
                            data.Add(parabola.StartPoint.Coordinates.X, GetProfilePointData(element, "PVC", parabola.StartPoint.Coordinates.X, settings, formatter));
                            data.Add(parabola.VPIPoint.X, GetProfilePointData(element, "PVI", parabola.VPIPoint.X, settings, formatter));
                            data.Add(parabola.EndPoint.Coordinates.X, GetProfilePointData(element, "PVT", parabola.EndPoint.Coordinates.X, settings, formatter));
                            }
                        else if (element is ProfileLine)
                            {
                            ProfileLine line = element as ProfileLine;
                            data.Add(line.StartPoint.Coordinates.X, GetProfilePointData(element, "POB", line.StartPoint.Coordinates.X, settings, formatter));
                            data.Add(line.EndPoint.Coordinates.X, GetProfilePointData(element, "POE", line.EndPoint.Coordinates.X, settings, formatter));
                            }
                        }

                    for (double station = 0.0; station < element.ProjectedLength; station += interval)
                        {
                        if (!data.ContainsKey(station))
                            {
                            data.Add(station, GetProfilePointData(element, "Interval", station, settings, formatter));
                            }
                        }

                    report.PrintValueTable(labels, data.Values.ToList());
                    }
                }

            report.Finished();
        }

        /*------------------------------------------------------------------------------------**/
        /* Reads profiles and creates report of profiles and their elements.
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void ProfileElementReport()
        {
            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if (sdkCon == null)
                return;

            ReportResultsForm alignmentReport = new ReportResultsForm();
            alignmentReport.SetReportName("Profile Element Report");
            
            // Verify we can get the active profile model 
            GeometricModel gm = sdkCon.GetActiveGeometricModel();
            if (gm == null)
            {
                alignmentReport.AddLine("Could not load active model - make sure there is an active profile.");
                alignmentReport.Finished();
                return;
            }

            StationFormatSettings settings = StationFormatSettings.GetStationFormatSettingsForModel(Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModelRef() as DgnModel);

            bool foundProfiles = false;
            foreach (Alignment al in gm.Alignments)
            {
                if (!al.IsFinalElement)
                    continue;

                // Print Horizontal Alignment Header
                if (al.Profiles != null && al.Profiles.Count() > 0)
                {
                    alignmentReport.AddHeader("Horizontal Alignment: " + (al.Name != "" ? al.Name : "Unnamed") + alignmentReport.NewLineCharacter +
                                              "Horizontal Style: " + al.FeatureName);
                }

                StationingFormatter formatter = new StationingFormatter(al);
                foreach (Profile profile in al.Profiles)
                {
                    if (!profile.IsFinalElement)
                        continue;
                    foundProfiles = true;

                    // Print Profile Header
                    alignmentReport.AddSubheader("Profile Name: " + profile.Name + alignmentReport.NewLineCharacter +
                                                 "Length: " + GeometryHelper.FormatDistance(profile.ProfileGeometry.ProjectedLength));

                    // Read Profile Geometry Information and Generate Report
                    Dictionary<string, string> profileProperties = new Dictionary<string, string>();
                    if (profile.ProfileGeometry is ProfileComplex)
                    {
                        ProfileComplex complex = profile.ProfileGeometry as ProfileComplex;
                        foreach (ProfileElement ele in complex.GetSubProfileElements())
                            alignmentReport.PrintValueTable(ReportProfileElement(ele, settings, formatter));
                    }
                    else
                        alignmentReport.PrintValueTable(ReportProfileElement(profile.ProfileGeometry, settings, formatter));
                }
            }

            if (!foundProfiles)
                alignmentReport.AddLine("No profiles to display.");

            alignmentReport.Finished();
        }

        // Report Profile Element Based on Type
        private Dictionary<string, string> ReportProfileElement(ProfileElement ele, StationFormatSettings settings, StationingFormatter format)
        {

            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Type", ele.GetType().Name);
            if (ele is ProfileLine)
                ReportProfileLine(ele as ProfileLine, settings, format, properties);
            else if (ele is ProfileParabola)
                ReportProfileParabola(ele as ProfileParabola, settings, format, properties);

            return properties;
        }

        // Report Linear Profile Elements
        private void ReportProfileLine(ProfileLine ele, StationFormatSettings settings, StationingFormatter format, Dictionary<string, string> properties)
        {
            ReportProfilePoint("PVT", ele.StartPoint.Coordinates, settings, format, properties);
            ReportProfilePoint("PVC", ele.EndPoint.Coordinates, settings, format, properties);
            properties.Add("Tangent Grade", GeometryHelper.FormatGrade(ele.Slope));
            properties.Add("Tangent Length", GeometryHelper.FormatDistance(ele.ProjectedLength));
        }

        // Report Parabola Profile Elements 
        private void ReportProfileParabola(ProfileParabola ele, StationFormatSettings settings, StationingFormatter format, Dictionary<string, string> properties)
        {
            ReportProfilePoint("PVC", ele.StartPoint.Coordinates, settings, format, properties);
            ReportProfilePoint("PVI", ele.VPIPoint, settings, format, properties);
            ReportProfilePoint("PVT", ele.EndPoint.Coordinates, settings, format, properties);

            double projectedLeftLength = ele.VPIPoint.X - ele.StartPoint.Coordinates.X;
            double projectedRightLength = ele.EndPoint.Coordinates.X - ele.VPIPoint.X;
            LinearPoint summit = ele.SummitPoint;
            if (summit != null &&
                Math.Sign(ele.StartSlope) != Math.Sign(ele.EndSlope) &&
                projectedLeftLength != 0.0 &&
                projectedRightLength != 0.0 &&
                (ele.StartSlope - ele.EndSlope) != 0.0 &&
                (ele.EndSlope - ele.StartSlope) != 0.0)
            {
                if (ele.EndSlope - ele.StartSlope > 0.0)
                    ReportProfilePoint("VLOW", summit.Coordinates, settings, format, properties);
                else
                    ReportProfilePoint("VHIGH", summit.Coordinates, settings, format, properties);
            }

            properties.Add("Length", GeometryHelper.FormatDistance(ele.ProjectedLength));
            properties.Add("Entrance Grade", GeometryHelper.FormatGrade(ele.StartSlope));
            properties.Add("Exit Grade", GeometryHelper.FormatGrade(ele.EndSlope));
            double projectedLength = GeometryHelper.ConvertMeterToMaster(ele.ProjectedLength);
            properties.Add("r = (g2 - g1) / L", GeometryHelper.FormatNumber(projectedLength == 0.0 ? 0.0 : 100 * ((ele.EndSlope - ele.StartSlope) / (projectedLength / 100.0))));
            properties.Add("K = l / (g2 - g1)", GeometryHelper.FormatDistance( Math.Abs(ele.KValue)));
            if (ele.ProjectedLength != 0.0 && projectedLeftLength != 0.0 && projectedRightLength != 0.0)
            {
                double middleOrdinate = 0.0;
                if (Math.Abs(projectedLeftLength - projectedRightLength) < 0.0001)
                    middleOrdinate = ((ele.EndSlope - ele.StartSlope) / 8.0) * ele.ProjectedLength;
                else
                    middleOrdinate = ((ele.EndSlope - ele.StartSlope) / (2.0 * projectedLeftLength * projectedRightLength)) * projectedLeftLength * projectedRightLength;
                properties.Add("Middle Ordinate", GeometryHelper.FormatDistance(middleOrdinate));
            }
        }

        // Report Points
        private void ReportProfilePoint(string pointType, Bentley.GeometryNET.DPoint3d point, StationFormatSettings settings, StationingFormatter format, Dictionary<string, string> properties)
        {
            string station = string.Empty;
            format.FormatStation(ref station, point.X, settings);
            string elevation = GeometryHelper.FormatDistance(point.Y);
            properties.Add(pointType, "Station: " + station + " | Elevation: " + elevation);
        }

        // Get formatted point data
        private string GetProfilePointData(ProfileElement element, string pointType, double station, StationFormatSettings settings, StationingFormatter formatter)
        {
            string stationValue = "";
            formatter.FormatStation(ref stationValue, station, settings);
            string elevationValue = GeometryHelper.FormatDistance(GeometryHelper.ConvertMeterToMaster(element.GetYAtX(station)));

            return string.Format("{0}|{1}|{2}", pointType, stationValue, elevationValue);
        }
    }
}
