using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NewsFood.Core.Common.Extension
{
    public static class ByteArrayEx
    {
        public static byte[] SerializeObjectToByteArray<T>(this T data)
        {
            try
            {
                if (data == null)
                {
                    return null;
                }
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, data);
                    return ms.ToArray();
                }
            }
            catch(Exception ex)
            {

            }
            return null;
            
        }

        public static T DeserializeByteArrayToObject<T>(this byte[] arrays)
        {
            using (MemoryStream ms = new MemoryStream(arrays))
            {
                var br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }
    }
}
