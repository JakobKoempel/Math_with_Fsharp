
let n = Seq.init 100 ((+) 1)

(n |> Seq.fold (fun acc i -> acc + i * i) 0) - pown (n |> Seq.sum) 2 |> abs
|> printfn "%i"