using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLPowerupButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
    {
        // Fields
        protected BlockPuzzleMagic.PowerUpType powerupType;
        protected UnityEngine.UI.Button myButton;
        protected UnityEngine.UI.Image icon;
        protected UnityEngine.UI.Text priceLabel;
        protected UnityEngine.UI.Image priceIcon;
        protected UnityEngine.GameObject lockOverlay;
        protected UnityEngine.CanvasGroup tooltip;
        protected UnityEngine.UI.Text tooltipLabel;
        protected bool isPowerupUsed;
        protected bool isUnlocked;
        protected DG.Tweening.Sequence tooltipSeq;
        
        // Properties
        public UnityEngine.UI.Image Icon { get; }
        public bool BlockRaycasts { get; set; }
        public bool Interactable { get; set; }
        
        // Methods
        public UnityEngine.UI.Image get_Icon()
        {
            return (UnityEngine.UI.Image)this.icon;
        }
        public bool get_BlockRaycasts()
        {
            goto typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_2B0;
        }
        public void set_BlockRaycasts(bool value)
        {
            bool val_1 = value;
            goto typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_2C0;
        }
        public bool get_Interactable()
        {
            if(this.myButton != null)
            {
                    return (bool)this;
            }
            
            throw new NullReferenceException();
        }
        public void set_Interactable(bool value)
        {
            if(this.myButton != null)
            {
                    this.myButton.interactable = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        protected virtual void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_1C8));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            val_1.OnLevelDataInitialized = val_3;
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnPowerupUsed, b:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_1F8));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_9;
            }
            
            }
            
            val_4.OnPowerupUsed = val_6;
            return;
            label_9:
        }
        protected virtual void OnDestroy()
        {
            System.Action<BlockPuzzleMagic.PowerUpType> val_9;
            var val_10;
            val_9 = 1152921504893161472;
            val_10 = 1152921513393502304;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnLevelDataInitialized, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_1C8));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            val_3.OnLevelDataInitialized = val_5;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_9 = val_6.OnPowerupUsed;
            val_10 = 1152921504614248448;
            System.Delegate val_8 = System.Delegate.Remove(source:  val_9, value:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_1F8));
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            val_6.OnPowerupUsed = val_8;
            return;
            label_14:
        }
        protected virtual void OnEnable()
        {
            this.RefreshPriceLabel();
        }
        protected virtual void ToggleLock(bool isUnlocked)
        {
            if(this.lockOverlay != 0)
            {
                    this.lockOverlay.SetActive(value:  (~isUnlocked) & 1);
            }
            
            this.myButton.interactable = isUnlocked;
        }
        protected virtual void OnLevelInitialized(BlockPuzzleMagic.Level level)
        {
            var val_7;
            int val_7 = BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  this.powerupType);
            val_7 = GameEcon.IsEnabledAndLevelMet(playerLevel:  level.levelId, knobValue:  val_7);
            this.isUnlocked = val_7;
            if(level.levelId > (BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  this.powerupType)))
            {
                    if(this.powerupType <= 3)
            {
                    val_7 = mem[32560544 + (this.powerupType) << 2];
                val_7 = 32560544 + (this.powerupType) << 2;
            }
            else
            {
                    val_7 = 0;
            }
            
                BestBlocksPlayer val_6 = BestBlocksPlayer.Instance;
                if(val_7 != 0)
            {
                    int val_8 = val_6.tutorialCompleted;
                val_8 = val_8 | 0;
                val_6.tutorialCompleted = val_8;
            }
            
            }
            
            this.RefreshPriceLabel();
        }
        public virtual void OnPointerClick(UnityEngine.EventSystems.PointerEventData pointerEventData)
        {
            goto typeof(BlockPuzzleMagic.BBLPowerupButton).__il2cppRuntimeField_1E0;
        }
        protected virtual void OnButtonClicked()
        {
        
        }
        protected void ShowTooltip()
        {
            var val_13;
            DG.Tweening.Sequence val_14;
            if(this.powerupType <= 2)
            {
                    val_13 = mem[39724768 + (this.powerupType) << 3];
                val_13 = 39724768 + (this.powerupType) << 3;
            }
            else
            {
                    val_13 = "";
            }
            
            val_14 = this.tooltipSeq;
            if(val_14 == null)
            {
                    DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
                this.tooltipSeq = val_1;
                DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_1, autoKillOnCompletion:  false);
                DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.tooltipSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tooltip, endValue:  1f, duration:  0.1f));
                DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.tooltipSeq, interval:  2f);
                DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.tooltipSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tooltip, endValue:  0f, duration:  0.1f));
                DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.tooltipSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.BBLPowerupButton::<ShowTooltip>b__26_0()));
                DG.Tweening.Sequence val_10 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  this.tooltipSeq);
                val_14 = this.tooltipSeq;
            }
            
            if((DG.Tweening.TweenExtensions.IsPlaying(t:  val_14)) != false)
            {
                    this.HideTooltip();
                return;
            }
            
            this.tooltip.alpha = 0f;
            this.tooltip.gameObject.SetActive(value:  true);
            DG.Tweening.TweenExtensions.Restart(t:  this.tooltipSeq, includeDelay:  true, changeDelayTo:  -1f);
        }
        protected void HideTooltip()
        {
            if(this.tooltipSeq == null)
            {
                    return;
            }
            
            if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.tooltipSeq)) == false)
            {
                    return;
            }
            
            DG.Tweening.TweenExtensions.Complete(t:  this.tooltipSeq);
        }
        protected virtual void OnPowerupUsed(BlockPuzzleMagic.PowerUpType powerupUsed)
        {
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  public System.Void BlockPuzzleMagic.BBLPowerupButton::RefreshPriceLabel()), count:  1);
            this.isPowerupUsed = (this.powerupType == powerupUsed) ? 1 : 0;
        }
        public void RefreshPriceLabel()
        {
            var val_10;
            if(this.isUnlocked != false)
            {
                    BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
                decimal val_3 = BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupCost(_type:  this.powerupType);
                string val_4 = val_3.flags.ToString();
                UnityEngine.GameObject val_5 = this.priceIcon.gameObject;
                val_10 = 1;
            }
            else
            {
                    string val_8 = System.String.Format(format:  "LEVEL {0}", arg0:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  this.powerupType));
                val_10 = 0;
            }
            
            this.priceIcon.gameObject.SetActive(value:  false);
        }
        public BBLPowerupButton()
        {
            this.isUnlocked = true;
        }
        private void <ShowTooltip>b__26_0()
        {
            this.tooltip.gameObject.SetActive(value:  false);
        }
    
    }

}
