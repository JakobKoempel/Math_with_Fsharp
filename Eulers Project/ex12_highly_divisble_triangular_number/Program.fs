open System
open System.Diagnostics

let triangularNum (n : int64) = (n * (n + 1L)) / 2L

let divisors (n : int64) : int64 = 
    let rec loop (i : int64) (div : int64) : int64 = 
        match i * i with
        | i2 when i2 < n -> if n % i = 0L then loop (i + 1L) (div + 2L)
                            else loop (i + 1L) div
        | i2 when i2 > n -> div
        | _ -> div + 1L
    loop 1L 0L

let rec find (i : int64) =
    if triangularNum i |> divisors > 500L then triangularNum i
    else find (i + 1L)

let timer = Stopwatch ()
timer.Start ()

printfn("%i") <| find 1L

timer.Stop ()

printfn("%i") timer.ElapsedMilliseconds 


Console.ReadKey () |> ignore