using UnityEngine;
public class CategoryPackProgressMeter : MonoBehaviour
{
    // Fields
    private const int TOTAL_METER_SUBDIVISIONS = 5;
    private UnityEngine.CanvasGroup meterCanvasGroup;
    private UnityEngine.UI.Slider progressMeter;
    private UnityEngine.UI.Text meterName;
    private UnityEngine.UI.Image goalImage;
    private UnityEngine.RectTransform nodeContainerCoinIcons;
    private UnityEngine.RectTransform nodeContainerMeterDivider;
    private UnityEngine.Sprite spriteCoin;
    private UnityEngine.Sprite spriteTick;
    private UnityEngine.Sprite spriteMeterDivider;
    private float packCompletionRateNormalized;
    private int meterSegmentsCompleted;
    private System.Collections.Generic.List<UnityEngine.UI.Image> meterCoinsList;
    private System.Collections.Generic.List<UnityEngine.UI.Image> meterTicksList;
    
    // Methods
    public void Initialize()
    {
        CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        int val_3 = val_1.GetPackProgress(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId);
        int val_4 = val_1.CurrentCategoryPackWordBank.Size;
        float val_6 = (float)val_3 / (float)val_4;
        this.packCompletionRateNormalized = val_6;
        float val_17 = 0.2f;
        val_17 = val_6 / val_17;
        this.meterSegmentsCompleted = UnityEngine.Mathf.FloorToInt(f:  val_17);
        string val_9 = System.String.Format(format:  "{0} - {1}/{2}", arg0:  val_1.<CurrentCategoryPackInfo>k__BackingField.FullTitle, arg1:  val_3, arg2:  val_4);
        var val_18 = 0;
        do
        {
            var val_10 = val_18 + 1;
            UnityEngine.RectTransform val_11 = this.meterName.CreateMeterNode(parent:  this.nodeContainerCoinIcons);
            UnityEngine.RectTransform val_12 = val_11.CreateMeterNode(parent:  this.nodeContainerMeterDivider);
            if(val_18 != 3)
        {
                UnityEngine.UI.Image val_13 = this.CreateImageCoin(parent:  val_11);
            this.meterCoinsList.Add(item:  val_13);
            if(val_10 < (val_1.GetCurrentChapterForPack(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId)))
        {
                val_13.gameObject.SetActive(value:  false);
        }
        
            UnityEngine.UI.Image val_15 = this.CreateImageDivider(parent:  val_12);
        }
        
            if(val_10 < this.meterSegmentsCompleted)
        {
                this.meterTicksList.Add(item:  this.CreateImageTick(parent:  val_12));
        }
        
            val_18 = val_18 + 1;
        }
        while(val_18 < 4);
    
    }
    public void ShowLevelCompleteAnimation(float startDelay = 0, bool isChapterComplete = False, System.Action onComplete)
    {
        System.Action val_47;
        float val_48;
        float val_49;
        float val_50;
        System.Collections.Generic.List<UnityEngine.UI.Image> val_51;
        DG.Tweening.Sequence val_52;
        DG.Tweening.TweenCallback val_53;
        val_47 = onComplete;
        val_48 = startDelay;
        CategoryPackProgressMeter.<>c__DisplayClass15_0 val_1 = new CategoryPackProgressMeter.<>c__DisplayClass15_0();
        .<>4__this = this;
        this.Initialize();
        this.meterName.gameObject.SetActive(value:  (~isChapterComplete) & 1);
        this.meterCanvasGroup.alpha = 0f;
        var val_50 = 4;
        val_49 = 1f;
        label_17:
        var val_4 = val_50 - 4;
        if(val_4 >= null)
        {
            goto label_7;
        }
        
        if(null <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if(1 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  3f, y:  3f, z:  val_49);
        mem[21474836513].transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        val_50 = val_50 + 1;
        if(this.meterTicksList != null)
        {
            goto label_17;
        }
        
        label_7:
        val_50 = this.packCompletionRateNormalized;
        .meterWaveSeq = DG.Tweening.DOTween.Sequence();
        if(this.meterSegmentsCompleted >= 1)
        {
                float val_8 = val_50 / 0.8f;
            val_8 = val_49 / val_8;
            var val_52 = 0;
            val_50 = val_8 / 5f;
            do
        {
            if(val_52 < 32493568)
        {
                if(val_52 >= 32493568)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_11 = val_52 + 1;
            val_49 = val_50 * (float)val_11;
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Insert(s:  (CategoryPackProgressMeter.<>c__DisplayClass15_0)[1152921516120999312].meterWaveSeq, atPosition:  val_49, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  176, endValue:  1f, duration:  0.001f), ease:  1));
            if(val_52 >= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + 0;
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Insert(s:  (CategoryPackProgressMeter.<>c__DisplayClass15_0)[1152921516120999312].meterWaveSeq, atPosition:  val_49, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  ((0 + 1) + 0) + 32.transform, endValue:  1f, duration:  0.3f), ease:  27));
        }
        
            if(((isChapterComplete != false) && (val_52 < val_11)) && ((val_52 + 1) == this.meterSegmentsCompleted))
        {
                val_11 = val_11 & 4294967295;
            if(val_52 >= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + 0;
            ((((0 + 1) + 0) & 4294967295) + 0) + 32.gameObject.SetActive(value:  true);
            if(val_52 >= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + 0;
            var val_22 = val_52 + 1;
            val_49 = val_50 * (float)val_22;
            DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Insert(s:  (CategoryPackProgressMeter.<>c__DisplayClass15_0)[1152921516120999312].meterWaveSeq, atPosition:  val_49, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (((((0 + 1) + 0) & 4294967295) + 0) + 0) + 32, endValue:  0f, duration:  0.25f), delay:  0.1f), ease:  20));
            if(val_52 >= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_22 = val_22 + 0;
            val_51 = this.meterCoinsList;
            if(val_52 >= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_22 = val_22 + 0;
            UnityEngine.Vector2 val_26 = (((0 + 1) + 0) + 0) + 32.rectTransform.anchoredPosition;
            float val_51 = 30f;
            val_51 = val_26.y + val_51;
            DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Insert(s:  (CategoryPackProgressMeter.<>c__DisplayClass15_0)[1152921516120999312].meterWaveSeq, atPosition:  val_49, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  ((0 + 1) + 0) + 32.rectTransform, endValue:  val_51, duration:  0.4f, snapping:  false), ease:  6));
        }
        
