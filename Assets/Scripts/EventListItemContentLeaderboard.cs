using UnityEngine;
public class EventListItemContentLeaderboard : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text rank_text;
    private UnityEngine.UI.Text rank_suffix_text;
    private UnityEngine.GameObject rank_suffix_plus_text;
    private UnityEngine.UI.Text apples_text;
    
    // Methods
    private void Awake()
    {
        this.rank_suffix_plus_text.SetActive(value:  false);
        this.rank_suffix_text.gameObject.SetActive(value:  false);
    }
    public void SetupLeaderboardPlayerInfo(string rank, string suffix, string apples)
    {
        this.rank_suffix_text.gameObject.SetActive(value:  (~(System.String.IsNullOrEmpty(value:  suffix))) & 1);
        this.rank_suffix_plus_text.SetActive(value:  System.String.IsNullOrEmpty(value:  suffix));
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public EventListItemContentLeaderboard()
    {
    
    }

}
