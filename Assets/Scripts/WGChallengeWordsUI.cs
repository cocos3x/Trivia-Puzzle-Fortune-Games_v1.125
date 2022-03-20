using UnityEngine;
public class WGChallengeWordsUI : MonoSingleton<WGChallengeWordsUI>
{
    // Fields
    private UnityEngine.GameObject challengeWordsTilePrefab;
    private WGChallengeWordsManager challengeWordsManager;
    private WordRegion wordRegion;
    private LineWord word;
    private System.Collections.Generic.List<UnityEngine.GameObject> coinPieces;
    
    // Methods
    public void Start()
    {
        this.challengeWordsManager = MonoSingleton<WGChallengeWordsManager>.Instance;
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGChallengeWordsUI::OnSceneLoaded(SceneType obj)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        this.challengeWordsTilePrefab = this.GetComponent<PrefabsFromFolder>().LoadStrictlyTypeNamedPrefab<ChallengeWordsTile>(allowMultiple:  false).gameObject;
        return;
        label_7:
    }
    private void OnSceneLoaded(SceneType obj)
    {
        if(WGChallengeWordsManager.IsFeatureUnlocked == false)
        {
                return;
        }
        
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_2.PlayingMorning != false)
        {
                return;
        }
        
        if(obj != 2)
        {
                return;
        }
        
        if(val_2.PlayingEvening == true)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        this.coinPieces.Clear();
        WordRegion val_5 = WordRegion.instance;
        this.wordRegion = val_5;
        val_5.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  this, method:  System.Void WGChallengeWordsUI::OnWordRegionLoaded()));
        this.wordRegion.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WGChallengeWordsUI::OnWordRegionWordFound(string wordCompleted)));
        this.wordRegion.addOnHintUsedAtLocation(callback:  new System.Action<UnityEngine.Vector3>(object:  this, method:  System.Void WGChallengeWordsUI::OnWordRegionHintUsed(UnityEngine.Vector3 location)));
        this.wordRegion.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WGChallengeWordsUI::OnLevelLoaded(GameLevel gameLevel)));
    }
    private void OnLevelLoaded(GameLevel gameLevel)
    {
        if(this.challengeWordsManager != null)
        {
                this.challengeWordsManager.OnLevelLoaded(gameLevel:  gameLevel);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnWordRegionLoaded()
    {
        if(this.challengeWordsManager.progress.inited != true)
        {
                this.challengeWordsManager.progress.InitProgress();
        }
        
        if(this.challengeWordsManager.progress._wordIndex == 1)
        {
                return;
        }
        
        if(this.challengeWordsManager.progress.inited != true)
        {
                this.challengeWordsManager.progress.InitProgress();
        }
        
        if((X21 + 24) <= this.challengeWordsManager.progress._wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = X21 + 16;
        val_6 = val_6 + ((this.challengeWordsManager.progress._wordIndex) << 3);
        this.word = (X21 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32;
        var val_8 = 4;
        label_31:
        var val_1 = val_8 - 4;
        if(val_1 >= ((X21 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32 + 40 + 24))
        {
            goto label_13;
        }
        
        if(((X21 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32 + 40 + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.challengeWordsTilePrefab, parent:  (X21 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32 + 40 + 16 + 32.transform);
        if(this.challengeWordsManager.progress.inited != true)
        {
                this.challengeWordsManager.progress.InitProgress();
        }
        
        if((X27 + 24) <= this.challengeWordsManager.progress._wordIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_7 = X27 + 16;
        val_7 = val_7 + ((this.challengeWordsManager.progress._wordIndex) << 3);
        if(((X27 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32 + 40 + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(((X27 + 16 + (this.challengeWordsManager.progress._wordIndex) << 3) + 32 + 40 + 16 + 32 + 72) != 0)
        {
                val_3.SetActive(value:  false);
        }
        
        this.coinPieces.Add(item:  val_3);
        val_8 = val_8 + 1;
        if(this.word != null)
        {
            goto label_31;
        }
        
        label_13:
        if((this.challengeWordsManager.<hasShowChallengeFTUX>k__BackingField) != false)
        {
                return;
        }
        
        WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGChallengeWordsFTUXPopup>(showNext:  false);
    }
    private void OnWordRegionWordFound(string wordCompleted)
    {
        if(this.challengeWordsManager.IsPlaying == false)
        {
                return;
        }
        
        if(this.word == 0)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  this.word.answer, b:  wordCompleted)) == false)
        {
                return;
        }
        
        var val_8 = 0;
        label_12:
        if(val_8 >= this.word)
        {
            goto label_9;
        }
        
        if(this.word <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        LineWord.__il2cppRuntimeField_byval_arg.SetActive(value:  false);
        val_8 = val_8 + 1;
        if(this.coinPieces != null)
        {
            goto label_12;
        }
        
        return;
        label_9:
        decimal val_5 = System.Decimal.op_Implicit(value:  this.coinPieces);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, source:  "Challenge Word Reward", subSource:  0, externalParams:  0, doTrack:  true);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "CoinsStatViewUpdate");
        App.Player.SaveState();
        this.challengeWordsManager.CompleteChallenge();
    }
    private void OnWordRegionHintUsed(UnityEngine.Vector3 location)
    {
        var val_6;
        bool val_7 = true;
        if(this.challengeWordsManager.IsPlaying == false)
        {
                return;
        }
        
        val_6 = 4;
        do
        {
            var val_2 = val_6 - 4;
            if(val_2 >= val_7)
        {
                return;
        }
        
            val_7 = val_7 & 4294967295;
            if(val_2 >= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((true & 4294967295) + 32) != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Vector3 val_5 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.transform.position;
            if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, rhs:  new UnityEngine.Vector3() {x = location.x, y = location.y, z = location.z})) != false)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished + 32.SetActive(value:  false);
        }
        
        }
        
            val_6 = val_6 + 1;
        }
        while(this.coinPieces != null);
        
        throw new NullReferenceException();
    }
    public WGChallengeWordsUI()
    {
        this.coinPieces = new System.Collections.Generic.List<UnityEngine.GameObject>();
    }

}
