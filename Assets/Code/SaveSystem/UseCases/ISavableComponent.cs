using System.Collections.Generic;

namespace Code.SaveSystem.UseCases
{
    public interface ISavableComponent
    {
        public Dictionary<string, object> CaptureComponentState();
        public void RestoreState(Dictionary<string, object> state);
    }
    
}
