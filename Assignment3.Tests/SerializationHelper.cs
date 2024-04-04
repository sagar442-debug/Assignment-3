using System.IO;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) a singly linked list of users
        /// </summary>
        /// <param name="list">Singly linked list of users</param>
        /// <param name="fileName">File name to save the serialized data</param>
        public static void SerializeUsers(ILinkedListADT list, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.Create(fileName))
            {
                // Cast the list to SLL before serialization
                SLL sll = (SLL)list;
                serializer.WriteObject(stream, sll);
            }
        }

        /// <summary>
        /// Deserializes (decodes) a singly linked list of users
        /// </summary>
        /// <param name="fileName">File name containing the serialized data</param>
        /// <returns>Singly linked list of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL)serializer.ReadObject(stream);
            }
        }
    }
}
