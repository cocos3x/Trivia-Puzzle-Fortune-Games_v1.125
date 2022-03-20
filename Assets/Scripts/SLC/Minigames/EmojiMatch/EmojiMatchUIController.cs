using UnityEngine;

namespace SLC.Minigames.EmojiMatch
{
    public class EmojiMatchUIController : MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchUIController>, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
    {
        // Fields
        private const float wait_for_answer_time = 1.5;
        private float timerSpeed;
        private SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay selectedCard;
        private SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay selectedPhrase;
        private UnityEngine.LineRenderer draggingLine;
        private UnityEngine.Transform phraseParent;
        private UnityEngine.Transform cardParent;
        private SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay matchCardPrefab;
        private SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay phraseCardPrefab;
        private UnityEngine.LineRenderer lrPrefab;
        private SLC.Minigames.MinigameLivesDisplay livesDisplay;
        private System.Collections.Generic.List<SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay> spawnedCards;
        private UnityEngine.Vector3[] linePoints;
        private UnityEngine.UI.Slider timerSlider;
        private UnityEngine.UI.Image FTUXHand;
        private UnityEngine.LineRenderer FTUXRenderer;
        private UnityEngine.UI.Text FTUXText;
        private UnityEngine.GameObject gameplayContainer;
        private UnityEngine.GameObject pausedContainer;
        private UnityEngine.UI.Button buttonQuit;
        private UnityEngine.UI.Button buttonResume;
        private UnityEngine.Canvas gameCanvas;
        private bool blockInput;
        private bool firstSession;
        private float timerDurationToWait;
        private float timerFullDuration;
        
        // Properties
        private UnityEngine.Color BrownPathColor { get; }
        private UnityEngine.Color GreenPathColor { get; }
        private UnityEngine.Color RedPathColor { get; }
        
