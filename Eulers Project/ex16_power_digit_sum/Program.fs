string (1I <<< 1000) 
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i") 