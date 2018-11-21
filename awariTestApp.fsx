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

    printfn "Whitebox-testning af funktion isHome"
    printfn " Branch: 1a - %b" (isHome [] = )
    printfn " Branch: 2a - %b" (isHome [] = )
    printfn " Branch: 3a - %b" (isHome [] = )
    Printfn " Branch: 4a - ‰b" (isHome [] = )
