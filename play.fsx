type pit = int
type board = int list
type player = Player1 | Player2
let rec play : b:board -> p:player -> board
if isGameOver = true && b.isHome(player1) > b.isHome(player2)
  printf "player1 vinder"
elif isGameOver = true && b.isHome(player2) > b.isHome(player1)
  printf "player2 vinder"
then board = [0;3;3;3;3;3;3;3;3;3;3;3;3;0]


let rec play (b : board) (p : player) : board = 
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1 
    play newB nextP
