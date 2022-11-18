/*--------------------------------------------------------------------------------------+
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
using System.Threading.Tasks;
using System.Windows.Forms;

using Bentley.DgnPlatformNET;
using Bentley.MstnPlatformNET.CursorPrompt;

/// ///////////////////////////////////////////////////
//using MYFORM = System.Windows.Forms.Form;
using MYFORM = Bentley.MstnPlatformNET.CursorPrompt.CursorTrackingDialog;
/// ///////////////////////////////////////////////////

namespace OpenRoadAddin.Utility
    {
    /// <summary>
    /// CursorLabelForm
    /// </summary>
    public partial class CursorLabelForm : MYFORM
        {

        #region Constructor

        /// <summary>
        /// CursorLabelForm
        /// </summary>
        /// <param name="addIn"></param>
        public CursorLabelForm(Bentley.ResourceManagement.IMatchLifetime addIn)
            : base(addIn)
            {
            InitializeComponent();
            }

        #endregion

        #region CursorTrackingDialog Overrides

        public override ushort Priority { get { return CursorTrackingDialog.PRIORITY_HIGH; } }
        public override bool WantsToBeVisible { get { return true; } }
        public override bool WantsFocus { get { return false; } }
        public override void SelectAllInFocusedField() { }
        public override void SetFocusToExtremityControlInTabOrder(bool forward) { }
        public override void ViewportChanged(Viewport cursorViewport)
            {
            this.Hide();
            this.BackColor = CursorTrackingDialogManager.Instance.BackgroundColor;
            this.ForeColor = CursorTrackingDialogManager.Instance.ContrastToBackgroundColor;
            }

        #endregion

        #region Methods

        private string GetTextString(List<string> list)
            {
            string str = string.Empty;
            string newLine = "\r\n";
            foreach (string s in list)
                str += s + newLine;
            return str;
            }

        /// <summary>
        /// SetLabel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetLabel(string name, string value)
            {
            if (this.BackColor != CursorTrackingDialogManager.Instance.BackgroundColor)
                this.BackColor = CursorTrackingDialogManager.Instance.BackgroundColor;
            if (this.ForeColor != CursorTrackingDialogManager.Instance.ContrastToBackgroundColor)
                this.ForeColor = CursorTrackingDialogManager.Instance.ContrastToBackgroundColor;

            this.LabelName.Text = name;
            this.LabelValue.Text = value;

            this.HostPanel.Size = this.HostPanel.PreferredSize;
            this.ClientSize = this.HostPanel.PreferredSize;
            }

        /// <summary>
        /// SetLabels
        /// </summary>
        /// <param name="names"></param>
        /// <param name="values"></param>
        public void SetLabels(List<string> names, List<string> values)
            {
            this.SetLabel(this.GetTextString(names), this.GetTextString(values));
            }

        #endregion

        }

    /// <summary>
    /// CursorLabelManager
    /// </summary>
    public class CursorLabelManager : IDisposable
        {

        #region Constructor

        /// <summary>
        /// CursorLabelManager
        /// </summary>
        public CursorLabelManager()
            {
            /// Needed to just create instance so viewport gets set
            if (CursorTrackingDialogManager.Instance != null)
                {
                }
            }

        #endregion

        #region Dispose

        ~CursorLabelManager()
            {
            this.Dispose(false);
            }

        private bool Disposed { get; set; } = false;
        protected virtual void Dispose(bool disposing)
            {
            if (!this.Disposed)
                {
                if (disposing)
                    {
                    /// Dispose managed resources here.
                    if (this.CursorLabelForm != null)
                        this.CursorLabelForm.Dispose();
                    this.CursorLabelForm = null;
                    }
                /// Dispose unmanaged resources here.
                }
            this.Disposed = true;
            }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
            {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            }

        #endregion

        #region Methods

        /// <summary>
        /// CursorLabelForm
        /// </summary>
        public CursorLabelForm CursorLabelForm { get; set; } = null;

        /// <summary>
        /// Hide
        /// </summary>
        public void Hide()
            {
            if (this.CursorLabelForm != null)
                this.CursorLabelForm.Dispose();
            this.CursorLabelForm = null;
            }

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Show(string name, string value)
            {
            if (this.CursorLabelForm == null)
                this.CursorLabelForm = new CursorLabelForm(OpenRoadTester.Instance());
            this.CursorLabelForm.SetLabel(name, value);
            }

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="names"></param>
        /// <param name="values"></param>
        public void Show(List<string> names, List<string> values)
            {
            if (this.CursorLabelForm == null)
                this.CursorLabelForm = new CursorLabelForm(OpenRoadTester.Instance());
            this.CursorLabelForm.SetLabels(names, values);
            }

        #endregion

        }
    }
