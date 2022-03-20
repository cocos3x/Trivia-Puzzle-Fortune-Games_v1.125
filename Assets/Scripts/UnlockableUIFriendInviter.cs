using UnityEngine;
public class UnlockableUIFriendInviter : WGUnlockableUIElement
{
    // Properties
    protected override bool FeatureHidden { get; }
    
    // Methods
    protected override bool get_FeatureHidden()
    {
        var val_5;
        GameEcon val_1 = App.getGameEcon;
        if((val_1.friendInvButtonDisplayLevel & 2147483648) == 0)
        {
                GameEcon val_3 = App.getGameEcon;
            var val_4 = (App.Player < val_3.friendInvButtonDisplayLevel) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 1;
        return (bool)val_5;
    }
    public UnlockableUIFriendInviter()
    {
    
    }

}
