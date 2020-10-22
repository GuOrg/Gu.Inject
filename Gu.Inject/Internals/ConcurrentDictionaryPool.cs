namespace Gu.Inject
{
    using System.Collections.Concurrent;

    internal static class ConcurrentDictionaryPool<TKey, TValue>
        where TKey : notnull
    {
        private static readonly ConcurrentQueue<ConcurrentDictionary<TKey, TValue>> Cache = new ConcurrentQueue<ConcurrentDictionary<TKey, TValue>>();

        internal static ConcurrentDictionary<TKey, TValue> Borrow()
        {
            return Cache.TryDequeue(out var result)
                ? result
                : new ConcurrentDictionary<TKey, TValue>();
        }

        internal static void Return(ConcurrentDictionary<TKey, TValue>? dictionary)
        {
            if (dictionary is null)
            {
                return;
            }

            dictionary.Clear();
            Cache.Enqueue(dictionary);
        }
    }
}
