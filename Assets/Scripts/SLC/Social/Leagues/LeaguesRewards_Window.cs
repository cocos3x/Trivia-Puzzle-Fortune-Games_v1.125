using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesRewards_Window : MonoBehaviour
    {
        // Fields
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay mainTierDisplay;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay prevButtonDisplay;
        private SLC.Social.Leagues.LeaguesUIGuildTierDisplay nextButtonDisplay;
        private SLC.Social.Leagues.LeaguesUI_TierRewardDisplay[] rewards;
        private UnityEngine.UI.Button prevButton;
        private UnityEngine.UI.Button nextButton;
        private UnityEngine.UI.Button closeButton;
        private int currentTier;
        
        // Properties
        private int buttonIndex { get; }
        
        // Methods
        private int get_buttonIndex()
        {
            return (int)this.currentTier - 1;
        }
        private void Start()
        {
            this.prevButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesRewards_Window::OnClick_Previous()));
            this.nextButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesRewards_Window::OnClick_Next()));
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesRewards_Window::<Start>b__10_0()));
        }
        private void OnEnable()
        {
            int val_5;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_5 = val_4.tier;
            }
            else
            {
                    val_5 = 1;
            }
            
            this.currentTier = val_5;
            this.UpdateUITier();
        }
        private void UpdateUITier()
        {
            this.mainTierDisplay.UpdateTierUI(guildTier:  this.currentTier);
            int val_7 = 0;
            label_6:
            if(val_7 >= this.rewards.Length)
            {
                goto label_3;
            }
            
            val_7 = val_7 + 1;
            this.rewards[val_7].UpdateFromLeagueTier(rank:  val_7, tier:  this.currentTier);
            if(this.rewards != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_3:
            float val_2 = UnityEngine.Mathf.Repeat(t:  (float)this.currentTier - 2, length:  15f);
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            this.nextButtonDisplay.UpdateTierUI(guildTier:  (int)val_2 + 1);
            float val_4 = UnityEngine.Mathf.Repeat(t:  (float)this.currentTier, length:  15f);
            val_4 = (val_4 == Infinityf) ? (-(double)val_4) : ((double)val_4);
            this.prevButtonDisplay.UpdateTierUI(guildTier:  (int)val_4 + 1);
        }
        private void OnClick_Previous()
        {
            float val_1 = UnityEngine.Mathf.Repeat(t:  (float)this.currentTier, length:  15f);
            val_1 = (val_1 == Infinityf) ? (-(double)val_1) : ((double)val_1);
            int val_2 = (int)val_1;
            val_2 = val_2 + 1;
            this.currentTier = val_2;
            this.UpdateUITier();
        }
        private void OnClick_Next()
        {
            float val_2 = UnityEngine.Mathf.Repeat(t:  (float)this.currentTier - 2, length:  15f);
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            int val_3 = (int)val_2;
            val_3 = val_3 + 1;
            this.currentTier = val_3;
            this.UpdateUITier();
        }
        public LeaguesRewards_Window()
        {
            this.currentTier = 0;
        }
        private void <Start>b__10_0()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
    
    }

}
