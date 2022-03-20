using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    [Serializable]
    public struct LetterSlotLink
    {
        // Fields
        public SLC.Minigames.WordBalloon.WordBalloonLetterSlot left;
        public SLC.Minigames.WordBalloon.WordBalloonLetterSlot right;
        public SLC.Minigames.WordBalloon.WordBalloonLetterSlot above;
        public SLC.Minigames.WordBalloon.WordBalloonLetterSlot below;
        
        // Methods
        public SLC.Minigames.WordBalloon.WordBalloonLetterSlot GetLinkedSlot(SLC.Minigames.WordBalloon.SlotDirection direction)
        {
            if((direction - 1) > 3)
            {
                    return 0;
            }
            
            var val_2 = 32555612 + ((direction - 1)) << 2;
            val_2 = val_2 + 32555612;
            goto (32555612 + ((direction - 1)) << 2 + 32555612);
        }
    
    }

}
