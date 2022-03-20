using UnityEngine;
public class GameBehavior
{
    // Fields
    private GameplayBehavior <gameplayBehavior>k__BackingField;
    private MetaGameBehavior <metaGameBehavior>k__BackingField;
    private HackBehavior <hackBehavior>k__BackingField;
    
    // Properties
    public GameplayBehavior gameplayBehavior { get; set; }
    public MetaGameBehavior metaGameBehavior { get; set; }
    public HackBehavior hackBehavior { get; set; }
    
    // Methods
    public GameplayBehavior get_gameplayBehavior()
    {
        return (GameplayBehavior)this.<gameplayBehavior>k__BackingField;
    }
    private void set_gameplayBehavior(GameplayBehavior value)
    {
        this.<gameplayBehavior>k__BackingField = value;
    }
    public MetaGameBehavior get_metaGameBehavior()
    {
        return (MetaGameBehavior)this.<metaGameBehavior>k__BackingField;
    }
    private void set_metaGameBehavior(MetaGameBehavior value)
    {
        this.<metaGameBehavior>k__BackingField = value;
    }
    public HackBehavior get_hackBehavior()
    {
        return (HackBehavior)this.<hackBehavior>k__BackingField;
    }
    private void set_hackBehavior(HackBehavior value)
    {
        this.<hackBehavior>k__BackingField = value;
    }
    public GameBehavior(WordGames.GameNames name)
    {
        HackBehavior val_8;
        if(name > 4)
        {
            goto label_1;
        }
        
        if((name == 1) || (name != 4))
        {
            goto label_5;
        }
        
        this.<gameplayBehavior>k__BackingField = new WUTGameplayBehavior();
        this.<metaGameBehavior>k__BackingField = new WUTMetaGameBehavior();
        WUTHackBehavior val_3 = null;
        val_8 = val_3;
        val_3 = new WUTHackBehavior();
        goto label_4;
        label_1:
        if((name - 9) > 10)
        {
            goto label_5;
        }
        
        var val_8 = 32497152 + ((name - 9)) << 2;
        val_8 = val_8 + 32497152;
        goto (32497152 + ((name - 9)) << 2 + 32497152);
        label_5:
        this.<gameplayBehavior>k__BackingField = new WADGameplayBehavior();
        this.<metaGameBehavior>k__BackingField = new WADMetaGameBehavior();
        WADHackBehavior val_7 = null;
        val_8 = val_7;
        val_7 = new WADHackBehavior();
        label_4:
        this.<hackBehavior>k__BackingField = val_8;
    }
    public virtual bool RandomizedChallengeParsing()
    {
        return true;
    }

}
