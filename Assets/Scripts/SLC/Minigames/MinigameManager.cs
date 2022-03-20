using UnityEngine;

namespace SLC.Minigames
{
    public class MinigameManager : MonoSingleton<SLC.Minigames.MinigameManager>
    {
        // Fields
        public int numVideosRequired;
        public int numCoinContinuesUsed;
        private SLC.Minigames.MinigamePlayerData currentPlayerData;
        private SLC.Minigames.MinigameRankData currentRankData;
        private twelvegigs.storage.JsonDictionary currentKnobsData;
        private decimal checkpointReward;
        private decimal hintCost;
        private decimal continueCost;
        private decimal continueIncrement;
        private int currentPlayerLevel;
        public System.Action OnContinueMinigame;
        public System.Action OnRestartMinigame;
        public System.Action OnCheckpointRankUpContinue;
        public System.Action OnPauseClicked;
        public System.Action<System.Collections.Generic.Dictionary<string, object>> OnInjectTracking;
        public System.Action<bool> TogglePopupWindow;
        private int _session_startLevel;
        private int _session_adsWatched;
        private float _session_startTime;
        private decimal _session_continuePurchased;
        private bool QAHACK_freeContinues;
        
        // Properties
        private string[] gameSceneNames { get; }
        private int currentMinigameIndex { get; }
        public string CurrentMinigameScene { get; }
        public string CurrentMinigameId { get; }
        public string CurrentMinigameName { get; }
        public SLC.Minigames.MinigamePlayerData GetCurrentPlayerData { get; }
        public SLC.Minigames.MinigameRankData GetRankData { get; }
        public twelvegigs.storage.JsonDictionary GetCurrentKnobsData { get; }
        public SLC.Minigames.MinigameLevelRank GetCurrentRank { get; }
        public SLC.Minigames.MinigameLevelRank GetNextRank { get; }
        public int GetPlayerLevelInCurrentRank { get; }
        public int GetNextCheckpointLevel { get; }
        public int GetLevelsToNextCheckpoint { get; }
        public int GetMaximumPlayerLevel { get; }
        public decimal GetCurrentCheckpointReward { get; }
        public decimal GetCurrentHintCost { get; }
        public decimal GetCurrentContinueCost { get; }
        public int GetCurrentPlayerLevel { get; }
        public bool QAHACK_FreeContinues { get; set; }
        
