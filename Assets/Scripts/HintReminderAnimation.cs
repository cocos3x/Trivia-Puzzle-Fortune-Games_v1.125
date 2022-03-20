using UnityEngine;
public class HintReminderAnimation : MonoBehaviour
{
    // Fields
    private float idleTriggerTime;
    private bool startHidden;
    private bool doShakeInstead;
    public UnityEngine.UI.Image shineImage;
    private UnityEngine.WaitForSeconds transitionTime;
    private UnityEngine.Vector3 startPos;
    private float nextTime;
    
    // Methods
    private void Start()
    {
        float val_1 = UnityEngine.Time.time;
        val_1 = val_1 + this.idleTriggerTime;
        this.nextTime = val_1;
        UnityEngine.Vector3 val_3 = this.shineImage.transform.localPosition;
        this.startPos = val_3;
        mem[1152921517680982964] = val_3.y;
        mem[1152921517680982968] = val_3.z;
        if(this.startHidden == false)
        {
                return;
        }
        
        if(this.doShakeInstead != false)
        {
                return;
        }
        
        this.shineImage.enabled = false;
        this.shineImage.canvasRenderer.SetAlpha(alpha:  0f);
    }
    private void Update()
    {
        if(UnityEngine.Input.touchCount < 1)
        {
                if(UnityEngine.Time.time < this.nextTime)
        {
                return;
        }
        
            WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGameSpecificSound(id:  "Picker Hint Reminder", clipIndex:  0);
            if(this.doShakeInstead != false)
        {
                this.ShakeTween();
        }
        else
        {
                UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.ShineRoutine());
        }
        
            float val_6 = UnityEngine.Time.time;
        }
        
        val_6 = val_6 + this.idleTriggerTime;
        this.nextTime = val_6;
    }
    private void SetNextTime()
    {
        float val_1 = UnityEngine.Time.time;
        val_1 = val_1 + this.idleTriggerTime;
        this.nextTime = val_1;
    }
    private void ShakeTween()
    {
        this.shineImage.enabled = true;
        DG.Tweening.Sequence val_2 = DG.Tweening.ShortcutExtensions.DOLocalJump(target:  this.shineImage.transform, endValue:  new UnityEngine.Vector3() {x = this.startPos}, jumpPower:  50f, numJumps:  2, duration:  1f, snapping:  true);
    }
    private System.Collections.IEnumerator ShineRoutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new HintReminderAnimation.<ShineRoutine>d__11();
    }
    private void OnDisable()
    {
        this.StopAllCoroutines();
    }
    public HintReminderAnimation()
    {
        this.idleTriggerTime = 13f;
        this.startHidden = true;
        this.transitionTime = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.startPos = val_2;
        mem[1152921517681753380] = val_2.y;
        mem[1152921517681753384] = val_2.z;
    }

}
