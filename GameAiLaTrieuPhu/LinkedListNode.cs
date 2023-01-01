using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAiLaTrieuPhu
{
    public class LinkedListNode
    {
        private Button prize;
        private Boolean checkpoint;
        private LinkedListNode next = null;

        // Khong co node tiep theo 

        public LinkedListNode(Button prize, Boolean checkpoint)
        {
            this.prize = prize;
            this.checkpoint = checkpoint;

        }

        // get  
        public Button getPrize()
        {
            return this.prize;
        }
        public Boolean getCheckpoint()
        {
            return this.checkpoint;
        }
        public LinkedListNode getNext()
        {
            return this.next;
        }
        // set 
        public void resetBackground()
        {
            if (this.checkpoint)
            {
                this.prize.BackgroundImage = Properties.Resources.wrong;
            }
            else
            {
                this.prize.BackgroundImage = Properties.Resources.mocCauHoi;
            }

        }
        // Thay doi next 
        public void setNext(LinkedListNode next)
        {
            this.next = next;
        }
        public void setPrizeBackground()
        {
            this.prize.BackgroundImage = Properties.Resources.prize;

        }

        public void setWrongBackground()
        {
            this.prize.BackgroundImage = Properties.Resources.wrong;

        }

    }
}
 