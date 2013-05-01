namespace MicroGe.Input
{
    /// <summary>
    /// Provides methods for checking keyboard state.
    /// </summary>
    public interface IKeyboard
    {
        /// <summary>
        /// Determines whether the specified key is pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key is pressed; otherwise, <c>false</c>.
        /// </returns>
        bool IsKeyDown(Keys key);

        /// <summary>
        /// Determines whether the specified key is not pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key is not pressed; otherwise, <c>false</c>.
        /// </returns>
        bool IsKeyUp(Keys key);
    }
}