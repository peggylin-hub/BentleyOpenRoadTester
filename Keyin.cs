/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Keyin.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

namespace OpenRoadAddin
{
	/*=====================================================================================**/
	/* Required | Keyin Class            
    /*=====================================================================================**/
	// Interface between CommandTable.xml and OPENROADADDIN
	public sealed class Keyin
    {


        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS
        /*------------------------------------------------------------------------------------**/
        public static void CmdHorizontalAlignmentReport(string unparsed)
        {
            OpenRoadTester.Instance().HorizontalAlignmentReport(false);
        }

        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> ASANNOTATION
        /*------------------------------------------------------------------------------------**/
        public static void CmdHorizontalAlignmentAnnotation(string unparsed)
        {
            OpenRoadTester.Instance().HorizontalAlignmentReport(true);
        }

        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> ITEMTYPES
        /*------------------------------------------------------------------------------------**/
        public static void CmdHorizontalAlignmentItemTypes(string unparsed)
        {
            OpenRoadTester.Instance().HorizontalAlignmentItemTypes();
        }

        /* OPENROADADDIN -> REPORT -> HORIZONTALALIGNMENTS -> PICKALIGNMENT
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static void CmdPickAlignment(string unparsed)
        {
            OpenRoadTester.Instance().PickAlignment();
        }

        ///* OPENROADADDIN -> REPORT -> STATIONELEVATIONS
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdStationElevationsReport(string unparsed)
        //    {
        //    OpenRoadTester.Instance().StationElevationsReport();
        //    }

        ///* OPENROADADDIN -> REPORT -> PROFILEELEMENTS
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdProfileElementReport(string unparsed)
        //    {
        //    OpenRoadTester.Instance().ProfileElementReport();
        //    }


        ///* OPENROADADDIN -> REPORT -> ACTIVESTATIONELEVATION
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdActiveStationElevationAtInterval(string unparsed)
        //    {
        //    OpenRoadTester.Instance().ActiveStationElevationAtInterval();
        //    }

        /////* OPENROADADDIN -> REPORT -> CORRIDORS
        /////*------------------------------------------------------------------------------------**/
        ////public static void CmdCorridorReport(string unparsed)
        ////    {
        ////    OpenRoadTester.Instance().CorridorReport();
        ////    }

        /////* OPENROADADDIN -> REPORT -> STATIONOFFSETELEVATION
        /////*------------------------------------------------------------------------------------**/
        ////public static void CmdStationOffsetElevation(string unparsed)
        ////    {
        ////    OpenRoadTester.Instance().StationOffsetElevation();
        ////    }

        ///* OPENROADADDIN -> REPORT -> DRAPELINEATINTERVAL
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdDrapeLineAtInterval(string unparsed)
        //    {
        //    OpenRoadTester.Instance().DrapeLineAtInterval();
        //    }

        ///* OPENROADADDIN -> REPORT -> QQCHECKER
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdQQChecker(string unparsed)
        //    {
        //    OpenRoadTester.Instance().QQCheckerReport();
        //    }

        ///* OPENROADADDIN -> REPORT -> XSCUTPOINTREPORT -> PICKCORRIDOR
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdXSCutPointReportPickCorridor(string unparsed)
        //    {
        //    OpenRoadTester.Instance().XSCutPointsReportPickCorridor();
        //    }

