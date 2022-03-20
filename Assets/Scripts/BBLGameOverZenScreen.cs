using UnityEngine;
public class BBLGameOverZenScreen : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button buttonRestartLevel;
    private UnityEngine.EventSystems.EventTrigger buttonReview;
    private UnityEngine.UI.Text textScoreCurrent;
    private UnityEngine.UI.Text textScoreBest;
    private UnityEngine.UI.Image background;
    private UnityEngine.CanvasGroup contentGroupRoot;
    private UnityEngine.CanvasGroup contentGroupPrelude;
    private UnityEngine.CanvasGroup contentGroupResults;
    
    // Methods
    private void Awake()
    {
        this.buttonRestartLevel.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLGameOverZenScreen::OnClickRestartLevel()));
        .eventID = 2;
        (EventTrigger.Entry)[1152921513403150576].callback.AddListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>(object:  this, method:  System.Void BBLGameOverZenScreen::OnReviewPointerDown(UnityEngine.EventSystems.BaseEventData eventData)));
        this.buttonReview.triggers.Add(item:  new EventTrigger.Entry());
        .eventID = 3;
        (EventTrigger.Entry)[1152921513403171056].callback.AddListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>(object:  this, method:  System.Void BBLGameOverZenScreen::OnReviewPointerUp(UnityEngine.EventSystems.BaseEventData eventData)));
        this.buttonReview.triggers.Add(item:  new EventTrigger.Entry());
    }
    private void OnEnable()
    {
        this.contentGroupResults.alpha = 0f;
        this.contentGroupPrelude.alpha = 0f;
        UnityEngine.Color val_1 = this.background.color;
        BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
        string val_3 = val_2.zenModeScoreCurrent.ToString();
        BestBlocksPlayer val_4 = BestBlocksPlayer.Instance;
        string val_6 = System.String.Format(format:  "BEST: {0}", arg0:  val_4.zenModeScoreBest.ToString());
        this.contentGroupPrelude.gameObject.SetActive(value:  true);
        this.contentGroupResults.gameObject.SetActive(value:  false);
        DG.Tweening.Sequence val_9 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroupPrelude, endValue:  1f, duration:  0.2f));
        DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_9, interval:  1f);
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_9, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLGameOverZenScreen::<OnEnable>b__9_0()));
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.background, endValue:  1f, duration:  0.5f));
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroupPrelude, endValue:  0f, duration:  0.5f));
        DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroupResults, endValue:  1f, duration:  0.3f));
    }
    private void OnClickRestartLevel()
    {
        MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.ClearProgress(gameMode:  1);
        this.gameObject.SetActive(value:  false);
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    private void OnReviewPointerDown(UnityEngine.EventSystems.BaseEventData eventData)
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroupRoot, endValue:  0f, duration:  0.15f);
    }
    private void OnReviewPointerUp(UnityEngine.EventSystems.BaseEventData eventData)
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroupRoot, endValue:  1f, duration:  0.15f);
    }
    public BBLGameOverZenScreen()
    {
    
    }
    private void <OnEnable>b__9_0()
    {
        AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_2 = val_1.ShowInterstitial(context:  2);
        this.contentGroupPrelude.gameObject.SetActive(value:  false);
        this.contentGroupResults.gameObject.SetActive(value:  true);
    }

}
