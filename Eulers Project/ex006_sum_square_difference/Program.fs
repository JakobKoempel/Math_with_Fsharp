open System

let limit = 100
let n (i : int) = Seq.init i (fun j -> j + 1)

let square_add (s : seq<int>) : int =
    let squared = Seq.map (fun i -> i * i) s
    Seq.sum squared

let add_square (s : seq<int>) =
       int (float (Seq.sum s) ** 2.)

let dif = add_square (n limit) - square_add (n limit)

printfn("%i") <| dif 
