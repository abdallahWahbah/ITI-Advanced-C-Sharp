namespace _05_EventArgs
{
    internal class Program
    {
        // when SetPosition to the ball, notify the Player and the Referee
        static void Main(string[] args)
        {
            Ball ball = new Ball();
            Player player1 = new Player() { Id = 1, Name = "Salah" };
            Player player2 = new Player() { Id = 2, Name = "Marmoush" };
            Player player3 = new Player() { Id = 3, Name = "Fathy" };
            Player player4 = new Player() { Id = 4, Name = "Messi" };
            Referee referee = new Referee() { Id = 1000, Name = "Referee 11111" };
            ball.SetPosition(0, 0);

            ball.OnPositionChanged += player1.MovePlayer;
            ball.OnPositionChanged += player2.MovePlayer;
            ball.OnPositionChanged += player3.MovePlayer;
            ball.OnPositionChanged += referee.MoveReferee;

            ball.SetPosition(10, 10);
            Console.WriteLine(ball);

            Console.WriteLine("-------------- replacement --------------");
            ball.OnPositionChanged -= player3.MovePlayer;
            ball.OnPositionChanged += player4.MovePlayer;
            ball.SetPosition(20, 20);
            Console.WriteLine(ball);
        }
    }
}
