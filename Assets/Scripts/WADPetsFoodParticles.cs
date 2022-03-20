using UnityEngine;
public class WADPetsFoodParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "OnPetsFoodUpdated";
    }
    public WADPetsFoodParticles()
    {
    
    }

}
