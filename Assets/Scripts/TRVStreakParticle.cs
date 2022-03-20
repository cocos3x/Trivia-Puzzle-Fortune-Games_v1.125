using UnityEngine;
public class TRVStreakParticle : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "OnTRVStreakUpdate";
    }
    public TRVStreakParticle()
    {
    
    }

}
