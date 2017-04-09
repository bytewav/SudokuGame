
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Catalyst.Core.Utility
{
    public static class ObjectExtention
    {
        public static byte[] ToByteArray(this object @this)
        {
            if (@this == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, @this);

            return ms.ToArray();
        }

        public static T FromByteArray<T>(this T @this, byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj = (T)binForm.Deserialize(memStream);

            return obj;
        }

        public static T Clone<T>(this object @this) where T : class
        {
            T clone = null;
            return clone.FromByteArray(@this.ToByteArray());
        }
    }

    public static class ByteArrayExtention
    {
        public static void ByteArrayToFile(this byte[] @this, string _FileName)
        {
            System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(@this, 0, @this.Length);
            _FileStream.Close();
        }

        public static byte[] FromFile(string _FileName)
        {
            return System.IO.File.ReadAllBytes(_FileName);
        }
    }
}