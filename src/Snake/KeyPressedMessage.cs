using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace Snake
{
    internal class KeyPressedMessage : MessageBase
    {
        public KeyEventArgs keyEventArgs { get; set; }
    }
}
