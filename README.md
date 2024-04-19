# 3-Tac-Toe

**[Play the game here](https://vmrfreitas.itch.io/3-tac-toe)**
Welcome to the source-code of my first game-dev learning project. I wanted to start my learning journey by making a very simple first game that would also help me learn a bit of AI (the classic AI, not gen-AI lol), that is why I chose tic-tac-toe. But I want to add a twist to every project, that is why I developed 3 versions of tic-tac-toe.\
As life went on I eventually became a trainer for the SOLID design principles on my job as Software Engineer, that's when I decided to re-design and later re-factor my 3-tac-toe code.\
In this readme I'll explain [how to play](#how-to-play) each version and later show you the initial [class diagram](#class-diagram) I made and explain it in more detail.


## How to play

On the game menu you can choose which tic-tac-toe variation you'd like to play. And by clicking the **?** button you can see an explanation text for the game.\
After you select the variation you can choose to play alone (against the computer) or take turns playing with a friend.

### Tic-tac-toe
This is classic [tic-tac-toe](https://en.wikipedia.org/wiki/Tic-tac-toe), you start, you are the **X**. \
There's a three-by-three grid of empty spaces that you can click. Clicking a space will draw an **X** and then the opponent's turn will begin. The opponent will draw an **O** on another empty space and it will be your turn again.\
The objective is to draw 3 equal symbols on a line or diagonal. The first one to achieve this will win.\
After the game ends you can click on the <span style="color:red">X</span> on the top left corner to go back to the main menu and play again.

### TicOatTwo
A tic-tac-toe variant created by the youtuber Oats Jenkins. He explains his creation on [this video](https://www.youtube.com/watch?v=ePxrVU4M9uA) and you can play the original on the [tickoattwo.com](https://www.tickoattwo.com/) website.\
\
Here you also have a three-by-three grid of empty spaces that you can click. Clicking a space will draw a vertical line **|** and then the opponent's turn will begin. The opponent will draw a horizontal line **-** on another space and your turn will resume.\
On this mode you can draw your line on top of the opponent's **-** line, **but not on the last line that they played, while the opponent cannot draw on the last line that you played**. This unplayable line will be colored <span style="color:green">green</span>, you cannot click on top of it.\
The objective of this game is to draw 3 **+** (a vertical line on top of a horizontal line) on a line or on a diagonal, the first one to achieve this will win.

### Wild tic-tac-toe
On this variant you can choose **on every move** if you want to draw an **X** or an **O**.\
On the bottom right corner there are 2 checkboxes, the checkbox that is filled will be the symbol you chose to play.\
There's also a three-by-three grid of empty spaces that you can click. Clicking a space will draw your chosen symbol and then the opponent's turn will begin. The opponent will also choose a symbol and draw it on another empty space and it will be your turn again.\
The objective is to draw 3 equal symbols on a line or diagonal. The first one to achieve this will win. You can win using either **X** or **O**.

## Class diagram
![architecture](./Architecture/3-tac-toe.svg)