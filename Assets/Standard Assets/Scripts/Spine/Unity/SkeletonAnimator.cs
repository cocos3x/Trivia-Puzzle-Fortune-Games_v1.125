using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonAnimator : SkeletonRenderer, ISkeletonAnimation
    {
        // Fields
        protected Spine.Unity.SkeletonAnimator.MecanimTranslator translator;
        private Spine.Unity.UpdateBonesDelegate _UpdateLocal;
        private Spine.Unity.UpdateBonesDelegate _UpdateWorld;
        private Spine.Unity.UpdateBonesDelegate _UpdateComplete;
        
        // Properties
        public Spine.Unity.SkeletonAnimator.MecanimTranslator Translator { get; }
        
        // Methods
        public Spine.Unity.SkeletonAnimator.MecanimTranslator get_Translator()
        {
            return (MecanimTranslator)this.translator;
        }
        protected void add__UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this._UpdateLocal, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateLocal != 1152921513263477976);
            
            return;
            label_2:
        }
        protected void remove__UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this._UpdateLocal, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateLocal != 1152921513263614552);
            
            return;
            label_2:
        }
        protected void add__UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this._UpdateWorld, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateWorld != 1152921513263751136);
            
            return;
            label_2:
        }
        protected void remove__UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this._UpdateWorld, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateWorld != 1152921513263887712);
            
            return;
            label_2:
        }
        protected void add__UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this._UpdateComplete, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateComplete != 1152921513264024296);
            
            return;
            label_2:
        }
        protected void remove__UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this._UpdateComplete, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this._UpdateComplete != 1152921513264160872);
            
            return;
            label_2:
        }
        public void add_UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            this.add__UpdateLocal(value:  value);
        }
        public void remove_UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            this.remove__UpdateLocal(value:  value);
        }
        public void add_UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            this.add__UpdateWorld(value:  value);
        }
        public void remove_UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            this.remove__UpdateWorld(value:  value);
        }
        public void add_UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            this.add__UpdateComplete(value:  value);
        }
        public void remove_UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            this.remove__UpdateComplete(value:  value);
        }
        public override void Initialize(bool overwrite)
        {
            MecanimTranslator val_3;
            if(true != 0)
            {
                    if(overwrite == false)
            {
                    return;
            }
            
            }
            
            overwrite = overwrite;
            this.Initialize(overwrite:  overwrite);
            if(true == 0)
            {
                    return;
            }
            
            val_3 = this.translator;
            if(val_3 == null)
            {
                    SkeletonAnimator.MecanimTranslator val_1 = null;
                val_3 = val_1;
                val_1 = new SkeletonAnimator.MecanimTranslator();
                this.translator = val_3;
            }
            
            val_1.Initialize(animator:  this.GetComponent<UnityEngine.Animator>(), skeletonDataAsset:  null);
        }
        public void Update()
        {
            if(W8 == 0)
            {
                    return;
            }
            
            this.translator.Apply(skeleton:  null);
            if(this._UpdateLocal != null)
            {
                    this._UpdateLocal.Invoke(animated:  this);
            }
            
            this._UpdateLocal.UpdateWorldTransform();
            if(this._UpdateWorld != null)
            {
                    this._UpdateWorld.Invoke(animated:  this);
                this._UpdateWorld.UpdateWorldTransform();
            }
            
            if(this._UpdateComplete == null)
            {
                    return;
            }
            
            this._UpdateComplete.Invoke(animated:  this);
        }
        public SkeletonAnimator()
        {
        
        }
    
    }

}
