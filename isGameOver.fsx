type pit = int
type board = pit list
let isGameOver (b: board) : bool =
  let mutable i = 1
  while b.[i] = 0 && i < 7 do
    i <- i + 1
  if i = 7 then
    true
  else
    i <- 7
    while b.[i] = 0 && i < 13 do
      i <- i + 1
    if i = 13 then
      true
    else
      false

let testBoard : board = [0;0;0;3;0;0;0;0;0;0;0;0;0;0]
printfn "%A" (isGameOver testBoard)
