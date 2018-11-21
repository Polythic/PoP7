open Awari
let mutable testBoard1 : board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]
let testBoard2 : board = [|0;3;3;3;3;3;3;0;0;0;0;0;0;0|]
let testBoard3 : board = [|0;0;0;0;0;0;0;0;3;3;3;3;3;3|]
let testBoard4 : board = [|0;0;0;0;0;0;0;0;0;0;0;0;0;0|]
let testBoard5 : board = [|0;0;3;3;3;3;3;0;0;3;3;3;3;3|]

printfn "Whitebox-testing af funktionen isHome"
printfn " Branch: 1a - %b" (isHome testBoard1 Player1 7 = true)
printfn " Branch: 2a - %b" (isHome testBoard1 Player2 0 = true)
printfn " Branch: 3a - %b" (isHome testBoard1 Player2 7 = false)
printfn " Branch: 3b - %b" (isHome testBoard1 Player1 0 = false)
printfn " Branch: 3c - %b" (isHome testBoard1 Player1 5 = false)
printfn " Branch: 3d - %b" (isHome testBoard1 Player2 1 = false)

printfn "Whitebox-testing af funktionen isGameOver"
printfn " Branch: 1a - %b" (isGameOver testBoard1 = false)
printfn " Branch: 2a - %b" (isGameOver testBoard2 = true)
printfn " Branch: 3a - %b" (isGameOver testBoard3 = true)
printfn " Branch: 4a - %b" (isGameOver testBoard4 = true)

printfn "Whitebox-testning af funktion getMove"
// Uncomment lines to test with input at end of each line
//printfn " Branch: 1a - %b" (getMove testBoard Player1 "" = 4) // input 4
//printfn " Branch: 2a - %b" (getMove testBoard Player1 "" = 99) // input 8
//printfn " Branch: 2b - %b" (getMove testBoard Player2 "" = 99) // input 3
//printfn " Branch: 3a - %b" (getMove testBoard2 Player1 "" = 98) // input 1
//printfn " Branch: 3b - %b" (getMove testBoard2 Player2 "" = 98) // input 8

printfn "Whitebox-testning af funktionen distribute"
printfn " Branch: 1a - %b" (distribute testBoard1 Player1 4 = ([|0;3;3;3;0;4;4;1;3;3;3;3;3;3|], Player1, 7))
testBoard1 <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard1
printfn " Branch: 2a - %b" (distribute testBoard1 Player2 11 = ([|1;3;3;3;3;3;3;0;3;3;3;0;4;4|], Player2, 0))
testBoard1 <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard1
printfn " Branch: 3a - %b" (distribute testBoard1 Player1 11 = ([|0;4;3;3;3;3;3;0;3;3;3;0;4;4|], Player1, 1))
testBoard1 <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard1
printfn " Branch: 4a - %b" (distribute testBoard1 Player2 4 = ([|0;3;3;3;0;4;4;0;4;3;3;3;3;3|], Player2, 8))
testBoard1 <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard1
