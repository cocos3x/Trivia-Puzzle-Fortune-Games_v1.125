using UnityEngine;
public class GoldenApplesParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "OnStarsUpdated";
    }
    public GoldenApplesParticles()
    {
    
    }

}
