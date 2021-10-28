namespace Olympus
open System

module MaxWidth = 
    let x = 1

    type CharMap = Map<char, List<int>>

    let findFirst map c i = 
        let x =
            map
            |> Map.find c
            |> List.find (fun e -> e > i)

        x

    let findLast map c i = 
        let x =
            map
            |> Map.find c
            |> List.rev
            |> List.find (fun e -> e < i)

        x

    let findShortestStart (sm: CharMap) t =
        
        let lol (a, i) ch =
            let n = findFirst sm ch i
            (n :: a), n

        let kelp = 
            t
            |> List.fold lol ([], -1)
            |> snd

        kelp

    let findShortestEnd (sm: CharMap) t =
        
        let lol (a, i) ch =
            let n = findLast sm ch i
            (n :: a), n

        let kelp = 
            t
            |> List.rev
            |> List.fold lol ([], Int32.MaxValue)
            |> snd

        kelp

    let doShit sm t =
        let tr = t |> List.rev

        let rec lol x y maxVal =
            match x with
            | [] -> maxVal
            | h :: x1 ->
                let a = findShortestStart sm (x1 |> List.rev)
                let y1 = h :: y
                let b = findShortestEnd sm y1
                let maxVal1 = max (b - a) maxVal

                lol x1 y1 maxVal1

        lol tr [] 0

    let run() = 
        let s = "ab".ToCharArray() |> List.ofArray
        let t = "c".ToCharArray() |> List.ofArray

        let sm =
            s
            |> List.mapi (fun i cha -> (cha, i))
            |> List.groupBy fst
            |> List.map (fun (cha, x) -> cha, x |> List.map snd)
            |> Map.ofList

        let r = doShit sm t
        printfn $"{r}"






