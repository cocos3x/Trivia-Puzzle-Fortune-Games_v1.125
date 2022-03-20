using UnityEngine;

namespace SRDebugger.Internal
{
    public static class OptionControlFactory
    {
        // Fields
        private static System.Collections.Generic.IList<SRDebugger.UI.Controls.DataBoundControl> _dataControlPrefabs;
        private static SRDebugger.UI.Controls.Data.ActionControl _actionControlPrefab;
        
        // Methods
        public static SRDebugger.UI.Controls.OptionsControlBase CreateControl(SRDebugger.Internal.OptionDefinition from, string categoryPrefix)
        {
            var val_10;
            UnityEngine.Object val_11;
            if(SRDebugger.Internal.OptionControlFactory._dataControlPrefabs == null)
            {
                    SRDebugger.Internal.OptionControlFactory._dataControlPrefabs = UnityEngine.Resources.LoadAll<SRDebugger.UI.Controls.DataBoundControl>(path:  "SRDebugger/UI/Prefabs/Options");
            }
            
            if(SRDebugger.Internal.OptionControlFactory._actionControlPrefab == 0)
            {
                    val_10 = null;
                SRDebugger.Internal.OptionControlFactory._actionControlPrefab = System.Linq.Enumerable.FirstOrDefault<SRDebugger.UI.Controls.Data.ActionControl>(source:  UnityEngine.Resources.LoadAll<SRDebugger.UI.Controls.Data.ActionControl>(path:  "SRDebugger/UI/Prefabs/Options"));
            }
            else
            {
                    val_10 = 1152921505016856760;
            }
            
            val_11 = 0;
            if(SRDebugger.Internal.OptionControlFactory._actionControlPrefab == val_11)
            {
                    val_11 = 0;
                UnityEngine.Debug.LogError(message:  "[SRDebugger.Options] Cannot find ActionControl prefab.");
            }
            
            if((from.<Property>k__BackingField) != null)
            {
                    SRDebugger.UI.Controls.DataBoundControl val_6 = SRDebugger.Internal.OptionControlFactory.CreateDataControl(from:  from, categoryPrefix:  categoryPrefix);
                return (SRDebugger.UI.Controls.OptionsControlBase)SRDebugger.Internal.OptionControlFactory.CreateActionControl(from:  from, categoryPrefix:  val_11);
            }
            
            if((from.<Method>k__BackingField) == null)
            {
                    throw new System.Exception(message:  "OptionDefinition did not contain property or method.");
            }
            
            return (SRDebugger.UI.Controls.OptionsControlBase)SRDebugger.Internal.OptionControlFactory.CreateActionControl(from:  from, categoryPrefix:  val_11);
        }
        private static SRDebugger.UI.Controls.Data.ActionControl CreateActionControl(SRDebugger.Internal.OptionDefinition from, string categoryPrefix)
        {
            SRDebugger.UI.Controls.Data.ActionControl val_3 = SRInstantiate.Instantiate<SRDebugger.UI.Controls.Data.ActionControl>(prefab:  SRDebugger.Internal.OptionControlFactory._actionControlPrefab);
            if(val_3 == 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "[SRDebugger.OptionsTab] Error creating action control from prefab");
                val_3 = 0;
                return (SRDebugger.UI.Controls.Data.ActionControl)val_3;
            }
            
            val_3.SetMethod(methodName:  from.<Name>k__BackingField, method:  from.<Method>k__BackingField);
            mem2[0] = from;
            return (SRDebugger.UI.Controls.Data.ActionControl)val_3;
        }
        private static SRDebugger.UI.Controls.DataBoundControl CreateDataControl(SRDebugger.Internal.OptionDefinition from, string categoryPrefix)
        {
            UnityEngine.Object val_14;
            string val_15;
            string val_16;
            string val_17;
            .from = from;
            SRDebugger.UI.Controls.DataBoundControl val_3 = System.Linq.Enumerable.FirstOrDefault<SRDebugger.UI.Controls.DataBoundControl>(source:  SRDebugger.Internal.OptionControlFactory._dataControlPrefabs, predicate:  new System.Func<SRDebugger.UI.Controls.DataBoundControl, System.Boolean>(object:  new OptionControlFactory.<>c__DisplayClass4_0(), method:  System.Boolean OptionControlFactory.<>c__DisplayClass4_0::<CreateDataControl>b__0(SRDebugger.UI.Controls.DataBoundControl p)));
            if(val_3 == 0)
            {
                    object[] val_5 = new object[1];
                val_5[0] = (OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from.<Property>k__BackingField.PropertyType;
                UnityEngine.Debug.LogWarning(message:  SRF.SRFStringExtensions.Fmt(formatString:  "[SRDebugger.OptionsTab] Can\'t find data control for type {0}", args:  val_5));
                val_14 = 0;
                return (SRDebugger.UI.Controls.DataBoundControl)val_14;
            }
            
            val_15 = public static SRDebugger.UI.Controls.DataBoundControl SRInstantiate::Instantiate<SRDebugger.UI.Controls.DataBoundControl>(SRDebugger.UI.Controls.DataBoundControl prefab);
            val_14 = SRInstantiate.Instantiate<SRDebugger.UI.Controls.DataBoundControl>(prefab:  val_3);
            if(((OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17 = (OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from.<Name>k__BackingField;
            val_16 = categoryPrefix;
            val_15 = 0;
            if((System.String.IsNullOrEmpty(value:  val_16)) != true)
            {
                    if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_16 = val_17;
                val_15 = categoryPrefix;
                if((val_16.StartsWith(value:  val_15)) != false)
            {
                    if(categoryPrefix == null)
            {
                    throw new NullReferenceException();
            }
            
                val_15 = categoryPrefix.m_stringLength;
                val_17 = val_17.Substring(startIndex:  val_15);
            }
            
            }
            
            if(((OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14.Bind(propertyName:  val_17, prop:  (OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from.<Property>k__BackingField);
            mem2[0] = (OptionControlFactory.<>c__DisplayClass4_0)[1152921519585133360].from;
            return (SRDebugger.UI.Controls.DataBoundControl)val_14;
        }
    
    }

}
