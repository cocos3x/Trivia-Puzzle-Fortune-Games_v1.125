using UnityEngine;
public class AlphabetWordRegion : WordRegionBase
{
    // Fields
    private LineWord lineWordPrefab;
    private Cell cellPrefab;
    private System.Collections.Generic.List<string> words;
    private System.Collections.Generic.List<string> progress;
    
    // Properties
    private LineWord LineWordPrefabLoaded { get; }
    private Cell CellPrefabLoaded { get; }
    
    // Methods
    private LineWord get_LineWordPrefabLoaded()
    {
        LineWord val_3;
        if(this.lineWordPrefab == 0)
        {
                this.lineWordPrefab = PrefabLoader.LoadPrefab<LineWord>(featureName:  "LineWord");
            return val_3;
        }
        
        val_3 = this.lineWordPrefab;
        return val_3;
    }
    private Cell get_CellPrefabLoaded()
    {
        Cell val_3;
        if(this.cellPrefab == 0)
        {
                this.cellPrefab = PrefabLoader.LoadPrefab<Cell>(featureName:  "AlphabetCell");
            return val_3;
        }
        
        val_3 = this.cellPrefab;
        return val_3;
    }
    public void Setup(System.Collections.Generic.List<string> requiredWords, System.Collections.Generic.List<string> progressWords)
    {
        this.words = requiredWords;
        this.progress = progressWords;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.LoadCoroutine());
    }
    public System.Collections.Generic.List<string> GetLevelProgress(System.Collections.Generic.List<string> savedProgress, System.Collections.Generic.List<string> orderedWordList)
    {
        string val_3;
        var val_4;
        var val_12;
        object val_13;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_2 = orderedWordList.GetEnumerator();
        label_13:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        AlphabetWordRegion.<>c__DisplayClass9_0 val_6 = null;
        val_13 = 0;
        val_6 = new AlphabetWordRegion.<>c__DisplayClass9_0();
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        .word = val_3;
        System.Predicate<System.String> val_7 = null;
        val_13 = val_6;
        val_7 = new System.Predicate<System.String>(object:  val_6, method:  System.Boolean AlphabetWordRegion.<>c__DisplayClass9_0::<GetLevelProgress>b__0(string x));
        if(savedProgress == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = savedProgress;
        val_13 = val_7;
        int val_8 = val_12.FindIndex(match:  val_7);
        if(val_8 == 1)
        {
            goto label_5;
        }
        
        if(val_3 <= val_8)
        {
                val_12 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((AlphabetWordRegion.<>c__DisplayClass9_0)[1152921516036971056].word) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_9 = X9 + (val_8 << 3);
        val_12 = mem[(X9 + (val_8) << 3) + 32];
        val_12 = (X9 + (val_8) << 3) + 32;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_13 = val_12.Remove(startIndex:  0, count:  (AlphabetWordRegion.<>c__DisplayClass9_0)[1152921516036971056].word.m_stringLength);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_13);
        goto label_13;
        label_5:
        if(((AlphabetWordRegion.<>c__DisplayClass9_0)[1152921516036971056].word) == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = 0.CreateString(c:  '0', count:  (AlphabetWordRegion.<>c__DisplayClass9_0)[1152921516036971056].word.m_stringLength);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_13);
        goto label_13;
        label_2:
        val_4.Dispose();
        return val_1;
    }
    private System.Collections.IEnumerator LoadCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new AlphabetWordRegion.<LoadCoroutine>d__10();
    }
    public AlphabetWordRegion()
    {
        this.words = new System.Collections.Generic.List<System.String>();
        this.progress = new System.Collections.Generic.List<System.String>();
    }

}
