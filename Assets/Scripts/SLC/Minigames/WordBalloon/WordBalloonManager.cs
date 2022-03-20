using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonManager : MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>
    {
        // Fields
        private const string MINIGAME_NAME = "WordBalloons";
        private int <CurrentPlayerLevel>k__BackingField;
        private SLC.Minigames.WordBalloon.GameState <MinigameState>k__BackingField;
        public System.Action OnMinigameBegin;
        public System.Action OnMinigameEnd;
        public System.Action OnLevelComplete;
        private SLC.Minigames.WordBalloon.WordBalloonLevelData <CurrentLevelData>k__BackingField;
        private System.Collections.Generic.List<string> <RemainingWords>k__BackingField;
        
        // Properties
        public int CurrentPlayerLevel { get; set; }
        public SLC.Minigames.WordBalloon.GameState MinigameState { get; set; }
        public SLC.Minigames.WordBalloon.WordBalloonLevelData CurrentLevelData { get; set; }
        public System.Collections.Generic.List<string> RemainingWords { get; set; }
        
        // Methods
        public int get_CurrentPlayerLevel()
        {
            return (int)this.<CurrentPlayerLevel>k__BackingField;
        }
        private void set_CurrentPlayerLevel(int value)
        {
            this.<CurrentPlayerLevel>k__BackingField = value;
        }
        public SLC.Minigames.WordBalloon.GameState get_MinigameState()
        {
            return (SLC.Minigames.WordBalloon.GameState)this.<MinigameState>k__BackingField;
        }
        private void set_MinigameState(SLC.Minigames.WordBalloon.GameState value)
        {
            this.<MinigameState>k__BackingField = value;
        }
        public SLC.Minigames.WordBalloon.WordBalloonLevelData get_CurrentLevelData()
        {
            return (SLC.Minigames.WordBalloon.WordBalloonLevelData)this.<CurrentLevelData>k__BackingField;
        }
        private void set_CurrentLevelData(SLC.Minigames.WordBalloon.WordBalloonLevelData value)
        {
            this.<CurrentLevelData>k__BackingField = value;
        }
        public System.Collections.Generic.List<string> get_RemainingWords()
        {
            return (System.Collections.Generic.List<System.String>)this.<RemainingWords>k__BackingField;
        }
        private void set_RemainingWords(System.Collections.Generic.List<string> value)
        {
            this.<RemainingWords>k__BackingField = value;
        }
        public override void InitMonoSingleton()
        {
            this.InitializeGame(existingData:  0);
            this.BeginGame();
        }
        private void Start()
        {
            this.InitializeGame(existingData:  0);
            this.BeginGame();
        }
        public void InitializeAndBeginGame()
        {
            this.InitializeGame(existingData:  0);
            this.BeginGame();
        }
        public void InitializeGame(SLC.Minigames.WordBalloon.WordBalloonLevelData existingData)
        {
            SLC.Minigames.WordBalloon.WordBalloonLevelData val_6 = existingData;
            this.<CurrentPlayerLevel>k__BackingField = 1;
            this.<MinigameState>k__BackingField = 0;
            if(val_6 != null)
            {
                    this.<CurrentLevelData>k__BackingField = val_6;
            }
            else
            {
                    SLC.Minigames.WordBalloon.WordBalloonWordData val_2 = SLC.Minigames.WordBalloon.WordBalloonDataManager.GetWords(amountToGet:  SLC.Minigames.WordBalloon.WordBalloonEcon.GetAmountOfWords(gameLevel:  1), storeHistory:  true);
                this.<CurrentLevelData>k__BackingField = SLC.Minigames.WordBalloon.WordBalloonGridGenerator.Instance.Generate(wordList:  val_2.requiredWords);
                val_4.category = val_2.category;
                val_6 = this.<CurrentLevelData>k__BackingField;
            }
            
            this.<RemainingWords>k__BackingField = new System.Collections.Generic.List<System.String>(collection:  this.<CurrentLevelData>k__BackingField.requiredWords);
        }
        public void BeginGame()
        {
            this.<MinigameState>k__BackingField = 1;
            this.Invoke(methodName:  "StartGame", time:  1f);
        }
        private void StartGame()
        {
            if(this.OnMinigameBegin != null)
            {
                    this.OnMinigameBegin.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void CompleteLevel()
        {
            if(this.OnLevelComplete != null)
            {
                    this.OnLevelComplete.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void EndGame()
        {
            this.<MinigameState>k__BackingField = 2;
            if(this.OnMinigameEnd != null)
            {
                    this.OnMinigameEnd.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
        public bool IsWordRequired(string submittedWord)
        {
            return this.<CurrentLevelData>k__BackingField.requiredWords.Contains(item:  submittedWord);
        }
        public bool HasWordBeenSubmitted(string submittedWord)
        {
            bool val_1 = this.<RemainingWords>k__BackingField.Contains(item:  submittedWord);
            val_1 = (~val_1) & 1;
            return (bool)val_1;
        }
        public void MarkWordAsFound(string submittedWord)
        {
            bool val_1 = this.<RemainingWords>k__BackingField.Remove(item:  submittedWord);
        }
        public bool IsFTUX()
        {
            return (bool)((this.<CurrentPlayerLevel>k__BackingField) < 1) ? 1 : 0;
        }
        private SLC.Minigames.WordBalloon.WordBalloonLevelData GetFTUXLevelData()
        {
            .columnLimit = 7;
            .category = "Colors";
            System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
            val_2.Add(item:  "GREEN");
            val_2.Add(item:  "RED");
            val_2.Add(item:  "ORANGE");
            .requiredWords = val_2;
            System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordSolutionData> val_3 = new System.Collections.Generic.List<SLC.Minigames.WordBalloon.WordSolutionData>();
            System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
            val_4.Add(item:  2);
            val_4.Add(item:  9);
            val_4.Add(item:  16);
            val_4.Add(item:  23);
            val_4.Add(item:  30);
            .word = "GREEN";
            .slotSequence = val_4;
            val_3.Add(item:  new SLC.Minigames.WordBalloon.WordSolutionData());
            System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
            val_6.Add(item:  1);
            val_6.Add(item:  3);
            val_6.Add(item:  4);
            .word = "RED";
            .slotSequence = val_6;
            val_3.Add(item:  new SLC.Minigames.WordBalloon.WordSolutionData());
            System.Collections.Generic.List<System.Int32> val_8 = new System.Collections.Generic.List<System.Int32>();
            val_8.Add(item:  0);
            val_8.Add(item:  8);
            val_8.Add(item:  10);
            val_8.Add(item:  11);
            val_8.Add(item:  5);
            val_8.Add(item:  6);
            .word = "ORANGE";
            .slotSequence = val_8;
            val_3.Add(item:  new SLC.Minigames.WordBalloon.WordSolutionData());
            .gridSolutionData = val_3;
            System.Collections.Generic.List<System.String> val_10 = new System.Collections.Generic.List<System.String>();
            val_10.Add(item:  "O");
            val_10.Add(item:  "R");
            val_10.Add(item:  "G");
            val_10.Add(item:  "E");
            val_10.Add(item:  "D");
            val_10.Add(item:  "G");
            val_10.Add(item:  "E");
            val_10.Add(item:  "");
            val_10.Add(item:  "R");
            val_10.Add(item:  "R");
            val_10.Add(item:  "A");
            val_10.Add(item:  "N");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "E");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "E");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "N");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            val_10.Add(item:  "");
            .gridData = val_10;
            return (SLC.Minigames.WordBalloon.WordBalloonLevelData)new SLC.Minigames.WordBalloon.WordBalloonLevelData();
        }
        public WordBalloonManager()
        {
        
        }
    
    }

}
