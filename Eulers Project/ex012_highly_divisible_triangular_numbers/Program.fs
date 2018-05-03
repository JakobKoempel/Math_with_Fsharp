let triangularNum (n : int) : int = (n * (n - 1)) / 2 

let countDivisors (x : int) : int = 
    let rec loop (i : int) (divCount : int) : int = 
        match i * i with
        | i2 when i2 < x -> if x % i = 0 then loop (i + 1) (divCount + 2)
                            else loop (i + 1) divCount
        | i2 when i2 > x -> divCount
        | _ -> divCount + 1
    loop 1 0

Seq.initInfinite (fun i -> triangularNum i) 
|> Seq.find (fun n -> countDivisors n > 500) 
|> printfn("%i")