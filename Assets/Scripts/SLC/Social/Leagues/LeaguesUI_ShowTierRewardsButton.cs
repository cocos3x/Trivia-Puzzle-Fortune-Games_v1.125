using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_ShowTierRewardsButton : LeaguesUI_OnClickButton
    {
        // Methods
        protected override void OnClickAction()
        {
            SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesRewards_Window>(showNext:  false);
        }
        public LeaguesUI_ShowTierRewardsButton()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
