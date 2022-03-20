using UnityEngine;

namespace WordForest
{
    public class WFOFeatureMenu : WGFeatureMenu
    {
        // Fields
        private UnityEngine.Sprite forestsSprite;
        private UnityEngine.Sprite newsSprite;
        
        // Methods
        protected override void SetupMenuItems()
        {
            this.SetupForestsItem();
            this.SetupNewsItem();
            this.SetupDailyChallenge();
            this.SetupLeaguesItem();
            if(AdsManager.ShowAdsControlMenuItem() != false)
            {
                    this.SetupAdControl();
            }
            
            this.SetupMoreGames();
        }
        protected void SetupForestsItem()
        {
            var val_13;
            var val_16;
            bool val_17;
            val_16 = MonoSingleton<WordForest.WFOForestManager>.Instance;
            WGFeatureMenu.FeatureMenuItemConfig val_2 = new WGFeatureMenu.FeatureMenuItemConfig();
            GameBehavior val_3 = App.getBehavior;
            WordForest.WFOGameEcon val_4 = WordForest.WFOGameEcon.Instance;
            .enabled = ((val_3.<metaGameBehavior>k__BackingField) >= val_4.wordForestUnlockLevel) ? 1 : 0;
            .onClickAction = new System.Action(object:  this, method:  System.Void WordForest.WFOFeatureMenu::OnClickForestsItem());
            .itemSprite = this.forestsSprite;
            .featureNameText = Localization.Localize(key:  "forests_upper", defaultValue:  "Forests", useSingularKey:  false);
            WordForest.WFOGameEcon val_8 = WordForest.WFOGameEcon.Instance;
            .featureUnlockLevel = val_8.wordForestUnlockLevel;
            if(val_16.AffordableGrowthStages > 0)
            {
                goto label_12;
            }
            
            bool val_10 = val_16.IsForestChestCollected;
            if(val_10 == false)
            {
                goto label_12;
            }
            
            WordForest.WFOForestData val_12 = val_16.CurrentForestData;
            if(val_10.CurrentForestGrowth >= val_13)
            {
                goto label_13;
            }
            
            val_17 = 0;
            goto label_16;
            label_12:
            val_17 = true;
            label_16:
            .featureActionable = val_17;
            FeatureMenuItem val_14 = this.getNewItem();
            val_16 = ???;
            goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
            label_13:
            var val_16 = ~val_16.IsAtLastForest;
            val_16 = val_16 & 1;
            goto label_16;
        }
        private void OnClickForestsItem()
        {
            this.Close();
            GameBehavior val_1 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
        }
        protected void SetupNewsItem()
        {
            WordForest.WFOForestManager val_1 = MonoSingleton<WordForest.WFOForestManager>.Instance;
            WGFeatureMenu.FeatureMenuItemConfig val_2 = new WGFeatureMenu.FeatureMenuItemConfig();
            GameBehavior val_3 = App.getBehavior;
            WordForest.WFOGameEcon val_4 = WordForest.WFOGameEcon.Instance;
            .enabled = ((val_3.<metaGameBehavior>k__BackingField) >= val_4.wordForestUnlockLevel) ? 1 : 0;
            .onClickAction = new System.Action(object:  this, method:  System.Void WordForest.WFOFeatureMenu::OnClickNewsItem());
            .itemSprite = this.newsSprite;
            .featureNameText = Localization.Localize(key:  "news_upper", defaultValue:  "NEWS", useSingularKey:  false);
            WordForest.WFOGameEcon val_8 = WordForest.WFOGameEcon.Instance;
            .featureUnlockLevel = val_8.wordForestUnlockLevel;
            .featureActionable = (WordForest.WFONewsPopup.UnseenNewsCount > 0) ? 1 : 0;
            FeatureMenuItem val_11 = this.getNewItem();
            goto typeof(FeatureMenuItem).__il2cppRuntimeField_170;
        }
        private void OnClickNewsItem()
        {
            this.Close();
            GameBehavior val_1 = App.getBehavior;
            goto mem[(1152921504946249728 + (public WordForest.WFONewsPopup MetaGameBehavior::ShowUGUIMonolith<WordForest.WFONewsPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        protected override void SetupEventsItem()
        {
            object val_12;
            WGFeatureMenu.FeatureMenuItemConfig val_1 = new WGFeatureMenu.FeatureMenuItemConfig();
            GameBehavior val_2 = App.getBehavior;
            .enabled = (val_2.<metaGameBehavior>k__BackingField) & 1;
            .onClickAction = new System.Action(object:  this, method:  System.Void WGFeatureMenu::OnClickEventsItem());
            .itemSprite = 1152921516208336576;
            if((WGFeatureMenu.FeatureMenuItemConfig)[1152921518116486048].enabled != false)
            {
                    val_12 = System.String.Format(format:  "({0})", arg0:  MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount.ToString());
            }
            else
            {
                    val_12 = "";
            }
            
            .featureNameText = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "events_upper", defaultValue:  "EVENTS", useSingularKey:  false), arg1:  val_12);
            .featureUnlockLevel = 0;
            FeatureMenuItem val_11 = this.getNewItem();
        }
        public WFOFeatureMenu()
        {
        
        }
    
    }

}
