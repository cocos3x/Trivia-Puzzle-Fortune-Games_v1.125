using UnityEngine;
private sealed class Alphabet2Manager.<QAHACK_SampleLoop>d__153 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Alphabet2Manager <>4__this;
    private int <draws>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Alphabet2Manager.<QAHACK_SampleLoop>d__153(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_12;
        int val_13;
        val_12 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<draws>5__2 = 0;
        if((this.<>4__this) != null)
        {
            goto label_3;
        }
        
        label_1:
        this.<>1__state = 0;
        label_3:
        if((this.<>4__this.IsCurrentCollectionComplete()) == false)
        {
            goto label_6;
        }
        
        object[] val_2 = new object[1];
        val_12 = this.<draws>5__2;
        val_2[0] = val_12;
        UnityEngine.Debug.LogErrorFormat(format:  "Complete collection after {0} draws", args:  val_2);
        label_2:
        val_13 = 0;
        return (bool)val_13;
        label_6:
        int val_12 = this.<draws>5__2;
        val_12 = val_12 + 1;
        this.<draws>5__2 = val_12;
        this.<>4__this.FillCollectionBoxRandomly(lettersToCollect:  this.<>4__this.tilesPerCollectionBox);
        List.Enumerator<T> val_7 = MonoSingleton<Alphabet2Manager>.Instance.GetRandomSeededPositionsForCollection(collectionBox:  MonoSingleton<Alphabet2Manager>.Instance.currentCollectionBox).GetEnumerator();
        label_23:
        if(0.MoveNext() == false)
        {
            goto label_19;
        }
        
        Alphabet2Manager val_9 = MonoSingleton<Alphabet2Manager>.Instance;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.CollectTileFromBox(word:  0, letterIndex:  0);
        goto label_23;
        label_19:
        0.Dispose();
        MonoSingleton<Alphabet2Manager>.Instance.currentCollectionBox.Clear();
        val_13 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_13;
        return (bool)val_13;
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
