open System.IO
open System.Numerics

File.ReadAllLines "Series.txt" 
|> Seq.sumBy (fun i -> BigInteger.Parse i) 
|> string
 |> Seq.take 10
|> Seq.fold (fun acc i -> acc + int64 i) 0L
|>printfn("%i") 