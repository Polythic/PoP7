type pit = int
type board = pit list
let isGameOver : b:board -> bool =
let mutable i = 1
while b.i = [] and i < 7 do
  i <- i + 1
if b.i > 0
    return false
