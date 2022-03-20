using UnityEngine;

namespace SRF.Service
{
    public abstract class SRDependencyServiceBase<T> : SRServiceBase<T>, IAsyncService
    {
        // Fields
        private bool _isLoaded;
        
        // Properties
        protected abstract System.Type[] Dependencies { get; }
        public bool IsLoaded { get; }
        
        // Methods
        protected abstract System.Type[] get_Dependencies(); // 0
        public bool get_IsLoaded()
        {
            return (bool)this;
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
        protected virtual void OnLoaded()
        {
        
        }
        private System.Collections.IEnumerator LoadDependencies()
        {
            mem2[0] = this;
            return (System.Collections.IEnumerator)__RuntimeMethodHiddenParam + 24 + 192 + 8;
        }
        protected SRDependencyServiceBase<T>()
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
