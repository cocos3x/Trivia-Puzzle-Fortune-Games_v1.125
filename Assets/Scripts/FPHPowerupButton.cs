using UnityEngine;
public abstract class FPHPowerupButton : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Text labelCost;
    protected FPHEcon econ;
    protected UnityEngine.UI.Button button;
    
    // Properties
    protected abstract int Cost { get; }
    protected abstract string TrackingSource { get; }
    
    // Methods
    protected abstract int get_Cost(); // 0
    protected abstract string get_TrackingSource(); // 0
    protected virtual void Awake()
    {
        this.econ = App.GetGameSpecificEcon<FPHEcon>();
        this.button = this.GetComponent<UnityEngine.UI.Button>();
        val_2.m_OnClick.RemoveAllListeners();
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(FPHPowerupButton).__il2cppRuntimeField_1B8));
    }
    public virtual void Initialize()
    {
        string val_1 = this.ToString();
    }
    protected virtual void OnButtonClick()
    {
        UnityEngine.Object val_14;
        TrackerPurchasePoints val_15;
        var val_16;
        val_14 = 0;
        if((MonoSingleton<WGAudioController>.Instance) != val_14)
        {
                WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_14 = 0;
            val_3.sound.PlayButtonSound(type:  val_14, pitch:  1f, vol:  1f);
        }
        
        Player val_4 = App.Player;
        if(val_4._gems >= this)
        {
            goto label_13;
        }
        
        if((MonoSingleton<FPHPhraseOfTheDayController>.Instance) == 0)
        {
            goto label_18;
        }
        
        FPHPhraseOfTheDayController val_7 = MonoSingleton<FPHPhraseOfTheDayController>.Instance;
        val_15 = 126;
        if((val_7.<Status>k__BackingField) == null)
        {
            goto label_23;
        }
        
        var val_8 = ((val_7.<Status>k__BackingField.IsPlaying) == true) ? (val_15 + 1) : (val_15);
        goto label_23;
        label_13:
        if((this & 1) == 0)
        {
                return;
        }
        
        FPHGameplayController val_9 = FPHGameplayController.Instance;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        return;
        label_18:
        val_15 = 126;
        label_23:
        val_16 = null;
        val_16 = null;
        PurchaseProxy.currentPurchasePoint = val_15;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        GameBehavior val_12 = App.getBehavior;
        val_12.<metaGameBehavior>k__BackingField.Init(outOfCredits:  true, onCloseAction:  0);
    }
    protected abstract bool ExecutePowerup(); // 0
    protected FPHPowerupButton()
    {
    
    }

}
