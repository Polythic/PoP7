module Awari
type pit = int // typen integer brugt til at holde indeks af felter på brættet
type board = pit array // array af pits til at holde værdien af pits
type player = Player1 | Player2

let printBoard (b: board) : unit = // Printer boardet efter indeks i arrayet
  printfn "  %A %A %A %A %A %A" b.[13] b.[12] b.[11] b.[10] b.[9] b.[8]
  printfn "%A             %A" b.[0] b.[7]
  printfn "  %A %A %A %A %A %A" b.[1] b.[2] b.[3] b.[4] b.[5] b.[6]

let isHome (b:board) (p:player) (i:pit) : bool =
  if p = Player1 && i = 7 then // Hvis p er Player1 og indeks er 7
    true
  elif p = Player2 && i = 0 then // Hvis p er Player2 og indeks er 0
    true
  else
    false

let isGameOver (b: board) : bool =
  let p1Board = b.[1..6] //Pits tilhørende Player1
  let p2Board = b.[8..13] //Pits tilhørende Player2
  let mutable p1 = 0
  let mutable p2 = 0
  let p1Empty =
    for i in p1Board do // Gennemgår alle pits for Player1, og incrementerer p1
      if i <> 0 then    // med 1 hvis pit i ikke er tomt *)
        p1 <- p1 + 1
      else
        p1 <- p1
    p1 = 0              //Hvis p1 er 0, er alle pits for Player1 tomme,
                        // og p1Empty bliver true
  let p2Empty =
    for i in p2Board do // Gennemgår alle pits for Player2, og incrementerer p2
      if i <> 0 then    //med 1 hvis pit i ikke er tomt *)
        p2 <- p2 + 1
      else
        p2 <- p2
    p2 = 0              //Hvis p2 er 0, er alle pits for Player2 tomme,
                        // og p2Empty bliver true
  p1Empty || p2Empty    // Hvis p1Empty eller p2Empty er true, returnerer
                        // isGameOver true
let getMove (b: board) (p: player) (q: string) : pit =
  printfn "%A" q        // Skriver strengen q til spilleren
  let userInput = int (System.Console.ReadLine()) // Læser spillerens input
  match p with          // Vurderer om spillerens valg er lovligt
  | Player1 ->
    if userInput > 0 && userInput < 7 then // For Player1, check om valget er
      if b.[userInput] <> 0 then           // en gyldig pit, dvs. mellem 0 og 7
        userInput                          // Hvis true og pit'en ikke er tom
      else                                 // returner userInput
        98                                 // Hvis pit er tom returner 98
    else                                   // Hvis ugyldig pit returner 99
      99
  | Player2 ->
    if userInput > 7 && userInput < 14 then // Se kommentar ovenfor
      if b.[userInput] <> 0 then
        userInput
      else
        98
    else
      99

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable beanCount = b.[i]
  b.[i] <- 0
  let mutable pi =      // Lokal variabel der holder nuværende pit
    if i <> 13 then
      i + 1
    else
      0
  let oppHome =         // Sætter modstanders hjem afhængigt af p
    match p with
    | Player1 -> 0
    | Player2 -> 7
  let home =
    match p with        // Sætter eget hjem afhængigt af p
    | Player1 -> 7
    | Player2 -> 0

  while beanCount > 0 do           // Så længe der er bønner :
    if pi <> oppHome then          // Hvis pi ikke er modstanders hjem, læg
      b.[pi] <- (b.[pi] + 1)       // bønne og gå videre til næste pit
      beanCount <- beanCount - 1   // ellers gå videre til næste pit
      if pi <> 13 then
        pi <- pi + 1
      else
        pi <- 0
    else
      pi <- pi + 1

  let finalPit =            // Sidste pit distribute lander i
    if pi <> 0 then
      pi - 1
    else
      13

  // Hvis sidste pit har 1 bønne (og dermed var tom før distribute), ikke er
  // hjem, og feltet overfor ikke er tomt tag bønner fra felt overfor og sidste
  if b.[finalPit] = 1 && finalPit <> home && b.[14-(finalPit)] <> 0 then
    b.[home] <- b.[home] + b.[14-(finalPit)]
    b.[14-(finalPit)] <- 0
    b.[home] <- b.[home] + 1
    b.[finalPit] <- 0
    (b,p,finalPit)
  else
    (b,p,finalPit)

// Kommentarer kun tilføjet til ændringer af original kode fra Jon.
let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      elif n = 98 then  // Se kommentar til getMove
        sprintf "Invalid move: pit is empty, please try again!"
      elif n = 99 then  // Se kommentar til getMove
        sprintf "Invalid move: illegal pit, please try again!"
      else
        "Again? "
    let i = getMove b p str
    if i = 98 then      // Hvis getMove giver 98 (fejl i brugerinput) prøv igen
      repeat b p 98
    elif i <> 99 then   // Hvis getMove ikke giver 99 (fejl i brugerinput)
      let (newB, finalPitsPlayer, finalPit)= distribute b p i
      if not (isHome b finalPitsPlayer finalPit)
        || (isGameOver b) then
        newB
      else
        repeat newB p (n + 1)
    else                // Ellers hvis getMove giver 99, prøv igen
      repeat b p 99
  repeat b p 0

// Ingen rettelser tilføjet til original kode fra Jon
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
