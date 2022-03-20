using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleGameplayController : MonoSingleton<SLC.Minigames.WordJumble.WordJumbleGameplayController>
    {
        // Fields
        private UnityEngine.RectTransform wordAreaParent;
        private SLC.Minigames.WordJumble.WordJumbleWordArea wordAreaPrefab;
        private SLC.Minigames.WordJumble.WordJumbleAnswerLetter answerLetterPrefab;
        private SLC.Minigames.WordJumble.WordJumbleLetterTile letterTilePrefab;
        private System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea> wordAreas;
        
        // Properties
        public System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea> getWordAreas { get; }
        
        // Methods
        public System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea> get_getWordAreas()
        {
            return (System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea>)this.wordAreas;
        }
        private void Start()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnRestartMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleGameplayController::OnRestartFromCheckpoint()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_1.OnRestartMinigame = val_3;
            SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleGameplayController::OnContinue()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_4.OnContinueMinigame = val_6;
            SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnCheckpointRankUpContinue, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleGameplayController::OnRankUpContinue()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            val_7.OnCheckpointRankUpContinue = val_9;
            this.StartGame();
            return;
            label_11:
        }
        private void StartGame()
        {
            string val_9;
            var val_10;
            int val_18;
            UnityEngine.Transform val_19;
            System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea> val_20;
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.wordAreaParent.transform);
            this.wordAreas.Clear();
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_18 = val_4.currentPlayerLevel;
                MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
            }
            else
            {
                    val_18 = 100;
            }
            
            SLC.Minigames.WordJumble.WordJumbleLevel val_7 = MonoSingleton<SLC.Minigames.WordJumble.WordJumbleDataParser>.Instance.getLevel(currentLevel:  100);
            List.Enumerator<T> val_8 = val_7.<levelWords>k__BackingField.GetEnumerator();
            label_24:
            if(val_10.MoveNext() == false)
            {
                goto label_19;
            }
            
            val_19 = this.wordAreaParent;
            SLC.Minigames.WordJumble.WordJumbleWordArea val_12 = UnityEngine.Object.Instantiate<SLC.Minigames.WordJumble.WordJumbleWordArea>(original:  this.wordAreaPrefab, parent:  val_19);
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = val_9;
            val_12.Init(word:  val_19, _answerLetter:  this.answerLetterPrefab, _letterTile:  this.letterTilePrefab);
            val_20 = this.wordAreas;
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20.Add(item:  val_12);
            goto label_24;
            label_19:
            val_10.Dispose();
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_15 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_15.currentPlayerLevel != 1)
            {
                    return;
            }
            
            this.gameObject.GetComponent<SLC.Minigames.WordJumble.WordJumbleFTUX>().Init(controller:  this);
        }
        private void OnRestartFromCheckpoint()
        {
            this.StartGame();
        }
        private void OnContinue()
        {
            this.StartGame();
        }
        private void OnRankUpContinue()
        {
            this.StartGame();
        }
        public void HandleFailed()
        {
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
                return;
            }
            
            this.StartGame();
        }
        public void HandleComplete()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance)) == false)
            {
                    return;
            }
            
            bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
        }
        public void HACK_InstantWin()
        {
            this.HandleComplete();
        }
        private void Update()
        {
            if((UnityEngine.Input.GetKeyDown(key:  32)) == false)
            {
                    return;
            }
            
            this.Hint();
        }
        public void Hint()
        {
            var val_5;
            System.Func<SLC.Minigames.WordJumble.WordJumbleWordArea, System.Boolean> val_7;
            val_5 = null;
            val_5 = null;
            val_7 = WordJumbleGameplayController.<>c.<>9__16_0;
            if(val_7 == null)
            {
                    System.Func<SLC.Minigames.WordJumble.WordJumbleWordArea, System.Boolean> val_1 = null;
                val_7 = val_1;
                val_1 = new System.Func<SLC.Minigames.WordJumble.WordJumbleWordArea, System.Boolean>(object:  WordJumbleGameplayController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordJumbleGameplayController.<>c::<Hint>b__16_0(SLC.Minigames.WordJumble.WordJumbleWordArea x));
                WordJumbleGameplayController.<>c.<>9__16_0 = val_7;
            }
            
            var val_5 = 1152921519782107520;
            System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<SLC.Minigames.WordJumble.WordJumbleWordArea>(source:  System.Linq.Enumerable.Where<SLC.Minigames.WordJumble.WordJumbleWordArea>(source:  this.wordAreas, predicate:  val_1));
            int val_4 = UnityEngine.Random.Range(min:  0, max:  -2004608640);
            if(val_5 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + (val_4 << 3);
            (1152921519782107520 + (val_4) << 3) + 32.Hint();
        }
        public WordJumbleGameplayController()
        {
            this.wordAreas = new System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleWordArea>();
        }
    
    }

}
