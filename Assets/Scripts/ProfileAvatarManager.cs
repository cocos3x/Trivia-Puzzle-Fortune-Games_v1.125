using UnityEngine;
public class ProfileAvatarManager : MonoSingleton<ProfileAvatarManager>
{
    // Fields
    private SLC.Social.AvatarConfig avatarConfig;
    private System.Collections.Generic.List<ProfileAvatarDisplayModifier> avatarDisplayModifiers;
    private bool hasSortedModifiers;
    private System.Collections.Generic.List<ProfileAvatarDisplayModifier> _orderedAvatarModifiers;
    
    // Properties
    public SLC.Social.AvatarConfig ProfileAvatarConfig { get; }
    private System.Collections.Generic.List<ProfileAvatarDisplayModifier> OrderedAvatarModifiers { get; }
    
    // Methods
    public SLC.Social.AvatarConfig get_ProfileAvatarConfig()
    {
        SLC.Social.AvatarConfig val_3;
        if(this.avatarConfig == 0)
        {
                this.avatarConfig = SLC.Social.Leagues.LeaguesUIManager.memberAvatarHandler;
            return val_3;
        }
        
        val_3 = this.avatarConfig;
        return val_3;
    }
    private System.Collections.Generic.List<ProfileAvatarDisplayModifier> get_OrderedAvatarModifiers()
    {
        System.Collections.Generic.List<ProfileAvatarDisplayModifier> val_4;
        var val_5;
        System.Func<ProfileAvatarDisplayModifier, System.Int32> val_7;
        val_4 = this._orderedAvatarModifiers;
        if(val_4 != null)
        {
                return (System.Collections.Generic.List<ProfileAvatarDisplayModifier>)val_3;
        }
        
        val_5 = null;
        val_5 = null;
        val_7 = ProfileAvatarManager.<>c.<>9__7_0;
        if(val_7 == null)
        {
                System.Func<ProfileAvatarDisplayModifier, System.Int32> val_1 = null;
            val_7 = val_1;
            val_1 = new System.Func<ProfileAvatarDisplayModifier, System.Int32>(object:  ProfileAvatarManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 ProfileAvatarManager.<>c::<get_OrderedAvatarModifiers>b__7_0(ProfileAvatarDisplayModifier p));
            ProfileAvatarManager.<>c.<>9__7_0 = val_7;
        }
        
        System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<ProfileAvatarDisplayModifier>(source:  System.Linq.Enumerable.OrderBy<ProfileAvatarDisplayModifier, System.Int32>(source:  this.avatarDisplayModifiers, keySelector:  val_1));
        this._orderedAvatarModifiers = val_3;
        return (System.Collections.Generic.List<ProfileAvatarDisplayModifier>)val_3;
    }
    public void AppendAvatarDisplay(AvatarSlotUGUI avatarDisplay, SLC.Social.Profile profile)
    {
        var val_6;
        System.Collections.Generic.List<ProfileAvatarDisplayModifier> val_1 = this.OrderedAvatarModifiers;
        val_6 = 4;
        do
        {
            var val_2 = val_6 - 4;
            if(val_2 >= true)
        {
                return;
        }
        
            System.Collections.Generic.List<ProfileAvatarDisplayModifier> val_3 = this.OrderedAvatarModifiers;
            if(true <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((0 & 1) != 0)
        {
                System.Collections.Generic.List<ProfileAvatarDisplayModifier> val_4 = this.OrderedAvatarModifiers;
            if((mem[-2305843009213693952]) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((mem[-2305843009213693952] + 32) & 1) != 0)
        {
                System.Collections.Generic.List<ProfileAvatarDisplayModifier> val_5 = this.OrderedAvatarModifiers;
            if((mem[-2305843009213693952] + 32) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((mem[-2305843009213693952] + 32 + 32 + 28) != 0)
        {
                return;
        }
        
        }
        
        }
        
            val_6 = val_6 + 1;
        }
        while(this.OrderedAvatarModifiers != null);
        
        throw new NullReferenceException();
    }
    public ProfileAvatarManager()
    {
    
    }

}
