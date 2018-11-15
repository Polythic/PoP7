type pit = int
type board = int list
type player = Player1 | Player2
let play : b:board -> p:player -> board
if isGameOver = true && b.isHome(player1) > b.isHome(player2)
  printf "player1 vinder"
elif isGameOver = true && b.isHome(player2) > b.isHome(player1)
  printf "player2 vinder"
then board = [0;3;3;3;3;3;3;3;3;3;3;3;3;0]