            val_52 = val_52 + 1;
        }
        while(val_52 < this.meterSegmentsCompleted);
        
            val_52 = (CategoryPackProgressMeter.<>c__DisplayClass15_0)[1152921516120999312].meterWaveSeq;
            val_47 = val_47;
            val_50 = val_50;
            val_48 = val_48;
        }
        
        DG.Tweening.Sequence val_30 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_52);
        DG.Tweening.Sequence val_31 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_32 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_31, interval:  val_48);
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_31, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.meterCanvasGroup, endValue:  1f, duration:  0.5f));
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_31, interval:  0.2f);
        DG.Tweening.TweenCallback val_36 = null;
        val_53 = val_36;
        val_36 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPackProgressMeter.<>c__DisplayClass15_0::<ShowLevelCompleteAnimation>b__0());
        DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_31, callback:  val_36);
        DG.Tweening.Sequence val_41 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_31, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetSpeedBased<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOValue(target:  this.progressMeter, endValue:  val_50, duration:  0.8f, snapping:  false), isSpeedBased:  true), ease:  1));
        if(this.meterSegmentsCompleted >= 5)
        {
                DG.Tweening.TweenCallback val_42 = null;
            val_53 = val_42;
            val_42 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void CategoryPackProgressMeter.<>c__DisplayClass15_0::<ShowLevelCompleteAnimation>b__1());
            DG.Tweening.Sequence val_43 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_31, callback:  val_42);
            val_49 = 1f;
            UnityEngine.Vector3 val_45 = new UnityEngine.Vector3(x:  0.25f, y:  0.25f, z:  val_49);
            DG.Tweening.Sequence val_47 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_31, t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.goalImage.transform, punch:  new UnityEngine.Vector3() {x = val_45.x, y = val_45.y, z = val_45.z}, duration:  0.3f, vibrato:  10, elasticity:  val_49));
        }
        
        if(val_47 == 0)
        {
                return;
        }
        
        DG.Tweening.Sequence val_49 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_31, action:  new DG.Tweening.TweenCallback(object:  val_47, method:  public System.Void System.Action::Invoke()));
    }
    public void Hide(float fadeOutDuration = 0)
    {
        if(fadeOutDuration > 0f)
        {
                DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.meterCanvasGroup, endValue:  0f, duration:  fadeOutDuration);
            return;
        }
        
        if(this.meterCanvasGroup != null)
        {
                this.meterCanvasGroup.alpha = 0f;
            return;
        }
        
        throw new NullReferenceException();
    }
    private UnityEngine.RectTransform CreateMeterNode(UnityEngine.Transform parent)
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "MeterNode");
        val_1.transform.SetParent(p:  parent);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        val_1.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_1.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        return val_1.AddComponent<UnityEngine.RectTransform>();
    }
    private UnityEngine.UI.Image CreateImage(string objName, UnityEngine.Transform parent, UnityEngine.Sprite sprite)
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  objName);
        val_1.transform.SetParent(p:  parent);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
        val_1.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        val_1.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.UI.Image val_7 = val_1.AddComponent<UnityEngine.UI.Image>();
        val_7.sprite = sprite;
        val_7.raycastTarget = false;
        return val_7;
    }
    private UnityEngine.UI.Image CreateImageCoin(UnityEngine.Transform parent)
    {
        UnityEngine.UI.Image val_1 = this.CreateImage(objName:  "CoinIcon", parent:  parent, sprite:  this.spriteCoin);
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        val_1.rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        val_1.rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  80f);
        val_1.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        return val_1;
    }
    private UnityEngine.UI.Image CreateImageTick(UnityEngine.Transform parent)
    {
        UnityEngine.UI.Image val_1 = this.CreateImage(objName:  "TickIcon", parent:  parent, sprite:  this.spriteTick);
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        val_1.rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        val_1.rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.zero;
        val_1.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        return val_1;
    }
    private UnityEngine.UI.Image CreateImageDivider(UnityEngine.Transform parent)
    {
        UnityEngine.UI.Image val_1 = this.CreateImage(objName:  "Divider", parent:  parent, sprite:  this.spriteMeterDivider);
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  1f, y:  0f);
        val_1.rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.one;
        val_1.rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        UnityEngine.Rect val_7 = val_1.m_Sprite.rect;
        UnityEngine.Vector2 val_8 = val_7.m_XMin.size;
        val_8.x = val_8.x * (-0.5f);
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_8.x, y:  0f);
        val_1.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        UnityEngine.Rect val_11 = val_1.m_Sprite.rect;
        UnityEngine.Vector2 val_12 = val_11.m_XMin.size;
        val_12.x = val_12.x * 0.5f;
        UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  val_12.x, y:  0f);
        val_1.rectTransform.offsetMax = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
        return val_1;
    }
    public CategoryPackProgressMeter()
    {
        this.meterCoinsList = new System.Collections.Generic.List<UnityEngine.UI.Image>();
        this.meterTicksList = new System.Collections.Generic.List<UnityEngine.UI.Image>();
    }

}
