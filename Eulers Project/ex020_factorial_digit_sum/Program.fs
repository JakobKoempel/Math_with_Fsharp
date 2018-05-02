let rec factorial (n : bigint) : bigint =
        if n = 0I then 1I
        else n * factorial (n - 1I) 

string (factorial 100I)
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i")