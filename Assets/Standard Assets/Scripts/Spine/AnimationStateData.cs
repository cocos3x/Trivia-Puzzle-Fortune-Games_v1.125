using UnityEngine;

namespace Spine
{
    public class AnimationStateData
    {
        // Fields
        internal Spine.SkeletonData skeletonData;
        private readonly System.Collections.Generic.Dictionary<Spine.AnimationStateData.AnimationPair, float> animationToMixTime;
        internal float defaultMix;
        
        // Properties
        public Spine.SkeletonData SkeletonData { get; }
        public float DefaultMix { get; set; }
        
        // Methods
        public Spine.SkeletonData get_SkeletonData()
        {
            return (Spine.SkeletonData)this.skeletonData;
        }
        public float get_DefaultMix()
        {
            return (float)this.defaultMix;
        }
        public void set_DefaultMix(float value)
        {
            this.defaultMix = value;
        }
        public AnimationStateData(Spine.SkeletonData skeletonData)
        {
            null = null;
            this.animationToMixTime = new System.Collections.Generic.Dictionary<AnimationPair, System.Single>(comparer:  AnimationStateData.AnimationPairComparer.Instance);
            if(skeletonData == null)
            {
                    throw new System.ArgumentException(message:  "skeletonData cannot be null.");
            }
            
            this.skeletonData = skeletonData;
        }
        public void SetMix(string fromName, string toName, float duration)
        {
            string val_5;
            string val_6;
            Spine.Animation val_1 = this.skeletonData.FindAnimation(animationName:  fromName);
            if(val_1 == null)
            {
                goto label_2;
            }
            
            Spine.Animation val_2 = this.skeletonData.FindAnimation(animationName:  toName);
            if(val_2 == null)
            {
                goto label_4;
            }
            
            this.SetMix(from:  val_1, to:  val_2, duration:  duration);
            return;
            label_2:
            val_5 = "Animation not found: ";
            val_6 = ???;
            throw new System.ArgumentException(message:  val_5 + val_6);
            label_4:
            val_5 = "Animation not found: ";
            val_6 = toName;
            throw new System.ArgumentException(message:  val_5 + val_6);
        }
        public void SetMix(Spine.Animation from, Spine.Animation to, float duration)
        {
            string val_4;
            string val_5;
            if(from == null)
            {
                goto label_1;
            }
            
            if(to == null)
            {
                goto label_2;
            }
            
            bool val_1 = this.animationToMixTime.Remove(key:  new AnimationPair() {a1 = from, a2 = to});
            this.animationToMixTime.Add(key:  new AnimationPair() {a1 = from, a2 = to}, value:  duration);
            return;
            label_1:
            val_4 = "from";
            val_5 = "from cannot be null.";
            goto label_5;
            label_2:
            System.ArgumentNullException val_2 = null;
            val_4 = "to";
            val_5 = "to cannot be null.";
            label_5:
            val_2 = new System.ArgumentNullException(paramName:  val_4, message:  val_5);
            throw val_2;
        }
        public float GetMix(Spine.Animation from, Spine.Animation to)
        {
            string val_6;
            string val_7;
            if(from == null)
            {
                goto label_1;
            }
            
            if(to == null)
            {
                goto label_2;
            }
            
            return (float)((this.animationToMixTime.TryGetValue(key:  new AnimationPair() {a1 = from, a2 = to}, value: out  float val_1 = 5.916995E+20f)) != true) ? 1644187116 : this.defaultMix;
            label_1:
            val_6 = "from";
            val_7 = "from cannot be null.";
            goto label_4;
            label_2:
            System.ArgumentNullException val_4 = null;
            val_6 = "to";
            val_7 = "to cannot be null.";
            label_4:
            val_4 = new System.ArgumentNullException(paramName:  val_6, message:  val_7);
            throw val_4;
        }
    
    }

}
