let g (x : float) = x ** 3. * 2. + 5.

let integral (f : float -> float) (a : float) (b : float) (stepwidth : float) : float =
    let rec loop (x : float) (acc : float) : float =
        if x < b then
            loop (x + stepwidth) (acc + f x * stepwidth) 
        else acc
    loop a 0.

printfn("%f") <| integral g 0. 1. 0.000001