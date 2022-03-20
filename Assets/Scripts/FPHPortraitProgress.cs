using UnityEngine;
public class FPHPortraitProgress
{
    // Fields
    public System.DateTime collectionStartTime;
    public System.DateTime LastLPNSetupTime;
    public string chosenCollection;
    public int starsCollected;
    public bool collectionCompleted;
    public bool showUnlockedPortrait;
    public bool hasStartedInstance;
    
    // Methods
    public override string ToString()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_3 = val_1.AppendLine(value:  "start time " + this.collectionStartTime);
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  "last setup at " + this.LastLPNSetupTime);
        System.Text.StringBuilder val_7 = val_1.AppendLine(value:  "chosen collection " + this.chosenCollection);
        System.Text.StringBuilder val_9 = val_1.AppendLine(value:  "stars collected " + this.starsCollected);
        System.Text.StringBuilder val_12 = val_1.AppendLine(value:  "completed? "("completed? ") + this.collectionCompleted.ToString());
        System.Text.StringBuilder val_15 = val_1.AppendLine(value:  "show unlocked? "("show unlocked? ") + this.showUnlockedPortrait.ToString());
        return (string)val_1;
    }
    public FPHPortraitProgress()
    {
    
    }

}