        ///* OPENROADADDIN -> REPORT -> XSCUTPOINTREPORT -> ALLCORRIDORS
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdXSCutPointReportAllCorridors(string unparsed)
        //    {
        //    OpenRoadTester.Instance().XSCutPointsReportAllCorridors();
        //    }



        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS
        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> LINE
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsLine(string unparsed)
        //    {
        //    OpenRoadTester.Instance().HorizontalAlignmentsCreator();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> ARC
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsArc(string unparsed)
        //    {
        //    OpenRoadTester.Instance().ArcCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> SPIRAL
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsSpiral(string unparsed)
        //    {
        //    OpenRoadTester.Instance().SpiralCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsComplexAlignment(string unparsed)
        //    {
        //    OpenRoadTester.Instance().ComplexAlignmentCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> PI ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsPIAlignment(string unparsed)
        //    {
        //    OpenRoadTester.Instance().PIAlignmentCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> HORIZONTALALIGNMENTS -> CURB RETURNS
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateHorizontalAlignmentsCurbReturns(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CurbReturnsCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS
        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> LINE
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateVerticalAlignmentsLine(string unparsed)
        //    {
        //    OpenRoadTester.Instance().VerticalLineCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> PARABOLA
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateVerticalAlignmentsParabola(string unparsed)
        //    {
        //    OpenRoadTester.Instance().VerticalParabolaCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> VERTICALALIGNMENTS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateVerticalAlignmentsComplexAlignment(string unparsed)
        //    {
        //    OpenRoadTester.Instance().VerticalComplexAlignmentCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCorridorItemsComplexAlignment(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CorridorItemsComplexAlignmentCreators();
        //    }

        //        /* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> COMPLEX ALIGNMENT
        ///*------------------------------------------------------------------------------------**/
        //        public static void CmdCreateCorridorItemsModifyAlignment(string unparsed)
        //            {
        //            OpenRoadTester.Instance().CorridorItemsComplexAlignmentModifier();
        //            }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> SETFEATUREDEFINITION
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCorridorItemsSetFeatureDefinition(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CorridorItemsFeatureDefinitionSetter();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> PROFILE
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCorridorItemsProfile(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CorridorItemsProfileCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> CORRIDOR
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCorridorItemsCorridor(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CorridorItemsCorridorCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> TEMPLATEDROP
        //   /*------------------------------------------------------------------------------------**/
        //   public static void CmdCreateCorridorItemsTemplateDrop(string unparsed)
        //       {
        //       OpenRoadTester.Instance().CorridorItemsTemplateDropCreators(unparsed);
        //       }

        ///* OPENROADADDIN -> CREATE -> CORRIDORITEMS -> KEYSTATION
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCorridorItemsKeyStation(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CorridorItemsKeyStationCreators(unparsed);
        //    }

        /////* OPENROADADDIN -> CREATE -> CIVILCELL PLACE
        /////*------------------------------------------------------------------------------------**/
        ////public static void CmdCreateCivilCellPlace(string unparsed)
        ////    {
        ////    OpenRoadTester.Instance().CivilCellCreators();
        ////    }

        ///* OPENROADADDIN -> CREATE -> SUPERELEVATION -> PLACE
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateSuperElevation(string unparsed)
        //    {
        //    OpenRoadTester.Instance().SuperElevationCreators();
        //    }

        ///* OPENROADADDIN -> CREATE -> SUPERELEVATION -> ASSIGN
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdAssignSuperElevation(string unparsed)
        //    {
        //    OpenRoadTester.Instance().SuperElevationAssigns();
        //    }        

        ///* OPENROADADDIN -> CREATE -> CURVEWIDENING -> PLACE
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdCreateCurveWidening(string unparsed)
        //    {
        //    OpenRoadTester.Instance().CurveWideningCreators();
        //    }

        // /* OPENROADADDIN -> CREATE -> FORESIGHTPOINT -> FROMOCCUPIEDPOINT
        ///*------------------------------------------------------------------------------------**/
        // public static void CmdCreateForesightPointFromOccupiedPoint(string unparsed)
        //     {
        //     OpenRoadTester.Instance().ForesightPointCreators();
        //     }

        ///* OPENROADADDIN -> ANNOTATION -> REGISTER 
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdAnnotationRegister(string unparsed)
        //    {
        //    OpenRoadTester.Instance().AnnotationRegisters();
        //    }

        ///* OPENROADADDIN -> ANNOTATION -> UNREGISTER 
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdAnnotationUnRegister(string unparsed)
        //    {
        //    OpenRoadTester.Instance().AnnotationUnRegisters();
        //    }

        ///* OPENROADADDIN -> UTILITY -> TRACKCURSOR
        ///*------------------------------------------------------------------------------------**/
        //public static void CmdTrackCursor(string unparsed)
        //    {
        //    OpenRoadTester.Instance().LaunchTrackCursor();
        //    }
    }
}

