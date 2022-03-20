using UnityEngine;
public class BBLGameOverScreen : MonoBehaviour
{
    // Fields
    private BlockPuzzleMagic.GoalDisplayIcon goalDisplayIconPrefab;
    private UnityEngine.RectTransform displayContainer;
    private UnityEngine.UI.Button buttonKeepPlaying;
    private UnityEngine.UI.Button buttonRestartLevel;
    private UnityEngine.UI.Text labelLifeDeductionAmt;
    private UnityEngine.CanvasGroup groupLabelLifeDeduction;
    private UnityEngine.UI.Image background;
    private UnityEngine.CanvasGroup contentGroup;
    
    // Methods
    private void Awake()
    {
        this.buttonKeepPlaying.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLGameOverScreen::OnClickKeepPlaying()));
        this.buttonRestartLevel.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLGameOverScreen::OnClickRestartLevel()));
    }
    private void OnEnable()
    {
        BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        if((this.goalDisplayIconPrefab == 0) || (this.displayContainer == 0))
        {
            goto label_12;
        }
        
        var val_16 = 0;
        label_18:
        if(val_16 >= val_1.currentLevel.goals)
        {
            goto label_12;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Object.Instantiate<BlockPuzzleMagic.GoalDisplayIcon>(original:  this.goalDisplayIconPrefab, parent:  this.displayContainer).Initialize(_goal:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32);
        val_16 = val_16 + 1;
        if(val_1.currentLevel.goals != null)
        {
            goto label_18;
        }
        
        label_12:
        BlockPuzzleMagic.BestBlocksGameEcon val_5 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        string val_7 = System.String.Format(format:  "-{0}", arg0:  val_5.lifePenaltyGameOver.ToString());
        this.contentGroup.alpha = 0f;
        UnityEngine.Color val_8 = this.background.color;
        this.contentGroup.blocksRaycasts = false;
        DG.Tweening.Sequence val_9 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.background, endValue:  1f, duration:  0.5f));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.contentGroup, endValue:  1f, duration:  0.3f));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_9, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLGameOverScreen::<OnEnable>b__9_0()));
    }
    private void OnClickKeepPlaying()
    {
        this.contentGroup.blocksRaycasts = false;
        this.gameObject.SetActive(value:  false);
    }
    private void OnClickRestartLevel()
    {
        .<>4__this = this;
        MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.GameOver(success:  false);
        this.contentGroup.blocksRaycasts = false;
        BlockPuzzleMagic.BestBlocksGameEcon val_4 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        int val_5 = BestBlocksPlayer.Instance.DebitLife(amount:  val_4.lifePenaltyGameOver);
        UnityEngine.CanvasGroup val_7 = UnityEngine.Object.Instantiate<UnityEngine.CanvasGroup>(original:  this.groupLabelLifeDeduction, parent:  this.buttonRestartLevel.transform);
        .floatyTextGroup = val_7;
        UnityEngine.Transform val_8 = val_7.transform;
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        if(null == null)
        {
                UnityEngine.Vector2 val_10 = this.groupLabelLifeDeduction.transform.anchoredPosition;
            val_8.anchoredPosition = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  val_8, endValue:  -180f, duration:  1.5f, snapping:  false), ease:  6);
            DG.Tweening.Tweener val_16 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (BBLGameOverScreen.<>c__DisplayClass11_0)[1152921513402391920].floatyTextGroup, endValue:  0f, duration:  0.5f), delay:  0.5f), action:  new DG.Tweening.TweenCallback(object:  new BBLGameOverScreen.<>c__DisplayClass11_0(), method:  System.Void BBLGameOverScreen.<>c__DisplayClass11_0::<OnClickRestartLevel>b__0()));
            return;
        }
        
        label_15:
    }
    public BBLGameOverScreen()
    {
    
    }
    private void <OnEnable>b__9_0()
    {
        if(this.contentGroup != null)
        {
                this.contentGroup.blocksRaycasts = true;
            return;
        }
        
        throw new NullReferenceException();
    }

}
