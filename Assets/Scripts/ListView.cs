using UnityEngine;
public class ListView
{
    // Fields
    public ListView.Type listType;
    private UnityEngine.RectTransform root;
    private System.Collections.Generic.List<UnityEngine.RectTransform> items;
    private float itemSize;
    private UnityEngine.MonoBehaviour behaviour;
    private bool isSnapScroll;
    
    // Methods
    public ListView(UnityEngine.MonoBehaviour behaviour)
    {
        this.behaviour = behaviour;
        this.items = new System.Collections.Generic.List<UnityEngine.RectTransform>();
    }
    public ListView SetType(ListView.Type listType)
    {
        this.listType = listType;
        return (ListView)this;
    }
    public ListView SetSnapScroll(bool isSnap)
    {
        this.isSnapScroll = true;
        return (ListView)this;
    }
    public ListView SetRoot(UnityEngine.RectTransform root)
    {
        var val_5;
        var val_8;
        this.root = root;
        if(root == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_1 = root.GetEnumerator();
        val_5 = 1152921504683417600;
        label_15:
        var val_6 = 0;
        val_6 = val_6 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_7 = 0;
        val_7 = val_7 + 1;
        object val_5 = val_1.Current;
        if(val_5 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.items == null)
        {
                throw new NullReferenceException();
        }
        
        this.items.Add(item:  val_5);
        goto label_15;
        label_7:
        val_5 = 0;
        if(X0 == false)
        {
            goto label_16;
        }
        
        var val_10 = X0;
        if((X0 + 294) == 0)
        {
            goto label_20;
        }
        
        var val_8 = X0 + 176;
        var val_9 = 0;
        val_8 = val_8 + 8;
        label_19:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_18;
        }
        
        val_9 = val_9 + 1;
        val_8 = val_8 + 16;
        if(val_9 < (X0 + 294))
        {
            goto label_19;
        }
        
        goto label_20;
        label_18:
        val_10 = val_10 + (((X0 + 176 + 8)) << 4);
        val_8 = val_10 + 304;
        label_20:
        X0.Dispose();
        label_16:
        if(val_5 != 0)
        {
                throw val_5;
        }
        
        return (ListView)this;
    }
    public ListView SetItemSize(float itemSize)
    {
        this.itemSize = itemSize;
        return (ListView)this;
    }
    public void Build()
    {
        this.UpdateList();
    }
    private void UpdateList()
    {
        float val_8;
        UnityEngine.RectTransform val_9;
        System.Collections.Generic.List<UnityEngine.RectTransform> val_1 = this.GetActiveItems();
        if(this.isSnapScroll != false)
        {
                val_8 = this.itemSize;
        }
        else
        {
                val_8 = 0f;
        }
        
        val_9 = this.root;
        if(this.listType == 1)
        {
                UnityEngine.Vector2 val_2 = val_9.sizeDelta;
            float val_8 = (float)S10;
            val_8 = this.itemSize * val_8;
            val_8 = val_8 + val_8;
            UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_8, y:  val_2.y);
            val_9.sizeDelta = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
            if(this.listType < 1)
        {
                return;
        }
        
            var val_10 = 0;
            val_8 = val_8 * 0.5f;
            do
        {
            if(this.listType <= val_10)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector2 val_4 = ListView.Type.__il2cppRuntimeField_byval_arg.sizeDelta;
            float val_9 = 0f;
            val_9 = this.itemSize * val_9;
            val_4.x = val_4.x * 0.5f;
            val_4.x = val_9 + val_4.x;
            val_4.x = val_8 + val_4.x;
            PluginExtension.SetLocalX(transform:  ListView.Type.__il2cppRuntimeField_byval_arg, x:  val_4.x);
            val_10 = val_10 + 1;
        }
        while(val_10 < null);
        
            return;
        }
        
        UnityEngine.Vector2 val_5 = val_9.sizeDelta;
        float val_11 = (float)val_5.y;
        val_11 = this.itemSize * val_11;
        val_11 = val_8 + val_11;
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_5.x, y:  val_11);
        val_9.sizeDelta = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        if(this.listType < 1)
        {
                return;
        }
        
        var val_13 = 0;
        val_8 = val_8 * 0.5f;
        do
        {
            if(this.listType <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector2 val_7 = ListView.Type.__il2cppRuntimeField_byval_arg.sizeDelta;
            float val_12 = 0f;
            val_12 = this.itemSize * val_12;
            val_7.y = val_7.y * (-0.5f);
            val_12 = val_7.y - val_12;
            val_12 = val_12 - val_8;
            PluginExtension.SetLocalY(transform:  ListView.Type.__il2cppRuntimeField_byval_arg, y:  val_12);
            val_13 = val_13 + 1;
        }
        while(val_13 < null);
    
    }
    public void DisappearItems(int[] indexes)
    {
        var val_2;
        if(indexes.Length >= 1)
        {
                do
        {
            int val_2 = indexes[0];
            if(indexes[0] <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            indexes[0][val_2].gameObject.SetActive(value:  false);
            val_2 = 0 + 1;
        }
        while(val_2 < indexes.Length);
        
        }
        
        this.UpdateList();
    }
    public void DisappearItemsAfterTime(float delay, int[] indexes)
    {
        UnityEngine.Coroutine val_2 = this.behaviour.StartCoroutine(routine:  this.IEDisappearItems(indexes:  indexes, delay:  delay));
    }
    private System.Collections.IEnumerator IEDisappearItems(int[] indexes, float delay)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .indexes = indexes;
        .delay = delay;
        return (System.Collections.IEnumerator)new ListView.<IEDisappearItems>d__16();
    }
    private System.Collections.Generic.List<UnityEngine.RectTransform> GetActiveItems()
    {
        var val_2;
        System.Predicate<UnityEngine.RectTransform> val_4;
        val_2 = null;
        val_2 = null;
        val_4 = ListView.<>c.<>9__17_0;
        if(val_4 != null)
        {
                return this.items.FindAll(match:  System.Predicate<UnityEngine.RectTransform> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<UnityEngine.RectTransform>(object:  ListView.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean ListView.<>c::<GetActiveItems>b__17_0(UnityEngine.RectTransform x));
        ListView.<>c.<>9__17_0 = val_4;
        return this.items.FindAll(match:  val_1);
    }
    public int GetActiveItemsCount()
    {
        return (int)this.GetActiveItems();
    }

}
