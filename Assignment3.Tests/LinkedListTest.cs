using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private SLL list;

        [SetUp]
        public void Setup()
        {
            list = new SLL();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestPrepend()
        {
            User user = new User(1, "Admin", "Admin@junior.com", "password");
            list.AddFirst(user);
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAppend()
        {
            User user = new User(1, "Jake", "jake@example.com", "refgtg");
            list.AddLast(user);
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            list.AddLast(new User(1, "Admin", "Admin@junior.com", "password"));
            list.AddLast(new User(2, "Jake", "jake@example.com", "refgtg"));
            list.Add(new User(3, "Ruth", "ruth@bright.com", "pass"), 1);
            Assert.AreEqual("Ruth", list.GetValue(1).Name);
        }

        [Test]
        public void TestReplace()
        {
            list.AddLast(new User(1, "Admin", "Admin@junior.com", "password"));
            list.Replace(new User(1, "Jake", "jake@example.com", "refgtg"), 0);
            Assert.AreEqual("Jake", list.GetValue(0).Name);
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            list.AddLast(new User(1, "Admin", "Admin@junior.com", "password"));
            list.AddLast(new User(2, "Jake", "jake@example.com", "refgtg"));
            list.RemoveFirst();
            Assert.AreEqual("Jake", list.GetValue(0).Name);
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            list.AddLast(new User(1, "Admin", "Admin@junior.com", "password"));
            list.AddLast(new User(2, "Jake", "jake@example.com", "refgtg"));
            list.RemoveLast();
            Assert.AreEqual("Admin", list.GetValue(0).Name);
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            list.AddLast(new User(1, "Admin", "Admin@junior.com", "password"));
            list.AddLast(new User(2, "Jake", "jake@example.com", "refgtg"));
            list.AddLast(new User(3, "Ruth", "ruth@bright.com", "pass"));
            list.Remove(1);
            Assert.AreEqual("Ruth", list.GetValue(1).Name);
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            User user1 = new User(1, "Admin", "Admin@junior.com", "password");
            User user2 = new User(2, "Jake", "jake@example.com", "refgtg");
            list.AddLast(user1);
            list.AddLast(user2);
            Assert.AreEqual(1, list.IndexOf(user2));
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void TestSerialization()
        {
            list.AddLast(new User(1, "John", "Admin@junior.com", "password"));
            list.AddLast(new User(2, "Jake", "jake@example.com", "refgtg"));

            
            list.Serialize("users.xml");

           
            var deserializedList = SLL.Deserialize("users.xml");

          
            Assert.AreEqual(list.Count(), deserializedList.Count());
            Assert.AreEqual(list.GetValue(0).Name, deserializedList.GetValue(0).Name);
            Assert.AreEqual(list.GetValue(1).Name, deserializedList.GetValue(1).Name);
        }
    }
}
