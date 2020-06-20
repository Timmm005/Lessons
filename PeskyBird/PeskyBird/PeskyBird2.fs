namespace NewLessons
open System

module PeskyBird2 =


    let readInt () = Console.ReadLine() |> Int32.Parse
    let readFloat () = Console.ReadLine() |> Double.Parse

    let lesson1 () =
        
        let n = Console.ReadLine() |> Int32.Parse
        let results = [ for _ in 1..(n - 1) -> Console.ReadLine() |> Int32.Parse ]
        let teams = [ for i in 1..n -> i ]

        let getWinner (p, r) =
            match r with 
            | 1 -> fst p 
            | 2 -> snd p 
            | _ -> failwith "WTF?!"
        
        let getAllWinners r p = 
            List.zip p r 
            |> List.map getWinner
        
        let getPairs x = 
            x
            |> List.mapi (fun i e -> i, e )
            |> List.partition (fun (i, _) -> i % 2 = 0)
            ||> List.zip 
            |> List.map (fun (a, b) -> snd a, snd b)

        let getRoundResults r t = getPairs t |> getAllWinners r

        let getRounds (r : list<'A>) =
            let split x = 
                let (a, b) =
                    x 
                    |> List.mapi (fun i e -> i, e)
                    |> List.partition (fun (i, _) -> i < (x.Length + 1) / 2 )

                a |> List.map snd , b |> List.map snd 

            let rec splitAll acc x =
                match x with 
                | [e] -> [e]::acc |> List.rev
                | _ -> 
                    let a, b = split x
                    splitAll (a::acc) b

            splitAll [] r
        
        let rounds = getRounds results 

        let winner = 
            rounds
            |> List.fold (fun acc r -> getRoundResults r acc ) teams 
            |> List.head 

        printfn "The winner is: %A" winner
        0
    let lesson2 () =

        let m = Console.ReadLine() |> Int32.Parse 
        let w = Console.ReadLine() |> Int32.Parse 
        let h = Console.ReadLine() |> Int32.Parse 

        let countTiles x = 
            match x % m with 
            | 0 -> (x / m) + 1
            | _ -> (x / m) + 2

        let r = (countTiles h) * (countTiles w) 

        printfn "%A" r

        0
    let lesson3 () = 

        let n = Console.ReadLine() |> Int64.Parse 
        let a = Console.ReadLine() |> Int64.Parse 
        let b = Console.ReadLine() |> Int64.Parse 
        let c = Console.ReadLine() |> Int64.Parse 

        let x = (a * n + b) / (a + b)

        let getMinTime f = 
            let d = c * f + b * (f - 1L)
            let u = c * f + a * (n - f)

            max d u

        let r =
            [x; x + 1L]
            |> List.map(fun e -> e, getMinTime e)
            |> List.sortBy snd 
            |> List.head 
            |> fst 


        printfn "%A" (int r)
        0
    let lesson4 () =
        
        let k = readFloat ()
        let p = readFloat ()
        let s = readFloat ()

        let price = k + ((k * p) / 100.0 )

        let result = s / price
        
        let r = int result 
        printfn "%A" r 
        0
    let lesson5 () =

        let x1 = readInt ()
        let y1 = readInt ()
        let x2 = readInt ()
        let y2 = readInt ()
        let x = readInt ()
        let y = readInt ()

        let rules =
            [
                x <= x1 && y >= y2 , "Pacifica"
                x > x1 && x < x2 && y > y2, "N"
                x >= x2 && y >= y2, "NE"
                x > x2 && y > y1 && y < y2, "E"
                x >= x2 && y <= y1, "SE"
                x > x1 && x < x2 && y < y1, "S"
                x <= x1 && y <= y1, "SW"
                x < x1 && y > y1 && y < y2, "W"
            ]
        
        let result = 
            rules 
            |> List.filter fst 
            |> List.head 
            |> snd 

        printfn "%s" result
        0
    let lesson6 () =
        
        let a = readInt ()
        let b = readInt ()
        
        let a1 = a % 2
        let b1 = b % 2
        let x = b1 - a1 
        match x with
        | 0 -> 
            let ans = abs (b - a) / 2 
            printfn "%A" ans
        | 1 -> 
            let ans = abs (b + 1 - a) / 2
            printfn "%A" ans
        | -1 -> 
            let ans = abs (b - 1 - a) / 2
            printfn "%A" ans
        | _ -> printfn "Gulai Vasya, zhui opilki!"
        0
    let lesson7 () =
        let s = readInt ()
        let n = readInt ()
        let w = [for _ in 1..n -> readInt()]

        let (b, s) =
            w
            |> List.fold (fun (bull, shit) r -> if bull + r <= s then (bull + r, shit) else (bull, shit + r)) (0, 0)

        printfn "%s" "Here is your shit!"
        printfn "%A" b
        printfn "%A" s
        0


    let lessons =
        [
            "Tournament(N7)", lesson1
            "Tiles(N5)", lesson2
            "Elevator(N6)", lesson3
            "Pens(N5)", lesson4
            "Raft(N6)", lesson5
            "Street(N5)", lesson6
            "Pack the bag", lesson7
        ]
        |> List.mapi (fun i (s, f) -> i + 1, s, f)


































