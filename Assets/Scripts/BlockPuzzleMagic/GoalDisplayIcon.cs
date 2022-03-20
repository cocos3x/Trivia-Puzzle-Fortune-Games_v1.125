using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GoalDisplayIcon : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image icon;
        private UnityEngine.UI.Text label;
        private UnityEngine.UI.Image checkmarkIcon;
        private UnityEngine.GameObject newText;
        private UnityEngine.UI.Button button;
        private float iconDesiredHeight;
        private UnityEngine.ParticleSystem particles;
        private UnityEngine.GameObject container;
        private System.Collections.Generic.List<BlockPuzzleMagic.GoalIconSprite> goalIconList;
        private BlockPuzzleMagic.Goal.GoalType <goalType>k__BackingField;
        private BlockPuzzleMagic.BlockColorType <goalColor>k__BackingField;
        
        // Properties
        public UnityEngine.GameObject Container { get; }
        public BlockPuzzleMagic.Goal.GoalType goalType { get; set; }
        public BlockPuzzleMagic.BlockColorType goalColor { get; set; }
        
        // Methods
        public UnityEngine.GameObject get_Container()
        {
            return (UnityEngine.GameObject)this.container;
        }
        public BlockPuzzleMagic.Goal.GoalType get_goalType()
        {
            return (GoalType)this.<goalType>k__BackingField;
        }
        private void set_goalType(BlockPuzzleMagic.Goal.GoalType value)
        {
            this.<goalType>k__BackingField = value;
        }
        public BlockPuzzleMagic.BlockColorType get_goalColor()
        {
            return (BlockPuzzleMagic.BlockColorType)this.<goalColor>k__BackingField;
        }
        private void set_goalColor(BlockPuzzleMagic.BlockColorType value)
        {
            this.<goalColor>k__BackingField = value;
        }
        private void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnGoalProgressUpdated, b:  new System.Action(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayIcon::OnGoalProgressUpdated()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_1.OnGoalProgressUpdated = val_3;
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnGameOver, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayIcon::OnLevelCleared(bool success)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_4.OnGameOver = val_6;
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void BlockPuzzleMagic.GoalDisplayIcon::OnButtonClicked()));
            return;
            label_8:
        }
        private void OnDestroy()
        {
            System.Action<System.Boolean> val_9;
            var val_10;
            val_9 = 1152921504893161472;
            val_10 = 1152921513393502304;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnGoalProgressUpdated, value:  new System.Action(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayIcon::OnGoalProgressUpdated()));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_3.OnGoalProgressUpdated = val_5;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_9 = val_6.OnGameOver;
            val_10 = 1152921504614248448;
            System.Delegate val_8 = System.Delegate.Remove(source:  val_9, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayIcon::OnLevelCleared(bool success)));
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_6.OnGameOver = val_8;
            return;
            label_13:
        }
        public void EnableNewText()
        {
            if(this.newText != null)
            {
                    this.newText.SetActive(value:  true);
                return;
            }
            
            throw new NullReferenceException();
        }
        public void EnableButton()
        {
            if(this.button != null)
            {
                    this.button.interactable = true;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void Initialize(BlockPuzzleMagic.Goal _goal)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GoalIconSprite> val_7;
            IntPtr val_8;
            ._goal = _goal;
            .<>4__this = this;
            this.<goalType>k__BackingField = _goal.goalType;
            val_7 = this.goalIconList;
            if(((GoalDisplayIcon.<>c__DisplayClass23_0)[1152921520167921792]._goal.goalType) == 5)
            {
                    val_8 = 1152921520167796160;
            }
            else
            {
                    val_8 = 1152921520167797184;
            }
            
            System.Predicate<BlockPuzzleMagic.GoalIconSprite> val_2 = new System.Predicate<BlockPuzzleMagic.GoalIconSprite>(object:  new GoalDisplayIcon.<>c__DisplayClass23_0(), method:  val_8);
            BlockPuzzleMagic.GoalIconSprite val_3 = val_7.Find(match:  null);
            this.icon.sprite = val_3.goalSprite;
            this.icon.preserveAspect = true;
            this.icon.rectTransform.SetSizeWithCurrentAnchors(axis:  1, size:  this.iconDesiredHeight);
            this.RefreshUIInstant(currentGoalData:  (GoalDisplayIcon.<>c__DisplayClass23_0)[1152921520167921792]._goal);
            if((this.<goalType>k__BackingField) != 3)
            {
                    return;
            }
            
            val_7 = this.icon;
            BlockPuzzleMagic.BlockColor val_6 = BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  (GoalDisplayIcon.<>c__DisplayClass23_0)[1152921520167921792]._goal.goalColorValue);
            val_7.color = new UnityEngine.Color() {r = val_6.colorValue};
            this.<goalColor>k__BackingField = (GoalDisplayIcon.<>c__DisplayClass23_0)[1152921520167921792]._goal.goalColorValue;
        }
        private void OnGoalProgressUpdated()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_5;
            IntPtr val_7;
            if((this.<goalType>k__BackingField) == 3)
            {
                    BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_5 = val_1.currentLevel.goals;
                val_7 = 1152921520168084288;
            }
            else
            {
                    BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_5 = val_2.currentLevel.goals;
                System.Predicate<BlockPuzzleMagic.Goal> val_3 = null;
                val_7 = 1152921520168101696;
            }
            
            val_3 = new System.Predicate<BlockPuzzleMagic.Goal>(object:  this, method:  val_7);
            BlockPuzzleMagic.Goal val_4 = val_5.Find(match:  val_3);
            if(val_4 == null)
            {
                    return;
            }
            
            this.RefreshUI(currentGoalData:  val_4);
        }
        private void RefreshUI(BlockPuzzleMagic.Goal currentGoalData)
        {
            .<>4__this = this;
            .currentDisplayValue = UnityEngine.Mathf.Max(a:  0, b:  currentGoalData.targetValue - currentGoalData.currentValue);
            if((System.String.Compare(strA:  this.label, strB:  .currentDisplayValue.ToString())) == 0)
            {
                    return;
            }
            
            this.particles.Play();
            DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.label.transform, endValue:  0f, duration:  0.15f), action:  new DG.Tweening.TweenCallback(object:  new GoalDisplayIcon.<>c__DisplayClass25_0(), method:  System.Void GoalDisplayIcon.<>c__DisplayClass25_0::<RefreshUI>b__0()));
        }
        private void RefreshUIInstant(BlockPuzzleMagic.Goal currentGoalData)
        {
            int val_2 = UnityEngine.Mathf.Max(a:  0, b:  currentGoalData.targetValue - currentGoalData.currentValue);
            string val_3 = val_2.ToString();
            this.label.gameObject.SetActive(value:  (val_2 > 0) ? 1 : 0);
            this.checkmarkIcon.gameObject.SetActive(value:  (val_2 < 1) ? 1 : 0);
        }
        private void OnLevelCleared(bool success)
        {
            if(success == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_3 = this.transform.localPosition;
            DG.Tweening.Sequence val_4 = DG.Tweening.ShortcutExtensions.DOLocalJump(target:  this.transform, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, jumpPower:  15f, numJumps:  1, duration:  0.5f, snapping:  false);
        }
        public void OnButtonClicked()
        {
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BlockPuzzleMagic.BBLGoalTooltipPopup>(showNext:  false).Initialize(goalTransform:  this.transform, goalType:  this.<goalType>k__BackingField, goalColor:  this.<goalColor>k__BackingField);
        }
        public GoalDisplayIcon()
        {
            this.iconDesiredHeight = 108f;
        }
        private bool <OnGoalProgressUpdated>b__24_0(BlockPuzzleMagic.Goal obj)
        {
            if(obj != null)
            {
                    if(obj.goalType != (this.<goalType>k__BackingField))
            {
                    return false;
            }
            
                return (bool)(obj.goalColorValue == (this.<goalColor>k__BackingField)) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
        private bool <OnGoalProgressUpdated>b__24_1(BlockPuzzleMagic.Goal obj)
        {
            if(obj != null)
            {
                    return (bool)(obj.goalType == (this.<goalType>k__BackingField)) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
