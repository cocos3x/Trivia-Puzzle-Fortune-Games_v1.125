using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesTabsUI : MonoBehaviour
    {
        // Fields
        private int desiredSiblingIndex;
        private UnityEngine.GameObject tabsBar;
        private UnityEngine.UI.Outline textOutline;
        private UnityEngine.UI.Image tabImage;
        private UnityEngine.GameObject tabUnderline;
        private ThemeTextSettings selectedTabTextSetting;
        private ThemeTextSettings unselectedTabTextSetting;
        private UnityEngine.Sprite selectedTabSprite;
        private UnityEngine.Sprite unselectedTabSprite;
        private ThemedText themedText;
        private bool selectedByDefault;
        private UnityEngine.UI.Toggle m_toggle;
        
        // Methods
        private void Start()
        {
            this.m_toggle = this.gameObject.GetComponent<UnityEngine.UI.Toggle>();
            val_2.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesTabsUI::<Start>b__12_0(bool arg0)));
            if(this.themedText == 0)
            {
                    return;
            }
            
            var val_5 = (this.selectedByDefault == false) ? 72 : 64;
            this.themedText.ApplyThemeTextSettings(newText:  null);
        }
        public LeaguesTabsUI()
        {
            this.selectedByDefault = true;
        }
        private void <Start>b__12_0(bool arg0)
        {
            UnityEngine.Sprite val_13;
            if(this.themedText != 0)
            {
                    var val_2 = (arg0 != true) ? 64 : 72;
                this.themedText.ApplyThemeTextSettings(newText:  null);
            }
            else
            {
                    if((UnityEngine.Object.op_Implicit(exists:  this.textOutline)) != false)
            {
                    this.textOutline.enabled = arg0;
            }
            
            }
            
            if(this.tabImage != 0)
            {
                    if(arg0 != false)
            {
                    val_13 = this.selectedTabSprite;
            }
            else
            {
                    val_13 = this.unselectedTabSprite;
            }
            
                this.tabImage.sprite = val_13;
            }
            
            this.m_toggle.interactable = (~arg0) & 1;
            if(((~arg0) & 1) == 0)
            {
                    if((UnityEngine.Object.op_Implicit(exists:  this.tabsBar)) != false)
            {
                    this.tabsBar.transform.SetAsLastSibling();
                if((UnityEngine.Object.op_Implicit(exists:  this.tabUnderline)) != false)
            {
                    this.tabUnderline.transform.SetAsLastSibling();
            }
            
            }
            
                this.transform.SetAsLastSibling();
                return;
            }
            
            this.transform.SetSiblingIndex(index:  this.desiredSiblingIndex);
        }
    
    }

}
