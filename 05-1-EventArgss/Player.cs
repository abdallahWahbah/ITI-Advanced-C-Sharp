using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventArgs
{
    internal class Player
    {   
        public int Id { get; set; }
        public string Name { get; set; }

        //public void MovePlayer(Ball b, PositionChangedEventArgs e)
        //{
        //    Console.WriteLine($"Player{this}::: Ball position changed {b.Position}");
        //}
        public void MovePlayer(object sender, PositionChangedEventArgs e)
        {
            Ball b = sender as Ball;
            Console.WriteLine($"Player({this})::: Ball position changed {b.Position}");
        }
        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
    }
}
