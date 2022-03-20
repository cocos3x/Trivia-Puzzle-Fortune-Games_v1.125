using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIMembersView : UIListViewController
    {
        // Fields
        private bool showRequestsLeadersOptions;
        private bool myMainGuildView;
        private bool MVPsView;
        private string memberGridItemPrefabName;
        private UnityEngine.GameObject _leaguesUIMemberGridItemPrefab;
        private int curr_invites;
        private int curr_members;
        private bool showingOtherGuild;
        private int currentGuildId;
        
        // Properties
        private UnityEngine.GameObject leaguesUIMemberGridItemPrefab { get; }
        private SLC.Social.Leagues.Guild CurrentGuild { get; }
        
        // Methods
        private UnityEngine.GameObject get_leaguesUIMemberGridItemPrefab()
        {
            UnityEngine.GameObject val_3;
            if(this._leaguesUIMemberGridItemPrefab == 0)
            {
                    this._leaguesUIMemberGridItemPrefab = PrefabLoader.LoadPrefab(featureName:  "Leagues", prefabName:  this.memberGridItemPrefabName);
                return val_3;
            }
            
            val_3 = this._leaguesUIMemberGridItemPrefab;
            return val_3;
        }
        protected override UnityEngine.GameObject GetMemberItemPrefab()
        {
            return this.leaguesUIMemberGridItemPrefab;
        }
        private SLC.Social.Leagues.Guild get_CurrentGuild()
        {
            if(this.currentGuildId != 1)
            {
                    return SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  this.currentGuildId);
            }
            
            if(this.myMainGuildView == false)
            {
                    return SLC.Social.Leagues.LeaguesManager.DAO.GetGuild(guildId:  this.currentGuildId);
            }
            
            return SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        }
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  2.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  3.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  7.ToString());
        }
        private void OnMyProfileUpdate()
        {
            if(this.showingOtherGuild != false)
            {
                    return;
            }
            
            this.StopCoroutines();
            this.Refresh(guildId:  this.currentGuildId);
        }
        private void OnGuildListUpdate()
        {
            if(this.showingOtherGuild == false)
            {
                    return;
            }
            
            this.StopCoroutines();
            this.Refresh(guildId:  this.currentGuildId);
        }
        private void OnMyGuildUpdate()
        {
            if(this.showingOtherGuild != false)
            {
                    return;
            }
            
            this.StopCoroutines();
            this.Refresh(guildId:  this.currentGuildId);
        }
        private void OnGuildMembersUpdate()
        {
            this.StopCoroutines();
            this.Refresh(guildId:  this.currentGuildId);
        }
        public void Refresh(int guildId)
        {
            this.currentGuildId = guildId;
            if(this.gameObject.activeInHierarchy == false)
            {
                    return;
            }
            
            this.DoRefresh();
        }
        private void OnEnable()
        {
            16894.GetComponent<UnityEngine.UI.ScrollRect>().verticalNormalizedPosition = 1f;
            this.DoRefresh();
        }
        private void OnSceneLoaded()
        {
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == 0)
            {
                    return;
            }
            
            System.Action<System.Boolean> val_4 = null;
            1152921504893161472 = val_4;
            val_4 = new System.Action<System.Boolean>(object:  MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance, method:  public System.Void SLC.Social.Leagues.LeaguesUIManager::ToggleLoadingPopup(bool state));
            mem[1152921519707634096] = 1152921504893161472;
        }
        private void DoRefresh()
        {
            bool val_16;
            SLC.Social.Leagues.GuildMembers val_17;
            if(this.CurrentGuild == null)
            {
                    return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_11;
            }
            
            SLC.Social.Leagues.Guild val_4 = this.CurrentGuild;
            SLC.Social.Leagues.Guild val_6 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(val_4.ServerId != val_6.ServerId)
            {
                goto label_11;
            }
            
            val_16 = this.showRequestsLeadersOptions;
            this.showingOtherGuild = false;
            if(val_16 == false)
            {
                goto label_31;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer != true)
            {
                    if(SLC.Social.Leagues.LeaguesManager.DAO.IsMaster == false)
            {
                goto label_31;
            }
            
            }
            
            SLC.Social.Leagues.Guild val_11 = this.CurrentGuild;
            goto label_31;
            label_11:
            val_16 = 0;
            this.showingOtherGuild = true;
            this.showRequestsLeadersOptions = false;
            label_31:
            this.curr_invites = val_16;
            SLC.Social.Leagues.Guild val_12 = this.CurrentGuild;
            this.curr_members = val_12.MemberCount;
            if(this.MVPsView != false)
            {
                    SLC.Social.Leagues.LeaguesDataController val_13 = SLC.Social.Leagues.LeaguesManager.DAO;
                val_17 = val_13.SeasonMvpMembers;
                int val_14 = val_17.Count;
            }
            else
            {
                    val_17 = this.curr_invites + val_12.MemberCount;
            }
            
            mem[1152921519707812632] = val_17;
            this.UpdateMembersGrid();
        }
        private void OnMemberClickedCallback(int memberId)
        {
            UnityEngine.GameObject val_1 = this.gameObject;
            if(memberId != 1)
            {
                    SLC.Social.Leagues.LeaguesUIManager.ShowPlayerProfile(serverId:  memberId, gridItem:  val_1);
                return;
            }
            
            val_1.SetActive(value:  false);
        }
        protected override void SetupGridItem(int i)
        {
            System.Action<System.Int32> val_17;
            int val_18;
            SLC.Social.Profile val_19;
            var val_20;
            if(this.myMainGuildView != false)
            {
                    val_17 = 0;
            }
            else
            {
                    System.Action<System.Int32> val_1 = null;
                val_17 = val_1;
                val_1 = new System.Action<System.Int32>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIMembersView::OnMemberClickedCallback(int memberId));
            }
            
            val_18 = this.curr_invites;
            if(val_18 > i)
            {
                    if(this.MVPsView == false)
            {
                goto label_4;
            }
            
            }
            
            SLC.Social.Leagues.Guild val_2 = this.CurrentGuild;
            if((i - val_18) >= val_2.members.Count)
            {
                goto label_7;
            }
            
            if(this.MVPsView == false)
            {
                goto label_8;
            }
            
            label_36:
            val_19 = SLC.Social.Leagues.LeaguesManager.DAO.GetMembers(memberships:  val_5.SeasonMvpMembers)[i];
            goto label_14;
            label_7:
            val_19 = 0;
            label_14:
            if((X24 + 24) <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_17 = X24 + 16;
            val_17 = val_17 + (i << 3);
            label_41:
            (X24 + 16 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIMemberGridItem>().UpdateUIFromMember(member:  val_19, rank:  (i + 1) - this.curr_invites, showLeadersOptions:  this.showRequestsLeadersOptions, request:  0, showMVP:  false, specialMVPMode:  this.MVPsView, clickOutAction:  val_1);
            return;
            label_4:
            SLC.Social.Leagues.Guild val_11 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_18 = mem[(SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + (i) << 3) + 32];
            val_18 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + (i) << 3) + 32;
            SLC.Social.Leagues.Guild val_13 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_20 = mem[(SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 16];
            val_20 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 16;
            goto label_33;
            label_8:
            SLC.Social.Profile[] val_15 = this.CurrentGuild.GetMembers();
            int val_18 = this.curr_invites;
            val_18 = i - val_18;
            if(val_18 < val_15.Length)
            {
                goto label_36;
            }
            
            throw new IndexOutOfRangeException();
            label_33:
            if((X25 + 24) <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_19 = X25 + 16;
            val_19 = val_19 + ((X24) << 3);
            SLC.Social.Leagues.LeaguesUIMemberGridItem val_16 = (X25 + 16 + (X24) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIMemberGridItem>();
            goto label_41;
        }
        private SLC.Social.Profile[] GetMembers(SLC.Social.Leagues.GuildMembers memberships)
        {
            return System.Linq.Enumerable.ToArray<SLC.Social.Profile>(source:  memberships.Values);
        }
        public LeaguesUIMembersView()
        {
            this.showRequestsLeadersOptions = true;
            this.myMainGuildView = true;
            this.currentGuildId = 0;
            this.memberGridItemPrefabName = "member_grid_item";
        }
    
    }

}