        // Methods
        private string[] get_gameSceneNames()
        {
            AppConfigs val_1 = WordApp.getConfig();
            return val_1.minigamesConfig.MiniGamesScenes;
        }
        private int get_currentMinigameIndex()
        {
            return MonoSingleton<Bootstrapper>.Instance.CurrentMinigame;
        }
        public string get_CurrentMinigameScene()
        {
            MiniGame val_3 = val_1.minigamesConfig.GetMiniGameByIndex(index:  App.Configuration.currentMinigameIndex);
            return (string)val_3.scene;
        }
        public string get_CurrentMinigameId()
        {
            MiniGame val_3 = val_1.minigamesConfig.GetMiniGameByIndex(index:  App.Configuration.currentMinigameIndex);
            return (string)val_3.id;
        }
        public string get_CurrentMinigameName()
        {
            MiniGame val_3 = val_1.minigamesConfig.GetMiniGameByIndex(index:  App.Configuration.currentMinigameIndex);
            return (string)val_3.name;
        }
        public SLC.Minigames.MinigamePlayerData get_GetCurrentPlayerData()
        {
            return (SLC.Minigames.MinigamePlayerData)this.currentPlayerData;
        }
        public SLC.Minigames.MinigameRankData get_GetRankData()
        {
            return (SLC.Minigames.MinigameRankData)this.currentRankData;
        }
        public twelvegigs.storage.JsonDictionary get_GetCurrentKnobsData()
        {
            return (twelvegigs.storage.JsonDictionary)this.currentKnobsData;
        }
        public SLC.Minigames.MinigameLevelRank get_GetCurrentRank()
        {
            SLC.Minigames.MinigamePlayerData val_1 = this.currentPlayerData;
            if(val_1 <= this.currentPlayerData.rankIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + ((this.currentPlayerData.rankIndex) << 3);
            return (SLC.Minigames.MinigameLevelRank)(this.currentPlayerData + (this.currentPlayerData.rankIndex) << 3).rankCheckpoints;
        }
        public SLC.Minigames.MinigameLevelRank get_GetNextRank()
        {
            int val_3 = UnityEngine.Mathf.Min(a:  this.currentPlayerData.rankIndex + 1, b:  W21 - 1);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            return (SLC.Minigames.MinigameLevelRank)(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + (val_3) << 3) + 32;
        }
        public int get_GetPlayerLevelInCurrentRank()
        {
            SLC.Minigames.MinigameLevelRank val_1 = this.GetCurrentRank;
            return (int)this.currentPlayerLevel - val_1.rankLevel;
        }
        public int get_GetNextCheckpointLevel()
        {
            SLC.Minigames.MinigameLevelRank val_1 = this.GetCurrentRank;
            return val_1.rankCheckpoints.Find(match:  new System.Predicate<System.Int32>(object:  this, method:  System.Boolean SLC.Minigames.MinigameManager::<get_GetNextCheckpointLevel>b__28_0(int x)));
        }
        public int get_GetLevelsToNextCheckpoint()
        {
            int val_1 = this.GetNextCheckpointLevel;
            val_1 = val_1 - this.currentPlayerData.checkpointLevel;
            return (int)val_1;
        }
        public int get_GetMaximumPlayerLevel()
        {
            SLC.Minigames.MinigameLevelRank val_1 = System.Linq.Enumerable.Last<SLC.Minigames.MinigameLevelRank>(source:  this.currentRankData.ranks);
            SLC.Minigames.MinigameLevelRank val_2 = System.Linq.Enumerable.Last<SLC.Minigames.MinigameLevelRank>(source:  this.currentRankData.ranks);
            int val_3 = System.Linq.Enumerable.Last<System.Int32>(source:  val_2.rankCheckpoints);
            val_3 = val_3 + val_1.rankLevel;
            return (int)val_3;
        }
        public decimal get_GetCurrentCheckpointReward()
        {
            return new System.Decimal() {flags = this.checkpointReward, hi = this.checkpointReward};
        }
        public decimal get_GetCurrentHintCost()
        {
            return new System.Decimal() {flags = this.hintCost, hi = this.hintCost};
        }
        public decimal get_GetCurrentContinueCost()
        {
            decimal val_1 = System.Decimal.op_Implicit(value:  this.numCoinContinuesUsed);
            decimal val_2 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = this.continueIncrement, hi = this.continueIncrement, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
            return System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.continueCost, hi = this.continueCost, lo = 41971712}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        }
        public int get_GetCurrentPlayerLevel()
        {
            return (int)this.currentPlayerLevel;
        }
        private void Start()
        {
            var val_14;
            this.currentPlayerData = new SLC.Minigames.MinigamePlayerData();
            this.currentRankData = new SLC.Minigames.MinigameRankData();
            SLC.Minigames.MinigamesUIController val_3 = MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance;
            System.Delegate val_5 = System.Delegate.Combine(a:  val_3.ToggleExclusivePopup, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.MinigameManager::ToggleExclusivePopup(bool showingPopup)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_3.ToggleExclusivePopup = val_5;
            object[] val_6 = new object[1];
            val_6[0] = val_6.currentMinigameIndex.ToString();
            UnityEngine.Debug.LogFormat(format:  "Loading minigame index: {0}", args:  val_6);
            val_14 = null;
            val_14 = null;
            SLC.Minigames.MinigamesKnobsManager.defaultKnobData = new System.Action<twelvegigs.storage.JsonDictionary>(object:  this, method:  System.Void SLC.Minigames.MinigameManager::UpdateGameplayDataFromKnobs(twelvegigs.storage.JsonDictionary allMinigamesKnobs));
            this.UpdateGameplayDataFromKnobs(allMinigamesKnobs:  SLC.Minigames.MinigamesKnobsManager.GetKnobs());
            UnityEngine.AsyncOperation val_12 = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName:  this.CurrentMinigameScene, mode:  1);
            this.LoadCurrentPlayerData();
            this._session_startLevel = this.currentPlayerLevel;
            this._session_adsWatched = 0;
            this._session_startTime = UnityEngine.Time.unscaledTime;
            mem[1152921519752388788] = 0;
            this._session_continuePurchased = 0m;
        }
        private void ToggleExclusivePopup(bool showingPopup)
        {
            if(this.TogglePopupWindow == null)
            {
                    return;
            }
            
            showingPopup = showingPopup;
            this.TogglePopupWindow.Invoke(obj:  showingPopup);
        }
        private void UpdateGameplayDataFromKnobs(twelvegigs.storage.JsonDictionary allMinigamesKnobs)
        {
            var val_12;
            twelvegigs.storage.JsonDictionary val_31;
            string val_32;
            System.Collections.IDictionary val_33;
            twelvegigs.storage.JsonDictionary val_34;
            int val_35;
            var val_36;
            string val_37;
            string val_38;
            string val_39;
            val_31 = allMinigamesKnobs;
            AppConfigs val_1 = App.Configuration;
            MiniGame val_3 = val_1.minigamesConfig.GetMiniGameById(id:  this.CurrentMinigameId);
            val_32 = val_3.dlcPack;
            if((val_31.Contains(key:  val_32)) == false)
            {
                goto label_7;
            }
            
            this.currentKnobsData = val_31.getJsonDictionary(key:  val_32);
            twelvegigs.storage.JsonDictionary val_7 = val_31.getJsonDictionary(key:  val_32).getJsonDictionary(key:  "econ");
            val_31 = val_7;
            if((val_7.Contains(key:  "ranks")) == false)
            {
                goto label_40;
            }
            
            this.currentRankData.ranks.Clear();
            List.Enumerator<T> val_10 = val_31.getList(key:  "ranks").GetEnumerator();
            label_20:
            if(val_12.MoveNext() == false)
            {
                goto label_14;
            }
            
            val_33 = X0;
            val_34 = new twelvegigs.storage.JsonDictionary();
            val_34 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  val_33);
            if(this.currentRankData == null)
            {
                    throw new NullReferenceException();
            }
            
