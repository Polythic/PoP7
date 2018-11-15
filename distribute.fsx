type pit = int
type board = pit list
type player = Player1 | Player2

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable beanCount = b.[i]
  let mutable pitIndex = i + 1
  while beanCount > 0 do
    b.[pitIndex] <- b.[pitIndex] + 1
    beanCount <- beanCount - 1
    pitIndex <- pitIndex + 1
  
