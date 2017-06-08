using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Domain;
using WarChess.Domain.Chess;
using WarChess.Infrastructure;

namespace WarChess.UserInterface
{
    class ListMenu : Control
    {
        private ListBox listBox;
        private int length = 0;
        public event Action<int> IndexSelection;

        public int Length { get { return length; } }

        public ListMenu()
        {
            listBox = new ListBox();
            Controls.Add(listBox);
            listBox.SelectedIndexChanged += 
                (sender, args) => IndexSelection?.Invoke(listBox.SelectedIndex);
        }

        public ListMenu(string[] menu)
        {
            listBox = new ListBox();
            Update(menu);
            Controls.Add(listBox);
        }

        public void Update(string[] menu)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(menu);
            length = menu.Length;
        }

        public void Add(string item)
        {
            listBox.Items.Add(item);
            length++;
        }

        public void Pop()
        {
            if (length == 0)
                throw new Exception("Menu is empty");
            listBox.Items.RemoveAt(length - 1);
            length--;
        }
    }
}
