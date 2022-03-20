using UnityEngine;
public class WGChallengeFlyout : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
    // Fields
    private UnityEngine.RectTransform progressFlyout;
    private UnityEngine.RectTransform completeFlyout;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.UI.Text completeText;
    private bool playingAnimation;
    private System.Action onStartAction;
    private UnityEngine.Camera canvasCamera;
    private WGChallengeButton uiButton;
    
    // Methods
    private void Start()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_3 = MainController.instance;
            val_3.onBeforeLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGChallengeFlyout::OnBeforeLevelComplete()));
        }
        
        if(this.onStartAction == null)
        {
                return;
        }
        
        this.onStartAction.Invoke();
    }
    public void PlayProgressFlyout()
    {
        this.onStartAction = new System.Action(object:  this, method:  System.Void WGChallengeFlyout::ProgressAnim());
    }
    private void ProgressAnim()
    {
        var val_12;
        System.Func<ChallengeTask, System.Single> val_14;
        if(this.playingAnimation == true)
        {
                return;
        }
        
        this.playingAnimation = true;
        this.progressFlyout.gameObject.SetActive(value:  true);
        this.completeFlyout.gameObject.SetActive(value:  false);
        WGChallengeController val_3 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        System.Collections.Generic.List<ChallengeTask> val_4 = new System.Collections.Generic.List<ChallengeTask>(collection:  val_3.taskList);
        PluginExtension.Shuffle<ChallengeTask>(list:  val_4, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        val_12 = null;
        val_12 = null;
        val_14 = WGChallengeFlyout.<>c.<>9__8_0;
        if(val_14 == null)
        {
                System.Func<ChallengeTask, System.Single> val_5 = null;
            val_14 = val_5;
            val_5 = new System.Func<ChallengeTask, System.Single>(object:  WGChallengeFlyout.<>c.__il2cppRuntimeField_static_fields, method:  System.Single WGChallengeFlyout.<>c::<ProgressAnim>b__8_0(ChallengeTask s));
            WGChallengeFlyout.<>c.<>9__8_0 = val_14;
        }
        
        string val_9 = System.String.Format(format:  "{0} {1}/{2}", arg0:  System.Linq.Enumerable.First<ChallengeTask>(source:  System.Linq.Enumerable.OrderByDescending<ChallengeTask, System.Single>(source:  val_4, keySelector:  val_5)).goalName(cType:  val_7.id), arg1:  val_7.progress, arg2:  val_7.target);
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.ProgressFlyout());
    }
    private System.Collections.IEnumerator ProgressFlyout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGChallengeFlyout.<ProgressFlyout>d__9();
    }
    private string goalName(ChallengeType cType)
    {
        if(cType > 5)
        {
                return "ERROR";
        }
        
        var val_5 = 32496348 + (cType) << 2;
        val_5 = val_5 + 32496348;
        goto (32496348 + (cType) << 2 + 32496348);
    }
    private void DoCompleteFlyout()
    {
        if(this.playingAnimation == true)
        {
                return;
        }
        
        this.playingAnimation = true;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  1f);
        this.completeFlyout.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        this.progressFlyout.gameObject.SetActive(value:  false);
        this.completeFlyout.gameObject.SetActive(value:  true);
        string val_5 = Localization.Localize(key:  "rewards_avail", defaultValue:  "Rewards Available!", useSingularKey:  false);
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.CompleteFlyout());
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.SetCompleteFlyoutPlacement());
    }
    private void OnBeforeLevelComplete()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_3 = MainController.instance;
            val_3.onBeforeLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGChallengeFlyout::OnBeforeLevelComplete()));
        }
        
        this.OnDisplayComplete();
    }
    public void PlayCompleteFlyout()
    {
        this.onStartAction = new System.Action(object:  this, method:  System.Void WGChallengeFlyout::DoCompleteFlyout());
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.sound.PlayGameSpecificSound(id:  "Challenge Complete", clipIndex:  0);
    }
    private System.Collections.IEnumerator CompleteFlyout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGChallengeFlyout.<CompleteFlyout>d__16();
    }
    private void Update()
    {
        if((MonoSingleton<WGWindowManager>.Instance.GetActiveAndQueuedWindowCount()) < 2)
        {
                return;
        }
        
        this.OnDisplayComplete();
    }
    private System.Collections.IEnumerator SetCompleteFlyoutPlacement()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGChallengeFlyout.<SetCompleteFlyoutPlacement>d__18();
    }
    private void OnDisplayComplete()
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
    }
    private void OnDestroy()
    {
        this.StopAllCoroutines();
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        this.StopAllCoroutines();
        this.gameObject.SetActive(value:  false);
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeWindow>(showNext:  false);
    }
    public WGChallengeFlyout()
    {
    
    }

}
