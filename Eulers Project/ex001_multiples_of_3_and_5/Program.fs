
List.init 1000 (fun i -> i) 
|> List.filter (fun i -> i % 3 = 0 || i % 5 = 0) 
|> List.sum 
|> printfn("%i")