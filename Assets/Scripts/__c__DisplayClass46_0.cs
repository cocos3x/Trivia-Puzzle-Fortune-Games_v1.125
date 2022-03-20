using UnityEngine;
private sealed class ImageQuizUIController.<>c__DisplayClass46_0
{
    // Fields
    public SLC.Minigames.ImageQuiz.ImageQuizUIController <>4__this;
    public SLC.Minigames.ImageQuiz.ImageQuizLetterButton buttonToHighlight;
    
    // Methods
    public ImageQuizUIController.<>c__DisplayClass46_0()
    {
    
    }
    internal void <FtuxHighlightAction>b__0()
    {
        this.<>4__this.ftuxPointer.gameObject.SetActive(value:  true);
        this.<>4__this.ftuxPointer.PointAt(targetObj:  this.buttonToHighlight.gameObject, flipPointerX:  false, flipPointerY:  false);
    }

}
