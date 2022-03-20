using UnityEngine;
public class CategoryPacksScreenMain : MonoSingleton<CategoryPacksScreenMain>
{
    // Fields
    private UnityEngine.RectTransform headerInfoGroupObj;
    private UnityEngine.GameObject completionMeterObject;
    private UnityEngine.UI.Slider completionMeterSlider;
    private UnityEngine.UI.Text completionMeterLabel;
    private UnityEngine.CanvasGroup completionMeterRewardObject;
    private UnityEngine.ParticleSystem rewardParticle;
    private UnityEngine.UI.LoopScrollRect packsScrollRect;
    private CategoryPackButton categoryPackPrefab;
    private UnityEngine.RectTransform packContainer;
    private UnityEngine.UI.Text subtitle;
    private UnityEngine.UI.Button buttonExit;
    public const int RESERVED_SCROLL_ID_FOR_HEADER_DISPLAY = 0;
    public const int INITIAL_SCROLL_ID_FOR_CONTENT = 2;
    private int currentHeaderParentId;
    private System.Collections.Generic.List<CategoryPackInfo> sortedPackData;
    
    // Properties
    public UnityEngine.RectTransform HeaderInfoDisplayGroup { get; }
    public System.Collections.Generic.List<CategoryPackInfo> SortedPackData { get; }
    
