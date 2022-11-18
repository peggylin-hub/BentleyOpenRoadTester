/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRoadAddin.Utility
    {
    /*====================================================================================**/
    /// <summary>
    /// Limited MDL tools for SDK use
    /// </summary>
    /// <author>Nathan.Assaf</author>                                  <date>07/2019</date>
    /*==============+===============+===============+===============+===============+======*/
    public class MDL
        {
        [System.Runtime.InteropServices.DllImport("stdmdlbltin.dll", EntryPoint = "mdlView_isVisible")]
        private static extern int mdlView_isVisible(int viewIndex);

        [System.Runtime.InteropServices.DllImport("stdmdlbltin.dll", EntryPoint = "mdlView_updateSingle")]
        private static extern int mdlView_updateSingle(int viewIndex);

        [System.Runtime.InteropServices.DllImport("stdmdlbltin.dll", EntryPoint = "mdlView_fitViewToRange")]
        private static extern int mdlView_fitViewToRange(ref Bentley.GeometryNET.DPoint3d min, ref Bentley.GeometryNET.DPoint3d max, ref int options, int viewIndex);

        public static void UpdateAllViews()
            {
            for (int i = 0; i < 8; i++)
                {
                if (0 != mdlView_isVisible(i))
                    {
                    mdlView_updateSingle(i);
                    }
                }
            }
        }
    }
