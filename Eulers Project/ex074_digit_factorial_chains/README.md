# Digit factorial chain

The 74th problem was slightly more difficult to solve. As in April 2018, only 20.000 people solved it so far.   
In this problem the task was to find how many digit factorial chains, with a starting number below one million, contain exactly sixty non-repeating terms.
  
A digit factorial chain is a sequence of natural numbers which is created as follows:  
The next number of the sequence is determined by summing the factorials of all digits in the previous number.    
(50 →  5! + 0! = 120 + 1 = 121)  
This sequences will allaways end in a loop. For example:    
69 → 363600 → **1454** → 169 → 363601 → (**1454**)  
(The sequence above has 5 non-repeating terms)

Solution
---

```fsharp
let rec fac (n : int) : int = 
    if n = 0 then 1
    else fac (n - 1) * n

let factorial : int[] = Array.init 10 (fun i -> fac i) //dynamic programming optimization

let digitFacChainLength (start : int) : int =
   let rec loop (x : int) (tested : int list) : int =
        let facDigitSum = string x 
                          |> Seq.fold  (fun acc digit -> 
                            factorial.[int digit - int '0'] + acc
                          ) 0 
        if Seq.contains facDigitSum tested  then tested.Length
        else loop facDigitSum (facDigitSum::tested)
   loop start [start]  

Seq.init 1_000_000 id
|> Seq.filter (fun i -> digitFacChainLength i = 60)
|> Seq.length
|> printfn("%i")
```

Walkthrough
---

At first, we have to create a function which returns factorials for any given natural number. This is easily solved by recursion.

```fsharp
let rec fac (n : int) : int = 
    if n = 0 then 1
    else fac (n - 1) * n
```
But since we know we will only need to calculate the factorials of numbers between 0 and 9, we can create an array with 10 elements which stores the factorial for each digit. This way we don't have to calculate the same 10 different factorials millions of times but can instead just refer to the array.

```fsharp
let factorial : int[] = Array.init 10 (fun i -> fac i) //dynamic programming optimization
```

Now we can implement the function which returns the length of a digit factorial chain. The function takes the starting number as an input and returns an integer. The function then loops through the sequence and stores all of the elements in a list. The list must be built up so we can test if the next element in the sequence is already contained or if the sequence should continue.

```fsharp
let digitFacChainLength (start : int) : int =
   let rec loop (x : int) (tested : int list) : int =
        ...
   loop start [start] 
```

Inside the loop function we first create the digit factorial sum of the current element. Then we test if the sequence already contains the element or if it doesn't. In case it does we end the recursion and return the length of the list. In case it doesn't we continue to iterate through the sequence until we find a non-repeating term.

```fsharp
let digitFacChainLength (start : int) : int =
   let rec loop (x : int) (tested : int list) : int =
        let facDigitSum = string x 
                          |> Seq.fold  (fun acc digit -> 
                            factorial.[int digit - int '0'] + acc
                          ) 0 
        if Seq.contains facDigitSum tested  then tested.Length
        else loop facDigitSum (facDigitSum::tested)
   loop start [start]  
```

Now we only have to calculate the length of the sequence for every starting number below one million and count the ones, where the digit factorial chain is exactly 60 terms long.

```fsharp
Seq.init 1_000_000 id
|> Seq.filter (fun i -> digitFacChainLength i = 60)
|> Seq.length
|> printfn("%i")
```

Result
---

The result equals to 402.
