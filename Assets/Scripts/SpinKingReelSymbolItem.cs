using UnityEngine;
public class SpinKingReelSymbolItem : ScrollerIteam
{
    // Fields
    private UnityEngine.UI.Image symbol;
    private SpinKingSlotMachine.SpinKingSymbol <SymbolType>k__BackingField;
    
    // Properties
    public SpinKingSlotMachine.SpinKingSymbol SymbolType { get; set; }
    
    // Methods
    public SpinKingSlotMachine.SpinKingSymbol get_SymbolType()
    {
        return (SpinKingSymbol)this.<SymbolType>k__BackingField;
    }
    private void set_SymbolType(SpinKingSlotMachine.SpinKingSymbol value)
    {
        this.<SymbolType>k__BackingField = value;
    }
    public override void SetUp(ScrollerIteamData itemData)
    {
        this.<SymbolType>k__BackingField = null;
        this.symbol.sprite = MonoSingleton<WGSpinKingSlotPopup>.Instance.GetSymbolSprite(symbol:  this.<SymbolType>k__BackingField);
        WGSpinKingSlotPopup val_3 = MonoSingleton<WGSpinKingSlotPopup>.Instance;
        val_3.ReelController.RecycleRESSymbolItemData(itemData:  itemData);
    }
    public SpinKingReelSymbolItem()
    {
    
    }

}
