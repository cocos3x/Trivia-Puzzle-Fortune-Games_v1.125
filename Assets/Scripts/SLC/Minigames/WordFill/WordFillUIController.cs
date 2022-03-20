using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WordFillUIController : MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>
    {
        // Fields
        private UnityEngine.Canvas canvas;
        private UnityEngine.Canvas pauseCanvas;
        private UnityEngine.GameObject blur;
        private BlurCanvas blurCanvas;
        private UnityEngine.UI.Slider lifeMeter;
        private UnityEngine.GameObject lifeGainIndicator;
        private WFLifeIcon lifeCountIndicator1;
        private WFLifeIcon lifeCountIndicator2;
        private WFLifeIcon lifeCountIndicator3;
        private UnityEngine.UI.Text categoryText;
        private UnityEngine.UI.Text spellingWord;
        private UnityEngine.Transform boardTransform;
        private UnityEngine.GameObject boardLetter;
        private UnityEngine.UI.Button pauseButton;
        private UnityEngine.UI.Button quitButton;
        private UnityEngine.UI.Button resumeButton;
        private bool init;
        private float remainingTime;
        private float extraWordBonusDisplay;
        private float completedWordDisplay;
        private bool started;
        private bool ended;
        private bool overlay;
        private float endTimer;
        private SLC.Minigames.WordFill.WordFillLevel currentLevel;
        private System.Collections.Generic.List<WFLetter> allLetters;
        private System.Collections.Generic.List<WFLetter> spelling;
        private System.Collections.Generic.List<System.Collections.Generic.HashSet<int>> usedPaths;
        
        // Methods
        public override void InitMonoSingleton()
        {
            this.pauseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillUIController::OnClick_Pause()));
            this.quitButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillUIController::OnClick_Quit()));
            this.resumeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillUIController::OnClick_Resume()));
        }
        private void Start()
        {
        
        }
        public void Initialize()
        {
            if(this.init != false)
            {
                    return;
            }
            
            this.init = true;
        }
        private void Update()
        {
            float val_13;
            if(this.overlay != false)
            {
                    return;
            }
            
            float val_1 = UnityEngine.Time.deltaTime;
            val_1 = this.extraWordBonusDisplay - val_1;
            this.extraWordBonusDisplay = val_1;
            float val_2 = UnityEngine.Time.deltaTime;
            val_2 = this.completedWordDisplay - val_2;
            this.completedWordDisplay = val_2;
            this.RefreshPlayerDisplay();
            if((this.started == false) || ((this.pauseCanvas.enabled == true) || (this.ended == true)))
            {
                goto label_5;
            }
            
            WordFillFTUXManager val_4 = MonoSingleton<WordFillFTUXManager>.Instance;
            val_13 = this.remainingTime;
            if((val_4.<ftux>k__BackingField) != true)
            {
                    val_13 = val_13 - UnityEngine.Time.deltaTime;
                this.remainingTime = val_13;
            }
            
            if(val_13 <= 0f)
            {
                goto label_10;
            }
            
            this.HandleInput();
            label_5:
            if(this.ended == false)
            {
                    return;
            }
            
            float val_6 = UnityEngine.Time.deltaTime;
            val_6 = this.endTimer - val_6;
            this.endTimer = val_6;
            if(val_6 > 0f)
            {
                    return;
            }
            
            SLC.Minigames.WordFill.WordFillManager val_7 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            UnityEngine.Coroutine val_9 = val_7.StartCoroutine(routine:  val_7.OnStartNextLevel());
            this.started = false;
            this.ended = false;
            return;
            label_10:
            MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance.LostLife();
            this.endTimer = 1.5f;
            this.ended = true;
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Lose", clipIndex:  0, volumeScale:  1f);
        }
        private void HandleInput()
        {
            var val_22;
            float val_23;
            string val_68;
            var val_69;
            UnityEngine.Object val_70;
            UnityEngine.Object val_71;
            System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Int32>> val_77;
            val_68 = 1152921504762331136;
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            if(UnityEngine.Input.touchCount < 1)
            {
                goto label_3;
            }
            
            UnityEngine.Touch val_3 = UnityEngine.Input.GetTouch(index:  0);
            val_69 = phase;
            UnityEngine.Touch val_5 = UnityEngine.Input.GetTouch(index:  0);
            val_71 = 0;
            UnityEngine.Vector2 val_6 = position;
            goto label_4;
            label_3:
            if(((UnityEngine.Input.GetMouseButton(button:  0)) == true) || ((UnityEngine.Input.GetMouseButtonDown(button:  0)) == true))
            {
                goto label_6;
            }
            
            val_71 = 0;
            if((UnityEngine.Input.GetMouseButtonUp(button:  0)) == false)
            {
                goto label_7;
            }
            
            label_6:
            val_71 = 0;
            val_69 = 0;
            if((UnityEngine.Input.GetMouseButtonDown(button:  0)) != true)
            {
                    if((UnityEngine.Input.GetMouseButton(button:  0)) != false)
            {
                    if((UnityEngine.Input.GetMouseButtonDown(button:  0)) != true)
            {
                    if((UnityEngine.Input.GetMouseButtonUp(button:  0)) == false)
            {
                goto label_128;
            }
            
            }
            
            }
            
                val_71 = 0;
            }
            
            label_128:
            UnityEngine.Vector3 val_16 = UnityEngine.Input.mousePosition;
            val_70 = 0;
            UnityEngine.Vector2 val_17 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
            label_4:
            if((((UnityEngine.Input.GetMouseButtonUp(button:  0)) != true) ? (2 + 1) : 2) > 3)
            {
                    return;
            }
            
            var val_65 = 32560608 + (val_14 != true ? (2 + 1) : 2) << 2;
            val_65 = val_65 + 32560608;
            goto (32560608 + (val_14 != true ? (2 + 1) : 2) << 2 + 32560608);
            label_7:
            val_70 = this.spelling;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_21 = val_70.GetEnumerator();
            label_31:
            val_71 = public System.Boolean List.Enumerator<WFLetter>::MoveNext();
            if(val_23.MoveNext() == false)
            {
                goto label_29;
            }
            
            val_70 = val_22;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_70.SetAvailable();
            goto label_31;
            label_35:
            val_71 = public System.Boolean List.Enumerator<WFLetter>::MoveNext();
            val_68 = "";
            if(val_23.MoveNext() == false)
            {
                goto label_33;
            }
            
            val_70 = val_22;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_29 = val_68 + val_70.Letter.ToString();
            goto label_35;
            label_33:
            val_71 = public System.Void List.Enumerator<WFLetter>::Dispose();
            val_23.Dispose();
            System.Collections.Generic.HashSet<System.Int32> val_37 = this.ConstructSpellingPath();
            WordFillFTUXManager val_38 = MonoSingleton<WordFillFTUXManager>.Instance;
            if(val_38 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 0;
            if(val_38.RequiredFtuxAnswer() != null)
            {
                    WordFillFTUXManager val_40 = MonoSingleton<WordFillFTUXManager>.Instance;
                if(val_40 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_71 = val_68;
                if((System.String.op_Inequality(a:  val_40.RequiredFtuxAnswer(), b:  val_71)) != false)
            {
                    if(val_37 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_68 = "";
                val_70 = val_37;
                val_71 = public System.Void System.Collections.Generic.HashSet<System.Int32>::Clear();
                val_70.Clear();
            }
            
            }
            
            if(this.currentLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            val_70 = this.currentLevel.answers;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_68;
            bool val_43 = val_70.Contains(item:  val_71);
            if(val_43 == false)
            {
                goto label_74;
            }
            
            if(this.currentLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = this.currentLevel.answerPaths;
            bool val_44 = val_43.ContainsPath(pathset:  val_71, newpath:  val_37);
            if(val_44 == false)
            {
                goto label_76;
            }
            
            val_70 = this.spelling;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_45 = val_70.GetEnumerator();
            label_80:
            if(val_23.MoveNext() == false)
            {
                goto label_78;
            }
            
            val_22.SetUsed();
            goto label_80;
            label_29:
            val_71 = public System.Void List.Enumerator<WFLetter>::Dispose();
            val_23.Dispose();
            val_70 = this.spelling;
            if(val_70 != null)
            {
                goto label_81;
            }
            
            throw new NullReferenceException();
            label_74:
            val_77 = this.usedPaths;
            val_71 = mem[this.usedPaths];
            val_71 = this.usedPaths.SyncRoot;
            if((val_43.ContainsPath(pathset:  val_71, newpath:  val_37)) == true)
            {
                goto label_88;
            }
            
            SLC.Minigames.WordFill.WordFillManager val_48 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            val_71 = 0;
            if(val_48 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = ToLower();
            val_70 = val_48;
            if((val_70.IsValidWord(word:  val_71)) == false)
            {
                goto label_88;
            }
            
            this.GainExtraWordBonus();
            MinigameAudioController val_51 = MonoSingleton<MinigameAudioController>.Instance;
            if(val_51 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 2;
            val_51.PlayButtonSound(clipIndex:  2, volumeScale:  1f);
            val_70 = mem[this.usedPaths];
            val_70 = this.usedPaths.SyncRoot;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_37;
            val_70.Add(item:  val_71);
            WordFillFTUXManager val_52 = MonoSingleton<WordFillFTUXManager>.Instance;
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 0;
            val_52.FtuxProceed();
            goto label_98;
            label_88:
            if(this.spelling == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.spelling >= 1)
            {
                    MinigameAudioController val_53 = MonoSingleton<MinigameAudioController>.Instance;
                if(val_53 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_71 = 3;
                val_53.PlayButtonSound(clipIndex:  3, volumeScale:  1f);
            }
            
            label_98:
            val_70 = this.spelling;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_54 = val_70.GetEnumerator();
            label_105:
            val_71 = public System.Boolean List.Enumerator<WFLetter>::MoveNext();
            if(val_23.MoveNext() == false)
            {
                goto label_124;
            }
            
            val_70 = val_22;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_70.SetAvailable();
            goto label_105;
            label_76:
            val_77 = this;
            val_71 = this.usedPaths;
            if((val_44.ContainsPath(pathset:  val_71, newpath:  val_37)) == false)
            {
                goto label_106;
            }
            
            MinigameAudioController val_57 = MonoSingleton<MinigameAudioController>.Instance;
            if(val_57 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 3;
            val_57.PlayButtonSound(clipIndex:  3, volumeScale:  1f);
            goto label_110;
            label_78:
            val_71 = public System.Void List.Enumerator<WFLetter>::Dispose();
            val_23.Dispose();
            MinigameAudioController val_58 = MonoSingleton<MinigameAudioController>.Instance;
            if(val_58 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 2;
            val_58.PlayButtonSound(clipIndex:  2, volumeScale:  1f);
            val_70 = this.usedPaths;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_37;
            val_70.Add(item:  val_71);
            this.CheckWin();
            WordFillFTUXManager val_59 = MonoSingleton<WordFillFTUXManager>.Instance;
            if(val_59 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 0;
            val_59.FtuxProceed();
            goto label_145;
            label_106:
            this.GainExtraWordBonus();
            MinigameAudioController val_60 = MonoSingleton<MinigameAudioController>.Instance;
            if(val_60 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = 2;
            val_60.PlayButtonSound(clipIndex:  2, volumeScale:  1f);
            val_70 = null;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_71 = val_37;
            val_70.Add(item:  val_71);
            label_110:
            val_70 = this.spelling;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_61 = val_70.GetEnumerator();
            label_126:
            val_71 = public System.Boolean List.Enumerator<WFLetter>::MoveNext();
            if(val_23.MoveNext() == false)
            {
                goto label_124;
            }
            
            val_70 = val_22;
            if(val_70 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_70.SetAvailable();
            goto label_126;
            label_124:
            val_71 = public System.Void List.Enumerator<WFLetter>::Dispose();
            val_23.Dispose();
            label_145:
            val_70 = this.spelling;
            this.completedWordDisplay = 2f;
            if(val_70 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_81:
            val_70.Clear();
        }
        private WFLetter GetTouchedLetter(UnityEngine.Vector2 touchPos)
        {
            var val_12;
            var val_18;
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = touchPos.x, y = touchPos.y});
            UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  val_3.x, y:  val_3.y);
            UnityEngine.Vector3 val_7 = UnityEngine.Camera.main.transform.forward;
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
            UnityEngine.RaycastHit2D val_9 = UnityEngine.Physics2D.Raycast(origin:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, direction:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
            val_18 = 0;
            if(val_12.collider == 0)
            {
                    return (WFLetter)val_12.transform.gameObject.GetComponent<WFLetter>();
            }
            
            return (WFLetter)val_12.transform.gameObject.GetComponent<WFLetter>();
        }
        public void ToggleUI(bool show)
        {
            if(this.canvas != null)
            {
                    this.canvas.enabled = show;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void RefreshPlayerDisplay()
        {
            SLC.Minigames.WordFill.WordFillManager val_1 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            this.lifeCountIndicator1.SetAlive(alive:  ((val_1.<playerLives>k__BackingField) > 0) ? 1 : 0);
            SLC.Minigames.WordFill.WordFillManager val_3 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            this.lifeCountIndicator2.SetAlive(alive:  ((val_3.<playerLives>k__BackingField) > 1) ? 1 : 0);
            SLC.Minigames.WordFill.WordFillManager val_5 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            this.lifeCountIndicator3.SetAlive(alive:  ((val_5.<playerLives>k__BackingField) > 2) ? 1 : 0);
            SLC.Minigames.WordFill.WordFillManager val_7 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            float val_10 = UnityEngine.Mathf.Min(a:  UnityEngine.Mathf.Max(a:  this.remainingTime / (val_7.<playerLevelTime>k__BackingField), b:  0f), b:  1f);
            this.lifeGainIndicator.SetActive(value:  (this.extraWordBonusDisplay > 0f) ? 1 : 0);
            if(this.completedWordDisplay > 0f)
            {
                    return;
            }
            
            1152921519821593824 = "";
            List.Enumerator<T> val_12 = this.spelling.GetEnumerator();
            label_18:
            if(0.MoveNext() == false)
            {
                goto label_16;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_16 = 1152921519821593824 + 0.Letter.ToString();
            goto label_18;
            label_16:
            0.Dispose();
        }
        private void GainExtraWordBonus()
        {
            this.extraWordBonusDisplay = 2f;
            SLC.Minigames.WordFill.WordFillManager val_1 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            float val_3 = 5f;
            val_3 = this.remainingTime + val_3;
            this.remainingTime = UnityEngine.Mathf.Min(a:  val_3, b:  val_1.<playerLevelTime>k__BackingField);
        }
        private void CheckWin()
        {
            List.Enumerator<T> val_1 = this.allLetters.GetEnumerator();
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(0 != 0)
            {
                goto label_4;
            }
            
            0.Dispose();
            return;
            label_2:
            0.Dispose();
            MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance.BeatLevel();
            this.endTimer = 1.5f;
            this.ended = true;
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Win", clipIndex:  0, volumeScale:  1f);
        }
        public void StartLevel(SLC.Minigames.WordFill.WordFillLevel level)
        {
            var val_8;
            if(this.init != true)
            {
                    this.init = true;
            }
            
            this.blur.SetActive(value:  false);
            this.pauseCanvas.enabled = false;
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
            this.currentLevel = level;
            SLC.Minigames.WordFill.WordFillManager val_2 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            this.remainingTime = val_2.<playerLevelTime>k__BackingField;
            SLC.Minigames.WordFill.WordFillManager val_3 = MonoSingleton<SLC.Minigames.WordFill.WordFillManager>.Instance;
            val_8 = 1152921519821956800;
            this.allLetters.Clear();
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.boardTransform);
            this.usedPaths.Clear();
            this.spelling.Clear();
            this.started = true;
            this.ended = false;
            this.overlay = false;
            this.endTimer = 0f;
            this.extraWordBonusDisplay = 0f;
            this.completedWordDisplay = 0f;
            this.boardTransform.GetComponent<UnityEngine.UI.GridLayoutGroup>().constraintCount = -2012798256;
            if(1152921515478950608 >= 1)
            {
                    var val_8 = 0;
                WFLetter val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.boardLetter, parent:  this.boardTransform).GetComponent<WFLetter>();
                this.allLetters.Add(item:  val_6);
                val_6.Letter = val_6;
                val_6.SetGridPos(x:  0, y:  0);
                val_8 = val_8 + 1;
            }
            
            val_8 = 0 + 1;
            this.RefreshPlayerDisplay();
            MonoSingleton<WordFillFTUXManager>.Instance.FtuxProceed();
        }
        private System.Collections.Generic.HashSet<int> ConstructSpellingPath()
        {
            System.Collections.Generic.HashSet<System.Int32> val_1 = new System.Collections.Generic.HashSet<System.Int32>();
            List.Enumerator<T> val_2 = this.spelling.GetEnumerator();
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(this.currentLevel == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_5 = val_1.Add(item:  41868256 + (this.currentLevel * 0));
            goto label_6;
            label_2:
            0.Dispose();
            return val_1;
        }
        private bool ContainsPath(System.Collections.Generic.List<System.Collections.Generic.HashSet<int>> pathset, System.Collections.Generic.HashSet<int> newpath)
        {
            int val_2;
            var val_3;
            var val_13;
            var val_14;
            var val_15;
            var val_16;
            List.Enumerator<T> val_1 = pathset.GetEnumerator();
            var val_11 = 0;
            label_10:
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_13 = val_2;
            if(val_13 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(newpath == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_2 + 32) != W9)
            {
                goto label_10;
            }
            
            HashSet.Enumerator<T> val_5 = newpath.GetEnumerator();
            val_14 = 1;
            goto label_6;
            label_7:
            val_14 = val_14 & (val_13.Contains(item:  val_2));
            label_6:
            if(val_3.MoveNext() == true)
            {
                goto label_7;
            }
            
            val_15 = val_11 + 1;
            val_13 = 0;
            mem2[0] = 88;
            val_3.Dispose();
            if(val_13 != 0)
            {
                    throw val_13;
            }
            
            if(val_15 != 1)
            {
                    var val_8 = ((1152921519823483152 + ((0 + 1)) << 2) == 88) ? 1 : 0;
                val_8 = ((val_15 >= 0) ? 1 : 0) & val_8;
                val_15 = val_15 - val_8;
            }
            
            if(val_14 == false)
            {
                goto label_10;
            }
            
            goto label_11;
            label_2:
            val_11 = val_11 + 1;
            mem2[0] = 121;
            val_3.Dispose();
            label_17:
            if(val_11 != 1)
            {
                    val_16 = 0 & (((1152921519823483152 + ((0 + 1)) << 2) == 123) ? 1 : 0);
                return (bool)val_16;
            }
            
            val_16 = 0;
            return (bool)val_16;
            label_11:
            val_15 = val_15 + 1;
            mem2[0] = 123;
            val_3.Dispose();
            goto label_17;
        }
        private void OnClick_Pause()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.blur.SetActive(value:  true);
            this.blurCanvas.DoBlur();
            this.pauseCanvas.enabled = true;
        }
        private void OnClick_Quit()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleHomeClicked(redirectToGameplay:  false);
        }
        private void OnClick_Resume()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.blur.SetActive(value:  false);
            this.blurCanvas.StopBlur();
            this.pauseCanvas.enabled = false;
        }
        public void SetOverlay(bool o)
        {
            this.overlay = o;
        }
        public UnityEngine.Transform GetGridPos(int x, int y)
        {
            int val_1 = y;
            SLC.Minigames.WordFill.WordFillLevel val_2 = this.currentLevel;
            val_1 = x + (val_2 * val_1);
            if(W9 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + (val_1 << 3);
            return (this.currentLevel + ((this.currentLevel * y) + x) << 3).answers.transform;
        }
        public WordFillUIController()
        {
            this.allLetters = new System.Collections.Generic.List<WFLetter>();
            this.spelling = new System.Collections.Generic.List<WFLetter>();
            this.usedPaths = new System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Int32>>();
        }
    
    }

}
