type pit = int
type board = int array
type player = Player1 | Player2
let isHome (b:board) (p:player) (i:pit) : bool =
  if p = Player1 && i = 7 then
    true
  elif p = Player2 && i = 0 then
    true
  else
    false
let testBoard : board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]

printfn "Whitebox-testning af funktion isHome"
printfn " Branch: 1a - %b" (isHome testBoard Player1 7 = true)
printfn " Branch: 2a - %b" (isHome testBoard Player2 0 = true)
printfn " Branch: 3a - %b" (isHome testBoard Player2 7 = false)
Printfn " Branch: 3b - ‰b" (isHome testBoard Player1 0 = false)
printfn " Branch: 3c - %b" (isHome testBoard Player1 5 = false)
printfn " Branch: 3d - %b" (isHome testBoard Player2 1 = false)
