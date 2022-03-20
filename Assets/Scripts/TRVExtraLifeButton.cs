using UnityEngine;
public class TRVExtraLifeButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image freeLifeCooldownOverlay;
    private UnityEngine.UI.Text timeRemainingText;
    private UnityEngine.GameObject labelOverlayObject;
    public System.Action<bool> ExtraLifeStateChange;
    private bool _ExtraLifeAvailable;
    
    // Properties
    public UnityEngine.UI.Button.ButtonClickedEvent onClick { get; }
    private bool ExtraLifeAvailable { get; set; }
    
    // Methods
    public UnityEngine.UI.Button.ButtonClickedEvent get_onClick()
    {
        UnityEngine.UI.Button val_1 = this.GetComponent<UnityEngine.UI.Button>();
        return (ButtonClickedEvent)val_1.m_OnClick;
    }
    private bool get_ExtraLifeAvailable()
    {
        return (bool)this._ExtraLifeAvailable;
    }
    private void set_ExtraLifeAvailable(bool value)
    {
        var val_1 = (this._ExtraLifeAvailable == true) ? 1 : 0;
        val_1 = val_1 ^ value;
        if((val_1 != false) && (this.ExtraLifeStateChange != null))
        {
                value = value;
            this.ExtraLifeStateChange.Invoke(obj:  value);
        }
        
        this._ExtraLifeAvailable = value;
    }
    private void OnEnable()
    {
        FrameSkipper val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this);
        val_1.updateLogic = new System.Action(object:  this, method:  System.Void TRVExtraLifeButton::UpdateCoolDown());
        val_1._framesToSkip = 10;
        this.timeRemainingText = this.GetComponentInChildren<UnityEngine.UI.Text>();
    }
    public void Init()
    {
        this.UpdateCoolDown();
    }
    private void UpdateCoolDown()
    {
        ulong val_23;
        var val_24;
        if((MonoSingleton<TRVMainController>.Instance.freeLifeAvailable) != false)
        {
                this.freeLifeCooldownOverlay.gameObject.SetActive(value:  true);
            this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
            TRVDataParser val_6 = MonoSingleton<TRVDataParser>.Instance;
            string val_8 = val_6.<playerPersistance>k__BackingField.TotalFreeLivesAvailable().ToString();
            this.labelOverlayObject.SetActive(value:  false);
            this.ExtraLifeAvailable = true;
            return;
        }
        
        System.DateTime val_10 = MonoSingleton<TRVMainController>.Instance.freeLifeAvailableAt;
        System.DateTime val_11 = ServerHandler.ServerTime;
        val_23 = val_11.dateData;
        System.TimeSpan val_12 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_10.dateData}, d2:  new System.DateTime() {dateData = val_23});
        double val_13 = val_12._ticks.TotalSeconds;
        TRVEcon val_14 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_14.bonusRewardedLivesEnabled != false)
        {
                string val_15 = Localization.Localize(key:  "free_upper", defaultValue:  "FREE", useSingularKey:  false);
            this.labelOverlayObject.SetActive(value:  false);
            this.ExtraLifeAvailable = true;
            UnityEngine.GameObject val_16 = this.freeLifeCooldownOverlay.gameObject;
            val_24 = 1;
        }
        else
        {
                System.DateTime val_18 = MonoSingleton<TRVMainController>.Instance.freeLifeAvailableAt;
            val_23 = val_18.dateData;
            System.DateTime val_19 = ServerHandler.ServerTime;
            System.TimeSpan val_20 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_23}, d2:  new System.DateTime() {dateData = val_19.dateData});
            string val_21 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_20._ticks}, formatted:  true);
            this.labelOverlayObject.SetActive(value:  true);
            this.ExtraLifeAvailable = false;
            val_24 = 0;
        }
        
        this.freeLifeCooldownOverlay.gameObject.SetActive(value:  false);
    }
    public TRVExtraLifeButton()
    {
    
    }

}
