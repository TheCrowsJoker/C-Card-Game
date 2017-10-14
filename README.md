# C-Card-Game

A card game written for an assignment IT6253 Assignment 2

The Aim of this game is to last longer than your opponent

The Program builds a deck of cards (default size of 52)
Each card Has the following attributes:
* Id
* Value
* Suit
* Status

When the program is launched, a simple GUI is loaded and a deck is build as an array of cards

When the 'Deal' button is pressed, the array of cards is shuffled and dealed to 2 players (half the deck each)

Player one starts - On the first round, after clicking the 'Player 1 turn' button, the card at the top of their pile is selected.

Player 2 then clicks their button. The program will then select the top most card that is either 1 number higher, or one number lower than the value of the last played card. The suit does not matter. 11, 12, and 13, represent the Jack, Queen, and King respectively. A card higher than 13, loops round to a 1, and vice-versa.

The two players then take turns clicking their buttons until one player no longer has a card to play. The last person who plays a card is the winner.
