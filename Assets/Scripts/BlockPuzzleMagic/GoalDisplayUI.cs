using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GoalDisplayUI : MonoSingleton<BlockPuzzleMagic.GoalDisplayUI>
    {
        // Fields
        private BlockPuzzleMagic.GoalDisplayIcon goalDisplayIconPrefab;
        private UnityEngine.RectTransform displayContainer;
        private System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon> goalDisplayIconList;
        
        // Properties
        public System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon> GoalDisplayIconList { get; }
        
        // Methods
        public System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon> get_GoalDisplayIconList()
        {
            return (System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon>)this.goalDisplayIconList;
        }
        private void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayUI::OnLevelDataInitialized(BlockPuzzleMagic.Level currLevel)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnLevelDataInitialized = val_3;
            return;
            label_5:
        }
        private void OnDestroy()
        {
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            1152921504893161472 = val_3.OnLevelDataInitialized;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.GoalDisplayUI::OnLevelDataInitialized(BlockPuzzleMagic.Level currLevel)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnLevelDataInitialized = val_5;
            return;
            label_10:
        }
        private void OnLevelDataInitialized(BlockPuzzleMagic.Level currLevel)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon> val_4;
            var val_5;
            bool val_4 = true;
            if(this.goalDisplayIconList == null)
            {
                goto label_2;
            }
            
            var val_5 = 0;
            label_7:
            if(val_5 >= val_4)
            {
                goto label_2;
            }
            
            if(val_4 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + 0;
            UnityEngine.Object.Destroy(obj:  (true + 0) + 32.gameObject);
            val_5 = val_5 + 1;
            if(this.goalDisplayIconList != null)
            {
                goto label_7;
            }
            
            label_2:
            System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon> val_2 = null;
            val_4 = val_2;
            val_2 = new System.Collections.Generic.List<BlockPuzzleMagic.GoalDisplayIcon>();
            this.goalDisplayIconList = val_4;
            val_5 = 0;
            do
            {
                if(val_5 >= currLevel.goals)
            {
                    return;
            }
            
                val_4 = UnityEngine.Object.Instantiate<BlockPuzzleMagic.GoalDisplayIcon>(original:  this.goalDisplayIconPrefab, parent:  this.displayContainer);
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_4.Initialize(_goal:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32);
                val_4.EnableButton();
                this.goalDisplayIconList.Add(item:  val_4);
                val_5 = val_5 + 1;
            }
            while(currLevel.goals != null);
            
            throw new NullReferenceException();
        }
        public GoalDisplayUI()
        {
        
        }
    
    }

}
