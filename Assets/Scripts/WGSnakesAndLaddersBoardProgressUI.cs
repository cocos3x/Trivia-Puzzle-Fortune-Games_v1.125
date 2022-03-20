using UnityEngine;
public class WGSnakesAndLaddersBoardProgressUI : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject inProgressGroup;
    private UnityEngine.UI.Text progressText;
    private UnityEngine.GameObject notInProgressGroup;
    private UnityEngine.GameObject checkMark;
    private UnityEngine.UI.Text boardIndex;
    
    // Methods
    public void Setup(int boardNum, bool isCurrentBoard, int percentProgress)
    {
        int val_5 = percentProgress;
        if(isCurrentBoard == false)
        {
            goto label_1;
        }
        
        string val_1 = System.String.Format(format:  "{0}%", arg0:  val_5 = percentProgress);
        this.inProgressGroup.SetActive(value:  true);
        if(this.notInProgressGroup != null)
        {
            goto label_4;
        }
        
        label_1:
        bool val_2 = percentProgress.Equals(obj:  100);
        val_5 = this.boardIndex;
        if(val_2 != false)
        {
                if(val_5 != null)
        {
            goto label_7;
        }
        
        }
        
        string val_3 = boardNum.ToString();
        label_7:
        this.checkMark.SetActive(value:  val_2);
        this.notInProgressGroup.SetActive(value:  true);
        label_4:
        this.inProgressGroup.SetActive(value:  false);
    }
    public WGSnakesAndLaddersBoardProgressUI()
    {
    
    }

}
