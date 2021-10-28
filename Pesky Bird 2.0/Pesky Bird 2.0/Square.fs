namespace Olympus
open System


module Square =
    let solve n m k =
        let d = 4L * (m + n) * (m + n) - 16L * k
        let w = (2.0 * (float (m + n)) - sqrt(float d)) / 8.0 |> floor
        int w

    let readInt64() = Console.ReadLine() |> Int64.Parse

    let runSquare() =
        let n = readInt64()
        let m = readInt64()
        let k = readInt64()
        let w = solve n m k
        printfn $"{w}"




