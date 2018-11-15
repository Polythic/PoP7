type pit = int
type board = int list
type player = Player1 | Player2
let isHome : b:board -> p:player -> i:pit -> bool =
if p = Player1 && b.[i] = 7 then
  true
elif p = Player2 && b.[i] = 0 then
  true
else
  false 
