type pit = int
type board = pit list
let printBoard (b: board) : unit =
  printfn "  %A %A %A %A %A %A" b.[7] b.[8] b.[9] b.[10] b.[11] b.[12]
  printfn "%A             %A" b.[0] b.[13]
  printfn "  %A %A %A %A %A %A" b.[1] b.[2] b.[3] b.[4] b.[5] b.[6]

let testBoard : board = [0;3;3;3;3;3;3;3;3;3;3;3;3;0]
printBoard testBoard
