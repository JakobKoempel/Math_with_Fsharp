open System.IO

File.ReadLines "Series.txt" 
|> Seq.concat 
|> Seq.map (fun i -> int64 i - int64 '0')
|> Seq.windowed 13  
|> Seq.map (Array.reduce (*))
|> Seq.max 
|> printfn("%i")