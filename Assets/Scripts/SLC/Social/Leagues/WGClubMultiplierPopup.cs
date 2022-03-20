using UnityEngine;

namespace SLC.Social.Leagues
{
    public class WGClubMultiplierPopup : MonoBehaviour
    {
        // Fields
        private static readonly decimal maxMultiplier;
        private TweenCoinsText statviewText;
        private UnityEngine.UI.Text currentMultiplierText;
        private UnityEngine.UI.Text[] multiplierTexts;
        private UnityEngine.UI.Text[] costTexts;
        private UGUINetworkedButtonMultiGraphic[] multiplierButtons;
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Button storeButton;
        private UnityEngine.ParticleSystem trailParticles;
        private UnityEngine.ParticleSystem burstParticles;
        private UnityEngine.UI.Image currentMultiplierOverlay;
        private decimal costScale;
        private decimal currentMultiplier;
        private System.Decimal[] multiplierValues;
        private int currentIndex;
        private TrackerPurchasePoints purchasePoint;
        
        // Methods
        private void Awake()
        {
            var val_8;
            var val_9;
            val_8 = null;
            val_8 = null;
            this.costScale = SLC.Social.Leagues.LeaguesEconomy.MultiplierCostScale;
            this.multiplierValues = SLC.Social.Leagues.LeaguesEconomy.MultiplierOptions;
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnCloseClicked()));
            this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnStoreButtonClicked()));
            UGUINetworkedButtonMultiGraphic val_10 = this.multiplierButtons[0];
            mem2[0] = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnMultiplierButton1Clicked(bool connection));
            UGUINetworkedButtonMultiGraphic val_11 = this.multiplierButtons[1];
            mem2[0] = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnMultiplierButton2Clicked(bool connection));
            UGUINetworkedButtonMultiGraphic val_12 = this.multiplierButtons[2];
            mem2[0] = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnMultiplierButton3Clicked(bool connection));
            UGUINetworkedButtonMultiGraphic val_13 = this.multiplierButtons[3];
            System.Action<System.Boolean> val_6 = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnMultiplierButton4Clicked(bool connection));
            mem2[0] = val_6;
            val_9 = 0;
            label_25:
            if(0 >= this.multiplierTexts.Length)
            {
                goto label_20;
            }
            
            var val_8 = (0 + 1) - 1;
            UnityEngine.UI.Text val_16 = this.multiplierTexts[0];
            string val_9 = val_6.FormatMultiplierString(multiplier:  new System.Decimal() {flags = this.multiplierValues[val_9], hi = this.multiplierValues[val_9], lo = this.multiplierValues[val_9], mid = this.multiplierValues[val_9]});
            val_9 = val_9 + 16;
            if(this.multiplierTexts != null)
            {
                goto label_25;
            }
            
            throw new NullReferenceException();
            label_20:
            this.UpdateCurrentMultiplier(animate:  false);
            this.UpdateMultiplierCosts();
            this.ToggleButtonsInteractable(buttonInteractable:  true);
        }
        private void OnMultiplierButton1Clicked(bool connection)
        {
            this.purchasePoint = 70;
            this.ContributeMultiplier(multiplierIndex:  0, connection:  connection);
        }
        private void OnMultiplierButton2Clicked(bool connection)
        {
            this.purchasePoint = 71;
            this.ContributeMultiplier(multiplierIndex:  1, connection:  connection);
        }
        private void OnMultiplierButton3Clicked(bool connection)
        {
            this.purchasePoint = 72;
            this.ContributeMultiplier(multiplierIndex:  2, connection:  connection);
        }
        private void OnMultiplierButton4Clicked(bool connection)
        {
            this.purchasePoint = 73;
            this.ContributeMultiplier(multiplierIndex:  3, connection:  connection);
        }
        private void ContributeMultiplier(int multiplierIndex, bool connection)
        {
            int val_20;
            int val_21;
            int val_22;
            int val_23;
            int val_24;
            var val_25;
            System.Func<System.Boolean> val_27;
            var val_28;
            if(connection == false)
            {
                goto label_1;
            }
            
            this.currentIndex = multiplierIndex;
            decimal val_20 = this.multiplierValues[(long)multiplierIndex];
            decimal val_21 = this.multiplierValues[(long)multiplierIndex];
            decimal val_1 = this.CalculateMultiplierCost(multiplierIncrease:  new System.Decimal() {flags = val_20, hi = val_20, lo = val_21, mid = val_21});
            GameBehavior val_2 = App.getBehavior;
            if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                goto label_8;
            }
            
            Player val_3 = App.Player;
            val_20 = val_1.flags;
            val_21 = val_1.lo;
            val_22 = val_3._credits;
            val_23 = 1152921504884269056;
            goto label_14;
            label_1:
            GameBehavior val_4 = App.getBehavior;
            bool[] val_8 = new bool[2];
            val_8[0] = true;
            string[] val_9 = new string[2];
            val_24 = val_9.Length;
            val_9[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
            val_24 = val_9.Length;
            val_9[1] = "NULL";
            System.Func<System.Boolean>[] val_11 = new System.Func<System.Boolean>[2];
            val_25 = null;
            val_25 = null;
            val_27 = WGClubMultiplierPopup.<>c.<>9__21_0;
            if(val_27 == null)
            {
                    System.Func<System.Boolean> val_12 = null;
                val_27 = val_12;
                val_12 = new System.Func<System.Boolean>(object:  WGClubMultiplierPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGClubMultiplierPopup.<>c::<ContributeMultiplier>b__21_0());
                WGClubMultiplierPopup.<>c.<>9__21_0 = val_27;
            }
            
            val_11[0] = val_27;
            val_28 = null;
            val_28 = null;
            val_4.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_11, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
            label_8:
            Player val_14 = App.Player;
            decimal val_15 = System.Decimal.op_Implicit(value:  val_14._gems);
            val_22 = val_15.flags;
            val_23 = val_15.lo;
            val_20 = val_1.flags;
            val_21 = val_1.lo;
            label_14:
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_20, hi = val_1.hi, lo = val_21, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_22, hi = val_15.hi, lo = val_23, mid = val_15.mid})) != false)
            {
                    this.RedirectToStore();
                return;
            }
            
            SLC.Social.Leagues.LeaguesManager.DAO.ContributeMultiplier(multiplierOption:  this.currentIndex + 1, multiplierToContribute:  new System.Decimal() {flags = val_20, hi = val_20, lo = val_21, mid = val_21}, multiplierCost:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, resultAction:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnAddMultiplierSuccess(bool success)));
            this.ToggleButtonsInteractable(buttonInteractable:  false);
        }
        private void OnAddMultiplierSuccess(bool success)
        {
            decimal val_13;
            int val_14;
            this.UpdateMultiplierCosts();
            this.ToggleButtonsInteractable(buttonInteractable:  true);
            GameBehavior val_1 = App.getBehavior;
            if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
            {
                goto label_5;
            }
            
            Player val_2 = App.Player;
            val_13 = val_2._credits;
            if(this.statviewText != null)
            {
                goto label_9;
            }
            
            label_5:
            Player val_3 = App.Player;
            decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
            val_13 = val_4.flags;
            val_14 = val_4.lo;
            label_9:
            this.statviewText.Set(instantValue:  new System.Decimal() {flags = val_13, hi = val_4.hi, lo = val_14, mid = val_4.mid});
            UnityEngine.Vector3 val_7 = this.multiplierButtons[this.currentIndex].transform.position;
            this.trailParticles.transform.position = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            decimal val_8 = new System.Decimal(value:  10);
            decimal val_9 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = this.multiplierValues[this.currentIndex], hi = this.multiplierValues[this.currentIndex], lo = this.multiplierValues[this.currentIndex], mid = this.multiplierValues[this.currentIndex]}, d2:  new System.Decimal() {flags = val_8.flags, hi = val_8.flags, lo = val_8.lo, mid = val_8.lo});
            this.trailParticles.Emit(count:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}));
            this.burstParticles.Play();
            DG.Tweening.Tween val_12 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.75f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::<OnAddMultiplierSuccess>b__22_0()), ignoreTimeScale:  true);
        }
        private void UpdateCurrentMultiplier(bool animate = False)
        {
            this.currentMultiplier = val_2.LeaguePointsMultiplier;
            mem[1152921519741685600] = ???;
            string val_3 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild.FormatMultiplierString(multiplier:  new System.Decimal() {flags = val_2.LeaguePointsMultiplier, hi = val_2.LeaguePointsMultiplier});
            if(animate == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0.3f, y:  0.3f, z:  0.3f);
            DG.Tweening.Tweener val_6 = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.currentMultiplierText.transform, punch:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  0.45f, vibrato:  0, elasticity:  0.5f);
            DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.currentMultiplierOverlay, endValue:  0.15f, duration:  0.15f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::<UpdateCurrentMultiplier>b__23_0()));
        }
        private void UpdateMultiplierCosts()
        {
            var val_5;
            SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            this.currentMultiplier = val_2.LeaguePointsMultiplier;
            val_5 = 0;
            do
            {
                if(0 >= this.costTexts.Length)
            {
                    return;
            }
            
                var val_4 = (0 + 1) - 1;
                UnityEngine.UI.Text val_9 = this.costTexts[0];
                decimal val_5 = this.CalculateMultiplierCost(multiplierIncrease:  new System.Decimal() {flags = this.multiplierValues[val_5], hi = this.multiplierValues[val_5], lo = this.multiplierValues[val_5], mid = this.multiplierValues[val_5]});
                string val_6 = val_5.flags.ToString();
                val_5 = val_5 + 16;
            }
            while(this.costTexts != null);
            
            throw new NullReferenceException();
        }
        private void OnCloseClicked()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnStoreButtonClicked()
        {
            this.purchasePoint = 74;
            this.RedirectToStore();
        }
        private void RedirectToStore()
        {
            null = null;
            PurchaseProxy.currentPurchasePoint = this.purchasePoint;
            GameBehavior val_2 = App.getBehavior;
            MonoSingletonSelfGenerating<GameStoreManager>.Instance.ShowStore(categoryFocus:  ((val_2.<metaGameBehavior>k__BackingField) != 1) ? "" : "GEMS", storeCloseCallback:  new System.Action<System.Boolean, System.Boolean>(object:  this, method:  System.Void SLC.Social.Leagues.WGClubMultiplierPopup::OnCloseCallback(bool purchased, bool forcedClose)));
        }
        private void OnCloseCallback(bool purchased, bool forcedClose)
        {
            UnityEngine.Object val_9;
            UnityEngine.Component val_10;
            var val_11;
            val_9 = forcedClose;
            val_10 = this;
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWGStoreClosed");
            if(purchased == true)
            {
                    return;
            }
            
            if(val_9 == true)
            {
                    return;
            }
            
            GameBehavior val_3 = App.getBehavior;
            if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
            {
                    val_10 = 1152921513404137360;
                val_9 = MonoSingleton<AdsUIController>.Instance;
                if(val_9 == 0)
            {
                    return;
            }
            
                val_11 = null;
                val_11 = null;
                MonoSingleton<AdsUIController>.Instance.TryShowPromptVideo(entryPoint:  PurchaseProxy.currentPurchasePoint, showAsFlyout:  false);
                return;
            }
            
            GameBehavior val_7 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
        }
        private void ToggleButtonsInteractable(bool buttonInteractable)
        {
            UGUINetworkedButtonMultiGraphic val_5;
            var val_6;
            var val_7;
            var val_7 = 0;
            val_6 = 0;
            label_12:
            if(val_6 >= this.multiplierButtons.Length)
            {
                goto label_2;
            }
            
            val_5 = this.multiplierButtons[val_6];
            if(buttonInteractable == false)
            {
                goto label_4;
            }
            
            decimal val_1 = System.Decimal.op_Addition(d1:  new System.Decimal() {flags = this.currentMultiplier, hi = this.currentMultiplier, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.multiplierValues[val_7], hi = this.multiplierValues[val_7], lo = this.multiplierValues[val_7], mid = this.multiplierValues[val_7]});
            decimal val_2 = new System.Decimal(value:  231);
            val_7 = System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
            if(val_5 != null)
            {
                goto label_9;
            }
            
            label_4:
            val_7 = 0;
            label_9:
            val_5.interactable = false;
            val_6 = val_6 + 1;
            val_7 = val_7 + 16;
            if(this.multiplierButtons != null)
            {
                goto label_12;
            }
            
            throw new NullReferenceException();
            label_2:
            bool val_4 = buttonInteractable;
            this.closeButton.interactable = val_4;
            this.storeButton.interactable = val_4;
        }
        private decimal CalculateMultiplierCost(decimal multiplierIncrease)
        {
            decimal val_1 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = multiplierIncrease.flags, hi = multiplierIncrease.hi, lo = multiplierIncrease.lo, mid = multiplierIncrease.mid}, d2:  new System.Decimal() {flags = this.currentMultiplier, hi = this.currentMultiplier, lo = 41971712});
            decimal val_2 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this.currentMultiplier, hi = this.currentMultiplier, lo = 41971712});
            decimal val_3 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, d2:  new System.Decimal() {flags = this.costScale, hi = this.costScale, lo = 41971712});
            return System.Decimal.Ceiling(d:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        }
        private string FormatMultiplierString(decimal multiplier)
        {
            return (string)System.String.Format(format:  "x{0}", arg0:  multiplier);
        }
        public WGClubMultiplierPopup()
        {
            decimal val_1 = new System.Decimal(lo:  10, mid:  0, hi:  0, isNegative:  false, scale:  1);
            this.currentMultiplier = val_1.flags;
        }
        private void <OnAddMultiplierSuccess>b__22_0()
        {
            this.UpdateCurrentMultiplier(animate:  true);
        }
        private void <UpdateCurrentMultiplier>b__23_0()
        {
            DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.currentMultiplierOverlay, endValue:  0f, duration:  0.3f);
        }
        private static WGClubMultiplierPopup()
        {
            decimal val_1 = new System.Decimal(value:  231);
            SLC.Social.Leagues.WGClubMultiplierPopup.maxMultiplier = val_1.flags;
        }
    
    }

}
