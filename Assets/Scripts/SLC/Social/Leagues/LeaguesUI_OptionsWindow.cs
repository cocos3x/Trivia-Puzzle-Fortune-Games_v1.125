using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_OptionsWindow : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button leagueInfoButton;
        private UnityEngine.UI.Button contributeButton;
        private UnityEngine.UI.Button leaveClubButton;
        private UnityEngine.UI.Button editClubButton;
        
        // Methods
        private void Start()
        {
            this.leagueInfoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_OptionsWindow::OnLeagueInfoClick()));
            this.contributeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_OptionsWindow::OnContributeClick()));
            this.leaveClubButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_OptionsWindow::OnLeaveClubClick()));
            this.editClubButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_OptionsWindow::OnEditClubClick()));
        }
        private void OnEnable()
        {
            this.editClubButton.gameObject.SetActive(value:  SLC.Social.Leagues.LeaguesManager.DAO.IsMaster);
        }
        private void OnLeagueInfoClick()
        {
            this.gameObject.SetActive(value:  false);
            SLC.Social.Leagues.LeaguesWindowManager val_3 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesHelp_Window>(showNext:  false);
        }
        private void OnContributeClick()
        {
            this.gameObject.SetActive(value:  false);
            SLC.Social.Leagues.LeaguesWindowManager val_3 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.ClubLevelContribution_Window>(showNext:  false);
        }
        private void OnLeaveClubClick()
        {
            this.gameObject.SetActive(value:  false);
            MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance.OnLeaveGuildClicked(newGuildIdToJoin:  0, inviteRequired:  false);
        }
        private void OnEditClubClick()
        {
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsMaster != false)
            {
                    this.gameObject.SetActive(value:  false);
                SLC.Social.Leagues.LeaguesWindowManager val_5 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.ClubEdit_Window>(showNext:  false);
                return;
            }
            
            this.editClubButton.gameObject.SetActive(value:  false);
        }
        public LeaguesUI_OptionsWindow()
        {
        
        }
    
    }

}
