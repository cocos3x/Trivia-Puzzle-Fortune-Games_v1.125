using UnityEngine;
private sealed class WGMegaHintController.<CoolMegaHint>d__7 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public bool tutorial;
    public System.Collections.Generic.List<LineWord> availableLines;
    public WGMegaHintController <>4__this;
    private System.Collections.Generic.List<Cell> <chosenCells>5__2;
    private System.Collections.Generic.List<Cell> <lineWordCells>5__3;
    private System.Collections.Generic.List<UnityEngine.GameObject> <tutorialRays>5__4;
    private int <hint>5__5;
    private System.Collections.Generic.List.Enumerator<Cell> <>7__wrap5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGMegaHintController.<CoolMegaHint>d__7(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 3)
        {
                if((this.<>1__state) != 3)
        {
                return;
        }
        
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        var val_33;
        List.Enumerator<Cell> val_34;
        WGMegaHintController val_40;
        UnityEngine.GameObject val_41;
        System.Collections.Generic.List<Cell> val_42;
        Cell val_43;
        System.Collections.Generic.List<Cell> val_44;
        int val_45;
        int val_46;
        int val_47;
        if((this.<>1__state) > 4)
        {
            goto label_4;
        }
        
        var val_39 = 32496644 + (this.<>1__state) << 2;
        val_40 = this.<>4__this;
        val_39 = val_39 + 32496644;
        goto (32496644 + (this.<>1__state) << 2 + 32496644);
        label_14:
        if((this.<tutorialRays>5__4) == null)
        {
                throw new NullReferenceException();
        }
        
        if(32496644 < 1)
        {
            goto label_76;
        }
        
        bool val_5 = this.<tutorialRays>5__4.Remove(item:  -12568824);
        UnityEngine.Object.Destroy(obj:  -12568824);
        goto label_14;
        label_29:
        if( >= ((1152921517543633728 + (val_6) << 3) + 32 + 40 + 24))
        {
            goto label_22;
        }
        
        if(((1152921517543633728 + (val_6) << 3) + 32 + 40 + 24) <= )
        {
                val_42 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_41 = (1152921517543633728 + (val_6) << 3) + 32 + 40 + 16;
        val_41 = val_41 + 0;
        if((((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + 32 + 72) == 0)
        {
                if(((1152921517543633728 + (val_6) << 3) + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
            if(((1152921517543633728 + (val_6) << 3) + 32 + 40 + 24) <= )
        {
                val_42 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((this.<lineWordCells>5__3) == null)
        {
                throw new NullReferenceException();
        }
        
            var val_42 = (1152921517543633728 + (val_6) << 3) + 32 + 40 + 16;
            val_42 = val_42 + 0;
            val_43 = mem[((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + 32];
            val_43 = ((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + 32;
            val_42 = this.<lineWordCells>5__3;
            val_42.Add(item:  val_43);
        }
        
         =  + 1;
        if(((1152921517543633728 + (val_6) << 3) + 32 + 40) != 0)
        {
            goto label_29;
        }
        
        throw new NullReferenceException();
        label_22:
        if((this.<lineWordCells>5__3) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43 == 0)
        {
            goto label_31;
        }
        
        int val_7 = UnityEngine.Random.Range(min:  0, max:  val_43);
        if(val_42 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_42 = this.<lineWordCells>5__3;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_42 + (val_7 << 3);
        val_43 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32;
        bool val_8 = val_42.Remove(item:  val_43);
        if((this.<lineWordCells>5__3) == null)
        {
                throw new NullReferenceException();
        }
        
        if((public System.Boolean System.Collections.Generic.List<Cell>::Remove(Cell item)) == 0)
        {
            goto label_35;
        }
        
        if(this.availableLines == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<hint>5__5) > W10)
        {
            goto label_38;
        }
        
        val_43 = ;
        bool val_9 = this.availableLines.Remove(item:  val_43);
        goto label_38;
        label_31:
        val_42 = this.availableLines;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = ;
        bool val_10 = val_42.Remove(item:  val_43);
        int val_44 = this.<hint>5__5;
        val_44 = val_44 + 1;
        this.<hint>5__5 = val_44;
        goto label_64;
        label_35:
        val_43 = ;
        bool val_11 = this.availableLines.Remove(item:  val_43);
        label_38:
        val_42 = this.<chosenCells>5__2;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32;
        val_42.Add(item:  val_43);
        if(this.tutorial != false)
        {
                if(((((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_43 = 0;
            UnityEngine.GameObject val_12 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32.gameObject;
            if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
            val_43 = public UnityEngine.Canvas UnityEngine.GameObject::AddComponent<UnityEngine.Canvas>();
            UnityEngine.Canvas val_13 = val_12.AddComponent<UnityEngine.Canvas>();
            val_41 = val_13;
            if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
            val_41.overrideSorting = true;
            val_41.sortingLayerName = "Immediate";
            val_41.sortingOrder = 1;
            UnityEngine.GameObject val_14 = null;
            val_41 = val_14;
            val_43 = 0;
            val_14 = new UnityEngine.GameObject();
            if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.Transform val_15 = val_14.transform;
            val_43 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32.transform;
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            val_15.SetParent(p:  val_43);
            val_43 = 0;
            UnityEngine.Transform val_17 = val_14.transform;
            val_42 = 0;
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.zero;
            if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
            val_17.localPosition = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
            val_43 = 0;
            UnityEngine.Transform val_19 = val_14.transform;
            UnityEngine.Vector3 val_20 = UnityEngine.Vector3.one;
            val_42 = 0;
            UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z}, d:  2.5f);
            if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
            val_19.localScale = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
            val_43 = public UnityEngine.UI.Image UnityEngine.GameObject::AddComponent<UnityEngine.UI.Image>();
            UnityEngine.UI.Image val_22 = val_14.AddComponent<UnityEngine.UI.Image>();
            if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
            val_22.sprite = this.<>4__this.raySprite;
            val_43 = public UnityEngine.UI.Image UnityEngine.GameObject::GetComponent<UnityEngine.UI.Image>();
            UnityEngine.UI.Image val_23 = val_14.GetComponent<UnityEngine.UI.Image>();
            val_42 = 0;
            UnityEngine.Color val_24 = UnityEngine.Color.yellow;
            if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
            val_23.color = new UnityEngine.Color() {r = val_24.r, g = val_24.g, b = val_24.b, a = val_24.a};
            val_43 = 0;
            UnityEngine.Transform val_25 = val_14.transform;
            if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
            val_43 = 0;
            val_25.SetAsFirstSibling();
            val_42 = this.<tutorialRays>5__4;
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            val_42.Add(item:  val_14);
        }
        
        val_42 = ;
        val_43 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32;
        UnityEngine.Vector3 val_26 = val_42.ShowHint(cell:  val_43);
        if(((((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_42 = mem[(((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32 + 32];
        val_42 = (((1152921517543633728 + (val_6) << 3) + 32 + 40 + 16 + 0) + (val_7) << 3) + 32 + 32;
        if(val_42 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        UnityEngine.GameObject val_27 = val_42.gameObject;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 0;
        val_27.SetActive(value:  false);
        if(WordRegion.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = ;
        if(((1152921517543633728 + (val_6) << 3) + 32 + 56) != 0)
        {
                val_42 = this.availableLines;
            if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
            val_43 = ;
            bool val_29 = val_42.Remove(item:  val_43);
        }
        
        label_64:
        val_45 = (this.<hint>5__5) - 1;
        this.<hint>5__5 = val_45;
        if(val_45 >= 1)
        {
                if(this.availableLines == null)
        {
                throw new NullReferenceException();
        }
        
            if(this.availableLines != null)
        {
                val_46 = 1;
            this.<>2__current = new UnityEngine.WaitForEndOfFrame();
            this.<>1__state = val_46;
            return (bool)val_46;
        }
        
        }
        
        if(this.tutorial == false)
        {
            goto label_70;
        }
        
        val_47 = 2;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.6f);
        goto label_75;
        label_70:
        val_42 = this.<chosenCells>5__2;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_32 = val_42.GetEnumerator();
        val_44 = this.<>7__wrap5;
        mem[1152921517543783784] = val_33;
        this.<>7__wrap5 = val_34;
        this.<>1__state = -3;
        val_43 = public System.Boolean List.Enumerator<Cell>::MoveNext();
        val_42 = val_44;
        if(val_42.MoveNext() == false)
        {
            goto label_73;
        }
        
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>2__current = val_40.CellAnimation(chosenCell:  val_43);
        val_47 = 3;
        goto label_75;
        label_73:
        this.<>m__Finally1();
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        if(this.tutorial == false)
        {
            goto label_76;
        }
        
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.6f);
        val_47 = 4;
        label_75:
        this.<>1__state = val_47;
        val_46 = 1;
        return (bool)val_46;
        label_76:
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.canHint = true;
        if(WordRegion.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_46 = 0;
        val_38.canHint = true;
        return (bool)val_46;
        label_4:
        val_46 = 0;
        return (bool)val_46;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        this.<>7__wrap5.Dispose();
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
