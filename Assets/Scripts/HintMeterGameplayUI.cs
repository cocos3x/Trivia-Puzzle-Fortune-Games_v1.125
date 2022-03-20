using UnityEngine;
public class HintMeterGameplayUI : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image[] fillImages;
    
    // Methods
    private void Start()
    {
        System.Delegate val_5;
        if(HintMeterHandler._Instance == 0)
        {
                return;
        }
        
        this.UpdateHintMeterHints(progress:  13803.progressTowardsFreeHint);
        System.Action<System.Int32> val_3 = null;
        val_5 = val_3;
        val_3 = new System.Action<System.Int32>(object:  this, method:  System.Void HintMeterGameplayUI::UpdateHintMeterHints(int progress));
        System.Delegate val_4 = System.Delegate.Combine(a:  HintMeterHandler._Instance.hintMeterUpdate, b:  val_3);
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        HintMeterHandler._Instance.hintMeterUpdate = val_4;
        return;
        label_10:
    }
    private void UpdateHintMeterHints(int progress)
    {
        var val_10 = 0;
        label_6:
        if(val_10 >= this.fillImages.Length)
        {
            goto label_2;
        }
        
        this.fillImages[val_10].gameObject.SetActive(value:  (val_10 < progress) ? 1 : 0);
        val_10 = val_10 + 1;
        if(this.fillImages != null)
        {
            goto label_6;
        }
        
        throw new NullReferenceException();
        label_2:
        if(this.fillImages.Length == progress)
        {
                WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGameSpecificSound(id:  "Hint Reminder", clipIndex:  0);
            UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.AnimateFills());
            return;
        }
        
        if(progress != 0)
        {
                return;
        }
        
        this.StopAllCoroutines();
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        this.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        var val_12 = 0;
        do
        {
            if(val_12 >= this.fillImages.Length)
        {
                return;
        }
        
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.one;
            this.fillImages[val_12].transform.localScale = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            val_12 = val_12 + 1;
        }
        while(this.fillImages != null);
    
    }
    private System.Collections.IEnumerator AnimateFills()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new HintMeterGameplayUI.<AnimateFills>d__3();
    }
    private void OnDestroy()
    {
        System.Delegate val_2 = System.Delegate.Remove(source:  HintMeterHandler._Instance.hintMeterUpdate, value:  new System.Action<System.Int32>(object:  this, method:  System.Void HintMeterGameplayUI::UpdateHintMeterHints(int progress)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        HintMeterHandler._Instance.hintMeterUpdate = val_2;
        return;
        label_4:
    }
    public HintMeterGameplayUI()
    {
    
    }

}
