using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizDisplayLetter : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button button;
        private string _letter;
        private bool <IsAnimating>k__BackingField;
        private SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileStatus <CurrentTileStatus>k__BackingField;
        private UnityEngine.UI.Image backgroundImage;
        private UnityEngine.RectTransform tileContainer;
        private UnityEngine.GameObject unconfirmedTile;
        private UnityEngine.GameObject confirmedTile;
        private UnityEngine.UI.Text[] letterLabel;
        private int buttonIndex;
        private DG.Tweening.Sequence tileAnimationSequence;
        
        // Properties
        public string Letter { get; }
        public bool IsAnimating { get; set; }
        public bool Interactable { get; set; }
        public SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileStatus CurrentTileStatus { get; set; }
        
        // Methods
        public string get_Letter()
        {
            return (string)this._letter;
        }
        private void set_IsAnimating(bool value)
        {
            this.<IsAnimating>k__BackingField = value;
        }
        public bool get_IsAnimating()
        {
            return (bool)this.<IsAnimating>k__BackingField;
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
        public SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileStatus get_CurrentTileStatus()
        {
            return (TileStatus)this.<CurrentTileStatus>k__BackingField;
        }
        private void set_CurrentTileStatus(SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileStatus value)
        {
            this.<CurrentTileStatus>k__BackingField = value;
        }
        private void Start()
        {
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter::OnClick()));
        }
        private void OnDestroy()
        {
            this.button.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter::OnClick()));
        }
        public void Initialize(int indexInWord)
        {
            this.buttonIndex = indexInWord;
            this.SetLetter(letterString:  System.String.alignConst);
            this.SetTileStatus(state:  0, dontUpdateVisual:  false);
        }
        private void OnClick()
        {
            SLC.Minigames.ImageQuiz.ImageQuizUIController val_1 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizUIController>.Instance;
            val_1.wordInputDisplay.EraseLetter(letterIndex:  this.buttonIndex);
        }
        public void SetLetter(string letterString)
        {
            this._letter = letterString;
            var val_2 = 0;
            do
            {
                if(val_2 >= this.letterLabel.Length)
            {
                    return;
            }
            
                UnityEngine.UI.Text val_1 = this.letterLabel[val_2];
                val_2 = val_2 + 1;
            }
            while(this.letterLabel != null);
            
            throw new NullReferenceException();
        }
        private void SetTileStatus(SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileStatus state, bool dontUpdateVisual = False)
        {
            var val_1;
            this.<CurrentTileStatus>k__BackingField = state;
            if(dontUpdateVisual != false)
            {
                    return;
            }
            
            if(state == 2)
            {
                goto label_1;
            }
            
            if(state == 1)
            {
                goto label_2;
            }
            
            if(state != 0)
            {
                    return;
            }
            
            goto label_4;
            label_2:
            this.SetTileVisible(state:  state);
            val_1 = 1;
            goto label_6;
            label_1:
            label_4:
            this.SetTileVisible(state:  true);
            val_1 = 0;
            label_6:
            this.button.interactable = false;
        }
        private void SetTileVisible(bool state)
        {
            var val_6;
            this.tileContainer.gameObject.SetActive(value:  state);
            if(state == false)
            {
                    return;
            }
            
            if((this.<CurrentTileStatus>k__BackingField) == 0)
            {
                goto label_3;
            }
            
            if((this.<CurrentTileStatus>k__BackingField) == 2)
            {
                goto label_4;
            }
            
            if((this.<CurrentTileStatus>k__BackingField) != 1)
            {
                    return;
            }
            
            UnityEngine.Color val_3 = UnityEngine.Color.white;
            this.backgroundImage.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
            val_6 = 1;
            goto label_8;
            label_3:
            UnityEngine.Color val_4 = UnityEngine.Color.white;
            this.backgroundImage.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
            val_6 = 0;
            label_8:
            this.unconfirmedTile.SetActive(value:  false);
            this.confirmedTile.SetActive(value:  false);
            return;
            label_4:
            UnityEngine.Color val_5 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
            this.backgroundImage.color = new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a};
            this.unconfirmedTile.SetActive(value:  false);
            this.confirmedTile.SetActive(value:  true);
        }
        public void PlayAnimation(SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter.TileAnimation anim, float animationDelay = 0)
        {
            DG.Tweening.TweenCallback val_32;
            DG.Tweening.Sequence val_33;
            IntPtr val_35;
            TileStatus val_36;
            if(this.tileAnimationSequence != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.tileAnimationSequence, complete:  false);
            }
            
            this.<IsAnimating>k__BackingField = true;
            this.button.interactable = false;
            if(anim < 2)
            {
                goto label_3;
            }
            
            if(anim == 2)
            {
                goto label_4;
            }
            
            if(anim != 3)
            {
                    return;
            }
            
            this.<CurrentTileStatus>k__BackingField = 2;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.tileAnimationSequence = val_1;
            UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  0.275f, y:  0.275f, z:  0f);
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_1, atPosition:  animationDelay, t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.tileContainer, punch:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, duration:  0.3f, vibrato:  1, elasticity:  0.5f));
            val_33 = this.tileAnimationSequence;
            val_35 = 1152921519938112560;
            goto label_8;
            label_3:
            if(anim != 1)
            {
                goto label_9;
            }
            
            val_36 = 2;
            goto label_10;
            label_4:
            DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
            this.tileAnimationSequence = val_5;
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  -16f);
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_5, atPosition:  animationDelay, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.tileContainer, endValue:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y}, duration:  0.1f, snapping:  false), ease:  5));
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Insert(s:  this.tileAnimationSequence, atPosition:  animationDelay, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundImage, endValue:  1f, duration:  0.1f), ease:  1));
            val_33 = this.tileAnimationSequence;
            DG.Tweening.TweenCallback val_13 = null;
            val_35 = 1152921519938162736;
            label_8:
            val_32 = val_13;
            val_13 = new DG.Tweening.TweenCallback(object:  this, method:  val_35);
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_33, action:  val_13);
            return;
            label_9:
            val_36 = 1;
            label_10:
            this.SetTileStatus(state:  val_36, dontUpdateVisual:  false);
            UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  1.15f, y:  1.15f, z:  1f);
            this.tileContainer.localScale = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
            UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  0f, y:  -33f);
            this.tileContainer.anchoredPosition = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
            DG.Tweening.Sequence val_17 = DG.Tweening.DOTween.Sequence();
            this.tileAnimationSequence = val_17;
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.one;
            DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_17, atPosition:  animationDelay, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.tileContainer, endValue:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, duration:  0.45f), ease:  30));
            UnityEngine.Vector2 val_22 = UnityEngine.Vector2.zero;
            DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Insert(s:  this.tileAnimationSequence, atPosition:  animationDelay, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.tileContainer, endValue:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y}, duration:  0.45f, snapping:  false), ease:  12));
            if(anim == 1)
            {
                    DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.Insert(s:  this.tileAnimationSequence, atPosition:  animationDelay, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundImage, endValue:  0f, duration:  0.45f), ease:  1));
            }
            
            DG.Tweening.TweenCallback val_29 = null;
            val_32 = val_29;
            val_29 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizDisplayLetter::OnAnimationComplete());
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.tileAnimationSequence, action:  val_29);
            MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "PlaceLetter", clipIndex:  0, volumeScale:  1f);
        }
        private void OnAnimationComplete()
        {
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            this.tileContainer.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
            this.tileContainer.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
            this.<IsAnimating>k__BackingField = false;
            this.button.interactable = ((this.<CurrentTileStatus>k__BackingField) == 1) ? 1 : 0;
        }
        public ImageQuizDisplayLetter()
        {
            this._letter = System.String.alignConst;
        }
        private void <PlayAnimation>b__31_0()
        {
            this.SetTileStatus(state:  0, dontUpdateVisual:  false);
            this.OnAnimationComplete();
        }
    
    }

}
