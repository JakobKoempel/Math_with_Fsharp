# Longest Collatz sequence

In this problem the task was to find the longest Collatz sequence starting below one million.

A Collatz sequence is created by following rules:
-if the number is even, divide it by two
-if the number is odd, triple it and add one

Any natural number can be given as an input and the sequence will allways end on the number 1. (Note: it is not proven that for every starting number the Collatz sequence will eventually reach 1 but it is highly suggested. Read more)
But depending on the starting number it takes a different amount of steps to get the the end.

Solution
---

```fsharp
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
```

Walkthrough
---

All we need is a function that returns the length of a Collatz sequence of a given starting number. 
For this we just ran the Collatz sequence operation until the we reach one. For every iteration we add 1 to the counter **i**. 
But since we know that if you triple an odd number and add 1 to it, you will get an even number, we can instantly divide the resulting number by 2 and increase the **i** by 2.

```fsharp
let collatzLength (n : int) : int = 
    let rec loop (x : int64) (i : int) : int =
        if x = 1L then i
        else match x with
             | _ when x % 2L = 0L -> loop (x / 2L) (i + 1)
             | _ -> loop ((x * 3L + 1L) / 2L) (i + 2)
    loop (int64 n) 1
```

Now we only need to create a sequence of all natural numbers from 1 to 999999 and calculate the Collatz sequence for every one. Then we get the maximal value in the sequence and print out the result.

Result
---

The result equals to 837799.
