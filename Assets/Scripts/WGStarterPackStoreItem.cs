using UnityEngine;
public class WGStarterPackStoreItem : WGStoreItem
{
    // Fields
    private UnityEngine.UI.Text text_countdown_time;
    private UnityEngine.UI.Text text_coins_amount;
    private UnityEngine.UI.Text text_dollar_value;
    private FrameSkipper _skipper;
    
    // Properties
    private FrameSkipper skipper { get; }
    
    // Methods
    private FrameSkipper get_skipper()
    {
        FrameSkipper val_3;
        if(this._skipper == 0)
        {
                this._skipper = this.GetComponent<FrameSkipper>();
            return val_3;
        }
        
        val_3 = this._skipper;
        return val_3;
    }
    public override void Awake()
    {
        this.Awake();
        FrameSkipper val_1 = this.skipper;
        val_1.updateLogic = new System.Action(object:  this, method:  System.Void WGStarterPackStoreItem::UpdateTimer());
    }
    public override void UpdateUI(PurchaseModel pack, int packIndex, int totalPackItems, IStoreUI storeUI)
    {
        PurchaseModel val_6 = pack;
        this.UpdateUI(pack:  val_6 = pack, packIndex:  packIndex, totalPackItems:  totalPackItems, storeUI:  storeUI);
        if(this.text_coins_amount == 0)
        {
                return;
        }
        
        decimal val_2 = val_6.Credits;
        val_6 = val_2.flags.ToString(format:  "#,##0");
        string val_5 = System.String.Format(format:  "{0} {1}", arg0:  val_6, arg1:  Localization.Localize(key:  "coins_upper", defaultValue:  "COINS", useSingularKey:  false));
    }
    private void UpdateTimer()
    {
        System.TimeSpan val_2 = MonoSingleton<WGStarterPackController>.Instance.timeRemaining;
        string val_3 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_2._ticks}, formatted:  true);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public WGStarterPackStoreItem()
    {
        mem[1152921517983035640] = 1;
        val_1 = new MyButton();
    }

}
