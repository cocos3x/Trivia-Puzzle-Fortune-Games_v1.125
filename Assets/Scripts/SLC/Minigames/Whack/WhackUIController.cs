using UnityEngine;

namespace SLC.Minigames.Whack
{
    public class WhackUIController : MonoSingleton<SLC.Minigames.Whack.WhackUIController>
    {
        // Fields
        private const int SLOTS = 7;
        private UnityEngine.CanvasGroup mainCanvasGroup;
        public System.Collections.Generic.List<SLC.Minigames.Whack.WhackItem> whackItems;
        private UnityEngine.GameObject itemPrefab;
        private System.Collections.Generic.List<UnityEngine.GameObject> slots;
        private UnityEngine.UI.Text timer;
        private UnityEngine.UI.Slider timerSlider;
        private UnityEngine.UI.Image sliderFill;
        private UnityEngine.Color sliderFillColor;
        private SLC.Minigames.MinigamesCheckpointSlider cpSlider;
        private UnityEngine.GameObject[] lives;
        private UnityEngine.GameObject tapToContinueGroup;
        private UnityEngine.GameObject hammer;
        private UnityEngine.GameObject ftuxText;
        private UnityEngine.GameObject pauseMenu;
        private bool paused;
        private int[] emptyIndices;
        private RandomSet randomSet;
        private SLC.Minigames.Whack.WhackLevel currentLevel;
        private System.DateTime levelExpired;
        private System.TimeSpan remainingTime;
        private bool timerHasStarted;
        private bool firstLevelThisSession;
        
