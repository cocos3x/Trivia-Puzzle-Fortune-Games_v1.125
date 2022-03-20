using UnityEngine;
public class TRVStarChampionshipPopupUIParam
{
    // Fields
    public readonly float[] definedProgressDivisions;
    public int tier;
    public float progress;
    public string descriptionTop;
    
    // Methods
    public TRVStarChampionshipPopupUIParam()
    {
        this.definedProgressDivisions = new float[5] {0f, 5.650511E-20f, 5.671687E-20f, -1.011724E+27f, 4.600603E-41f};
    }

}
