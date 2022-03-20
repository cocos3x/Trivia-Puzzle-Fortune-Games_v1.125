using UnityEngine;
public class Scroller : MonoBehaviour
{
    // Fields
    public ScrollerIteam[] ScrollingItems;
    public bool isWindStart;
    public float windStart;
    public float windStartTime;
    public bool isWindEnd;
    public float windEnd;
    public float windEndTime;
    private bool scrollHorizontal;
    private bool invertScroll;
    private System.Collections.Generic.List<ScrollerIteam> <ScrollingItemsList>k__BackingField;
    private float <itemSpace>k__BackingField;
    private bool <isScrolling>k__BackingField;
    private UnityEngine.UI.HorizontalOrVerticalLayoutGroup layoutGroup;
    private float movedDistance;
    private float moveNeed;
    private UnityEngine.Vector3 moveNeedV3;
    private float movedItemSpace;
    private System.Collections.Generic.List<ScrollerIteamData> iteamsmData;
    private int iteamDataIndex;
    private System.Action<ScrollerIteam> onScrolledIteam;
    
    // Properties
    public System.Collections.Generic.List<ScrollerIteam> ScrollingItemsList { get; set; }
    public float itemSpace { get; set; }
    public int iteamCount { get; }
    public bool isScrolling { get; set; }
    
