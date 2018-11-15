type pit = int
type board = pit list
type player = Player1 | Player2

let getMove (b: board) (p: player) (q: string) : pit =
  
