using UnityEngine;

namespace SRF.Components
{
    public abstract class SRSingleton<T> : SRMonoBehaviour
    {
        // Fields
        private static T _instance;
        
        // Properties
        public static T Instance { get; }
        public static bool HasInstance { get; }
        
        // Methods
        public static T get_Instance()
        {
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
            {
                    if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
            {
                    return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
            }
            
                return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
            }
            
            System.Type val_3 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 16});
            throw new System.InvalidOperationException(message:  SRF.SRFStringExtensions.Fmt(formatString:  "No instance of {0} present in scene", args:  new object[1]));
        }
        public static bool get_HasInstance()
        {
            return UnityEngine.Object.op_Inequality(x:  __RuntimeMethodHiddenParam + 24 + 192 + 184, y:  0);
        }
        private void Register()
        {
            UnityEngine.Object val_7;
            object val_8;
            var val_9;
            var val_10;
            var val_11;
            val_7 = this;
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
            {
                goto label_4;
            }
            
            object[] val_2 = new object[1];
            val_8 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 16});
            val_2[0] = val_8;
            UnityEngine.Debug.LogWarning(message:  SRF.SRFStringExtensions.Fmt(formatString:  "More than one singleton object of type {0} exists.", args:  val_2));
            T[] val_5 = this.GetComponents<UnityEngine.Component>();
            if(val_5.Length != 2)
            {
                goto label_16;
            }
            
            val_7 = this.gameObject;
            val_9 = null;
            goto label_19;
            label_4:
            val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192];
            val_10 = __RuntimeMethodHiddenParam + 24 + 192;
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
            {
                    val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_10 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            
            val_8 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 184];
            val_8 = __RuntimeMethodHiddenParam + 24 + 192 + 184;
            if(this == null)
            {
                goto label_22;
            }
            
            if(X0 == true)
            {
                goto label_23;
            }
            
            label_16:
            val_9 = null;
            label_19:
            UnityEngine.Object.Destroy(obj:  this);
            return;
            label_22:
            val_11 = 0;
            label_23:
            mem2[0] = val_11;
        }
        protected virtual void Awake()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnEnable()
        {
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
            {
                    return;
            }
            
            this = ???;
            goto __RuntimeMethodHiddenParam + 24 + 192 + 24;
        }
        private void OnApplicationQuit()
        {
            mem2[0] = 0;
        }
        protected SRSingleton<T>()
        {
            if(this != null)
            {
                    return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
