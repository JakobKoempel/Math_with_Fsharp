open System.IO
open System.Numerics

let firstTenDigitsOfSum = File.ReadAllLines "Series.txt" 
                    |> Seq.sumBy (fun i -> BigInteger.Parse i) 
                    |> string
                    |> Seq.take 10 

let digitsToInt (digits : char seq) = new string [|for i in digits -> i|]
                                    |> int64
printfn("%i") <| digitsToInt  firstTenDigitsOfSum