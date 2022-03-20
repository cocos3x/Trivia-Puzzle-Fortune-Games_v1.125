using UnityEngine;

namespace Spine.Unity
{
    public class SpineBone : SpineAttributeBase
    {
        // Methods
        public SpineBone(string startsWith = "", string dataField = "", bool includeNone = True)
        {
            mem[1152921513284029848] = dataField;
            mem[1152921513284029856] = startsWith;
            mem[1152921513284029864] = includeNone;
        }
        public static Spine.Bone GetBone(string boneName, Spine.Unity.SkeletonRenderer renderer)
        {
            if(renderer != null)
            {
                    if(renderer.skeleton == null)
            {
                    return (Spine.Bone)renderer.skeleton;
            }
            
                return renderer.skeleton.FindBone(boneName:  boneName);
            }
            
            throw new NullReferenceException();
        }
        public static Spine.BoneData GetBoneData(string boneName, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            return skeletonDataAsset.GetSkeletonData(quiet:  true).FindBone(boneName:  boneName);
        }
    
    }

}
