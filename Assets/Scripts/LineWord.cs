using UnityEngine;
public class LineWord : MonoBehaviour
{
    // Fields
    public string answer;
    public float cellSize;
    public System.Collections.Generic.List<Cell> cells;
    public int numLetters;
    public float lineWidth;
    public bool isShown;
    public bool isStarred;
    
    // Properties
    public int numLettersFound { get; }
    public int numLettersRemaining { get; }
    private int _numLettersFound { get; }
    
    // Methods
    public int get_numLettersFound()
    {
        if(this.isShown == false)
        {
                return this._numLettersFound;
        }
        
        return (int)this.numLetters;
    }
    public int get_numLettersRemaining()
    {
        if(this.isShown != false)
        {
                return 0;
        }
        
        int val_1 = this._numLettersFound;
        val_1 = this.numLetters - val_1;
        return (int)val_1;
    }
    public void MakeVisible(bool visible)
    {
        var val_2;
        bool val_2 = true;
        val_2 = 0;
        do
        {
            if(val_2 >= val_2)
        {
                return;
        }
        
            if(val_2 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2 = val_2 + 0;
            (true + 0) + 32 + 112.alpha = (visible != true) ? 1f : 0f;
            val_2 = val_2 + 1;
        }
        while(this.cells != null);
        
        throw new NullReferenceException();
    }
    public void Build(Cell cellType, bool clickable = True)
    {
        var val_21;
        LineWord val_22;
        float val_23;
        var val_24;
        var val_25;
        object val_26;
        val_21 = clickable;
        val_22 = this;
        this.numLetters = this.answer.m_stringLength;
        val_23 = this.cellSize;
        GameBehavior val_1 = App.getBehavior;
        if(this.numLetters < 1)
        {
                return;
        }
        
        val_24 = 1152921504878624768;
        val_25 = 1152921504762171392;
        var val_22 = 0;
        val_23 = val_23 * S0;
        do
        {
            LineWord.<>c__DisplayClass12_0 val_2 = null;
            val_26 = val_2;
            val_2 = new LineWord.<>c__DisplayClass12_0();
            .<>4__this = val_22;
            .cell = UnityEngine.Object.Instantiate<Cell>(original:  cellType);
            val_3.letter = this.answer.Chars[0].ToString();
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
            float val_20 = this.cellSize;
            val_20 = val_20 / 80f;
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, d:  val_20);
            (LineWord.<>c__DisplayClass12_0)[1152921515445818032].cell.SetScale(newScale:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
            UnityEngine.RectTransform val_8 = (LineWord.<>c__DisplayClass12_0)[1152921515445818032].cell.GetComponent<UnityEngine.RectTransform>();
            val_8.SetParent(p:  this.transform);
            UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  this.cellSize, y:  this.cellSize);
            val_8.sizeDelta = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            UnityEngine.Vector3 val_11 = UnityEngine.Vector3.one;
            val_8.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            float val_21 = this.cellSize;
            float val_12 = val_21 * 0.5f;
            val_21 = val_23 + val_21;
            val_21 = val_21 * 0f;
            val_21 = val_12 + val_21;
            UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  val_21, y:  val_12);
            val_8.localPosition = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
            this.cells.Add(item:  (LineWord.<>c__DisplayClass12_0)[1152921515445818032].cell);
            if(val_21 != false)
        {
                UnityEngine.UI.Button val_15 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(gameObject:  (LineWord.<>c__DisplayClass12_0)[1152921515445818032].cell.gameObject);
            val_15.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_2, method:  System.Void LineWord.<>c__DisplayClass12_0::<Build>b__0()));
            val_26 = MonoSingleton<HintPickerController>.Instance;
            val_24 = val_24;
            val_25 = val_25;
            val_21 = val_21;
            val_22 = val_22;
            if(val_26 != 0)
        {
                val_15.transition = 2;
            HintPickerController val_19 = MonoSingleton<HintPickerController>.Instance;
            val_15.spriteState = new UnityEngine.UI.SpriteState() {m_HighlightedSprite = val_13.x, m_DisabledSprite = val_19.tileSpotHighlightDisabled};
        }
        
        }
        
            val_22 = val_22 + 1;
        }
        while(val_22 < this.numLetters);
    
    }
    public void ReBuild()
    {
        float val_12;
        this.numLetters = this.answer.m_stringLength;
        val_12 = this.cellSize;
        GameBehavior val_1 = App.getBehavior;
        if(this.numLetters < 1)
        {
                return;
        }
        
        var val_14 = 0;
        val_12 = val_12 * S0;
        do
        {
            if(32493568 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            mem[85899346160] = this.answer.Chars[0].ToString();
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
            float val_12 = this.cellSize;
            val_12 = val_12 / 80f;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  val_12);
            176.SetScale(newScale:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            UnityEngine.RectTransform val_6 = 176.GetComponent<UnityEngine.RectTransform>();
            val_6.SetParent(p:  this.transform);
            UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  this.cellSize, y:  this.cellSize);
            val_6.sizeDelta = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.one;
            val_6.localScale = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            float val_13 = this.cellSize;
            UnityEngine.Vector3 val_11;
            float val_10 = val_13 * 0.5f;
            val_13 = val_12 + val_13;
            val_13 = val_13 * 0f;
            val_13 = val_10 + val_13;
            val_11 = new UnityEngine.Vector3(x:  val_13, y:  val_10);
            val_6.localPosition = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            val_14 = val_14 + 1;
        }
        while(val_14 < this.numLetters);
    
    }
    public void SetLineWidth()
    {
        GameBehavior val_2 = App.getBehavior;
        float val_6 = (float)this.answer.m_stringLength - 1;
        float val_7 = (float)this.answer.m_stringLength;
        val_6 = this.cellSize * val_6;
        val_7 = this.cellSize * val_7;
        float val_4 = val_6 * S0;
        val_4 = val_7 + val_4;
        this.lineWidth = val_4;
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  val_4, y:  this.cellSize);
        this.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
    }
    public void SetProgress(string progress)
    {
        var val_6;
        string val_7 = progress;
        if(progress.m_stringLength != W9)
        {
            goto label_3;
        }
        
        this.isShown = true;
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        val_6 = 0;
        goto label_4;
        label_8:
        if((val_7.Chars[0] & 65535) == '1')
        {
                if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
            0.SetAndShowText();
        }
        else
        {
                this.isShown = false;
        }
        
        val_6 = 1;
        label_4:
        if(0.MoveNext() == true)
        {
            goto label_8;
        }
        
        0.Dispose();
        return;
        label_3:
        val_7 = "Mismatched progress and level data, not caught. line: "("Mismatched progress and level data, not caught. line: ") + this.answer;
        UnityEngine.Debug.LogError(message:  val_7);
    }
    private int get__numLettersFound()
    {
        var val_3;
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        val_3 = 0;
        goto label_2;
        label_4:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3 = 0;
        label_2:
        if(0.MoveNext() == true)
        {
            goto label_4;
        }
        
        0.Dispose();
        return (int)val_3;
    }
    public void SetStarred()
    {
        bool val_1 = true;
        var val_2 = 0;
        label_6:
        if(val_2 >= val_1)
        {
            goto label_2;
        }
        
        if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + 0;
        if(((true + 0) + 32 + 72) == 0)
        {
                (true + 0) + 32.ShowStarred();
        }
        
        val_2 = val_2 + 1;
        if(this.cells != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_2:
        this.isStarred = true;
    }
    public void SetAnswer()
    {
        this.isShown = true;
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.SetAndShowText();
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void ShowAnswer(float waitTime = 0)
    {
        this.isShown = true;
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        goto label_2;
        label_4:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[72] = true;
        label_2:
        if(0.MoveNext() == true)
        {
            goto label_4;
        }
        
        0.Dispose();
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.IEShowAnswer(waitBeforePlaying:  waitTime));
    }
    public System.Collections.IEnumerator IEShowAnswer(float waitBeforePlaying)
    {
        .<>4__this = this;
        .waitBeforePlaying = waitBeforePlaying;
        return (System.Collections.IEnumerator)new LineWord.<IEShowAnswer>d__21(<>1__state:  0);
    }
    public Cell ShowHintGetCell(Cell cell)
    {
        Cell val_2 = cell;
        if(val_2 != 0)
        {
                if(val_2 != null)
        {
            goto label_10;
        }
        
        }
        
        var val_2 = 0;
        do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_2 = mem[(UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32];
            val_2 = (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32;
            val_2 = this.cells;
            val_2 = val_2 + 1;
        }
        while(val_2 != null);
        
        throw new NullReferenceException();
        label_10:
        val_2.ShowHint();
        this.CheckShown();
        return (Cell);
    }
    public UnityEngine.Vector3 ShowHint(Cell cell)
    {
        Cell val_1 = this.ShowHintGetCell(cell:  cell);
        if(val_1 != 0)
        {
                return val_1.transform.position;
        }
        
        return UnityEngine.Vector3.zero;
    }
    public int GetHintCellIndex(Cell cell)
    {
        var val_2;
        if(cell != 0)
        {
                return this.cells.IndexOf(item:  cell);
        }
        
        val_2 = 0;
        do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_2 = val_2 + 1;
        }
        while(this.cells != null);
        
        throw new NullReferenceException();
    }
    public void CheckShown()
    {
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(0 != 0)
        {
            goto label_4;
        }
        
        0.Dispose();
        return;
        label_2:
        0.Dispose();
        this.isShown = true;
    }
    public void ShowExists()
    {
        var val_2 = 4;
        do
        {
            var val_1 = val_2 - 4;
            if(val_1 >= true)
        {
                return;
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((mem[-2305843009213693880]) != false)
        {
                if((mem[-2305843009213693880]) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            mem[-2305843009213693880] + 32.ShowExists();
        }
        
            this.cells = this.cells;
            val_2 = val_2 + 1;
        }
        while(this.cells != null);
        
        throw new NullReferenceException();
    }
    public void DisplayDefiniton()
    {
        if(this.isShown == false)
        {
                return;
        }
        
        if(App.Player < 3)
        {
                return;
        }
        
        MainController val_2 = MainController.instance;
        if(val_2.isGameComplete != false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<WGDefinitionManager>.Instance.displayDefinition(word:  this.answer, flyout:  false);
    }
    public System.Collections.Generic.List<Cell> HiddenCells()
    {
        System.Collections.Generic.List<Cell> val_1 = new System.Collections.Generic.List<Cell>();
        List.Enumerator<T> val_2 = this.cells.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(0 != 0)
        {
            goto label_6;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  0);
        goto label_6;
        label_2:
        0.Dispose();
        return val_1;
    }
    public int HiddenCellsCount()
    {
        var val_3;
        List.Enumerator<T> val_1 = this.cells.GetEnumerator();
        val_3 = 0;
        goto label_2;
        label_4:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3 = 1;
        label_2:
        if(0.MoveNext() == true)
        {
            goto label_4;
        }
        
        0.Dispose();
        return (int)val_3;
    }
    public LineWord()
    {
        this.cells = new System.Collections.Generic.List<Cell>();
    }

}
