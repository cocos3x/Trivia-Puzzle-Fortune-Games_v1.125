using UnityEngine;

namespace WordForest
{
    public class WFOAttackFriendsListItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image userPicture;
        private UnityEngine.UI.Text labelBody;
        private UnityEngine.UI.Button buttonAttack;
        private WordForest.UserForestProfile forestProfileData;
        private System.Action<WordForest.UserForestProfile> onButtonClicked;
        
        // Methods
        public void Initialize(WordForest.UserForestProfile data, System.Action<WordForest.UserForestProfile> onBtnClicked)
        {
            this.forestProfileData = data;
            WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            this.userPicture.sprite = val_1.avatarConfig.GetAvatarSpriteByID(id:  this.forestProfileData.avatarId, portraitID:  this.forestProfileData.portraitID);
            this.onButtonClicked = onBtnClicked;
            this.buttonAttack.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOAttackFriendsListItem::OnActiveButtonClicked()));
        }
        private void OnActiveButtonClicked()
        {
            if(this.onButtonClicked == null)
            {
                    return;
            }
            
            this.onButtonClicked.Invoke(obj:  this.forestProfileData);
        }
        public WFOAttackFriendsListItem()
        {
        
        }
    
    }

}
