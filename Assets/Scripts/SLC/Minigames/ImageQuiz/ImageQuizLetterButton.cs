using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizLetterButton : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button button;
        private string _letter;
        private SLC.Minigames.ImageQuiz.ImageQuizLetterButton.HighlightState <CurrentHighlightState>k__BackingField;
        private UnityEngine.UI.Image spriteDefault;
        private UnityEngine.UI.Image spriteHighlighted;
        private UnityEngine.UI.Text letterLabel;
        private bool <IsUsed>k__BackingField;
        private UnityEngine.RectTransform rectTransform;
        private DG.Tweening.Tweener buttonTweener;
        
        // Properties
        public string Letter { get; }
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButton.HighlightState CurrentHighlightState { get; set; }
        public bool IsUsed { get; set; }
        public bool Interactable { get; set; }
        
        // Methods
        public string get_Letter()
        {
            return (string)this._letter;
        }
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButton.HighlightState get_CurrentHighlightState()
        {
            return (HighlightState)this.<CurrentHighlightState>k__BackingField;
        }
        private void set_CurrentHighlightState(SLC.Minigames.ImageQuiz.ImageQuizLetterButton.HighlightState value)
        {
            this.<CurrentHighlightState>k__BackingField = value;
        }
        public bool get_IsUsed()
        {
            return (bool)this.<IsUsed>k__BackingField;
        }
        private void set_IsUsed(bool value)
        {
            this.<IsUsed>k__BackingField = value;
        }
        public bool get_Interactable()
        {
            if(this.button != null)
            {
                    return (bool)this;
            }
            
            throw new NullReferenceException();
        }
        public void set_Interactable(bool value)
        {
            if(this.button != null)
            {
                    this.button.interactable = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void Awake()
        {
            UnityEngine.Transform val_2 = this.gameObject.transform;
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_3;
            }
            
            }
            
            this.rectTransform = val_2;
            return;
            label_3:
        }
        private void Start()
        {
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizLetterButton::OnClick()));
            this.SetHighlight(state:  0);
        }
        private void OnDestroy()
        {
            this.button.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizLetterButton::OnClick()));
        }
        public void ToggleButtonVisibility(bool isVisible)
        {
            isVisible = isVisible;
            this.button.interactable = isVisible;
            bool val_10 = ~isVisible;
            val_10 = val_10 & 1;
            this.<IsUsed>k__BackingField = val_10;
            if(this.buttonTweener != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.buttonTweener, complete:  false);
            }
            
            if(isVisible != false)
            {
                    this.SetHighlight(state:  0);
                this.gameObject.SetActive(value:  true);
                UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
                this.rectTransform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
                UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
                DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.rectTransform, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  0.15f);
            }
            else
            {
                    UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
                this.rectTransform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
                UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
            }
            
            this.buttonTweener = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.rectTransform, endValue:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, duration:  0.15f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizLetterButton::<ToggleButtonVisibility>b__24_0()));
        }
        private void OnClick()
        {
            this.ToggleButtonVisibility(isVisible:  false);
            SLC.Minigames.ImageQuiz.ImageQuizUIController val_1 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizUIController>.Instance;
            val_1.wordInputDisplay.AddInput(inputLetter:  this._letter, originatingButton:  this);
        }
        public void SetHighlight(SLC.Minigames.ImageQuiz.ImageQuizLetterButton.HighlightState state)
        {
            var val_4;
            this.<CurrentHighlightState>k__BackingField = state;
            UnityEngine.GameObject val_1 = this.spriteHighlighted.gameObject;
            if(state == 1)
            {
                    val_1.SetActive(value:  true);
                UnityEngine.GameObject val_2 = this.spriteDefault.gameObject;
                val_4 = 0;
            }
            else
            {
                    val_1.SetActive(value:  false);
                val_4 = 1;
            }
            
            this.spriteDefault.gameObject.SetActive(value:  true);
        }
        public void SetLetter(string letterString)
        {
            this._letter = letterString;
        }
        public ImageQuizLetterButton()
        {
            this._letter = System.String.alignConst;
        }
        private void <ToggleButtonVisibility>b__24_0()
        {
            this.gameObject.SetActive(value:  false);
        }
    
    }

}
