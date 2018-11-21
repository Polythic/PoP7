type pit = int
type board = pit array
let isGameOver (b: board) : bool =
  let p1Board = b.[1..6]
  let p2Board = b.[8..13]
  let mutable p1 = 0
  let mutable p2 = 0
  let p1Empty =
    for i in p1Board do
      if i <> 0 then
        p1 <- p1 + 1
      else
        p1 <- p1
    p1 = 0
  let p2Empty =
    for i in p2Board do
      if i <> 0 then
        p2 <- p2 + 1
      else
        p2 <- p2
    p2 = 0

  p1Empty || p2Empty

let testBoard : board = [|0;0;0;0;1;0;0;8;0;0;9;0;0;0|]
printfn "%A" (isGameOver testBoard)

(* let mutable i = 1
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
    false *)
