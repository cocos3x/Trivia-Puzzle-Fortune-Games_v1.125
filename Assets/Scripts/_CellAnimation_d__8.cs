using UnityEngine;
private sealed class WGMegaHintController.<CellAnimation>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGMegaHintController <>4__this;
    public Cell chosenCell;
    private UnityEngine.Transform <letter>5__2;
    private UnityEngine.Vector3 <startPos>5__3;
    private UnityEngine.Vector3 <randomVec>5__4;
    private float <growDuration>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGMegaHintController.<CellAnimation>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_39;
        UnityEngine.Vector3 val_40;
        float val_44;
        float val_45;
        float val_49;
        int val_50;
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
            goto label_3;
        }
        
        this.<>1__state = 0;
        this.<>4__this.timeProgress = 0f;
        UnityEngine.Transform val_1 = this.chosenCell.letterGroup.transform;
        this.<letter>5__2 = val_1;
        UnityEngine.Vector3 val_3 = val_1.transform.position;
        this.<startPos>5__3 = val_3;
        mem[1152921517544859580] = val_3.y;
        mem[1152921517544859584] = val_3.z;
        UnityEngine.Vector3 val_4 = UnityEngine.Random.insideUnitSphere;
        this.<randomVec>5__4 = val_4;
        mem[1152921517544859592] = val_4.y;
        mem[1152921517544859596] = 0;
        this.<randomVec>5__4.Normalize();
        val_40 = this.<randomVec>5__4;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_40, y = V8.16B, z = V9.16B}, d:  5f);
        this.<randomVec>5__4 = val_5;
        mem[1152921517544859592] = val_5.y;
        mem[1152921517544859596] = val_5.z;
        UnityEngine.Transform val_6 = this.<letter>5__2.transform;
        UnityEngine.Vector3 val_7 = val_6.position;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, b:  new UnityEngine.Vector3() {x = this.<randomVec>5__4});
        val_6.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        this.<letter>5__2.gameObject.SetActive(value:  true);
        goto label_15;
        label_1:
        this.<>1__state = 0;
        float val_10 = UnityEngine.Time.deltaTime;
        val_10 = (this.<>4__this.timeProgress) + val_10;
        this.<>4__this.timeProgress = val_10;
        UnityEngine.Vector3 val_12 = UnityEngine.Random.insideUnitSphere;
        val_44 = val_12.y;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_44, z = val_12.z}, d:  0.05f);
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.<startPos>5__3, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        this.chosenCell.transform.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        if(((this.<>4__this.TimePerAnim) / (this.<>4__this.timePerSecondary)) >= 0)
        {
            goto label_22;
        }
        
        UnityEngine.Vector3 val_17 = UnityEngine.Vector3.one;
        val_39 = val_17.x;
        val_45 = val_17.y;
        val_40 = val_17.z;
        UnityEngine.Vector3 val_18 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, d:  2f);
        float val_39 = this.<growDuration>5__5;
        val_39 = (this.<>4__this.timePerSecondary) * val_39;
        float val_20 = (this.<>4__this.timeProgress) / val_39;
        goto label_25;
        label_2:
        this.<>1__state = 0;
        float val_21 = UnityEngine.Time.deltaTime;
        val_21 = (this.<>4__this.timeProgress) + val_21;
        this.<>4__this.timeProgress = val_21;
        UnityEngine.Vector3 val_24 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = this.<randomVec>5__4, y = V10.16B, z = V9.16B}, b:  new UnityEngine.Vector3() {x = this.<startPos>5__3, y = V12.16B, z = this.<>4__this.timeProgress}, t:  (this.<>4__this.timeProgress) / (this.<>4__this.TimePerAnim));
        this.<letter>5__2.transform.position = new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z};
        label_15:
        if((this.<>4__this.timeProgress) < 0)
        {
            goto label_31;
        }
        
        this.<letter>5__2.transform.position = new UnityEngine.Vector3() {x = this.<startPos>5__3, y = this.<>4__this.TimePerAnim, z = val_24.z};
        this.<>4__this.timeProgress = 0f;
        this.<growDuration>5__5 = 0.3f;
        goto label_34;
        label_3:
        val_50 = 0;
        return (bool)val_50;
        label_31:
        val_50 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_50;
        return (bool)val_50;
        label_22:
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_28 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z}, d:  2f);
        val_39 = val_28.x;
        val_45 = val_28.y;
        val_40 = val_28.z;
        UnityEngine.Vector3 val_29 = UnityEngine.Vector3.one;
        label_25:
        val_49 = val_45;
        UnityEngine.Vector3 val_31 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_39, y = val_49, z = val_40}, b:  new UnityEngine.Vector3() {x = val_29.x, y = val_29.y, z = val_29.z}, t:  (this.<>4__this.timeProgress) / (this.<>4__this.timePerSecondary));
        this.chosenCell.transform.localScale = new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z};
        label_34:
        if((this.<>4__this.timeProgress) >= 0)
        {
                UnityEngine.Vector3 val_33 = UnityEngine.Vector3.zero;
            this.chosenCell.transform.eulerAngles = new UnityEngine.Vector3() {x = val_33.x, y = val_33.y, z = val_33.z};
            this.chosenCell.transform.position = new UnityEngine.Vector3() {x = this.<startPos>5__3, y = val_33.y, z = val_33.z};
            UnityEngine.Vector3 val_36 = UnityEngine.Vector3.one;
            this.chosenCell.transform.localScale = new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z};
            this.<letter>5__2.transform.position = new UnityEngine.Vector3() {x = this.<startPos>5__3, y = val_36.y, z = val_36.z};
            val_50 = 0;
            this.<>4__this.timeProgress = 0f;
            return (bool)val_50;
        }
        
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        val_50 = 1;
        return (bool)val_50;
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
