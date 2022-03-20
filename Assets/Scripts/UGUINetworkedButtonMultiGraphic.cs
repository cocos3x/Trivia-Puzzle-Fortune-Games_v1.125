using UnityEngine;
public class UGUINetworkedButtonMultiGraphic : UGUINetworkedButton
{
    // Methods
    protected override void DoStateTransition(UnityEngine.UI.Selectable.SelectionState state, bool instant)
    {
        float val_6;
        var val_7;
        val_6 = 1f;
        if(state != 4)
        {
            goto label_0;
        }
        
        if(W8 == 0)
        {
            goto label_1;
        }
        
        val_7 = 1;
        goto label_2;
        label_1:
        label_0:
        val_7 = 0;
        label_2:
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(W8 == 0)
        {
            goto label_5;
        }
        
        if((X23 + 24) < 1)
        {
            goto label_11;
        }
        
        var val_6 = 0;
        do
        {
            var val_3 = X23 + 0;
            (X23 + 0) + 32.enabled = false;
            val_6 = val_6 + 1;
        }
        while(val_6 < (X23 + 24));
        
        goto label_11;
        label_5:
        this.SetAlpha(targetAlpha:  val_6, instant:  instant);
        label_11:
        this.DoStateTransition(state:  state, instant:  instant);
    }
    public UGUINetworkedButtonMultiGraphic()
    {
    
    }

}
