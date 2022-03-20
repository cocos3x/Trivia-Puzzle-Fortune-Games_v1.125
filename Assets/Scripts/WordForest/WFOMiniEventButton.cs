using UnityEngine;

namespace WordForest
{
    public class WFOMiniEventButton : MonoBehaviour
    {
        // Fields
        protected UnityEngine.CanvasGroup canvasGroup;
        protected UnityEngine.UI.Image notifBadgeIcon;
        protected UnityEngine.UI.Text buttonLabel;
        protected UGUINetworkedButton eventButton;
        protected WGEventHandler eventHandler;
        
        // Properties
        public string EventType { get; }
        
        // Methods
        public string get_EventType()
        {
            if(this.eventHandler == null)
            {
                    return (string)this.eventHandler;
            }
            
            return this.eventHandler.EventType;
        }
        protected virtual void Awake()
        {
            UGUINetworkedButton val_1 = this.GetComponent<UGUINetworkedButton>();
            this.eventButton = val_1;
            if(val_1 == 0)
            {
                    return;
            }
            
            System.Delegate val_4 = System.Delegate.Combine(a:  this.eventButton.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  typeof(WordForest.WFOMiniEventButton).__il2cppRuntimeField_1A8));
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_6;
            }
            
            }
            
            this.eventButton.OnConnectionClick = val_4;
            return;
            label_6:
        }
        public virtual void Initialize(WGEventHandler handler)
        {
            this.eventHandler = handler;
        }
        public virtual void Refresh()
        {
            if(this.eventHandler == null)
            {
                    return;
            }
            
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        protected virtual void OnButtonClick(bool isConnected)
        {
            var val_6;
            var val_7;
            val_6 = this;
            if(this.eventHandler != null)
            {
                    val_7 = isConnected;
                if((this.eventHandler & 1) == 0)
            {
                    if((this.eventHandler & 1) == 0)
            {
                goto label_3;
            }
            
            }
            
            }
            
            val_6 = ???;
            val_7 = ???;
            goto typeof(WordForest.WFOMiniEventButton).__il2cppRuntimeField_1B0;
            label_3:
            var val_3 = val_7 & 1;
            goto val_6 + 56 + 592;
        }
        public virtual void OnEventEnded()
        {
            UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        public void ShowIntroAnimation()
        {
            this.canvasGroup.alpha = 0f;
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void WordForest.WFOMiniEventButton::<ShowIntroAnimation>b__12_0()), count:  1);
        }
        public WFOMiniEventButton()
        {
        
        }
        private void <ShowIntroAnimation>b__12_0()
        {
            UnityEngine.Transform val_2 = this.gameObject.transform;
            if(null == null)
            {
                    UnityEngine.Vector2 val_3 = val_2.anchoredPosition;
                UnityEngine.Vector2 val_4 = val_2.anchoredPosition;
                UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  500f, y:  0f);
                UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y}, b:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y});
                val_2.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
                DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  val_2, endValue:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, duration:  1f, snapping:  false), ease:  27);
                DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  1f);
                return;
            }
        
        }
    
    }

}
