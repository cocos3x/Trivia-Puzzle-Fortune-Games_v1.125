using UnityEngine;
private sealed class TRVStarChampionshipEventPopup.<DelayShowingRewardPopup>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVStarChampionshipEventPopup <>4__this;
    public TRVStarChampionshipRewardUIParam param;
    private TRVStarChampionshipEventPopup.<>c__DisplayClass14_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVStarChampionshipEventPopup.<DelayShowingRewardPopup>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Events.UnityAction val_10;
        int val_11;
        val_10 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new TRVStarChampionshipEventPopup.<>c__DisplayClass14_0();
        .<>4__this = this.<>4__this;
        this.<>8__1.param = this.param;
        this.<>4__this.popupHolder.SetActive(value:  false);
        this.<>4__this.gemAnim.gameObject.SetActive(value:  false);
        val_11 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>8__1.param.delay);
        this.<>1__state = val_11;
        return (bool)val_11;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.description_bottom.gameObject.SetActive(value:  false);
        this.<>4__this.progressBar.UpdateProgressBar(progress:  null, tier:  0);
        string val_5 = this.<>8__1.param.reward.ToString();
        this.<>4__this.rewardGroup.SetActive(value:  true);
        string val_6 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        UnityEngine.Events.UnityAction val_7 = null;
        val_10 = val_7;
        val_7 = new UnityEngine.Events.UnityAction(object:  this.<>8__1, method:  System.Void TRVStarChampionshipEventPopup.<>c__DisplayClass14_0::<DelayShowingRewardPopup>b__0());
        this.<>4__this.button.m_OnClick.AddListener(call:  val_7);
        this.<>4__this.closeButton.gameObject.SetActive(value:  false);
        this.<>4__this.gemAnim.gameObject.SetActive(value:  true);
        this.<>4__this.popupHolder.SetActive(value:  true);
        label_2:
        val_11 = 0;
        return (bool)val_11;
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
