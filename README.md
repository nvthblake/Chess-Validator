# Chess-Validator

## How to run:
1. Open Input.cs file
2. Enter the correct chess configuration that you wish to generate. See the note below to understand the input format
3. Press Start (on Visual Studio) to run the program
4. A Console window will open up with a chessboard and pieces drawn out. Please note that white pieces are all upper case, and black pieces are all lowercase
5. Enter the combination of piece and coordinate to get that piece's valid moves
6. The chessboard on Console will mark each valid positions the piece can move with ".", all valid moves' coordinates will be displayed
7. Press enter to return back to the original configuration of the board, and continue from step 5 to 7 to find all valid moves of each piece.

#### Input Format:
An example of input format:

"p21 p22 p25 r11 k14 n17 q15 b16"

p, r, k, n, q, and b stand for pawn, rook, king, knight, queen, and bishop respectively
While "21" in "p21" is the current position of the pawn: row 2 column 1 (please note that this is not like the normal way to call out a coordinate in chess)
All piece of the same color are separated by a space " "

## Test Case:
The test cases covers basic valid moves in the chess rule for each chess piece, as well as some advanced rules related to King check. For each chess piece, there are from 14 to 32
tests for each piece to ensure basic correct movement rules, and there are 5 tests related to check king rules for each piece to ensure that piece will not leave king in check,
expose king to check, or king will not move to a check position.

All Test Cases were tested and all came out as success.
However, All of the test cases are nowhere near cover all of the possible situations. They only cover some of the basic situation to demonstrate how the program operates.

### How to exercise test cases:
1. Follow the "how to run" instructions above to get the basic flows of the program
2. Open up Test Case excel sheet
3. Follow the test case's action description and the corresponding input:
   - i.e. enter the inputs into the correct piece color in Input.cs file, run the program, input the concerned piece position to see the results
4. Repeat step 3 again for all the test cases if necessary

