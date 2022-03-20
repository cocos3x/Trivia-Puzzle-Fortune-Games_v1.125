using UnityEngine;
public class UGUIPageDisplay : MonoBehaviour
{
    // Fields
    public int maxPageDots;
    private UnityEngine.GameObject pageDotPrefab;
    private UnityEngine.Transform dotGridTransform;
    private UnityEngine.UI.HorizontalLayoutGroup dotControlGroup;
    private UnityEngine.UI.Button button_left;
    private UnityEngine.UI.Button button_right;
    private UnityEngine.GameObject[] pages;
    private UnityEngine.UI.Text pageNumbering;
    private bool refreshOnEnable;
    private bool hideControlls;
    private int currentPageIndex;
    private System.Collections.Generic.List<UnityEngine.UI.Button> pageDots;
    public System.Action<int> PageIndexChanged;
    private int numPages;
    
    // Properties
    public int NumPages { get; set; }
    
    // Methods
    public int get_NumPages()
    {
        if(this.numPages != 1)
        {
                return (int)this.numPages;
        }
        
        if(this.pages != null)
        {
                return (int)this.pages.Length;
        }
        
        throw new NullReferenceException();
    }
    public void set_NumPages(int value)
    {
        this.numPages = value;
    }
    private void Awake()
    {
        UnityEngine.Events.UnityAction val_5;
        if(this.button_left != 0)
        {
                UnityEngine.Events.UnityAction val_2 = null;
            val_5 = val_2;
            val_2 = new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void UGUIPageDisplay::PageLeft());
            this.button_left.m_OnClick.AddListener(call:  val_2);
        }
        
