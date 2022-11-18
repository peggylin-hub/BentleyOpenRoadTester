/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/OPENROADADDIN/OPENROADADDIN.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Bentley.DgnPlatformNET;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.LinearGeometry;

namespace OpenRoadAddin
    {
    /*=====================================================================================**/
    /* Required | Implementation of Addin Class            
    /*=====================================================================================**/
    [Bentley.MstnPlatformNET.AddInAttribute(MdlTaskID = "OPENROADADDIN")]
    public sealed class OpenRoadTester : Bentley.MstnPlatformNET.AddIn
    {
        private static OpenRoadTester s_OPENROADTESTER = null;

        public OpenRoadTester(System.IntPtr mdlDesc): base(mdlDesc)
        {
            s_OPENROADTESTER = this;
        }

        protected override int Run(string[] commandLine)
        {
            return 0;
        }

        internal static OpenRoadTester Instance()
        {
            return s_OPENROADTESTER;
        }


        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS
        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> ASANNOTATION
        /*------------------------------------------------------------------------------------**/
        internal void HorizontalAlignmentReport(bool reportAsAnnotation)
        {
            HorizontalAlignmentReporter hRep = new HorizontalAlignmentReporter();

            if (reportAsAnnotation)
                hRep.AnnotateAllAlignments();
            else
                hRep.ReportAllAlignments();
        }

        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> ITEMTYPES
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void HorizontalAlignmentItemTypes()
        {
            HorizontalAlignmentReporter hRep = new HorizontalAlignmentReporter();
            hRep.ReportAllAlignmentsItemTypes();
        }

        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> PICKALIGNMENT
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal void PickAlignment()
        {
            PickAlignmentTool.InstallNewInstance();
        }

        ///* OPENROADADDIN -> REPORT -> STATIONELEVATIONS
        ///*------------------------------------------------------------------------------------**/
        //internal void StationElevationsReport()
        //    {
        //    VerticalAlignmentReporter vRep = new VerticalAlignmentReporter();
        //    vRep.StationElevationsReport();
        //    }

        ///* OPENROADADDIN -> REPORT -> PROFILEELEMENTS
        ///*------------------------------------------------------------------------------------**/
        //internal void ProfileElementReport()
        //    {
        //    VerticalAlignmentReporter vRep = new VerticalAlignmentReporter();
        //    vRep.ProfileElementReport();
        //    }

        ///* OPENROADADDIN -> REPORT -> ACTIVESTATIONELEVATION
        ///*------------------------------------------------------------------------------------**/
        //internal void ActiveStationElevationAtInterval()
        //    {
        //    VerticalAlignmentReporter vRep = new VerticalAlignmentReporter();
        //    vRep.ActiveStationElevationAtIntervalReport();
        //    }

        ///* OPENROADADDIN -> REPORT -> CORRIDORS
        ///*------------------------------------------------------------------------------------**/
        //internal void CorridorReport()
        //    {
        //    CorridorReporter cRep = new CorridorReporter();
        //    cRep.ReportAllCorridors();
        //    }

        ///* OPENROADADDIN -> REPORT -> STATIONOFFSETELEVATION
        ///*------------------------------------------------------------------------------------**/
        //internal void StationOffsetElevation()
        //    {
        //    TerrainReporter tRep = new TerrainReporter();
        //    tRep.StationOffsetElevation();
        //    }

        ///* OPENROADADDIN -> REPORT -> DRAPELINEATINTERVAL
        ///*------------------------------------------------------------------------------------**/
        //internal void DrapeLineAtInterval()
        //    {
        //    TerrainReporter tRep = new TerrainReporter();
        //    tRep.DrapeLineAtInterval();
        //    }

        ///* OPENROADADDIN -> REPORT -> QQCHECKER
        ///*------------------------------------------------------------------------------------**/
        //internal void QQCheckerReport()
        //    {
        //    QQChecker.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> REPORT -> XSCUTPOINTS
        ///* OPENROADADDIN -> REPORT -> XSCUTPOINTS -> PICKCORRIDOR
        ///*------------------------------------------------------------------------------------**/
        //internal void XSCutPointsReportPickCorridor()
        //    {
        //    XSCutPointReporter.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> REPORT -> XSCUTPOINTS -> ALLCORRIDORS
        ///*------------------------------------------------------------------------------------**/
        //internal void XSCutPointsReportAllCorridors()
        //    {
        //    XSCutPointReporter cpRep = new XSCutPointReporter();
        //    cpRep.ReportAllXSCutPointsAllCorridors();
        //    }



        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS
        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> LINE
        ///*------------------------------------------------------------------------------------**/
        //internal void HorizontalAlignmentsCreator()
        //    {
        //    HorizontalAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> ARC
        ///*------------------------------------------------------------------------------------**/
        //internal void ArcCreators()
        //    {
        //    ArcCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> SPIRAL
        ///*------------------------------------------------------------------------------------**/
        //internal void SpiralCreators()
        //    {
        //    SpiralCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //internal void ComplexAlignmentCreators()
        //    {
        //    ComplexAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> PI ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //internal void PIAlignmentCreators()
        //    {
        //    PIAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> CURB RETURNS
        ///*------------------------------------------------------------------------------------**/
        //internal void CurbReturnsCreators()
        //    {
        //    HorizontalCurbReturns.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS
        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> LINE
        ///*------------------------------------------------------------------------------------**/
        //internal void VerticalLineCreators()
        //    {
        //    VerticalAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> PARABOLA
        ///*------------------------------------------------------------------------------------**/
        //internal void VerticalParabolaCreators()
        //    {
        //    VerticalParabolaCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //internal void VerticalComplexAlignmentCreators()
        //    {
        //    VerticalComplexAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //internal void CorridorItemsComplexAlignmentCreators()
        //    {
        //    CorridorItemsComplexAlignmentCreator.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //internal void CorridorItemsComplexAlignmentModifier()
        //    {
        //    CorridorItemsComplexAlignmentModify.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> FEATUREDEFINITION
        ///*------------------------------------------------------------------------------------**/
        //internal void CorridorItemsFeatureDefinitionSetter()
        //    {
        //    CorridorItemsFeatureDefinitionSet.InstallNewInstance();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> PROFILE
        ///*------------------------------------------------------------------------------------**/
        //internal void CorridorItemsProfileCreators()
        //    {
        //    CorridorItemsProfileCreator.InstallNewInstance();
        //    }

        // /* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> CORRIDOR
        // /*------------------------------------------------------------------------------------**/
        // internal void CorridorItemsCorridorCreators()
        //     {
        //     CorridorItemsCorridorCreator.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> TemplateDrop
        // /*------------------------------------------------------------------------------------**/
        // internal void CorridorItemsTemplateDropCreators(string unparsed)
        //     {
        //     CorridorItemsTemplateDropCreator.InstallNewInstance(unparsed);
        //     }

        // /* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> KeyStation
        // /*------------------------------------------------------------------------------------**/
        // internal void CorridorItemsKeyStationCreators(string unparsed)
        //     {
        //     CorridorItemsKeyStationCreator.InstallNewInstance(unparsed);
        //     }

        // /* OPENROADADDIN -> CREATE -> CIVILCELL PLACE
        // /*------------------------------------------------------------------------------------**/
        // internal void CivilCellCreators()
        //     {
        //     CivilCellCreator.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> CREATE -> SUPERELEVATION -> PLACE
        // /*------------------------------------------------------------------------------------**/
        // internal void SuperElevationCreators()
        //     {
        //     SuperElevationCreator.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> CREATE -> SUPERELEVATION -> ASSIGN
        // /*------------------------------------------------------------------------------------**/
        // internal void SuperElevationAssigns()
        //     {
        //     SuperElevationAssign.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> CREATE -> CURVEWIDENING -> PLACE
        // /*------------------------------------------------------------------------------------**/
        // internal void CurveWideningCreators()
        //     {
        //     CurveWideningCreator.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> CREATE -> FORESIGHTPOINT -> FROMOCCUPIEDPOINT
        ///*------------------------------------------------------------------------------------**/
        // internal void ForesightPointCreators()
        //     {
        //     ForesightPointCreator.InstallNewInstance();
        //     }

        // /* OPENROADADDIN -> ANNOTATION -> REGISTER 
        // /*------------------------------------------------------------------------------------**/
        // internal void AnnotationRegisters()
        //     {
        //     AnnotationRegister.AnnotationDefinitionRegister();
        //     }

        // /* OPENROADADDIN -> ANNOTATION -> UNREGISTER 
        // /*------------------------------------------------------------------------------------**/
        // internal void AnnotationUnRegisters()
        //     {
        //     AnnotationRegister.AnnotationDefinitionUnRegister();
        //     }

        // /* OPENROADADDIN -> UTILITY -> TRACKCURSOR
        // /*------------------------------------------------------------------------------------**/
        // internal void LaunchTrackCursor()
        //     {
        //     TrackCursor.InstallNewInstance();
        //     }
    }
}
