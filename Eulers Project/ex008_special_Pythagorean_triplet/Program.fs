open System

type Triplet = {
    a : int
    b : int
    c : int
}

let isSquare (x : int ) : bool = 
    let root = int (sqrt (float x))
    root * root = x

let findTripletWithCircumferenceOf (limit : int) : Triplet =
    let hypotenuse (a : int, b : int) : int = int (sqrt(float(a * a + b * b)))
    let rec f (a : int, b : int) : Triplet =
        let c = hypotenuse (a, b)
        if isSquare c = false then f (a, b + 1)
        else match a + b + c with
             | Cf when Cf < limit -> f (a, b + 1)
             | Cf when Cf > limit -> f (a + 1, a + 2)
             | _ -> {a = a ; b = b ; c = c}
    f (1, 2)
          
printfn("%A") <| findTripletWithCircumferenceOf 1000

Console.ReadKey() |> ignore
