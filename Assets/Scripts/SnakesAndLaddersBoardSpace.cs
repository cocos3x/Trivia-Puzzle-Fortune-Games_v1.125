using UnityEngine;
public class SnakesAndLaddersBoardSpace : MonoBehaviour
{
    // Fields
    private SnakesAndLaddersEvent.BoardSpace <BoardSpaceInfo>k__BackingField;
    
    // Properties
    public SnakesAndLaddersEvent.BoardSpace BoardSpaceInfo { get; set; }
    
    // Methods
    public SnakesAndLaddersEvent.BoardSpace get_BoardSpaceInfo()
    {
        return (SnakesAndLaddersEvent.BoardSpace)this.<BoardSpaceInfo>k__BackingField;
    }
    private void set_BoardSpaceInfo(SnakesAndLaddersEvent.BoardSpace value)
    {
        this.<BoardSpaceInfo>k__BackingField = value;
    }
    public void Setup(SnakesAndLaddersEvent.BoardSpace numberSpace)
    {
        this.<BoardSpaceInfo>k__BackingField = numberSpace;
    }
    public SnakesAndLaddersBoardSpace()
    {
    
    }

}
