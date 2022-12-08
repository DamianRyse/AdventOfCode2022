namespace DamianRyse.AdventOfCode2022.Day2;

internal class Challenge3
{
    private readonly Queue<RockPaperScissorMove> _strategyGuide;

    public Challenge3(string strategyGuide)
    {
        _strategyGuide = ParseStrategyGuide(strategyGuide);
        Games = new List<RockPaperScissorGame>();

        PlayGames();
        Console.WriteLine($"Day 2/Challenge 3 => {Games.Sum(x => x.WonPoints)} total points won.");
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

                if (line.Substring(2, 1) == "X")
                    move.PlayerShape = new Rock();
                else if (line.Substring(2, 1) == "Y")
                    move.PlayerShape = new Paper();
                else if (line.Substring(2, 1) == "Z")
                    move.PlayerShape = new Scissor();
            }

            r.Enqueue(move);
        }

        return r;
    }
}

internal interface IWeapon
{
    string Name { get; }
    int Points { get; }
}

internal class Rock : IWeapon
{
    public int Points { get; } = 1;
    public string Name { get; } = "Rock";
}

internal class Paper : IWeapon
{
    public int Points { get; } = 2;
    public string Name { get; } = "Paper";
}

internal class Scissor : IWeapon
{
    public int Points { get; } = 3;
    public string Name { get; } = "Scissor";
}

internal class RockPaperScissorGame
{
    public RockPaperScissorGame(IWeapon playerChoice, IWeapon enemyChoice)
    {
        PlayerChoice = playerChoice;
        EnemyChoice = enemyChoice;
        if (playerChoice.GetType() == typeof(Rock))
        {
            if (enemyChoice.GetType() == typeof(Rock))
            {
                GameResult = RockPaperScissorGameResults.Draw;
                WonPoints = playerChoice.Points + 3;
            }
            else if (enemyChoice.GetType() == typeof(Paper))
            {
                GameResult = RockPaperScissorGameResults.Lost;
                WonPoints = playerChoice.Points;
            }
            else if (enemyChoice.GetType() == typeof(Scissor))
            {
                GameResult = RockPaperScissorGameResults.Won;
                WonPoints = playerChoice.Points + 6;
            }
        }
        else if (playerChoice.GetType() == typeof(Paper))
        {
            if (enemyChoice.GetType() == typeof(Rock))
            {
                GameResult = RockPaperScissorGameResults.Won;
                WonPoints = playerChoice.Points + 6;
            }
            else if (enemyChoice.GetType() == typeof(Paper))
            {
                GameResult = RockPaperScissorGameResults.Draw;
                WonPoints = playerChoice.Points + 3;
            }
            else if (enemyChoice.GetType() == typeof(Scissor))
            {
                GameResult = RockPaperScissorGameResults.Lost;
                WonPoints = playerChoice.Points;
            }
        }
        else if (playerChoice.GetType() == typeof(Scissor))
        {
            if (enemyChoice.GetType() == typeof(Rock))
            {
                GameResult = RockPaperScissorGameResults.Lost;
                WonPoints = playerChoice.Points;
            }
            else if (enemyChoice.GetType() == typeof(Paper))
            {
                GameResult = RockPaperScissorGameResults.Won;
                WonPoints = playerChoice.Points + 6;
            }
            else if (enemyChoice.GetType() == typeof(Scissor))
            {
                GameResult = RockPaperScissorGameResults.Draw;
                WonPoints = playerChoice.Points + 3;
            }
        }
    }

    public IWeapon PlayerChoice { get; }
    public IWeapon EnemyChoice { get; }
    public RockPaperScissorGameResults GameResult { get; }
    public int WonPoints { get; }
}

internal enum RockPaperScissorGameResults
{
    Won = 0,
    Lost = 1,
    Draw = 2
}

internal struct RockPaperScissorMove
{
    public IWeapon EnemyShape;
    public IWeapon PlayerShape;
}