namespace MicroGe.Bootstrapper
{
    /// <summary>
    /// Provides methods to initialize the bootstrapper and
    /// retrieve the main game object.
    /// </summary>
    public interface IBootstrapper
    {
        IGame GetGame();

        void Initialize();
    }
}