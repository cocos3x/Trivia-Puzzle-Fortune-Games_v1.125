using UnityEngine;

namespace SRDebugger.UI
{
    public class MobileMenuController : SRMonoBehaviourEx
    {
        // Fields
        private UnityEngine.UI.Button _closeButton;
        private float _maxMenuWidth;
        private float _peekAmount;
        private float _targetXPosition;
        public UnityEngine.RectTransform Content;
        public UnityEngine.RectTransform Menu;
        public UnityEngine.UI.Button OpenButton;
        public SRDebugger.UI.Other.SRTabController TabController;
        
        // Properties
        public float PeekAmount { get; }
        public float MaxMenuWidth { get; }
        
        // Methods
        public float get_PeekAmount()
        {
            return (float)this._peekAmount;
        }
        public float get_MaxMenuWidth()
        {
            return (float)this._maxMenuWidth;
        }
        protected override void OnEnable()
        {
            var val_16;
            this.OnEnable();
            UnityEngine.Transform val_1 = this.Menu.parent;
            if(val_1 != null)
            {
                    var val_2 = (null == null) ? (val_1) : 0;
            }
            else
            {
                    val_16 = 0;
            }
            
            UnityEngine.UI.LayoutElement val_3 = this.Menu.GetComponent<UnityEngine.UI.LayoutElement>();
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  1f, y:  1f);
            this.Menu.pivot = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  1f, y:  0f);
            this.Menu.offsetMin = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  1f, y:  1f);
            this.Menu.offsetMax = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
            UnityEngine.Rect val_7 = val_16.rect;
            float val_8 = val_7.m_XMin.width;
            val_8 = val_8 - this._peekAmount;
            this.Menu.SetSizeWithCurrentAnchors(axis:  0, size:  UnityEngine.Mathf.Clamp(value:  val_8, min:  0f, max:  this._maxMenuWidth));
            UnityEngine.Rect val_10 = val_16.rect;
            this.Menu.SetSizeWithCurrentAnchors(axis:  1, size:  val_10.m_XMin.height);
            UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  0f, y:  0f);
            this.Menu.anchoredPosition = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
            if(this._closeButton == 0)
            {
                    this.CreateCloseButton();
            }
            
            this.OpenButton.gameObject.SetActive(value:  true);
            this.TabController.add_ActiveTabChanged(value:  new System.Action<SRDebugger.UI.Other.SRTabController, SRDebugger.UI.Other.SRTab>(object:  this, method:  System.Void SRDebugger.UI.MobileMenuController::TabControllerOnActiveTabChanged(SRDebugger.UI.Other.SRTabController srTabController, SRDebugger.UI.Other.SRTab srTab)));
        }
        protected override void OnDisable()
        {
            this.OnDisable();
            UnityEngine.UI.LayoutElement val_1 = this.Menu.GetComponent<UnityEngine.UI.LayoutElement>();
            UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  0f, y:  0f);
            this.Content.anchoredPosition = new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
            this._closeButton.gameObject.SetActive(value:  false);
            this.OpenButton.gameObject.SetActive(value:  false);
            this.TabController.remove_ActiveTabChanged(value:  new System.Action<SRDebugger.UI.Other.SRTabController, SRDebugger.UI.Other.SRTab>(object:  this, method:  System.Void SRDebugger.UI.MobileMenuController::TabControllerOnActiveTabChanged(SRDebugger.UI.Other.SRTabController srTabController, SRDebugger.UI.Other.SRTab srTab)));
        }
        private void CreateCloseButton()
        {
            UnityEngine.GameObject val_1 = SRF.SRFTransformExtensions.CreateChild(t:  this.Content, name:  "SR_CloseButtonCanvas");
            UnityEngine.Canvas val_2 = val_1.AddComponent<UnityEngine.Canvas>();
            UnityEngine.UI.GraphicRaycaster val_3 = val_1.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            UnityEngine.RectTransform val_4 = SRF.SRFGameObjectExtensions.GetComponentOrAdd<UnityEngine.RectTransform>(obj:  val_1);
            val_2.overrideSorting = true;
            val_2.sortingOrder = 122;
            UnityEngine.UI.LayoutElement val_5 = val_1.AddComponent<UnityEngine.UI.LayoutElement>();
            this.SetRectSize(rect:  val_4);
            UnityEngine.GameObject val_6 = SRF.SRFTransformExtensions.CreateChild(t:  val_4, name:  "SR_CloseButton");
            this.SetRectSize(rect:  val_6.AddComponent<UnityEngine.RectTransform>());
            UnityEngine.Color val_9 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
            val_6.AddComponent<UnityEngine.UI.Image>().color = new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a};
            UnityEngine.UI.Button val_10 = val_6.AddComponent<UnityEngine.UI.Button>();
            this._closeButton = val_10;
            val_10.transition = 0;
            this._closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SRDebugger.UI.MobileMenuController::CloseButtonClicked()));
            this._closeButton.gameObject.SetActive(value:  false);
        }
        private void SetRectSize(UnityEngine.RectTransform rect)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  0f);
            rect.anchorMin = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
            UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  1f, y:  1f);
            rect.anchorMax = new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
            UnityEngine.Rect val_3 = this.Content.rect;
            rect.SetSizeWithCurrentAnchors(axis:  0, size:  val_3.m_XMin.width);
            UnityEngine.Rect val_5 = this.Content.rect;
            rect.SetSizeWithCurrentAnchors(axis:  1, size:  val_5.m_XMin.height);
        }
        private void CloseButtonClicked()
        {
            this.Close();
        }
        protected override void Update()
        {
            float val_8;
            float val_9;
            this.Update();
            UnityEngine.Vector2 val_1 = this.Content.anchoredPosition;
            val_8 = this._targetXPosition;
            val_8 = this._targetXPosition;
            val_8 = this._targetXPosition;
            val_1.x = this._targetXPosition ?? val_1.x;
            val_9 = 2.5f;
            if(val_1.x < 0)
            {
                    UnityEngine.Vector2 val_2 = this.Content.anchoredPosition;
                UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_8, y:  val_2.y);
            }
            else
            {
                    val_9 = val_8;
                val_8 = SRMath.SpringLerp(from:  val_1.x, to:  val_9, strength:  15f, deltaTime:  UnityEngine.Time.unscaledDeltaTime);
                UnityEngine.Vector2 val_6 = this.Content.anchoredPosition;
                UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_8, y:  val_6.y);
            }
            
            this.Content.anchoredPosition = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
        }
        private void TabControllerOnActiveTabChanged(SRDebugger.UI.Other.SRTabController srTabController, SRDebugger.UI.Other.SRTab srTab)
        {
            this.Close();
        }
        public void Open()
        {
            UnityEngine.Rect val_1 = this.Menu.rect;
            this._targetXPosition = val_1.m_XMin.width;
            this._closeButton.gameObject.SetActive(value:  true);
        }
        public void Close()
        {
            this._targetXPosition = 0f;
            this._closeButton.gameObject.SetActive(value:  false);
        }
        public MobileMenuController()
        {
            this._maxMenuWidth = 185f;
            this._peekAmount = 45f;
        }
    
    }

}
