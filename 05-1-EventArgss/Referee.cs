using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventArgs
{
    internal class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void MoveReferee(object sender, PositionChangedEventArgs e)
        {
            Ball b = sender as Ball;
            Console.WriteLine($"Referee({this})::: Ball position changed {b.Position}");
        }
        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
    }
}
