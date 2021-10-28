﻿namespace Olympus
open System
module Olimp1 =
    let toInt32() = Console.ReadLine() |> Int32.Parse

    type Brick =
        {
            a : int
            b : int
        }

        member brick.flip() = 
            {
                a = brick.b
                b = brick.a
            }
    
        member brick.tryFlip b = 
            match b with
            | false -> brick
            | true -> brick.flip()


    let createBrick() =
        {
            a = toInt32()
            b = toInt32()
        }


    type Barge = 
        | OneRow of Brick * Brick * Brick
        | TwoRows of (Brick * Brick) * Brick

        member barge.area = 
            match barge with
            | OneRow (x, y, z) ->
                let a = x.a + y.a + z.a
                let b = [x.b; y.b; z.b] |> List.max
                a * b
            | TwoRows ((x, y), z) -> 
                let a = [x.a + y.a; z.a] |> List.max
                let b = ([x.b; y.b] |> List.max) + z.b
                a * b


    let createBarge (x : Brick, y : Brick, z : Brick) a (b, c, d) =
        let x1 = x.tryFlip b
        let y1 = y.tryFlip c
        let z1 = z.tryFlip d

        match a with
        | false -> OneRow (x1, y1, z1)
        | true -> TwoRows ((x1, y1), z1)


    let flips = 
        [
            false, false, false
            false, false, true
            false, true, false
            false, true, true
            true, false, false
            true, false, true
            true, true, false
            true, true, true
        ]


    let createAll x y z = 
        [
            createBarge (x, y, z) false
            createBarge (x, y, z) true
            createBarge (z, y, x) true
            createBarge (x, z, y) true
        ]
        |> List.map (fun e -> flips |> List.map e) 
        |> List.concat


    let findBest x y z =
        createAll x y z
        |> List.map (fun e -> e.area)
        |> List.min


    let runBarge() = 
        let br1 = createBrick()
        let br2 = createBrick()
        let br3 = createBrick()
        let a = findBest br1 br2 br3
        printfn "%A" a
        //Console.ReadLine() |> ignore


//===============================================

    let s1 a b k = 
        (-(1 + k) * (-3 * (-2 + a - b) * (-1 + a - b) + 2 * k + k * k)) / 6

    let s2 a b c k =
        -(-1 + a - b + k) * (a - b + k) * (1 + a + 2 * b - 3 * c + k) / 6

    let k a b c =
        if c - b - 1 < b - a
        then c - b - 1
        else b - a

    let runTrains() =
        let a = toInt32()
        let b = toInt32()
        let c = toInt32()
        let _ = toInt32()

        let j = k a b c
        let s1 = s1 a b j
        let s2 = s2 a b c j
        let ans = s1 + s2
        printfn "%A" ans







