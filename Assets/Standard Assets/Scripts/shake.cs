using UnityEngine;
public class shake : MonoBehaviour
{
    // Fields
    public bool shakePosition;
    public UnityEngine.Vector3 positionMagnitude;
    public UnityEngine.GameObject positionEventReceiver;
    public string positionCallWhenFinished;
    public bool shakeRotate;
    public UnityEngine.Vector3 rotationMagnitude;
    public UnityEngine.GameObject rotationEventReceiver;
    public string rotationCallWhenFinished;
    public bool shakeOnEnable;
    public int iterations;
    public int shakeSpeed;
    public float delayInbetweens;
    public float duration;
    public float startDelay;
    public bool randomDelay;
    public UnityEngine.Vector2 minMaxDelay;
    public float shakeNowDuration;
    private UnityEngine.Vector3 initialPosition;
    private UnityEngine.Quaternion initialRotation;
    
    // Methods
    private void OnEnable()
    {
        UnityEngine.Vector3 val_2 = this.transform.localPosition;
        this.initialPosition = val_2;
        mem[1152921510472531140] = val_2.y;
        mem[1152921510472531144] = val_2.z;
        UnityEngine.Quaternion val_4 = this.transform.localRotation;
        this.initialRotation = val_4;
        mem[1152921510472531152] = val_4.y;
        mem[1152921510472531156] = val_4.z;
        mem[1152921510472531160] = val_4.w;
        if(this.shakeOnEnable == false)
        {
                return;
        }
        
        this.Shake();
    }
    private void OnDisable()
    {
        this.Stop();
    }
    private void OnDestroy()
    {
        int val_2 = DG.Tweening.DOTween.Kill(targetOrId:  this.transform, complete:  false);
        this.StopAllCoroutines();
    }
    public void Stop()
    {
        int val_2 = DG.Tweening.DOTween.Kill(targetOrId:  this.transform, complete:  false);
        this.StopAllCoroutines();
        this.RestoreInitialTransformSpecs();
    }
    public void Shake()
    {
        if(this.shakeRotate != false)
        {
                if(this.randomDelay != false)
        {
                float val_3 = UnityEngine.Random.Range(min:  this.minMaxDelay, max:  this.rotationMagnitude);
        }
        
            DG.Tweening.Tweener val_8 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.transform, duration:  this.duration, strength:  new UnityEngine.Vector3() {x = this.rotationMagnitude}, vibrato:  100, randomness:  100f, fadeOut:  true), delay:  this.startDelay), loops:  this.iterations), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void shake::RotationOnComplete())), autoKillOnCompletion:  true);
        }
        
        if(this.shakePosition == false)
        {
                return;
        }
        
        if(this.randomDelay != false)
        {
                float val_11 = UnityEngine.Random.Range(min:  this.minMaxDelay, max:  10f);
        }
        
        DG.Tweening.Tweener val_16 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.transform, duration:  this.duration, strength:  10f, vibrato:  100, randomness:  100f, snapping:  true, fadeOut:  true), delay:  this.startDelay), loops:  this.iterations), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void shake::PositionOnComplete())), autoKillOnCompletion:  true);
    }
    public void ShakeNow()
    {
        if(this.shakeRotate != false)
        {
                DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  this.transform, duration:  this.shakeNowDuration, strength:  new UnityEngine.Vector3() {x = this.rotationMagnitude}, vibrato:  50, randomness:  100f, fadeOut:  false), delay:  0f), loops:  1), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void shake::RotationOnComplete())), autoKillOnCompletion:  true);
        }
        
        if(this.shakePosition == false)
        {
                return;
        }
        
        DG.Tweening.Tweener val_14 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.transform, duration:  this.shakeNowDuration, strength:  new UnityEngine.Vector3() {x = this.positionMagnitude}, vibrato:  150, randomness:  90f, snapping:  true, fadeOut:  false), delay:  0f), loops:  1), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void shake::PositionOnComplete())), autoKillOnCompletion:  true);
    }
    private void RotationOnComplete()
    {
        this.RestoreInitialTransformSpecs();
        if(this.rotationEventReceiver == 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  this.rotationCallWhenFinished)) != false)
        {
                return;
        }
        
        this.rotationEventReceiver.SendMessage(methodName:  this.rotationCallWhenFinished, value:  this, options:  1);
    }
    private void PositionOnComplete()
    {
        this.RestoreInitialTransformSpecs();
        if(this.positionEventReceiver == 0)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  this.positionCallWhenFinished)) != false)
        {
                return;
        }
        
        this.positionEventReceiver.SendMessage(methodName:  this.positionCallWhenFinished, value:  this, options:  1);
    }
    private void RestoreInitialTransformSpecs()
    {
        this.transform.localPosition = new UnityEngine.Vector3() {x = this.initialPosition};
        this.transform.localRotation = new UnityEngine.Quaternion() {x = this.initialRotation};
    }
    public void setInitialValues()
    {
        UnityEngine.Vector3 val_2 = this.transform.localPosition;
        this.initialPosition = val_2;
        mem[1152921510473889348] = val_2.y;
        mem[1152921510473889352] = val_2.z;
        UnityEngine.Quaternion val_4 = this.transform.localRotation;
        this.initialRotation = val_4;
        mem[1152921510473889360] = val_4.y;
        mem[1152921510473889364] = val_4.z;
        mem[1152921510473889368] = val_4.w;
    }
    public shake()
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        this.positionMagnitude = val_1;
        mem[1152921510474009440] = val_1.y;
        mem[1152921510474009444] = val_1.z;
        this.positionCallWhenFinished = "";
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.rotationMagnitude = val_2;
        mem[1152921510474009472] = val_2.y;
        mem[1152921510474009476] = val_2.z;
        this.shakeOnEnable = true;
        this.duration = 1;
        this.iterations = 1;
        this.shakeSpeed = 0;
        this.rotationCallWhenFinished = "";
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  12f, y:  35f);
        this.minMaxDelay = val_3.x;
        this.shakeNowDuration = 2f;
    }

}
