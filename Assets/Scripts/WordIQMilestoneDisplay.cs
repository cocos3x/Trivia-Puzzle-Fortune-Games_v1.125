using UnityEngine;
public class WordIQMilestoneDisplay : MonoBehaviour
{
    // Fields
    private string[] milestoneHexColors;
    private UnityEngine.GameObject mortarBoardBG;
    private UnityEngine.UI.Image mortarBoard;
    private UnityEngine.UI.Image upgradeGlow;
    private UnityEngine.UI.Image upgradeArrow;
    private UnityEngine.ParticleSystem upgradeBurst;
    
    // Methods
    public void UpdateMilestoneDisplay(int newMilestoneIndex)
    {
        this.mortarBoard.sprite = MonoSingleton<WordIQManagerUI>.Instance.MilestoneColorableSprite;
        UnityEngine.Color val_3 = this.mortarBoard.GetColorFromHexColor(colorString:  this.milestoneHexColors[0]);
        this.mortarBoard.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
    }
    public float GetMilestoneUpdateAnimTime()
    {
        return 0f;
    }
    public void AnimateMilestoneUpdate(int newMilestoneIndex)
    {
        38146 = new System.Object();
    }
    public void PlayBurstUpdateDisplay(int newMilestoneIndex)
    {
        this.UpdateMilestoneDisplay(newMilestoneIndex:  newMilestoneIndex);
    }
    private UnityEngine.Color GetColorFromHexColor(string colorString)
    {
        string val_2 = colorString;
        if((System.String.op_Equality(a:  val_2 = colorString, b:  "GOLD")) == false)
        {
                return MetricSystem.HexToColor(hex:  val_2);
        }
        
        val_2 = "FFD700";
        return MetricSystem.HexToColor(hex:  val_2);
    }
    public WordIQMilestoneDisplay()
    {
        int val_2;
        string[] val_1 = new string[10];
        val_2 = val_1.Length;
        val_1[0] = "6A6A6A";
        val_2 = val_1.Length;
        val_1[1] = "FDF022";
        val_2 = val_1.Length;
        val_1[2] = "3CFF00";
        val_2 = val_1.Length;
        val_1[3] = "02EAAB";
        val_2 = val_1.Length;
        val_1[4] = "028FF2";
        val_2 = val_1.Length;
        val_1[5] = "FF0000";
        val_2 = val_1.Length;
        val_1[6] = "FF7800";
        val_2 = val_1.Length;
        val_1[7] = "9600FF";
        val_2 = val_1.Length;
        val_1[8] = "FFFFFF";
        val_2 = val_1.Length;
        val_1[9] = "GOLD";
        this.milestoneHexColors = val_1;
    }

}
