
namespace SaveSystem
{
    public interface ISavableComponent {

        object CaptureState();

        void RestoreState(object state);

    }
}