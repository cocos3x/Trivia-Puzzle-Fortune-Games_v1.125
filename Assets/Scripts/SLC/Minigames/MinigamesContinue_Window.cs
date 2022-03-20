using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesContinue_Window : MonoBehaviour
    {
        // Fields
        private MultiGraphicButton storeButton;
        private UnityEngine.UI.Text coinAmountText;
        private UnityEngine.UI.Button useCoinsButton;
        private UnityEngine.UI.Text useCoinsButtonText;
        private UnityEngine.UI.Text useCoinsButtonText_largeCount;
        private UnityEngine.UI.Button watchVideosButton;
        private UnityEngine.GameObject watchVideosContinueGroup;
        private UnityEngine.GameObject watchVideosGroup;
        private UnityEngine.UI.Text watchVideosButtonText;
        private UnityEngine.UI.Text watchVideosButtonText_largeCount;
        private UnityEngine.UI.Button continueButton;
        private UnityEngine.UI.Text rankText;
        private System.Collections.Generic.List<SLC.Minigames.MinigameRankSpriteDisplay> rankDisplayIcons;
        private UnityEngine.UI.Text plusLivesText;
        private UnityEngine.UI.RawImage lifeDisplayImage;
        private UnityEngine.UI.RawImage snakeLivesImage;
        private UnityEngine.UI.Slider nextRankSlider;
        private UnityEngine.UI.Text sliderText;
        private UnityEngine.UI.HorizontalLayoutGroup rankTextGroup;
        private int numVideosWatched;
        
        // Methods
        private void Start()
        {
            this.useCoinsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesContinue_Window::OnClick_UseCoinsButton()));
            this.watchVideosButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesContinue_Window::OnClick_WatchVideosButton()));
            this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesContinue_Window::OnClick_ContinueButton()));
            if(this.storeButton == 0)
            {
                    return;
            }
            
            this.storeButton.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesContinue_Window::OnClick_StoreButton()));
        }
        private void OnClick_ContinueButton()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            this.numVideosWatched = 0;
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void OnClick_StoreButton()
        {
            var val_6;
            var val_7;
            System.Action val_9;
            val_6 = null;
            val_6 = null;
            PurchaseProxy.currentPurchasePoint = 22;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            val_7 = null;
            val_7 = null;
            val_9 = MinigamesContinue_Window.<>c.<>9__22_0;
            if(val_9 == null)
            {
                    System.Action val_4 = null;
                val_9 = val_4;
                val_4 = new System.Action(object:  MinigamesContinue_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MinigamesContinue_Window.<>c::<OnClick_StoreButton>b__22_0());
                MinigamesContinue_Window.<>c.<>9__22_0 = val_9;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  val_4);
        }
        private void OnClick_UseCoinsButton()
        {
            var val_30;
            TrackerPurchasePoints val_31;
            var val_32;
            System.Action val_34;
            Player val_1 = App.Player;
            decimal val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentContinueCost;
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = 41967616}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) != false)
            {
                    decimal val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentContinueCost;
                bool val_10 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, source:  System.String.Format(format:  "MG {0} CONTINUE", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), externalParams:  0, animated:  false);
                decimal val_13 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentContinueCost;
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.Cointinue(cost:  new System.Decimal() {flags = val_13.flags, hi = val_13.hi, lo = val_13.lo, mid = val_13.mid});
                SLC.Minigames.MinigameManager val_14 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                int val_29 = val_14.numCoinContinuesUsed;
                val_29 = val_29 + 1;
                val_14.numCoinContinuesUsed = val_29;
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleGameContinue();
                SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
                return;
            }
            
            string val_18 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId;
            if((System.String.op_Equality(a:  val_18, b:  "Just2Emojis")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 44;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_18, b:  "ImageQuiz")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 39;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_18, b:  "SnakeBlock")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 43;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_18, b:  "TwistyArrow")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 41;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_18, b:  "Whack")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 40;
            }
            else
            {
                    if((System.String.op_Equality(a:  val_18, b:  "WordQuiz")) != false)
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 42;
            }
            else
            {
                    val_30 = null;
                val_30 = null;
                val_31 = 0;
            }
            
            }
            
            }
            
            }
            
            }
            
            }
            
            PurchaseProxy.currentPurchasePoint = val_31;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            val_32 = null;
            val_32 = null;
            val_34 = MinigamesContinue_Window.<>c.<>9__23_0;
            if(val_34 == null)
            {
                    System.Action val_28 = null;
                val_34 = val_28;
                val_28 = new System.Action(object:  MinigamesContinue_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MinigamesContinue_Window.<>c::<OnClick_UseCoinsButton>b__23_0());
                MinigamesContinue_Window.<>c.<>9__23_0 = val_34;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  val_28);
        }
        private void OnClick_WatchVideosButton()
        {
            var val_19;
            int val_20;
            var val_21;
            System.Func<System.Boolean> val_23;
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(this.numVideosWatched >= val_1.numVideosRequired)
            {
                goto label_4;
            }
            
            SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_2.QAHACK_freeContinues == false)
            {
                goto label_8;
            }
            
            label_4:
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            int val_19 = val_3.numVideosRequired;
            val_19 = val_19 + 1;
            val_3.numVideosRequired = val_19;
            this.numVideosWatched = 0;
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleGameContinue();
            label_44:
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
            label_8:
            MinigamesAdsController val_6 = MonoSingleton<MinigamesAdsController>.Instance;
            if(((MonoSingleton<Bootstrapper>.Instance.CurrentMinigame) - 1) > 13)
            {
                goto label_18;
            }
            
            val_19 = mem[32555792 + ((val_8 - 1)) << 2];
            val_19 = 32555792 + ((val_8 - 1)) << 2;
            if(val_6 != null)
            {
                goto label_19;
            }
            
            label_18:
            val_19 = 20;
            label_19:
            if((val_6.ShowIncentivizedVideo(heyZapAdTag:  20)) != false)
            {
                    return;
            }
            
            SLC.Minigames.MinigamesUIController val_11 = MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance;
            bool[] val_14 = new bool[2];
            val_14[0] = true;
            string[] val_15 = new string[2];
            val_20 = val_15.Length;
            val_15[0] = Localization.Localize(key:  "try_again_later_upper", defaultValue:  "TRY AGAIN LATER", useSingularKey:  false);
            val_20 = val_15.Length;
            val_15[1] = "NULL";
            System.Func<System.Boolean>[] val_17 = new System.Func<System.Boolean>[2];
            val_21 = null;
            val_21 = null;
            val_23 = MinigamesContinue_Window.<>c.<>9__24_0;
            if(val_23 == null)
            {
                    System.Func<System.Boolean> val_18 = null;
                val_23 = val_18;
                val_18 = new System.Func<System.Boolean>(object:  MinigamesContinue_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean MinigamesContinue_Window.<>c::<OnClick_WatchVideosButton>b__24_0());
                MinigamesContinue_Window.<>c.<>9__24_0 = val_23;
            }
            
            val_17[0] = val_23;
            X0.ShowMessage(titleTxt:  Localization.Localize(key:  "unavailable_upper", defaultValue:  "UNAVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "no_videos_explanation", defaultValue:  "Sorry, no videos available at this time.", useSingularKey:  false), shownButtons:  val_14, buttonTexts:  val_15, showClose:  false, buttonCallbacks:  val_17);
            goto label_44;
        }
        private bool isContinueStyle(int index)
        {
            int val_1 = index - 1;
            if(val_1 > 13)
            {
                    return true;
            }
            
            val_1 = 5446 >> val_1;
            return (bool)val_1 & 1;
        }
        private void OnVideoResponse(Notification notif)
        {
            var val_17;
            int val_18;
            var val_19;
            string val_20;
            int val_21;
            var val_22;
            System.Func<System.Boolean> val_24;
            val_18 = this;
            bool val_3 = System.Boolean.Parse(value:  notif.data.ToString());
            UnityEngine.Debug.Log(message:  "MinigamesContinue_Window OnVideoResponse " + val_3.ToString());
            if(val_3 == false)
            {
                goto label_8;
            }
            
            int val_17 = this.numVideosWatched;
            val_17 = val_17 + 1;
            this.numVideosWatched = val_17;
            this.UpdateVideoButton();
            val_18 = this.numVideosWatched;
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_18 != val_6.numVideosRequired)
            {
                    return;
            }
            
            val_17 = 1152921504617017344;
            val_18 = App.Player;
            val_19 = null;
            val_19 = null;
            if(((MonoSingleton<Bootstrapper>.Instance.CurrentMinigame) - 1) > 13)
            {
                goto label_20;
            }
            
            val_20 = mem[39724544 + ((val_8 - 1)) << 3];
            val_20 = 39724544 + ((val_8 - 1)) << 3;
            if(val_18 != null)
            {
                goto label_21;
            }
            
            label_8:
            val_17 = MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance;
            bool[] val_12 = new bool[2];
            val_12[0] = true;
            string[] val_13 = new string[2];
            val_21 = val_13.Length;
            val_13[0] = "TRY AGAIN";
            val_21 = val_13.Length;
            val_13[1] = "NULL";
            System.Func<System.Boolean>[] val_14 = new System.Func<System.Boolean>[2];
            val_22 = null;
            val_22 = null;
            val_24 = MinigamesContinue_Window.<>c.<>9__26_0;
            if(val_24 == null)
            {
                    System.Func<System.Boolean> val_15 = null;
                val_24 = val_15;
                val_15 = new System.Func<System.Boolean>(object:  MinigamesContinue_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean MinigamesContinue_Window.<>c::<OnVideoResponse>b__26_0());
                MinigamesContinue_Window.<>c.<>9__26_0 = val_24;
            }
            
            val_14[0] = val_24;
            X0.ShowMessage(titleTxt:  "FAIL", messageTxt:  "Failed while watching video.", shownButtons:  val_12, buttonTexts:  val_13, showClose:  false, buttonCallbacks:  val_14);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
            label_20:
            val_20 = "MG Continue From Ads";
            label_21:
            val_18.AddCredits(amount:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0}, source:  val_20, subSource:  0, externalParams:  0, doTrack:  true);
        }
        private void Close()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnEnable()
        {
            var val_37;
            var val_38;
            UnityEngine.Component val_46;
            UnityEngine.Object val_47;
            float val_48;
            MinigamesContinue_Window.<>c__DisplayClass28_0 val_1 = null;
            val_46 = 0;
            val_1 = new MinigamesContinue_Window.<>c__DisplayClass28_0();
            NotificationCenter val_2 = NotificationCenter.DefaultCenter;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = this;
            val_2.AddObserver(observer:  this, name:  "OnVideoResponse");
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            .currentPlayer = val_3.currentPlayerData;
            SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            SLC.Minigames.MinigameLevelRank val_5 = val_4.GetCurrentRank;
            val_47 = this.coinAmountText;
            val_46 = 0;
            if(val_47 != val_46)
            {
                    if(App.Player == null)
            {
                    throw new NullReferenceException();
            }
            
                if(App.getGameEcon == null)
            {
                    throw new NullReferenceException();
            }
            
                val_46 = val_8.numberFormatInt;
                if(this.coinAmountText == null)
            {
                    throw new NullReferenceException();
            }
            
                val_46 = val_7._credits.ToString(format:  val_46);
                val_47 = this.coinAmountText;
            }
            
            if(((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex) < 1)
            {
                goto label_18;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_10.currentRankData == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_10.currentRankData.ranks == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_45 = (MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex;
            int val_11 = val_45 - 1;
            if(val_10.currentRankData <= val_11)
            {
                    val_47 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_45 = val_45 + (val_11 << 3);
            if((((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex + (((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex - 1)) < + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = ((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex + (((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex - 1)) < + 32 + 20;
            val_46 = ((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex + (((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.rankIndex - 1)) < + 32 + 28;
            val_48 = System.Decimal.ToSingle(d:  new System.Decimal() {flags = val_47, hi = val_47, lo = val_46, mid = val_46});
            if(val_5 != null)
            {
                goto label_29;
            }
            
            throw new NullReferenceException();
            label_18:
            val_48 = 100f;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_29:
            System.Predicate<System.Int32> val_14 = null;
            val_46 = val_1;
            val_14 = new System.Predicate<System.Int32>(object:  val_1, method:  System.Boolean MinigamesContinue_Window.<>c__DisplayClass28_0::<OnEnable>b__0(int x));
            if(val_5.rankCheckpoints == null)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = val_5.rankCheckpoints;
            val_46 = val_14;
            if(val_5.rankCheckpoints == null)
            {
                    throw new NullReferenceException();
            }
            
            SLC.Minigames.MinigameManager val_19 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            SLC.Minigames.MinigameManager val_21 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            if(((MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.nextRankSlider == null)
            {
                    throw new NullReferenceException();
            }
            
            float val_46 = (float)val_19.GetPlayerLevelInCurrentRank;
            float val_47 = (float)(MinigamesContinue_Window.<>c__DisplayClass28_0)[1152921519762585456].currentPlayer.checkpointLevel;
            val_46 = val_46 - val_47;
            val_47 = (float)val_21.GetNextCheckpointLevel - val_47;
            val_47 = val_46 / val_47;
            if(App.getGameEcon == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = UnityEngine.Mathf.Lerp(a:  val_48, b:  System.Decimal.ToSingle(d:  new System.Decimal() {flags = val_5.percentPlayersComplete, hi = val_5.percentPlayersComplete, lo = X23, mid = X23}), t:  ((float)val_47.FindIndex(match:  val_14)) / ((float)val_5.rankCheckpoints - 1)).ToString(format:  val_23.numberFormatInt);
            if(this.sliderText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = System.String.Format(format:  "Only {0}% of players reach this point", arg0:  val_46);
            SLC.Minigames.MinigameManager val_26 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            if(val_26.GetCurrentRank == null)
            {
                    throw new NullReferenceException();
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = public System.String System.Enum::ToString();
            if(val_27.rankName == null)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = val_27.rankName;
            val_46 = 0.ToString();
            if((val_47.Equals(value:  val_46)) == false)
            {
                goto label_52;
            }
            
            val_46 = "";
            if(this.rankText != null)
            {
                goto label_53;
            }
            
            throw new NullReferenceException();
            label_52:
            SLC.Minigames.MinigameManager val_30 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            if(val_30.GetCurrentRank == null)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = val_31.rankName;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = val_47.ToUpper();
            if(this.rankText == null)
            {
                    throw new NullReferenceException();
            }
            
            label_53:
            SLC.Minigames.MinigameManager val_33 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_33 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            SLC.Minigames.MinigameLevelRank val_34 = val_33.GetCurrentRank;
            if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            UnityEngine.Color val_35 = val_34.TitleColor;
            if(this.rankText == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = public System.Void UnityEngine.UI.Graphic::set_color(UnityEngine.Color value);
            this.rankText.color = new UnityEngine.Color() {r = val_35.r, g = val_35.g, b = val_35.b, a = val_35.a};
            val_47 = this.rankDisplayIcons;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_36 = val_47.GetEnumerator();
            label_72:
            val_46 = public System.Boolean List.Enumerator<SLC.Minigames.MinigameRankSpriteDisplay>::MoveNext();
            if(val_38.MoveNext() == false)
            {
                goto label_67;
            }
            
            SLC.Minigames.MinigameManager val_40 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_40 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_37.DisplaySprite(rank:  val_40.GetCurrentRank);
            goto label_72;
            label_67:
            val_46 = public System.Void List.Enumerator<SLC.Minigames.MinigameRankSpriteDisplay>::Dispose();
            val_38.Dispose();
            val_47 = this.rankTextGroup;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            val_47.enabled = false;
            val_47 = this.rankTextGroup;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 0;
            val_47.spacing = 15f;
            val_47 = this.rankTextGroup;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = 1;
            val_47.enabled = true;
            Bootstrapper val_42 = MonoSingleton<Bootstrapper>.Instance;
            if(val_42 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_42.CurrentMinigame - 1) <= 6)
            {
                    var val_48 = 32555508 + ((val_43 - 1)) << 2;
                val_48 = val_48 + 32555508;
            }
            else
            {
                    this.UpdateCoinButton();
                this.UpdateVideoButton();
            }
        
        }
        private void SetupLifeDisplay(bool heart, int numLives = 1)
        {
            if(heart != false)
            {
                    this.lifeDisplayImage.enabled = true;
                this.snakeLivesImage.enabled = false;
                this.plusLivesText.enabled = true;
                string val_1 = "+"("+") + numLives;
                return;
            }
            
            this.snakeLivesImage.enabled = true;
            this.lifeDisplayImage.enabled = false;
            this.plusLivesText.enabled = false;
        }
        private void UpdateCoinButton()
        {
            decimal val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentContinueCost;
            GameEcon val_3 = App.getGameEcon;
            string val_4 = val_2.flags.ToString(format:  val_3.numberFormatInt);
        }
        private void UpdateVideoButton()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_1.numVideosRequired <= this.numVideosWatched)
            {
                goto label_4;
            }
            
            SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_2.QAHACK_freeContinues == false)
            {
                goto label_8;
            }
            
            label_4:
            this.watchVideosContinueGroup.SetActive(value:  true);
            this.watchVideosGroup.SetActive(value:  false);
            return;
            label_8:
            this.watchVideosContinueGroup.SetActive(value:  false);
            this.watchVideosGroup.SetActive(value:  true);
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            UnityEngine.GameObject val_4 = this.watchVideosButtonText_largeCount.gameObject;
            if(val_3.numVideosRequired == 1)
            {
                    val_4.SetActive(value:  false);
                return;
            }
            
            val_4.SetActive(value:  true);
            SLC.Minigames.MinigameManager val_6 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            string val_8 = System.String.Format(format:  "{0}/{1}", arg0:  this.numVideosWatched.ToString(), arg1:  val_6.numVideosRequired.ToString());
            SLC.Minigames.MinigameManager val_9 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            int val_12 = val_9.numVideosRequired;
            val_12 = val_12 - this.numVideosWatched;
            if(val_12 <= 1)
            {
                    return;
            }
            
            string val_11 = System.String.Format(format:  "CONTINUE w/ {0} VIDEOS", arg0:  val_12.ToString());
        }
        private void OnDisable()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
        }
        public MinigamesContinue_Window()
        {
        
        }
    
    }

}
