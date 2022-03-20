using UnityEngine;
public class WordIQFoundWordsScreen : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text nLetterWords;
    private UnityEngine.UI.Text wordsFound;
    private UnityEngine.UI.Text[] gridTexts;
    private UGUIPageDisplay pageDisplay;
    private System.Collections.Generic.List<string> foundWords;
    private bool hasInitialized;
    
    // Methods
    private void OnPageChanged(int currentPageIndex)
    {
        ButtonClickedEvent val_8;
        if(this.gridTexts.Length < 1)
        {
                return;
        }
        
        var val_13 = 0;
        do
        {
            .<>4__this = this;
            System.Collections.Generic.List<System.String> val_10 = this.foundWords;
            int val_4 = (this.gridTexts.Length * currentPageIndex) + val_13;
            this.gridTexts[0].gameObject.SetActive(value:  (val_4 < val_10) ? 1 : 0);
            if(val_4 < val_10)
        {
                UnityEngine.UI.Text val_9 = this.gridTexts[0];
            if(val_10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_10 = val_10 + (val_4 << 3);
            UnityEngine.UI.Button val_6 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.Button>(child:  this.gridTexts[0]);
            val_6.m_OnClick.RemoveAllListeners();
            .word = this.gridTexts[0];
            val_8 = val_6.m_OnClick;
            val_8.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new WordIQFoundWordsScreen.<>c__DisplayClass6_0(), method:  System.Void WordIQFoundWordsScreen.<>c__DisplayClass6_0::<OnPageChanged>b__0()));
        }
        
            val_13 = val_13 + 1;
        }
        while(val_13 < this.gridTexts.Length);
    
    }
    public void Awake()
    {
        this.Init();
    }
    public void ShowFoundWordsList(int numLetters)
    {
        this.Init();
        System.Collections.Generic.List<System.String> val_2 = MonoSingleton<WordIQManager>.Instance.GetFoundWords(numLetters:  numLetters);
        this.foundWords = val_2;
        val_2.Sort();
        string val_5 = System.String.Format(format:  Localization.Localize(key:  "x_letter_words", defaultValue:  "{0} LETTER WORDS", useSingularKey:  false), arg0:  numLetters.ToString());
        string val_9 = System.String.Format(format:  "{0} / {1}", arg0:  this.foundWords, arg1:  MonoSingleton<WordIQManager>.Instance.GetPossibleWordsCount(numLetters:  numLetters).ToString());
        float val_12 = (float)this.gridTexts.Length;
        val_12 = (1.152922E+18f) / val_12;
        this.pageDisplay.numPages = UnityEngine.Mathf.CeilToInt(f:  val_12);
        this.pageDisplay.SetToPage(index:  0, force:  true);
        this.gameObject.SetActive(value:  true);
    }
    private void Init()
    {
        if(this.hasInitialized == true)
        {
                return;
        }
        
        this.pageDisplay.maxPageDots = 0;
        System.Delegate val_2 = System.Delegate.Combine(a:  this.pageDisplay.PageIndexChanged, b:  new System.Action<System.Int32>(object:  this, method:  System.Void WordIQFoundWordsScreen::OnPageChanged(int currentPageIndex)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        this.pageDisplay.PageIndexChanged = val_2;
        this.hasInitialized = true;
        return;
        label_5:
    }
    private void OnClick_Word(string word)
    {
        if((MonoSingletonSelfGenerating<WGDefinitionManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<WGDefinitionManager>.Instance.displayDefinition(word:  word, flyout:  true);
    }
    public WordIQFoundWordsScreen()
    {
    
    }

}
