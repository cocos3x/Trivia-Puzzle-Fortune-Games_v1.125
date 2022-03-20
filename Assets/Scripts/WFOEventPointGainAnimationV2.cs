using UnityEngine;
public class WFOEventPointGainAnimationV2 : MonoBehaviour
{
    // Fields
    public static bool IsActive;
    private EventButtonPanel eventButtonPanel;
    private UnityEngine.Sprite iconAttackMadness;
    private UnityEngine.Sprite iconRaidMadness;
    private UnityEngine.Sprite iconIslandParadise;
    private UnityEngine.UI.Image largePointImage;
    private UnityEngine.UI.Image prefabPointImage;
    private UnityEngine.Transform symbolPrefab;
    private UnityEngine.Transform symbolParent;
    private UnityEngine.Transform centralSymbolTransform;
    private UnityEngine.GameObject glow;
    private UnityEngine.UI.Text symbolCountText;
    private DG.Tweening.Ease easeX;
    private UnityEngine.AnimationCurve curveY;
    private float duration;
    private float symbolInterval;
    private float symbolScale;
    private int currentPoints;
    private int pendingPoints;
    private WFOEventPointType eventPointType;
    private WGEventButtonV2 progress;
    private UnityEngine.Transform target;
    private UnityEngine.Vector3 originalCentralSymbolPos;
    private System.Action onComplete;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Vector3 val_1 = this.centralSymbolTransform.position;
        this.originalCentralSymbolPos = val_1;
        mem[1152921517422686172] = val_1.y;
        mem[1152921517422686176] = val_1.z;
    }
    private void OnDisable()
    {
        WFOEventPointGainAnimationV2.IsActive = false;
    }
    private void OnEnable()
    {
        WFOEventPointGainAnimationV2.IsActive = true;
        this.ResetUI();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.PointGainAnimation());
    }
    public void Setup(WFOEventPointType type, int points, int initialPoints, System.Action _onComplete)
    {
        this.pendingPoints = points;
        this.eventPointType = type;
        this.currentPoints = initialPoints;
        this.onComplete = _onComplete;
        WordRegion.instance.AddLevelCompleteBlocker(blocker:  3);
    }
    private void SetupEventIcons()
    {
        UnityEngine.Sprite val_1;
        if(this.eventPointType == 2)
        {
            goto label_0;
        }
        
        if(this.eventPointType == 1)
        {
            goto label_1;
        }
        
        if(this.eventPointType != 0)
        {
                return;
        }
        
        this.largePointImage.sprite = this.iconAttackMadness;
        val_1 = this.iconAttackMadness;
        goto label_8;
        label_1:
        this.largePointImage.sprite = this.iconRaidMadness;
        val_1 = this.iconRaidMadness;
        goto label_8;
        label_0:
        this.largePointImage.sprite = this.iconIslandParadise;
        val_1 = this.iconIslandParadise;
        label_8:
        this.prefabPointImage.sprite = val_1;
    }
    private void SetupEventProgress()
    {
        string val_5;
        if(this.eventPointType <= 2)
        {
                val_5 = mem[39724800 + (this.eventPointType) << 3];
            val_5 = 39724800 + (this.eventPointType) << 3;
        }
        else
        {
                val_5 = "";
        }
        
        this.progress = this.eventButtonPanel.GetEventButton(eventId:  val_5);
        string val_2 = this.currentPoints.ToString();
        if(this.progress.efxUpdate == 0)
        {
                return;
        }
        
        this.progress.efxUpdate.gameObject.SetActive(value:  true);
    }
    private System.Collections.IEnumerator PointGainAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WFOEventPointGainAnimationV2.<PointGainAnimation>d__30();
    }
    private void Play(int symbolCount)
    {
        var val_23;
        DG.Tweening.TweenCallback val_25;
        .<>4__this = this;
        .symbolCount = symbolCount;
        this.SetupEventIcons();
        this.SetupEventProgress();
        string val_2 = "+"("+") + (WFOEventPointGainAnimationV2.<>c__DisplayClass31_0)[1152921517423856304].symbolCount((WFOEventPointGainAnimationV2.<>c__DisplayClass31_0)[1152921517423856304].symbolCount);
        string val_3 = this.currentPoints.ToString();
        this.target = this.progress.icon.transform;
        DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
        val_23 = null;
        val_23 = null;
        val_25 = WFOEventPointGainAnimationV2.<>c.<>9__31_0;
        if(val_25 == null)
        {
                DG.Tweening.TweenCallback val_6 = null;
            val_25 = val_6;
            val_6 = new DG.Tweening.TweenCallback(object:  WFOEventPointGainAnimationV2.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOEventPointGainAnimationV2.<>c::<Play>b__31_0());
            WFOEventPointGainAnimationV2.<>c.<>9__31_0 = val_25;
        }
        
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_5, callback:  val_6);
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, d:  this.symbolScale);
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.centralSymbolTransform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  1f));
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.one;
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_5, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.symbolCountText.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  1f));
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_5, interval:  0.5f);
        UnityEngine.Vector3 val_18 = UnityEngine.Vector3.zero;
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_5, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.glow.transform, endValue:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, duration:  0.5f));
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_5, action:  new DG.Tweening.TweenCallback(object:  new WFOEventPointGainAnimationV2.<>c__DisplayClass31_0(), method:  System.Void WFOEventPointGainAnimationV2.<>c__DisplayClass31_0::<Play>b__1()));
    }
    private void TweenText(int count)
    {
        WFOEventPointGainAnimationV2.<>c__DisplayClass32_0 val_1 = new WFOEventPointGainAnimationV2.<>c__DisplayClass32_0();
        .<>4__this = this;
        .count = count;
        if(count < 1)
        {
                return;
        }
        
        .pointProgress = (float)this.currentPoints;
        DG.Tweening.Sequence val_4 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_4, interval:  this.duration);
        int val_14 = this.currentPoints;
        val_14 = ((WFOEventPointGainAnimationV2.<>c__DisplayClass32_0)[1152921517424127024].count) + val_14;
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void WFOEventPointGainAnimationV2.<>c__DisplayClass32_0::<TweenText>b__0(float x)), startValue:  (float)val_14, endValue:  (float)val_14, duration:  this.symbolInterval * ((float)UnityEngine.Mathf.Min(a:  10, b:  count))), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointGainAnimationV2.<>c__DisplayClass32_0::<TweenText>b__1())), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOEventPointGainAnimationV2.<>c__DisplayClass32_0::<TweenText>b__2())));
    }
    private System.Collections.IEnumerator AutoGenerateSymbols(int count)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .count = count;
        return (System.Collections.IEnumerator)new WFOEventPointGainAnimationV2.<AutoGenerateSymbols>d__33();
    }
    private DG.Tweening.Sequence MoveSymbol(float scale, UnityEngine.Transform trans, UnityEngine.Transform dest, bool destroy = True)
    {
        .trans = trans;
        .<>4__this = this;
        .destroy = destroy;
        DG.Tweening.Sequence val_3 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_4 = dest.position;
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_3, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  (WFOEventPointGainAnimationV2.<>c__DisplayClass34_0)[1152921517424492336].trans, endValue:  val_4.x, duration:  this.duration, snapping:  false), ease:  this.easeX));
        UnityEngine.Vector3 val_8 = dest.position;
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_3, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  (WFOEventPointGainAnimationV2.<>c__DisplayClass34_0)[1152921517424492336].trans, endValue:  val_8.y, duration:  this.duration, snapping:  false), animCurve:  this.curveY));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_3, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (WFOEventPointGainAnimationV2.<>c__DisplayClass34_0)[1152921517424492336].trans, endValue:  scale, duration:  this.duration));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_3, callback:  new DG.Tweening.TweenCallback(object:  new WFOEventPointGainAnimationV2.<>c__DisplayClass34_0(), method:  System.Void WFOEventPointGainAnimationV2.<>c__DisplayClass34_0::<MoveSymbol>b__0()));
        return val_3;
    }
    private void OnPointCollision()
    {
        if(this.progress.efxUpdate != 0)
        {
                this.progress.efxUpdate.Play();
        }
        
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.sound.PlayGameSpecificSound(id:  "Plop", clipIndex:  0);
    }
    private void OnPointGainComplete()
    {
        if(this.onComplete != null)
        {
                this.onComplete.Invoke();
        }
        
        if(this.progress.efxUpdate != 0)
        {
                this.progress.efxUpdate.gameObject.SetActive(value:  false);
        }
        
        this.Close();
    }
    private void ResetUI()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.symbolCountText.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.centralSymbolTransform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
        this.glow.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
    }
    private void ResetCentralSymbolPos()
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.symbolCountText.transform, endValue:  0f, duration:  0.3f);
        this.centralSymbolTransform.position = new UnityEngine.Vector3() {x = this.originalCentralSymbolPos, y = 0.3f};
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.centralSymbolTransform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
        this.glow.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
    }
    private void Close()
    {
        WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  3);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WFOEventPointGainAnimationV2()
    {
        this.symbolScale = 3f;
        this.duration = 0.6f;
        this.symbolInterval = 0.12f;
    }
    private void <AutoGenerateSymbols>b__33_0()
    {
        this.ResetCentralSymbolPos();
    }
    private void <AutoGenerateSymbols>b__33_1()
    {
        this.OnPointGainComplete();
    }

}
