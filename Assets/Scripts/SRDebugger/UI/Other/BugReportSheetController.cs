using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class BugReportSheetController : SRMonoBehaviourEx
    {
        // Fields
        public UnityEngine.GameObject ButtonContainer;
        public UnityEngine.UI.Text ButtonText;
        public UnityEngine.UI.Button CancelButton;
        public System.Action CancelPressed;
        public UnityEngine.UI.InputField DescriptionField;
        public UnityEngine.UI.InputField EmailField;
        public UnityEngine.UI.Slider ProgressBar;
        public UnityEngine.UI.Text ResultMessageText;
        public System.Action ScreenshotComplete;
        public UnityEngine.UI.Button SubmitButton;
        public System.Action<bool, string> SubmitComplete;
        public System.Action TakingScreenshot;
        
        // Properties
        public bool IsCancelButtonEnabled { get; set; }
        
        // Methods
        public bool get_IsCancelButtonEnabled()
        {
            return this.CancelButton.gameObject.activeSelf;
        }
        public void set_IsCancelButtonEnabled(bool value)
        {
            this.CancelButton.gameObject.SetActive(value:  value);
        }
        protected override void Start()
        {
            this.Start();
            this.SetLoadingSpinnerVisible(visible:  false);
            this.ClearErrorMessage();
            this.ClearForm();
        }
        public void Submit()
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(selected:  0);
            this.ClearErrorMessage();
            this.SetLoadingSpinnerVisible(visible:  true);
            this.SetFormEnabled(e:  false);
            bool val_2 = System.String.IsNullOrEmpty(value:  this.EmailField.m_Text);
            if(val_2 != true)
            {
                    val_2.SetDefaultEmailFieldContents(value:  this.EmailField.m_Text);
            }
            
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.SubmitCo());
        }
        public void Cancel()
        {
            if(this.CancelPressed == null)
            {
                    return;
            }
            
            this.CancelPressed.Invoke();
        }
        private System.Collections.IEnumerator SubmitCo()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new BugReportSheetController.<SubmitCo>d__18();
        }
        private void OnBugReportProgress(float progress)
        {
            if(this.ProgressBar != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        private void OnBugReportComplete(bool didSucceed, string errorMessage)
        {
            string val_2;
            string val_3;
            if(didSucceed != false)
            {
                    this.ClearForm();
                val_2 = "Bug report submitted successfully";
                val_3 = 0;
            }
            else
            {
                    val_2 = "Error sending bug report";
                val_3 = errorMessage;
            }
            
            this.ShowErrorMessage(userMessage:  val_2, serverMessage:  val_3);
            this.SetLoadingSpinnerVisible(visible:  false);
            this.SetFormEnabled(e:  true);
            if(this.SubmitComplete == null)
            {
                    return;
            }
            
            this.SubmitComplete.Invoke(arg1:  didSucceed, arg2:  errorMessage);
        }
        protected void SetLoadingSpinnerVisible(bool visible)
        {
            this.ProgressBar.gameObject.SetActive(value:  visible);
            this.ButtonContainer.SetActive(value:  (~visible) & 1);
        }
        protected void ClearForm()
        {
            this.EmailField.text = this.GetDefaultEmailFieldContents();
            this.DescriptionField.text = "";
        }
        protected void ShowErrorMessage(string userMessage, string serverMessage)
        {
            string val_6 = userMessage;
            if((System.String.IsNullOrEmpty(value:  serverMessage)) != true)
            {
                    object[] val_2 = new object[1];
                val_2[0] = serverMessage;
                val_6 = val_6 + System.String.Format(format:  " (<b>{0}</b>)", args:  val_2)(System.String.Format(format:  " (<b>{0}</b>)", args:  val_2));
            }
            
            this.ResultMessageText.gameObject.SetActive(value:  true);
        }
        protected void ClearErrorMessage()
        {
            this.ResultMessageText.gameObject.SetActive(value:  false);
        }
        protected void SetFormEnabled(bool e)
        {
            bool val_1 = e;
            this.SubmitButton.interactable = val_1;
            this.CancelButton.interactable = val_1;
            bool val_2 = e;
            this.EmailField.interactable = val_2;
            this.DescriptionField.interactable = val_2;
        }
        private string GetDefaultEmailFieldContents()
        {
            return UnityEngine.PlayerPrefs.GetString(key:  "SRDEBUGGER_BUG_REPORT_LAST_EMAIL", defaultValue:  "");
        }
        private void SetDefaultEmailFieldContents(string value)
        {
            UnityEngine.PlayerPrefs.SetString(key:  "SRDEBUGGER_BUG_REPORT_LAST_EMAIL", value:  value);
            bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        }
        public BugReportSheetController()
        {
        
        }
    
    }

}
