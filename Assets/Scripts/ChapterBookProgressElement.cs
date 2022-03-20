using UnityEngine;
public class ChapterBookProgressElement : MonoBehaviour
{
    // Fields
    private UnityEngine.Sprite sprite_leftSideBar;
    private UnityEngine.Sprite sprite_middleBar;
    private UnityEngine.Sprite sprite_rightSideBar;
    private UnityEngine.UI.Image extraProgressImage;
    private ExtraProgressFlexible extraProgress;
    private UnityEngine.UI.Text chapterText;
    private UnityEngine.GameObject checkMark;
    private UnityEngine.GameObject divider;
    private UnityEngine.GameObject coinGroup;
    private UnityEngine.GameObject coinReward;
    private UnityEngine.GameObject coinRewardGlow;
    
    // Methods
    public void Setup(int chapter, float completeProgress, int lastChapterInBook, bool isCurrentChapter)
    {
        UnityEngine.Sprite val_6;
        this.extraProgress.target = 1f;
        this.extraProgress.current = completeProgress;
        if(chapter == 1)
        {
                val_6 = this.sprite_leftSideBar;
        }
        else
        {
                if((chapter == lastChapterInBook) && ((UnityEngine.Mathf.Approximately(a:  completeProgress, b:  1f)) != false))
        {
                val_6 = this.sprite_rightSideBar;
        }
        else
        {
                val_6 = this.sprite_middleBar;
        }
        
        }
        
        this.extraProgressImage.sprite = val_6;
        string val_2 = this.extraProgressImage.RomanNumeralize(num:  chapter);
        this.chapterText.gameObject.SetActive(value:  (completeProgress < 1f) ? 1 : 0);
        this.checkMark.SetActive(value:  (completeProgress >= 1f) ? 1 : 0);
        this.divider.SetActive(value:  false);
        this.coinGroup.SetActive(value:  false);
    }
    public void SetupAsDivider(bool lastElement)
    {
        this.chapterText.gameObject.SetActive(value:  false);
        this.checkMark.gameObject.SetActive(value:  false);
        this.extraProgress.gameObject.SetActive(value:  false);
        this.divider.SetActive(value:  (~lastElement) & 1);
        this.coinGroup.SetActive(value:  false);
    }
    public void SetupAsCoin(int chapter, float completeProgress, int lastChapterInBook, bool isCurrentChapter)
    {
        bool val_8;
        var val_9;
        this.chapterText.gameObject.SetActive(value:  false);
        this.checkMark.gameObject.SetActive(value:  false);
        this.extraProgress.gameObject.SetActive(value:  false);
        this.divider.SetActive(value:  false);
        this.coinGroup.SetActive(value:  true);
        if(chapter == lastChapterInBook)
        {
                val_8 = 0;
        }
        else
        {
                var val_4 = (completeProgress < 0) ? 1 : 0;
            val_8 = val_4 | isCurrentChapter;
        }
        
        this.coinReward.SetActive(value:  val_8);
        val_4 = val_8 & isCurrentChapter;
        if(val_4 == false)
        {
            goto label_12;
        }
        
        val_9 = 0;
        bool val_6 = UnityEngine.Mathf.Approximately(a:  completeProgress, b:  1f);
        if(this.coinRewardGlow != null)
        {
            goto label_15;
        }
        
        label_12:
        val_9 = 0;
        label_15:
        this.coinRewardGlow.SetActive(value:  val_9 & 1);
    }
    private string RomanNumeralize(int num)
    {
        if((num - 1) <= 4)
        {
                var val_3 = 32560756 + ((num - 1)) << 2;
            val_3 = val_3 + 32560756;
        }
        else
        {
                string val_2 = num.ToString();
            return (string);
        }
    
    }
    public ChapterBookProgressElement()
    {
    
    }

}
