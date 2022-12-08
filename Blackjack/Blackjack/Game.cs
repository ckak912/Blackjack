using System.Runtime.InteropServices.ComTypes;
using Blackjack.Interfaces;
using Blackjack.GameServices;


namespace Blackjack;

public class Game
{
    private readonly Player _dealer;
    private readonly Player _player;
    private readonly IHand _hand;
    private readonly IOutput _consoleOutput;
    private readonly IUserInput _playerInput;

    public Game(Player dealer, Player player, IHand hand, IOutput consoleOutput, IUserInput playerInput)
    {
        _dealer = dealer;
        _player = player;
        _hand = hand;
        _consoleOutput = consoleOutput;
        _playerInput = playerInput;
    }

    public void RunGame()
    {
        SetUpGame();
        PlayerPlayMove();
        DealerPlayMove();
        WaitTwoSeconds();
        CheckGameOutcome();
    }

    private void SetUpGame()
    {
        _consoleOutput.PrintStartGameMessage();
        _hand.Shuffle();
        _player.Hand = _hand.DealHand();
        _dealer.Hand = _hand.DealHand();
        WaitTwoSeconds();
        GetPointsAndCheckIfBust(_player);
        _consoleOutput.PrintTotalPointsAndHand(_player);
        WaitTwoSeconds();
    }

    private void PlayerPlayMove()
    {
        while (!_player.IsBust && !IsGameOverForDealer())
        {
            var playerMove = _playerInput.GetPlayerMove();
            if (Player.ChooseToStay(playerMove))
                break;
            DrawAndPrintNewCardDrawn(_player);
            _consoleOutput.PrintTotalPointsAndHand(_player);
            GetPointsAndCheckIfBust(_player);
            //WaitTwoSeconds();
        }
    }

    private void DealerPlayMove()
    {
        if (!_player.IsBust && !IsGameOverForDealer())
            do
            {
                DrawAndPrintNewCardDrawn(_dealer);
                _consoleOutput.PrintTotalPointsAndHand(_dealer);
                GetPointsAndCheckIfBust(_dealer);
                WaitTwoSeconds();
                if (_dealer.Points >= Rules.DealerStandOn) continue;
                WaitTwoSeconds();
            } while (!IsGameOverForDealer());
    }

    private void CheckGameOutcome()
    {
        var drawGame = CheckIfWon.CheckIfDraw(_dealer, _player);
        if (drawGame)
            _consoleOutput.PrintDrawGameMessage();
        else
        {
            var winner = CheckIfWon.DecideWinner(_dealer, _player);
            if (winner == _dealer)
                _consoleOutput.PrintDealerWinsMessage();
            else
                _consoleOutput.PrintPlayerWinsMessage();
            
        }
    }

    private static void GetPointsAndCheckIfBust(Player player)
    {
        
    }

    private void DrawAndPrintNewCardDrawn(Player player)
    {
        var newCard = _hand.DealOneCard();
        player.AddCardToHand(newCard);
        _consoleOutput.PrintCardDrawnMessage(player, newCard);
    }

    private static void WaitTwoSeconds()
    {
        //Thread.Sleep(2000);
    }

    private bool IsGameOverForDealer()
    {
        return _dealer.IsBust || _dealer.Points >= Rules.DealerStandOn;
    }
    
}