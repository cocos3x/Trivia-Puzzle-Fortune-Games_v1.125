using UnityEngine;
public class DiceRollParticles : CurrencyParticles
{
    // Methods
    protected override string GetBalanceUpdateNotifiicationName()
    {
        return "OnDiceRollsBalanceUpdated";
    }
    public DiceRollParticles()
    {
    
    }

}
