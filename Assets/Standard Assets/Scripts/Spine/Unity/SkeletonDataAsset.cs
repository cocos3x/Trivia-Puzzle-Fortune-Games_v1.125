using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonDataAsset : ScriptableObject
    {
        // Fields
        public Spine.Unity.AtlasAsset[] atlasAssets;
        public float scale;
        public UnityEngine.TextAsset skeletonJSON;
        public string[] fromAnimation;
        public string[] toAnimation;
        public float[] duration;
        public float defaultMix;
        public UnityEngine.RuntimeAnimatorController controller;
        private Spine.SkeletonData skeletonData;
        private Spine.AnimationStateData stateData;
        
        // Properties
        public bool IsLoaded { get; }
        
        // Methods
        public bool get_IsLoaded()
        {
            return (bool)(this.skeletonData != 0) ? 1 : 0;
        }
        private void Reset()
        {
            this.skeletonData = 0;
            this.stateData = 0;
        }
        public static Spine.Unity.SkeletonDataAsset CreateRuntimeInstance(UnityEngine.TextAsset skeletonDataFile, Spine.Unity.AtlasAsset atlasAsset, bool initialize, float scale = 0.01)
        {
            Spine.Unity.AtlasAsset[] val_1 = new Spine.Unity.AtlasAsset[1];
            val_1[0] = atlasAsset;
            initialize = initialize;
            return Spine.Unity.SkeletonDataAsset.CreateRuntimeInstance(skeletonDataFile:  skeletonDataFile, atlasAssets:  val_1, initialize:  initialize, scale:  scale);
        }
        public static Spine.Unity.SkeletonDataAsset CreateRuntimeInstance(UnityEngine.TextAsset skeletonDataFile, Spine.Unity.AtlasAsset[] atlasAssets, bool initialize, float scale = 0.01)
        {
            Spine.Unity.SkeletonDataAsset val_1 = UnityEngine.ScriptableObject.CreateInstance<Spine.Unity.SkeletonDataAsset>();
            val_1.skeletonData = 0;
            val_1.stateData = 0;
            val_1.skeletonJSON = skeletonDataFile;
            val_1.atlasAssets = atlasAssets;
            val_1.scale = scale;
            if(initialize == false)
            {
                    return val_1;
            }
            
            Spine.SkeletonData val_2 = val_1.GetSkeletonData(quiet:  true);
            return val_1;
        }
        public void Clear()
        {
            this.skeletonData = 0;
            this.stateData = 0;
        }
        public Spine.SkeletonData GetSkeletonData(bool quiet)
        {
            UnityEngine.TextAsset val_16;
            Spine.SkeletonData val_17;
            Spine.SkeletonData val_18;
            val_16 = this.skeletonJSON;
            if(val_16 == 0)
            {
                    if(quiet != true)
            {
                    UnityEngine.Debug.LogError(message:  "Skeleton JSON file not set for SkeletonData asset: "("Skeleton JSON file not set for SkeletonData asset: ") + this.name, context:  this);
            }
            
                val_17 = 0;
                this.skeletonData = 0;
                this.stateData = 0;
                return val_17;
            }
            
            val_17 = this.skeletonData;
            if(val_17 != null)
            {
                    return val_17;
            }
            
            Spine.AtlasAttachmentLoader val_5 = null;
            val_16 = val_5;
            val_5 = new Spine.AtlasAttachmentLoader(atlasArray:  this.GetAtlasArray());
            if((this.skeletonJSON.name.ToLower().Contains(value:  ".skel")) != false)
            {
                    if(this.skeletonJSON == null)
            {
                    throw new NullReferenceException();
            }
            
                val_18 = Spine.Unity.SkeletonDataAsset.ReadSkeletonData(bytes:  this.skeletonJSON.bytes, attachmentLoader:  val_5, scale:  this.scale);
            }
            else
            {
                    if(this.skeletonJSON == null)
            {
                    throw new NullReferenceException();
            }
            
                val_18 = Spine.Unity.SkeletonDataAsset.ReadSkeletonData(text:  this.skeletonJSON.text, attachmentLoader:  val_5, scale:  this.scale);
            }
            
            this.InitializeWithData(sd:  val_18);
            val_17 = this.skeletonData;
            return val_17;
        }
        internal void InitializeWithData(Spine.SkeletonData sd)
        {
            this.skeletonData = sd;
            this.stateData = new Spine.AnimationStateData(skeletonData:  sd);
            this.FillStateData();
        }
        internal Spine.Atlas[] GetAtlasArray()
        {
            System.Collections.Generic.List<Spine.Atlas> val_1 = new System.Collections.Generic.List<Spine.Atlas>(capacity:  this.atlasAssets.Length);
            var val_4 = 0;
            do
            {
                if(val_4 >= (this.atlasAssets.Length << ))
            {
                    return val_1.ToArray();
            }
            
                Spine.Unity.AtlasAsset val_3 = this.atlasAssets[val_4];
                if((val_3 != 0) && (val_3 != null))
            {
                    val_1.Add(item:  val_3);
            }
            
                val_4 = val_4 + 1;
            }
            while(this.atlasAssets != null);
            
            throw new NullReferenceException();
        }
        internal static Spine.SkeletonData ReadSkeletonData(byte[] bytes, Spine.AttachmentLoader attachmentLoader, float scale)
        {
            .<Scale>k__BackingField = scale;
            return new Spine.SkeletonBinary(attachmentLoader:  attachmentLoader).ReadSkeletonData(input:  new System.IO.MemoryStream(buffer:  bytes));
        }
        internal static Spine.SkeletonData ReadSkeletonData(string text, Spine.AttachmentLoader attachmentLoader, float scale)
        {
            .<Scale>k__BackingField = scale;
            return new Spine.SkeletonJson(attachmentLoader:  attachmentLoader).ReadSkeletonData(reader:  new System.IO.StringReader(s:  text));
        }
        public void FillStateData()
        {
            if(this.stateData == null)
            {
                    return;
            }
            
            this.stateData.defaultMix = this.defaultMix;
            if(this.fromAnimation.Length < 1)
            {
                    return;
            }
            
            var val_5 = 1;
            do
            {
                if((this.fromAnimation[(long)(int)((1 - 1))][0].m_stringLength) != 0)
            {
                    if((this.toAnimation[(long)(int)((1 - 1))][0].m_stringLength) != 0)
            {
                    this.stateData.SetMix(fromName:  this.fromAnimation[(long)val_5 - 1], toName:  this.toAnimation[(long)val_5 - 1], duration:  this.duration[(long)val_5 - 1]);
            }
            
            }
            
                if(val_5 >= this.fromAnimation.Length)
            {
                    return;
            }
            
                val_5 = val_5 + 1;
            }
            while(this.fromAnimation != null);
            
            throw new NullReferenceException();
        }
        public Spine.AnimationStateData GetAnimationStateData()
        {
            Spine.AnimationStateData val_2 = this.stateData;
            if(val_2 != null)
            {
                    return val_2;
            }
            
            Spine.SkeletonData val_1 = this.GetSkeletonData(quiet:  false);
            val_2 = this.stateData;
            return val_2;
        }
        public SkeletonDataAsset()
        {
            this.atlasAssets = new Spine.Unity.AtlasAsset[0];
            this.scale = 0.01f;
            this.fromAnimation = new string[0];
            this.toAnimation = new string[0];
            this.duration = new float[0];
        }
    
    }

}