        // Methods
        public override void InitMonoSingleton()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPauseClicked, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.Whack.WhackUIController::PauseLevel()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnPauseClicked = val_3;
            UnityEngine.Color val_4 = this.sliderFill.color;
            this.sliderFillColor = val_4;
            mem[1152921519876100020] = val_4.g;
            mem[1152921519876100024] = val_4.b;
            mem[1152921519876100028] = val_4.a;
            return;
            label_5:
        }
        public void HideUIForPopup(bool showingPopup)
        {
            if(this.mainCanvasGroup != null)
            {
                    this.mainCanvasGroup.alpha = (showingPopup != true) ? 0f : 1f;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void OnDestroy()
        {
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            1152921504893161472 = val_3.OnPauseClicked;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.Whack.WhackUIController::PauseLevel()));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnPauseClicked = val_5;
            return;
            label_10:
        }
        private void PauseLevel()
        {
            if(this.pauseMenu.gameObject.activeSelf != false)
            {
                    return;
            }
            
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.paused = true;
            this.timerHasStarted = false;
            UnityEngine.Color val_4 = UnityEngine.Color.red;
            this.timer.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
            System.DateTime val_5 = System.DateTime.UtcNow;
            System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.levelExpired}, d2:  new System.DateTime() {dateData = val_5.dateData});
            this.remainingTime = val_6;
            this.pauseMenu.gameObject.SetActive(value:  true);
        }
        public void ResumeLevel()
        {
            if((this.ftuxText.gameObject.activeSelf != true) && (this.firstLevelThisSession != true))
            {
                    this.paused = false;
            }
            
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.sliderFill.color = new UnityEngine.Color() {r = this.sliderFillColor};
            System.DateTime val_4 = System.DateTime.UtcNow;
            System.DateTime val_6 = val_4.dateData.AddMilliseconds(value:  this.remainingTime.TotalMilliseconds);
            this.levelExpired = val_6;
            this.timerHasStarted = true;
            this.pauseMenu.gameObject.SetActive(value:  false);
        }
        public void Initialize(SLC.Minigames.Whack.WhackLevel level)
        {
            UnityEngine.Transform val_13;
            bool val_14 = true;
            this.ClearUI();
            this.currentLevel = level;
            this.CreateEmptySlots();
            var val_16 = 0;
            var val_15 = 0;
            do
            {
                if(val_14 <= val_16)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_14 = val_14 + 0;
                val_13 = (true + 0) + 32.transform;
                SLC.Minigames.Whack.WhackItem val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.itemPrefab, parent:  val_13).GetComponent<SLC.Minigames.Whack.WhackItem>();
                this.whackItems.Add(item:  val_3);
                if((System.Linq.Enumerable.Contains<System.Int32>(source:  this.emptyIndices, value:  0)) != false)
            {
                    val_3.Setup(wordDefinition:  0);
            }
            else
            {
                    val_13 = level.whackWords;
                if(this.whackItems <= val_15)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3.Setup(wordDefinition:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg);
                val_15 = val_15 + 1;
            }
            
                val_16 = val_16 + 1;
            }
            while((val_16 - 1) < 6);
            
            this.timerHasStarted = false;
            string val_7 = this.timerSlider.TimeRemaining.ToString(format:  "##,##0.000");
            UnityEngine.Color val_8 = UnityEngine.Color.white;
            this.timer.color = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
            this.StartTimer();
            this.cpSlider.UpdateUI();
            if((MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.PlayerLife) == 0)
            {
                    MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.PlayerLife = 3;
            }
            
            this.UIResetLife();
            this.hammer.SetActive(value:  false);
            this.paused = false;
            if((CPlayerPrefs.GetInt(key:  "WhackFTUX", defaultValue:  0)) != 0)
            {
                goto label_31;
            }
            
            SLC.Minigames.MinigameManager val_13 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_13.currentPlayerLevel == 0)
            {
                goto label_35;
            }
            
            label_31:
            label_39:
            this.ftuxText.SetActive(value:  false);
            if(this.firstLevelThisSession == false)
            {
                    return;
            }
            
            this.paused = true;
            return;
            label_35:
            this.paused = true;
            goto label_39;
        }
        public void DisplayResult(SLC.Minigames.Whack.WhackItem item, bool won)
        {
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.displayResult(item:  item, won:  won));
        }
        private System.Collections.IEnumerator displayResult(SLC.Minigames.Whack.WhackItem item, bool won)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .item = item;
            .won = won;
            return (System.Collections.IEnumerator)new WhackUIController.<displayResult>d__30();
        }
        private void setAllWackItemsClickable(bool clickable)
        {
            List.Enumerator<T> val_1 = this.whackItems.GetEnumerator();
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            0.SetInteractable(state:  clickable);
            goto label_4;
            label_2:
            0.Dispose();
        }
        private void UIWon(SLC.Minigames.Whack.WhackItem item)
        {
            this.timerHasStarted = false;
            UnityEngine.Color val_1 = UnityEngine.Color.red;
            this.timer.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Win", clipIndex:  0, volumeScale:  1f);
            if((CPlayerPrefs.GetInt(key:  "WhackFTUX", defaultValue:  0)) == 0)
            {
                    CPlayerPrefs.SetInt(key:  "WhackFTUX", val:  1);
            }
            
            List.Enumerator<T> val_4 = this.whackItems.GetEnumerator();
            label_16:
            if(0.MoveNext() == false)
            {
                goto label_11;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(37794084 == 0)
            {
                goto label_16;
            }
            
            if(0 == 0)
            {
                goto label_14;
            }
            
            0.SetDisplayState(state:  4);
            goto label_16;
            label_14:
            0.SetDisplayState(state:  3);
            goto label_16;
            label_11:
            0.Dispose();
        }
        private void UILose(SLC.Minigames.Whack.WhackItem item)
        {
            this.UILoseLife();
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Lose", clipIndex:  0, volumeScale:  1f);
            List.Enumerator<T> val_2 = this.whackItems.GetEnumerator();
            label_14:
            if(0.MoveNext() == false)
            {
                goto label_5;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(37794084 == 0)
            {
                goto label_14;
            }
            
            if(0 == 0)
            {
                goto label_8;
            }
            
            0.SetDisplayState(state:  6);
            goto label_14;
            label_8:
            if(0 != item)
            {
                goto label_12;
            }
            
            0.SetDisplayState(state:  5);
            goto label_14;
            label_12:
            0.SetDisplayState(state:  7);
            goto label_14;
            label_5:
            0.Dispose();
        }
        public void ClearUI()
        {
            this.hammer.transform.SetParent(p:  0);
            List.Enumerator<T> val_2 = this.whackItems.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.DestroyImmediate(obj:  0.gameObject);
            goto label_8;
            label_4:
            0.Dispose();
            this.whackItems.Clear();
        }
        public void OnQuit()
        {
            this.pauseMenu.gameObject.SetActive(value:  false);
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void Update()
        {
            if(this.paused != false)
            {
                    return;
            }
            
            if(this.timerHasStarted == false)
            {
                    return;
            }
            
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.levelExpired}, d2:  new System.DateTime() {dateData = val_1.dateData});
            if(val_2._ticks.TotalMilliseconds < 0)
            {
                    this.setAllWackItemsClickable(clickable:  false);
                this.timerHasStarted = false;
                string val_4 = 0.ToString(format:  "##,##0.000");
                MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.LevelFailed(itemClicked:  0);
                return;
            }
            
            float val_7 = val_2._ticks.TimeRemaining;
            float val_10 = (float)val_2._ticks.TotalMilliseconds;
            val_10 = val_10 / 1000f;
            val_7 = val_10 / val_7;
            float val_11 = (float)val_2._ticks.TotalMilliseconds;
            val_11 = val_11 / 1000f;
            string val_9 = val_11.ToString(format:  "##,##0.000");
        }
        private void CreateEmptySlots()
        {
            RandomSet val_1 = new RandomSet();
            this.randomSet = val_1;
            val_1.addIntRange(lowest:  0, highest:  6);
            int[] val_2 = new int[2];
            val_2[0] = this.randomSet.roll(unweighted:  false);
            val_2[0] = this.randomSet.roll(unweighted:  false);
            this.emptyIndices = val_2;
        }
        private void StartTimer()
        {
            System.DateTime val_1 = System.DateTime.UtcNow;
            float val_2 = val_1.dateData.TimeRemaining;
            val_2 = val_2 * 1000f;
            System.DateTime val_3 = val_1.dateData.AddMilliseconds(value:  (double)val_2);
            this.levelExpired = val_3;
            this.timerHasStarted = true;
        }
        private void UILoseLife()
        {
            int val_2 = MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.PlayerLife;
            if(val_2 > 2)
            {
                    return;
            }
            
            var val_5 = 2;
            do
            {
                this.lives[val_5].gameObject.SetActive(value:  false);
                val_5 = val_5 - 1;
            }
            while(val_5 >= val_2);
        
        }
        private void HammerHit(SLC.Minigames.Whack.WhackItem hitDude)
        {
            this.hammer.transform.SetParent(p:  hitDude.transform);
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.up;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  100f);
            this.hammer.transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            this.hammer.gameObject.SetActive(value:  true);
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Whack", clipIndex:  0, volumeScale:  1f);
        }
        private void UIResetLife()
        {
            var val_4;
            var val_6 = 0;
            do
            {
                if(val_6 < (MonoSingleton<SLC.Minigames.Whack.WhackGameManager>.Instance.PlayerLife))
            {
                    val_4 = 1;
            }
            else
            {
                    val_4 = 0;
            }
            
                this.lives[val_6].gameObject.SetActive(value:  false);
                val_6 = val_6 + 1;
            }
            while((val_6 - 1) < 2);
        
        }
        public void PauseHack()
        {
            if(this.pauseMenu.gameObject.activeSelf != false)
            {
                    return;
            }
            
            this.paused = true;
            this.timerHasStarted = false;
            UnityEngine.Color val_3 = UnityEngine.Color.blue;
            this.sliderFill.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
            System.DateTime val_4 = System.DateTime.UtcNow;
            System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.levelExpired}, d2:  new System.DateTime() {dateData = val_4.dateData});
            this.remainingTime = val_5;
            this.Invoke(methodName:  "ResumeLevel", time:  15f);
        }
        public void StopTimerHack()
        {
            if(this.pauseMenu.gameObject.activeSelf == true)
            {
                    return;
            }
            
            this.paused = true;
            this.timerHasStarted = false;
            UnityEngine.Color val_3 = UnityEngine.Color.blue;
            this.sliderFill.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
            System.DateTime val_4 = System.DateTime.UtcNow;
            System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.levelExpired}, d2:  new System.DateTime() {dateData = val_4.dateData});
            this.remainingTime = val_5;
        }
        public void ResumeTimerHack()
        {
            this.ResumeLevel();
        }
        public WhackUIController()
        {
            this.firstLevelThisSession = true;
        }
    
    }

}
