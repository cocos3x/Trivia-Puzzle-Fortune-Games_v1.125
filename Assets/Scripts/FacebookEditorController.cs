using UnityEngine;
public class FacebookEditorController : MonoBehaviour
{
    // Fields
    public static System.Action doFBEditorLogin;
    public static System.Action loginPressed;
    public static System.Action cancelPressed;
    public static System.Action<string, string> loginComplete;
    public UnityEngine.GameObject wholeScreenBlocker;
    public static string userId;
    public static string token;
    
    // Methods
    public FacebookEditorController()
    {
    
    }
    private static FacebookEditorController()
    {
        null = null;
        FacebookEditorController.doFBEditorLogin = new System.Action(object:  FacebookEditorController.<>c.<>9, method:  System.Void FacebookEditorController.<>c::<.cctor>b__8_0());
        FacebookEditorController.loginPressed = new System.Action(object:  FacebookEditorController.<>c.<>9, method:  System.Void FacebookEditorController.<>c::<.cctor>b__8_1());
        FacebookEditorController.cancelPressed = new System.Action(object:  FacebookEditorController.<>c.<>9, method:  System.Void FacebookEditorController.<>c::<.cctor>b__8_2());
        FacebookEditorController.loginComplete = new System.Action<System.String, System.String>(object:  FacebookEditorController.<>c.<>9, method:  System.Void FacebookEditorController.<>c::<.cctor>b__8_3(string <p0>, string <p1>));
        FacebookEditorController.userId = "";
        FacebookEditorController.token = "";
    }

}
