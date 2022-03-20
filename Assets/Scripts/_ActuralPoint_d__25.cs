using UnityEngine;
private sealed class WordBubblesUIController.<ActuralPoint>d__25 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.Bubbles.WordBubblesUIController <>4__this;
    public int bubbleIndex;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordBubblesUIController.<ActuralPoint>d__25(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_14;
        var val_15;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_6;
        }
        
        this.<>1__state = 0;
        val_14 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_14;
        return (bool)val_14;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.BubbleElements.Length) >= 1)
        {
                var val_15 = 0;
            do
        {
            SLC.Minigames.Bubbles.WordBubblesBubble val_14 = this.<>4__this.BubbleElements[val_15];
            if(val_14.gameObject.activeSelf != false)
        {
                if((this.<>4__this.BubbleElements[0x0][0].Index) == this.bubbleIndex)
        {
                UnityEngine.Vector3 val_6 = val_14.transform.position;
            UnityEngine.Vector3 val_8 = val_14.transform.position;
            UnityEngine.Vector3 val_10 = this.<>4__this.hand.transform.position;
            UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_6.x, y:  val_8.y, z:  val_10.z);
            this.<>4__this.hand.transform.position = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            UnityEngine.UI.Button val_12 = val_14.GetComponent<UnityEngine.UI.Button>();
            val_15 = 1;
        }
        else
        {
                val_15 = 0;
        }
        
            val_14.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
        
            val_15 = val_15 + 1;
        }
        while(val_15 < (this.<>4__this.BubbleElements.Length));
        
        }
        
        label_6:
        val_14 = 0;
        return (bool)val_14;
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
