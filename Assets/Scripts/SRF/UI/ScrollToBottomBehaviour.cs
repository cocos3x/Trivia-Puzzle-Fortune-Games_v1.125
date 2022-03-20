using UnityEngine;

namespace SRF.UI
{
    public class ScrollToBottomBehaviour : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.ScrollRect _scrollRect;
        private UnityEngine.CanvasGroup _canvasGroup;
        
        // Methods
        public void Start()
        {
            object val_4;
            if(this._scrollRect != 0)
            {
                goto label_3;
            }
            
            val_4 = "[ScrollToBottomBehaviour] ScrollRect not set";
            goto label_6;
            label_3:
            if(this._canvasGroup != 0)
            {
                goto label_9;
            }
            
            val_4 = "[ScrollToBottomBehaviour] CanvasGroup not set";
            label_6:
            UnityEngine.Debug.LogError(message:  val_4);
            return;
            label_9:
            this._scrollRect.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(object:  this, method:  System.Void SRF.UI.ScrollToBottomBehaviour::OnScrollRectValueChanged(UnityEngine.Vector2 position)));
            this.Refresh();
        }
        private void OnEnable()
        {
            this.Refresh();
        }
        public void Trigger()
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  0f);
            this._scrollRect.normalizedPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        private void OnScrollRectValueChanged(UnityEngine.Vector2 position)
        {
            this.Refresh();
        }
        private void Refresh()
        {
            var val_3;
            if(this._scrollRect == 0)
            {
                    return;
            }
            
            UnityEngine.Vector2 val_2 = this._scrollRect.normalizedPosition;
            if(val_2.y < 0)
            {
                    val_3 = 0;
            }
            else
            {
                    val_3 = 1;
            }
            
            this.SetVisible(truth:  true);
        }
        private void SetVisible(bool truth)
        {
            var val_1;
            if(truth != false)
            {
                    this._canvasGroup.alpha = 1f;
                this._canvasGroup.interactable = true;
                val_1 = 1;
            }
            else
            {
                    this._canvasGroup.alpha = 0f;
                this._canvasGroup.interactable = false;
                val_1 = 0;
            }
            
            this._canvasGroup.blocksRaycasts = false;
        }
        public ScrollToBottomBehaviour()
        {
        
        }
    
    }

}
