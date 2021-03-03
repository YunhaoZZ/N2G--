# 14LL-PuzzelGame(N2G--)
 Go to the link for downloading the game. This is a just the assets of a 3d game project -- a math puzzle game combined with feature of pushing box.  p13-l0v3r.itch.io/14ll

14LL by N2G

Instruction:

************************************************************************************************************************
- Moving the Character to push tiles:
	- Use WASD or arrows to move the chess and push tiles.
	- The chess board is at 45 degree, we apologize if it is a little confusing when moving pushing the tiles.
		- We hope we can soon improve this feature.


************************************************************************************************************************
- The goal of this game:
	- There will be riddles to solve excluding the first level, which is the instruction level.
	- Riddle answer will be a English word that can be spelled with 26 letters.
	- To solve the riddle, push the tiles that have already converted to letters and connect them together, no matter the direction.

************************************************************************************************************************
- How to reach the goal?
- The usage of the three gates:
A. Adding gates:
1. The rectangular port will be the port to connect with the number added to the target tile.
2. The half-ellipse gate will be a passble gate where the number being pushed through is added with the amount of rectangular portal number.
3. For example, we have 2 at rectangular port and push 1 through half-ellipse gate. Tile with 2 will remain unchanged, and tile with 1 will be added with 2 which becomes 3.
B. Multiply gates:
1. The rectangular port will be the port to connect with the multiplier.
2. The half-ellipse gate will be a passble gate where the number being pushed through is the factor.
3. For example, we have 3 at rectangular port and push 2 through half-ellipse gate. Tile with 3 will remain unchanged, and tile with 2 will be multiplied by 3 which becomes 6.
C. Letter gates(ASCII gates):
1. There is no rectangular port for this kind of gate.
2. The half-ellipse gate will be a passble gate where the number being pushed through is converted to a letter based on a rule similar as ASCII value (A-Z as 1-26).
3. For example, number 6 being pushed through letter gate will be converted to letter F.

After calculating using the tiles and convert into letter, riddle can be answered by pushing the letter tiles together, either vertical or horizontal on the chess board.

************************************************************************************************************************
Good Luck, player!
************************************************************************************************************************
