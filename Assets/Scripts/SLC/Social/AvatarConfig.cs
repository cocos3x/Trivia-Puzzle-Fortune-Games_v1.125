using UnityEngine;

namespace SLC.Social
{
    public class AvatarConfig : ScriptableObject
    {
        // Fields
        private UnityEngine.Sprite[] avatarSprites;
        private System.Collections.Generic.List<UnityEngine.Sprite> portraitSprites;
        private System.Collections.Generic.List<UnityEngine.Sprite> portraitAltSprites;
        
        // Properties
        public int AvatarSpritesCount { get; }
        
        // Methods
        public int get_AvatarSpritesCount()
        {
            if(this.avatarSprites != null)
            {
                    return (int)this.avatarSprites.Length;
            }
            
            throw new NullReferenceException();
        }
        public UnityEngine.Sprite GetAvatarSpriteByID(int id, string portraitID)
        {
            UnityEngine.Sprite[] val_8;
            UnityEngine.Object val_9;
            val_8 = this;
            if((System.String.IsNullOrEmpty(value:  portraitID)) != true)
            {
                    val_9 = this.GetPortraitSpriteByName(name:  portraitID);
                if(val_9 != 0)
            {
                    return val_9;
            }
            
            }
            
            if((id & 2147483648) != 0)
            {
                goto label_5;
            }
            
            if(this.avatarSprites.Length <= id)
            {
                goto label_7;
            }
            
            goto label_14;
            label_5:
            UnityEngine.Debug.LogWarning(message:  "Returning random Avatar Sprite for: "("Returning random Avatar Sprite for: ") + id);
            val_8 = this.avatarSprites;
            goto label_14;
            label_7:
            UnityEngine.Debug.LogWarning(message:  "Returning random Avatar Sprite for: "("Returning random Avatar Sprite for: ") + id);
            label_14:
            val_9 = this.avatarSprites[((-4294967296) + ((this.avatarSprites.Length) << 32)) >> 29];
            return val_9;
        }
        public UnityEngine.Sprite GetPortraitSpriteByName(string name)
        {
            var val_4;
            .name = name;
            if(this.portraitSprites != null)
            {
                    UnityEngine.Sprite val_3 = System.Linq.Enumerable.FirstOrDefault<UnityEngine.Sprite>(source:  this.portraitSprites, predicate:  new System.Func<UnityEngine.Sprite, System.Boolean>(object:  new AvatarConfig.<>c__DisplayClass6_0(), method:  System.Boolean AvatarConfig.<>c__DisplayClass6_0::<GetPortraitSpriteByName>b__0(UnityEngine.Sprite x)));
                return (UnityEngine.Sprite)val_4;
            }
            
            val_4 = 0;
            return (UnityEngine.Sprite)val_4;
        }
        public UnityEngine.Sprite GetAltPortraitSpriteByName(string name)
        {
            System.Collections.Generic.List<UnityEngine.Sprite> val_5;
            var val_6;
            val_5 = this;
            .name = name;
            if(this.portraitAltSprites != null)
            {
                    .name = System.String.Format(format:  "{0}_silhouette", arg0:  name);
                val_5 = this.portraitAltSprites;
                UnityEngine.Sprite val_4 = System.Linq.Enumerable.FirstOrDefault<UnityEngine.Sprite>(source:  val_5, predicate:  new System.Func<UnityEngine.Sprite, System.Boolean>(object:  new AvatarConfig.<>c__DisplayClass7_0(), method:  System.Boolean AvatarConfig.<>c__DisplayClass7_0::<GetAltPortraitSpriteByName>b__0(UnityEngine.Sprite x)));
                return (UnityEngine.Sprite)val_6;
            }
            
            val_6 = 0;
            return (UnityEngine.Sprite)val_6;
        }
        public int GetIDByAvatarSprite(UnityEngine.Sprite sprite, bool randomIfNotFound = False)
        {
            var val_2;
            int val_3;
            val_2 = 0;
            label_7:
            val_3 = this.avatarSprites.Length;
            if(val_2 >= (val_3 << ))
            {
                goto label_2;
            }
            
            val_3 = this.avatarSprites[val_2];
            if(sprite == val_3)
            {
                    return (int)val_2;
            }
            
            val_2 = val_2 + 1;
            if(this.avatarSprites != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_2:
            if(randomIfNotFound != false)
            {
                    return UnityEngine.Random.Range(min:  0, max:  val_3);
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        public AvatarConfig()
        {
        
        }
    
    }

}
