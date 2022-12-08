# Blackjack
___
### Objective 

The objective of this kata is to build a text-based Blackjack engine that allows a user to play against a dealer who follows conventional house rules.

___
### System Requirements 
A command line interface (CLI), either command prompt for windows or terminal for macOs.
.Net SDK 7.0 - if you have homebrew you can install the latest version of .NET SDK by running the command:
```
brew cask install dotnet-sdk 
```
___
### Clone the repo
You can clone this repo from your CLI by using the following commands:
```
$ gh repo clone myob-fma/charlie-backjack
$ cd <location of chosen folder>
$ dotnet restore
```
___
### Running the game
This game is entirely text-based, and can be displayed using either the built-in IDE terminal, or using the following commands in the CLI:
```
$ cd Blackjack/
$ dotnet run --project Backjack
```

___
### Testing
To navigate to the testing folder, enter dotnet tests into your CLI to run the unit tests (note that you must be in the top layer folder of the directory):
```
$ dotnet test
```

___
### Dependencies

XUnit Testing framework : [xUnit Framework](https://xunit.net/).
