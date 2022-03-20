using UnityEngine;
public class SpinsParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "OnSpinAmountUpdate";
    }
    public SpinsParticles()
    {
    
    }

}
