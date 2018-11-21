open Awari
let testBoard : board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]

printfn "Whitebox-testning af funktion isHome"
printfn " Branch: 1a - %b" (isHome testBoard Player1 7 = true)
printfn " Branch: 2a - %b" (isHome testBoard Player2 0 = true)
printfn " Branch: 3a - %b" (isHome testBoard Player2 7 = false)
printfn " Branch: 3b - %b" (isHome testBoard Player1 0 = false)
printfn " Branch: 3c - %b" (isHome testBoard Player1 5 = false)
printfn " Branch: 3d - %b" (isHome testBoard Player2 1 = false)

printfn "Whitebox-testning af funktion distribute"
printfn " Branch: 1a - %b" (distribute testBoard Player1 1 = ([|0;0;4;4;4;3;3;0;3;3;3;3;3;3|], Player1, 4))
//printfn " Branch: 2a - %b" (p = Player2 & i = 7)
//printfn " Branch: 3a - %b" (isHome [] = )
//Printfn " Branch: 4a - ‰b" (isHome [] = )
