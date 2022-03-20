using UnityEngine;
public class TRVHowToPlayPage5Description : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text text;
    
    // Methods
    private void OnEnable()
    {
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "trv_how_to_play_pg5", defaultValue:  "Use an Extra Life if you get a question wrong. Get a free Extra Life every {0} minutes.", useSingularKey:  false), arg0:  val_2.extraLifeCoolDown);
    }
    public TRVHowToPlayPage5Description()
    {
    
    }

}
