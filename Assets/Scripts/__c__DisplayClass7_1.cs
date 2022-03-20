using UnityEngine;
private sealed class PortraitCollectionProgressBar.<>c__DisplayClass7_1
{
    // Fields
    public float progress;
    public PortraitCollectionProgressBar.<>c__DisplayClass7_0 CS$<>8__locals1;
    
    // Methods
    public PortraitCollectionProgressBar.<>c__DisplayClass7_1()
    {
    
    }
    internal void <Init>b__1(float x)
    {
        this.progress = x;
    }
    internal void <Init>b__2()
    {
        float val_7 = (float)this.CS$<>8__locals1.targetStars;
        val_7 = this.progress * val_7;
        decimal val_1 = System.Convert.ToDecimal(value:  val_7);
        GameEcon val_2 = App.getGameEcon;
        GameEcon val_4 = App.getGameEcon;
        string val_6 = System.String.Format(format:  "{0}/{1}", arg0:  val_1.flags.ToString(format:  val_2.numberFormatInt), arg1:  this.CS$<>8__locals1.targetStars.ToString(format:  val_4.numberFormatInt));
    }

}
