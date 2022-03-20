using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_ShowLeaguesHelpButton : LeaguesUI_OnClickButton
    {
        // Fields
        private bool showLeaguesHelp;
        
        // Methods
        protected override void OnClickAction()
        {
            var val_6;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    if(this.showLeaguesHelp == false)
            {
                goto label_5;
            }
            
            }
            
            SLC.Social.Leagues.LeaguesWindowManager val_3 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance;
            val_6 = 1152921519717693360;
            goto label_9;
            label_5:
            val_6 = 1152921519717698480;
            label_9:
            SLC.Social.Leagues.LeaguesWindowManager val_5 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesUI_OptionsWindow>(showNext:  false);
        }
        public LeaguesUI_ShowLeaguesHelpButton()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
