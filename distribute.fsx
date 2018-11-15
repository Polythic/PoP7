type pit = int
type board = pit list
type player = Player1 | Player2

let distribute (b:board) (p:player) (i:pit) : board * player * pit
