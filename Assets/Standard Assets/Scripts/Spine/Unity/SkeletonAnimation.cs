using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, IAnimationStateComponent
    {
        // Fields
        public Spine.AnimationState state;
        private Spine.Unity.UpdateBonesDelegate _UpdateLocal;
        private Spine.Unity.UpdateBonesDelegate _UpdateWorld;
        private Spine.Unity.UpdateBonesDelegate _UpdateComplete;
        private string _animationName;
        public bool loop;
        public float timeScale;
        
        // Properties
        public Spine.AnimationState AnimationState { get; }
        public string AnimationName { get; set; }
        
        // Methods
        public Spine.AnimationState get_AnimationState()
        {
            return (Spine.AnimationState)this.state;
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
            while(this._UpdateLocal != 1152921513260618104);
            
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
            while(this._UpdateLocal != 1152921513260754680);
            
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
            while(this._UpdateWorld != 1152921513260891264);
            
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
            while(this._UpdateWorld != 1152921513261027840);
            
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
            while(this._UpdateComplete != 1152921513261164424);
            
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
            while(this._UpdateComplete != 1152921513261301000);
            
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
        public string get_AnimationName()
        {
            string val_2;
            if(true != 0)
            {
                    if((this.state.GetCurrent(trackIndex:  0)) == null)
            {
                    return (string)val_2;
            }
            
                val_2 = val_1.animation.name;
                return (string)val_2;
            }
            
            UnityEngine.Debug.LogWarning(message:  "You tried access AnimationName but the SkeletonAnimation was not valid. Try checking your Skeleton Data for errors.");
            val_2 = 0;
            return (string)val_2;
        }
        public void set_AnimationName(string value)
        {
            if((System.String.op_Equality(a:  this._animationName, b:  value)) != false)
            {
                    return;
            }
            
            this._animationName = value;
            if(true == 0)
            {
                goto label_2;
            }
            
            if((System.String.IsNullOrEmpty(value:  value)) == false)
            {
                goto label_3;
            }
            
            this.state.ClearTrack(trackIndex:  0);
            return;
            label_2:
            UnityEngine.Debug.LogWarning(message:  "You tried to change AnimationName but the SkeletonAnimation was not valid. Try checking your Skeleton Data for errors.");
            return;
            label_3:
            Spine.TrackEntry val_3 = this.state.SetAnimation(trackIndex:  0, animationName:  value, loop:  this.loop);
        }
        public static Spine.Unity.SkeletonAnimation AddToGameObject(UnityEngine.GameObject gameObject, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            return Spine.Unity.SkeletonRenderer.AddSpineComponent<Spine.Unity.SkeletonAnimation>(gameObject:  gameObject, skeletonDataAsset:  skeletonDataAsset);
        }
        public static Spine.Unity.SkeletonAnimation NewSkeletonAnimationGameObject(Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            return Spine.Unity.SkeletonRenderer.NewSpineGameObject<Spine.Unity.SkeletonAnimation>(skeletonDataAsset:  skeletonDataAsset);
        }
        protected override void ClearState()
        {
            this.ClearState();
            if(this.state == null)
            {
                    return;
            }
            
            this.state.ClearTracks();
        }
        public override void Initialize(bool overwrite)
        {
            Spine.AnimationStateData val_5;
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
            
            val_5 = 195;
            if(val_5 == 0)
            {
                    Spine.SkeletonData val_1 = GetSkeletonData(quiet:  false);
                val_5 = 195;
            }
            
            this.state = new Spine.AnimationState(data:  val_5);
            if((System.String.IsNullOrEmpty(value:  this._animationName)) != false)
            {
                    return;
            }
            
            Spine.TrackEntry val_4 = this.state.SetAnimation(trackIndex:  0, animationName:  this._animationName, loop:  this.loop);
            this.Update(deltaTime:  0f);
        }
        private void Update()
        {
            this.Update(deltaTime:  UnityEngine.Time.deltaTime);
        }
        public void Update(float deltaTime)
        {
            if(W8 == 0)
            {
                    return;
            }
            
            float val_1 = this.timeScale * deltaTime;
            this.Update(delta:  val_1);
            this.state.Update(delta:  val_1);
            bool val_2 = this.state.Apply(skeleton:  0);
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
        public SkeletonAnimation()
        {
            this.timeScale = 1f;
        }
    
    }

}
