using UnityEngine;
public class WGCompliment : MonoBehaviour
{
    // Fields
    private TMPro.TextMeshProUGUI displayText;
    private UnityEngine.Animator anim;
    private string[] localizationKeys;
    private string[] localizationDefaults;
    public bool IsEnabled;
    
    // Methods
    public void ShowRandom()
    {
        if(this.IsAvailable2Show() == false)
        {
                return;
        }
        
        this.displayText.text = Localization.Localize(key:  this.localizationKeys[(long)UnityEngine.Random.Range(min:  0, max:  this.localizationKeys.Length)], defaultValue:  this.localizationDefaults[(long)UnityEngine.Random.Range(min:  0, max:  this.localizationKeys.Length)], useSingularKey:  false);
        if(this.anim == 0)
        {
                return;
        }
        
        this.anim.SetTrigger(name:  "show");
    }
    private bool IsAvailable2Show()
    {
        var val_5;
        var val_9;
        if(this.IsEnabled == false)
        {
            goto label_1;
        }
        
        if(this.anim != 0)
        {
            goto label_4;
        }
        
        val_9 = 1;
        return (bool)val_5.IsName(name:  "Idle");
        label_1:
        val_9 = 0;
        return (bool)val_5.IsName(name:  "Idle");
        label_4:
        UnityEngine.AnimatorStateInfo val_2 = this.anim.GetCurrentAnimatorStateInfo(layerIndex:  0);
        return (bool)val_5.IsName(name:  "Idle");
    }
    public WGCompliment()
    {
        int val_3;
        int val_4;
        string[] val_1 = new string[10];
        val_3 = val_1.Length;
        val_1[0] = "amazing_upper_ex";
        val_3 = val_1.Length;
        val_1[1] = "fantastic_upper_ex";
        val_3 = val_1.Length;
        val_1[2] = "sweet_upper_ex";
        val_3 = val_1.Length;
        val_1[3] = "whoa_upper_ex";
        val_3 = val_1.Length;
        val_1[4] = "incredible_upper_ex";
        val_3 = val_1.Length;
        val_1[5] = "spectacular_upper_ex";
        val_3 = val_1.Length;
        val_1[6] = "wow_upper_ex";
        val_3 = val_1.Length;
        val_1[7] = "super_upper_ex";
        val_3 = val_1.Length;
        val_1[8] = "great_upper_ex";
        val_3 = val_1.Length;
        val_1[9] = "awesome_upper_ex";
        this.localizationKeys = val_1;
        string[] val_2 = new string[10];
        val_4 = val_2.Length;
        val_2[0] = "AMAZING!";
        val_4 = val_2.Length;
        val_2[1] = "FANTASTIC!";
        val_4 = val_2.Length;
        val_2[2] = "SWEET!";
        val_4 = val_2.Length;
        val_2[3] = "WHOA!";
        val_4 = val_2.Length;
        val_2[4] = "INCREDIBLE!";
        val_4 = val_2.Length;
        val_2[5] = "SPECTACULAR!";
        val_4 = val_2.Length;
        val_2[6] = "WOW!";
        val_4 = val_2.Length;
        val_2[7] = "SUPER!";
        val_4 = val_2.Length;
        val_2[8] = "GREAT!";
        val_4 = val_2.Length;
        val_2[9] = "AWESOME!";
        this.localizationDefaults = val_2;
    }

}
