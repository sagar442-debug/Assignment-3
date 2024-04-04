using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Assignment3
{
    public class CannotRemoveException : Exception
    {
        public CannotRemoveException(string message) : base(message)
        {
        }
    }

    public interface ILinkedListADT
    {
        bool IsEmpty();
        void Clear();
        void AddLast(User value);
        void AddFirst(User value);
        void Add(User value, int index);
        void Replace(User value, int index);
        int Count();
        void RemoveFirst();
        void RemoveLast();
        void Remove(int index);
        User GetValue(int index);
        int IndexOf(User value);
        bool Contains(User value);
    }
    [Serializable]
    public class Node
    {
        public User Value { get; set; }
        public Node Next { get; set; }
        public User Data { get; internal set; }

        public Node(User value)
        {
            Value = value;
            Next = null;
        }
    }
    [Serializable]
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list.");
            }

            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list.");
            }

            if (count == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                count--;
            }
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }
        public List<User> ToList()
        {
            List<User> userList = new List<User>();
            Node current = head;
            while (current != null)
            {
                userList.Add(current.Data);
                current = current.Next;
            }
            return userList;
        }
        public void Serialize(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, this);
            }
        }

        public static SLL Deserialize(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL)serializer.ReadObject(stream);
            }
        }
    }
}
