using UnityEngine;
private sealed class AttackMadnessEventHandler.<>c__DisplayClass73_0
{
    // Fields
    public float buttonProgress;
    public WGEventButtonV2_AttackMadness attackMadnessButton;
    public AttackMadnessEventHandler <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public int initialProgressLabelPoints;
    public int startValue;
    public int points;
    
    // Methods
    public AttackMadnessEventHandler.<>c__DisplayClass73_0()
    {
    
    }
    internal void <PlayPointCollectionSequence>b__0(float x)
    {
        this.buttonProgress = x;
    }
    internal void <PlayPointCollectionSequence>b__1()
    {
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  this.buttonProgress);
        string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  val_1.ToString(), arg1:  this.<>4__this.ToString());
        int val_5 = this.initialProgressLabelPoints - val_1;
        val_5 = val_5 + this.startValue;
        string val_6 = val_5.ToString();
    }
    internal void <PlayPointCollectionSequence>b__2()
    {
        string val_4 = System.String.Format(format:  "{0}/{1}", arg0:  this.points + this.startValue.ToString(), arg1:  this.<>4__this.ToString());
        string val_6 = this.initialProgressLabelPoints - this.points.ToString();
    }

}
