﻿open System

let (x : int) = 10001
let n = seq {yield 2; yield! Seq.initInfinite (fun i -> i * 2 + 3) }

let isPrime (x : int) : bool = //only natural numbers
    match x with
    | _ when 2 = x -> true   
    | _ when 2 > x  || x % 2 = 0 -> false 
    | _ ->
        let maxDiv = int (sqrt (float x)) 
        let rec f (d : int) : bool = 
            if d > maxDiv then true
            else if x % d = 0 then false
            else f (d + 2)
        f 3

let findXthPrime (x : int) : int =
    let primes = Seq.filter isPrime n
    let rec f (p : seq<int>) (i : int) : int =
        if x = i then Seq.head p
        else f (Seq.tail p) (i + 1)
    f primes 1

printfn("%i is the %ist prime number") (findXthPrime x) x

Console.ReadKey() |> ignore


