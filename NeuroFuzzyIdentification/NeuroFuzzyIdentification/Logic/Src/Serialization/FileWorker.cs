using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using JustCalculateIt.Logic;

namespace JustCalculateIt.Logic.Src.Serialization
{
    class FileWorker
    {
        public static MainFunction Deserialize(string fileName)
        {
            Stream deserializationStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter deserializer = new BinaryFormatter();

            if (deserializationStream.Length != 0)
            {
                MainFunction function = (MainFunction)deserializer.Deserialize(deserializationStream);

                deserializationStream.Close();
                return function;
            }
            else
            {
                deserializationStream.Close();
                throw new System.ArgumentException("File is empty", "Filename");
            }
        }

        public static void Serialize(string fileName, MainFunction function)
        {
            Stream serializationStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter serializer = new BinaryFormatter();

            serializer.Serialize(serializationStream, function);

            serializationStream.Close();
        }
    }
}
