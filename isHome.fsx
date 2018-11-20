type pit = int
type board = int list
type player = Player1 | Player2
let isHome (b:board) (p:player) (i:pit) : bool =
  if p = Player1 && i = 7 then
    true
  elif p = Player2 && i = 0 then
    true
  else
    false
