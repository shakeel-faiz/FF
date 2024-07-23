## What is a PGN file?

A PGN (Portable Game Notation) file is a plain text file format used for recording chess games. It includes detailed information about the game, such as the moves played, the players' names, the event, the date, and other relevant metadata. Created in 1993 by Steven J. Edwards, PGN files are widely recognized and supported by most chess programs.

PGN files are used by chess players and analysts to share and review game recordings. They allow users to visually replay the game and analyze the moves using various chess programs.

## Key Features of a PGN File:

-   **Human-Readable Format**: The file is in plain text, making it easy to read and edit.
-   **Game Metadata**: The beginning of a PGN file contains tag pairs specifying game details:
    -   **Event**: The name of the tournament or match.
    -   **Site**: The location or platform where the game was played.
    -   **Date**: The date of the game.
    -   **Round**: The specific round of the event.
    -   **Players**: The names of the players, their colors, and Elo ratings.
    -   **Result**: The outcome of the game.

## Example of Metadata in PGN:

```
[Event "FIDE World Championship"]
[Site "Dubai UAE"]
[Date "2021.12.10"]
[Round "6"]
[White "Magnus Carlsen"]
[Black "Ian Nepomniachtchi"]
[Result "1-0"]
```

## Recording Moves:

Moves are recorded using Standard Algebraic Notation (SAN), which is a turn-based list of moves. For example, `2.Nf3 Nc6` indicates that on the second turn, White moved a knight to f3, and Black moved a knight to c6.
