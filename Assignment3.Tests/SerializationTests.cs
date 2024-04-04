using Assignment3;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            this.users = new SLL();

            users.AddLast(new User(1, "Eddie James", "eddie@gmail.com", "jamie@233"));
            users.AddLast(new User(2, "Chloe Kelly", "kchloe@gmail.com", "kelly2000"));
            users.AddLast(new User(3, "Lucy Smith", "smithlucy4@gmail.com", "Lu#402"));
            users.AddLast(new User(4, "Victor Peng", "pengismyname@gmail.com", "45Jpeng"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

      
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

      
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            
            Assert.IsTrue(users.Count() == deserializedUsers.Count());
            
            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
    }
}