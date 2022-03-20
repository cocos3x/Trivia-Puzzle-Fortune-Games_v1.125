using UnityEngine;
public class WordIQFeedbackWord : MonoSingleton<WordIQFeedbackWord>
{
    // Fields
    public UnityEngine.GameObject displayGroup;
    private UnityEngine.UI.Text wordText;
    private System.Collections.Generic.Queue<string> queuedWords;
    
    // Methods
    public void ShowIQWord(string word)
    {
        this.queuedWords.Enqueue(item:  word);
    }
    public bool WantsToShow()
    {
        return (bool)(this.queuedWords > 0) ? 1 : 0;
    }
    public void UpdateDisplay()
    {
        string val_1 = this.queuedWords.Dequeue();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public WordIQFeedbackWord()
    {
        this.queuedWords = new System.Collections.Generic.Queue<System.String>();
    }

}
