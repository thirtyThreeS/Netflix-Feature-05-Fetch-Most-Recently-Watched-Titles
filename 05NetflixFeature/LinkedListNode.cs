using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05NetflixFeature
{
    public class LinkedListNode
    {
        public int key;
        public string data;
        public LinkedListNode? next;
        public LinkedListNode? prev;

        public LinkedListNode(string data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }

        public LinkedListNode(int key, string data)
        {
            this.key = key;
            this.data = data;
            this.next = null;
            this.prev = null;
        }

        public LinkedListNode(string data, LinkedListNode next)
        {
            this.data = data;
            this.next = next;
            this.prev = null;
        }

        public LinkedListNode(string data, LinkedListNode next, LinkedListNode prev)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
        }
    }

    public class MyLinkedList
    {
        public LinkedListNode? head;
        public LinkedListNode? tail;
        public int size;

        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void InsertAtHead(int key, string data)
        {
            LinkedListNode newNode = new(key, data);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;
                this.head.prev = newNode;
                this.head = newNode;
            }
            this.size++;
        }

        public void InsertAtTail(int key, string data)
        {
            LinkedListNode newNode = new(key, data);
            if (this.tail == null)
            {
                this.tail = newNode;
                this.head = newNode;
                newNode.next = null;
                newNode.prev = null;
            }
            else
            {
                this.tail.next = newNode;
                newNode.prev = this.tail;
                this.tail = newNode;
                newNode.next = null;
            }
            this.size++;
        }

        public LinkedListNode? GetHead()
        {
            return this.head;
        }

        public LinkedListNode? GetTail()
        {
            return this.tail;
        }

        public LinkedListNode? RemoveNode(LinkedListNode node)
        {
            if (node == null) return null;

            if (node.prev != null) node.prev.next = node.next;

            if (node.next != null) node.next.prev = node.prev;

            if (node == this.head) this.head = this.head.next;

            if (node == this.tail) this.tail = this.tail.prev;

            this.size--;
            return node;
        }

        public void Remove(string data)
        {
            LinkedListNode? i = this.GetHead();
            while (i != null)
            {
                if (i.data == data)
                {
                    this.RemoveNode(i);
                }
                i = i.next;
            }
        }

        public LinkedListNode? RemoveHead()
        {
            return this.RemoveNode(this.head);
        }

        public LinkedListNode? RemoveTail()
        {
            return this.RemoveNode(this.tail);
        }
    }
}
