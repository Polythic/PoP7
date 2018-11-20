type pit = int
type board = pit array
type player = Player1 | Player2

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable beanCount = b.[i]
  let mutable pitIndex = i + 1
  let mutable newBoard = b
  while beanCount > 0 do
    newBoard.[pitIndex] <- (newBoard.[pitIndex] + 1)
    beanCount <- beanCount - 1
    pitIndex <- pitIndex + 1
  (newBoard,p,pitIndex)
