using UnityEngine;
public class CategoryPackButton : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.UI.Text packTitleLabel;
    private UnityEngine.UI.Image packTitleBackground;
    private UnityEngine.GameObject completionMeterObject;
    private UnityEngine.UI.Slider completionMeterSlider;
    private UnityEngine.UI.Text completionMeterLabel;
    private UnityEngine.UI.Text unlockCostLabel;
    private UnityEngine.UI.Button buttonPack;
    private UnityEngine.GameObject badgeNew;
    private UnityEngine.UI.Image badgeCompleted;
    private UnityEngine.GameObject groupStateLocked;
    private UnityEngine.GameObject groupStateUnlocked;
    private UnityEngine.GameObject groupStateCompleted;
    private UnityEngine.GameObject timerObject;
    private UnityEngine.UI.Text timerLabel;
    private CategoryPackInfo packData;
    
    // Properties
    public int PackId { get; }
    public UnityEngine.UI.Image BadgeCompleted { get; }
    
    // Methods
    public int get_PackId()
    {
        if(this.packData == null)
        {
                return 0;
        }
        
        return (int)this.packData.packId;
    }
    public UnityEngine.UI.Image get_BadgeCompleted()
    {
        return (UnityEngine.UI.Image)this.badgeCompleted;
    }
    private void Awake()
    {
        this.buttonPack.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void CategoryPackButton::OnClicked()));
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(child:  this);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void CategoryPackButton::UpdateLogic());
    }
    private void Start()
    {
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPackPurchaseComplete, b:  new System.Action<System.Boolean, System.Int32>(object:  this, method:  System.Void CategoryPackButton::OnPackPurchaseComplete(bool isSuccess, int packPurchased)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnPackPurchaseComplete = val_3;
        return;
        label_5:
    }
    private void OnDestroy()
    {
        if((MonoSingleton<CategoryPacksManager>.Instance) == 0)
        {
                return;
        }
        
        CategoryPacksManager val_3 = MonoSingleton<CategoryPacksManager>.Instance;
        1152921504893161472 = val_3.OnPackPurchaseComplete;
        string val_4 = "{}[],:\"";
        val_4 = new System.Action<System.Boolean, System.Int32>(object:  this, method:  System.Void CategoryPackButton::OnPackPurchaseComplete(bool isSuccess, int packPurchased));
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  val_4);
        if(val_5 != null)
        {
                if(null != ("{}[],:\""))
        {
            goto label_10;
        }
        
        }
        
        val_3.OnPackPurchaseComplete = val_5;
        return;
        label_10:
    }
    public void Initialize(CategoryPackInfo data)
    {
        this.packData = data;
        this.RefreshUI();
    }
    private void ScrollCellIndex(int index)
    {
        int val_5 = index;
        CategoryPacksScreenMain val_1 = MonoSingleton<CategoryPacksScreenMain>.Instance;
        if(val_1.sortedPackData == null)
        {
                return;
        }
        
        MonoSingleton<CategoryPacksScreenMain>.Instance.OnScrollFocusChanged(currScrollFocalIndex:  val_5, currScrollFocalTransform:  this.transform);
        if(val_5 > 1)
        {
                this.canvasGroup.blocksRaycasts = true;
            this.canvasGroup.interactable = true;
            this.canvasGroup.alpha = 1f;
            CategoryPacksScreenMain val_4 = MonoSingleton<CategoryPacksScreenMain>.Instance;
            val_5 = val_5 - 2;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.packData = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + ((index - 2)) << 3) + 32;
            this.RefreshUI();
            return;
        }
        
        this.canvasGroup.blocksRaycasts = false;
        this.canvasGroup.interactable = false;
        this.canvasGroup.alpha = 0f;
    }
    private void OnPackPurchaseComplete(bool isSuccess, int packPurchased)
    {
        if(this.packData == null)
        {
                return;
        }
        
        if(isSuccess == false)
        {
                return;
        }
        
        if(this.packData.packId != packPurchased)
        {
                return;
        }
        
        this.RefreshUI();
    }
    public void RefreshUI()
    {
        bool val_15;
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        string val_2 = this.packData.FullTitle;
        if((val_1.IsPackCompleted(packId:  this.packData.packId)) != false)
        {
                CategoryColor val_4 = val_1.GetColor(colorCode:  this.packData.color);
            this.packTitleBackground.color = new UnityEngine.Color() {r = val_4.colorValue};
            this.groupStateLocked.SetActive(value:  false);
            this.groupStateUnlocked.SetActive(value:  false);
            val_15 = 1;
        }
        else
        {
                if((val_1.IsPackOwned(packId:  this.packData.packId)) != false)
        {
                CategoryColor val_6 = val_1.GetColor(colorCode:  this.packData.color);
            this.packTitleBackground.color = new UnityEngine.Color() {r = val_6.colorValue};
            int val_7 = val_1.GetPackProgress(packId:  this.packData.packId);
            int val_9 = val_1.GetWordBank(packId:  this.packData.packId).Size;
            float val_15 = (float)val_7;
            val_15 = val_15 / (float)val_9;
            string val_10 = System.String.Format(format:  "{0}/{1}", arg0:  val_7, arg1:  val_9);
            this.groupStateLocked.SetActive(value:  false);
            this.groupStateUnlocked.SetActive(value:  true);
            val_15 = 0;
        }
        else
        {
                CategoryColor val_11 = val_1.GetColor(colorCode:  0);
            this.packTitleBackground.color = new UnityEngine.Color() {r = val_11.colorValue};
            decimal val_12 = val_1.GetPackUnlockCost(packId:  this.packData.packId);
            string val_13 = val_12.flags.ToString();
            this.groupStateLocked.SetActive(value:  true);
            this.groupStateUnlocked.SetActive(value:  false);
            this.groupStateCompleted.SetActive(value:  false);
            val_15 = this.packData.timeLimited;
        }
        
        }
        
        this.timerObject.SetActive(value:  val_15);
        int val_16 = this.packData.packId;
        val_16 = val_1.IsPackNewlyDiscovered(packId:  val_16);
        this.badgeNew.SetActive(value:  val_16);
        val_1.SetPackDiscovered(packId:  this.packData.packId);
    }
    private void OnClicked()
    {
        if((MonoSingleton<CategoryPacksManager>.Instance.IsPackCompleted(packId:  this.packData.packId)) != false)
        {
                return;
        }
        
        if((MonoSingleton<CategoryPacksManager>.Instance.IsPackOwned(packId:  this.packData.packId)) != false)
        {
                MonoSingleton<CategoryPacksManager>.Instance.OpenAndPlayPack(packId:  this.packData.packId);
            return;
        }
        
        if(this.packData.timeLimited != false)
        {
                if(this.packData.IsAvailable == false)
        {
                return;
        }
        
        }
        
        MonoSingleton<CategoriesWindowManager>.Instance.ShowUGUIMonolith<CategoryPackPurchasePopup>(showNext:  false).Show(packId:  this.packData.packId);
    }
    private void UpdateLogic()
    {
        UnityEngine.UI.Text val_12;
        var val_13;
        val_12 = this;
        if(this.packData == null)
        {
                return;
        }
        
        if(this.packData.timeLimited == false)
        {
                return;
        }
        
        System.DateTime val_1 = this.packData.availableDate.AddDays(value:  (double)this.packData.availableDuration);
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        if((val_3._ticks & 9223372036854775808) != 0)
        {
                val_13 = null;
            val_13 = null;
        }
        
        object[] val_4 = new object[4];
        val_4[0] = System.TimeSpan.Zero.Days;
        val_4[1] = System.TimeSpan.Zero.Hours;
        val_4[2] = System.TimeSpan.Zero.Minutes;
        val_4[3] = System.TimeSpan.Zero.Seconds;
        val_12 = this.timerLabel;
        string val_11 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "ends_upper", defaultValue:  "ENDS", useSingularKey:  false), arg1:  System.String.Format(format:  "{0:D2}:{1:D2}:{2:D2}:{3:D2}", args:  val_4));
    }
    public CategoryPackButton()
    {
    
    }

}
