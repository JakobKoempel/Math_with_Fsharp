open System

let n : seq<int64> = seq {yield 2L; yield! Seq.initInfinite (fun i -> (int64 i * 2L) + 3L)} 
                     |> Seq.takeWhile (fun i -> int64 i < 2_000_000L)

let isPrime (x : int64) : bool = 
    match x with
    |_ when 2L = x -> true   
    | _ when 2L > x  || x % 2L = 0L -> false 
    | _ ->
        let maxDiv = int64 (sqrt (float x)) 
        let rec f (d : int64) : bool = 
            if d > maxDiv then true
            else if x % d = 0L then false
            else f (d + 2L)
        f 3L

let primesSummed = Seq.filter (isPrime) n |> Seq.sum

printfn ("All prime numbers under 2 million summed : %A") <| primesSummed 

Console.ReadKey () |> ignore
