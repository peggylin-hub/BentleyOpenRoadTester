/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/ReportResultsForm.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRoadAddin
{
    public enum ReportDataType { header, label, data };
    public struct ReportData
        {
        public bool newRow;
        public string data;
        public ReportDataType type;
        }
    public partial class ReportResultsForm : Form
        {
        public string NewLineCharacter { get { return "</br>"; } }
        public string NewColumnCharacter { get { return "|"; } }

        private StringBuilder m_reportHtml = new StringBuilder();

        /*------------------------------------------------------------------------------------**/
        /* Dialog Functions / Setup
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public ReportResultsForm()
            {
            InitializeComponent();
            m_reportHtml.Append("<html><body style='font-family:arial;font-size: 13px;'>");         
            }

        public void Finished()
            {
            m_reportHtml.Append("</body></html>");
            reportViewer.DocumentText = m_reportHtml.ToString();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            }

        public void SetReportName(string reportName)
            {
            labelReportName.Text = reportName;
            this.Text = reportName;
            }

        /*------------------------------------------------------------------------------------**/
        /* Printing Text
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void AddHeader(string text)
            {
            m_reportHtml.Append("<h3 style='background:#eee; padding: 5px;'>" + text + "</h3>");
            }

        public void AddSubheader(string text)
            {
            m_reportHtml.Append("<h4 style='padding: 5px;'>" + text + "</h4>");

            }

        public void AddLine(string text)
            {
            m_reportHtml.Append(text + NewLineCharacter);
            }

        /*------------------------------------------------------------------------------------**/
        /* Formatting
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void NewLine()
            {
            m_reportHtml.Append(NewLineCharacter);
            }

        public void NewParagraph()
            {
            m_reportHtml.Append("</p> <p>");
            }

        /*------------------------------------------------------------------------------------**/
        /* Print property pairs into into HTML table 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public void PrintValueTable(Dictionary<string, string> values)
            {
            PrintValueTable(null, values);
            }

        public void PrintValueTable(List<string> headerValues, Dictionary<string, string> values)
            {
            string labelCell = "<td style='font-size: 13px; padding: 5px 10px;' valign='top' width=250> <b>{0}</b> </td>";
            string valueCell = "<td style='font-size: 13px; padding: 5px 10px;'> {0} </td>";
            string headerCell = "<th style='font-size: 15px; padding: 5px 10px; font-weight: bold; text-align: left;'> {0} </th>";
            bool labelHeaders = true;

            m_reportHtml.Append("<p><table style='border:1px solid #777; margin:10px;' width='90%'>");

            // Print headers (if there are any)
            if(headerValues != null && headerValues.Count > 0)
                {
                labelHeaders = false;
                m_reportHtml.Append("<tr>");
                foreach (string header in headerValues)
                    m_reportHtml.Append(string.Format(headerCell, header));
                m_reportHtml.Append("</tr>");                
                }

            // Print list of property label / value pairs
            foreach (KeyValuePair<string, string> pair in values)
                {
                m_reportHtml.Append("<tr>");
                if(labelHeaders)
                    m_reportHtml.Append(string.Format(labelCell, pair.Key));
                else
                    m_reportHtml.Append(string.Format(valueCell, pair.Key));

                if (pair.Value.Contains("|"))
                    {
                    string[] multipleValues = pair.Value.Split('|');
                    foreach (string s in multipleValues)
                        m_reportHtml.Append(string.Format(valueCell, s));
                    }
                else
                    m_reportHtml.Append(string.Format(valueCell, pair.Value));

                m_reportHtml.Append("</tr>");
                }

            m_reportHtml.Append("</table></p>");
            }

        public void PrintValueTable(List<string> headerValues, List<string> values)
            {
            string valueCell = "<td style='font-size: 13px; padding: 5px 10px;'> {0} </td>";
            string headerCell = "<th style='font-size: 15px; padding: 5px 10px; font-weight: bold; text-align: left;'> {0} </th>";

            m_reportHtml.Append("<p><table style='border:1px solid #777; margin:10px;' width='90%'>");

            // Print headers (if there are any)
            if (headerValues != null && headerValues.Count > 0)
                {
                m_reportHtml.Append("<tr>");
                foreach (string header in headerValues)
                    m_reportHtml.Append(string.Format(headerCell, header));
                m_reportHtml.Append("</tr>");
                }

            // Print list of property values
            foreach (string value in values)
                {
                m_reportHtml.Append("<tr>");

                if (value.Contains("|"))
                    {
                    string[] multipleValues = value.Split('|');
                    foreach (string s in multipleValues)
                        m_reportHtml.Append(string.Format(valueCell, s));
                    }
                else
                    m_reportHtml.Append(string.Format(valueCell, value));

                m_reportHtml.Append("</tr>");
                }

            m_reportHtml.Append("</table></p>");
            }

        public void PrintReportData(List<ReportData> reportData)
            {
            string labelCell = "<td style='font-size: 13px; padding: 5px 10px;' valign='top' width=250> <b>{0}</b> </td>";
            string dataCell = "<td style='font-size: 13px; padding: 5px 10px;'> {0} </td>";
            string headerCell = "<th style='font-size: 15px; padding: 5px 10px; font-weight: bold; text-align: left;'> {0} </th>";

            m_reportHtml.Append("<p><table style='border:1px solid #777; margin:10px;' width='90%'>");
            m_reportHtml.Append("<tr>");

            foreach (ReportData data in reportData)
                {
                if (data.newRow)
                    m_reportHtml.Append("</tr><tr>");

                switch (data.type)
                    {
                    case ReportDataType.header:
                        m_reportHtml.Append(string.Format(headerCell, data.data));
                        break;
                    case ReportDataType.label:
                        m_reportHtml.Append(string.Format(labelCell, data.data));
                        break;
                    case ReportDataType.data:
                        m_reportHtml.Append(string.Format(dataCell, data.data));
                        break;
                    default:
                        break;
                    }
                }

            m_reportHtml.Append("</tr></table></p>");
            }
        }
    }
