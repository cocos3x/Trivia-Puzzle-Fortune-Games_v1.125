using UnityEngine;

namespace WADPets
{
    public class WADPetsUtils : ScriptableObject
    {
        // Fields
        private System.Collections.Generic.List<WADPets.WADPetInfo> PetsInfo;
        public System.Collections.Generic.List<WADPets.WADPetUpgradeRequirement> UpgradeRequirements;
        private static System.Collections.Generic.List<WADPets.WADPet> allPetsInfo;
        
        // Properties
        public System.Collections.Generic.List<WADPets.WADPet> AllPetsInfo { get; }
        
        // Methods
        public System.Collections.Generic.List<WADPets.WADPet> get_AllPetsInfo()
        {
            if(WADPets.WADPetsUtils.allPetsInfo != null)
            {
                    return (System.Collections.Generic.List<WADPets.WADPet>)WADPets.WADPetsUtils.allPetsInfo;
            }
            
            System.Collections.Generic.List<WADPets.WADPet> val_1 = new System.Collections.Generic.List<WADPets.WADPet>();
            WADPets.WADPetsUtils.allPetsInfo = val_1;
            List.Enumerator<T> val_2 = this.PetsInfo.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            .Info = 0;
            .LevelIndex = 0;
            .IsUnlocked = false;
            .Cards = 0;
            .CachedValueModifier = 0f;
            .IsFtuxShown = false;
            if(WADPets.WADPetsUtils.allPetsInfo == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  new WADPets.WADPet());
            goto label_5;
            label_3:
            0.Dispose();
            return (System.Collections.Generic.List<WADPets.WADPet>)WADPets.WADPetsUtils.allPetsInfo;
        }
        public static void QHACK_ResetWADPetsCollection()
        {
            WADPets.WADPetsUtils.allPetsInfo = 0;
        }
        public WADPetsUtils()
        {
            this.PetsInfo = new System.Collections.Generic.List<WADPets.WADPetInfo>();
            this.UpgradeRequirements = new System.Collections.Generic.List<WADPets.WADPetUpgradeRequirement>();
        }
    
    }

}
