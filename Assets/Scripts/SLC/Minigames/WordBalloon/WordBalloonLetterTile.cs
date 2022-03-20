using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonLetterTile : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler
    {
        // Fields
        private UnityEngine.UI.Text label;
        private UnityEngine.UI.Image sprite;
        private string value;
        public bool interactable;
        private SLC.Minigames.WordBalloon.WordBalloonLetterSlot parentSlot;
        private SLC.Minigames.WordBalloon.LetterTileState currentState;
        private bool isHighlighted;
        private DG.Tweening.Tweener moveTween;
        
        // Properties
        public string Value { get; }
        
        // Methods
        public string get_Value()
        {
            return (string)this.value;
        }
        public void Initialize(SLC.Minigames.WordBalloon.WordBalloonLetterSlot slotToAttachTo, string letter)
        {
            this.parentSlot = slotToAttachTo;
            this.value = letter;
            this.currentState = 0;
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnGridChanged, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonLetterTile::OnGridChanged()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_6;
            }
            
            }
            
            val_1.OnGridChanged = val_3;
            this.UpdatePosition(isAnimated:  false, delayed:  true);
            return;
            label_6:
        }
        private void OnDestroy()
        {
            SLC.Minigames.WordBalloon.WordBalloonGrid val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnGridChanged, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.WordBalloon.WordBalloonLetterTile::OnGridChanged()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnGridChanged = val_3;
            return;
            label_5:
        }
        private void OnGridChanged()
        {
            this.UpdatePosition(isAnimated:  true, delayed:  true);
        }
        private void UpdatePosition(bool isAnimated, bool delayed)
        {
            if(delayed != false)
            {
                    isAnimated = isAnimated;
                UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdatePositionDelayed(isAnimated:  isAnimated));
                return;
            }
            
            if(this.moveTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.moveTween, complete:  false);
            }
            
            UnityEngine.Transform val_4 = this.gameObject.transform;
            UnityEngine.Vector3 val_6 = this.parentSlot.transform.position;
            if(isAnimated != false)
            {
                    this.moveTween = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  val_4, endValue:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, duration:  0.55f, snapping:  false), ease:  30);
                return;
            }
            
            val_4.position = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        }
        private System.Collections.IEnumerator UpdatePositionDelayed(bool isAnimated)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .isAnimated = isAnimated;
            return (System.Collections.IEnumerator)new WordBalloonLetterTile.<UpdatePositionDelayed>d__14();
        }
        public void ChangeState(SLC.Minigames.WordBalloon.LetterTileState incomingState)
        {
            if(incomingState == 1)
            {
                goto label_0;
            }
            
            if(incomingState != 0)
            {
                goto label_3;
            }
            
            if(this.isHighlighted == false)
            {
                goto label_2;
            }
            
            this.Highlight();
            goto label_3;
            label_0:
            UnityEngine.Color val_1 = this.sprite.color;
            goto label_6;
            label_2:
            UnityEngine.Color val_2 = this.sprite.color;
            label_6:
            this.sprite.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = 1f};
            label_3:
            this.currentState = incomingState;
        }
        public void Highlight()
        {
            UnityEngine.Color val_1 = this.sprite.color;
            this.sprite.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = 0.15f};
            this.isHighlighted = true;
        }
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            var val_4;
            if(this.interactable == false)
            {
                    return;
            }
            
            val_4 = 1152921504893161472;
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.OnPointerDown(eventData:  eventData);
            SLC.Minigames.WordBalloon.WordBalloonManager val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_2.<MinigameState>k__BackingField) != 1)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.RegisterSlotForInput(incomingSlot:  this.parentSlot);
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.interactable == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.OnPointerUp(eventData:  eventData);
        }
        public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData pointerEventData)
        {
            if(this.interactable == false)
            {
                    return;
            }
            
            SLC.Minigames.WordBalloon.WordBalloonManager val_1 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonManager>.Instance;
            if((val_1.<MinigameState>k__BackingField) != 1)
            {
                    return;
            }
            
            SLC.Minigames.WordBalloon.WordBalloonGrid val_2 = MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance;
            if(val_2.isInputModeOn == false)
            {
                    return;
            }
            
            MonoSingleton<SLC.Minigames.WordBalloon.WordBalloonGrid>.Instance.RegisterSlotForInput(incomingSlot:  this.parentSlot);
        }
        public WordBalloonLetterTile()
        {
            this.interactable = true;
        }
    
    }

}
