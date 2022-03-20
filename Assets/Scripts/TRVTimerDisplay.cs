using UnityEngine;
public class TRVTimerDisplay : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Text pointsText;
    public System.Action<int> OnTick;
    private System.DateTime startTime;
    private float quizDuration;
    private System.Collections.IEnumerator timeRemainingTimer;
    
    // Properties
    public bool playingGame { get; }
    
    // Methods
    public bool get_playingGame()
    {
        return this.enabled;
    }
    public void Setup()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void UpdateTime(System.DateTime incStartTime, float secondsToCompleteQuiz)
    {
        if(this.enabled != true)
        {
                this.enabled = true;
        }
        
        this.startTime = incStartTime;
        this.quizDuration = secondsToCompleteQuiz;
        if(this.timeRemainingTimer != null)
        {
                return;
        }
        
        System.Collections.IEnumerator val_2 = this.CheckTimeRemaining();
        this.timeRemainingTimer = val_2;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  val_2);
    }
    public void StopTimer()
    {
        this.StopAllCoroutines();
        this.timeRemainingTimer = 0;
    }
    public string TimeRemainingText()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.startTime});
        float val_6 = (float)val_2._ticks.Seconds;
        val_6 = this.quizDuration - val_6;
        return (string)UnityEngine.Mathf.FloorToInt(f:  val_6).ToString();
    }
    public float TimeRemaining()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.startTime});
        float val_4 = (float)val_2._ticks.Seconds;
        val_4 = this.quizDuration - val_4;
        return (float)val_4;
    }
    private System.Collections.IEnumerator CheckTimeRemaining()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVTimerDisplay.<CheckTimeRemaining>d__12();
    }
    public TRVTimerDisplay()
    {
    
    }

}
