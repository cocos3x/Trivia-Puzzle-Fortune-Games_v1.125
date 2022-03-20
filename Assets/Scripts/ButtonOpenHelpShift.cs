using UnityEngine;
public class ButtonOpenHelpShift : MyButton
{
    // Fields
    private bool isFeedbackPrompt;
    
    // Methods
    protected override void Start()
    {
        this.Start();
        Player val_1 = App.Player;
        if(val_1.isTroll == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void OnEnable()
    {
        Player val_1 = App.Player;
        if(val_1.isTroll == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public override void OnButtonClick()
    {
        Player val_1 = App.Player;
        if(val_1.isTroll != false)
        {
                return;
        }
        
        this.OnButtonClick();
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.ShowFAQs();
    }
    public ButtonOpenHelpShift()
    {
    
    }

}
