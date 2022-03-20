using UnityEngine;
public class CategoryPackCompleteDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform catPackMeterContainer;
    private CategoryPackProgressMeter catPackMeterPrefab;
    private UnityEngine.CanvasGroup completeMessageCanvasGroup;
    private UnityEngine.CanvasGroup completeMessageBlurbGroup;
    private UnityEngine.UI.MaskableGraphic icon;
    private UnityEngine.UI.Text labelDescription;
    private UnityEngine.UI.Button buttonContinue;
    private LevelCompletePopup levelCompletePopup;
    private CategoryPackProgressMeter catPackMeterInstance;
    
    // Methods
    private void Start()
    {
        this.buttonContinue.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void CategoryPackCompleteDisplay::OnContinueClicked()));
    }
    public void Init(LevelCompletePopup lvlComplete)
    {
        this.levelCompletePopup = lvlComplete;
    }
    public void Show(bool isChapterComplete, bool isPackComplete)
    {
        this.ShowProgressMeter(isChapterComplete:  isChapterComplete, isPackComplete:  isPackComplete);
    }
    private void ShowProgressMeter(bool isChapterComplete, bool isPackComplete)
    {
        CategoryPackProgressMeter val_7;
        .<>4__this = this;
        .isPackComplete = isPackComplete;
        if(this.catPackMeterInstance == 0)
        {
                CategoryPackProgressMeter val_4 = UnityEngine.Object.Instantiate<CategoryPackProgressMeter>(original:  this.catPackMeterPrefab, parent:  this.catPackMeterContainer);
            val_7 = val_4;
            this.catPackMeterInstance = val_4;
        }
        else
        {
                val_7 = this.catPackMeterInstance;
        }
        
        val_7.ShowLevelCompleteAnimation(startDelay:  0.1f, isChapterComplete:  isChapterComplete, onComplete:  new System.Action(object:  new CategoryPackCompleteDisplay.<>c__DisplayClass12_0(), method:  System.Void CategoryPackCompleteDisplay.<>c__DisplayClass12_0::<ShowProgressMeter>b__0()));
    }
    private void ShowPackCompleteMessage()
    {
        this.completeMessageCanvasGroup.gameObject.SetActive(value:  true);
        this.completeMessageCanvasGroup.alpha = 1f;
        this.completeMessageCanvasGroup.blocksRaycasts = false;
        this.completeMessageBlurbGroup.alpha = 0f;
        UnityEngine.Color val_2 = this.icon.color;
        this.icon.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = 0f};
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  1.6f, y:  1.6f, z:  1f);
        this.icon.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  80f);
        this.icon.transform.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
        DG.Tweening.Sequence val_7 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.icon.transform, endValue:  1f, duration:  0.18f), ease:  20));
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.zero;
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.icon.transform, endValue:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, duration:  0.18f, mode:  0), ease:  1));
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.icon, endValue:  1f, duration:  0.1f), delay:  0.05f), ease:  1));
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_7, interval:  0.15f);
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_7, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.completeMessageBlurbGroup, endValue:  1f, duration:  0.15f));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_7, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CategoryPackCompleteDisplay::<ShowPackCompleteMessage>b__13_0()));
    }
    private void OnContinueClicked()
    {
        if(this.levelCompletePopup != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    private void OnPackCompleteClicked()
    {
        this.levelCompletePopup.HideLowerUI(fadeOutDuration:  0.5f, delay:  0f);
        this.ShowPackCompleteMessage();
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.catPackMeterInstance.meterCanvasGroup, endValue:  0f, duration:  0.5f);
    }
    public CategoryPackCompleteDisplay()
    {
    
    }
    private void <ShowPackCompleteMessage>b__13_0()
    {
        if(this.completeMessageCanvasGroup != null)
        {
                this.completeMessageCanvasGroup.blocksRaycasts = true;
            return;
        }
        
        throw new NullReferenceException();
    }

}
