using UnityEngine;
private sealed class TRVCategorySelection.<animateCategorySelection>d__38 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVCategorySelection <>4__this;
    public TRVCategorySelectionInfo selectedCat;
    public TRVCategoryButton thisCatButton;
    public System.Collections.Generic.List<string> incCats;
    private TRVCategorySelection.<>c__DisplayClass38_0 <>8__1;
    private System.Collections.Generic.List<string> <allCategories>5__2;
    private float <animationDuration>5__3;
    private System.DateTime <startTime>5__4;
    private UnityEngine.Sprite <chosenSprite>5__5;
    private UnityEngine.Sprite <eventSprite>5__6;
    private int <cat>5__7;
    private UnityEngine.Sprite <newCatSprite>5__8;
    private string <newCatCat>5__9;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVCategorySelection.<animateCategorySelection>d__38(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_41 = 0;
        if((this.<>1__state) > 9)
        {
                return (bool);
        }
        
        var val_41 = 32496480;
        val_41 = (32496480 + (this.<>1__state) << 2) + val_41;
        goto (32496480 + (this.<>1__state) << 2 + 32496480);
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
