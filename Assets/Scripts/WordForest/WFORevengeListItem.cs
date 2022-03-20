using UnityEngine;

namespace WordForest
{
    public class WFORevengeListItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image userPicture;
        private UnityEngine.UI.Text labelBody;
        private UnityEngine.UI.Button buttonGreen;
        private UnityEngine.UI.Button buttonBlue;
        private WordForest.UserForestProfile forestProfileData;
        private UnityEngine.UI.Button activeButton;
        private System.Action<WordForest.UserForestProfile> onButtonClicked;
        
        // Methods
        public void Initialize(WordForest.UserForestProfile data, System.Action<WordForest.UserForestProfile> onBtnClicked, bool isRandomTarget = False, string buttonText)
        {
            string val_22;
            WordForest.UserForestProfile val_23;
            var val_24;
            val_22 = buttonText;
            val_23 = data;
            this.forestProfileData = val_23;
            WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            this.userPicture.sprite = val_1.avatarConfig.GetAvatarSpriteByID(id:  this.forestProfileData.avatarId, portraitID:  0);
            mem[1152921518180389880] = onBtnClicked;
            this.buttonBlue.gameObject.SetActive(value:  isRandomTarget);
            this.buttonGreen.gameObject.SetActive(value:  (~isRandomTarget) & 1);
            this.activeButton = (isRandomTarget != true) ? (this.buttonBlue) : (this.buttonGreen);
            val_24 = mem[isRandomTarget != true ? 1152921518180389856 : 1152921518180389848 + 248];
            val_24 = isRandomTarget != true ? 1152921518180389856 : 1152921518180389848 + 248;
            val_24.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFORevengeListItem::OnActiveButtonClicked()));
            if(isRandomTarget != true)
            {
                    if(data.isOffline != false)
            {
                    if((data.map.CurrentForestGrowth(includeDamagedTrees:  false)) > 0)
            {
                goto label_19;
            }
            
            }
            
                this.activeButton.gameObject.SetActive(value:  false);
            }
            
            label_19:
            if((System.String.IsNullOrEmpty(value:  val_22)) == true)
            {
                    return;
            }
            
            if((this.activeButton.GetComponentInChildren<UnityEngine.UI.Text>()) == 0)
            {
                    return;
            }
            
            val_22 = ???;
            val_23 = ???;
            val_24 = ???;
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void OnActiveButtonClicked()
        {
            if(this.onButtonClicked == null)
            {
                    return;
            }
            
            this.onButtonClicked.Invoke(obj:  this.forestProfileData);
        }
        public WFORevengeListItem()
        {
        
        }
    
    }

}
