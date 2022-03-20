using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesEntryButton : MonoBehaviour
    {
        // Fields
        private UGUINetworkedButton networkedButton;
        private UnityEngine.UI.Text labelText;
        private bool gameButton;
        private bool disablesButton;
        private bool useFlyout;
        private UnityEngine.UI.Image clubAvatarImage;
        private UnityEngine.UI.Image defaultImage;
        private UnityEngine.GameObject rewardAvailableTooltip;
        private UnityEngine.GameObject rewardIcon;
        private bool displayLeagueName;
        public SLC.Social.AvatarConfig guildAvatarHandler;
        private bool showingFreeCoins;
        private bool showingDailyReward;
        public System.Action onLeaguesEntryAction;
        public System.Action onExitLeaguesAction;
        private bool playingEffect;
        
        // Properties
        public UGUINetworkedButton getButton { get; }
        
        // Methods
        public UGUINetworkedButton get_getButton()
        {
            return (UGUINetworkedButton)this.networkedButton;
        }
        private void Awake()
        {
            if(this.enabled == false)
            {
                    return;
            }
            
            System.Delegate val_3 = System.Delegate.Combine(a:  this.networkedButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesEntryButton::OnConnectionClick(bool connected)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_4;
            }
            
            }
            
            this.networkedButton.OnConnectionClick = val_3;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  1.ToString());
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
            return;
            label_4:
        }
        private void Start()
        {
            this.CheckActive();
        }
        private void OnServerSync()
        {
            this.CheckActive();
        }
        private void OnMyProfileUpdate()
        {
            this.CheckActive();
        }
        private void OnLocalize()
        {
            this.CheckActive();
        }
        private void CheckActive()
        {
            var val_9 = null;
            if((SLC.Social.Leagues.LeaguesManager.IsAvailable() == false) || ((MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance) == 0))
            {
                goto label_12;
            }
            
            SLC.Social.Leagues.LeaguesManager val_4 = MonoSingleton<SLC.Social.Leagues.LeaguesManager>.Instance;
            if(val_4._InitialResponseSuccess == false)
            {
                goto label_12;
            }
            
            this.networkedButton.gameObject.SetActive(value:  true);
            goto label_15;
            label_12:
            if(this.disablesButton != false)
            {
                    this.networkedButton.gameObject.SetActive(value:  false);
                return;
            }
            
            if(SLC.Social.Leagues.LeaguesManager.DAO == 0)
            {
                    return;
            }
            
            label_15:
            this.UpdateButtonUI();
        }
        private void UpdateButtonUI()
        {
            SLC.Social.AvatarConfig val_20;
            var val_21;
            string val_22;
            var val_23;
            var val_24;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    if(this.displayLeagueName != false)
            {
                    if(this.labelText != 0)
            {
                    SLC.Social.Leagues.Guild val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            }
            
            }
            
                this.clubAvatarImage.gameObject.SetActive(value:  true);
                if(this.defaultImage != 0)
            {
                    this.defaultImage.gameObject.SetActive(value:  false);
            }
            
                val_20 = this.guildAvatarHandler;
                SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                this.clubAvatarImage.sprite = val_20.GetAvatarSpriteByID(id:  val_10.AvatarId, portraitID:  0);
                val_21 = null;
                val_21 = null;
                val_22 = 1;
            }
            else
            {
                    string val_12 = Localization.Localize(key:  "league_upper", defaultValue:  "LEAGUE", useSingularKey:  false);
                val_20 = this.labelText;
                bool val_13 = UnityEngine.Object.op_Inequality(x:  val_20, y:  0);
                this.clubAvatarImage.gameObject.SetActive(value:  false);
                if(this.defaultImage != 0)
            {
                    this.defaultImage.gameObject.SetActive(value:  true);
            }
            
                val_21 = null;
                val_21 = null;
                val_22 = 0;
            }
            
            SLC.Social.Leagues.LeaguesUIManager.ON_AVATAR_CHANGED = val_22;
            this.showingFreeCoins = false;
            this.showingDailyReward = false;
            if(this.rewardAvailableTooltip == 0)
            {
                    return;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_18 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_23 = null;
            val_23 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_18.SeasonRewardAmount, hi = val_18.SeasonRewardAmount, lo = val_20, mid = val_20}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    val_24 = 1;
            }
            else
            {
                    val_24 = 0;
            }
            
            this.rewardAvailableTooltip.SetActive(value:  false);
        }
        private void OnConnectionClick(bool connected)
        {
            object val_44;
            var val_45;
            var val_46;
            var val_47;
            var val_48;
            string val_49;
            var val_50;
            var val_51;
            System.String[] val_52;
            int val_53;
            var val_54;
            var val_55;
            var val_56;
            FeatureAccessPoints val_57;
            var val_58;
            var val_59;
            var val_60;
            var val_61;
            val_44 = this;
            if(connected == false)
            {
                goto label_1;
            }
            
            if(this.showingDailyReward == false)
            {
                goto label_2;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_1 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_45 = 1152921504617017344;
            val_47 = null;
            val_47 = null;
            if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.DailyRewardAmount, hi = val_1.DailyRewardAmount, lo = 41967616}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
            {
                    if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_12;
            }
            
            }
            
            SLC.Social.Leagues.LeaguesDataController val_5 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_48 = null;
            val_48 = null;
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_5.DailyRewardAmount, hi = val_5.DailyRewardAmount, lo = 41967616}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
            {
                    return;
            }
            
            if(this.playingEffect == true)
            {
                    return;
            }
            
            this.playingEffect = true;
            DG.Tweening.Tweener val_10 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.rewardIcon.transform, endValue:  110f, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesEntryButton::<OnConnectionClick>b__25_0()));
            return;
            label_1:
            val_50 = null;
            val_50 = null;
            if(App.game == 17)
            {
                    WGFlyoutManager val_11 = MonoSingleton<WGFlyoutManager>.Instance;
                val_51 = 1152921517526870000;
            }
            else
            {
                    val_51 = 1152921515849370336;
            }
            
            val_44 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false);
            val_49 = Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false);
            bool[] val_16 = new bool[2];
            val_16[0] = true;
            string[] val_17 = new string[2];
            val_52 = val_17;
            val_53 = val_17.Length;
            val_52[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_53 = val_17.Length;
            val_52[1] = "NULL";
            val_54 = null;
            val_54 = null;
            val_44.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  val_49, shownButtons:  val_16, buttonTexts:  val_17, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            return;
            label_2:
            if(this.showingFreeCoins == false)
            {
                goto label_46;
            }
            
            SLC.Social.Leagues.LeaguesDataController val_19 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_55 = 1152921504617017344;
            val_56 = null;
            val_56 = null;
            if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_19.SeasonRewardAmount, hi = val_19.SeasonRewardAmount, lo = 41967616}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) == false)
            {
                    return;
            }
            
            GameBehavior val_21 = App.getBehavior;
            SLC.Social.Leagues.LeaguesDataController val_22 = SLC.Social.Leagues.LeaguesManager.DAO;
            mem2[0] = 0;
            val_22.SeasonRewardAmount = 0m;
            goto label_130;
            label_46:
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild == null)
            {
                goto label_64;
            }
            
            if(this.gameButton == false)
            {
                goto label_65;
            }
            
            GameBehavior val_25 = App.getBehavior;
            if(((val_25.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                goto label_70;
            }
            
            var val_28 = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (14 + 1) : 14;
            goto label_112;
            label_12:
            GameBehavior val_29 = App.getBehavior;
            SLC.Social.Leagues.LeaguesDataController val_30 = SLC.Social.Leagues.LeaguesManager.DAO;
            mem2[0] = 0;
            val_30.DailyRewardAmount = 0m;
            goto label_130;
            label_64:
            SLC.Social.Leagues.LeaguesDataController val_31 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_58 = null;
            val_58 = null;
            if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_31.SeasonRewardAmount, hi = val_31.SeasonRewardAmount, lo = 41967616}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
            {
                    SLC.Social.Leagues.LeaguesDataController val_33 = SLC.Social.Leagues.LeaguesManager.DAO;
                mem2[0] = 0;
                val_33.SeasonRewardAmount = 0m;
            }
            
            val_59 = null;
            val_59 = null;
            if(App.game == 17)
            {
                goto label_97;
            }
            
            val_59 = null;
            val_59 = null;
            if(App.game != 19)
            {
                goto label_103;
            }
            
            label_97:
            GameBehavior val_34 = App.getBehavior;
            WGLeaguesLoadingPopup val_35 = val_34.<metaGameBehavior>k__BackingField.GetComponent<WGLeaguesLoadingPopup>();
            label_141:
            if(this.onExitLeaguesAction != null)
            {
                    val_35.onLeaguesExitAction = this.onExitLeaguesAction;
            }
            
            if(this.onLeaguesEntryAction == null)
            {
                    return;
            }
            
            this.onLeaguesEntryAction.Invoke();
            return;
            label_65:
            val_57 = 13;
            goto label_112;
            label_70:
            val_57 = 14;
            label_112:
            val_46 = 1152921504887996416;
            val_60 = null;
            val_60 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = val_57;
            if(this.useFlyout != false)
            {
                    GameBehavior val_36 = App.getBehavior;
                val_61 = val_36.<metaGameBehavior>k__BackingField;
                mem2[0] = 1;
            }
            else
            {
                    WGWindowManager val_39 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  false);
            }
            
            if(this.onExitLeaguesAction != null)
            {
                    mem2[0] = this.onExitLeaguesAction;
            }
            
            if(this.onLeaguesEntryAction != null)
            {
                    this.onLeaguesEntryAction.Invoke();
            }
            
            label_130:
            this.UpdateButtonUI();
            return;
            label_103:
            if(this.useFlyout == false)
            {
                goto label_131;
            }
            
            GameBehavior val_40 = App.getBehavior;
            mem2[0] = 1;
            goto label_141;
            label_131:
            WGWindowManager val_43 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesLoadingPopup>(showNext:  false);
            goto label_141;
        }
        private void OnCollectDailyAnimationComplete()
        {
            SLC.Social.Leagues.LeaguesDataController val_2 = SLC.Social.Leagues.LeaguesManager.DAO;
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.DailyRewardAmount, hi = val_2.DailyRewardAmount}, source:  "Daily First Golden Currency Reward", subSource:  0, externalParams:  0, doTrack:  true);
            SLC.Social.Leagues.LeaguesDataController val_3 = SLC.Social.Leagues.LeaguesManager.DAO;
            mem2[0] = 0;
            val_3.DailyRewardAmount = 0m;
            this.UpdateButtonUI();
            MainController val_4 = MainController.instance;
            System.Delegate val_6 = System.Delegate.Remove(source:  val_4.coin_stat_view_anim.OnClosedCallback, value:  new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesEntryButton::OnCollectDailyAnimationComplete()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_4.coin_stat_view_anim.OnClosedCallback = val_6;
            return;
            label_13:
        }
        public LeaguesEntryButton()
        {
            this.disablesButton = true;
            this.displayLeagueName = true;
        }
        private void <OnConnectionClick>b__25_0()
        {
            DG.Tweening.Tweener val_4 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.rewardIcon.transform, duration:  1f, strength:  10f, vibrato:  10, randomness:  90f, snapping:  false, fadeOut:  true), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesEntryButton::<OnConnectionClick>b__25_1()));
        }
        private void <OnConnectionClick>b__25_1()
        {
            PluginExtension.SetColorAlpha(graphic:  this.rewardIcon.GetComponent<UnityEngine.UI.Image>(), a:  0f);
            this.rewardIcon.GetComponentInChildren<UnityEngine.ParticleSystem>().Play();
            WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGameSpecificSound(id:  "WordStarredSuccess", clipIndex:  0);
            MainController val_4 = MainController.instance;
            Player val_5 = App.Player;
            Player val_6 = App.Player;
            SLC.Social.Leagues.LeaguesDataController val_7 = SLC.Social.Leagues.LeaguesManager.DAO;
            decimal val_8 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_6._credits, hi = val_6._credits, lo = X23, mid = X23}, d2:  new System.Decimal() {flags = val_7.DailyRewardAmount, hi = val_7.DailyRewardAmount, lo = X26, mid = X26});
            val_4.coin_stat_view_anim.Play(startCoins:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = X22, mid = X22}, finalCoins:  new System.Decimal() {flags = val_8.flags, hi = val_8.hi, lo = val_8.lo, mid = val_8.mid}, particleStart:  this.rewardIcon.transform, forceTextTween:  false);
            MainController val_10 = MainController.instance;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_10.coin_stat_view_anim.OnClosedCallback, b:  new System.Action(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesEntryButton::OnCollectDailyAnimationComplete()));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_25;
            }
            
            }
            
            val_10.coin_stat_view_anim.OnClosedCallback = val_12;
            this.playingEffect = false;
            return;
            label_25:
        }
    
    }

}
