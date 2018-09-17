namespace Gu.Inject
{
    public interface IGetter
    {
        /// <summary>
        /// Get the singleton instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The singleton instance of <typeparamref name="T"/>.</returns>
        T Get<T>()
            where T : class;
    }
}