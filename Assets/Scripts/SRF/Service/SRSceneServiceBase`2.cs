using UnityEngine;

namespace SRF.Service
{
    public abstract class SRSceneServiceBase<T, TImpl> : SRServiceBase<T>, IAsyncService
    {
        // Fields
        private TImpl _rootObject;
        
        // Properties
        protected abstract string SceneName { get; }
        protected TImpl RootObject { get; }
        public bool IsLoaded { get; }
        
        // Methods
        protected abstract string get_SceneName(); // 0
        protected TImpl get_RootObject()
        {
            return (object)this;
        }
        public bool get_IsLoaded()
        {
            return UnityEngine.Object.op_Inequality(x:  this, y:  0);
        }
        private void Log(string msg, UnityEngine.Object target)
        {
            UnityEngine.Debug.Log(message:  msg, context:  target);
        }
        protected override void Start()
        {
            this.Start();
            UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
        }
        protected override void OnDestroy()
        {
            if((this & 1) != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.gameObject);
            }
        
        }
        protected virtual void OnLoaded()
        {
        
        }
        private System.Collections.IEnumerator LoadCoroutine()
        {
            mem2[0] = this;
            return (System.Collections.IEnumerator)__RuntimeMethodHiddenParam + 24 + 192 + 32;
        }
        protected SRSceneServiceBase<T, TImpl>()
        {
            if(this != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
    
    }

}
