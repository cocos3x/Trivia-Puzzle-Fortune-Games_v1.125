using UnityEngine;
public class WordRegionBase : MonoBehaviour
{
    // Fields
    protected UnityEngine.RectTransform safeAreaWithinParent;
    protected float previousSafeHeight;
    private bool <isMovingObjectCollected>k__BackingField;
    protected System.Collections.Generic.List<LineWord> lines;
    protected int numWords;
    protected int numCol;
    protected int numRow;
    protected int maxCellInWidth;
    protected float cellSize;
    protected float startFirstColX;
    protected bool hasLongLine;
    
    // Properties
    public bool isMovingObjectCollected { get; set; }
    public UnityEngine.Rect getSafeAreaRect { get; }
    public System.Collections.Generic.List<LineWord> getLines { get; }
    public System.Collections.Generic.List<int> getAvailableLineIndices { get; }
    protected System.Collections.Generic.List<int> getUnavailableLineIndices { get; }
    public System.Collections.Generic.List<LineWord> getAvailableLineWords { get; }
    
    // Methods
    public bool get_isMovingObjectCollected()
    {
        return (bool)this.<isMovingObjectCollected>k__BackingField;
    }
    public void set_isMovingObjectCollected(bool value)
    {
        this.<isMovingObjectCollected>k__BackingField = value;
    }
    public UnityEngine.Rect get_getSafeAreaRect()
    {
        if(this.safeAreaWithinParent != null)
        {
                return this.safeAreaWithinParent.rect;
        }
        
        throw new NullReferenceException();
    }
    public System.Collections.Generic.List<LineWord> get_getLines()
    {
        return (System.Collections.Generic.List<LineWord>)this.lines;
    }
    public System.Collections.Generic.List<int> get_getAvailableLineIndices()
    {
        var val_4;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_4 = 0;
        do
        {
            if(val_4 >= this.lines)
        {
                return System.Linq.Enumerable.ToList<System.Int32>(source:  System.Linq.Enumerable.Except<System.Int32>(first:  val_1, second:  val_1.getUnavailableLineIndices));
        }
        
            val_1.Add(item:  0);
            val_4 = val_4 + 1;
        }
        while(this.lines != null);
        
        throw new NullReferenceException();
    }
    protected System.Collections.Generic.List<int> get_getUnavailableLineIndices()
    {
        var val_24;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        if((Alphabet2Manager.IsAvailable != false) && ((MonoSingleton<Alphabet2Manager>.Instance.canAddGameplayTile) != false))
        {
                if((System.String.IsNullOrEmpty(value:  MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionLetter)) != true)
        {
                val_1.Add(item:  MonoSingleton<Alphabet2Manager>.Instance.GetAbWordIndex);
        }
        
        }
        
        val_24 = null;
        val_24 = null;
        if(App.game == 18)
        {
                WordForest.WFOMysteryChestManager val_10 = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance;
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked != false)
        {
                if(val_10 != 0)
        {
                val_1.AddRange(collection:  val_10.GetChestsWordIndexes());
        }
        
        }
        
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WordGameEventsController>.Instance)) != false)
        {
                val_1.AddRange(collection:  MonoSingleton<WordGameEventsController>.Instance.GetMovingItemsIndices());
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGChallengeWordsManager>.Instance)) == false)
        {
                return val_1;
        }
        
        if((MonoSingleton<WGChallengeWordsManager>.Instance.IsPlaying) == false)
        {
                return val_1;
        }
        
        WGChallengeWordsManager val_22 = MonoSingleton<WGChallengeWordsManager>.Instance;
        val_1.Add(item:  val_22.progress.WordIndex);
        return val_1;
    }
    public System.Collections.Generic.List<LineWord> get_getAvailableLineWords()
    {
        System.Collections.Generic.List<System.Int32> val_1 = this.getAvailableLineIndices;
        System.Collections.Generic.List<LineWord> val_2 = new System.Collections.Generic.List<LineWord>();
        if(1152921517088822256 < 1)
        {
                return val_2;
        }
        
        var val_3 = 0;
        do
        {
            if(val_3 >= 1152921517088822256)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(44488224 <= (System.Void PiggyBankRaidEventHandler::<RetrieveRaidPool>b__80_0(System.Collections.Generic.Dictionary<string, object> resp)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2.Add(item:  mem[-9223371941007058752]);
            val_3 = val_3 + 1;
        }
        while(val_3 < (-9223371941007058784));
        
        return val_2;
    }
    protected void RecalculateCellSize()
    {
        float val_16;
        UnityEngine.Rect val_1 = this.safeAreaWithinParent.rect;
        if(this.numCol < 2)
        {
                float val_2 = val_1.m_XMin.height;
            GameBehavior val_3 = App.getBehavior;
            val_2 = val_2 * ((float)this.numRow - 1);
            val_2 = val_2 + (float)this.numRow;
            val_2 = val_2 + 0.8f;
            val_2 = val_2 / val_2;
            this.cellSize = val_2;
            float val_5 = val_1.m_XMin.width;
            val_16 = val_5;
            GameBehavior val_6 = App.getBehavior;
            val_5 = val_5 * ((float)this.maxCellInWidth - 1);
            val_5 = val_5 + (float)this.maxCellInWidth;
            val_5 = val_16 / val_5;
            if(val_5 >= 0)
        {
                return;
        }
        
            this.hasLongLine = true;
            this.cellSize = val_5;
            return;
        }
        
        GameBehavior val_8 = App.getBehavior;
        int val_16 = this.numCol;
        val_1.m_XMin = val_1.m_XMin * ((float)this.maxCellInWidth - this.numCol);
        val_16 = val_16 - 1;
        val_1.m_XMin = val_1.m_XMin + (float)this.maxCellInWidth;
        float val_17 = (float)val_16;
        val_17 = val_17 * 0.4f;
        float val_10 = val_1.m_XMin + val_17;
        float val_11 = val_1.m_XMin.width;
        val_11 = val_11 / val_10;
        this.cellSize = val_11;
        float val_12 = val_1.m_XMin.height;
        val_16 = val_12;
        GameBehavior val_13 = App.getBehavior;
        val_12 = val_12 * ((float)this.numRow + 1);
        val_12 = val_12 + (float)this.numRow;
        val_12 = val_16 / val_12;
        if(val_12 >= 0)
        {
                return;
        }
        
        this.cellSize = val_12;
        float val_15 = val_1.m_XMin.width;
        float val_18 = this.cellSize;
        val_18 = val_10 * val_18;
        val_15 = val_15 - val_18;
        val_15 = val_15 * 0.5f;
        this.startFirstColX = val_15;
    }
    protected System.Collections.IEnumerator ScaleToPositionAndFitLate()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WordRegionBase.<ScaleToPositionAndFitLate>d__25();
    }
    protected virtual void ScaleToFit()
    {
        var val_5;
        var val_6;
        if(this.safeAreaWithinParent == 0)
        {
                return;
        }
        
        UnityEngine.Rect val_2 = this.safeAreaWithinParent.rect;
        val_5 = 0;
        float val_3 = val_2.m_XMin.height;
        val_6 = null;
        val_6 = null;
        if((this.previousSafeHeight ?? val_3) <= UnityEngine.Mathf.Epsilon)
        {
                return;
        }
        
        this.previousSafeHeight = val_3;
        this.RecalculateCellSize();
        var val_6 = 4;
        do
        {
            var val_5 = val_6 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            mem2[0] = this.cellSize;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Mathf.Epsilon.__il2cppRuntimeField_20 + 32.SetLineWidth();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_5 = 0;
            UnityEngine.Mathf.Epsilon.__il2cppRuntimeField_20 + 32.ReBuild();
            val_6 = val_6 + 1;
        }
        while(this.lines != null);
        
        throw new NullReferenceException();
    }
    protected virtual void SetLinesPosition()
    {
        float val_32;
        float val_33;
        float val_34;
        var val_35;
        var val_36;
        int val_38;
        float val_39;
        float val_40;
        UnityEngine.Rect val_1 = this.safeAreaWithinParent.rect;
        val_32 = val_1.m_XMin.width;
        float val_32 = -0.5f;
        val_32 = val_1.m_XMin.height * val_32;
        val_33 = val_32 * val_32;
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  val_33, y:  val_32);
        if(this.numCol <= 1)
        {
                val_34 = 0.4f;
            val_35 = 1152921504884269056;
            val_36 = 0;
            var val_36 = 0;
            do
        {
            if(val_36 >= this.lines)
        {
                return;
        }
        
            float val_6 = val_1.m_XMin.width;
            float val_35 = val_6;
            if(this.lines <= val_36)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(this.hasLongLine != false)
        {
                float val_7 = val_1.m_XMin.height;
            val_38 = this.numRow;
            float val_33 = (float)val_38;
            val_33 = this.cellSize * val_33;
            val_7 = val_7 - val_33;
            val_39 = val_7 / ((float)val_38 + 1);
            val_40 = this.cellSize + val_39;
        }
        else
        {
                GameBehavior val_9 = App.getBehavior;
            val_38 = this.numRow;
            val_6 = this.cellSize * val_6;
            val_39 = this.cellSize * val_34;
            val_40 = this.cellSize + val_6;
        }
        
            if(null <= val_36)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            float val_34 = (float)val_38 + val_36;
            val_34 = val_40 * val_34;
            val_35 = (val_35 * 0.5f) - ((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 52) * 0.5f);
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_35, y:  val_39 + val_34);
            UnityEngine.Vector2 val_16 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_15.x, y = val_15.y}, b:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
            UnityEngine.Vector3 val_17 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_16.x, y = val_16.y});
            GameplayBehavior.__il2cppRuntimeField_byval_arg.transform.localPosition = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
            val_36 = val_36 + 1;
            val_36 = val_36 - 1;
        }
        while(this.lines != null);
        
        }
        
        float[] val_18 = new float[0];
        int val_37 = val_18.Length;
        val_18[0] = this.startFirstColX;
        if(this.numCol >= 2)
        {
                val_32 = 0.4f;
            val_37 = val_37 & 4294967295;
            do
        {
            int val_39 = this.numRow;
            val_39 = val_39 * (0 + 1);
            int val_20 = val_39 - 1;
            if(val_18[0] <= val_20)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            float val_40 = val_18[0][val_20];
            var val_21 = 0 + 1;
            float val_41 = val_18[0x0][((this.numRow * (0 + 1)) - 1)][0] + 52;
            float val_42 = this.cellSize;
            val_41 = val_18[0] + val_41;
            val_42 = val_42 * val_32;
            val_33 = val_41 + val_42;
            val_18[0] = val_33;
            val_36 = 0 + 1;
        }
        while((0 + 2) < this.numCol);
        
        }
        
        var val_48 = 0;
        val_35 = 0;
        do
        {
            if(val_35 >= this.lines)
        {
                return;
        }
        
            int val_23 = val_35 / this.numRow;
            val_34 = this.cellSize;
            float val_47 = val_1.m_XMin.height;
            if((val_18[val_23 << 2]) <= val_35)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            int val_25 = val_23 + 1;
            float val_45 = (float)this.numRow;
            val_25 = val_48 + (this.numRow * val_25);
            val_45 = val_34 * val_45;
            val_45 = val_47 - val_45;
            val_45 = val_45 / ((float)this.numRow + 1);
            float val_46 = (float)val_25 - 1;
            val_45 = val_45 * (float)val_25;
            val_46 = val_34 * val_46;
            val_47 = val_46 + val_45;
            val_36 = val_18[val_23 << 2][val_35].transform;
            UnityEngine.Vector2 val_29 = new UnityEngine.Vector2(x:  val_18[val_23 << 2], y:  val_47);
            val_32 = val_5.x;
            UnityEngine.Vector2 val_30 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y}, b:  new UnityEngine.Vector2() {x = val_32, y = val_5.y});
            UnityEngine.Vector3 val_31 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_30.x, y = val_30.y});
            val_36.localPosition = new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z};
            val_35 = val_35 + 1;
            val_48 = val_48 - 1;
        }
        while(this.lines != null);
        
        throw new NullReferenceException();
    }
    public WordRegionBase()
    {
        this.lines = new System.Collections.Generic.List<LineWord>();
    }

}
