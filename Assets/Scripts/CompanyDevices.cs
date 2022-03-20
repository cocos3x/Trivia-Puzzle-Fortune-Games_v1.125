using UnityEngine;
public class CompanyDevices : ScriptableObject
{
    // Fields
    public static bool TrackingAllowed;
    public System.Collections.Generic.List<AllowedDevice> allowedAddresses;
    public System.Collections.Generic.List<AllowedDevice> allowedIDFAs;
    public System.Collections.Generic.List<AllowedDevice> allowedDeviceId;
    public System.Collections.Generic.List<AllowedDevice> deviceIds;
    public System.Collections.Generic.List<string> lowEndDevices;
    private static CompanyDevices _instance;
    
    // Properties
    public static string AllowedId { get; }
    public static CompanyDevices Instance { get; }
    
    // Methods
    public static void SwitchDevice()
    {
        null = null;
        bool val_1 = CompanyDevices.TrackingAllowed;
        val_1 = val_1 ^ 1;
        CompanyDevices.TrackingAllowed = val_1;
    }
    public bool CompanyDevice()
    {
        System.Collections.Generic.List<AllowedDevice> val_9;
        var val_10;
        System.Collections.Generic.List<AllowedDevice> val_12;
        val_9 = this;
        CompanyDevices.<>c__DisplayClass7_0 val_1 = new CompanyDevices.<>c__DisplayClass7_0();
        val_10 = null;
        val_10 = null;
        if(CompanyDevicesHelper.cached != false)
        {
                return (bool)CompanyDevicesHelper.cachedValue;
        }
        
        .id = DeviceIdPlugin.GetDeviceId();
        val_12 = this.deviceIds;
        if((System.Linq.Enumerable.FirstOrDefault<AllowedDevice>(source:  val_12, predicate:  new System.Func<AllowedDevice, System.Boolean>(object:  val_1, method:  System.Boolean CompanyDevices.<>c__DisplayClass7_0::<CompanyDevice>b__0(AllowedDevice device)))) == null)
        {
                .id = DeviceIdPlugin.GetMacAddress().ToUpper();
            val_9 = this.allowedAddresses;
            System.Func<AllowedDevice, System.Boolean> val_7 = null;
            val_12 = val_7;
            val_7 = new System.Func<AllowedDevice, System.Boolean>(object:  val_1, method:  System.Boolean CompanyDevices.<>c__DisplayClass7_0::<CompanyDevice>b__1(AllowedDevice device));
            AllowedDevice val_8 = System.Linq.Enumerable.FirstOrDefault<AllowedDevice>(source:  val_9, predicate:  val_7);
            if(val_8 == null)
        {
                return val_8.ReturnType(value:  true);
        }
        
        }
        
        return val_8.ReturnType(value:  true);
    }
    public bool isLowEndDevice()
    {
        CompanyDevices val_1 = CompanyDevices.Instance;
        return val_1.lowEndDevices.Contains(item:  DeviceProperties.DeviceModel);
    }
    public bool isRunningOutOfMemory()
    {
        return false;
    }
    private bool ReturnType(bool value)
    {
        null = null;
        CompanyDevicesHelper.cachedValue = value;
        CompanyDevicesHelper.cached = true;
        return (bool)CompanyDevicesHelper.cachedValue;
    }
    public static string get_AllowedId()
    {
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return "AllowedId: None";
        }
        
        return System.String.Format(format:  "AllowedId: mac {0}", arg0:  DeviceIdPlugin.GetMacAddress().ToUpper());
    }
    private static void LoadInstance()
    {
        var val_2 = null;
        CompanyDevices._instance = UnityEngine.Resources.Load(path:  "data/Company_Devices");
    }
    public static CompanyDevices get_Instance()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(CompanyDevices._instance == 0)
        {
                CompanyDevices.LoadInstance();
        }
        
        val_3 = null;
        val_3 = null;
        return (CompanyDevices)CompanyDevices._instance;
    }
    public CompanyDevices()
    {
    
    }
    private static CompanyDevices()
    {
    
    }

}
