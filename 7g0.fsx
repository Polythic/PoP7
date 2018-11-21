open Awari
let startBoard: board = [|0;3;3;3;3;3;3;0;3;3;3;3;3;3|]
let finalBoard = (play startBoard Player1)
let winner =
  if finalBoard.[0] > finalBoard.[7] then
    "Winner is Player2"
  elif finalBoard.[0] < finalBoard.[7] then
    "Winner is Player1"
  else
    "Tie - No winner!"
printBoard finalBoard
printfn "Game over!"
printfn "%s" winner
