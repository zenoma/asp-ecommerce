
namespace Es.Udc.DotNet.ModelUtil.IoC
{
    /// <summary>
    /// Manages the Inversion of Control
    /// </summary>
    public interface IIoCManager
    {
        /// <summary>
        /// Configures this instance. It sets the bindings
        /// </summary>
        void Configure();

        /// <summary>
        /// Resolves this instance and returns the specific binding.
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>The instance binding to TConfigures this instance. It stablishes the bindings</returns>
        T Resolve<T>();

    }
}
