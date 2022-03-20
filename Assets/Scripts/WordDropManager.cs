using UnityEngine;
public class WordDropManager : MonoSingleton<WordDropManager>
{
    // Fields
    public UnityEngine.UI.Button failButton;
    public UnityEngine.UI.Button addLifeButton;
    private WordDropController wordDropController;
    private SLC.Minigames.WordDrop.IceCreamController iceCreamController;
    private int playerLives;
    private System.Collections.Generic.List<string[]> parsedWordData;
    private RandomSet randomSet;
    private float levelSpeed;
    private bool init;
    private bool isPaused;
    private int playerScoops;
    
    // Properties
    public WordDropController GetWordDropController { get; }
    public SLC.Minigames.WordDrop.IceCreamController GetIceCreamController { get; }
    public bool IsPaused { get; }
    public int PlayerScoops { get; }
    public float LevelSpeed { get; }
    
    // Methods
    public WordDropController get_GetWordDropController()
    {
        return (WordDropController)this.wordDropController;
    }
    public SLC.Minigames.WordDrop.IceCreamController get_GetIceCreamController()
    {
        return (SLC.Minigames.WordDrop.IceCreamController)this.iceCreamController;
    }
    public bool get_IsPaused()
    {
        return (bool)this.isPaused;
    }
    public int get_PlayerScoops()
    {
        return (int)this.playerScoops;
    }
    public void AddScoop()
    {
        int val_2 = this.playerScoops;
        val_2 = val_2 + 1;
        this.playerScoops = val_2;
        MonoSingleton<WordDropUIController>.Instance.UpdateScoopsDisplay(updatedScoops:  this.playerScoops);
    }
    public float get_LevelSpeed()
    {
        SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        float val_2 = 0.9996057f;
        val_2 = val_2 * 5.5f;
        return (float)val_2;
    }
    public override void InitMonoSingleton()
    {
        this.Initialize();
        this.failButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WordDropManager::HandleFail()));
        this.addLifeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordDropManager::AddLife()));
    }
    private void Initialize()
    {
        if(this.init == true)
        {
                return;
        }
        
        SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void WordDropManager::ResetLevel()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_1.OnRestartMinigame = val_3;
        SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void WordDropManager::OnContinue()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_4.OnContinueMinigame = val_6;
        SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnCheckpointRankUpContinue, b:  new System.Action(object:  this, method:  System.Void WordDropManager::OnCheckpointRankContinue()));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_7.OnCheckpointRankUpContinue = val_9;
        this.init = true;
        return;
        label_12:
    }
    private void Start()
    {
        string val_7;
        var val_8;
        var val_20;
        System.String[] val_21;
        var val_22;
        this.isPaused = false;
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/worddrop/word_data").text);
        this.parsedWordData = new System.Collections.Generic.List<System.String[]>();
        List.Enumerator<T> val_6 = GetEnumerator();
        var val_20 = 0;
        label_21:
        if(val_8.MoveNext() == false)
        {
            goto label_7;
        }
        
        val_20 = val_7;
        System.Collections.Generic.List<System.String> val_10 = new System.Collections.Generic.List<System.String>();
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_12 = GetEnumerator();
        label_16:
        if(val_8.MoveNext() == false)
        {
            goto label_13;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Add(item:  val_7);
        goto label_16;
        label_13:
        val_20 = 0;
        val_20 = val_20 + 1;
        mem2[0] = 122;
        val_21 = public System.Void List.Enumerator<System.Object>::Dispose();
        val_8.Dispose();
        if(val_20 != 0)
        {
            goto label_17;
        }
        
        if(val_20 != 1)
        {
                var val_14 = ((1152921515835375392 + ((0 + 1)) << 2) == 122) ? 1 : 0;
            val_14 = ((val_20 >= 0) ? 1 : 0) & val_14;
            val_20 = val_20 - val_14;
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = val_10.ToArray();
        if(this.parsedWordData == null)
        {
                throw new NullReferenceException();
        }
        
        this.parsedWordData.Add(item:  val_21);
        goto label_21;
        label_7:
        var val_17 = val_20 + 1;
        mem2[0] = 164;
        val_8.Dispose();
        this.randomSet.addIntRange(lowest:  0, highest:  this.parsedWordData - 1);
        this.isPaused = false;
        this.iceCreamController.Init(reset:  true);
        this.playerLives = 3;
        MonoSingleton<WordDropUIController>.Instance.UpdateLivesDisplay(updatedLives:  this.playerLives);
        return;
        label_17:
        val_22 = val_20;
        val_21 = 0;
        throw val_22;
    }
    public string[] GetNextLevelData()
    {
        bool val_3 = true;
        if(this.randomSet.remainingCount() == 0)
        {
                this.randomSet.reset();
        }
        
        int val_2 = this.randomSet.roll(unweighted:  false);
        if(val_3 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + (val_2 << 3);
        return (System.String[])(true + (val_2) << 3) + 32;
    }
    private void ResetLevel()
    {
        this.isPaused = false;
    }
    private void AddLife()
    {
        int val_2 = this.playerLives;
        val_2 = val_2 + 1;
        this.playerLives = val_2;
        MonoSingleton<WordDropUIController>.Instance.UpdateLivesDisplay(updatedLives:  this.playerLives);
    }
    private void OnContinue()
    {
        this.iceCreamController.DeleteWordScoops();
        this.playerLives = 3;
        MonoSingleton<WordDropUIController>.Instance.UpdateLivesDisplay(updatedLives:  this.playerLives);
        this.isPaused = false;
        WordDropUIController val_2 = MonoSingleton<WordDropUIController>.Instance;
        val_2.canvas.enabled = true;
        WordDropFTUXManager val_3 = MonoSingleton<WordDropFTUXManager>.Instance;
        if(val_3.ftux != false)
        {
                return;
        }
        
        MonoSingleton<WordDropFTUXManager>.Instance.RestartFTUX();
    }
    private void OnCheckpointRankContinue()
    {
        this.isPaused = false;
        WordDropUIController val_1 = MonoSingleton<WordDropUIController>.Instance;
        val_1.canvas.enabled = true;
    }
    public void HandleFail()
    {
        int val_6 = this.playerLives;
        val_6 = val_6 - 1;
        this.playerLives = val_6;
        MonoSingleton<WordDropUIController>.Instance.UpdateScoopsDisplay(updatedScoops:  this.playerScoops);
        this.iceCreamController.DeleteWordScoops();
        if(this.playerLives > 0)
        {
                MonoSingleton<WordDropUIController>.Instance.UpdateLivesDisplay(updatedLives:  this.playerLives);
            return;
        }
        
        this.isPaused = true;
        bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        WordDropUIController val_5 = MonoSingleton<WordDropUIController>.Instance;
        val_5.canvas.enabled = false;
    }
    public void HandlePause()
    {
        bool val_1 = this.isPaused;
        val_1 = val_1 ^ 1;
        this.isPaused = val_1;
    }
    public void HandleLevelComplete()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) != false)
        {
                this.isPaused = true;
        }
        
        MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
    }
    public WordDropManager()
    {
        this.randomSet = new RandomSet();
    }

}
