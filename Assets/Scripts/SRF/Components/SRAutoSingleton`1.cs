using UnityEngine;

namespace SRF.Components
{
    public abstract class SRAutoSingleton<T> : SRMonoBehaviour
    {
        // Fields
        private static T _instance;
        
        // Properties
        public static T Instance { get; }
        public static bool HasInstance { get; }
        
        // Methods
        public static T get_Instance()
        {
            var val_6;
            var val_7;
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0) && (UnityEngine.Application.isPlaying != false))
            {
                    UnityEngine.GameObject val_5 = new UnityEngine.GameObject(name:  "_" + System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 16})(System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 16})));
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_6 = __RuntimeMethodHiddenParam + 24 + 302;
                val_7 = __RuntimeMethodHiddenParam + 24;
                if((val_6 & 1) == 0)
            {
                    val_7 = mem[__RuntimeMethodHiddenParam + 24];
                val_7 = __RuntimeMethodHiddenParam + 24;
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 302];
                val_6 = __RuntimeMethodHiddenParam + 24 + 302;
            }
            
            }
            
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
            {
                    return (SRF.Service.SRServiceManager)__RuntimeMethodHiddenParam + 24 + 192 + 184;
            }
            
            return (SRF.Service.SRServiceManager)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        public static bool get_HasInstance()
        {
            return UnityEngine.Object.op_Inequality(x:  __RuntimeMethodHiddenParam + 24 + 192 + 184, y:  0);
        }
        protected virtual void Awake()
        {
            var val_5;
            var val_6;
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
            {
                    object[] val_2 = new object[1];
                val_2[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 16});
                UnityEngine.Debug.LogWarning(message:  SRF.SRFStringExtensions.Fmt(formatString:  "More than one singleton object of type {0} exists.", args:  val_2));
                return;
            }
            
            val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192;
            if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
            {
                    val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192];
                val_5 = __RuntimeMethodHiddenParam + 24 + 192;
            }
            
            if(this != null)
            {
                    if(X0 == true)
            {
                goto label_17;
            }
            
            }
            
            val_6 = 0;
            label_17:
            mem2[0] = val_6;
        }
        private void OnApplicationQuit()
        {
            mem2[0] = 0;
        }
        protected SRAutoSingleton<T>()
        {
            if(this != null)
            {
                    return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
