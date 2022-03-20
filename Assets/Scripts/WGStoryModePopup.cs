using UnityEngine;
public class WGStoryModePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject letter_group;
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Text message;
    private UnityEngine.UI.Button close_button;
    private UnityEngine.UI.Text close_text_no_thanks;
    private UnityEngine.UI.Text close_text_just_for_puzzles;
    private UnityEngine.UI.Button[] response_buttons;
    private UnityEngine.UI.Text[] response_buttons_text;
    private UnityEngine.GameObject feedback_group;
    private UnityEngine.UI.Button continue_button;
    private UnityEngine.UI.Text feedback_message;
    
    // Methods
    private void Awake()
    {
        ButtonClickedEvent val_7;
        this.PrepFeedback();
        int val_8 = 0;
        label_8:
        if(val_8 >= this.response_buttons.Length)
        {
            goto label_2;
        }
        
        .<>4__this = this;
        .index = val_8;
        UnityEngine.UI.Button val_7 = this.response_buttons[val_8];
        val_7 = this.response_buttons[0x0][0].m_OnClick;
        val_7.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new WGStoryModePopup.<>c__DisplayClass11_0(), method:  System.Void WGStoryModePopup.<>c__DisplayClass11_0::<Awake>b__2()));
        val_8 = val_8 + 1;
        if(this.response_buttons != null)
        {
            goto label_8;
        }
        
        throw new NullReferenceException();
        label_2:
        if((UnityEngine.Object.op_Implicit(exists:  this.close_button)) != false)
        {
                UnityEngine.Events.UnityAction val_4 = null;
            val_7 = val_4;
            val_4 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGStoryModePopup::<Awake>b__11_0());
            this.close_button.m_OnClick.AddListener(call:  val_4);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.continue_button)) == false)
        {
                return;
        }
        
        this.continue_button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGStoryModePopup::<Awake>b__11_1()));
    }
    public void OnDialogClick(int index)
    {
        if(index <= 3)
        {
                var val_11 = 32497336 + (index) << 2;
            val_11 = val_11 + 32497336;
        }
        else
        {
                ???.OnFeedbackSelected();
        }
    
    }
    public void OnDialogDismiss()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void PrepFeedback()
    {
        int val_19;
        int val_20;
        if((UnityEngine.Object.op_Implicit(exists:  this.close_button)) != false)
        {
                this.close_button.gameObject.SetActive(value:  true);
        }
        
        var val_20 = 0;
        label_11:
        if(val_20 >= this.response_buttons.Length)
        {
            goto label_7;
        }
        
        this.response_buttons[val_20].gameObject.SetActive(value:  true);
        val_20 = val_20 + 1;
        if(this.response_buttons != null)
        {
            goto label_11;
        }
        
        throw new NullReferenceException();
        label_7:
        if((UnityEngine.Object.op_Implicit(exists:  this.title)) != false)
        {
                string val_5 = Localization.Localize(key:  "mysterious_letter_upper", defaultValue:  "A MYSTERIOUS LETTER", useSingularKey:  false);
        }
        
        if(this.response_buttons_text.Length >= 3)
        {
                UnityEngine.UI.Text val_21 = this.response_buttons_text[0];
            string val_6 = Localization.Localize(key:  "mystery_upper", defaultValue:  "MYSTERY", useSingularKey:  false);
            UnityEngine.UI.Text val_22 = this.response_buttons_text[1];
            string val_7 = Localization.Localize(key:  "adventure_upper", defaultValue:  "ADVENTURE", useSingularKey:  false);
            UnityEngine.UI.Text val_23 = this.response_buttons_text[2];
            string val_8 = Localization.Localize(key:  "romance_upper", defaultValue:  "ROMANCE", useSingularKey:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.message)) != false)
        {
                string[] val_10 = new string[5];
            val_19 = val_10.Length;
            val_10[0] = Localization.Localize(key:  "story_mode_popup_text_1", defaultValue:  "An envelope slides under your front door.\nYou open the door, but no one is there.", useSingularKey:  false);
            val_19 = val_10.Length;
            val_10[1] = "\n\n";
            val_20 = val_10.Length;
            val_10[2] = Localization.Localize(key:  "story_mode_popup_text_2", defaultValue:  "You know whatever is inside\nthe envelope will lead you on\na new journey.", useSingularKey:  false);
            val_20 = val_10.Length;
            val_10[3] = "\n\n";
            val_10[4] = Localization.Localize(key:  "story_mode_popup_text_3", defaultValue:  "What kind of journey would you like?", useSingularKey:  false);
            string val_14 = +val_10;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.close_text_no_thanks)) != false)
        {
                string val_16 = Localization.Localize(key:  "no_thanks", defaultValue:  "No Thanks", useSingularKey:  false);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.close_text_just_for_puzzles)) != false)
        {
                string val_18 = Localization.Localize(key:  "just_for_puzzles", defaultValue:  "I\'m just here for puzzles", useSingularKey:  false);
        }
        
        this.letter_group.SetActive(value:  true);
        this.feedback_group.SetActive(value:  false);
    }
    private void OnFeedbackSelected()
    {
        this.letter_group.SetActive(value:  false);
        if((UnityEngine.Object.op_Implicit(exists:  this.feedback_message)) != false)
        {
                string val_4 = Localization.Localize(key:  "story_coming_soon", defaultValue:  "Story Mode is coming soon!", useSingularKey:  false)(Localization.Localize(key:  "story_coming_soon", defaultValue:  "Story Mode is coming soon!", useSingularKey:  false)) + "\n" + Localization.Localize(key:  "thanks_for_feedback", defaultValue:  "Thanks for your feedback!", useSingularKey:  false)(Localization.Localize(key:  "thanks_for_feedback", defaultValue:  "Thanks for your feedback!", useSingularKey:  false));
        }
        
        this.feedback_group.SetActive(value:  true);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGStoryModePopup()
    {
    
    }
    private void <Awake>b__11_0()
    {
        this.OnDialogClick(index:  3);
    }
    private void <Awake>b__11_1()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
