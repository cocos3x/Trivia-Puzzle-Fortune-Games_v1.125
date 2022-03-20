using UnityEngine;
private sealed class WGDailyChallengeLevelComplete.<PlayNewStarAnimation>d__50 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeLevelComplete <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeLevelComplete.<PlayNewStarAnimation>d__50(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_40;
        int val_41;
        float val_42;
        UnityEngine.Transform val_43;
        int val_44;
        float val_46;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        WGDailyChallengeLevelComplete.<>c__DisplayClass50_0 val_1 = new WGDailyChallengeLevelComplete.<>c__DisplayClass50_0();
        .<>4__this = this.<>4__this;
        val_40 = 1152921504893161472;
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_42 = 0.2f;
        var val_42 = 0;
        label_15:
        if(val_42 >= ((this.<>4__this.dcStars.Length) << ))
        {
            goto label_11;
        }
        
        if(val_42 < X23)
        {
                val_43 = this.<>4__this.dcStars[val_42].transform;
            UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  val_42, y:  val_42, z:  val_42);
            float val_41 = this.<>4__this.starPunchDuration;
            float val_40 = 0f;
            val_40 = val_41 * val_40;
            val_40 = val_40 / 3f;
            val_41 = val_41 + val_40;
            DG.Tweening.Tweener val_6 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  val_43, punch:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, duration:  this.<>4__this.starPunchDuration, vibrato:  2, elasticity:  0f), delay:  val_41);
        }
        
        val_42 = val_42 + 1;
        if((this.<>4__this.dcStars) != null)
        {
            goto label_15;
        }
        
        throw new NullReferenceException();
        label_1:
        val_44 = 0;
        this.<>1__state = 0;
        return (bool)val_44;
        label_2:
        val_44 = 0;
        return (bool)val_44;
        label_11:
        WGDailyChallengeManager val_7 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_43 = val_7.<RecentStarGained>k__BackingField;
        int[] val_8 = new int[1];
        WGDailyChallengeManager val_9 = MonoSingleton<WGDailyChallengeManager>.Instance;
        WGDailyChallengeManager val_10 = MonoSingleton<WGDailyChallengeManager>.Instance;
        int val_43 = val_10.monthHistory.stars;
        val_43 = (val_9.<Econ>k__BackingField.RequiredMonthlyStars) - val_43;
        val_8[0] = val_43;
        val_40 = 1152921504762277888;
        .newMonthStar = UnityEngine.Mathf.Min(a:  val_43, b:  UnityEngine.Mathf.Max(values:  val_8));
        this.<>4__this.monthlyProgressUI.InitializeMonthlyProgress(starsToAnimate:  0);
        DG.Tweening.Tween val_15 = DG.Tweening.DOVirtual.DelayedCall(delay:  (this.<>4__this.starPunchDuration) * 3f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGDailyChallengeLevelComplete.<>c__DisplayClass50_0::<PlayNewStarAnimation>b__0()), ignoreTimeScale:  true);
        val_41 = (WGDailyChallengeLevelComplete.<>c__DisplayClass50_0)[1152921517780661296].newMonthStar;
        MainModule val_16 = this.<>4__this.monthStarParticles.main;
        MinMaxCurve val_17 = val_16.m_ParticleSystem.startLifetime;
        float val_44 = this.<>4__this.starPunchDuration;
        val_44 = val_44 * 3f;
        val_46 = val_4.x.constantMin + val_44;
        this.<>4__this.monthlyProgressUI.TweenProgressBar(amount:  val_41, delay:  val_46);
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingCurrentWeek()) != false)
        {
                .CS$<>8__locals1 = val_1;
            int[] val_23 = new int[1];
            WGDailyChallengeManager val_24 = MonoSingleton<WGDailyChallengeManager>.Instance;
            val_41 = val_24.<Econ>k__BackingField.RequiredWeeklyStars;
            WGDailyChallengeManager val_25 = MonoSingleton<WGDailyChallengeManager>.Instance;
            int val_45 = val_25.weekHistory.stars;
            val_45 = val_41 - val_45;
            val_23[0] = val_45;
            .newWeekStar = UnityEngine.Mathf.Min(a:  val_43, b:  UnityEngine.Mathf.Max(values:  val_23));
            this.<>4__this.weeklyProgressUI.InitializeWeeklyProgress(starsToAnimate:  0);
            DG.Tweening.Tween val_30 = DG.Tweening.DOVirtual.DelayedCall(delay:  (this.<>4__this.starPunchDuration) * 3f, callback:  new DG.Tweening.TweenCallback(object:  new WGDailyChallengeLevelComplete.<>c__DisplayClass50_1(), method:  System.Void WGDailyChallengeLevelComplete.<>c__DisplayClass50_1::<PlayNewStarAnimation>b__1()), ignoreTimeScale:  true);
            val_43 = (WGDailyChallengeLevelComplete.<>c__DisplayClass50_1)[1152921517780837408].newWeekStar;
            MainModule val_31 = this.<>4__this.weekStarParticles.main;
            MinMaxCurve val_32 = val_31.m_ParticleSystem.startLifetime;
            float val_46 = this.<>4__this.starPunchDuration;
            val_46 = val_46 * 3f;
            val_46 = val_4.x.constantMin + val_46;
            this.<>4__this.weeklyProgressUI.TweenProgressBar(amount:  val_43, delay:  val_46);
        }
        else
        {
                this.<>4__this.weeklyProgressUI.InitializeWeeklyProgress(starsToAnimate:  0);
        }
        
        MainModule val_34 = this.<>4__this.monthStarParticles.main;
        MinMaxCurve val_35 = val_34.m_ParticleSystem.startLifetime;
        val_42 = val_4.x.constantMin;
        UnityEngine.WaitForSeconds val_38 = null;
        float val_37 = (this.<>4__this.starPunchDuration) * 3f;
        val_37 = val_42 + val_37;
        val_38 = new UnityEngine.WaitForSeconds(seconds:  val_37);
        val_44 = 1;
        this.<>2__current = val_38;
        this.<>1__state = val_44;
        return (bool)val_44;
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
