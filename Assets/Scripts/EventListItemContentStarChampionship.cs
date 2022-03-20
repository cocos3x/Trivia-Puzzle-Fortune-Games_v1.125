using UnityEngine;
public class EventListItemContentStarChampionship : MonoBehaviour
{
    // Fields
    private TRVStarChampionshipProgressBar progressBar;
    
    // Methods
    public void UpdateProgressBar(TRVStarChampionshipProgressUIParam uiParam)
    {
        this.progressBar.UpdateProgressBar(progress:  null, tier:  W8);
    }
    public EventListItemContentStarChampionship()
    {
    
    }

}
