using UnityEngine;
public class WordBubblesBubbleSelect : WordBubblesBubble
{
    // Methods
    public override void OnClick()
    {
        SLC.Minigames.Bubbles.WordBubblesController val_1 = MonoSingleton<SLC.Minigames.Bubbles.WordBubblesController>.Instance;
        if(val_1.IsGameOver != false)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.Bubbles.WordBubblesUIController>.Instance.TurnBackWordElement(select:  this);
    }
    public WordBubblesBubbleSelect()
    {
    
    }

}
