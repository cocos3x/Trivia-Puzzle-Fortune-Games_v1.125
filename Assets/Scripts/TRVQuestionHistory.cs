using UnityEngine;
public class TRVQuestionHistory
{
    // Fields
    private string _questionID;
    private int questionDifficulty;
    public int extraLivesUsed;
    public int hintsUsed;
    public int freehintsused;
    public bool rerollQuestionPowerUpUsed;
    public bool freererollQuestionPowerUpUsed;
    public int pointsGained;
    public bool ranOutOfTime;
    public bool extraLifePurchased;
    public bool expertAnswerUsed;
    public bool freeexpertAnswerUsed;
    private float questionMaxDuration;
    private System.DateTime questionStartTime;
    private System.DateTime questionEndTime;
    
    // Properties
    public string questionID { get; }
    public bool extraLifeUsed { get; }
    public bool hintUsed { get; }
    public bool freehintUsed { get; }
    public bool answeredCorrectly { get; }
    public float questionTimeTaken { get; }
    
    // Methods
    public TRVQuestionHistory(TRVGameplayState prevState, QuestionData qd)
    {
        var val_7;
        this.questionMaxDuration = 20f;
        val_7 = null;
        val_7 = null;
        this.questionStartTime = System.DateTime.MinValue;
        this.questionEndTime = System.DateTime.MinValue;
        val_1 = new System.Object();
        this.extraLivesUsed = prevState.extraLivesUsed;
        this.hintsUsed = prevState.hintsUsed;
        this.freehintsused = prevState.freehintsUsed;
        this.pointsGained = prevState.pointsEarned;
        this._questionID = qd.<questionID>k__BackingField;
        this.questionDifficulty = qd.<difficulty>k__BackingField;
        this.extraLifePurchased = prevState.extraLifePurchased;
        this.rerollQuestionPowerUpUsed = prevState.rerollQuestionPowerupUsed;
        this.freererollQuestionPowerUpUsed = prevState.freererollQuestionPowerupUsed;
        this.questionMaxDuration = prevState.quizDuration;
        this.ranOutOfTime = System.String.op_Equality(a:  prevState.selectedAnswer, b:  "!");
        this.questionStartTime = prevState.quizStartTime;
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        this.questionEndTime = val_4;
        this.expertAnswerUsed = (prevState.expertHintedAnswers.Count > 0) ? 1 : 0;
        this.freeexpertAnswerUsed = prevState.freeExpertAnswer;
    }
    public string get_questionID()
    {
        return (string)this._questionID;
    }
    public bool get_extraLifeUsed()
    {
        return (bool)(this.extraLivesUsed > 0) ? 1 : 0;
    }
    public bool get_hintUsed()
    {
        return (bool)(this.hintsUsed > 0) ? 1 : 0;
    }
    public bool get_freehintUsed()
    {
        return (bool)(this.freehintsused > 0) ? 1 : 0;
    }
    public bool get_answeredCorrectly()
    {
        return (bool)(this.pointsGained > 0) ? 1 : 0;
    }
    public float get_questionTimeTaken()
    {
        System.TimeSpan val_1 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.questionEndTime}, d2:  new System.DateTime() {dateData = this.questionStartTime});
        if((float)val_1._ticks.TotalSeconds > 0f)
        {
                return (float)this.questionMaxDuration;
        }
        
        return (float)this.questionMaxDuration;
    }
    public System.Collections.Generic.Dictionary<string, object> GetTrackingData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Question ID", value:  this._questionID);
        val_1.Add(key:  "Difficulty", value:  this.questionDifficulty);
        val_1.Add(key:  "Correct", value:  (this.pointsGained > 0) ? 1 : 0);
        val_1.Add(key:  "Hint Used", value:  (this.hintsUsed > 0) ? 1 : 0);
        val_1.Add(key:  "Free Hint Used", value:  (this.freehintsused > 0) ? 1 : 0);
        val_1.Add(key:  "Reroll Used", value:  this.rerollQuestionPowerUpUsed);
        val_1.Add(key:  "Free Reroll Used", value:  this.freererollQuestionPowerUpUsed);
        val_1.Add(key:  "Extra Life Used", value:  (this.extraLivesUsed > 0) ? 1 : 0);
        val_1.Add(key:  "Stars Earned", value:  this.pointsGained);
        val_1.Add(key:  "Extra Life Purchased", value:  this.extraLifePurchased);
        val_1.Add(key:  "Expert Answer Used", value:  this.expertAnswerUsed);
        val_1.Add(key:  "Free Expert Used", value:  this.freeexpertAnswerUsed);
        return val_1;
    }
    public override string ToString()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  "Extra life used? "("Extra life used? ") + (this.extraLivesUsed > 0) ? 1 : 0.ToString()((this.extraLivesUsed > 0) ? 1 : 0.ToString()));
        System.Text.StringBuilder val_7 = val_1.AppendLine(value:  "hints used? "("hints used? ") + this.hintsUsed);
        System.Text.StringBuilder val_9 = val_1.AppendLine(value:  "free hints used ?"("free hints used ?") + this.freehintsused);
        System.Text.StringBuilder val_12 = val_1.AppendLine(value:  "rerolls used? "("rerolls used? ") + this.rerollQuestionPowerUpUsed.ToString());
        System.Text.StringBuilder val_15 = val_1.AppendLine(value:  "free rerolls used? "("free rerolls used? ") + this.freererollQuestionPowerUpUsed.ToString());
        System.Text.StringBuilder val_17 = val_1.AppendLine(value:  "points gained? "("points gained? ") + this.pointsGained);
        System.Text.StringBuilder val_21 = val_1.AppendLine(value:  "answered correctly? "("answered correctly? ") + (this.pointsGained > 0) ? 1 : 0.ToString()((this.pointsGained > 0) ? 1 : 0.ToString()));
        System.Text.StringBuilder val_23 = val_1.AppendLine(value:  "q max duration? "("q max duration? ") + this.questionMaxDuration);
        System.Text.StringBuilder val_25 = val_1.AppendLine(value:  "q start time? "("q start time? ") + this.questionStartTime);
        System.Text.StringBuilder val_27 = val_1.AppendLine(value:  "q end time? "("q end time? ") + this.questionEndTime);
        System.Text.StringBuilder val_30 = val_1.AppendLine(value:  "q time taken? "("q time taken? ") + this.questionTimeTaken);
        System.Text.StringBuilder val_33 = val_1.AppendLine(value:  "Expert Answer Used? "("Expert Answer Used? ") + this.expertAnswerUsed.ToString());
        System.Text.StringBuilder val_36 = val_1.AppendLine(value:  "Free Expert Used? "("Free Expert Used? ") + this.freeexpertAnswerUsed.ToString());
        return (string)val_1;
    }

}
