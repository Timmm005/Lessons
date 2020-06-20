open NewLessons.PeskyBird2
 
open System 

[<EntryPoint>]
let main argv =
    printfn "%A" argv

    lessons 
    |> List.map (fun (i, s, f) -> printfn "Lesson number: %A - %A" i s)
    |> ignore 

    printfn "Input Lesson number:"
    let n = Console.ReadLine() |> Int32.Parse 

    let (a,b,c) = lessons.[n - 1]
    c() |> ignore

    Console.ReadLine() |> ignore 



    0 // return an integer exit code
