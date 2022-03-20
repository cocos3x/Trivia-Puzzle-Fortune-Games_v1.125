using UnityEngine;
public class GemsParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "GemStatViewUpdate";
    }
    public GemsParticles()
    {
    
    }

}
