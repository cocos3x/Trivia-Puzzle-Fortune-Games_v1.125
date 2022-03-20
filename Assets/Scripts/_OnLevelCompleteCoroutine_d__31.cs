using UnityEngine;
private sealed class ImageQuizUIController.<OnLevelCompleteCoroutine>d__31 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.ImageQuiz.ImageQuizUIController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageQuizUIController.<OnLevelCompleteCoroutine>d__31(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_10;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_17;
        }
        
        this.<>1__state = 0;
        this.<>4__this.clueImageDisplay.ToggleResultOverlay(isVisible:  true, isCorrect:  true);
        MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Correct", clipIndex:  0, volumeScale:  1f);
        val_10 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_10;
        return (bool)val_10;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.gameplayUIGroup.alpha = 0f;
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) == false)
        {
            goto label_15;
        }
        
        this.<>4__this.checkpointSlider.UpdateUI();
        goto label_17;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.loadingIndicator.Show(isVisible:  false);
        goto label_20;
        label_15:
        if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.HasLevelData()) == false)
        {
            goto label_24;
        }
        
        label_20:
        this.<>4__this.DisplayLevel();
        label_17:
        val_10 = 0;
        return (bool)val_10;
        label_24:
        this.<>4__this.loadingIndicator.Show(isVisible:  true);
        this.<>2__current = new UnityEngine.WaitUntil(predicate:  new System.Func<System.Boolean>(object:  MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance, method:  public System.Boolean SLC.Minigames.ImageQuiz.ImageQuizMinigameManager::HasLevelData()));
        this.<>1__state = 2;
        return (bool)val_10;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
