using UnityEngine;
public class CoinCurrencyParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "CoinsStatViewUpdate";
    }
    public CoinCurrencyParticles()
    {
    
    }

}
