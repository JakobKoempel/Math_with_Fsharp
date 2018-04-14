open System

type Triplet = {
    a : int
    b : int
    c : int
}

let isNaturalNumber (x : float) : bool = 
    if x % 1.0 = 0.0 then true
    else false

let findTripletWithCircumferenceOf (limit : int) : Triplet =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : Triplet =
        let c = hypotenuse (a, b)
        if isNaturalNumber c = false then f (a, b + 1)
        else match a + b + int c with
                | Cf when Cf < limit -> f (a, b + 1)
                | Cf when Cf > limit -> f (a + 1, a + 2)
                | _ -> {a = a ; b = b ; c = int c}
    f (1, 2)

let resultTriplet =  findTripletWithCircumferenceOf 1000       
printfn("%A") <| (resultTriplet.a * resultTriplet.b * resultTriplet.c)

Console.ReadKey() |> ignore
