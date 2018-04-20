let collatzLength (n : int) : int = 
    let rec loop (x : int64) (i : int) : int =
        if x = 1L then i
        else match x with
             | _ when x % 2L = 0L -> loop (x / 2L) (i + 1)
             | _ -> loop ((x * 3L + 1L) / 2L) (i + 2)
    loop (int64 n) 1

Seq.init 999_999 (fun i -> i + 1) 
|> Seq.maxBy (collatzLength)
|> printfn("%i") 