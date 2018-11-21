open Awari
let testBoard1 : board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]
let testBoard2 : board = [|0;3;3;3;3;3;3;0;0;0;0;0;0;0|]
let testBoard3 : board = [|0;0;0;0;0;0;0;0;3;3;3;3;3;3|]
let testBoard4 : board = [|0;0;0;0;0;0;0;0;0;0;0;0;0;0|]


printfn "Whitebox-testing af funktion isHome"
printfn " Branch: 1a - %b" (isHome testBoard1 Player1 7 = true)
printfn " Branch: 2a - %b" (isHome testBoard1 Player2 0 = true)
printfn " Branch: 3a - %b" (isHome testBoard1 Player2 7 = false)
printfn " Branch: 3b - %b" (isHome testBoard1 Player1 0 = false)
printfn " Branch: 3c - %b" (isHome testBoard1 Player1 5 = false)
printfn " Branch: 3d - %b" (isHome testBoard1 Player2 1 = false)

printfn "Whitebox-testing af funktionen isGameOver"
printfn "Branch: 1a - %b" (isGameOver testBoard1 = false)
printfn "Branch: 2a - %b" (isGameOver testBoard2 = true)
printfn "Branch: 3a - %b" (isGameOver testBoard3 = true)
printfn "Branch: 4a - %b" (isGameOver testBoard4 = true)


printfn "Whitebox-testing af funktion distribute"
printfn " Branch: 1a - %b" (distribute testBoard1 Player1 1 = ([|0;0;4;4;4;3;3;0;3;3;3;3;3;3|], Player1, 4))
//printfn " Branch: 2a - %b" (p = Player2 & i = 7)
//printfn " Branch: 3a - %b" (isHome [] = )
//Printfn " Branch: 4a - ‰b" (isHome [] = )
