/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/DataDisplayHelper.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.CifNET.LinearGeometry;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.GeometryNET;

namespace OpenRoadAddin
{
    public class DataDisplayHelper
        {
        public enum DisplayType { ReportDialog, Annotation }
        
        public bool IsReportDialog { get { return (m_displayType == DisplayType.ReportDialog);  } }
        public bool IsAnnotation { get { return (m_displayType == DisplayType.Annotation);  } }

        private DisplayType m_displayType;
        private ReportResultsForm m_dialog;
        private AnnotationHelper m_annotation;

        // Constructor and Setup / Finish ------------------------- */
        public static DataDisplayHelper CreateForReportDialog()
            {
            return new DataDisplayHelper(DisplayType.ReportDialog);
            }

        public static DataDisplayHelper CreateForAnnotation()
            {
            return new DataDisplayHelper(DisplayType.Annotation);
            }

        private DataDisplayHelper(DisplayType type)
            {
            m_displayType = type;
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog = new ReportResultsForm();
            else
                m_annotation = new AnnotationHelper(Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel());
            }
        
        public void SetAnnotationOrigin(DPoint3d origin)
            {
            if(IsAnnotation)
                m_annotation.SetAnnotationOrigin(origin);
            }

        public void SetAnnotationOrigin(LinearPoint origin)
            {
            if (IsAnnotation)
                m_annotation.SetAnnotationOrigin(new DPoint3d(origin.Coordinates.X, origin.Coordinates.Y));
            }

        public void Finished()
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.Finished();
            else
                m_annotation.FinishAnnotation();
            }

        // Formatting 
        public string NewLineCharacter
            {
            get
                {
                if (m_displayType == DisplayType.ReportDialog)
                    return m_dialog.NewLineCharacter;
                else
                    return m_annotation.NewLineString;
                }
            }

        // Pass Data to Correct Display Function --------- */
        // (ReportResultsForm or AnnotationHelper)
        public void AddHeader(string text)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.AddHeader(text);
            else
                m_annotation.AddAnnotation(text);
            }

        public void AddSubheader(string text)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.AddSubheader(text);
            else
                m_annotation.AddAnnotation(text);
            }

        public void AddLine(string text)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.AddLine(text);
            else
                m_annotation.AddAnnotation(text);
            }

        public void PrintValueTable(Dictionary<string, string> values)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.PrintValueTable(null, values);
            else
                m_annotation.AddAnnotation(null, values);
            }

        public void PrintValueTable(List<string> headerValues, Dictionary<string, string> values)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.PrintValueTable(headerValues, values);
            else
                m_annotation.AddAnnotation(headerValues, values);
            }

        public void PrintValueTable(List<string> headerValues, List<string> values)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.PrintValueTable(headerValues, values);
            else
                m_annotation.AddAnnotation(headerValues, values);
            }


        // ReportResultsForm Only ------------------------ */
        public void SetReportName(string text)
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.SetReportName(text);
            }

        public void NewLine()
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.NewLine();
            }

        public void NewParagraph()
            {
            if (m_displayType == DisplayType.ReportDialog)
                m_dialog.NewParagraph();
            }        

        /*------------------------------------------------------------------------------------**/
        /* AnnotationHelper Class -- Handles printing data as annotations in DGN 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        internal class AnnotationHelper
            {
            public string NewLineString = "_ANNOTATIONHELPER_NEWLINESTRING_";

            private DgnModel m_dgnModel;
            private DPoint3d m_origin = new DPoint3d();
            private TextBlock m_currentText;

            // Setup and Finish ------------------------------ */
            public AnnotationHelper(DgnModel model)
                {
                m_dgnModel = model;
                }

            public void FinishAnnotation()
                {
                if (m_currentText != null)
                    AddAnnotationToModel();
                }

            public void SetAnnotationOrigin(DPoint3d origin)
                {
                if (m_origin.X == origin.X && m_origin.Y == origin.Y)
                    return;

                // Store new origin 
                m_origin = origin;

                // Convert to correct units
                ModelInfo modelInfo = m_dgnModel.GetModelInfo();
                double uorsPerMeter = modelInfo.UorPerMeter;
                m_origin.X = origin.X * uorsPerMeter;
                m_origin.Y = origin.Y * uorsPerMeter;

                // Start new TextBlock annotation
                if (m_currentText != null)
                    AddAnnotationToModel();
                m_currentText = CreateTextBlock();
                }

            // Populate Annotations with Given Data ---------- */
            internal void AddAnnotation(string text)
                {
                AddTextToAnnotation(text);
                }

            internal void AddAnnotation(List<string> headerValues, Dictionary<string, string> values)
                {
                if(headerValues != null)
                    {
                    foreach (string s in headerValues)
                        {
                        m_currentText.AppendText(s);
                        if (s != headerValues.Last())
                            m_currentText.AppendTab();
                        }
                    }
                
                foreach (KeyValuePair<string, string> kvp in values)
                    {
                    AddTextToAnnotation(kvp.Key);
                    m_currentText.AppendTab();
                    AddTextToAnnotation(kvp.Value);
                    m_currentText.AppendLineBreak();
                    }
                }

            internal void AddAnnotation(List<string> headerValues, List<string> values)
                {
                if (headerValues != null)
                    {
                    foreach (string s in headerValues)
                        {
                        m_currentText.AppendText(s);
                        if (s != headerValues.Last())
                            m_currentText.AppendTab();
                        }
                    }

                foreach (string s in values)
                    {
                    AddTextToAnnotation(s);
                    m_currentText.AppendLineBreak();
                    }
                }

            internal void AddTextToAnnotation(string text)
                {
                string[] lines;

                // Check for line breaks and split the text with them 
                if (text.Contains(NewLineString))
                    lines = text.Split(new string[] { NewLineString }, StringSplitOptions.None);
                else
                    {
                    lines = new string[1];
                    lines[0] = text;
                    }

                // Cycle through lines (or single line, if no breaks)
                foreach(string line in lines)
                    {
                    // If line has columns, add them with tabs
                    if (line.Contains("|"))
                        {
                        string[] tabSplit = text.Split('|');
                        foreach (string s in tabSplit)
                            {
                            m_currentText.AppendText(s);

                            if (s != tabSplit.Last())
                                m_currentText.AppendTab();
                            }
                        }

                    // If line doesn't have column, add normally
                    else
                        m_currentText.AppendText(line);

                    if(line != lines.Last())
                        m_currentText.AppendLineBreak();
                    }
                }

            // Create / Add Annotation (As TextBlocks) ------- */
            private TextBlock CreateTextBlock()
                {
                DgnFile dgnFile = m_dgnModel.GetDgnFile();
                DgnTextStyle style = DgnTextStyle.GetSettings(dgnFile);
                TextBlock tb = new TextBlock(style, m_dgnModel);
                TextBlockProperties props = new TextBlockProperties(m_dgnModel);
                tb.SetProperties(props);
                tb.SetUserOrigin(m_origin);
                return tb;
                }
            
            private void AddAnnotationToModel()
                {
                TextHandlerBase thb = TextElement.CreateElement(null, m_currentText);

                // Use active text color
                ElementPropertiesSetter pSetter = new ElementPropertiesSetter();
                pSetter.SetColor((uint)Bentley.MstnPlatformNET.Settings.GetActiveColor().Index);
                pSetter.Apply(thb);

                thb.AddToModel();
                }
            }
        }
    }
