using UnityEngine;
public class WordIQFoundWordsMenu : MonoBehaviour
{
    // Fields
    private readonly int[] buttonIndexToLetterCounts;
    private UnityEngine.UI.Text iqStat;
    private WordIQMilestoneDisplay milestoneDisplay;
    private UnityEngine.UI.Text wordsFound;
    private ExtraProgress wordsFoundProgressBar;
    private UnityEngine.UI.Text[] buttonTexts;
    private UnityEngine.UI.Button[] buttons;
    private WordIQFoundWordsScreen foundWordsScreen;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button infoButton;
    
    // Methods
    public void OnButtonClicked(int buttonIndex)
    {
        this.foundWordsScreen.ShowFoundWordsList(numLetters:  this.buttonIndexToLetterCounts[buttonIndex]);
    }
    private void Start()
    {
        UnityEngine.Events.UnityAction val_3;
        var val_4;
        UnityEngine.Events.UnityAction val_6;
        UnityEngine.Events.UnityAction val_1 = null;
        val_3 = val_1;
        val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordIQFoundWordsMenu::<Start>b__11_0());
        this.closeButton.m_OnClick.AddListener(call:  val_1);
        val_4 = null;
        val_4 = null;
        val_6 = WordIQFoundWordsMenu.<>c.<>9__11_1;
        if(val_6 == null)
        {
                UnityEngine.Events.UnityAction val_2 = null;
            val_6 = val_2;
            val_2 = new UnityEngine.Events.UnityAction(object:  WordIQFoundWordsMenu.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WordIQFoundWordsMenu.<>c::<Start>b__11_1());
            WordIQFoundWordsMenu.<>c.<>9__11_1 = val_6;
        }
        
        this.infoButton.m_OnClick.AddListener(call:  val_2);
    }
    private void OnEnable()
    {
        string val_3 = WordIQManagerUI.FormatPoints(iqPoints:  MonoSingleton<WordIQManager>.Instance.PlayerIQ);
        WordIQManager val_4 = MonoSingleton<WordIQManager>.Instance;
        this.milestoneDisplay.UpdateMilestoneDisplay(newMilestoneIndex:  val_4.GetMilestone(iqPoints:  val_4.PlayerIQ));
        int val_8 = MonoSingleton<WordIQManager>.Instance.GetTotalFoundWordsCount();
        int val_10 = MonoSingleton<WordIQManager>.Instance.GetTotalPossibleFoundWordsCount();
        string val_13 = val_8.ToString() + " / "(" / ") + 0.ToString();
        this.wordsFoundProgressBar.target = 0f;
        this.wordsFoundProgressBar.current = (float)val_8;
        var val_34 = 0;
        label_28:
        if(val_34 >= this.buttonTexts.Length)
        {
            goto label_13;
        }
        
        int val_31 = this.buttonIndexToLetterCounts[val_34];
        System.Collections.Generic.List<System.String> val_15 = MonoSingleton<WordIQManager>.Instance.GetFoundWords(numLetters:  val_31);
        UnityEngine.UI.Text val_32 = this.buttonTexts[val_34];
        string val_23 = System.String.Format(format:  "{0} {1}/{2}", arg0:  System.String.Format(format:  Localization.Localize(key:  "x_letter_words", defaultValue:  "{0} Letter Words", useSingularKey:  false), arg0:  val_31.ToString()), arg1:  MonoSingleton<T>.__il2cppRuntimeField_cctor_finished.ToString(), arg2:  MonoSingleton<WordIQManager>.Instance.GetPossibleWordsCount(numLetters:  val_31).ToString());
        this.buttons[val_34].gameObject.SetActive(value:  ((MonoSingleton<T>.__il2cppRuntimeField_cctor_finished) > 0) ? 1 : 0);
        val_34 = val_34 + 1;
        if(this.buttonTexts != null)
        {
            goto label_28;
        }
        
        label_13:
        if((MonoSingleton<WordIQManager>.Instance.IsFtuxSeen) == true)
        {
                return;
        }
        
        MonoSingleton<WordIQManager>.Instance.IsFtuxSeen = true;
        GameBehavior val_29 = App.getBehavior;
        this = val_29.<metaGameBehavior>k__BackingField;
    }
    public WordIQFoundWordsMenu()
    {
        this.buttonIndexToLetterCounts = new int[6] {7, 6, 5, 4, 3, 2};
    }
    private void <Start>b__11_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
