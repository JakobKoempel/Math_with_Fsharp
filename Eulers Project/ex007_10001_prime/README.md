# Finding the 10001th prime number

This project contains the solution for the 7th problem. The task is to find the 10001th prime number. 

Solution
---

```fsharp
let n = seq {yield 2; yield! Seq.initInfinite (fun i -> i * 2 + 3) }

let isPrime (x : int) : bool = 
    match x with
    | _ when 2 = x -> true   
    | _ ->
        let maxDiv = int (sqrt (float x)) 
        let rec f (d : int) : bool = 
            if d > maxDiv then true
            else if x % d = 0 then false
            else f (d + 2)
        f 3

Seq.filter isPrime n
|> Seq.item 10001
|> printfn("%i")
```

Walkthorugh
---
A number is prime when it cant be divided by any other number except for 1 and its own. So when creating a list of natural numbers we can skip all even numbers since all even numbers can be divided by 2. When doing this we have to keep the 2 because it is the only even number which also is prime.

```fsharp
let n = seq {yield 2; yield! Seq.initInfinite (fun i -> i * 2 + 3) }
```

After creating this infinite list we only have to filter out those which are not prime and then take the 10001th element in the list in order to get the correct answer.

```fsharp
Seq.filter isPrime n
|> Seq.item 10001
|> printfn("%i")
```

Before filtering the list the function 'isPrime' has to be defined. The function takes an integer value and returns a boolean depending on if the input number was a prime or not. 

```fsharp
let isPrime (x : int) : bool = 
...
```

Because the 2 is the only even number in the created list we test it separately

```fsharp
let isPrime (x : int) : bool = 
    match x with
    | _ when 2 = x -> true   
    | _ -> ...
```

As explained, a number is prime if it cant be divided by any other number except for 1 and its own. So we can iterate through by using a tail recursive function called 'f' and check if one number can divide the given number. When doing this we start at 3 since all numbers can be divided by 1 and none can be divided by 2 since there are no even numbers in the list, we want to filter. And based on the commutative law we only have to iterate until the divisor reaches the square root of the number to test.

```fsharp
let isPrime (x : int) : bool = 
    match x with
    | _ when 2 = x -> true   
    | _ ->
        let maxDiv = int (sqrt (float x)) 
        let rec f (d : int) : bool = 
            if d > maxDiv then true
            else if x % d = 0 then false
            else f (d + 2)
        f 3
```
Note that we can increase the divisor by 2 every iteration because all numbers we are testing are with the function 'f' are uneven and therefore cant be divided by an even number. 

Result
---

The 10001th number of the filtered list is 104759.
