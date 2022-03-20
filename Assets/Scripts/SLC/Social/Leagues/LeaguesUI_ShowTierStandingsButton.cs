using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_ShowTierStandingsButton : LeaguesUI_OnClickButton
    {
        // Methods
        protected override void OnClickAction()
        {
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowTierStandingsContainer();
        }
        public LeaguesUI_ShowTierStandingsButton()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
