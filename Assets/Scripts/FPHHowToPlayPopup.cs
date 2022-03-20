using UnityEngine;
public class FPHHowToPlayPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text lineCostText;
    
    // Methods
    public void Start()
    {
        FPHEcon val_1 = App.GetGameSpecificEcon<FPHEcon>();
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "fph_how_to_play_ln3", defaultValue:  "Consonants cost {0}. Vowels cost {0}.", useSingularKey:  false), arg0:  val_1.consonantCost, arg1:  val_1.vowelCost);
    }
    public FPHHowToPlayPopup()
    {
    
    }

}
