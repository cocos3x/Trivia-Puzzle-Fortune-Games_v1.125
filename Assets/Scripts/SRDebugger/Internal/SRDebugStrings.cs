using UnityEngine;

namespace SRDebugger.Internal
{
    public class SRDebugStrings
    {
        // Fields
        public static readonly SRDebugger.Internal.SRDebugStrings Current;
        public readonly string Console_MessageTruncated;
        public readonly string Console_NoStackTrace;
        public readonly string PinEntryPrompt;
        public readonly string Profiler_DisableProfilerInfo;
        public readonly string Profiler_EnableProfilerInfo;
        public readonly string Profiler_NoProInfo;
        public readonly string Profiler_NotSupported;
        public readonly string ProfilerCameraListenerHelp;
        
        // Methods
        public SRDebugStrings()
        {
            this.Console_MessageTruncated = "-- Message Truncated --";
            this.Console_NoStackTrace = "-- No Stack Trace Available --";
            this.PinEntryPrompt = "Enter code to open debug panel";
            this.Profiler_DisableProfilerInfo = "Unity profiler is currently <b>enabled</b>. Disable to improve performance.";
            this.Profiler_EnableProfilerInfo = "Unity profiler is currently <b>disabled</b>. Enable to show more information.";
            this.Profiler_NoProInfo = "Unity profiler is currently <b>disabled</b>. Unity Pro is required to enable it.";
            this.Profiler_NotSupported = "Unity profiler is <b>not supported</b> in this build.";
            this.ProfilerCameraListenerHelp = "This behaviour is attached by the SRDebugger profiler to calculate render times.";
        }
        private static SRDebugStrings()
        {
            SRDebugger.Internal.SRDebugStrings.Current = new SRDebugger.Internal.SRDebugStrings();
        }
    
    }

}
