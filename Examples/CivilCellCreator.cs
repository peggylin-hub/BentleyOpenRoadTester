/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Examples/CivilCellCreator.cs $
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK;

namespace OpenRoadAddin
{
    class CivilCellCreator : DgnElementSetTool
        {
        private Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo sourceCivil = new Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellInfo();
        private List<Element> m_elements = new List<Element>();

		/*----------------------------------------------------------------------------------------------**/
		/* Write Function | The user is prompted to select a civil cell template from the library.Then select
         *                  a number of alignments on which to place civil cell. The number depends on the
         *                  civil cell template you selected.
        /*--------------+---------------+---------------+---------------+---------------+----------------*/
		private bool PlaceCivilCell()
		{
			bool res = false;

			Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit con = Bentley.CifNET.SDK.Edit.ConsensusConnectionEdit.GetActive();

			List<KeyValuePair<Bentley.CifNET.GeometryModel.SDK.Alignment, bool>> alignmentsAndReverse = new List<KeyValuePair<Bentley.CifNET.GeometryModel.SDK.Alignment, bool>>();
			foreach (Element elem in m_elements)
			{
				Bentley.CifNET.GeometryModel.SDK.Alignment alignment = Bentley.CifNET.GeometryModel.SDK.Alignment.CreateFromElement(con, elem);
				if (alignment != null)
				{
					KeyValuePair<Bentley.CifNET.GeometryModel.SDK.Alignment, bool> elePair = new KeyValuePair<Bentley.CifNET.GeometryModel.SDK.Alignment, bool>(alignment, true);
					alignmentsAndReverse.Add(elePair);
				}
			}

			if (alignmentsAndReverse.Count > 0)
			{
				con.StartTransientMode();
				Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellEdit civilcell = Bentley.CifNET.GeometryModel.SDK.Edit.CivilCellEdit.CreateCivilCellElement(con, sourceCivil, alignmentsAndReverse);
				if (civilcell != null)
				{
					res = true;
				}

				con.PersistTransients();
			}

			return res;
		}

		private void GetSourceCivilCell()
            {
            NotificationManager.OutputPrompt("Select a civil cell template.");
            Utility.CivilCellTreeForm treeForm = new Utility.CivilCellTreeForm();
            treeForm.ShowDialog();
            sourceCivil = treeForm.selectedCivil;
            }
        protected override void OnPostInstall()
            {
            GetSourceCivilCell();
            NotificationManager.OutputPrompt("Select first alignment.");
            base.BeginPickElements();
            }
        protected override bool OnDataButton(DgnButtonEvent ev)
            {
            HitPath hitPath = DoLocate(ev, true, 1);

			Bentley.DgnPlatformNET.Elements.Element selectedElement = null;
			if (hitPath != null)
			{
				selectedElement = hitPath.GetHeadElement();
			}
            
            if (selectedElement != null)
                {
                m_elements.Add(selectedElement);
                NotificationManager.OutputPrompt("Select next alignment.");
                }

            if (m_elements.Count != 0 && m_elements.Count == sourceCivil.ExternalRefListCount)
                {
                bool result = PlaceCivilCell();
                m_elements.Clear();
                if (result)
                    {
                    NotificationManager.OutputPrompt("Command complete. Select first alignment or right click to restart the command.");
                    }
                else
                    {
                    NotificationManager.OutputPrompt("Failed to place civil cell! Right click to restart the command.");
                    }
                }

            return false;
            }

        protected override bool OnPostLocate(HitPath path, out string cantAcceptReason)
            {
            //checks that hitpath is not null
            if (path == null)
                {
                cantAcceptReason = "HitPath is null.";
                return false;
                }

            //checks that the cursor element is not null
            Element element = path.GetCursorElement();
            if (element == null)
                {
                cantAcceptReason = "There is no element at cursor.";
                return false;
                }

            if (element.ElementType != MSElementType.Line && element.ElementType != MSElementType.LineString && element.ElementType != MSElementType.ComplexString)
                {
                cantAcceptReason = "This is not a civil element.";
                return false;
                }

            Bentley.CifNET.SDK.ConsensusConnection con = ConsensusConnectionEdit.GetActive();
            if (con == null)
                {
                cantAcceptReason = "There was an error connecting to the Civil SDK model.";
                return false;
                }
                

            Alignment al = (element.ParentElement == null) ? Alignment.CreateFromElement(con, element) : Alignment.CreateFromElement(con, element.ParentElement);
            if (al == null || al.ActiveProfile == null)
                {
                cantAcceptReason = "This is not a civil element.";
                }

            foreach (Element elem in m_elements)
                {
                if (elem.ElementId == element.ElementId)
                    {
                    cantAcceptReason = "Line has been selected.";
                    return false;
                    }
                }

            cantAcceptReason = System.String.Empty;
            return true;
            }
        protected override bool OnResetButton(DgnButtonEvent ev)
            {
            InstallNewInstance();
            return true;
            }
        protected override void OnRestartTool()
            {
            InstallNewInstance();
            }
        public override StatusInt OnElementModify(Element element)
            {
            return StatusInt.Error;
            }
        public override StatusInt OnPreElementModify(Element element)
            {
            return StatusInt.Success;
            }
        protected override bool IsModifyOriginal()
            {
            return false;
            }
        public static void InstallNewInstance()
            {
            CivilCellCreator cmd = new CivilCellCreator();
            cmd.InstallTool();
            }

        }
    }
