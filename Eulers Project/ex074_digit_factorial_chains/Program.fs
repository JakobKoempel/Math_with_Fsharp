let rec fac (n : int) : int = 
    if n = 0 then 1
    else fac (n - 1) * n

let factorial : int[] = Array.init 10 (fun i -> fac i) //dynamic programming optimization

let digitFacChain (start : int) : int =
   let rec loop (x : int) (tested : int list) : int =
        let facDigitSum = string x 
                          |> Seq.fold  (fun acc digit -> 
                            factorial.[int digit - int '0'] + acc
                          ) 0 
        if Seq.contains facDigitSum tested  then tested.Length
        else loop facDigitSum (facDigitSum::tested)
   loop start [start]  

Seq.init 1_000_000 id
|> Seq.filter (fun i -> digitFacChain i = 60)
|> Seq.length
|> printfn("%i")