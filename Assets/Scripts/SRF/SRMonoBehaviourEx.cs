using UnityEngine;

namespace SRF
{
    public abstract class SRMonoBehaviourEx : SRMonoBehaviour
    {
        // Fields
        private static System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IList<SRF.SRMonoBehaviourEx.FieldInfo>> _checkedFields;
        
        // Methods
        private static void CheckFields(SRF.SRMonoBehaviourEx instance, bool justSet = False)
        {
            if(SRF.SRMonoBehaviourEx._checkedFields == null)
            {
                    System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IList<FieldInfo>> val_1 = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IList<FieldInfo>>();
                SRF.SRMonoBehaviourEx._checkedFields = val_1;
            }
            
            System.Type val_2 = instance.GetType();
            if((val_1.TryGetValue(key:  instance.GetType(), value: out  0)) != true)
            {
                    System.Collections.Generic.List<FieldInfo> val_6 = SRF.SRMonoBehaviourEx.ScanType(t:  val_2);
                val_1.Add(key:  val_2, value:  val_6);
            }
            
            SRF.SRMonoBehaviourEx.PopulateObject(cache:  val_6, instance:  instance, justSet:  justSet);
        }
        private static void PopulateObject(System.Collections.Generic.IList<SRF.SRMonoBehaviourEx.FieldInfo> cache, SRF.SRMonoBehaviourEx instance, bool justSet)
        {
            var val_3;
            System.Type val_4;
            var val_5;
            var val_6;
            var val_18;
            System.Type val_20;
            System.Type val_21;
            System.Object[] val_22;
            object val_23;
            object val_24;
            int val_25;
            val_18 = 0;
            goto label_2;
            label_36:
            var val_20 = 0;
            val_20 = val_20 + 1;
            T val_2 = cache.Item[0];
            val_20 = val_4;
            val_21 = val_6;
            val_22 = System.Collections.Generic.EqualityComparer<System.Object>.Default;
            if((val_22 & 1) == 0)
            {
                goto label_31;
            }
            
            if(val_5 == false)
            {
                goto label_10;
            }
            
            if(val_21 == 0)
            {
                    val_21 = val_20;
            }
            
            object val_8 = SRF.Service.SRServiceManager.GetService(t:  val_21);
            if(val_8 == null)
            {
                goto label_14;
            }
            
            val_23 = val_8;
            val_24 = instance;
            goto label_15;
            label_10:
            if((val_3 & 65280) == 0)
            {
                    if(((System.Collections.Generic.EqualityComparer<System.Object>.Default) & 1) == 0)
            {
                goto label_19;
            }
            
            }
            
            if(justSet == true)
            {
                goto label_31;
            }
            
            goto label_21;
            label_14:
            object[] val_11 = new object[2];
            val_22 = val_11;
            val_25 = val_11.Length;
            val_22[0] = val_20;
            if(val_21 != 0)
            {
                    val_25 = val_11.Length;
            }
            
            val_22[1] = val_21;
            val_20 = SRF.SRFStringExtensions.Fmt(formatString:  "Field {0} import failed (Type {1})", args:  val_11);
            UnityEngine.Debug.LogWarning(message:  val_20);
            goto label_31;
            label_19:
            val_24 = instance;
            val_23 = instance.GetComponent(type:  val_20);
            label_15:
            val_20.SetValue(obj:  val_24, value:  val_23);
            label_31:
            val_18 = 1;
            label_2:
            var val_21 = 0;
            val_21 = val_21 + 1;
            if(val_18 < cache.Count)
            {
                goto label_36;
            }
            
            return;
            label_21:
            if(((???) & 255) != 0)
            {
                    throw new UnityEngine.UnassignedReferenceException(message:  SRF.SRFStringExtensions.Fmt(formatString:  "Field {0} is unassigned, but marked with RequiredFieldAttribute", args:  new object[1]));
            }
            
            UnityEngine.GameObject val_15 = ???.CachedGameObject;
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            ???.SetValue(obj:  ???, value:  val_15.AddComponent(componentType:  ???));
            throw new UnityEngine.UnassignedReferenceException(message:  SRF.SRFStringExtensions.Fmt(formatString:  "Field {0} is unassigned, but marked with RequiredFieldAttribute", args:  new object[1]));
        }
        private static System.Collections.Generic.List<SRF.SRMonoBehaviourEx.FieldInfo> ScanType(System.Type t)
        {
            System.Type val_8;
            var val_9;
            var val_10;
            bool val_11;
            bool val_12;
            bool val_13;
            System.Collections.Generic.List<FieldInfo> val_1 = new System.Collections.Generic.List<FieldInfo>();
            if(null < 1)
            {
                    return val_1;
            }
            
            var val_8 = 0;
            System.Type val_3 = t + 32;
            label_14:
            SRF.RequiredFieldAttribute val_4 = SRF.Helpers.SRReflection.GetAttribute<SRF.RequiredFieldAttribute>(t:  1152921504623353856);
            SRF.ImportAttribute val_5 = SRF.Helpers.SRReflection.GetAttribute<SRF.ImportAttribute>(t:  1152921504623353856);
            if(((SRF.Helpers.SRReflection.GetAttribute<SRF.RequiredFieldAttribute>(t:  t)) == null) && (val_4 == null))
            {
                    if(val_5 == null)
            {
                goto label_7;
            }
            
            }
            
            if(val_5 != null)
            {
                    val_8 = val_5.Service;
                val_9 = 0;
                val_10 = 0;
                val_11 = 1;
            }
            else
            {
                    if(val_4 != null)
            {
                    val_12 = val_4._autoSearch;
                val_13 = val_4._autoCreate;
            }
            else
            {
                    val_12 = val_2._autoSearch;
                val_13 = val_2._autoCreate;
            }
            
                val_11 = false;
                val_8 = 0;
            }
            
            val_1.Add(item:  new FieldInfo() {AutoCreate = (val_13 == true) ? 1 : 0, AutoSet = (val_12 == true) ? 1 : 0, Import = val_11, ImportType = val_8});
            label_7:
            val_8 = val_8 + 1;
            if(val_8 < (val_8 << ))
            {
                goto label_14;
            }
            
            return val_1;
        }
        protected virtual void Awake()
        {
            SRF.SRMonoBehaviourEx.CheckFields(instance:  this, justSet:  false);
        }
        protected virtual void Start()
        {
        
        }
        protected virtual void Update()
        {
        
        }
        protected virtual void FixedUpdate()
        {
        
        }
        protected virtual void OnEnable()
        {
        
        }
        protected virtual void OnDisable()
        {
        
        }
        protected virtual void OnDestroy()
        {
        
        }
        protected SRMonoBehaviourEx()
        {
        
        }
    
    }

}
