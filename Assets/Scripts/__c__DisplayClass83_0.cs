using UnityEngine;
private sealed class TRVLevelComplete.<>c__DisplayClass83_0
{
    // Fields
    public TRVLevelComplete <>4__this;
    public int multi;
    
    // Methods
    public TRVLevelComplete.<>c__DisplayClass83_0()
    {
    
    }
    internal void <MultiplierPicked>b__0()
    {
        this.<>4__this.noThanksButton.gameObject.SetActive(value:  false);
        this.<>4__this.redrawButton.gameObject.SetActive(value:  false);
        MonoSingleton<TRVMainController>.Instance.RewardMultiPicked(multi:  this.multi);
        UnityEngine.Coroutine val_5 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.SetupPostMinigameState());
    }

}
