using UnityEngine;
public class TRVExpertsProfilePopup : MonoBehaviour
{
    // Fields
    private TRVExpertDisplay eDisplay;
    private UnityEngine.UI.Button upgradeButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.GameObject upgradeSection;
    private UnityEngine.UI.Text upgradeCostText;
    private UnityEngine.UI.Text upgradeCardText;
    public System.Action onClose;
    private TRVExpert displayingExpert;
    private TRVExpertProgressData progData;
    
    // Methods
    public void Init(TRVExpert expert, TRVExpertProgressData data)
    {
        this.displayingExpert = expert;
        this.progData = data;
        this.DisplayExpertData(expert:  expert, data:  data, fromUpgrade:  false);
        this.closeButton.m_OnClick.RemoveAllListeners();
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsProfilePopup::Close()));
        this.storeButton.m_OnClick.RemoveAllListeners();
        this.storeButton.gameObject.SetActive(value:  false);
    }
    private void DisplayExpertData(TRVExpert expert, TRVExpertProgressData data, bool fromUpgrade = False)
    {
        bool val_11;
        UnityEngine.Events.UnityAction val_12;
        var val_13;
        val_11 = fromUpgrade;
        TRVExpertsController val_1 = MonoSingleton<TRVExpertsController>.Instance;
        val_12 = val_1.myEcon.getReqFromExpert(exp:  expert, prog:  data);
        fromUpgrade = val_11;
        this.eDisplay.Init(me:  expert, progress:  data, upgraded:  fromUpgrade, showName:  true);
        if(val_12 == null)
        {
            goto label_6;
        }
        
        string val_3 = val_2.coinsNeeded.ToString();
        string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  data.<cardsOwned>k__BackingField, arg1:  val_2.cardsNeeded);
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Implicit(value:  val_2.coinsNeeded);
        if(((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = this.upgradeCardText, mid = this.upgradeCardText}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid})) == false) || ((data.<cardsOwned>k__BackingField) < val_2.cardsNeeded))
        {
            goto label_16;
        }
        
        this.upgradeButton.m_OnClick.RemoveAllListeners();
        UnityEngine.Events.UnityAction val_8 = null;
        val_12 = val_8;
        val_8 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertsProfilePopup::Upgrade());
        this.upgradeButton.m_OnClick.AddListener(call:  val_8);
        UnityEngine.GameObject val_9 = this.upgradeButton.gameObject;
        val_13 = 1;
        goto label_23;
        label_6:
        this.upgradeSection.SetActive(value:  false);
        label_16:
        val_13 = 0;
        label_23:
        this.upgradeButton.gameObject.SetActive(value:  false);
    }
    private void Upgrade()
    {
        if((MonoSingleton<TRVExpertsController>.Instance.UpgradeExpert(name:  this.displayingExpert.expertName)) == false)
        {
                return;
        }
        
        TRVExpertsController val_3 = MonoSingleton<TRVExpertsController>.Instance;
        this.DisplayExpertData(expert:  this.displayingExpert, data:  val_3.myExperts.Item[this.displayingExpert.expertName], fromUpgrade:  true);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate");
    }
    private void OpenStore()
    {
        MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
        GameBehavior val_2 = App.getBehavior;
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  new System.Action(object:  this, method:  System.Void TRVExpertsProfilePopup::<OpenStore>b__13_0()));
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
    }
    private void Close()
    {
        if(this.onClose != null)
        {
                this.onClose.Invoke();
        }
        
        this.onClose = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVExpertsProfilePopup()
    {
    
    }
    private void <OpenStore>b__13_0()
    {
        .<>4__this = this;
        GameBehavior val_2 = App.getBehavior;
        .ecp = val_2.<metaGameBehavior>k__BackingField;
        mem2[0] = new System.Action(object:  new TRVExpertsProfilePopup.<>c__DisplayClass13_0(), method:  System.Void TRVExpertsProfilePopup.<>c__DisplayClass13_0::<OpenStore>b__1());
    }

}
