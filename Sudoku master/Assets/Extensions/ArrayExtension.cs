namespace Catalyst.Core.Utility
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Create a new array with <paramref name="addItem"/> value at the end of <paramref name="originalArray"/>.
        /// </summary>
        /// <param name="originalArray"></param>
        /// <param name="addItem"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return a new array of size <paramref name="originalArray"/>.Length + 1</returns>
        public static T[] Add<T>(this T[] originalArray, T addItem) where T : class
        {
            T[] result = new T[originalArray.Length + 1];

            originalArray.CopyTo(result, 0);
            result[result.Length - 1] = addItem;

            return result;
        }
    }
}
