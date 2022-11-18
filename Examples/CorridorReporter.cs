/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/CorridorReporter.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.SDK;
using Bentley.CifNET.Geometry;

namespace OpenRoadAddin
{
    class CorridorReporter
        {
        /*------------------------------------------------------------------------------------**/
        /* Reads corridors and creates report.
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void ReportAllCorridors()
            {
            ConsensusConnection sdkCon = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();
            if (sdkCon == null)
                return;
                
            GeometricModel geomModel = sdkCon.GetActiveGeometricModel();
            if (geomModel == null)
                return;

            ReportResultsForm corridorReport = new ReportResultsForm();
            corridorReport.SetReportName("Corridor Report");
            corridorReport.AddHeader("Corridors");

            bool foundCorridors = false;
            foreach (Corridor cor in geomModel.Corridors)
                {
                foundCorridors = true;
                if (cor.Name != null)
                    corridorReport.AddLine("Name: " + cor.Name);

                foreach (CorridorSurface cs in cor.CorridorSurfaces)
                    {
                    if (cs.Type.Contains ("Hidden"))
                        continue;
                    CorridorMeshComponent (corridorReport, cs);
                    }

                corridorReport.NewParagraph();
                }
            corridorReport.NewLine();

            if (!foundCorridors)
                corridorReport.AddLine("No corridors to display.");

            corridorReport.Finished();
            }

        private void CorridorMeshComponent(ReportResultsForm corridorReport, CorridorSurface cs)
            {
            corridorReport.AddSubheader ("Corridor Component");
            Dictionary<string, string> properties = new Dictionary<string, string> ();
            if (!string.IsNullOrEmpty(cs.Name))
                properties.Add ("Name", cs.Name);
            if (!string.IsNullOrEmpty (cs.FeatureName))
                {
                properties.Add ("Feature Name", cs.FeatureName);
                MeshHeaderElement mesh = (MeshHeaderElement)cs.Element;
                PolyfaceHeader polyface = mesh.GetMeshData ();
                MeshElement meshEle = new MeshElement (polyface);
                double volume = meshEle.PolyfaceVolume;
                double area = meshEle.SlopedArea;
                // Only shows the area up upward facing meshes (the top areas)
                properties.Add ("Slope Area", GeometryHelper.FormatArea (area));
                properties.Add ("Volume", GeometryHelper.FormatVolume (volume));
                properties.Add ("Top Mesh", cs.IsTopMesh.ToString());
                properties.Add ("Bottom Mesh", cs.IsBottomMesh.ToString());
                }
            corridorReport.PrintValueTable (properties);
            }
        }
    }
