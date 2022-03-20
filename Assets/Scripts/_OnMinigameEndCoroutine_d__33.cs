using UnityEngine;
private sealed class ImageQuizUIController.<OnMinigameEndCoroutine>d__33 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.ImageQuiz.ImageQuizUIController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageQuizUIController.<OnMinigameEndCoroutine>d__33(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_6;
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
            goto label_3;
        }
        
        this.<>1__state = 0;
        this.<>4__this.clueImageDisplay.ToggleResultOverlay(isVisible:  true, isCorrect:  false);
        MonoSingleton<MinigameAudioController>.Instance.PlayGameSpecificSound(id:  "Wrong", clipIndex:  0, volumeScale:  1f);
        val_6 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_6;
        return (bool)val_6;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.clueImageDisplay.ToggleResultOverlay(isVisible:  false, isCorrect:  false);
        this.<>4__this.wordInputDisplay.ShowAnswer();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1.5f);
        this.<>1__state = 2;
        val_6 = 1;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.gameplayUIGroup.alpha = 0f;
        bool val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        label_3:
        val_6 = 0;
        return (bool)val_6;
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
