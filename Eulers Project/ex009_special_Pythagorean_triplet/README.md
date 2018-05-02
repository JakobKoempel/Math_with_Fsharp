# Special Pythagorean Triplet

A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a ** 2 + b ** 2 = c ** 2.
Each number represents the lengths of a side in a right-angled triangle.
The question is to find the product of a, b and c of the only Pythagorean triplet with a circumference of 1000.

Solution
---

```fsharp
let isWholeNumber (x : float) : bool = 
    x % 1.0 = 0.0

let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        if c |> isWholeNumber then 
            match a + b + int c with
                | circumference when circumference < target -> f (a, b + 1)
                | circumference when circumference > target -> f (a + 1, a + 2)
                | _ -> (a, b, int c)
        else f (a, b + 1) 
    f (1, 2)

let (a : int, b : int, c : int) =  findTripletWithCircumferenceOf 1000       
printfn("%i") <| (a * b * c)
```

Walkthrough
---

We start off by writing a function that takes a target circumference as an argument and 
returns 3 values stored in a tuple which represent each variable, a, b and c, of the triplet.

````fsharp
let findTripletWithCircumferenceOf (target : int) : int * int * int = ...
```

We know that a and b can only be natrual numbers and that b must be larger than a. 
So we can iterate through all possibilities by a tail recrusive function called 'f' starting by a = 1 and b = 2.
For each set of values for a and b we can calculate c.

````fsharp
let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        ...
    f (1, 2)
```

Since c also has to be a natural number in order to fulfill the condition, 
we dont even have to test if the circumference of the the triangle equals the target circumference 
when c is not an natural number. 
To test if c is a natural number we need another function called 'isWholeNumber'.

```fsharp
let isWholeNumber (x : float) : bool = 
    x % 1.0 = 0.0

let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        if c |> isWholeNumber then 
            ...
        else ...
    f (1, 2)
```
(Note: strictly the function 'isWholeNumber' only tests if a number is a whole number
but since we are only dealing with positive integers here it does not matter)

If c is not a natural number we can just test if the next pair of values for a and b. 
If c is natural we can start testing the circumference.

```fsharp
let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        if c |> isWholeNumber then 
            match a + b + int c with
                ...
        else f (a, b + 1) 
    f (1, 2)
```

If the circumference is smaler than the target, we raise b by 1.
If the circumference is larger than the target, we raise the value of a by 1 and reset the value of b.
If the circumference euquals the target we can finally return the values of a, b and c.

```fsharp
let findTripletWithCircumferenceOf (target : int) : int * int * int =
    let hypotenuse (a : int, b : int) : float = sqrt(float(a * a + b * b))  
    let rec f (a : int, b : int) : int * int * int =
        let c = hypotenuse (a, b)
        if c |> isWholeNumber then 
            match a + b + int c with
                | circumference when circumference < target -> f (a, b + 1)
                | circumference when circumference > target -> f (a + 1, a + 2)
                | _ -> (a, b, int c)
        else f (a, b + 1) 
    f (1, 2)
```

After writing this function we only have to call it and print out the product of all 3 values.

```fsharp
let (a : int, b : int, c : int) =  findTripletWithCircumferenceOf 1000       
printfn("%i") <| (a * b * c)
```

Result
---

The result equals to 31875000.