    // Methods
    public System.Collections.Generic.List<ScrollerIteam> get_ScrollingItemsList()
    {
        return (System.Collections.Generic.List<ScrollerIteam>)this.<ScrollingItemsList>k__BackingField;
    }
    private void set_ScrollingItemsList(System.Collections.Generic.List<ScrollerIteam> value)
    {
        this.<ScrollingItemsList>k__BackingField = value;
    }
    public float get_itemSpace()
    {
        return (float)this.<itemSpace>k__BackingField;
    }
    private void set_itemSpace(float value)
    {
        this.<itemSpace>k__BackingField = value;
    }
    public int get_iteamCount()
    {
        if(this.ScrollingItems != null)
        {
                return (int)this.ScrollingItems.Length;
        }
        
        throw new NullReferenceException();
    }
    public bool get_isScrolling()
    {
        return (bool)this.<isScrolling>k__BackingField;
    }
    private void set_isScrolling(bool value)
    {
        this.<isScrolling>k__BackingField = value;
    }
    private void Awake()
    {
        this.layoutGroup = this.gameObject.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>();
        this.<isScrolling>k__BackingField = false;
    }
    private void Start()
    {
        if(this.layoutGroup != null)
        {
                this.layoutGroup.enabled = false;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void Init()
    {
        float val_8;
        var val_9;
        UnityEngine.Vector3 val_2 = this.ScrollingItems[0].transform.localPosition;
        if(this.scrollHorizontal != false)
        {
                val_8 = val_2.x;
            UnityEngine.Vector3 val_4 = this.ScrollingItems[1].transform.localPosition;
            val_9 = val_8 - val_4.x;
        }
        else
        {
                UnityEngine.Vector3 val_6 = this.ScrollingItems[1].transform.localPosition;
            val_8 = val_6.y;
            val_9 = val_2.y - val_8;
        }
        
        this.<itemSpace>k__BackingField = System.Math.Abs(val_9);
    }
    public void Init(System.Action<ScrollerIteam> onScrolledIteamChange)
    {
        this.onScrolledIteam = onScrolledIteamChange;
    }
    public void Init(System.Action<ScrollerIteam> onScrolledIteamChange, bool scrollDir)
    {
        this.scrollHorizontal = scrollDir;
        this.onScrolledIteam = onScrolledIteamChange;
    }
    public void Init(System.Action<ScrollerIteam> onScrolledIteamChange, bool scrollDir, bool invert)
    {
        this.invertScroll = invert;
        this.scrollHorizontal = scrollDir;
        this.onScrolledIteam = onScrolledIteamChange;
    }
    public void SetWind(float start = 0, float end = 0)
    {
        this.windStart = start;
        this.windEnd = end;
    }
    public void InitScrollerIteam<T>(System.Collections.Generic.List<T> data)
    {
        var val_2 = 0;
        do
        {
            if(val_2 >= this.ScrollingItems.Length)
        {
                return;
        }
        
            if(val_2 < (data << ))
        {
                ScrollerIteam val_1 = this.ScrollingItems[val_2];
        }
        
            val_2 = val_2 + 1;
        }
        while(this.ScrollingItems != null);
        
        throw new NullReferenceException();
    }
    public void SetData<T>(System.Collections.Generic.List<T> data, bool invert = False, float windStartDis = -1, float windEndDis = -1)
    {
        this.iteamsmData.Clear();
        if(data >= 1)
        {
                var val_10 = 0;
            do
        {
            this.iteamsmData.Add(item:  data);
            val_10 = val_10 + 1;
        }
        while(val_10 < data);
        
        }
        
        this.iteamDataIndex = 0;
        if((this.iteamsmData == null) || ((__RuntimeMethodHiddenParam + 48 + 16) < 1))
        {
            goto label_23;
        }
        
        if(invert == false)
        {
            goto label_8;
        }
        
        var val_13 = 0;
        label_15:
        if(val_13 >= this.ScrollingItems.Length)
        {
            goto label_23;
        }
        
        ScrollerIteam val_11 = this.ScrollingItems[val_13];
        int val_2 = 0 - ((0 / this.ScrollingItems.Length) * this.ScrollingItems.Length);
        if(this.ScrollingItems.Length <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        ScrollerIteam val_12 = this.ScrollingItems[val_13][val_2];
        int val_14 = this.iteamDataIndex;
        val_13 = val_13 + 1;
        val_14 = val_14 + 1;
        this.iteamDataIndex = val_14;
        if(this.ScrollingItems != null)
        {
            goto label_15;
        }
        
        label_8:
        int val_3 = this.ScrollingItems.Length - 1;
        if((__RuntimeMethodHiddenParam + 48 + 16) < 0)
        {
            goto label_23;
        }
        
        var val_15 = 0;
        var val_4 = X9 + 32;
        label_24:
        int val_6 = val_15 - ((val_15 / this.ScrollingItems.Length) * this.ScrollingItems.Length);
        if(this.ScrollingItems.Length <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_15 = val_15 + (val_6 << 3);
        int val_16 = this.iteamDataIndex;
        val_3 = val_3 - 1;
        val_16 = val_16 + 1;
        this.iteamDataIndex = val_16;
        if((val_3 & 2147483648) != 0)
        {
            goto label_23;
        }
        
        val_4 = val_4 - 8;
        if(this.iteamsmData != null)
        {
            goto label_24;
        }
        
        label_23:
        this.invertScroll = invert;
        this.layoutGroup.enabled = true;
        this.movedDistance = 0f;
        this.movedItemSpace = 0f;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.zero;
        this.moveNeedV3 = val_8;
        mem[1152921517122394324] = val_8.y;
        mem[1152921517122394328] = val_8.z;
        if(windStartDis > 0f)
        {
                this.windStart = windStartDis;
        }
        
        if(windEndDis > 0f)
        {
                this.windEnd = windEndDis;
        }
        
        this.<ScrollingItemsList>k__BackingField = new System.Collections.Generic.List<ScrollerIteam>(collection:  this.ScrollingItems);
    }
    public void StartSpin(int scrollCount, float duration = 1, DG.Tweening.TweenCallback callback)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ActuallyStartSpin(scrollCount:  scrollCount, duration:  duration, callback:  callback));
    }
    private System.Collections.IEnumerator ActuallyStartSpin(int scrollCount, float duration = 1, DG.Tweening.TweenCallback callback)
    {
        .<>1__state = 0;
        .scrollCount = scrollCount;
        .duration = duration;
        .<>4__this = this;
        .callback = callback;
        return (System.Collections.IEnumerator)new Scroller.<ActuallyStartSpin>d__41();
    }
    private void UpdatePosition(float totalDistance)
    {
        float val_17;
        System.Collections.Generic.List<ScrollerIteam> val_18;
        var val_19;
        float val_20;
        float val_21;
        ScrollerIteam val_22;
        ScrollerIteam val_23;
        ScrollerIteam val_24;
        var val_25;
        System.Collections.Generic.List<ScrollerIteamData> val_26;
        float val_17 = this.movedItemSpace;
        val_17 = totalDistance - this.movedDistance;
        val_17 = val_17 + val_17;
        this.moveNeed = val_17;
        this.movedItemSpace = val_17;
        if(this.invertScroll != false)
        {
                val_17 = -val_17;
            this.moveNeed = val_17;
        }
        
        var val_1 = (this.scrollHorizontal == false) ? 100 : 96;
        mem2[0] = val_17;
        val_18 = this.<ScrollingItemsList>k__BackingField;
        val_19 = 4;
        label_13:
        var val_2 = val_19 - 4;
        if(val_2 >= val_1)
        {
            goto label_3;
        }
        
        if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_1 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_5 = this.scrollHorizontal == false ? 100 : 96 + 32.transform.localPosition;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = this.moveNeedV3, y = V12.16B, z = V11.16B});
        this.scrollHorizontal == false ? 100 : 96 + 32.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        val_19 = val_19 + 1;
        if((this.<ScrollingItemsList>k__BackingField) != null)
        {
            goto label_13;
        }
        
        label_3:
        if(this.movedItemSpace <= (this.<itemSpace>k__BackingField))
        {
            goto label_39;
        }
        
        val_19 = 96;
        label_40:
        val_20 = (float)this.movedItemSpace;
        val_21 = (this.<itemSpace>k__BackingField) * val_20;
        var val_7 = (this.scrollHorizontal == false) ? 100 : (val_19);
        mem2[0] = val_21;
        if(this.invertScroll != false)
        {
                val_21 = this.moveNeedV3;
            val_20 = V10.16B;
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_21, y = val_20, z = V11.16B}, d:  -1f);
            this.moveNeedV3 = val_8;
            mem[1152921517123025236] = val_8.y;
            mem[1152921517123025240] = val_8.z;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_22 = mem[UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished + 32];
            val_22 = UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished + 32;
            this.<ScrollingItemsList>k__BackingField.RemoveAt(index:  0);
            val_23 = public System.Void System.Collections.Generic.List<ScrollerIteam>::Add(ScrollerIteam item);
            this.<ScrollingItemsList>k__BackingField.Add(item:  val_22);
        }
        
        bool val_9 = this.invertScroll - 1;
        if(this.invertScroll != false)
        {
                val_24 = this.invertScroll + (val_9 << 3);
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_25 = this.<ScrollingItemsList>k__BackingField;
            val_24 = 96 + (val_9 << 3);
        }
        
        val_24 = val_24 + 32;
        val_22 = mem[((96 + ((this.invertScroll - 1)) << 3) + 32)];
        val_22 = val_24;
        val_25.RemoveAt(index:  val_24 - 1);
        val_23 = val_22;
        this.<ScrollingItemsList>k__BackingField.Insert(index:  0, item:  val_23);
        UnityEngine.Vector3 val_13 = val_22.transform.localPosition;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, b:  new UnityEngine.Vector3() {x = this.moveNeedV3, y = V13.16B, z = V12.16B});
        val_22.transform.localPosition = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        val_26 = this.iteamsmData;
        if(val_26 != null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            int val_18 = this.iteamDataIndex;
            val_18 = val_18 + 1;
            this.iteamDataIndex = val_18;
        }
        
        if(this.onScrolledIteam != null)
        {
                this.onScrolledIteam.Invoke(obj:  val_22);
        }
        
        float val_19 = this.movedItemSpace;
        val_19 = val_19 - (this.<itemSpace>k__BackingField);
        this.movedItemSpace = val_19;
        if(val_19 <= (this.<itemSpace>k__BackingField))
        {
            goto label_39;
        }
        
        val_26 = this.<ScrollingItemsList>k__BackingField;
        if(val_26 != null)
        {
            goto label_40;
        }
        
        throw new NullReferenceException();
        label_39:
        this.movedDistance = totalDistance;
    }
    public Scroller()
    {
        this.windStartTime = 0.5f;
        this.windEndTime = 0.5f;
        this.scrollHorizontal = true;
        this.iteamsmData = new System.Collections.Generic.List<ScrollerIteamData>();
    }

}
