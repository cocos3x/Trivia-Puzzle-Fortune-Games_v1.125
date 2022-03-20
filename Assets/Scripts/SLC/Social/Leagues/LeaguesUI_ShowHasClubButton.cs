using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_ShowHasClubButton : LeaguesUI_OnClickButton
    {
        // Methods
        protected override void OnClickAction()
        {
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.ShowHasGuildContainer();
        }
        public LeaguesUI_ShowHasClubButton()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
