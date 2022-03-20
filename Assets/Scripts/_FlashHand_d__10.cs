using UnityEngine;
private sealed class WordJumbleFTUX.<FlashHand>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.WordJumble.WordJumbleFTUX <>4__this;
    private float <progress>5__2;
    private float <dir>5__3;
    private UnityEngine.Color <curColor>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WordJumbleFTUX.<FlashHand>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_15;
        double val_16;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_11;
        }
        
        this.<>1__state = 0;
        val_15 = 1;
        this.<>2__current = new UnityEngine.WaitForFixedUpdate();
        this.<>1__state = val_15;
        return (bool)val_15;
        label_2:
        val_16 = 1.37667629642531E-16;
        this.<>1__state = 0;
        this.<progress>5__2 = 0f;
        this.<dir>5__3 = 0.02f;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.<curColor>5__4 = val_2;
        mem[1152921519774653652] = val_2.g;
        mem[1152921519774653656] = val_2.b;
        mem[1152921519774653660] = val_2.a;
        if((this.<>4__this) != null)
        {
            goto label_5;
        }
        
        label_1:
        this.<>1__state = 0;
        float val_3 = (this.<progress>5__2) + (this.<dir>5__3);
        this.<progress>5__2 = val_3;
        mem[1152921519774653660] = val_3;
        if(val_3 <= 1f)
        {
                if(val_3 >= 0)
        {
            goto label_8;
        }
        
        }
        
        this.<dir>5__3 = -(this.<dir>5__3);
        label_8:
        val_16 = this.<curColor>5__4;
        this.<>4__this.handImage.color = new UnityEngine.Color() {r = val_16, g = this.<progress>5__2, b = 1f, a = val_3};
        label_5:
        if((this.<>4__this.enabled) != false)
        {
                UnityEngine.Vector3 val_7 = this.<>4__this.curTile.transform.position;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.up;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, d:  -0.3f);
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
            UnityEngine.Vector3 val_11 = UnityEngine.Vector3.right;
            UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, d:  0.3f);
            UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, b:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            this.<>4__this.handImage.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
            this.<>2__current = new UnityEngine.WaitForFixedUpdate();
            this.<>1__state = 2;
            val_15 = 1;
            return (bool)val_15;
        }
        
        label_11:
        val_15 = 0;
        return (bool)val_15;
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
