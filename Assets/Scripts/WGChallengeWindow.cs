using UnityEngine;
public class WGChallengeWindow : MonoBehaviour
{
    // Fields
    private WGChallengeProgressDisplay _progressDisplayPrefab;
    private WGChallengeDefinition myDef;
    private UnityEngine.Transform progressDisplayParent;
    private UnityEngine.GameObject checkLaterMessage;
    private GridCoinCollectAnimationInstantiator gridCoinAnimator;
    private UnityEngine.UI.Text coinRewardText;
    private System.Collections.Generic.Dictionary<ChallengeType, WGChallengeProgressDisplay> progressDisplays;
    private bool waitForAnimation;
    
    // Properties
    private WGChallengeProgressDisplay ProgressDisplayPrefab { get; }
    
    // Methods
    private WGChallengeProgressDisplay get_ProgressDisplayPrefab()
    {
        WGChallengeProgressDisplay val_3;
        if(this._progressDisplayPrefab == 0)
        {
                this._progressDisplayPrefab = PrefabLoader.LoadPrefab<WGChallengeProgressDisplay>(featureName:  "AchievementGoals");
            return val_3;
        }
        
        val_3 = this._progressDisplayPrefab;
        return val_3;
    }
    private void OnEnable()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  this.gridCoinAnimator.OnCompleteCallback, b:  new System.Action(object:  this, method:  System.Void WGChallengeWindow::OnCollectComplete()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.gridCoinAnimator.OnCompleteCallback = val_2;
        this.SetupUI();
        return;
        label_3:
    }
    public void SetupUI()
    {
        WGChallengeWindow val_30;
        var val_31;
        var val_32;
        System.Collections.Generic.List<ChallengeTask> val_33;
        object val_34;
        WGChallengeProgressDisplay val_35;
        val_30 = this;
        val_31 = 1152921504893267968;
        val_32 = 1152921515418617488;
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) == 0)
        {
                UnityEngine.Debug.LogError(message:  "can\'t init challenge window without an active challenge tracker");
            this.gameObject.SetActive(value:  false);
            return;
        }
        
        WGChallengeController val_4 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        val_33 = val_4.taskList;
        WGChallengeController val_5 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
        string val_6 = val_5._challengeReward.ToString();
        this.checkLaterMessage.SetActive(value:  false);
        if(null < 1)
        {
                return;
        }
        
        var val_32 = 0;
        label_60:
        WGChallengeWindow.<>c__DisplayClass11_0 val_7 = new WGChallengeWindow.<>c__DisplayClass11_0();
        .<>4__this = val_30;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_34 = (System.Type.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16;
        if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  (System.Type.__il2cppRuntimeField_cctor_finished + 0) + 32 + 16)) == false)
        {
            goto label_25;
        }
        
        if(null <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        object val_12 = System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())).GetValue(index:  System.Enum.__il2cppRuntimeField_byval_arg + 16);
        val_34 = val_7;
        .typeOf = null;
        PerChallengeInfo val_13 = this.myDef.getInfoForType(cType:  null);
        if(val_13 == null)
        {
            goto label_36;
        }
        
        if((this.progressDisplays.ContainsKey(key:  .typeOf)) != false)
        {
                val_35 = this.progressDisplays.Item[.typeOf];
        }
        else
        {
                val_35 = UnityEngine.Object.Instantiate<WGChallengeProgressDisplay>(original:  this.ProgressDisplayPrefab, parent:  this.progressDisplayParent);
            this.progressDisplays.Add(key:  .typeOf, value:  val_35);
            val_31 = val_31;
            val_32 = val_32;
            val_33 = val_33;
        }
        
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance.CheckChallengeAvailable(cType:  .typeOf)) == true)
        {
            goto label_47;
        }
        
        if((val_4.taskList + 24) <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_30 = val_4.taskList + 16;
        val_30 = val_30 + 0;
        if(((val_4.taskList + 16 + 0) + 32.isComplete()) == false)
        {
            goto label_50;
        }
        
        label_47:
        if((val_4.taskList + 24) <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_31 = val_4.taskList + 16;
        val_31 = val_31 + 0;
        val_35.Init(myDatas:  (val_4.taskList + 16 + 0) + 32, myPopup:  this.transform, incInfo:  val_13);
        val_35.transform.SetSiblingIndex(index:  0);
        UnityEngine.Events.UnityAction val_23 = null;
        val_34 = val_23;
        val_23 = new UnityEngine.Events.UnityAction(object:  val_7, method:  System.Void WGChallengeWindow.<>c__DisplayClass11_0::<SetupUI>b__0());
        val_17.collectButton.m_OnClick.AddListener(call:  val_23);
        goto label_56;
        label_50:
        val_35.gameObject.SetActive(value:  false);
        this.checkLaterMessage.SetActive(value:  true);
        label_56:
        val_32 = val_32 + 1;
        if(val_32 < (val_4.taskList + 24))
        {
            goto label_60;
        }
        
        return;
        label_25:
        if(null <= val_32)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_30 = "trying to display progress for " + (System.Enum.__il2cppRuntimeField_byval_arg + 16).ToString()((System.Enum.__il2cppRuntimeField_byval_arg + 16).ToString()) + " but type does not exist";
        UnityEngine.Debug.LogWarning(message:  val_30);
        return;
        label_36:
        mem[1152921516011100032] = null;
        val_30 = "No definition available for challenge type " + .typeOf.ToString();
        UnityEngine.Debug.LogError(message:  val_30);
    }
    private void OnClickCollect(ChallengeType myType)
    {
        int val_12;
        bool val_13;
        if(this.waitForAnimation == true)
        {
                return;
        }
        
        val_12 = 1152921504893267968;
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance.TryCompleteChallenge(chalToComplete:  myType)) != false)
        {
                WGChallengeProgressDisplay val_3 = this.progressDisplays.Item[myType];
            UnityEngine.Vector3 val_6 = val_3.collectButton.gameObject.transform.position;
            this.gridCoinAnimator.SetCoinStartPosition(pos:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
            mem2[0] = 0;
            Player val_7 = App.Player;
            WGChallengeController val_8 = MonoSingletonSelfGenerating<WGChallengeController>.Instance;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_8._challengeReward);
            decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_7._credits, hi = val_7._credits, lo = 1152921504893267968}, d2:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid});
            val_12 = val_10.flags;
            Player val_11 = App.Player;
            this.gridCoinAnimator.Play(fromValue:  new System.Decimal() {flags = val_12, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, toValue:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            val_13 = 1;
        }
        else
        {
                val_13 = false;
        }
        
        this.waitForAnimation = val_13;
    }
    private void OnCollectComplete()
    {
        this.SetupUI();
        this.waitForAnimation = false;
    }
    public void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WGChallengeWindow()
    {
        this.progressDisplays = new System.Collections.Generic.Dictionary<ChallengeType, WGChallengeProgressDisplay>();
    }

}