        // Methods
        private UnityEngine.Color get_BrownPathColor()
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  0.3164063f, g:  0.2304688f, b:  0.1523438f);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        private UnityEngine.Color get_GreenPathColor()
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  0.1914063f, g:  0.6601563f, b:  0.2539063f);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        private UnityEngine.Color get_RedPathColor()
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  0.7460938f, g:  0.0390625f, b:  0.125f);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        private void Start()
        {
            System.Action<System.Boolean> val_10;
            this.buttonQuit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchUIController::OnPausedQuit()));
            this.buttonResume.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchUIController::OnPausedResume()));
            val_10 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                    SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_5.OnPauseClicked = new System.Action(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchUIController::OnPauseClicked());
                SLC.Minigames.MinigameManager val_7 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_10 = val_7.TogglePopupWindow;
                System.Delegate val_9 = System.Delegate.Combine(a:  val_10, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.EmojiMatch.EmojiMatchUIController::TogglePopupWindow(bool showUI)));
                if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_15;
            }
            
            }
            
                val_7.TogglePopupWindow = val_9;
            }
            
            this.GetAndDisplayLevel();
            this.FTUXText.enabled = true;
            return;
            label_15:
        }
        private void TogglePopupWindow(bool showUI)
        {
            if(this.gameCanvas != null)
            {
                    showUI = (~showUI) & 1;
                this.gameCanvas.enabled = showUI;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void GetAndDisplayLevel()
        {
            SLC.Minigames.EmojiMatch.EmojiMatchController val_1 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance;
            this.livesDisplay.UpdateLivesDisplay(currentHearts:  val_1.lives);
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.phraseParent);
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.cardParent);
            if(this.spawnedCards != null)
            {
                    this.spawnedCards.Clear();
            }
            else
            {
                    this.spawnedCards = new System.Collections.Generic.List<SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay>();
            }
            
            this.draggingLine.enabled = false;
            this.blockInput = false;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.getLevel();
            object val_6 = val_5.Item["Pairs"];
            if(null >= 1)
            {
                    do
            {
                this.DisplayCard(card:  val_5.Item["Emoji" + 1.ToString()], index:  0);
                this.DisplayPhrase(phrase:  val_5.Item["Phrase" + 1.ToString()], index:  0);
            }
            while(1 < null);
            
            }
            
            float val_14 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.getLevelDuration;
            this.timerDurationToWait = val_14;
            this.timerFullDuration = val_14;
            if(this.firstSession != false)
            {
                
            }
            else
            {
                    float val_16 = MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.getLevelDuration;
            }
            
            this.timerDurationToWait = val_16;
            this.timerFullDuration = val_16;
            UnityEngine.Coroutine val_18 = this.StartCoroutine(routine:  this.Timer());
        }
        private System.Collections.IEnumerator Timer()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new EmojiMatchUIController.<Timer>d__35();
        }
        private System.Collections.IEnumerator MoveFTUXHand()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new EmojiMatchUIController.<MoveFTUXHand>d__36();
        }
        private void DisplayCard(string card, int index)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay val_1 = UnityEngine.Object.Instantiate<SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay>(original:  this.matchCardPrefab, parent:  this.cardParent);
            this.spawnedCards.Add(item:  val_1);
            val_1.Init(emojiUnparsed:  card, myIndex:  index);
            if((UnityEngine.Random.Range(min:  0, max:  index + 2)) < 1)
            {
                    return;
            }
            
            val_1.transform.SetAsFirstSibling();
        }
        private void DisplayPhrase(string phrase, int index)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay val_1 = UnityEngine.Object.Instantiate<SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay>(original:  this.phraseCardPrefab, parent:  this.phraseParent);
            val_1.Init(myPhrase:  phrase, myIndex:  index);
            if((UnityEngine.Random.Range(min:  0, max:  index + 2)) < 1)
            {
                    return;
            }
            
            val_1.transform.SetAsFirstSibling();
        }
        public void SelectPhrase(SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay phrase)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay val_4;
            if(this.blockInput == true)
            {
                    return;
            }
            
            val_4 = this.selectedPhrase;
            if(val_4 != 0)
            {
                    val_4 = this.selectedPhrase;
                if(val_4 == phrase)
            {
                    return;
            }
            
                this.selectedPhrase.SetState(state:  0);
            }
            
            if(phrase != 0)
            {
                    phrase.SetState(state:  1);
            }
            
            this.selectedPhrase = phrase;
        }
        public void MaybeDeselectPhrase(SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay phrase, bool isDragging)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay val_5;
            if(this.blockInput != false)
            {
                    return;
            }
            
            if(isDragging != false)
            {
                    if(this.selectedCard == 0)
            {
                    return;
            }
            
            }
            
            val_5 = this.selectedPhrase;
            if(val_5 != 0)
            {
                    val_5 = this.selectedPhrase;
                if(val_5 == phrase)
            {
                    this.selectedPhrase.SetState(state:  0);
                this.selectedPhrase = 0;
                return;
            }
            
            }
            
            if(phrase == 0)
            {
                    return;
            }
            
            phrase.SetState(state:  0);
        }
        public void SelectCard(SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay card)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay val_4;
            if(this.blockInput == true)
            {
                    return;
            }
            
            val_4 = this.selectedCard;
            if(val_4 != 0)
            {
                    val_4 = this.selectedCard;
                if(val_4 == card)
            {
                    return;
            }
            
            }
            
            bool val_3 = UnityEngine.Object.op_Inequality(x:  card, y:  0);
            this.selectedCard = card;
        }
        public void MaybeDeselectCard(SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay card, bool isDragging)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay val_5;
            if(this.blockInput != false)
            {
                    return;
            }
            
            if(isDragging != false)
            {
                    if(this.selectedPhrase == 0)
            {
                    return;
            }
            
            }
            
            val_5 = this.selectedCard;
            if(val_5 != 0)
            {
                    val_5 = this.selectedCard;
                if(val_5 == card)
            {
                    this.selectedCard = 0;
                return;
            }
            
            }
            
            if(card == 0)
            {
                    return;
            }
            
            goto typeof(SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay).__il2cppRuntimeField_170;
        }
        private void UpdateDraggingLine()
        {
        
        }
        private bool CheckMatch()
        {
            UnityEngine.Vector3[] val_16;
            float val_17;
            var val_18;
            if(this.blockInput != true)
            {
                    val_16 = 1152921504765632512;
                if((this.selectedPhrase != 0) && (this.selectedCard != 0))
            {
                    UnityEngine.Transform val_3 = this.selectedCard.transform;
                if((this.selectedCard.<index>k__BackingField) == (this.selectedPhrase.<index>k__BackingField))
            {
                    UnityEngine.LineRenderer val_4 = UnityEngine.Object.Instantiate<UnityEngine.LineRenderer>(original:  this.lrPrefab, parent:  val_3);
                UnityEngine.Vector3[] val_5 = new UnityEngine.Vector3[2];
                val_16 = val_5;
                UnityEngine.Vector3 val_6 = this.selectedPhrase.GetLinePosition();
                val_16[0] = val_6;
                val_16[0] = val_6.y;
                val_16[1] = 1065353216;
                UnityEngine.Vector3 val_7 = this.selectedCard.GetLinePosition();
                val_16[1] = val_7;
                val_16[2] = val_7.y;
                val_16[2] = 1065353216;
                val_4.SetPositions(positions:  val_5);
                val_17 = 0.1914063f;
                UnityEngine.Color val_8 = new UnityEngine.Color(r:  val_17, g:  0.6601563f, b:  0.2539063f);
                val_4.startColor = new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a};
                UnityEngine.Color val_9 = new UnityEngine.Color(r:  val_17, g:  0.6601563f, b:  0.2539063f);
                val_4.endColor = new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a};
                this.draggingLine.enabled = false;
                this.selectedPhrase.CompleteMe(matched:  true);
                this.selectedPhrase = 0;
                val_18 = 1;
                this.selectedCard.CompleteMe(matched:  true);
                this.selectedCard = 0;
                return (bool)val_18;
            }
            
                UnityEngine.LineRenderer val_10 = UnityEngine.Object.Instantiate<UnityEngine.LineRenderer>(original:  this.lrPrefab, parent:  val_3);
                UnityEngine.Vector3[] val_11 = new UnityEngine.Vector3[2];
                val_16 = val_11;
                UnityEngine.Vector3 val_12 = this.selectedPhrase.GetLinePosition();
                val_16[0] = val_12;
                val_16[0] = val_12.y;
                val_16[1] = 1065353216;
                UnityEngine.Vector3 val_13 = this.selectedCard.GetLinePosition();
                val_16[1] = val_13;
                val_16[2] = val_13.y;
                val_16[2] = 1065353216;
                val_10.SetPositions(positions:  val_11);
                val_17 = 0.7460938f;
                UnityEngine.Color val_14 = new UnityEngine.Color(r:  val_17, g:  0.0390625f, b:  0.125f);
                val_10.startColor = new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a};
                UnityEngine.Color val_15 = new UnityEngine.Color(r:  val_17, g:  0.0390625f, b:  0.125f);
                val_10.endColor = new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a};
                this.draggingLine.enabled = false;
                this.selectedPhrase.CompleteMe(matched:  false);
                this.selectedCard.CompleteMe(matched:  false);
            }
            
            }
            
            val_18 = 0;
            return (bool)val_18;
        }
        private bool CheckGameComplete()
        {
            var val_1;
            bool val_1 = true;
            var val_2 = 0;
            label_6:
            if(val_2 >= val_1)
            {
                goto label_2;
            }
            
            if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            if(((true + 0) + 32 + 80) == 0)
            {
                goto label_5;
            }
            
            val_2 = val_2 + 1;
            if(this.spawnedCards != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_2:
            val_1 = 1;
            return (bool)val_1;
            label_5:
            val_1 = 0;
            return (bool)val_1;
        }
        private void OnLevelComplete()
        {
            this.StopAllCoroutines();
            if(this.FTUXText.enabled != false)
            {
                    this.FTUXText.enabled = false;
            }
            
            if(this.firstSession != false)
            {
                    this.firstSession = false;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                goto label_9;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) == false)
            {
                goto label_13;
            }
            
            this.ClearLevel();
            goto label_14;
            label_9:
            this.blockInput = true;
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.WaitThenReset());
            return;
            label_13:
            this.blockInput = true;
            UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.WaitThenReset());
            label_14:
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        private void UnityEngine.EventSystems.IBeginDragHandler.OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.blockInput == true)
            {
                    return;
            }
            
            if(this.selectedCard == 0)
            {
                    if(this.selectedPhrase == 0)
            {
                    return;
            }
            
            }
            
            this.draggingLine.enabled = true;
            UnityEngine.Color val_3 = new UnityEngine.Color(r:  0.3164063f, g:  0.2304688f, b:  0.1523438f);
            this.draggingLine.startColor = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
            this = this.draggingLine;
            UnityEngine.Color val_4 = new UnityEngine.Color(r:  0.3164063f, g:  0.2304688f, b:  0.1523438f);
            this.endColor = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        }
        private void UnityEngine.EventSystems.IEndDragHandler.OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            string val_11;
            if(this.blockInput != false)
            {
                    return;
            }
            
            if(this.selectedCard != 0)
            {
                    if(this.selectedPhrase != 0)
            {
                goto label_7;
            }
            
            }
            
            bool val_3 = UnityEngine.Object.op_Inequality(x:  this.selectedCard, y:  0);
            if(this.selectedPhrase != 0)
            {
                    this.selectedPhrase.SetState(state:  0);
            }
            
            this.selectedCard = 0;
            this.selectedPhrase = 0;
            this.draggingLine.enabled = false;
            return;
            label_7:
            if(this.CheckMatch() != false)
            {
                    if(this.CheckGameComplete() == false)
            {
                    return;
            }
            
                this.StopAllCoroutines();
                this.blockInput = true;
                this.FTUXRenderer.gameObject.SetActive(value:  false);
                this.FTUXHand.gameObject.SetActive(value:  false);
                val_11 = "OnLevelComplete";
            }
            else
            {
                    this.StopAllCoroutines();
                this.blockInput = true;
                this.FTUXRenderer.gameObject.SetActive(value:  false);
                this.FTUXHand.gameObject.SetActive(value:  false);
                val_11 = "OnFailure";
            }
            
            this.Invoke(methodName:  val_11, time:  1.5f);
        }
        public void OnFailure()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            if(val_1.currentPlayerLevel < 1)
            {
                    return;
            }
            
            if((MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.ShouldReset()) != false)
            {
                    this.blockInput = true;
                UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.WaitThenReset());
                return;
            }
            
            this.ClearLevel();
        }
        public void ClearLevel()
        {
            if(this.selectedCard != 0)
            {
                    this.selectedCard.CompleteMe(matched:  false);
            }
            
            this.selectedCard = 0;
            if(this.selectedPhrase != 0)
            {
                    this.selectedPhrase.CompleteMe(matched:  false);
            }
            
            this.selectedPhrase = 0;
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.cardParent);
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.phraseParent);
            this.draggingLine.enabled = false;
        }
        public void ResetLevel()
        {
            this.blockInput = true;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.WaitThenReset());
        }
        private System.Collections.IEnumerator WaitThenReset()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new EmojiMatchUIController.<WaitThenReset>d__52();
        }
        private void UnityEngine.EventSystems.IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.blockInput != false)
            {
                    return;
            }
            
            this.UpdateLineRenderer(data:  eventData);
        }
        private void UpdateLineRenderer(UnityEngine.EventSystems.PointerEventData data)
        {
            SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay val_13;
            if(this.selectedCard == 0)
            {
                    if(this.selectedPhrase == 0)
            {
                    return;
            }
            
            }
            
            if(this.selectedPhrase == 0)
            {
                goto label_12;
            }
            
            val_13 = this.selectedCard;
            if(val_13 == 0)
            {
                goto label_12;
            }
            
            UnityEngine.Vector3 val_5 = this.selectedCard.GetLinePosition();
            this.linePoints[0] = val_5;
            this.linePoints[0] = val_5.y;
            this.linePoints[0] = val_5.z;
            this.linePoints[0] = 1065353216;
            UnityEngine.Vector3 val_6 = this.selectedPhrase.GetLinePosition();
            this.linePoints[1] = val_6;
            this.linePoints[1] = val_6.y;
            this.linePoints[1] = val_6.z;
            goto label_21;
            label_12:
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
            if(this.selectedPhrase != 0)
            {
                    if(this.selectedPhrase != null)
            {
                goto label_27;
            }
            
            }
            
            label_27:
            UnityEngine.Vector3 val_9 = this.selectedCard.GetLinePosition();
            this.linePoints[0] = val_9;
            this.linePoints[0] = val_9.y;
            this.linePoints[0] = val_9.z;
            this.linePoints[0] = 1065353216;
            val_13 = UnityEngine.Camera.main;
            UnityEngine.Vector3 val_11 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = data.<position>k__BackingField, y = V8.16B});
            UnityEngine.Vector3 val_12 = val_13.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
            this.linePoints[1] = val_12;
            this.linePoints[1] = val_12.y;
            this.linePoints[1] = val_12.z;
            label_21:
            this.linePoints[1] = 1065353216;
            this.draggingLine.SetPositions(positions:  this.linePoints);
        }
        private void OnPauseClicked()
        {
            this.PauseGame(paused:  true);
        }
        public void PauseGame(bool paused)
        {
            if(paused == false)
            {
                goto label_0;
            }
            
            if(this.blockInput == false)
            {
                goto label_1;
            }
            
            return;
            label_0:
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.Timer());
            goto label_2;
            label_1:
            this.StopAllCoroutines();
            label_2:
            this.pausedContainer.SetActive(value:  paused);
            this.gameplayContainer.SetActive(value:  (~paused) & 1);
        }
        public void UnpauseForRestart()
        {
            this.StopAllCoroutines();
            this.pausedContainer.SetActive(value:  false);
            this.gameplayContainer.SetActive(value:  true);
        }
        private void OnPausedQuit()
        {
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void OnPausedResume()
        {
            this.PauseGame(paused:  false);
        }
        public void SetTimerSpeedForHack(float speed)
        {
            this.timerSpeed = speed;
        }
        public EmojiMatchUIController()
        {
            this.timerSpeed = 1f;
            this.linePoints = new UnityEngine.Vector3[2];
            this.firstSession = true;
        }
    
    }

}
