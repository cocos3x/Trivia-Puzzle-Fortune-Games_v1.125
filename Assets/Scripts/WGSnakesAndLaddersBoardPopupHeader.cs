using UnityEngine;
public class WGSnakesAndLaddersBoardPopupHeader : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<WGSnakesAndLaddersBoardProgressUI> progress;
    
    // Methods
    public void Setup(System.Collections.Generic.List<SnakesAndLaddersEvent.Board> boards)
    {
        do
        {
            if(30105600 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            float val_2 = SnakesAndLaddersEventHandler.<Instance>k__BackingField.__il2cppRuntimeField_20.GetPercentProgress();
            val_2 = val_2 * 100f;
            int val_4 = 0 + 1;
            val_2 = (val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            48.Setup(boardNum:  val_4, isCurrentBoard:  ((SnakesAndLaddersEventHandler.<Instance>k__BackingField.GetCurrentBoardIndex()) == 0) ? 1 : 0, percentProgress:  (int)val_2);
        }
        while(val_4 < 1152921504934539264);
    
    }
    public WGSnakesAndLaddersBoardPopupHeader()
    {
    
    }

}
