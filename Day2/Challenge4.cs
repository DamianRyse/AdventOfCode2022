namespace DamianRyse.AdventOfCode2022.Day2;

internal class Challenge4
{
    private readonly Queue<RockPaperScissorMove> _strategyGuide;

    public Challenge4(string strategyGuide)
    {
        _strategyGuide = ParseStrategyGuide(strategyGuide);
        Games = new List<RockPaperScissorGame>();

        PlayGames();
        Console.WriteLine($"Day 2/Challenge 4 => {Games.Sum(x => x.WonPoints)} total points won.");
    }

    public List<RockPaperScissorGame> Games { get; }

    private void PlayGames()
    {
        Games.Clear();
        while (_strategyGuide.Count > 0)
        {
            var gameMove = _strategyGuide.Dequeue();
            Games.Add(new RockPaperScissorGame(gameMove.PlayerShape, gameMove.EnemyShape));
        }
    }

    private Queue<RockPaperScissorMove> ParseStrategyGuide(string guide)
    {
        Queue<RockPaperScissorMove> r = new();
        var lines = guide.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            var move = new RockPaperScissorMove();
            if (line.Length == 3)
            {
                if (line.Substring(0, 1) == "A")
                    move.EnemyShape = new Rock();
                else if (line.Substring(0, 1) == "B")
                    move.EnemyShape = new Paper();
                else if (line.Substring(0, 1) == "C")
                    move.EnemyShape = new Scissor();


                // X = lose
                // Y = draw
                // Z = win

                if (line.Substring(2, 1) == "X" && move.EnemyShape.GetType() == typeof(Rock))
                    move.PlayerShape = new Scissor();
                else if (line.Substring(2, 1) == "X" && move.EnemyShape.GetType() == typeof(Paper))
                    move.PlayerShape = new Rock();
                else if (line.Substring(2, 1) == "X" && move.EnemyShape.GetType() == typeof(Scissor))
                    move.PlayerShape = new Paper();

                else if (line.Substring(2, 1) == "Y" && move.EnemyShape.GetType() == typeof(Rock))
                    move.PlayerShape = new Rock();
                else if (line.Substring(2, 1) == "Y" && move.EnemyShape.GetType() == typeof(Paper))
                    move.PlayerShape = new Paper();
                else if (line.Substring(2, 1) == "Y" && move.EnemyShape.GetType() == typeof(Scissor))
                    move.PlayerShape = new Scissor();

                else if (line.Substring(2, 1) == "Z" && move.EnemyShape.GetType() == typeof(Rock))
                    move.PlayerShape = new Paper();
                else if (line.Substring(2, 1) == "Z" && move.EnemyShape.GetType() == typeof(Paper))
                    move.PlayerShape = new Scissor();
                else if (line.Substring(2, 1) == "Z" && move.EnemyShape.GetType() == typeof(Scissor))
                    move.PlayerShape = new Rock();
            }

            r.Enqueue(move);
        }

        return r;
    }
}