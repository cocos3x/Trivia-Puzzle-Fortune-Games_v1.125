using UnityEngine;

namespace Spine.Unity
{
    public abstract class SkeletonUtilityConstraint : MonoBehaviour
    {
        // Fields
        protected Spine.Unity.SkeletonUtilityBone utilBone;
        protected Spine.Unity.SkeletonUtility skeletonUtility;
        
        // Methods
        protected virtual void OnEnable()
        {
            this.utilBone = this.GetComponent<Spine.Unity.SkeletonUtilityBone>();
            Spine.Unity.SkeletonUtility val_3 = this.transform.GetComponentInParent<Spine.Unity.SkeletonUtility>();
            this.skeletonUtility = val_3;
            val_3.RegisterConstraint(constraint:  this);
        }
        protected virtual void OnDisable()
        {
            if(this.skeletonUtility != null)
            {
                    this.skeletonUtility.UnregisterConstraint(constraint:  this);
                return;
            }
            
            throw new NullReferenceException();
        }
        public abstract void DoUpdate(); // 0
        protected SkeletonUtilityConstraint()
        {
        
        }
    
    }

}
