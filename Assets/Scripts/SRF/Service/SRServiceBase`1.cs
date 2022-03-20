using UnityEngine;

namespace SRF.Service
{
    public abstract class SRServiceBase<T> : SRMonoBehaviourEx
    {
        // Methods
        protected override void Awake()
        {
            this.Awake();
            goto __RuntimeMethodHiddenParam + 24 + 192;
        }
        protected override void OnDestroy()
        {
            this.OnDestroy();
            goto __RuntimeMethodHiddenParam + 24 + 192 + 8;
        }
        protected SRServiceBase<T>()
        {
            if(this != null)
            {
                    return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
