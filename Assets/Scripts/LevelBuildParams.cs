using UnityEngine;
public class LevelBuildParams
{
    // Fields
    public int amountRequired;
    public int common_minRequiredWordLength;
    public int uncommon_minRequiredWordLength;
    public int rare_minRequiredWordLength;
    public int rare_maxRequiredWordLength;
    public bool runWordRemoval;
    public bool isChallengingLevel;
    public bool calculateAvailableExtraRequired;
    
    // Methods
    public LevelBuildParams()
    {
        this.rare_maxRequiredWordLength = 0;
        this.amountRequired = 0;
        this.common_minRequiredWordLength = 0;
        this.uncommon_minRequiredWordLength = 0;
        this.rare_minRequiredWordLength = 0;
        this.calculateAvailableExtraRequired = true;
    }

}
