/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/FeatureDefinitionHelper.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK.Edit;

namespace OpenRoadAddin
{
    public class FeatureDefinitionHelper
        {
        /*------------------------------------------------------------------------------------**/
        /* 
        /*--------------+---------------+---------------+---------------+---------------+------*/
        public static void BrowseFeatureDefinition (ConsensusConnectionEdit con, FeatureDefinition def)
            {
            FeatureDefinitionManager fdm = FeatureDefinitionManager.Instance;
            IEnumerable<string> FeatureNames = fdm.GetFeatureDefinitions(con, def.Name);
            }
        }
    }
