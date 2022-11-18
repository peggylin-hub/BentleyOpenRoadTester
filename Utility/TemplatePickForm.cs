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
using BMW = Bentley.MstnPlatformNET.WinForms;


namespace OpenRoadAddin.Utility
    {
    public partial class TemplatePickForm : BMW.Adapter
        {
        private Bentley.CifNET.GeometryModel.SDK.Edit.TemplateLibrary m_templateLibary;
        private Bentley.CifNET.GeometryModel.SDK.Edit.TemplateDefinition m_selectedTemplate;
        public TemplatePickForm(string strTemplateLibrary)
            {
            InitializeComponent();
            m_templateLibary = Bentley.CifNET.GeometryModel.SDK.Edit.TemplateLibrary.Load(strTemplateLibrary);
            MicrostationDock();
            }

        private void MicrostationDock()
            {
            // Setup the form for MicroStation
            this.Name = "Pick Template";
            this.Text = "Pick Template";
            // Attach the form to MicroStation
            this.AttachAsTopLevelForm(OpenRoadTester.Instance(), true);
            this.AllowTransparency = true;
            this.NETDockable = true;
            //Size minSize = new Size(300, 150);
            //this.ClientSize = this.MinimumSize;
            }


        public Bentley.CifNET.GeometryModel.SDK.Edit.TemplateDefinition SelectedTemplate
            {
            get
                {
                return m_selectedTemplate;
                }
            }
        private void OnTemplateLibaryChanged()
            {
            if(null == m_templateLibary)
                {
                return;
                }
            txtTemplateLibrary.Text = m_templateLibary.LibraryPath;
            m_selectedTemplate = m_templateLibary.ActiveTemplate;
            bool bret = InitializeTemplateTreeViewData();
            OnActiveTemplateChanged();
            }

        private void OnActiveTemplateChanged()
            {
            if(null != m_selectedTemplate)
                {
                //Users need to implement a preview of the template here themselves in plPreview control.
                }
            }
        private bool InitializeTemplateTreeViewData()
            {
            trTemplates.Nodes.Clear();
            if(null == m_templateLibary)
                {
                return false;
                }

            TreeNode treeParentNode = trTemplates.Nodes.Add(m_templateLibary.LibraryPath);
            InitializeTemplateTreeViewData(m_templateLibary.RootCategory, treeParentNode);
            return true;
            }

        private void InitializeTemplateTreeViewData(Bentley.CifNET.GeometryModel.SDK.Edit.Category parentCategory, TreeNode treeParentNode)
            {
            foreach (var category in parentCategory.Categories)
                {
                TreeNode newTreeNode = treeParentNode.Nodes.Add(category.Name);
                newTreeNode.Tag = category;
                InitializeTemplateTreeViewData(category, newTreeNode);
                }

            foreach(var template in parentCategory.Templates)
                {
                TreeNode newTreeNode = treeParentNode.Nodes.Add(template.Name);
                newTreeNode.Tag = template;
                }
            }
        private TreeNode findNode(TreeNode parentNode, string text)
            {
            foreach (TreeNode node in parentNode.Nodes)
                {
                if (text == node.Text)
                    {
                    return node;
                    }
                }
            return null;
            }
        
        private void SelectActiveTemplateNode()
            {
            if(null == m_selectedTemplate)
                {
                return;
                }
            string strPath = m_selectedTemplate.GetPath();
            string[] nodeTexts = strPath.Split('\\');
            TreeNode parentNode = trTemplates.Nodes[0];
            TreeNode activeNode = null;
            foreach(string strText in nodeTexts)
                {
                activeNode = findNode(parentNode, strText);
                if(null == activeNode)
                    {
                    return;
                    }
                parentNode = activeNode;
                }
            trTemplates.SelectedNode = activeNode;
            }

        private void TemplatePickForm_Load(object sender, EventArgs e)
            {
            OnTemplateLibaryChanged();
            SelectActiveTemplateNode();
            }

        private void btnBrowse_Click(object sender, EventArgs e)
            {
            System.Windows.Forms.OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Template Libary Files(*.itl)|*.itl|Xml Files(*.xml)|*.xml|All Files(*.*)|*.*";
            openFileDlg.RestoreDirectory = true;
            if(DialogResult.OK == openFileDlg.ShowDialog())
                {
                string strTemplateLibary = openFileDlg.FileName;
                if(m_templateLibary.LibraryPath != strTemplateLibary)
                    {
                    m_templateLibary = Bentley.CifNET.GeometryModel.SDK.Edit.TemplateLibrary.Load(strTemplateLibary);
                    OnTemplateLibaryChanged();
                    }
                }
            }

        private void btnOK_Click(object sender, EventArgs e)
            {
            if (null == m_selectedTemplate)
                {
                System.Windows.Forms.MessageBox.Show("Please select a template!");
                return;
                }
            DialogResult = DialogResult.OK;
            this.Close();
            }

        private void btnCancel_Click(object sender, EventArgs e)
            {
            DialogResult = DialogResult.Cancel;
            this.Close();
            }

        private void trTemplates_AfterSelect(object sender, TreeViewEventArgs e)
            {
            TreeNode node = e.Node;
            m_selectedTemplate = e.Node.Tag as Bentley.CifNET.GeometryModel.SDK.Edit.TemplateDefinition;
            OnActiveTemplateChanged();
            }

        private void plPreview_SizeChanged(object sender, EventArgs e)
            {
            OnActiveTemplateChanged();
            }
        }
    }
