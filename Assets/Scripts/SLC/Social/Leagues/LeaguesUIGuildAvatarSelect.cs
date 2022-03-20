using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIGuildAvatarSelect : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject avatarButtonPrefab;
        private UnityEngine.RectTransform gridTransform;
        private System.Collections.Generic.List<UnityEngine.UI.Image> buttonImages;
        private UnityEngine.UI.Image imageSprite;
        private SLC.Social.Leagues.LeaguesUICreateGuildView editGuildView;
        
        // Properties
        public UnityEngine.UI.Image ImageSpriteToSet { get; set; }
        
        // Methods
        public UnityEngine.UI.Image get_ImageSpriteToSet()
        {
            return (UnityEngine.UI.Image)this.imageSprite;
        }
        public void set_ImageSpriteToSet(UnityEngine.UI.Image value)
        {
            this.imageSprite = value;
        }
        private void Start()
        {
            int val_9;
            goto label_1;
            label_15:
            .<>4__this = this;
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.avatarButtonPrefab, parent:  this.gridTransform);
            val_2.name = "Avatar_" + ToString();
            .avatarImage = val_2.GetComponent<UnityEngine.UI.Image>();
            UnityEngine.UI.Button val_6 = val_2.GetComponent<UnityEngine.UI.Button>();
            val_6.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new LeaguesUIGuildAvatarSelect.<>c__DisplayClass8_0(), method:  System.Void LeaguesUIGuildAvatarSelect.<>c__DisplayClass8_0::<Start>b__0()));
            (LeaguesUIGuildAvatarSelect.<>c__DisplayClass8_0)[1152921519695729360].avatarImage.sprite = SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.GetAvatarSpriteByID(id:  val_9, portraitID:  0);
            0 = val_9 + 1;
            label_1:
            val_9 = 0;
            if(0 < SLC.Social.Leagues.LeaguesUIManager.guildAvatarHandler.AvatarSpritesCount)
            {
                goto label_15;
            }
        
        }
        public void SetSprite(UnityEngine.UI.Image selected)
        {
            this.imageSprite.sprite = selected.m_Sprite;
            if((UnityEngine.Object.op_Implicit(exists:  this.editGuildView)) == false)
            {
                    return;
            }
            
            this.editGuildView.OnClubImageChanged();
        }
        public LeaguesUIGuildAvatarSelect()
        {
        
        }
    
    }

}
