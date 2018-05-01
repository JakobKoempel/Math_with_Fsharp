let isWholeNumber (x : float) : bool = 
    x % 1.0 = 0.0

let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        if isWholeNumber c then 
            match a + b + int c with
                | circumference when circumference < target -> f (a, b + 1)
                | circumference when circumference > target -> f (a + 1, a + 2)
                | _ -> (a, b, int c)
        else f (a, b + 1) 
    f (1, 2)

let (a : int, b : int, c : int) =  findTripletWithCircumferenceOf 1000       
printfn("%i") <| (a * b * c)