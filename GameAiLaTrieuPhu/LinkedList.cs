﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAiLaTrieuPhu
{
    public class LinkedList
    {
        private LinkedListNode head;
        public LinkedList()
        {
            this.head = head;
        }
        // them node vao cuoi danh sach 
        public void addToList(LinkedListNode next)
        {
            if (head == null)
            {
                head = next;
            }
            else
            {

                LinkedListNode node = head;
                while (node.getNext() != null)
                {
                    node = node.getNext();
                }

                node.setNext(next);
            }
        }
      
        // get head 
        public LinkedListNode getHead()
        {
            return head;
        }
    }
}