            if(new twelvegigs.storage.JsonDictionary() == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35 = new twelvegigs.storage.JsonDictionary().getInt(key:  "level", defaultValue:  0);
            val_36 = null;
            val_36 = null;
            decimal val_15 = new twelvegigs.storage.JsonDictionary().getDecimal(key:  "pct", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
            SLC.Minigames.MinigameLevelRank val_19 = null;
            val_33 = val_35;
            val_19 = new SLC.Minigames.MinigameLevelRank(level:  val_33, percentage:  new System.Decimal() {flags = val_15.flags, hi = val_15.hi, lo = val_15.lo, mid = val_15.mid}, name:  new twelvegigs.storage.JsonDictionary().getString(key:  "name", defaultValue:  ""), checkpoints:  new System.Collections.Generic.List<System.Object>(collection:  new twelvegigs.storage.JsonDictionary().getList(key:  "checkpoints")));
            if(this.currentRankData.ranks == null)
            {
                    throw new NullReferenceException();
            }
            
            this.currentRankData.ranks.Add(item:  val_19);
            goto label_20;
            label_7:
            val_38 = "MinigameManager could not find econ data for minigame ";
            goto label_21;
            label_14:
            val_12.Dispose();
            val_31 = val_31;
            val_39 = val_32;
            label_40:
            if((val_31.Contains(key:  "cn_rwd")) != false)
            {
                    decimal val_21 = val_31.getDecimal(key:  "cn_rwd", defaultValue:  new System.Decimal() {flags = this.checkpointReward, hi = this.checkpointReward});
                this.checkpointReward = val_21;
                mem[1152921519752754912] = val_21.lo;
                mem[1152921519752754916] = val_21.mid;
            }
            
            if((val_31.Contains(key:  "h_p")) != false)
            {
                    decimal val_23 = val_31.getDecimal(key:  "h_p", defaultValue:  new System.Decimal() {flags = this.hintCost, hi = this.hintCost});
                this.hintCost = val_23;
                mem[1152921519752754928] = val_23.lo;
                mem[1152921519752754932] = val_23.mid;
            }
            
            if((val_31.Contains(key:  "c_p")) != false)
            {
                    decimal val_25 = val_31.getDecimal(key:  "c_p", defaultValue:  new System.Decimal() {flags = this.continueCost, hi = this.continueCost});
                this.continueCost = val_25;
                mem[1152921519752754944] = val_25.lo;
                mem[1152921519752754948] = val_25.mid;
            }
            
            if((val_31.Contains(key:  "c_i")) != false)
            {
                    decimal val_27 = val_31.getDecimal(key:  "c_i", defaultValue:  new System.Decimal() {flags = this.continueIncrement, hi = this.continueIncrement});
                this.continueIncrement = val_27;
                mem[1152921519752754960] = val_27.lo;
                mem[1152921519752754964] = val_27.mid;
            }
            
            val_38 = "MinigameManager loaded ";
            val_37 = " level data from knobs.";
            label_21:
            UnityEngine.Debug.LogWarning(message:  val_38 + val_39 + val_37);
        }
        public void LoadCurrentPlayerData()
        {
            SLC.Minigames.MinigameRankData val_2 = this.currentRankData;
            this.currentPlayerData = this.LoadPlayerDataFrom_Prefs();
            if(val_2 <= val_1.rankIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + ((val_1.rankIndex) << 3);
            System.Collections.Generic.List<SLC.Minigames.MinigameLevelRank> val_3 = (this.currentRankData + (val_1.rankIndex) << 3).ranks;
            val_3 = this.currentPlayerData.checkpointLevel + val_3;
            this.currentPlayerLevel = val_3;
        }
        public void SaveCurrentPlayerData()
        {
            this.SavePlayerDataTo_Prefs();
        }
        private SLC.Minigames.MinigamePlayerData LoadPlayerDataFrom_Prefs()
        {
            var val_5;
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this.CurrentMinigameId, defaultValue:  "{}"));
            val_5 = 0;
            this.currentPlayerData.Decode(jasonObject:  null, sourceModel:  0);
            return (SLC.Minigames.MinigamePlayerData)this.currentPlayerData;
        }
        public static SLC.Minigames.MinigamePlayerData LoadMiniGameData(string minigameId)
        {
            var val_5;
            SLC.Minigames.MinigamePlayerData val_1 = new SLC.Minigames.MinigamePlayerData();
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  minigameId, defaultValue:  "{}"));
            val_5 = 0;
            val_1.Decode(jasonObject:  null, sourceModel:  0);
            return val_1;
        }
        private void SavePlayerDataTo_Prefs()
        {
            UnityEngine.PlayerPrefs.SetString(key:  this.CurrentMinigameId, value:  MiniJSON.Json.Serialize(obj:  this.currentPlayerData.Encode(destination:  0)));
        }
        public bool HandleLevelComplete()
        {
            System.Collections.Generic.List<System.Int32> val_11;
            var val_12;
            MinigameManager.<>c__DisplayClass64_0 val_1 = new MinigameManager.<>c__DisplayClass64_0();
            .<>4__this = this;
            int val_11 = this.currentPlayerLevel;
            val_11 = val_11 + 1;
            this.currentPlayerLevel = val_11;
            .currentRank = this.GetCurrentRank;
            val_11 = val_2.rankCheckpoints;
            int val_4 = val_11.FindLastIndex(match:  new System.Predicate<System.Int32>(object:  val_1, method:  System.Boolean MinigameManager.<>c__DisplayClass64_0::<HandleLevelComplete>b__0(int x)));
            if(val_4 == 1)
            {
                goto label_9;
            }
            
            SLC.Minigames.MinigamePlayerData val_12 = this.currentPlayerData;
            val_11 = val_4;
            if(((MinigameManager.<>c__DisplayClass64_0)[1152921519753779360].currentRank) <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_12 = val_12 + (val_11 << 2);
            if(this.currentPlayerData.checkpointLevel >= ((this.currentPlayerData + (val_4) << 2).rankCheckpoints))
            {
                goto label_9;
            }
            
            int val_13 = this.currentPlayerData.checkpointsReached;
            val_13 = val_13 + 1;
            this.currentPlayerData.checkpointsReached = val_13;
            if((this.currentPlayerData.rankIndex < (this.currentRankData.ranks.FindLastIndex(match:  new System.Predicate<SLC.Minigames.MinigameLevelRank>(object:  val_1, method:  System.Boolean MinigameManager.<>c__DisplayClass64_0::<HandleLevelComplete>b__1(SLC.Minigames.MinigameLevelRank x))))) || (this.currentPlayerLevel >= this.GetMaximumPlayerLevel))
            {
                goto label_15;
            }
            
            SLC.Minigames.MinigameLevelRank val_14 = (MinigameManager.<>c__DisplayClass64_0)[1152921519753779360].currentRank;
            if(val_14 <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_14 = val_14 + (((long)(int)(val_4)) << 2);
            this.currentPlayerData.checkpointLevel = val_14;
            this.SavePlayerDataTo_Prefs();
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowCheckpoint();
            goto label_23;
            label_9:
            val_12 = 0;
            return (bool)val_12;
            label_15:
            val_11 = this.currentPlayerLevel;
            if(val_11 < this.GetMaximumPlayerLevel)
            {
                    int val_15 = this.currentPlayerData.rankIndex;
                val_15 = val_15 + 1;
                this.currentPlayerData.rankIndex = val_15;
            }
            else
            {
                    this.currentPlayerLevel = (MinigameManager.<>c__DisplayClass64_0)[1152921519753779360].currentRank.rankLevel;
            }
            
            this.currentPlayerData.checkpointLevel = 0;
            this.SavePlayerDataTo_Prefs();
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowRankup();
            label_23:
            val_12 = 1;
            return (bool)val_12;
        }
        public bool HandleLevelFailed()
        {
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowContinue();
            return false;
        }
        public void HandleGameContinue()
        {
            if(this.OnContinueMinigame == null)
            {
                    return;
            }
            
            this.OnContinueMinigame.Invoke();
        }
        public void HandleGameRestart()
        {
            this.LoadCurrentPlayerData();
            this._session_startLevel = this.currentPlayerLevel;
            this._session_adsWatched = 0;
            this._session_startTime = UnityEngine.Time.unscaledTime;
            mem[1152921519754190052] = 0;
            this._session_continuePurchased = 0m;
            if(this.OnRestartMinigame == null)
            {
                    return;
            }
            
            this.OnRestartMinigame.Invoke();
        }
        public void HandleCheckpointRankUpContinue()
        {
            if(this.OnCheckpointRankUpContinue == null)
            {
                    return;
            }
            
            this.OnCheckpointRankUpContinue.Invoke();
        }
        public void HandleHomeClicked(bool redirectToGameplay = False)
        {
            Bootstrapper val_1 = MonoSingleton<Bootstrapper>.Instance;
            if(val_1.IsLoadingScene != false)
            {
                    return;
            }
            
            Bootstrapper val_2 = MonoSingleton<Bootstrapper>.Instance;
            redirectToGameplay = redirectToGameplay;
            val_2.HandleLeaveMinigame(redirectToGameplay:  redirectToGameplay, currentGame:  val_2.CurrentMinigameScene);
        }
        public UnityEngine.Texture GetMainGameAdvert()
        {
            AppConfigs val_1 = WordApp.getConfig();
            return UnityEngine.Resources.Load<UnityEngine.Texture2D>(path:  System.String.Format(format:  "RedirectAds/{0}", arg0:  val_1.appConfig.gamePathName));
        }
        public string GetMainGameName()
        {
            AppConfigs val_1 = WordApp.getConfig();
            return (string)val_1.appConfig.gameName;
        }
        public void HandlePauseClicked()
        {
            if(this.OnPauseClicked == null)
            {
                    return;
            }
            
            this.OnPauseClicked.Invoke();
        }
        private void OnApplicationPause(bool pauseStatus)
        {
            if(pauseStatus != false)
            {
                    return;
            }
            
            WGGenericNotificationsManager.CancelPostAdNotification();
        }
        private void OnDestroy()
        {
            null = null;
            SLC.Minigames.MinigamesKnobsManager.defaultKnobData = 0;
        }
        public void AdWatched()
        {
            int val_1 = this._session_adsWatched;
            val_1 = val_1 + 1;
            this._session_adsWatched = val_1;
        }
        public void Cointinue(decimal cost)
        {
            decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this._session_continuePurchased, hi = this._session_continuePurchased, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = cost.flags, hi = cost.hi, lo = cost.lo, mid = cost.mid});
            this._session_continuePurchased = val_1;
            mem[1152921519755301588] = val_1.lo;
            mem[1152921519755301592] = val_1.mid;
        }
        public void StartMinigameSession()
        {
            this._session_startLevel = this.currentPlayerLevel;
            this._session_adsWatched = 0;
            this._session_startTime = UnityEngine.Time.unscaledTime;
            mem[1152921519755413588] = 0;
            this._session_continuePurchased = 0m;
        }
        public void TrackMinigameSessionEnd()
        {
            bool val_22;
            var val_23;
            Player val_1 = App.Player;
            int val_22 = val_1.properties.MGPlaysCount;
            val_22 = val_22 + 1;
            val_1.properties.MGPlaysCount = val_22;
            Player val_2 = App.Player;
            decimal val_3 = System.Decimal.op_Implicit(value:  this.currentPlayerData.checkpointsReached);
            decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = this.checkpointReward, hi = this.checkpointReward, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            decimal val_5 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_2.properties.MGCoinsRewarded, hi = val_2.properties.MGCoinsRewarded, lo = 41971712}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
            val_2.properties.MGCoinsRewarded = val_5;
            mem2[0] = val_5.lo;
            mem[4] = val_5.mid;
            Player val_6 = App.Player;
            int val_23 = val_6.properties.MGAdsCount;
            val_23 = this._session_adsWatched + val_23;
            val_6.properties.MGAdsCount = val_23;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if((MonoSingleton<Bootstrapper>.Instance) == 0)
            {
                goto label_20;
            }
            
            int val_11 = MonoSingleton<Bootstrapper>.Instance.DeeplinkedWhichMinigame;
            if(val_11 != val_11.currentMinigameIndex)
            {
                goto label_20;
            }
            
            val_22 = (~(MonoSingleton<Bootstrapper>.Instance.DeeplinkConsumed)) & 1;
            goto label_24;
            label_20:
            val_22 = false;
            label_24:
            val_7.Add(key:  "Mini Game Deeplink", value:  val_22);
            MonoSingleton<Bootstrapper>.Instance.DeeplinkConsumed = true;
            val_7.Add(key:  "Mini Game Name", value:  this.CurrentMinigameName);
            SLC.Minigames.MinigameLevelRank val_17 = this.GetCurrentRank;
            val_7.Add(key:  "Current Rank", value:  val_17.rankName);
            val_7.Add(key:  "Checkpoint on Start", value:  this._session_startLevel);
            SLC.Minigames.MinigameLevelRank val_18 = this.GetCurrentRank;
            int val_24 = val_18.rankLevel;
            val_24 = val_24 + this.currentPlayerData.checkpointLevel;
            val_7.Add(key:  "Checkpoint on End", value:  val_24);
            val_7.Add(key:  "Ads Watched", value:  this._session_adsWatched);
            val_7.Add(key:  "Coin Continues Used", value:  this._session_continuePurchased);
            float val_19 = UnityEngine.Time.unscaledTime;
            val_19 = val_19 - this._session_startTime;
            val_7.Add(key:  "Total Time Played", value:  val_19);
            decimal val_20 = System.Decimal.op_Implicit(value:  this.currentPlayerData.checkpointsReached);
            decimal val_21 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = this.checkpointReward, hi = this.checkpointReward, lo = 1152921504619999232}, d2:  new System.Decimal() {flags = val_20.flags, hi = val_20.hi, lo = val_20.lo, mid = val_20.mid});
            val_7.Add(key:  "Reward Coins", value:  val_21);
            if(this.OnInjectTracking != null)
            {
                    this.OnInjectTracking.Invoke(obj:  val_7);
            }
            
            val_23 = null;
            val_23 = null;
            App.trackerManager.track(eventName:  "Mini Game Session", data:  val_7);
        }
        public void QAHACK_IncrementCheckpoint()
        {
            this.currentPlayerData.checkpointLevel = this.GetNextCheckpointLevel;
            this.SavePlayerDataTo_Prefs();
            this.HandleGameRestart();
        }
        public void QAHACK_DecrementCheckpoint()
        {
            SLC.Minigames.MinigameLevelRank val_1 = this.GetCurrentRank;
            this.currentPlayerData.checkpointLevel = val_1.rankCheckpoints.FindLast(match:  new System.Predicate<System.Int32>(object:  this, method:  System.Boolean SLC.Minigames.MinigameManager::<QAHACK_DecrementCheckpoint>b__80_0(int x)));
            this.SavePlayerDataTo_Prefs();
            this.HandleGameRestart();
        }
        public void QAHACK_IncrementRank()
        {
            int val_1 = this.currentPlayerData.rankIndex;
            val_1 = val_1 + 1;
            this.currentPlayerData.rankIndex = val_1;
            this.currentPlayerData.checkpointLevel = 0;
            this.SavePlayerDataTo_Prefs();
            this.HandleGameRestart();
        }
        public void QAHACK_DecrementRank()
        {
            this.currentPlayerData.rankIndex = UnityEngine.Mathf.Max(a:  0, b:  this.currentPlayerData.rankIndex - 1);
            this.currentPlayerData.checkpointLevel = 0;
            this.SavePlayerDataTo_Prefs();
            this.HandleGameRestart();
        }
        public bool get_QAHACK_FreeContinues()
        {
            return (bool)this.QAHACK_freeContinues;
        }
        public void set_QAHACK_FreeContinues(bool value)
        {
            this.QAHACK_freeContinues = value;
        }
        public MinigameManager()
        {
            this.numVideosRequired = 1;
            this.currentPlayerData = new SLC.Minigames.MinigamePlayerData();
            this.currentRankData = new SLC.Minigames.MinigameRankData();
            this.currentKnobsData = new twelvegigs.storage.JsonDictionary();
            decimal val_4 = new System.Decimal(value:  2);
            this.checkpointReward = val_4.flags;
            decimal val_5 = new System.Decimal(value:  120);
            this.hintCost = val_5.flags;
            decimal val_6 = new System.Decimal(value:  25);
            decimal val_7;
            this.continueCost = val_6.flags;
            val_7 = new System.Decimal(value:  25);
            this.continueIncrement = val_7.flags;
        }
        private bool <get_GetNextCheckpointLevel>b__28_0(int x)
        {
            if(this.currentPlayerData != null)
            {
                    return (bool)(this.currentPlayerData.checkpointLevel < x) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
        private bool <QAHACK_DecrementCheckpoint>b__80_0(int x)
        {
            if(this.currentPlayerData != null)
            {
                    return (bool)(this.currentPlayerData.checkpointLevel > x) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
