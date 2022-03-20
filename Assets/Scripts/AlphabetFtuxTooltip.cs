using UnityEngine;
public class AlphabetFtuxTooltip : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button;
    private UnityEngine.GameObject toolTipPick;
    
    // Methods
    private void Start()
    {
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void AlphabetFtuxTooltip::<Start>b__2_0()));
    }
    public void Setup(UnityEngine.Transform toolTipBase, UnityEngine.Transform letter)
    {
        this.toolTipPick.transform.SetParent(parent:  letter, worldPositionStays:  false);
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.toolTipPick.transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        this.toolTipPick.transform.SetParent(parent:  toolTipBase, worldPositionStays:  true);
        PluginExtension.SetLocalY(transform:  this.toolTipPick.GetComponent<UnityEngine.RectTransform>(), y:  -10f);
        this.toolTipPick.transform.SetSiblingIndex(index:  1);
        UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.DestroyAfterSeconds());
    }
    private System.Collections.IEnumerator DestroyAfterSeconds()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new AlphabetFtuxTooltip.<DestroyAfterSeconds>d__4();
    }
    public AlphabetFtuxTooltip()
    {
    
    }
    private void <Start>b__2_0()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }

}
