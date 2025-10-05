using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventArgs
{
    public class PositionChangedEventArgs
    {
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
    }
    internal class Ball
    {
        Point position = new Point();
        //public event Action<Ball, PositionChangedEventArgs> OnPositionChanged;
        public event EventHandler<PositionChangedEventArgs> OnPositionChanged; // the same ::: we don't pass the current object class
        internal Point Position
        {
            get => position;
        }
        public void SetPosition(int _x, int _y)
        {
            PositionChangedEventArgs e = new PositionChangedEventArgs() { DeltaX = position.X - _x, DeltaY = position.Y - _y};
            position.X = _x;
            position.Y = _y;
            OnPositionChanged?.Invoke(this, e);
        }
        public override string ToString()
        {
            return $"Ball position: {position}";
        }
    }
}
