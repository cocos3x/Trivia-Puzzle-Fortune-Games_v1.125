using UnityEngine;
public class UICanvasManager : MonoBehaviour
{
    // Fields
    public static UICanvasManager GlobalAccess;
    public bool MouseOverButton;
    public UnityEngine.UI.Text PENameText;
    public UnityEngine.UI.Text ToolTipText;
    private UnityEngine.RaycastHit rayHit;
    
    // Methods
    private void Awake()
    {
        UICanvasManager.GlobalAccess = this;
    }
    private void Start()
    {
        if(this.PENameText == 0)
        {
                return;
        }
        
        string val_2 = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Update()
    {
        if(this.MouseOverButton != true)
        {
                if((UnityEngine.Input.GetMouseButtonUp(button:  0)) != false)
        {
                this.SpawnCurrentParticleEffect();
        }
        
        }
        
        if((UnityEngine.Input.GetKeyUp(key:  97)) != false)
        {
                this.SelectPreviousPE();
        }
        
        if((UnityEngine.Input.GetKeyUp(key:  100)) == false)
        {
                return;
        }
        
        this.SelectNextPE();
    }
    public void UpdateToolTip(ButtonTypes toolTipType)
    {
        var val_3;
        if(this.ToolTipText == 0)
        {
                return;
        }
        
        if(toolTipType != 2)
        {
                if(toolTipType != 1)
        {
                return;
        }
        
            val_3 = "Select Previous Particle Effect";
        }
        else
        {
                val_3 = "Select Next Particle Effect";
        }
    
    }
    public void ClearToolTip()
    {
        if(this.ToolTipText == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SelectPreviousPE()
    {
        ParticleEffectsLibrary.GlobalAccess.PreviousParticleEffect();
        if(this.PENameText == 0)
        {
                return;
        }
        
        string val_2 = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SelectNextPE()
    {
        ParticleEffectsLibrary.GlobalAccess.NextParticleEffect();
        if(this.PENameText == 0)
        {
                return;
        }
        
        string val_2 = ParticleEffectsLibrary.GlobalAccess.GetCurrentPENameString();
        this = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SpawnCurrentParticleEffect()
    {
        float val_4;
        float val_5;
        UnityEngine.Vector3 val_2 = UnityEngine.Input.mousePosition;
        UnityEngine.Ray val_3 = UnityEngine.Camera.main.ScreenPointToRay(pos:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        if((UnityEngine.Physics.Raycast(ray:  new UnityEngine.Ray() {m_Origin = new UnityEngine.Vector3() {x = val_5, y = val_5, z = val_5}, m_Direction = new UnityEngine.Vector3() {x = val_5, y = val_4, z = val_4}}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = this.rayHit, y = this.rayHit, z = this.rayHit}, m_Normal = new UnityEngine.Vector3() {x = this.rayHit, y = this.rayHit, z = this.rayHit}, m_FaceID = this.rayHit, m_Distance = this.rayHit, m_UV = new UnityEngine.Vector2() {x = this.rayHit, y = this.rayHit}, m_Collider = this.rayHit})) == false)
        {
                return;
        }
        
        UnityEngine.Vector3 val_7 = this.rayHit.point;
        ParticleEffectsLibrary.GlobalAccess.SpawnParticleEffect(positionInWorldToSpawn:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
    }
    public void UIButtonClick(ButtonTypes buttonTypeClicked)
    {
        if(buttonTypeClicked != 2)
        {
                if(buttonTypeClicked != 1)
        {
                return;
        }
        
            this.SelectPreviousPE();
            return;
        }
        
        this.SelectNextPE();
    }
    public UICanvasManager()
    {
    
    }

}
