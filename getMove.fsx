type pit = int
type board = pit list
type player = Player1 | Player2

let printBoard (b: board) : unit =
  printfn "  %A %A %A %A %A %A" b.[12] b.[11] b.[10] b.[9] b.[8] b.[7]
  printfn "%A             %A" b.[0] b.[13]
  printfn "  %A %A %A %A %A %A" b.[1] b.[2] b.[3] b.[4] b.[5] b.[6]

let getMove (b: board) (p: player) (q: string) : pit =
  printfn "%A" q
  let userInput : pit = int (System.Console.ReadLine())
  userInput

let testBoard : board = [0;3;3;3;3;3;3;3;3;3;3;3;3;0]

printfn "%A" (getMove testBoard Player1 "Please choose a pit")
