using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUI_MyClubLevelDetails : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text clubLevelText;
        private UnityEngine.UI.Slider clubLevelSlider;
        private UnityEngine.UI.Text clubMemberCountText;
        private UnityEngine.UI.Button contributeButton;
        
        // Properties
        private SLC.Social.Leagues.Guild CurrentGuild { get; }
        
        // Methods
        private SLC.Social.Leagues.Guild get_CurrentGuild()
        {
            return SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        }
        private void Awake()
        {
            this.contributeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUI_MyClubLevelDetails::OnContributeButtonPressed()));
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  3.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
        }
        private void OnMyProfileUpdate()
        {
            this.Refresh();
        }
        private void OnGuildMembersUpdate()
        {
            this.Refresh();
        }
        public void Refresh()
        {
            if(this.gameObject.activeInHierarchy == false)
            {
                    return;
            }
            
            this.DoRefresh();
        }
        private void OnEnable()
        {
            this.DoRefresh();
        }
        private void DoRefresh()
        {
            UnityEngine.UI.Slider val_33;
            int val_34;
            val_33 = this;
            SLC.Social.Leagues.Guild val_1 = this.CurrentGuild;
            if(val_1 == null)
            {
                    return;
            }
            
            SLC.Social.Leagues.Guild val_2 = val_1.CurrentGuild;
            SLC.Social.Leagues.Guild val_3 = val_2.MemberCount.CurrentGuild;
            string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  val_2.MemberCount, arg1:  val_3.maximumMembers);
            bool val_5 = UnityEngine.Object.op_Implicit(exists:  this.clubMemberCountText);
            SLC.Social.Leagues.Guild val_6 = this.clubMemberCountText.CurrentGuild;
            string val_7 = val_6.guildLevel.ToString();
            val_34 = 1152921505022660608;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level == SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel)
            {
                    return;
            }
            
            decimal val_17 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.Level.CoinSupportRequired;
            decimal val_21 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.NextLevel.CoinSupportRequired;
            val_34 = val_21.lo;
            decimal val_24 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.GetLeagueContributedCoins;
            SLC.Social.Leagues.Guild val_28 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            decimal val_29 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.ProgressThisLevel(currentLevel:  val_28.guildLevel);
            decimal val_30 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_24.flags, hi = val_24.hi, lo = val_24.lo, mid = val_24.mid}, d2:  new System.Decimal() {flags = val_29.flags, hi = val_29.hi, lo = val_29.lo, mid = val_29.mid});
            val_33 = this.clubLevelSlider;
            decimal val_31 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_30.flags, hi = val_30.hi, lo = val_30.lo, mid = val_30.mid}, d2:  new System.Decimal() {flags = val_21.flags, hi = val_21.hi, lo = val_34, mid = val_21.mid});
            float val_32 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_31.lo, mid = val_31.mid});
        }
        private void OnContributeButtonPressed()
        {
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == 0)
            {
                    return;
            }
            
            MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance.OnShowContributePopup();
        }
        public LeaguesUI_MyClubLevelDetails()
        {
        
        }
    
    }

}