    // Methods
    public UnityEngine.RectTransform get_HeaderInfoDisplayGroup()
    {
        return (UnityEngine.RectTransform)this.headerInfoGroupObj;
    }
    public System.Collections.Generic.List<CategoryPackInfo> get_SortedPackData()
    {
        return (System.Collections.Generic.List<CategoryPackInfo>)this.sortedPackData;
    }
    private void Start()
    {
        this.buttonExit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void CategoryPacksScreenMain::CloseWindow()));
        this.Initialize();
        System.Collections.Generic.List<CategoryPackInfo> val_3 = this.sortedPackData;
        val_3 = val_3 + 2;
        this.packsScrollRect.totalCount = val_3;
        this.packsScrollRect.RefillCells(offset:  0);
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void CategoryPacksScreenMain::ResolveQueuedActions()), count:  1);
    }
    private void OnDestroy()
    {
        if(this.buttonExit == 0)
        {
                return;
        }
        
        this.buttonExit.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void CategoryPacksScreenMain::CloseWindow()));
    }
    private void Initialize()
    {
        this.sortedPackData = this.SortPacks();
        GameEcon val_3 = App.getGameEcon;
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "category_list_pack", defaultValue:  "{0} Levels in each Pack", useSingularKey:  false), arg0:  val_3.categoryShowLevelsDisplay);
        string val_9 = System.String.Format(format:  "{0}/{1}", arg0:  MonoSingleton<CategoryPacksManager>.Instance.RewardCurrentPacks, arg1:  MonoSingleton<CategoryPacksManager>.Instance.RewardTargetPacks);
        float val_14 = (float)MonoSingleton<CategoryPacksManager>.Instance.RewardCurrentPacks;
        val_14 = val_14 / ((float)MonoSingleton<CategoryPacksManager>.Instance.RewardTargetPacks);
    }
    private CategoryPackButton GetPackButtonFromId(int packIdToFind)
    {
        var val_5;
        T[] val_1 = this.packsScrollRect.m_Content.GetComponentsInChildren<CategoryPackButton>();
        if(val_1 == null)
        {
                return (CategoryPackButton)null;
        }
        
        int val_4 = val_1.Length;
        if(val_4 >= 1)
        {
                var val_5 = 0;
            val_4 = val_4 & 4294967295;
            do
        {
            if(1152921506204592464 != 0)
        {
                if(1152921506204592464.PackId == packIdToFind)
        {
            goto label_11;
        }
        
        }
        
            val_5 = val_5 + 1;
        }
        while(val_5 < (val_1.Length << ));
        
        }
        
        val_5 = 0;
        return (CategoryPackButton)null;
        label_11:
        return (CategoryPackButton)null;
    }
    private System.Collections.Generic.List<CategoryPackInfo> SortPacks()
    {
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        CategoryPackInfo val_22;
        System.Collections.Generic.IComparer<T> val_23;
        System.Collections.Generic.List<T> val_24;
        .categoryPacksManager = MonoSingleton<CategoryPacksManager>.Instance;
        val_16 = null;
        val_16 = null;
        System.Collections.Generic.List<CategoryPackInfo> val_3 = new System.Collections.Generic.List<CategoryPackInfo>();
        System.Collections.Generic.List<CategoryPackInfo> val_5 = null;
        val_17 = val_5;
        val_5 = new System.Collections.Generic.List<CategoryPackInfo>();
        System.Collections.Generic.List<CategoryPackInfo> val_7 = new System.Collections.Generic.List<CategoryPackInfo>();
        System.Collections.Generic.List<CategoryPackInfo> val_8 = new System.Collections.Generic.List<CategoryPackInfo>();
        if((CategoryPackData.packList + 24) < 1)
        {
            goto label_7;
        }
        
        var val_24 = 0;
        label_44:
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_16 = CategoryPackData.packList + 16;
        val_16 = val_16 + 0;
        val_18 = (CategoryPacksScreenMain.<>c__DisplayClass23_0)[1152921516138131824].categoryPacksManager;
        if((val_18.IsPackCompleted(packId:  (CategoryPackData.packList + 16 + 0) + 32 + 16)) == false)
        {
            goto label_11;
        }
        
        if((CategoryPackData.packList + 24) <= val_24)
        {
                val_18 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_17 = CategoryPackData.packList + 16;
        val_17 = val_17 + 0;
        if(((CategoryPackData.packList + 16 + 0) + 32 + 16) != val_18.PackNewlyCompleted)
        {
            goto label_27;
        }
        
        label_11:
        if((CategoryPackData.packList + 24) <= val_24)
        {
                val_18 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_18 = CategoryPackData.packList + 16;
        val_18 = val_18 + 0;
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_19 = CategoryPackData.packList + 16;
        val_19 = val_19 + 0;
        val_19 = mem[(CategoryPackData.packList + 16 + 0) + 32];
        val_19 = (CategoryPackData.packList + 16 + 0) + 32;
        if((val_18.IsPackOwned(packId:  (CategoryPackData.packList + 16 + 0) + 32 + 16)) == false)
        {
            goto label_20;
        }
        
        val_20 = 1152921516119965424;
        goto label_42;
        label_20:
        if(((CategoryPackData.packList + 16 + 0) + 32 + 40) == 0)
        {
            goto label_24;
        }
        
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_20 = CategoryPackData.packList + 16;
            val_20 = val_20 + 0;
            val_21 = mem[(CategoryPackData.packList + 16 + 0) + 32];
            val_21 = (CategoryPackData.packList + 16 + 0) + 32;
        }
        
        if(val_21.IsAvailable == false)
        {
            goto label_27;
        }
        
        label_24:
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_21 = CategoryPackData.packList + 16;
        val_21 = val_21 + 0;
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_22 = CategoryPackData.packList + 16;
        val_22 = val_22 + 0;
        val_22 = mem[(CategoryPackData.packList + 16 + 0) + 32];
        val_22 = (CategoryPackData.packList + 16 + 0) + 32;
        if((CategoryPackData.packList + 24) <= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_23 = CategoryPackData.packList + 16;
            val_23 = val_23 + 0;
            val_22 = mem[(CategoryPackData.packList + 16 + 0) + 32];
            val_22 = (CategoryPackData.packList + 16 + 0) + 32;
        }
        
        if(((CategoryPacksScreenMain.<>c__DisplayClass23_0)[1152921516138131824].categoryPacksManager.IsPackNewlyDiscovered(packId:  (CategoryPackData.packList + 16 + 0) + 32 + 16)) == false)
        {
            goto label_34;
        }
        
        if(((CategoryPackData.packList + 16 + 0) + 32 + 40) == 0)
        {
            goto label_35;
        }
        
        val_20 = 1152921516119965424;
        goto label_42;
        label_34:
        if(((CategoryPackData.packList + 16 + 0) + 32 + 40) == 0)
        {
            goto label_38;
        }
        
        if(val_7 != 0)
        {
            goto label_39;
        }
        
        label_35:
        val_20 = 1152921516119965424;
        goto label_42;
        label_38:
        label_39:
        val_20 = 1152921516119965424;
        label_42:
        val_8.Add(item:  val_22);
        label_27:
        val_24 = val_24 + 1;
        if(val_24 < (CategoryPackData.packList + 24))
        {
            goto label_44;
        }
        
        label_7:
        new System.Collections.Generic.List<CategoryPackInfo>().Sort(comparison:  new System.Comparison<CategoryPackInfo>(object:  new CategoryPacksScreenMain.<>c__DisplayClass23_0(), method:  System.Int32 CategoryPacksScreenMain.<>c__DisplayClass23_0::<SortPacks>b__0(CategoryPackInfo a, CategoryPackInfo b)));
        LockedCategoryPacksComparer val_15 = null;
        val_23 = val_15;
        val_15 = new LockedCategoryPacksComparer();
        val_24 = val_7;
        val_5.Sort(comparer:  val_15);
        new System.Collections.Generic.List<CategoryPackInfo>().Sort(comparer:  val_15);
        val_7.Sort(comparer:  val_15);
        val_8.Sort(comparer:  val_15);
        if(1152921504911585280 >= 1)
        {
                val_23 = 1152921516119965424;
            var val_25 = 0;
            do
        {
            if(val_25 >= 1152921504911585280)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.Add(item:  static System.Void UnityEngine.Texture2D::Internal_Create(UnityEngine.Texture2D mono, int w, int h, int mipCount, UnityEngine.Experimental.Rendering.GraphicsFormat format, UnityEngine.Experimental.Rendering.TextureCreationFlags flags, IntPtr nativeTex));
            val_25 = val_25 + 1;
        }
        while(val_25 < 44460936);
        
        }
        
        if(44460936 >= 1)
        {
                var val_26 = 0;
            do
        {
            if(val_26 >= 44460936)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.Add(item:  static System.Void UnityEngine.Texture2D::Internal_Create(UnityEngine.Texture2D mono, int w, int h, int mipCount, UnityEngine.Experimental.Rendering.GraphicsFormat format, UnityEngine.Experimental.Rendering.TextureCreationFlags flags, IntPtr nativeTex));
            val_26 = val_26 + 1;
        }
        while(val_26 < 44460936);
        
        }
        
        if(44460936 >= 1)
        {
                val_17 = 1152921516119965424;
            var val_27 = 0;
            do
        {
            if(val_27 >= 44460936)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3.Add(item:  static System.Void UnityEngine.Texture2D::Internal_Create(UnityEngine.Texture2D mono, int w, int h, int mipCount, UnityEngine.Experimental.Rendering.GraphicsFormat format, UnityEngine.Experimental.Rendering.TextureCreationFlags flags, IntPtr nativeTex));
            val_27 = val_27 + 1;
        }
        while(val_27 < 44460936);
        
        }
        
        if(mem[1152921516138156424] >= 1)
        {
                var val_29 = 0;
            do
        {
            if(val_29 >= mem[1152921516138156424])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_28 = mem[1152921516138156416];
            val_28 = val_28 + 0;
            val_3.Add(item:  (mem[1152921516138156416] + 0) + 32);
            val_29 = val_29 + 1;
        }
        while(val_29 < mem[1152921516138156424]);
        
        }
        
        if(mem[1152921516138160520] < 1)
        {
                return val_3;
        }
        
        val_24 = 1152921516119965424;
        var val_31 = 0;
        do
        {
            if(val_31 >= mem[1152921516138160520])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_30 = mem[1152921516138160512];
            val_30 = val_30 + 0;
            val_3.Add(item:  (mem[1152921516138160512] + 0) + 32);
            val_31 = val_31 + 1;
        }
        while(val_31 < mem[1152921516138160520]);
        
        return val_3;
    }
    private void ResolveQueuedActions()
    {
        if(((MonoSingleton<CategoryPacksManager>.Instance.PackNewlyCompleted) & 2147483648) != 0)
        {
                return;
        }
        
        CategoryPackButton val_5 = this.GetPackButtonFromId(packIdToFind:  MonoSingleton<CategoryPacksManager>.Instance.PackNewlyCompleted);
        if(val_5 == 0)
        {
                return;
        }
        
        int val_8 = MonoSingleton<CategoryPacksManager>.Instance.RewardCurrentPacks;
        CategoryCompletionReward val_12 = MonoSingleton<CategoryPacksManager>.Instance.ResolveNewlyCompletedPack();
        if(val_12 != null)
        {
                MonoSingleton<CategoryPacksManager>.Instance.CreditGoalReward(chosenReward:  val_12);
        }
        
        this.DoPackCompleteAnimation(packButton:  val_5, goalValueStart:  0, goalValueEnd:  MonoSingleton<CategoryPacksManager>.Instance.RewardCurrentPacks, goalTargetStart:  MonoSingleton<CategoryPacksManager>.Instance.RewardTargetPacks, goalTargetEnd:  MonoSingleton<CategoryPacksManager>.Instance.RewardTargetPacks, goalRewardData:  val_12);
    }
    private void DoPackCompleteAnimation(CategoryPackButton packButton, int goalValueStart, int goalValueEnd, int goalTargetStart, int goalTargetEnd, CategoryCompletionReward goalRewardData)
    {
        float val_88;
        var val_89;
        float val_90;
        CategoryPacksScreenMain.<>c__DisplayClass25_0 val_1 = new CategoryPacksScreenMain.<>c__DisplayClass25_0();
        .<>4__this = this;
        .rewardData = goalRewardData;
        .isGoalMeterCompleted = (goalRewardData != 0) ? 1 : 0;
        .rewardLabelFinishValue1 = (goalRewardData != 0) ? goalTargetStart : goalValueEnd;
        .rewardLabelFinishValue2 = goalTargetStart;
        if(goalRewardData == null)
        {
            goto label_2;
        }
        
        val_88 = 1f;
        if(packButton != null)
        {
            goto label_3;
        }
        
        label_2:
        val_88 = (float)goalValueEnd / (float)goalTargetEnd;
        label_3:
        UnityEngine.UI.Image val_5 = UnityEngine.Object.Instantiate<UnityEngine.UI.Image>(original:  packButton.badgeCompleted, parent:  packButton.badgeCompleted.transform);
        .completedBadge = val_5;
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
        val_5.transform.localPosition = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        UnityEngine.UI.Text val_9 = UnityEngine.Object.Instantiate<UnityEngine.UI.Text>(original:  this.completionMeterLabel, parent:  this.completionMeterLabel.transform);
        .meterLabelDummy = val_9;
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.zero;
        val_9.transform.localPosition = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
        UnityEngine.Color val_13 = UnityEngine.Color.clear;
        System.Nullable<UnityEngine.Color> val_14 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_13.r, g = val_13.g, b = val_13.b, a = val_13.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        val_89 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
        val_89 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
        val_89 = mem[public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302];
        val_89 = public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 302;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  public static T[] System.Array::Empty<UnityEngine.Transform>().__il2cppRuntimeField_30 + 184);
        DG.Tweening.Sequence val_17 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_17, interval:  0.3f);
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_17, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPacksScreenMain.<>c__DisplayClass25_0::<DoPackCompleteAnimation>b__0()));
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_17, interval:  1f);
        UnityEngine.Vector3 val_24 = this.completionMeterRewardObject.transform.position;
        DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  (CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].completedBadge.transform, endValue:  new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z}, duration:  0.5f, snapping:  false));
        DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].completedBadge.transform, endValue:  0.2f, duration:  0.5f), ease:  1));
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].completedBadge, endValue:  0f, duration:  0.2f), delay:  0.3f), ease:  1));
        val_90 = 1f;
        UnityEngine.Vector3 val_36 = new UnityEngine.Vector3(x:  0.25f, y:  0.25f, z:  val_90);
        DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.OnStart<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.completionMeterRewardObject.transform, punch:  new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z}, duration:  0.35f, vibrato:  1, elasticity:  val_90), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPacksScreenMain.<>c__DisplayClass25_0::<DoPackCompleteAnimation>b__1())));
        DG.Tweening.Sequence val_42 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.ShortcutExtensions46.DOValue(target:  this.completionMeterSlider, endValue:  val_88, duration:  0.5f, snapping:  false));
        DG.Tweening.Sequence val_46 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].meterLabelDummy.transform, endValue:  2f, duration:  0.25f), ease:  1));
        DG.Tweening.Sequence val_50 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].meterLabelDummy, endValue:  0f, duration:  0.15f), delay:  0.075f), ease:  1));
        DG.Tweening.Sequence val_53 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_17, t:  DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPacksScreenMain.<>c__DisplayClass25_0::<DoPackCompleteAnimation>b__2()), ignoreTimeScale:  true));
        UnityEngine.Vector3 val_55 = this.completionMeterRewardObject.transform.position;
        .rewardIconOriPos = val_55;
        mem[1152921516138887332] = val_55.y;
        mem[1152921516138887336] = val_55.z;
        if(((CategoryPacksScreenMain.<>c__DisplayClass25_0)[1152921516138887280].isGoalMeterCompleted) != false)
        {
                UnityEngine.Vector3 val_57 = this.completionMeterRewardObject.transform.position;
            .rewardIconOriPos = val_57;
            mem[1152921516138887332] = val_57.y;
            mem[1152921516138887336] = val_57.z;
            UnityEngine.Vector3 val_60 = MonoSingleton<GameMaskOverlay>.Instance.TransformPositionToOverlaySpace(objectTransform:  this.packsScrollRect.transform);
            val_90 = val_60.x;
            UnityEngine.Vector3 val_62 = this.completionMeterRewardObject.transform.position;
            DG.Tweening.Sequence val_66 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.completionMeterRewardObject.transform, endValue:  new UnityEngine.Vector3() {x = val_90, y = val_60.y, z = val_62.z}, duration:  0.85f, snapping:  false), ease:  1));
            UnityEngine.Vector3 val_68 = new UnityEngine.Vector3(x:  3.5f, y:  3.5f, z:  1f);
            DG.Tweening.Sequence val_71 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.completionMeterRewardObject.transform, endValue:  new UnityEngine.Vector3() {x = val_68.x, y = val_68.y, z = val_68.z}, duration:  0.85f), ease:  1));
            DG.Tweening.Sequence val_72 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_17, interval:  0.1f);
            UnityEngine.Vector3 val_74 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  10f);
            DG.Tweening.Sequence val_76 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.completionMeterRewardObject.transform, duration:  1f, strength:  new UnityEngine.Vector3() {x = val_74.x, y = val_74.y, z = val_74.z}, vibrato:  40, randomness:  90f, fadeOut:  false));
            UnityEngine.Vector3 val_78 = new UnityEngine.Vector3(x:  4.5f, y:  4.5f, z:  1f);
            DG.Tweening.Sequence val_81 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.completionMeterRewardObject.transform, endValue:  new UnityEngine.Vector3() {x = val_78.x, y = val_78.y, z = val_78.z}, duration:  0.1f), ease:  15));
            DG.Tweening.Sequence val_84 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_17, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.completionMeterRewardObject, endValue:  0f, duration:  0.1f), ease:  1));
        }
        
        DG.Tweening.Sequence val_86 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_17, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPacksScreenMain.<>c__DisplayClass25_0::<DoPackCompleteAnimation>b__3()));
    }
    public void OnScrollFocusChanged(int currScrollFocalIndex, UnityEngine.Transform currScrollFocalTransform)
    {
        int val_10 = currScrollFocalIndex;
        if(val_10 != 0)
        {
                if(currScrollFocalTransform.GetInstanceID() != this.currentHeaderParentId)
        {
                return;
        }
        
            this.headerInfoGroupObj.SetParent(p:  this.packsScrollRect.transform);
            this.headerInfoGroupObj.gameObject.SetActive(value:  false);
            this.currentHeaderParentId = 0;
            return;
        }
        
        this.headerInfoGroupObj.SetParent(p:  currScrollFocalTransform);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        this.headerInfoGroupObj.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        this.headerInfoGroupObj.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  1f);
        this.headerInfoGroupObj.anchorMax = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        this.headerInfoGroupObj.anchorMin = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        this.headerInfoGroupObj.pivot = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        val_10 = this.headerInfoGroupObj;
        UnityEngine.Vector2 val_7 = UnityEngine.Vector2.zero;
        val_10.anchoredPosition = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        this.headerInfoGroupObj.gameObject.SetActive(value:  true);
        this.currentHeaderParentId = currScrollFocalTransform.GetInstanceID();
    }
    public void CloseWindow()
    {
        CategoryPacksMenuUI.Exit();
    }
    public void CloseWindow(bool rememberScrollAmt)
    {
        CategoryPacksMenuUI.Exit();
    }
    public CategoryPacksScreenMain()
    {
        this.currentHeaderParentId = 0;
    }

}
