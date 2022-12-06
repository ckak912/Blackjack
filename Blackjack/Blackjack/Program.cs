using Blackjack;
using Blackjack.IO;

var dealer = new Player("Dealer");
var player = new Player("You");
var hand = new Hand();
var consoleOutput = new ConsoleOutput();
var consoleInput = new ConsoleInput();
var playerInput = new PlayerInput(consoleOutput, consoleInput);
var game = new Game(dealer, player, hand, consoleOutput, playerInput);
game.RunGame();

