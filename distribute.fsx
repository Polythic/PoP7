type pit = int
type board = pit array
type player = Player1 | Player2

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable beanCount = b.[i]
  b.[i] <- 0
  let mutable pi = i + 1 //pit index
  let notHome =
    match p with
    | Player1 -> 0
    | Player2 -> 7
  let home =
    match p with
    | Player1 -> 7
    | Player2 -> 0

  while beanCount > 0 do
    if pi <> notHome then
      b.[pi] <- (b.[pi] + 1)
      beanCount <- beanCount - 1
      pi <- pi + 1
    else
      pi <- pi + 1

  let finalPit = pi - 1
  if b.[finalPit] = 1 then
    b.[home] <- b.[home] + b.[14-(finalPit)]
    b.[14-(finalPit)] <- 0
    b.[home] <- b.[home] + 1
    b.[finalPit] <- 0
    (b,p,finalPit)
  else
    (b,p,finalPit)

let testBoard : board = [|0;3;3;3;3;3;3;0;3;3;0;3;3;3|]
let printBoard (b: board) : unit =
  printfn "  %A %A %A %A %A %A" b.[13] b.[12] b.[11] b.[10] b.[9] b.[8]
  printfn "%A             %A" b.[0] b.[7]
  printfn "  %A %A %A %A %A %A" b.[1] b.[2] b.[3] b.[4] b.[5] b.[6]

// printfn "%A" (distribute testBoard Player1 5)
let newBoard, _, _ = (distribute testBoard Player2 6)
printBoard (newBoard)
