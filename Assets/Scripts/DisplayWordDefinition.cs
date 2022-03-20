using UnityEngine;
public class DisplayWordDefinition : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text wordText;
    private UnityEngine.UI.Text wordTypeText;
    private UnityEngine.UI.Text definitionText;
    private UnityEngine.GameObject closeButton;
    private string lookup;
    private string word;
    private string category;
    private string definition;
    private string loadingText;
    private string failureMessage;
    private System.Action showLoading;
    
    // Properties
    protected virtual bool checkTouchedMe { get; }
    
    // Methods
    private void Start()
    {
        if((this.closeButton.GetComponent<UnityEngine.UI.Button>()) == 0)
        {
                return;
        }
        
        val_1.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(DisplayWordDefinition).__il2cppRuntimeField_1B8));
    }
    protected virtual void OnEnable()
    {
        if(this.showLoading == null)
        {
                return;
        }
        
        this.showLoading.Invoke();
    }
    private void ShowLoading()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AppendDots());
    }
    public virtual void OpenButLoad(string word)
    {
        this.showLoading = new System.Action(object:  this, method:  System.Void DisplayWordDefinition::ShowLoading());
    }
    public virtual void Init(System.Collections.Generic.Dictionary<string, object> defToDisplay)
    {
        this.StopAllCoroutines();
        this.showLoading = 0;
        this.DisplayText(wordData:  defToDisplay);
    }
    protected void DisplayText(System.Collections.Generic.Dictionary<string, object> wordData)
    {
        object val_1 = wordData.Item[this.lookup];
        string val_3 = wordData.Item[this.category].ToLower();
        object val_4 = wordData.Item[this.definition];
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private System.Collections.IEnumerator AppendDots()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DisplayWordDefinition.<AppendDots>d__17();
    }
    public void OnFailure()
    {
        this.StopAllCoroutines();
        this.showLoading = 0;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected virtual bool get_checkTouchedMe()
    {
        if(UnityEngine.Input.touchCount <= 0)
        {
                if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
                return false;
        }
        
        }
        
        UnityEngine.EventSystems.EventSystem val_3 = UnityEngine.EventSystems.EventSystem.current;
        if(val_3.m_CurrentSelected == this.gameObject)
        {
                return false;
        }
        
        UnityEngine.EventSystems.EventSystem val_6 = UnityEngine.EventSystems.EventSystem.current;
        return UnityEngine.Object.op_Inequality(x:  val_6.m_CurrentSelected, y:  this.closeButton);
    }
    private void Update()
    {
        if((this & 1) == 0)
        {
                return;
        }
        
        this.enabled = false;
        goto typeof(DisplayWordDefinition).__il2cppRuntimeField_1B0;
    }
    protected virtual void DisableMe()
    {
        this.gameObject.SetActive(value:  false);
    }
    private void OnDisable()
    {
        if((System.String.op_Equality(a:  this.wordTypeText, b:  System.String.alignConst)) != false)
        {
                MonoSingletonSelfGenerating<WGDefinitionManager>.Instance.StopWaitingForRequest();
        }
        
        this.StopAllCoroutines();
        this.showLoading = 0;
    }
    public virtual void ShowFTUXMessage()
    {
    
    }
    public DisplayWordDefinition()
    {
        this.lookup = "lookup";
        this.word = "word";
        this.category = "lexical_category";
        this.definition = "definition";
        this.loadingText = "loading";
        this.failureMessage = "Oops! We\'re having trouble finding this definition.";
    }

}