        if(this.button_right != 0)
        {
                UnityEngine.Events.UnityAction val_4 = null;
            val_5 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void UGUIPageDisplay::PageRight());
            this.button_right.m_OnClick.AddListener(call:  val_4);
        }
        
        this.CreatePageDots();
    }
    public void Load(System.Collections.Generic.List<UnityEngine.GameObject> pages)
    {
        this.pages = pages.ToArray();
        this.CreatePageDots();
        goto typeof(UGUIPageDisplay).__il2cppRuntimeField_170;
    }
    private void CreatePageDots()
    {
        System.Collections.Generic.List<UnityEngine.UI.Button> val_28;
        int val_29;
        int val_30;
        int val_31;
        int val_32;
        int val_33;
        if(this.pages == null)
        {
                return;
        }
        
        if(this.pages.Length == 0)
        {
                return;
        }
        
        if(((this.numPages == 1) ? this.pages.Length : this.numPages) > this.maxPageDots)
        {
                if(this.pageNumbering != 0)
        {
                this.dotGridTransform.gameObject.SetActive(value:  false);
            this.pageNumbering.gameObject.SetActive(value:  true);
            return;
        }
        
        }
        
        this.dotGridTransform.gameObject.SetActive(value:  true);
        if((UnityEngine.Object.op_Implicit(exists:  this.pageNumbering)) != false)
        {
                this.pageNumbering.gameObject.SetActive(value:  false);
        }
        
        val_28 = this.pageDots;
        val_29 = this.numPages;
        if(val_29 == 1)
        {
                val_29 = this.pages.Length;
        }
        
        if(this.gameObject.activeSelf != false)
        {
                this.dotControlGroup.gameObject.SetActive(value:  false);
        }
        
        val_30 = 0;
        goto label_26;
        label_38:
        .<>4__this = this;
        this.pageDots.Add(item:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.pageDotPrefab, parent:  this.dotGridTransform).GetComponent<UnityEngine.UI.Button>());
        .index = val_30;
        val_13.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new UGUIPageDisplay.<>c__DisplayClass19_0(), method:  System.Void UGUIPageDisplay.<>c__DisplayClass19_0::<CreatePageDots>b__0()));
        val_30 = 1;
        label_26:
        val_31 = this.numPages;
        if(val_31 == 1)
        {
                val_31 = this.pages.Length;
        }
        
        val_28 = this.pageDots;
        if(val_30 < val_31)
        {
            goto label_38;
        }
        
        var val_28 = 0;
        label_46:
        if(val_28 >= val_31)
        {
            goto label_40;
        }
        
        if(val_31 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_31 = val_31 + 0;
        val_32 = this.numPages;
        if(val_32 == 1)
        {
                val_32 = this.pages.Length;
        }
        
        (this.pages.Length + 0) + 32.gameObject.SetActive(value:  (val_28 < val_32) ? 1 : 0);
        val_28 = val_28 + 1;
        if(this.pageDots != null)
        {
            goto label_46;
        }
        
        label_40:
        if(this.hideControlls != false)
        {
                val_33 = this.numPages;
            if(val_33 == 1)
        {
                val_33 = this.pages.Length;
        }
        
            if(val_33 == 1)
        {
                if(val_31 == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.pages.Length + 32.gameObject.SetActive(value:  false);
            if((UnityEngine.Object.op_Implicit(exists:  this.button_left)) != false)
        {
                this.button_left.gameObject.SetActive(value:  false);
        }
        
            if((UnityEngine.Object.op_Implicit(exists:  this.button_right)) != false)
        {
                this.button_right.gameObject.SetActive(value:  false);
        }
        
        }
        
        }
        
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.dotControlGroup.gameObject.activeSelf != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_27 = this.StartCoroutine(routine:  this.EnableControlsGroupAfterFrame());
    }
    private void OnEnable()
    {
        if(this.dotControlGroup.gameObject.activeSelf != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.EnableControlsGroupAfterFrame());
    }
    private System.Collections.IEnumerator EnableControlsGroupAfterFrame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UGUIPageDisplay.<EnableControlsGroupAfterFrame>d__21();
    }
    public void PageLeft()
    {
        int val_1 = this.currentPageIndex - 1;
        goto typeof(UGUIPageDisplay).__il2cppRuntimeField_170;
    }
    public void PageRight()
    {
        int val_1 = this.currentPageIndex + 1;
        goto typeof(UGUIPageDisplay).__il2cppRuntimeField_170;
    }
    public void SetToPage(int index, bool force = False)
    {
        bool val_1 = force;
        goto typeof(UGUIPageDisplay).__il2cppRuntimeField_170;
    }
    protected virtual void SetPage(int index, bool force = False)
    {
        var val_14;
        int val_15;
        int val_16;
        int val_17;
        int val_18;
        int val_19;
        var val_20;
        int val_21;
        int val_22;
        val_14 = index;
        this.CreatePageDots();
        val_15 = this.numPages;
        val_16 = val_15;
        if(val_15 == 1)
        {
                val_16 = this.pages.Length;
        }
        
        val_17 = val_14 & (~(val_14 >> 31));
        val_16 = val_16 - 1;
        if(val_17 > val_16)
        {
                val_18 = val_15;
            if(val_15 == 1)
        {
                val_18 = this.pages.Length;
        }
        
            val_17 = val_18 - 1;
        }
        
        if(this.currentPageIndex == val_17)
        {
                if(force == false)
        {
                return;
        }
        
        }
        
        if(val_15 == 1)
        {
                val_15 = this.pages.Length;
        }
        
        if((val_15 <= this.maxPageDots) || (this.pageNumbering == 0))
        {
            goto label_13;
        }
        
        val_19 = this.numPages;
        if(val_19 == 1)
        {
                val_19 = this.pages.Length;
        }
        
        string val_5 = System.String.Format(format:  "{0}/{1}", arg0:  val_17 + 1.ToString(format:  "00"), arg1:  val_19.ToString(format:  "00"));
        goto label_17;
        label_13:
        val_20 = 0;
        goto label_18;
        label_28:
        if(val_20 < this.pages.Length)
        {
                this.pages[val_20].SetActive(value:  (val_17 == val_20) ? 1 : 0);
        }
        
        if(this.pages[val_20] <= val_20)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.pages[val_20][val_20].interactable = (val_17 != val_20) ? 1 : 0;
        val_20 = 1;
        label_18:
        val_21 = this.numPages;
        if(val_21 == 1)
        {
                val_21 = this.pages.Length;
        }
        
        if(val_20 < val_21)
        {
            goto label_28;
        }
        
        label_17:
        this.currentPageIndex = val_17;
        val_14 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.button_left)) != false)
        {
                this.button_left.interactable = (this.currentPageIndex > 0) ? 1 : 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.button_right)) != false)
        {
                val_22 = this.numPages;
            if(val_22 == 1)
        {
                val_22 = this.pages.Length;
        }
        
            val_22 = val_22 - 1;
            this.button_right.interactable = (this.currentPageIndex < val_22) ? 1 : 0;
        }
        
        if(this.PageIndexChanged == null)
        {
                return;
        }
        
        this.PageIndexChanged.Invoke(obj:  this.currentPageIndex);
    }
    public UGUIPageDisplay()
    {
        this.maxPageDots = 4;
        this.refreshOnEnable = true;
        this.pageDots = new System.Collections.Generic.List<UnityEngine.UI.Button>();
        this.numPages = 0;
    }

}
