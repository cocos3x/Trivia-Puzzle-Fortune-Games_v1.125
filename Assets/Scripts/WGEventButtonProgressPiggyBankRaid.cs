using UnityEngine;
public class WGEventButtonProgressPiggyBankRaid : WGEventButtonProgress
{
    // Fields
    private PiggyBankRaidEventHandler evtHandler;
    
    // Methods
    public override void Initialize(WGEventHandler handler)
    {
        var val_2;
        mem[1152921517499004632] = handler;
        val_2 = 0;
        this.evtHandler = ;
    }
    public override void Refresh()
    {
        if(this.evtHandler != null)
        {
                decimal val_1 = this.evtHandler.PiggyBankCoins;
            GameEcon val_2 = App.getGameEcon;
            decimal val_5 = this.evtHandler.econ.bankMaxCoins.Item[this.evtHandler.PiggyBankLevel];
            GameEcon val_6 = App.getGameEcon;
            string val_8 = System.String.Format(format:  "{0}/{1}", arg0:  val_1.flags.ToString(format:  val_2.numberFormatInt), arg1:  val_5.flags.ToString(format:  val_6.numberFormatInt));
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Piggy Bank Raid Event Handler is not set");
    }
    public WGEventButtonProgressPiggyBankRaid()
    {
        mem[1152921517499323008] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
