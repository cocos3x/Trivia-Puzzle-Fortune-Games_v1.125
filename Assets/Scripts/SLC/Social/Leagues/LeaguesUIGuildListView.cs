using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesUIGuildListView : UIListViewController
    {
        // Fields
        private SLC.Social.Leagues.GuildsListType viewType;
        private bool updateOnEnable;
        private bool listenForGuildListUpdate;
        private string guildGridItemPrefabName;
        private UnityEngine.GameObject _leaguesUIGuildGridItemPrefab;
        private UnityEngine.UI.ScrollRect _GridScrollRect;
        public System.Action<UnityEngine.UI.ScrollRect> OnGuildListFinishedUIUpdate;
        protected bool actionableItems;
        private string _SearchTerm;
        private float nextSlowRefresh;
        
        // Properties
        private UnityEngine.GameObject leaguesUIGuildGridItemPrefab { get; }
        protected UnityEngine.UI.ScrollRect GridScrollRect { get; }
        public string SearchTerm { set; }
        
        // Methods
        private UnityEngine.GameObject get_leaguesUIGuildGridItemPrefab()
        {
            UnityEngine.GameObject val_3;
            if(this._leaguesUIGuildGridItemPrefab == 0)
            {
                    this._leaguesUIGuildGridItemPrefab = PrefabLoader.LoadPrefab(featureName:  "Leagues", prefabName:  this.guildGridItemPrefabName);
                return val_3;
            }
            
            val_3 = this._leaguesUIGuildGridItemPrefab;
            return val_3;
        }
        protected override UnityEngine.GameObject GetMemberItemPrefab()
        {
            return this.leaguesUIGuildGridItemPrefab;
        }
        protected UnityEngine.UI.ScrollRect get_GridScrollRect()
        {
            UnityEngine.UI.ScrollRect val_3;
            bool val_1 = UnityEngine.Object.op_Equality(x:  this._GridScrollRect, y:  0);
            if(val_1 != false)
            {
                    this._GridScrollRect = val_1.GetComponent<UnityEngine.UI.ScrollRect>();
                return val_3;
            }
            
            val_3 = this._GridScrollRect;
            return val_3;
        }
        private void Awake()
        {
            if(this.listenForGuildListUpdate == false)
            {
                    return;
            }
            
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  7.ToString());
        }
        private void Start()
        {
            mem[1152921519699443952] = new System.Action<System.Boolean>(object:  MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance, method:  public System.Void SLC.Social.Leagues.LeaguesUIManager::ToggleLoadingPopup(bool state));
            mem[1152921519699443960] = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesUIGuildListView::FinishedUIUpdate(bool state));
        }
        private void FinishedUIUpdate(bool state)
        {
            if(this.OnGuildListFinishedUIUpdate == null)
            {
                    return;
            }
            
            this.OnGuildListFinishedUIUpdate.Invoke(obj:  this.GridScrollRect);
        }
        private void OnGuildListUpdate()
        {
            this.StopCoroutines();
            this.SetupUI();
        }
        public void set_SearchTerm(string value)
        {
            this._SearchTerm = value;
            this.SearchForGuildByName(nameEntry:  value);
        }
        private void SearchForGuildByName(string nameEntry)
        {
            System.Collections.Generic.Dictionary<System.Int32, SLC.Social.Leagues.Guild> val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GetGuildsByName(queryString:  nameEntry);
            System.Collections.IEnumerator val_3 = this.UpdateWithSearch(term:  nameEntry);
        }
        private void OnEnable()
        {
            this.GridScrollRect.verticalNormalizedPosition = 1f;
            if(this.updateOnEnable == false)
            {
                    return;
            }
            
            this.SetupUI();
        }
        private void Update()
        {
            var val_3;
            if(this.viewType != 1)
            {
                    return;
            }
            
            if(UnityEngine.Time.time <= this.nextSlowRefresh)
            {
                    return;
            }
            
            val_3 = null;
            val_3 = null;
            float val_3 = SLC.Social.Leagues.LeaguesManager.SlowRefreshRequestInterval;
            val_3 = UnityEngine.Time.time + val_3;
            this.nextSlowRefresh = val_3;
            this.SearchForGuildByName(nameEntry:  this._SearchTerm);
        }
        public void ReadySetupUI()
        {
            this.SetupUI();
        }
        private void SetupUI()
        {
            if(this.viewType <= 5)
            {
                    var val_10 = 32561552 + (this.viewType) << 2;
                val_10 = val_10 + 32561552;
            }
            else
            {
                    mem[1152921519700480216] = 0;
                this.UpdateMembersGrid();
            }
        
        }
        private void UpdateItemWithOpen(int i)
        {
            var val_6;
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            var val_11;
            val_6 = i;
            val_7 = 1152921505022660608;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsToJoin;
            if((X22 + 24) <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_6 = X22 + 16;
            val_6 = val_6 + (val_6 << 3);
            if(this > val_6)
            {
                    val_7 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsToJoin;
                val_6 = (long)val_6;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_8 = mem[(SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64];
                val_8 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64;
                val_9 = 1;
                val_10 = 0;
                val_11 = 0;
            }
            else
            {
                    val_8 = 0;
                val_10 = 0;
                val_11 = 0;
                val_9 = 0;
            }
            
            (X22 + 16 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  false, showMemberCount:  false, finalSeasonRank:  0);
        }
        private System.Collections.IEnumerator UpdateWithSearch(string term)
        {
            .<>1__state = 0;
            .term = term;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesUIGuildListView.<UpdateWithSearch>d__27();
        }
        private void UpdateItemWithRanking(int i, bool actionableItems)
        {
            var val_16;
            System.Func<SLC.Social.Leagues.Guild, System.Decimal> val_18;
            var val_19;
            System.Func<SLC.Social.Leagues.Guild, System.Int32> val_21;
            val_16 = null;
            val_16 = null;
            val_18 = LeaguesUIGuildListView.<>c.<>9__28_0;
            if(val_18 == null)
            {
                    System.Func<SLC.Social.Leagues.Guild, System.Decimal> val_5 = null;
                val_18 = val_5;
                val_5 = new System.Func<SLC.Social.Leagues.Guild, System.Decimal>(object:  LeaguesUIGuildListView.<>c.__il2cppRuntimeField_static_fields, method:  System.Decimal LeaguesUIGuildListView.<>c::<UpdateItemWithRanking>b__28_0(SLC.Social.Leagues.Guild g));
                LeaguesUIGuildListView.<>c.<>9__28_0 = val_18;
            }
            
            val_19 = null;
            val_19 = null;
            val_21 = LeaguesUIGuildListView.<>c.<>9__28_1;
            if(val_21 == null)
            {
                    System.Func<SLC.Social.Leagues.Guild, System.Int32> val_7 = null;
                val_21 = val_7;
                val_7 = new System.Func<SLC.Social.Leagues.Guild, System.Int32>(object:  LeaguesUIGuildListView.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 LeaguesUIGuildListView.<>c::<UpdateItemWithRanking>b__28_1(SLC.Social.Leagues.Guild g));
                LeaguesUIGuildListView.<>c.<>9__28_1 = val_21;
            }
            
            var val_16 = 1152921519700930416;
            System.Linq.IOrderedEnumerable<TSource> val_8 = System.Linq.Enumerable.ThenBy<SLC.Social.Leagues.Guild, System.Int32>(source:  System.Linq.Enumerable.OrderBy<SLC.Social.Leagues.Guild, System.Decimal>(source:  Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<SLC.Social.Leagues.Guild>>(value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  SLC.Social.Leagues.LeaguesManager.DAO.GuildsInMyTier)), keySelector:  val_5), keySelector:  val_7);
            if(val_16 > i)
            {
                    if(val_16 <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_16 = val_16 + (i << 3);
                var val_17 = (1152921519700930416 + (i) << 3) + 32;
                mem2[0] = i + 1;
                if(val_17 <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_17 = val_17 + (((long)(int)(i)) << 3);
                SLC.Social.Leagues.LeaguesUIGuildGridItem val_10 = ((1152921519700930416 + (i) << 3) + 32 + ((long)(int)(i)) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>();
                val_10.clickable = actionableItems;
                if((actionableItems + 24) <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_18 = actionableItems + 16;
                val_18 = val_18 + (((long)(int)(i)) << 3);
                if(val_18 <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_18 = val_18 + (((long)(int)(i)) << 3);
                (actionableItems + 16 + ((long)(int)(i)) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guild:  ((actionableItems + 16 + ((long)(int)(i)) << 3) + ((long)(int)(i)) << 3) + 32, rankingView:  true, showMemberCount:  false, finalSeasonRank:  0);
                return;
            }
            
            if(val_16 <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_16 = val_16 + (i << 3);
            SLC.Social.Leagues.LeaguesUIGuildGridItem val_13 = (1152921519700930416 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>();
            val_13.clickable = actionableItems;
            if((actionableItems + 24) <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_19 = actionableItems + 16;
            val_19 = val_19 + (((long)(int)(i)) << 3);
            (actionableItems + 16 + ((long)(int)(i)) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  true, showMemberCount:  false, finalSeasonRank:  0);
        }
        private void UpdateItemWithRankingTier(int i)
        {
            var val_6;
            var val_7;
            var val_8;
            val_6 = i;
            val_7 = 1152921505022660608;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInSearchedTier;
            if((X22 + 24) <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_6 = X22 + 16;
            val_6 = val_6 + (val_6 << 3);
            if(this > val_6)
            {
                    val_7 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInSearchedTier;
                val_6 = (long)val_6;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_8 = mem[(SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64];
                val_8 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64;
            }
            else
            {
                    val_8 = 0;
            }
            
            (X22 + 16 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  true, showMemberCount:  false, finalSeasonRank:  0);
        }
        private void UpdateItemWithFinalSeasonRanking(int i)
        {
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            if((X22 + 24) <= i)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_4 = X22 + 16;
            val_4 = val_4 + (i << 3);
            SLC.Social.Leagues.LeaguesUIGuildGridItem val_2 = (X22 + 16 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>();
            if(this > i)
            {
                    SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_2.UpdateUIFromGuild(guild:  (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32, rankingView:  true, showMemberCount:  false, finalSeasonRank:  i);
                return;
            }
            
            val_2.UpdateUIFromGuild(guildId:  0, rankingView:  true, showMemberCount:  false, finalSeasonRank:  i);
        }
        private void UpdateItemWithInvites(int i)
        {
            var val_6;
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            var val_11;
            val_6 = i;
            val_7 = 1152921505022660608;
            System.Collections.Generic.List<SLC.Social.Leagues.Guild> val_2 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInvited;
            if((X22 + 24) <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_6 = X22 + 16;
            val_6 = val_6 + (val_6 << 3);
            if(this > val_6)
            {
                    val_7 = SLC.Social.Leagues.LeaguesManager.DAO.GuildsInvited;
                val_6 = (long)val_6;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_8 = mem[(SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64];
                val_8 = (SLC.Social.Leagues.LeaguesManager.__il2cppRuntimeField_cctor_finished + ((long)(int)(i)) << 3) + 32 + 64;
                val_9 = 1;
                val_10 = 0;
                val_11 = 0;
            }
            else
            {
                    val_8 = 0;
                val_10 = 0;
                val_11 = 0;
                val_9 = 0;
            }
            
            (X22 + 16 + (i) << 3) + 32.GetComponent<SLC.Social.Leagues.LeaguesUIGuildGridItem>().UpdateUIFromGuild(guildId:  0, rankingView:  false, showMemberCount:  false, finalSeasonRank:  0);
        }
        protected override void SetupGridItem(int i)
        {
            SLC.Social.Leagues.GuildsListType val_3 = this.viewType;
            if(val_3 == 0)
            {
                    this.UpdateItemWithOpen(i:  i);
                val_3 = this.viewType;
            }
            
            if(val_3 == 2)
            {
                    this.UpdateItemWithRanking(i:  i, actionableItems:  this.actionableItems);
                val_3 = this.viewType;
            }
            
            if(val_3 == 4)
            {
                    this.UpdateItemWithRankingTier(i:  i);
                val_3 = this.viewType;
            }
            
            if(val_3 == 3)
            {
                    this.UpdateItemWithFinalSeasonRanking(i:  i);
                val_3 = this.viewType;
            }
            
            if(val_3 == 1)
            {
                    UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateWithSearch(term:  this._SearchTerm));
                val_3 = this.viewType;
            }
            
            if(val_3 != 5)
            {
                    return;
            }
            
            this.UpdateItemWithInvites(i:  i);
        }
        public LeaguesUIGuildListView()
        {
            this.updateOnEnable = true;
            this.listenForGuildListUpdate = true;
            this.actionableItems = true;
            this.guildGridItemPrefabName = "club_grid_item";
            this.nextSlowRefresh = 30f;
            this._SearchTerm = "";
        }
    
    }

}
