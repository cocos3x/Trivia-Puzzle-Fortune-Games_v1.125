using UnityEngine;
public class DisableOnNonCompanyDevice : MonoBehaviour
{
    // Methods
    private void Awake()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public DisableOnNonCompanyDevice()
    {
    
    }

}
