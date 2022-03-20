using UnityEngine;
public class SpinKingReelsController : MonoBehaviour
{
    // Fields
    private Scroller[] reels;
    public System.Action<int> OnSpinReelStop;
    private System.Collections.Generic.Queue<SpinKingSymbolItemData> SymbolItemDataArray;
    private SpinKingSlotMachine.SpinKingSymbol[,] ReelData;
    private SpinKingSlotMachine.SpinKingSymbol[,] previousReelData;
    
    // Methods
    private void Start()
    {
        this.GetRealData();
        this.SetPreviousReelData();
        var val_3 = 0;
        do
        {
            this.reels[val_3].Init();
            val_3 = val_3 + 1;
        }
        while((val_3 - 1) < 2);
        
        this.InitReelSymbols();
    }
    private void GetRealData()
    {
        var val_2;
        var val_5 = 0;
        do
        {
            var val_4 = 0;
            do
        {
            val_2 = null;
            val_2 = null;
            SpinKingSymbol[,] val_3 = SpinKingSlotMachine.<ReelData>k__BackingField;
            var val_2 = SpinKingSlotMachine.<ReelData>k__BackingField + 16 + 16;
            val_2 = val_4 + (val_5 * val_2);
            val_3 = val_3 + (((0 * SpinKingSlotMachine.<ReelData>k__BackingField + 16 + 16) + 0) << 2);
            var val_1 = val_4 + (val_5 * (SpinKingSlotMachine.<ReelData>k__BackingField + 16 + 16));
            val_4 = val_4 + 1;
            this.ReelData[((0 * SpinKingSlotMachine.<ReelData>k__BackingField + 16 + 16) + 0) << 2] = (SpinKingSlotMachine.<ReelData>k__BackingField + ((0 * SpinKingSlotMachine.<ReelData>k__BackingField + 16 + 16) + 0) << 2) + 32;
        }
        while(val_4 < 4);
        
            val_5 = val_5 + 1;
        }
        while(val_5 <= 1);
    
    }
    private void InitReelSymbols()
    {
        var val_7 = 0;
        do
        {
            System.Collections.Generic.List<SpinKingSymbolItemData> val_1 = new System.Collections.Generic.List<SpinKingSymbolItemData>();
            var val_5 = 0;
            do
        {
            var val_3 = X9 + 16;
            val_3 = val_5 + (val_7 * val_3);
            val_1.Add(item:  this.GetRESSymbolItemDataObject(symbol:  this.ReelData[((0 * X9 + 16) + 0) << 2]));
            val_5 = val_5 + 1;
        }
        while(val_5 < 4);
        
            this.reels[0].InitScrollerIteam<SpinKingSymbolItemData>(data:  val_1);
            val_7 = val_7 + 1;
        }
        while(0 < 2);
    
    }
    public void StartSpin()
    {
        this.SetPreviousReelData();
        this.GetRealData();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ActualSpinStart());
    }
    private void SetPreviousReelData()
    {
        var val_5 = 0;
        do
        {
            var val_4 = 0;
            do
        {
            var val_2 = X11 + 16;
            val_2 = val_4 + (val_5 * val_2);
            var val_1 = val_4 + (val_5 * (X13 + 16));
            val_4 = val_4 + 1;
            this.previousReelData[((0 * X13 + 16) + 0) << 2] = this.ReelData[((0 * X11 + 16) + 0) << 2];
        }
        while(val_4 < 4);
        
            val_5 = val_5 + 1;
        }
        while(val_5 <= 1);
    
    }
    private System.Collections.IEnumerator ActualSpinStart()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new SpinKingReelsController.<ActualSpinStart>d__10();
    }
    private SpinKingSymbolItemData GetRESSymbolItemDataObject(SpinKingSlotMachine.SpinKingSymbol symbol)
    {
        if(true < 1)
        {
            goto label_2;
        }
        
        label_4:
        val_1.symbol = symbol;
        return (SpinKingSymbolItemData)this.SymbolItemDataArray.Dequeue();
        label_2:
        if(new SpinKingSymbolItemData() != null)
        {
            goto label_4;
        }
        
        throw new NullReferenceException();
    }
    public void RecycleRESSymbolItemData(SpinKingSymbolItemData itemData)
    {
        this.SymbolItemDataArray.Enqueue(item:  itemData);
    }
    public SpinKingReelsController()
    {
        this.SymbolItemDataArray = new System.Collections.Generic.Queue<SpinKingSymbolItemData>();
        this.ReelData = null;
        this.previousReelData = null;
    }

}
