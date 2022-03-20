using UnityEngine;
[Serializable]
public class SkeletonAnimator.MecanimTranslator
{
    // Fields
    public bool autoReset;
    public Spine.Unity.SkeletonAnimator.MecanimTranslator.MixMode[] layerMixModes;
    private readonly System.Collections.Generic.Dictionary<int, Spine.Animation> animationTable;
    private readonly System.Collections.Generic.Dictionary<UnityEngine.AnimationClip, int> clipNameHashCodeTable;
    private readonly System.Collections.Generic.List<Spine.Animation> previousAnimations;
    private UnityEngine.Animator animator;
    
    // Properties
    public UnityEngine.Animator Animator { get; }
    
    // Methods
    public UnityEngine.Animator get_Animator()
    {
        return (UnityEngine.Animator)this.animator;
    }
    public void Initialize(UnityEngine.Animator animator, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
    {
        var val_4;
        var val_5;
        this.animator = animator;
        this.animationTable.Clear();
        this.clipNameHashCodeTable.Clear();
        Spine.SkeletonData val_1 = skeletonDataAsset.GetSkeletonData(quiet:  true);
        ExposedList.Enumerator<T> val_2 = val_1.animations.GetEnumerator();
        label_10:
        val_4 = public System.Boolean ExposedList.Enumerator<Spine.Animation>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_5 = 64;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_4 = val_5;
        if(this.animationTable == null)
        {
                throw new NullReferenceException();
        }
        
        this.animationTable.Add(key:  64, value:  0);
        goto label_10;
        label_6:
        0.Dispose();
    }
    public void Apply(Spine.Skeleton skeleton)
    {
        var val_9;
        var val_36;
        float val_109;
        var val_111;
        var val_112;
        var val_113;
        float val_114;
        var val_115;
        var val_116;
        Spine.Skeleton val_117;
        float val_118;
        float val_119;
        float val_120;
        var val_121;
        int val_122;
        float val_123;
        float val_124;
        float val_125;
        float val_126;
        float val_127;
        float val_128;
        float val_129;
        float val_130;
        var val_131;
        float val_132;
        val_109 = 0;
        if(this.animator.layerCount > this.layerMixModes.Length)
        {
                System.Array.Resize<MixMode>(array: ref  this.layerMixModes, newSize:  this.animator.layerCount);
        }
        
        bool val_103 = this.autoReset;
        if(val_103 == false)
        {
            goto label_12;
        }
        
        if(val_103 < true)
        {
            goto label_7;
        }
        
        val_111 = 0;
        val_112 = val_103 - 1;
        goto label_8;
        label_10:
        val_111 = 1;
        label_8:
        if(val_111 >= val_103)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_103 = val_103 + 8;
        Spine.SkeletonExtensions.SetKeyedItemsToSetupPose(animation:  (this.autoReset + 8) + 32, skeleton:  skeleton);
        if(val_112 != val_111)
        {
            goto label_10;
        }
        
        label_7:
        this.previousAnimations.Clear();
        int val_4 = this.animator.layerCount;
        if(val_4 < 1)
        {
            goto label_12;
        }
        
        val_113 = 1152921513265730528;
        var val_108 = 0;
        label_32:
        val_114 = 1f;
        if(val_108 == 0)
        {
            goto label_13;
        }
        
        float val_5 = this.animator.GetLayerWeight(layerIndex:  0);
        val_114 = val_5;
        if(val_5 <= 0f)
        {
            goto label_27;
        }
        
        label_13:
        UnityEngine.AnimatorStateInfo val_6 = this.animator.GetNextAnimatorStateInfo(layerIndex:  0);
        val_115 = this.animator.GetCurrentAnimatorClipInfo(layerIndex:  0);
        int val_104 = val_11.Length;
        val_116 = this.animator.GetNextAnimatorClipInfo(layerIndex:  0);
        if(val_104 >= 1)
        {
                var val_105 = 0;
            val_104 = val_104 & 4294967295;
            do
        {
            val_109 = val_114 * null.weight;
            if(val_109 != 0f)
        {
                this.previousAnimations.Add(item:  this.animationTable.Item[this.NameHashCode(clip:  null.clip)]);
        }
        
            val_105 = val_105 + 1;
        }
        while(val_105 < (val_11.Length << ));
        
        }
        
        if(val_9.fullPathHash != 0)
        {
                int val_106 = val_12.Length;
            if(val_106 >= 1)
        {
                var val_107 = 0;
            val_106 = val_106 & 4294967295;
            do
        {
            val_109 = val_114 * null.weight;
            if(val_109 != 0f)
        {
                this.previousAnimations.Add(item:  this.animationTable.Item[this.NameHashCode(clip:  null.clip)]);
        }
        
            val_107 = val_107 + 1;
        }
        while(val_107 < (val_12.Length << ));
        
        }
        
        }
        
        label_27:
        val_108 = val_108 + 1;
        if(val_108 < val_4)
        {
            goto label_32;
        }
        
        label_12:
        int val_21 = this.animator.layerCount;
        val_117 = skeleton;
        if(val_21 < 1)
        {
                return;
        }
        
        var val_124 = 0;
        val_114 = 1f;
        goto label_108;
        label_96:
        val_118 = val_109.normalizedTime;
        if(val_109.speed < 0)
        {
                double val_109 = (double)val_118;
            val_109 = (val_118 == Infinityf) ? (-val_109) : (val_109);
            float val_29 = val_114 - val_118;
            float val_110 = (float)(int)val_109;
            val_29 = val_29 + val_110;
            val_118 = val_29 + val_110;
        }
        
        val_110 = 0.clip.length * val_118;
        val_119 = 0f;
        this.animationTable.Item[this.NameHashCode(clip:  0.clip)].Apply(skeleton:  skeleton, lastTime:  val_119, time:  val_110, loop:  val_109.loop, events:  0, alpha:  val_114, pose:  1, direction:  0);
        goto label_98;
        label_108:
        val_120 = val_114;
        if(val_124 != 0)
        {
                val_120 = this.animator.GetLayerWeight(layerIndex:  0);
        }
        
        UnityEngine.AnimatorStateInfo val_33 = this.animator.GetCurrentAnimatorStateInfo(layerIndex:  0);
        UnityEngine.AnimatorStateInfo val_34 = this.animator.GetNextAnimatorStateInfo(layerIndex:  0);
        int val_38 = val_36.fullPathHash;
        val_116 = this.animator.GetCurrentAnimatorClipInfo(layerIndex:  0);
        MixMode[] val_111 = this.layerMixModes;
        val_111 = val_111 + 0;
        val_113 = this.animator.GetNextAnimatorClipInfo(layerIndex:  0);
        if(((this.layerMixModes + 0) + 32) == 0)
        {
            goto label_49;
        }
        
        val_121 = 0;
        val_122 = val_39.Length & 4294967295;
        if(val_39.Length < 1)
        {
            goto label_55;
        }
        
        label_54:
        val_119 = val_120 * null.weight;
        if(val_119 != 0f)
        {
            goto label_53;
        }
        
        val_122 = val_39.Length;
        val_121 = val_121 + 1;
        if(val_121 < (val_122 << ))
        {
            goto label_54;
        }
        
        goto label_55;
        label_49:
        int val_112 = val_39.Length;
        if(val_112 >= 1)
        {
                val_112 = val_112 & 4294967295;
            do
        {
            val_118 = val_120 * null.weight;
            if(val_118 != 0f)
        {
                val_123 = val_9.normalizedTime;
            val_124 = null.clip.length;
            val_115 = val_9.loop;
            if(val_9.speed < 0)
        {
                double val_113 = (double)val_123;
            val_113 = (val_123 == Infinityf) ? (-val_113) : (val_113);
            float val_51 = val_114 - val_123;
            val_51 = val_51 + (float)(int)val_113;
            val_123 = val_51 + (float)(int)val_113;
        }
        
            val_125 = val_124 * val_123;
            if(val_115 != true)
        {
                val_51 = val_124 - val_125;
        }
        
            val_126 = 0f;
            this.animationTable.Item[this.NameHashCode(clip:  null.clip)].Apply(skeleton:  val_117, lastTime:  val_126, time:  (val_51 < 0) ? (val_124) : (val_125), loop:  val_9.loop, events:  0, alpha:  val_118, pose:  1, direction:  0);
        }
        
            val_112 = 0 + 1;
        }
        while(val_112 < (val_39.Length << ));
        
        }
        
        if(val_38 == 0)
        {
            goto label_100;
        }
        
        int val_114 = val_40.Length;
        if(val_114 < 1)
        {
            goto label_100;
        }
        
        val_114 = val_114 & 4294967295;
        do
        {
            val_118 = val_120 * null.weight;
            if(val_118 != 0f)
        {
                val_127 = val_36.normalizedTime;
            val_124 = null.clip.length;
            if(val_36.speed < 0)
        {
                double val_115 = (double)val_127;
            val_115 = (val_127 == Infinityf) ? (-val_115) : (val_115);
            float val_63 = val_114 - val_127;
            float val_116 = (float)(int)val_115;
            val_63 = val_63 + val_116;
            val_127 = val_63 + val_116;
        }
        
            val_116 = val_124 * val_127;
            this.animationTable.Item[this.NameHashCode(clip:  null.clip)].Apply(skeleton:  val_117, lastTime:  0f, time:  val_116, loop:  val_36.loop, events:  0, alpha:  val_118, pose:  1, direction:  0);
        }
        
            val_112 = 0 + 1;
        }
        while(val_112 < (val_40.Length << ));
        
        goto label_100;
        label_53:
        val_128 = val_9.normalizedTime;
        float val_71 = null.clip.length;
        val_115 = val_9.loop;
        if(val_9.speed < 0)
        {
                double val_117 = (double)val_128;
            val_117 = (val_128 == Infinityf) ? (-val_117) : (val_117);
            float val_74 = val_114 - val_128;
            val_74 = val_74 + (float)(int)val_117;
            val_128 = val_74 + (float)(int)val_117;
        }
        
        val_118 = val_71 * val_128;
        if(val_115 != true)
        {
                val_74 = val_71 - val_118;
        }
        
        val_119 = 0f;
        this.animationTable.Item[this.NameHashCode(clip:  null.clip)].Apply(skeleton:  skeleton, lastTime:  val_119, time:  (val_74 < 0) ? (val_71) : (val_118), loop:  val_9.loop, events:  0, alpha:  val_114, pose:  1, direction:  0);
        val_122 = val_39.Length;
        label_55:
        val_117 = skeleton;
        if(val_122 > val_121)
        {
                val_121 = val_121 & 4294967295;
            do
        {
            UnityEngine.AnimatorClipInfo val_118 = val_116[val_121];
            val_118 = val_120 * val_118.weight;
            if(val_118 != 0f)
        {
                val_129 = val_9.normalizedTime;
            val_124 = val_118.clip.length;
            val_115 = val_9.loop;
            if(val_9.speed < 0)
        {
                double val_119 = (double)val_129;
            val_119 = (val_129 == Infinityf) ? (-val_119) : (val_119);
            float val_87 = val_114 - val_129;
            val_87 = val_87 + (float)(int)val_119;
            val_129 = val_87 + (float)(int)val_119;
        }
        
            val_130 = val_124 * val_129;
            if(val_115 != true)
        {
                val_87 = val_124 - val_130;
        }
        
            val_119 = 0f;
            this.animationTable.Item[this.NameHashCode(clip:  val_118.clip)].Apply(skeleton:  val_117, lastTime:  val_119, time:  (val_87 < 0) ? (val_124) : (val_130), loop:  val_9.loop, events:  0, alpha:  val_118, pose:  1, direction:  0);
        }
        
            val_112 = val_121 + 1;
        }
        while(val_112 < (val_39.Length << ));
        
        }
        
        if(val_38 == 0)
        {
            goto label_100;
        }
        
        if(((this.layerMixModes + 0) + 32) != 2)
        {
            goto label_92;
        }
        
        int val_120 = val_40.Length;
        if(val_120 < 1)
        {
            goto label_94;
        }
        
        val_120 = val_120 & 4294967295;
        label_97:
        val_119 = val_120 * null.weight;
        if(val_119 != 0f)
        {
            goto label_96;
        }
        
        val_131 = 0 + 1;
        if(val_131 < (val_40.Length << ))
        {
            goto label_97;
        }
        
        goto label_98;
        label_92:
        label_94:
        val_131 = 0;
        label_98:
        val_117 = skeleton;
        val_112 = val_131 & 4294967295;
        if(val_112 < (val_40.Length << ))
        {
                do
        {
            UnityEngine.AnimatorClipInfo val_121 = val_113[val_112];
            val_118 = val_120 * val_121.weight;
            if(val_118 != 0f)
        {
                val_132 = val_36.normalizedTime;
            val_124 = val_121.clip.length;
            if(val_36.speed < 0)
        {
                double val_122 = (double)val_132;
            val_122 = (val_132 == Infinityf) ? (-val_122) : (val_122);
            float val_100 = val_114 - val_132;
            float val_123 = (float)(int)val_122;
            val_100 = val_100 + val_123;
            val_132 = val_100 + val_123;
        }
        
            val_123 = val_124 * val_132;
            this.animationTable.Item[this.NameHashCode(clip:  val_121.clip)].Apply(skeleton:  val_117, lastTime:  0f, time:  val_123, loop:  val_36.loop, events:  0, alpha:  val_118, pose:  1, direction:  0);
        }
        
            val_112 = val_112 + 1;
        }
        while(val_112 < (val_40.Length << ));
        
        }
        
        label_100:
        val_124 = val_124 + 1;
        if(val_124 < (long)val_21)
        {
            goto label_108;
        }
    
    }
    private static float AnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed)
    {
        if(reversed != false)
        {
                float val_4 = Infinityf;
            float val_2 = 1f;
            val_2 = val_2 - normalizedTime;
            normalizedTime = (normalizedTime == val_4) ? (-(double)normalizedTime) : ((double)normalizedTime);
            float val_3 = (float)(int)normalizedTime;
            val_2 = val_2 + val_3;
            val_3 = val_2 + val_3;
        }
        
        val_3 = val_3 * clipLength;
        if(loop == true)
        {
                return (float)(val_4 < 0) ? clipLength : (val_3);
        }
        
        val_4 = clipLength - val_3;
        return (float)(val_4 < 0) ? clipLength : (val_3);
    }
    private static float AnimationTime(float normalizedTime, float clipLength, bool reversed)
    {
        if(reversed != false)
        {
                float val_1 = 1f;
            val_1 = val_1 - normalizedTime;
            normalizedTime = (normalizedTime == Infinityf) ? (-(double)normalizedTime) : ((double)normalizedTime);
            float val_2 = (float)(int)normalizedTime;
            val_1 = val_1 + val_2;
            val_2 = val_1 + val_2;
        }
        
        val_2 = val_2 * clipLength;
        return (float)val_2;
    }
    private int NameHashCode(UnityEngine.AnimationClip clip)
    {
        if((this.clipNameHashCodeTable.TryGetValue(key:  clip, value: out  0)) == true)
        {
                return (int)val_3;
        }
        
        string val_3 = clip.name;
        this.clipNameHashCodeTable.Add(key:  clip, value:  val_3);
        return (int)val_3;
    }
    public SkeletonAnimator.MecanimTranslator()
    {
        this.autoReset = true;
        this.layerMixModes = new MixMode[0];
        this.animationTable = new System.Collections.Generic.Dictionary<System.Int32, Spine.Animation>();
        this.clipNameHashCodeTable = new System.Collections.Generic.Dictionary<UnityEngine.AnimationClip, System.Int32>();
        this.previousAnimations = new System.Collections.Generic.List<Spine.Animation>();
    }

}
