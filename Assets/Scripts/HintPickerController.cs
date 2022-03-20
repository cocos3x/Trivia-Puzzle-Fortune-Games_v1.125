using UnityEngine;
public class HintPickerController : MonoSingleton<HintPickerController>
{
    // Fields
    public static bool IsPickingHint;
    private UnityEngine.GameObject HintPickerGroup;
    private UnityEngine.GameObject closeButton;
    private UnityEngine.UI.Text HintPickerText;
    private UnityEngine.GameObject buttonsGroup;
    private UnityEngine.GameObject gameHintPickerButton;
    private UnityEngine.Sprite tileSpotHighlightDisabled;
    private UnityEngine.GameObject WordRegionGroup;
    private UnityEngine.Canvas wordRegionCanvas;
    private UnityEngine.UI.GraphicRaycaster wordRegionRaycaster;
    private LineWord selectedLine;
    private Cell selectedCell;
    private bool isFreeOne;
    public System.Action<bool> OnPickOverlayStateChanged;
    
    // Properties
    public UnityEngine.GameObject getHintPickerGroup { get; }
    public UnityEngine.UI.Text hintPickerText { get; }
    public UnityEngine.GameObject GameHintPickerButton { get; }
    public UnityEngine.Sprite TileSpotHighlightDisabled { get; }
    
    // Methods
    public UnityEngine.GameObject get_getHintPickerGroup()
    {
        return (UnityEngine.GameObject)this.HintPickerGroup;
    }
    public UnityEngine.UI.Text get_hintPickerText()
    {
        return (UnityEngine.UI.Text)this.HintPickerText;
    }
    public UnityEngine.GameObject get_GameHintPickerButton()
    {
        return (UnityEngine.GameObject)this.gameHintPickerButton;
    }
    public UnityEngine.Sprite get_TileSpotHighlightDisabled()
    {
        return (UnityEngine.Sprite)this.tileSpotHighlightDisabled;
    }
    public void OnHintPickButtonClicked(bool free = False)
    {
        var val_19;
        int val_20;
        var val_21;
        var val_22;
        val_19 = this;
        decimal val_1 = CurrencyController.GetBalance();
        val_20 = val_1.flags;
        GameEcon val_2 = App.getGameEcon;
        if(((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_20, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2._HintPickerCost, hi = val_2._HintPickerCost, lo = X24, mid = X24})) == true) || (free == true))
        {
            goto label_7;
        }
        
        val_19 = 1152921504891564032;
        val_21 = null;
        val_21 = null;
        PurchaseProxy.currentPurchasePoint = 8;
        if(WGStarterPackController.featureRelavent == false)
        {
            goto label_13;
        }
        
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
        WGStarterPackController val_7 = MonoSingleton<WGStarterPackController>.Instance;
        val_7._ap = 47;
        return;
        label_7:
        this.isFreeOne = free;
        this.HintPickerGroup.SetActive(value:  true);
        string val_9 = Localization.Localize(key:  "hintpicker_pick_empty", defaultValue:  "Pick an empty box to reveal that letter", useSingularKey:  false);
        this.HintPickerText.gameObject.SetActive(value:  true);
        this.closeButton.SetActive(value:  false);
        UnityEngine.Vector3 val_13 = this.gameHintPickerButton.transform.position;
        this.closeButton.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        if(this.wordRegionCanvas == 0)
        {
                UnityEngine.Canvas val_15 = this.WordRegionGroup.AddComponent<UnityEngine.Canvas>();
            this.wordRegionCanvas = val_15;
            val_15.overrideSorting = true;
            this.wordRegionCanvas.sortingLayerName = "Foreground";
            this.wordRegionCanvas.sortingOrder = 2;
        }
        
        UnityEngine.UI.GraphicRaycaster val_16 = this.WordRegionGroup.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        this.wordRegionRaycaster = val_16;
        val_16.enabled = true;
        val_20 = 1152921504973512704;
        val_22 = null;
        val_22 = null;
        HintPickerController.IsPickingHint = true;
        if(this.OnPickOverlayStateChanged == null)
        {
                return;
        }
        
        this.OnPickOverlayStateChanged.Invoke(obj:  true);
        return;
        label_13:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  false).Init(outOfCredits:  true, onCloseAction:  0);
    }
    public void HintCellPicked(LineWord line, Cell cell)
    {
        var val_3 = 0;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this.selectedCell, y:  0);
        this.selectedLine = line;
        this.selectedCell = cell;
        this.buttonsGroup.SetActive(value:  true);
        this.closeButton.SetActive(value:  false);
        string val_2 = Localization.Localize(key:  "hintpicker_confirm_choice", defaultValue:  "Confirm your choice", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void OnHintPickConfirmButtonClicked()
    {
        WordRegion val_1 = WordRegion.instance;
        this.OnHintPickCloseButtonClicked();
    }
    public void OnHintPickCancelButtonClicked()
    {
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this.selectedCell, y:  0);
        this.selectedLine = 0;
        this.selectedCell = 0;
        this.buttonsGroup.SetActive(value:  false);
        this.closeButton.SetActive(value:  false);
        string val_2 = Localization.Localize(key:  "hintpicker_pick_empty", defaultValue:  "Pick an empty box to reveal that letter", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void OnHintPickCloseButtonClicked()
    {
        var val_4;
        this.OnHintPickCancelButtonClicked();
        this.isFreeOne = false;
        this.HintPickerGroup.SetActive(value:  false);
        if(this.wordRegionRaycaster != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.wordRegionRaycaster);
        }
        
        if(this.wordRegionCanvas != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.wordRegionCanvas);
        }
        
        this.wordRegionRaycaster.enabled = false;
        if(this.wordRegionCanvas != 0)
        {
                UnityEngine.Object.Destroy(obj:  this.wordRegionCanvas);
        }
        
        val_4 = null;
        val_4 = null;
        HintPickerController.IsPickingHint = false;
        if(this.OnPickOverlayStateChanged == null)
        {
                return;
        }
        
        this.OnPickOverlayStateChanged.Invoke(obj:  false);
    }
    public HintPickerController()
    {
    
    }
    private static HintPickerController()
    {
    
    }

}
