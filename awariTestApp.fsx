open Awari
let mutable testBoard : board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]

printfn "Whitebox-testning af funktion isHome"
printfn " Branch: 1a - %b" (isHome testBoard Player1 7 = true)
printfn " Branch: 2a - %b" (isHome testBoard Player2 0 = true)
printfn " Branch: 3a - %b" (isHome testBoard Player2 7 = false)
printfn " Branch: 3b - %b" (isHome testBoard Player1 0 = false)
printfn " Branch: 3c - %b" (isHome testBoard Player1 5 = false)
printfn " Branch: 3d - %b" (isHome testBoard Player2 1 = false)

printfn "Whitebox-testning af funktion distribute"
printfn " Branch: 1a - %b" (distribute testBoard Player1 4 = ([|0;3;3;3;0;4;4;1;3;3;3;3;3;3|], Player1, 7))
testBoard <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard
printfn " Branch: 2a - %b" (distribute testBoard Player2 11 = ([|1;3;3;3;3;3;3;0;3;3;3;0;4;4|], Player2, 0))
testBoard <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard
printfn " Branch: 3a - %b" (distribute testBoard Player1 11 = ([|0;4;3;3;3;3;3;0;3;3;3;0;4;4|], Player1, 1))
testBoard <- [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|] // reset testBoard
printfn " Branch: 4a - %b" (distribute testBoard Player2 4 = ([|0;3;3;3;0;4;4;0;4;3;3;3;3;3|], Player2, 8))
