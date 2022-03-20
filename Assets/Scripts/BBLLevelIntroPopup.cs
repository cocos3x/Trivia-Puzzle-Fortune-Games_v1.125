using UnityEngine;
public class BBLLevelIntroPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text levelLabel;
    private BlockPuzzleMagic.GoalDisplayIcon goalDisplayIconPrefab;
    private UnityEngine.RectTransform displayContainer;
    private UnityEngine.UI.Button buttonClose;
    private UnityEngine.UI.Button buttonProceed;
    
    // Methods
    private void Awake()
    {
        this.buttonClose.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLLevelIntroPopup::OnCloseClicked()));
        this.buttonProceed.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLLevelIntroPopup::OnProceedClicked()));
    }
    public void Init()
    {
        var val_7;
        BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        string val_2 = System.String.Format(format:  "•LEVEL {0}•", arg0:  val_1.currentLevel.levelId);
        val_7 = 0;
        do
        {
            if(val_7 >= val_1.currentLevel.goals)
        {
                return;
        }
        
            BlockPuzzleMagic.GoalDisplayIcon val_3 = UnityEngine.Object.Instantiate<BlockPuzzleMagic.GoalDisplayIcon>(original:  this.goalDisplayIconPrefab, parent:  this.displayContainer);
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  0.9f, y:  0.9f, z:  1f);
            val_3.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3.Initialize(_goal:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32);
            val_7 = val_7 + 1;
        }
        while(val_1.currentLevel.goals != null);
        
        throw new NullReferenceException();
    }
    private void OnCloseClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        this.gameObject.SetActive(value:  false);
    }
    private void OnProceedClicked()
    {
        var val_9;
        System.Action val_11;
        bool val_2 = BestBlocksPlayer.Instance.RefreshPlayerLives();
        BestBlocksPlayer val_3 = BestBlocksPlayer.Instance;
        if(val_3.livesBalance >= 1)
        {
                this.gameObject.SetActive(value:  false);
            return;
        }
        
        GameBehavior val_5 = App.getBehavior;
        val_9 = null;
        val_9 = null;
        val_11 = BBLLevelIntroPopup.<>c.<>9__8_0;
        if(val_11 == null)
        {
                System.Action val_7 = null;
            val_11 = val_7;
            val_7 = new System.Action(object:  BBLLevelIntroPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLLevelIntroPopup.<>c::<OnProceedClicked>b__8_0());
            BBLLevelIntroPopup.<>c.<>9__8_0 = val_11;
        }
        
        val_5.<metaGameBehavior>k__BackingField.Init(onCloseAction:  val_7);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private bool IsFirstTimeGoalShown(BlockPuzzleMagic.Goal goal)
    {
        GoalType val_4 = goal.goalType;
        val_4 = val_4 - 1;
        if(val_4 <= 4)
        {
                var val_5 = 32564176 + ((goal.goalType - 1)) << 2;
            val_5 = val_5 + 32564176;
        }
        else
        {
                 =  ^ 1;
            return (bool);
        }
    
    }
    public BBLLevelIntroPopup()
    {
    
    }

}
