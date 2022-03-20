using UnityEngine;
public class PrefsSerializationManager : MonoSingleton<PrefsSerializationManager>
{
    // Fields
    private static bool LOGGING;
    private bool shouldSaveThisFrame;
    
    // Methods
    public static bool SavePlayerPrefs()
    {
        var val_4;
        if((MonoSingleton<PrefsSerializationManager>.Instance) == 0)
        {
                UnityEngine.Debug.LogError(message:  "Saving PlayerPrefs: PrefsSerializationManager Doesn\'t Exist");
            UnityEngine.PlayerPrefs.Save();
            val_4 = 1;
            return (bool)val_4;
        }
        
        MonoSingleton<PrefsSerializationManager>.Instance.QueueSavePrefs();
        val_4 = 0;
        return (bool)val_4;
    }
    private void QueueSavePrefs()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        if(this.shouldSaveThisFrame != false)
        {
                val_4 = null;
            if(PrefsSerializationManager.LOGGING == false)
        {
                return;
        }
        
            UnityEngine.Debug.LogError(message:  "+++Adding Prefs save existing queue.", context:  this);
            return;
        }
        
        val_5 = null;
        if(PrefsSerializationManager.LOGGING != false)
        {
                UnityEngine.Debug.LogError(message:  ">>>>>>Queuing Prefs save this frame.", context:  this);
        }
        
        this.shouldSaveThisFrame = true;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.SaveAtEndOfFrame());
    }
    private System.Collections.IEnumerator SaveAtEndOfFrame()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PrefsSerializationManager.<SaveAtEndOfFrame>d__4();
    }
    public PrefsSerializationManager()
    {
    
    }
    private static PrefsSerializationManager()
    {
    
    }

}
