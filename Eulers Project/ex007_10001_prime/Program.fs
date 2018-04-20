let n = seq {yield 2; yield! Seq.initInfinite (fun i -> i * 2 + 3) }

let isPrime (x : int) : bool = 
    match x with
    | _ when 2 = x -> true   
    | _ ->
        let maxDiv = int (sqrt (float x)) 
        let rec f (d : int) : bool = 
            if d > maxDiv then true
            else if x % d = 0 then false
            else f (d + 2)
        f 3

Seq.filter isPrime n
|> Seq.item 10001
|> printfn("%i")