using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLGoalTooltipPopup : MonoBehaviour
    {
        // Fields
        private const string horizontalGoalText = "Clear {0} horizontal line{1}";
        private const string verticalGoalText = "Clear {0} vertical line{1}";
        private const string blocksGoalText = "Clear {0} {1} block{2} by using them to clear lines";
        private const string stonesGoalText = "Clear all {0} stone{1} by using them twice to clear lines";
        private const string dotsGoalText = "Clear all {0} dot{1} by clearing lines where the dots are";
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.Transform arrow;
        private UnityEngine.GameObject[] pages;
        private UnityEngine.UI.Text titleText;
        private UnityEngine.UI.Text infoText;
        private System.Collections.Generic.Dictionary<BlockPuzzleMagic.BlockColorType, string> colorNames;
        
        // Methods
        private void Awake()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLGoalTooltipPopup::OnCloseButtonClicked()));
        }
        public void Initialize(UnityEngine.Transform goalTransform, BlockPuzzleMagic.Goal.GoalType goalType, BlockPuzzleMagic.BlockColorType goalColor)
        {
            UnityEngine.Color val_1 = UnityEngine.Color.clear;
            UnityEngine.Transform[] val_2 = new UnityEngine.Transform[2];
            val_2[0] = goalTransform;
            val_2[1] = this.transform;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a}, setBgColorInstantly:  false, contentToShow:  val_2);
            UnityEngine.Vector3 val_4 = goalTransform.localPosition;
            UnityEngine.Vector3 val_5 = this.arrow.localPosition;
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_4.x, y:  val_5.y, z:  0f);
            this.arrow.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            this.DisplayContent(goalType:  goalType, goalColor:  goalColor);
        }
        private void DisplayContent(BlockPuzzleMagic.Goal.GoalType goalType, BlockPuzzleMagic.BlockColorType goalColor)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_15;
            IntPtr val_17;
            int val_18;
            .goalType = goalType;
            .goalColor = goalColor;
            var val_16 = 0;
            label_6:
            if(val_16 >= this.pages.Length)
            {
                goto label_3;
            }
            
            this.pages[val_16].SetActive(value:  (val_16 == ((BBLGoalTooltipPopup.<>c__DisplayClass13_0)[1152921520119830416].goalType)) ? 1 : 0);
            val_16 = val_16 + 1;
            if(this.pages != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_3:
            if((BlockPuzzleMagic.Goal.IsGoalColorBased(goalType:  (BBLGoalTooltipPopup.<>c__DisplayClass13_0)[1152921520119830416].goalType)) != false)
            {
                    BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_15 = val_4.currentLevel.goals;
                val_17 = 1152921520119690656;
            }
            else
            {
                    BlockPuzzleMagic.GamePlay val_5 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_15 = val_5.currentLevel.goals;
                System.Predicate<BlockPuzzleMagic.Goal> val_6 = null;
                val_17 = 1152921520119708064;
            }
            
            val_6 = new System.Predicate<BlockPuzzleMagic.Goal>(object:  new BBLGoalTooltipPopup.<>c__DisplayClass13_0(), method:  val_17);
            BlockPuzzleMagic.Goal val_7 = val_15.Find(match:  val_6);
            val_18 = val_7.targetValue;
            GoalType val_17 = (BBLGoalTooltipPopup.<>c__DisplayClass13_0)[1152921520119830416].goalType;
            val_17 = val_17 - 1;
            if(val_17 > 4)
            {
                    return;
            }
            
            var val_18 = 32560488 + (((BBLGoalTooltipPopup.<>c__DisplayClass13_0)[1152921520119830416].goalType - 1)) << 2;
            val_18 = UnityEngine.Mathf.Max(a:  0, b:  val_18 - val_7.currentValue);
            val_18 = val_18 + 32560488;
            goto (32560488 + (((BBLGoalTooltipPopup.<>c__DisplayClass13_0)[1152921520119830416].goalType - 1)) << 2 + 32560488);
        }
        private void OnCloseButtonClicked()
        {
            BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  false, onOverlayClosed:  0);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public BBLGoalTooltipPopup()
        {
            System.Collections.Generic.Dictionary<BlockPuzzleMagic.BlockColorType, System.String> val_1 = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.BlockColorType, System.String>();
            val_1.Add(key:  2, value:  "blue");
            val_1.Add(key:  3, value:  "green");
            val_1.Add(key:  4, value:  "purple");
            val_1.Add(key:  5, value:  "red");
            val_1.Add(key:  6, value:  "teal");
            val_1.Add(key:  7, value:  "yellow");
            this.colorNames = val_1;
        }
    
    }

}
