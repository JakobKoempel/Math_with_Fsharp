let fibonacci : bigint seq =
    let rec loop a b = seq {yield a ; yield! loop b (a + b)}
    Seq.append [0I] (loop 1I 1I)

fibonacci
|> Seq.findIndex (fun i -> Seq.length (string i) = 1000)
|> printfn("%A")