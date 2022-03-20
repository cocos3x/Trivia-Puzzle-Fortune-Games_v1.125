using UnityEngine;
private sealed class SnakeBlockLevelStreamer.<SpawnNext>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.SnackBlock.SnakeBlockLevelStreamer <>4__this;
    private UnityEngine.GameObject <sectionHolder>5__2;
    private int <row>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SnakeBlockLevelStreamer.<SpawnNext>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_24;
        string val_25;
        int val_26;
        int val_27;
        int val_29;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_16;
        }
        
        this.<>1__state = 0;
        if(((this.<>4__this.sectionHolders) != null) && (0 >= 3))
        {
                UnityEngine.Object.Destroy(obj:  this.<>4__this.sectionHolders.Dequeue());
        }
        
        val_25 = "SectionHolder " + this.<>4__this.lastRowSpawned.ToString()(this.<>4__this.lastRowSpawned.ToString());
        UnityEngine.GameObject val_4 = new UnityEngine.GameObject(name:  val_25);
        this.<sectionHolder>5__2 = val_4;
        val_4.transform.SetParent(p:  this.<>4__this.transform);
        this.<>4__this.sectionHolders.Enqueue(item:  this.<sectionHolder>5__2);
        val_26 = this.<row>5__3;
        val_27 = (this.<>4__this.lastRowSpawned) + 1;
        this.<row>5__3 = val_27;
        goto label_11;
        label_1:
        val_26 = this;
        val_27 = (this.<row>5__3) + 1;
        this.<>1__state = 0;
        this.<row>5__3 = val_27;
        label_11:
        SLC.Minigames.SnackBlock.SnakeBlockManager val_7 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
        if(val_27 < val_7.myLevelData)
        {
                new UnityEngine.GameObject(name:  "RowParent " + this.<row>5__3.ToString()(this.<row>5__3.ToString())).transform.SetParent(p:  this.<sectionHolder>5__2.transform);
            val_25 = 0;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_21 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            val_24 = this.<row>5__3;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_29 = 1;
            mem[1152921519903023800] = 0;
            this.<>1__state = val_29;
            return (bool)val_29;
        }
        
        label_16:
        val_29 = 0;
        return (bool)val_29;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
