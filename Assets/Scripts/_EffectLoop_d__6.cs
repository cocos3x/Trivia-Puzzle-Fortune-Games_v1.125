using UnityEngine;
private sealed class ETFXLoopScript.<EffectLoop>d__6 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public EpicToonFX.ETFXLoopScript <>4__this;
    private UnityEngine.GameObject <effectPlayer>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ETFXLoopScript.<EffectLoop>d__6(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.GameObject val_15;
        int val_16;
        val_15 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.Vector3 val_2 = this.<>4__this.transform.position;
        UnityEngine.Quaternion val_4 = this.<>4__this.transform.rotation;
        UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>4__this.chosenEffect, position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w});
        this.<effectPlayer>5__2 = val_5;
        bool val_7 = UnityEngine.Object.op_Implicit(exists:  val_5.GetComponent<UnityEngine.Light>());
        this.<>4__this.spawnWithoutLight = val_7;
        if(val_7 != false)
        {
                this.<effectPlayer>5__2.GetComponent<UnityEngine.Light>().enabled = false;
        }
        
        bool val_11 = UnityEngine.Object.op_Implicit(exists:  this.<effectPlayer>5__2.GetComponent<UnityEngine.AudioSource>());
        this.<>4__this.spawnWithoutSound = val_11;
        if(val_11 != false)
        {
                this.<effectPlayer>5__2.GetComponent<UnityEngine.AudioSource>().enabled = false;
        }
        
        val_16 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this.loopTimeLimit);
        this.<>1__state = val_16;
        return (bool)val_16;
        label_1:
        this.<>1__state = 0;
        val_15 = this.<effectPlayer>5__2;
        UnityEngine.Object.Destroy(obj:  val_15);
        this.<>4__this.PlayEffect();
        label_2:
        val_16 = 0;
        return (bool)val_16;
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
