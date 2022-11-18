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
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using BMW = Bentley.MstnPlatformNET.WinForms;

namespace OpenRoadAddin.Utility
    {
    public partial class CivilCellTreeForm : BMW.Adapter
        {
        public Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo selectedCivil = new Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo();
        public CivilCellTreeForm()
            {
            InitializeComponent();
            AutoScroll = true;
            selectedCivil.SourceDGNPath = "";
            selectedCivil.SourceModelName = "Default";
            selectedCivil.CivilCellName = "";
            civilCellTreeView.Visible = false;
            MicrostationDock();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            if (!worker.IsBusy)
                {
                worker.RunWorkerAsync();
                }
            }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
            {
            System.Threading.Thread.Sleep(200);
            BackgroundWorker bw = sender as BackgroundWorker;
            bw.ReportProgress(10);
            }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
            InitTreeView();
            }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
            label1.Text = "Please Select A Civil Cell Template.";
            civilCellTreeView.Visible = true;
            }
        private void MicrostationDock()
            {
            // Setup the form for MicroStation
            this.Name = "CivilCellTreeForm";
            this.Text = "CivilCellTreeView";
            // Attach the form to MicroStation
            this.AttachAsTopLevelForm(OpenRoadTester.Instance(), true);
            this.AllowTransparency = true;
            this.NETDockable = true;
            Size minSize = new Size(350, 350);
            this.ClientSize = minSize;
            }
        public void InitTreeView()
            {
            // Load civil cell from libraries
            IEnumerable<Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo> libraryCivilCells = Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellEdit.GetLibraryCivilCellInfo();
            Dictionary<string, List<Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo>> libraryCivilCellsDic = new Dictionary<string, List<Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo>>();

            foreach (var civilCell in libraryCivilCells)
                {
                if (libraryCivilCellsDic.ContainsKey(civilCell.SourceDGNPath))
                    {
                    libraryCivilCellsDic[civilCell.SourceDGNPath].Add(civilCell);
                    }
                else
                    {
                    List<Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo> listCivilCell = new List<Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo>();
                    listCivilCell.Add(civilCell);
                    libraryCivilCellsDic.Add(civilCell.SourceDGNPath, listCivilCell);
                    }
                }

            foreach (var dic in libraryCivilCellsDic)
                {
                TreeNode treeNode = new TreeNode("Civil Cell Tree");
                treeNode.Tag = dic.Key;
                treeNode.Text = System.IO.Path.GetFileName(dic.Key);

                foreach (var civilCell in dic.Value)
                    {
                    TreeNode classNode = new TreeNode();
                    classNode.Tag = civilCell;
                    classNode.Text = civilCell.CivilCellName;
                    treeNode.Nodes.Add(classNode);
                    }

                // Add model node if contains civil cells
                if (treeNode.Nodes.Count > 0)
                    civilCellTreeView.Nodes.Add(treeNode);
                }
            civilCellTreeView.Visible = true;
            }
        private void civilCellTreeView_AfterSelect(object sender, TreeViewEventArgs e)
            {
            TreeView treeView = sender as TreeView;
            if (treeView != null && treeView.SelectedNode.Parent != null)
                {
                selectedCivil = treeView.SelectedNode.Tag as Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo;
                this.DialogResult = DialogResult.OK;
                this.Close();
                }
            }

        }
    }
