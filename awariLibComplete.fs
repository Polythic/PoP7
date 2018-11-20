module Awari
type pit = int // intentionally left empty
type board = pit array // intentionally left empty
type player = Player1 | Player2

// intentionally many missing implementations and additions
let printBoard (b: board) : unit =
  printfn "  %A %A %A %A %A %A" b.[13] b.[12] b.[11] b.[10] b.[9] b.[8]
  printfn "%A             %A" b.[0] b.[7]
  printfn "  %A %A %A %A %A %A" b.[1] b.[2] b.[3] b.[4] b.[5] b.[6]

let isHome (b:board) (p:player) (i:pit) : bool =
  if p = Player1 && i = 7 then
    true
  elif p = Player2 && i = 0 then
    true
  else
    false

let isGameOver (b: board) : bool =
  let mutable i = 1
  while b.[i] = 0 && i < 7 do
    i <- i + 1
  if i = 7 then
    true
  else
    i <- 7
    while b.[i] = 0 && i < 13 do
      i <- i + 1
    if i = 13 then
      true
    else
      false

let getMove (b: board) (p: player) (q: string) : pit =
  printfn "%A" q
  let userInput : pit = int (System.Console.ReadLine())
  userInput

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable beanCount = b.[i]
  b.[i] <- 0
  let mutable pi = i + 1 //pit index
  let oppHome =
    match p with
    | Player1 -> 0
    | Player2 -> 7
  let home =
    match p with
    | Player1 -> 7
    | Player2 -> 0

  while beanCount > 0 do
    if pi <> oppHome then
      b.[pi] <- (b.[pi] + 1)
      beanCount <- beanCount - 1
      if pi <> 13 then
        pi <- pi + 1
      else
        pi <- 0
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

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      else
        "Again? "
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit)
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
