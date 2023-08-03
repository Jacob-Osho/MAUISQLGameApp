using MAUISQLGameApp.Models;
using System;

namespace MAUISQLGameApp;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }
    int FirstNumber = 0;
    int SecondNumber = 0;
    int Score = 0;
    const int TotalQuestions = 2;
    int GamesLeft = TotalQuestions;
    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;

        //QuestionLabel Answer SubmitAnswer AnswerLabel GameOverLabel
        CreateNewQuestion(gameType);
        BindingContext = this;
    }

    private void CreateNewQuestion(string gameType)
    {
        var gameOperand = GameType switch
        {
            "Addition" => "+",
            "Substraction" => "-",
            "Multyplication" => "*",
            "Division" => "/",
            _ => ""
        };
        SetUpNumbers();
        AsigningText(gameOperand);


    }
    void AsigningText(string gameOperand)
    {
        QuestionLabel.Text = $"{FirstNumber} {gameOperand} {SecondNumber}";
    }
    void IfDevisionAction(Random random)
    {
        if (GameType == "Division")
            while (FirstNumber < SecondNumber || FirstNumber % SecondNumber != 0)
            {
                FirstNumber = random.Next(1, 99);
                SecondNumber = random.Next(1, 99);
            }
    }
    void AdjustNumbers(Random random)
    {
        if (GameType != "Division")
            FirstNumber = random.Next(1, 9);
        else FirstNumber = random.Next(1, 99);
    }
    void SetUpNumbers()
    {
        var random = new Random((int)(DateTime.Now.Ticks / TimeSpan.TicksPerSecond));
        AdjustNumbers(random);
        FirstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        SecondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        IfDevisionAction(random);


    }
    private void BackToMenue_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    private void SubmitAnswer_Clicked(object sender, EventArgs e)
    {
        if (Answer.Text == "")
            return;
        var answer = Int32.Parse(Answer.Text);
        bool isCorrect = false;
        switch (GameType)
        {
            case "Addition":
                isCorrect = answer == FirstNumber + SecondNumber; break;
            case "Substraction":
                isCorrect = answer == FirstNumber - SecondNumber; break;
            case "Multyplication":
                isCorrect = answer == FirstNumber * SecondNumber; break;
            case "Division":
                isCorrect = answer == FirstNumber / SecondNumber; break;
            default:
                break;
        }
        ProcessAnswer(isCorrect);
        GamesLeft--;
        Answer.Text = "";
        if (GamesLeft > 0)
            CreateNewQuestion(GameType);
        else
            GameOver();
    }

    private void GameOver()
    {
        GameOperation operation = GameType switch
        {
            "Addition" => GameOperation.Addition,
            "Substraction" => GameOperation.Substraction,
            "Multyplication" => GameOperation.Multyplication,
            "Division" => GameOperation.Division
        };

        GameOverLabel.Text = $"Game over ! Your score  {Score} out of {TotalQuestions}";
        BackToMenue.IsVisible = false;
        App.GameRepository.AddGame(new GameModel { DatePlayed = DateTime.Now, Type = operation, Score = Score });
    }

    private void ProcessAnswer(bool isCorrect)
    {
        _ = isCorrect == true ? Score += 1 : Score -= 1;
        AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
    }
}