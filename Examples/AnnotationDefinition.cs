/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2021 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.CifNET.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK.Edit;
using Bentley.CifNET.GeometryModel.SDK;
using Bentley.CifNET.Annotation;
using Bentley.CifNET.LinearGeometry;

namespace ManagedSDKExample
    {
    class ECClassDisplayNameHelper
        {

        public enum ECClassDisplay
            {
            SubType_AlignmentPointAlongAnnotation,
            SubType_ProfilePointAlongAnnotation,
            SubType_LinearEntity3dPointAlongAnnotation,
            SubType_LinearEntity3dSideSlopeAnnotation, 
            SubType_HorzPointAnnotation, 
            SubType_ProfilePointAnnotation, 
            SubType_AnyAnnotation,   
            SubType_CrossSectionPointAnnotation,
            SubType_CrossSectionLinearAnnotation,  
            SubType_GridAnnotation,           
            SubType_PlanGridAnnotation,         
            SubType_PlanDrawingAnnotation,       
            SubType_CrossSectionGridAnnotation,   
            SubType_ProfileGridAnnotation,     
            SubType_Frame     
            }

        public static string GetString(ECClassDisplay ecClassDisplay, string prefixName)
            {
            string ecClassDisplayName = prefixName + " Alignment Annotation";
            switch (ecClassDisplay)
                {
                case ECClassDisplay.SubType_AlignmentPointAlongAnnotation:
                    ecClassDisplayName = prefixName + " Alignment Annotation";
                    break;
                case ECClassDisplay.SubType_ProfilePointAlongAnnotation:
                    ecClassDisplayName = prefixName + " Profile Annotation";
                    break;
                case ECClassDisplay.SubType_LinearEntity3dPointAlongAnnotation:
                    ecClassDisplayName = prefixName + " Linear3d Annotation";
                    break;
                case ECClassDisplay.SubType_LinearEntity3dSideSlopeAnnotation:
                    ecClassDisplayName = prefixName + " Side Slope Annotation";
                    break;
                case ECClassDisplay.SubType_HorzPointAnnotation:
                    ecClassDisplayName = prefixName + " Horizontal Point Annotation";
                    break;
                case ECClassDisplay.SubType_ProfilePointAnnotation:
                    ecClassDisplayName = prefixName + " Profile Point Annotation";
                    break;
                case ECClassDisplay.SubType_AnyAnnotation:
                    ecClassDisplayName = prefixName + " Any Annotation";
                    break;
                case ECClassDisplay.SubType_CrossSectionPointAnnotation:
                    ecClassDisplayName = prefixName + " Point Annotation";
                    break;
                case ECClassDisplay.SubType_CrossSectionLinearAnnotation:
                    ecClassDisplayName = prefixName + " Linear Annotation";
                    break;
                case ECClassDisplay.SubType_GridAnnotation:
                    ecClassDisplayName = prefixName + " Grid Annotation";
                    break;
                case ECClassDisplay.SubType_PlanGridAnnotation:
                    ecClassDisplayName = prefixName + " Plan Grid Annotation";
                    break;
                case ECClassDisplay.SubType_PlanDrawingAnnotation:
                    ecClassDisplayName = prefixName + " Plan Drawing Annotation";
                    break;
                case ECClassDisplay.SubType_CrossSectionGridAnnotation:
                    ecClassDisplayName = prefixName + " Grid Annotation";
                    break;
                case ECClassDisplay.SubType_ProfileGridAnnotation:
                    ecClassDisplayName = prefixName + " Grid Annotation";
                    break;
                case ECClassDisplay.SubType_Frame:
                    ecClassDisplayName = prefixName + " Frame Annotation";
                    break;
                default:
                     ecClassDisplayName = prefixName + "My Alignment Annotation";
                    break;

                }
            return ecClassDisplayName;
            }
        }
    class MyAnnotationEvaluator : AnnotationEvaluator
        {
        Alignment GetAlignment(Bentley.CifNET.SDK.ConsensusConnection con)
            {
            Bentley.DgnPlatformNET.DgnEC.IDgnECInstance dgnECInstance = GetAnnotatedDgnECInstance();
            return (Alignment)Alignment.CreateFromElement(con, dgnECInstance.Element);
            }

        public static double ConvertUORToMeter(DgnModel model, double num)
            {
            ModelInfo info = model.GetModelInfo();
            return num / info.UorPerMeter;
            }

        double GetLineLength()
            {
            double val = 0.0;
            if (0 == GetDoubleValueParameter(ref val, "Length"))
                return val;
            return 0.0;
            }

        double GetLineInterval()
            {
            double val = 0.0;
            if (0 == GetDoubleValueParameter(ref val, "Interval"))
                return val;
            return 0.0;
            }
        protected override int _Draw(AnnotationDrawingContext context)
            {
            Bentley.CifNET.SDK.ConsensusConnection con = new Bentley.CifNET.SDK.ConsensusConnection(context.DrawingModel);

            Alignment alignment = GetAlignment(con);

            double UOR_TO_MASTER = ConvertUORToMeter(context.DrawingModel, 1.0);
            if (alignment != null)
                {
                LinearElement LinearEl = alignment.LinearGeometry;
                double EndPosition = LinearEl.Length;
                double Interval = GetLineInterval();
                double Length = GetLineLength();
                for (double dStation = 0; EndPosition > dStation - Interval; dStation += Interval)
                    {
                    if (dStation > EndPosition)
                        dStation = EndPosition;
                    LinearPoint offsetPt0 = null, offsetPtLength = null;
                    offsetPt0 = LinearEl.GetPointAtDistanceOffset(dStation, 0);
                    offsetPtLength = LinearEl.GetPointAtDistanceOffset(dStation, -Length);
                    DgnModel model = context.DrawingModel;

                    DPoint3d startPoint = offsetPt0.Coordinates;
                    startPoint.X /= UOR_TO_MASTER;
                    startPoint.Y /= UOR_TO_MASTER;
                    startPoint.Z /= UOR_TO_MASTER;

                    DPoint3d endPoint = offsetPtLength.Coordinates;
                    endPoint.X /= UOR_TO_MASTER;
                    endPoint.Y /= UOR_TO_MASTER;
                    endPoint.Z /= UOR_TO_MASTER;

                    DSegment3d segment = new DSegment3d(startPoint, endPoint);
                    LineElement lineElement = new Bentley.DgnPlatformNET.Elements.LineElement(model, null, segment);
                    context.PushElement(lineElement);

                    DVector3d rotVector = segment.UnitTangent;
                    DMatrix3d rotMatrix = DMatrix3d.Rotation(2, rotVector.AngleXY);

                    DgnFile activeDgnFile = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnFile();
                    DgnTextStyle textStyle = DgnTextStyle.GetByName("Line Length Label", activeDgnFile);

                    if (null == textStyle)
                        {
                        textStyle = new DgnTextStyle("Line Length Label", activeDgnFile);
                        textStyle.SetProperty(TextStyleProperty.Width, 400D);
                        textStyle.SetProperty(TextStyleProperty.Height, 400D);
                        textStyle.Add(activeDgnFile);
                        }

                    string textString = string.Format("sta = {0:F1}", dStation);

                    TextBlock textBlock = new TextBlock(textStyle, context.DrawingModel);
                    textBlock.AppendText(textString);
                    textBlock.SetUserOrigin(startPoint);
                    textBlock.SetOrientation(rotMatrix);

                    TextElement textElement = (TextElement)TextElement.CreateElement(null, textBlock);
                    context.PushElement(textElement);
                    }
                }
            return 0;
        }
    public static AnnotationEvaluator Create()
        {
        return new MyAnnotationEvaluator();
        }
    }

    class MyAnnotationEnabler : AnnotationEnabler
        {
        public override void _GetPrimaryClasses(ref List<Bentley.CifNET.Objects.SchemaNameClassNamePair> manageClasSchemaPairs)
            {
            manageClasSchemaPairs.Add(new Bentley.CifNET.Objects.SchemaNameClassNamePair("Civil", "Alignment"));
            }
        public override AnnotationEvaluator _CreateEvaluator() 
            {
             return MyAnnotationEvaluator.Create();
            }

       public override string _GetECClassName()
        {
        return "AligmentUser";
        }
        public override void _AddProperties()
        {
        int priority = 1000;
        int category = 1000;

        string cat = "Cate";

        category--;
        OptionDisplayString lp1 = new OptionDisplayString( 1, "One");
        OptionDisplayString lp2 = new OptionDisplayString( 2, "Two");
        OptionDisplayString lp3 = new OptionDisplayString( 3, "Three");
        List<OptionDisplayString> vec = new List<OptionDisplayString>();
        vec.Add(lp1);
        vec.Add(lp2);
        vec.Add(lp3);


        AddOptionProperty(cat, category, priority--, "With", "With", vec, 1);

        // LINE
        cat = "LINE";
        category--;
        AddDoubleProperty(cat, category, priority--, "Length", "Length", 20);

        AddDoubleProperty(cat, category, priority--, "Interval", "Interval", 100);
        }
        public override string _GetECClassDisplayName()
        {
            //return "My Aligment";
            return ECClassDisplayNameHelper.GetString(ECClassDisplayNameHelper.ECClassDisplay.SubType_AlignmentPointAlongAnnotation, "My");
        }

        public static MyAnnotationEnabler GetInstance()
            {
            MyAnnotationEnabler s_instance = new MyAnnotationEnabler();
            return s_instance;
            }
        };

    class MyAnnotationProvider : AnnotationProvider
        {
        private static MyAnnotationProvider s_instance = null;
        private bool m_isRegistered;
        public MyAnnotationProvider() : base("MyGeometryModel")            
            {

            }
        public override void _CollectEnablers(ref List<AnnotationEnabler> enablers)
            {
            enablers.Add(MyAnnotationEnabler.GetInstance());
            }
        public void Initialize()
            {
            if (!m_isRegistered)
                {                
                AnnotationManager.Manager.RegisterProvider(this);
                m_isRegistered = true;
                }
            }
        public void Shutdown()
            {
            if (m_isRegistered)
                {
                AnnotationManager.Manager.UnRegisterProvider(this);
                m_isRegistered = false;
                }
            }

        public static MyAnnotationProvider GetInstance()
            {
            if (s_instance == null)
                {
                s_instance = new MyAnnotationProvider();
                }
            return s_instance;
            }
        };

    public class AnnotationRegister
        {
        public static void AnnotationDefinitionRegister()
            {
            MyAnnotationProvider.GetInstance().Initialize();
            NotificationManager.OutputPrompt("Command complete. Annotations have been successfully registered.");
            }
        public static void AnnotationDefinitionUnRegister()
            {
            MyAnnotationProvider.GetInstance().Shutdown();
            NotificationManager.OutputPrompt("Command complete. Annotations have been successfully unregistered.");
            }
        }
    }
