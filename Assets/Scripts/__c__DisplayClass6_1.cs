using UnityEngine;
private sealed class WADPetsFtuxPopup.<>c__DisplayClass6_1
{
    // Fields
    public int i;
    public WADPetsFtuxPopup.<>c__DisplayClass6_0 CS$<>8__locals1;
    
    // Methods
    public WADPetsFtuxPopup.<>c__DisplayClass6_1()
    {
    
    }
    internal bool <SetupFtux>b__0(WADPetsFtuxDisplay x)
    {
        WADPetsFtuxPopup.<>c__DisplayClass6_0 val_2 = this.CS$<>8__locals1;
        if(val_2 <= this.i)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.i) << 3);
        return (bool)(x.PetAbility == ((this.CS$<>8__locals1 + (this.i) << 3).pets)) ? 1 : 0;
    }

}
