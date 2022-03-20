using UnityEngine;
private sealed class ImageQuizDataManager.<>c__DisplayClass26_1
{
    // Fields
    public bool onRequestComplete;
    public byte[] imageRawData;
    public SLC.Minigames.ImageQuiz.ImageQuizDataManager.<>c__DisplayClass26_0 CS$<>8__locals1;
    
    // Methods
    public ImageQuizDataManager.<>c__DisplayClass26_1()
    {
    
    }
    internal void <LoadQuizLevelsCoroutine>b__0(bool isReqSuccess, byte[] rawData)
    {
        this.onRequestComplete = true;
        if((this.CS$<>8__locals1) != null)
        {
                this.CS$<>8__locals1.downloadSucceed = isReqSuccess;
            this.imageRawData = rawData;
            return;
        }
        
        throw new NullReferenceException();
    }
    internal bool <LoadQuizLevelsCoroutine>b__1()
    {
        return (bool)this.onRequestComplete;
    }

}
