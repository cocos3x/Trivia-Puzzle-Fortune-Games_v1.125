using UnityEngine;
public class DebugMessageDisplay : MonoSingleton<DebugMessageDisplay>
{
    // Fields
    public UnityEngine.UI.Text textMessage;
    public UnityEngine.CanvasGroup canvasGroup;
    
    // Methods
    private void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(target:  this);
    }
    private static void SelfInstantiate()
    {
        UnityEngine.Object val_8;
        if((MonoSingleton<DebugMessageDisplay>.Instance) != 0)
        {
                return;
        }
        
        UnityEngine.Object val_4 = UnityEngine.Resources.Load(path:  "prefabs/DebugMessageDisplay", systemTypeInstance:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        if(val_4 != null)
        {
                var val_5 = (null == null) ? (val_4) : 0;
        }
        else
        {
                val_8 = 0;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_8)) != false)
        {
                UnityEngine.GameObject val_7 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_8);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "Could not load UI/Prefabs/DebugMessageDisplay.prefab");
    }
    public static void DisplayMessage(string msgTxt, float displayTime = 3)
    {
        DebugMessageDisplay.SelfInstantiate();
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<DebugMessageDisplay>.Instance)) == false)
        {
                return;
        }
        
        MonoSingleton<DebugMessageDisplay>.Instance.ShowMessage(msgTxt:  msgTxt, displayTime:  displayTime);
    }
    private void ShowMessage(string msgTxt, float displayTime)
    {
        this.canvasGroup.gameObject.SetActive(value:  true);
        this.FadeCanvas(from:  0f, to:  1f, duration:  0.25f);
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.WaitAndHide(displayTime:  displayTime));
    }
    private void HideMessage()
    {
        this.FadeCanvas(from:  1f, to:  0f, duration:  0.25f);
    }
    public void OnClick()
    {
        this.FadeCanvas(from:  1f, to:  0f, duration:  0.25f);
    }
    private System.Collections.IEnumerator WaitAndHide(float displayTime)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .displayTime = displayTime;
        return (System.Collections.IEnumerator)new DebugMessageDisplay.<WaitAndHide>d__8();
    }
    private void FadeCanvas(float from, float to, float duration)
    {
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.FadeCanvasCoroutine(from:  from, to:  to, duration:  duration));
    }
    private System.Collections.IEnumerator FadeCanvasCoroutine(float from, float to, float duration)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .from = from;
        .to = to;
        .duration = duration;
        return (System.Collections.IEnumerator)new DebugMessageDisplay.<FadeCanvasCoroutine>d__10();
    }
    public DebugMessageDisplay()
    {
    
    }

}
