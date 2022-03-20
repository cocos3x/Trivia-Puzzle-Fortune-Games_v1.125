using UnityEngine;
public class LocalNotificationsComponent : AppComponent
{
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public LocalNotificationsComponent(string gameName, string gameObjectName)
    {
        mem[1152921515589485184] = "LocalNotificationsComponent";
    }
    public override void initializeOnMainThread()
    {
        AppConfigs val_1 = App.Configuration;
        twelvegigs.plugins.LocalNotificationsPlugin.Initialize(gameName:  val_1.appConfig.gameName, available:  true);
        twelvegigs.plugins.LocalNotificationsPlugin.Clear();
        MonoSingletonSelfGenerating<AsyncExecution>.Instance.Async(callback:  new System.Action(object:  this, method:  System.Void LocalNotificationsComponent::ScheduleNotifications()), when:  2f);
    }
    private void ScheduleNotifications()
    {
    
    }
    public override void onInitialServerUpdate()
    {
    
    }
    public override void onServerUpdate()
    {
    
    }

}
