using UnityEngine;
private sealed class LoopScrollRect.<ScrollToCellCoroutine>d__124 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.UI.LoopScrollRect <>4__this;
    public int index;
    public float speed;
    private bool <needMoving>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LoopScrollRect.<ScrollToCellCoroutine>d__124(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_13;
        float val_44;
        float val_45;
        float val_46;
        float val_48;
        float val_49;
        int val_50;
        int val_51;
        int val_52;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<needMoving>5__2 = true;
        goto label_33;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.m_Dragging) == true)
        {
            goto label_33;
        }
        
        if(this.index >= (this.<>4__this.itemTypeStart))
        {
            goto label_6;
        }
        
        val_44 = this.speed;
        val_45 = -(UnityEngine.Time.deltaTime * val_44);
        goto label_30;
        label_6:
        if(this.index >= (this.<>4__this.itemTypeEnd))
        {
            goto label_8;
        }
        
        UnityEngine.Rect val_3 = this.<>4__this.viewRect.rect;
        UnityEngine.Vector2 val_4 = val_3.m_XMin.center;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
        val_46 = val_5.z;
        UnityEngine.Rect val_7 = this.<>4__this.viewRect.rect;
        UnityEngine.Vector2 val_8 = val_7.m_XMin.size;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
        UnityEngine.Bounds val_10 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_46}, size:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        mem2[0] = val_10.m_Extents.y;
        this.<>4__this.m_ViewBounds = val_10.m_Center.x;
        UnityEngine.Bounds val_11 = this.<>4__this.GetBounds4Item(index:  this.index);
        if((this.<>4__this.directionSign) == 1)
        {
            goto label_13;
        }
        
        val_45 = 0f;
        if((this.<>4__this.directionSign) != 1)
        {
            goto label_20;
        }
        
        if((this.<>4__this.reverseDirection) == false)
        {
            goto label_15;
        }
        
        UnityEngine.Vector3 val_14 = this.<>4__this.m_ViewBounds.min;
        val_48 = val_14.y;
        UnityEngine.Vector3 val_15 = val_13.min;
        goto label_16;
        label_8:
        val_44 = this.speed;
        val_45 = UnityEngine.Time.deltaTime * val_44;
        goto label_30;
        label_13:
        if((this.<>4__this.reverseDirection) == false)
        {
            goto label_18;
        }
        
        UnityEngine.Vector3 val_17 = val_13.max;
        val_49 = val_17.x;
        UnityEngine.Vector3 val_18 = this.<>4__this.m_ViewBounds.max;
        goto label_19;
        label_15:
        UnityEngine.Vector3 val_19 = this.<>4__this.m_ViewBounds.max;
        val_48 = val_19.y;
        UnityEngine.Vector3 val_20 = val_13.max;
        label_16:
        val_45 = val_48 - val_20.y;
        goto label_20;
        label_18:
        UnityEngine.Vector3 val_21 = val_13.min;
        val_49 = val_21.x;
        UnityEngine.Vector3 val_22 = this.<>4__this.m_ViewBounds.min;
        label_19:
        val_45 = val_49 - val_22.x;
        label_20:
        if(((this.<>4__this.totalCount) & 2147483648) == 0)
        {
                if((val_45 > 0f) && ((this.<>4__this.itemTypeEnd) == (this.<>4__this.totalCount)))
        {
                if((this.<>4__this.reverseDirection) == false)
        {
            goto label_24;
        }
        
        }
        
            if(val_45 < 0)
        {
                if((this.<>4__this.itemTypeStart) == 0)
        {
            goto label_26;
        }
        
        }
        
        }
        
        label_49:
        val_44 = this.speed;
        if(System.Math.Abs(val_45) < 0)
        {
                this.<needMoving>5__2 = false;
        }
        else
        {
                val_45 = (UnityEngine.Time.deltaTime * val_44) * (UnityEngine.Mathf.Sign(f:  val_45));
        }
        
        label_30:
        if(val_45 != 0f)
        {
                val_45 = val_45;
            UnityEngine.Vector2 val_26 = this.<>4__this.m_Content.anchoredPosition;
            val_46 = val_26.x;
            UnityEngine.Vector2 val_27 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_46, y = val_26.y}, b:  new UnityEngine.Vector2() {x = val_45, y = val_44});
            this.<>4__this.m_Content.anchoredPosition = new UnityEngine.Vector2() {x = val_27.x, y = val_27.y};
            UnityEngine.Vector2 val_28 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.<>4__this.m_PrevPosition, y = val_27.y}, b:  new UnityEngine.Vector2() {x = val_45, y = val_44});
            this.<>4__this.m_PrevPosition = val_28;
            mem2[0] = val_28.y;
            UnityEngine.Vector2 val_29 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.<>4__this.m_ContentStartPosition, y = val_44}, b:  new UnityEngine.Vector2() {x = val_45, y = val_44});
            this.<>4__this.m_ContentStartPosition = val_29;
            mem2[0] = val_29.y;
        }
        
        label_33:
        if((this.<needMoving>5__2) != false)
        {
                val_50 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_50;
            return (bool)val_50;
        }
        
        label_50:
        this.<>4__this.UpdatePrevData();
        label_2:
        val_50 = 0;
        return (bool)val_50;
        label_26:
        if((this.<>4__this.reverseDirection) == false)
        {
            goto label_49;
        }
        
        UnityEngine.Bounds val_30 = this.<>4__this.GetBounds4Item(index:  0);
        val_51 = this.<>4__this.directionSign;
        if(val_51 != 1)
        {
            goto label_41;
        }
        
        UnityEngine.Vector3 val_31 = val_10.m_Center.x.max;
        UnityEngine.Vector3 val_32 = this.<>4__this.m_ViewBounds.max;
        if(val_31.y < 0)
        {
            goto label_47;
        }
        
        val_51 = this.<>4__this.directionSign;
        label_41:
        if(val_51 != 1)
        {
            goto label_49;
        }
        
        UnityEngine.Vector3 val_33 = val_10.m_Center.x.min;
        UnityEngine.Vector3 val_34 = this.<>4__this.m_ViewBounds.min;
        if(val_33.x <= val_34.x)
        {
            goto label_49;
        }
        
        goto label_47;
        label_24:
        UnityEngine.Bounds val_36 = this.<>4__this.GetBounds4Item(index:  (this.<>4__this.totalCount) - 1);
        val_52 = this.<>4__this.directionSign;
        if(val_52 != 1)
        {
            goto label_46;
        }
        
        UnityEngine.Vector3 val_37 = val_10.m_Center.x.min;
        UnityEngine.Vector3 val_38 = this.<>4__this.m_ViewBounds.min;
        if(val_37.y > val_38.y)
        {
            goto label_47;
        }
        
        val_52 = this.<>4__this.directionSign;
        label_46:
        if(val_52 != 1)
        {
            goto label_49;
        }
        
        UnityEngine.Vector3 val_39 = val_10.m_Center.x.max;
        UnityEngine.Vector3 val_40 = this.<>4__this.m_ViewBounds.max;
        if(val_39.x >= 0)
        {
            goto label_49;
        }
        
        label_47:
        this.<needMoving>5__2 = false;
        goto label_50;
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
