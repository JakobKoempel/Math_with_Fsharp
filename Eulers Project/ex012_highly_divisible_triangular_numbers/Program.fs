let triangularNum (n : int) : int = (n * (n - 1)) / 2 

let countDivisors (n : int) : int = 
    let rec loop (i : int) (divCount : int) : int = 
        match i * i with
        | i2 when i2 < n -> if n % i = 0 then loop (i + 1) (divCount + 2)
                            else loop (i + 1) divCount
        | i2 when i2 > n -> divCount
        | _ -> divCount + 1
    loop 1 0

Seq.initInfinite (fun i -> triangularNum i) 
|> Seq.find (fun n -> countDivisors n > 500) 
|> printfn("%i")