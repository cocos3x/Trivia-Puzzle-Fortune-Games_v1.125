using UnityEngine;

namespace SRDebugger.Internal
{
    public static class SRDebuggerUtil
    {
        // Properties
        public static bool IsMobilePlatform { get; }
        
        // Methods
        public static bool get_IsMobilePlatform()
        {
            if(UnityEngine.Application.isMobilePlatform == false)
            {
                    return (bool)((UnityEngine.Application.platform - 18) < 3) ? 1 : 0;
            }
            
            return true;
        }
        public static bool EnsureEventSystemExists()
        {
            UnityEngine.Object val_9;
            var val_10;
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._enableEventSystemCreation == false)
            {
                goto label_15;
            }
            
            val_9 = UnityEngine.EventSystems.EventSystem.current;
            if(val_9 == 0)
            {
                goto label_7;
            }
            
            label_15:
            val_10 = 0;
            return (bool)val_10;
            label_7:
            UnityEngine.EventSystems.EventSystem val_4 = UnityEngine.Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>();
            val_9 = val_4;
            if(val_4 != 0)
            {
                    if(val_9.gameObject.activeSelf != false)
            {
                    if(val_9.enabled == true)
            {
                goto label_15;
            }
            
            }
            
            }
            
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger] No EventSystem found in scene - creating a default one.");
            SRDebugger.Internal.SRDebuggerUtil.CreateDefaultEventSystem();
            val_10 = 1;
            return (bool)val_10;
        }
        public static void CreateDefaultEventSystem()
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "EventSystem");
            UnityEngine.EventSystems.EventSystem val_2 = val_1.AddComponent<UnityEngine.EventSystems.EventSystem>();
            UnityEngine.EventSystems.StandaloneInputModule val_3 = val_1.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
        public static System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> ScanForOptions(object obj)
        {
            System.Collections.Generic.List<T> val_19;
            var val_20;
            SRDebugger.Internal.OptionDefinition val_21;
            string val_22;
            int val_23;
            string val_24;
            System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition> val_1 = null;
            val_19 = val_1;
            val_1 = new System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition>();
            if(null < 1)
            {
                    return (System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition>)val_19;
            }
            
            val_20 = 1152921519588622560;
            var val_19 = 0;
            System.Type val_3 = obj.GetType() + 32;
            label_30:
            System.ComponentModel.CategoryAttribute val_4 = SRF.Helpers.SRReflection.GetAttribute<System.ComponentModel.CategoryAttribute>(t:  1152921504623353856);
            if(val_4 != null)
            {
                    val_22 = val_4.Category;
            }
            else
            {
                    val_22 = "Default";
            }
            
            if((SRF.Helpers.SRReflection.GetAttribute<SROptions.SortAttribute>(t:  1152921504623353856)) != null)
            {
                    val_23 = val_6.SortPriority;
            }
            else
            {
                    val_23 = 0;
            }
            
            if((SRF.Helpers.SRReflection.GetAttribute<SROptions.DisplayNameAttribute>(t:  1152921504623353856)) == null)
            {
                goto label_10;
            }
            
            if(null == null)
            {
                goto label_28;
            }
            
            val_24 = val_7.Name;
            goto label_12;
            label_10:
            val_24 = 1152921504623353856;
            label_12:
            if(1152921504623353856.IsStatic == true)
            {
                goto label_28;
            }
            
            val_19 = val_19;
            val_20 = 1152921519588622560;
            if(((System.Type.op_Inequality(left:  1152921504623353856, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == true) || (System != null))
            {
                goto label_28;
            }
            
            SRDebugger.Internal.OptionDefinition val_13 = null;
            val_21 = val_13;
            val_13 = new SRDebugger.Internal.OptionDefinition();
            .<Name>k__BackingField = val_24;
            .<Category>k__BackingField = val_22;
            .<SortPriority>k__BackingField = val_23;
            .<Method>k__BackingField = new SRF.Helpers.MethodReference(target:  obj, method:  1152921504623353856);
            if(val_19 != 0)
            {
                goto label_24;
            }
            
            if(((System.Reflection.MethodInfo.op_Equality(left:  1152921504623353856.GetGetMethod(), right:  0)) == true) || ((1152921504623353856.GetGetMethod() & 16) != 0))
            {
                goto label_28;
            }
            
            SRDebugger.Internal.OptionDefinition val_18 = null;
            val_21 = val_18;
            val_18 = new SRDebugger.Internal.OptionDefinition();
            .<Name>k__BackingField = val_24;
            .<Category>k__BackingField = val_22;
            .<SortPriority>k__BackingField = val_23;
            .<Property>k__BackingField = new SRF.Helpers.PropertyReference(target:  obj, property:  1152921504623353856);
            label_24:
            val_1.Add(item:  val_18);
            val_20 = 1152921519588622560;
            label_28:
            val_19 = val_19 + 1;
            if(val_19 < (1152921519513254144 << ))
            {
                goto label_30;
            }
            
            return (System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition>)val_19;
        }
        public static string GetNumberString(int value, int max, string exceedsMaxString)
        {
            if(value >= max)
            {
                    return (string)value.ToString();
            }
            
            return (string)value.ToString();
        }
        public static void ConfigureCanvas(UnityEngine.Canvas canvas)
        {
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._useDebugCamera == false)
            {
                    return;
            }
            
            var val_5 = 0;
            val_5 = val_5 + 1;
            canvas.worldCamera = SRDebugger.Internal.Service.DebugCamera.Camera;
            canvas.renderMode = 1;
        }
    
    }

}
