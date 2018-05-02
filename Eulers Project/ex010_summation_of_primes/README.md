# Summation of primes

Here the question is to find the sum of all primes below 2 million.

Solution
---

```fsharp
let n : seq<int64> = seq {yield 2L; yield! Seq.initInfinite (fun i -> (int64 i * 2L) + 3L)} 
                     |> Seq.takeWhile (fun i -> int64 i < 2_000_000L)

let isPrime (x : int64) : bool = 
    match x with
    | _ when 2L = x -> true  
    | _ ->
        let maxDiv = int64 (sqrt (float x)) 
        let rec f (d : int64) : bool = 
            if d > maxDiv then true
            else if x % d = 0L then false
            else f (d + 2L)
        f 3L

Seq.filter (isPrime) n 
|> Seq.sum
|> printfn ("All prime numbers under 2 million summed : %i") 
```

Walkthrough
---

In order to find the sum of all prime numbers below 2 million we need to follow 3 steps:
- create a sequence of natural numbers below 2 million
- implement a function which tests if a number is prime
- filter the sequence of natural numbers using the previous function and sum up all elements

### Create a sequence of natural numbers

The process of creating a sequence of natural numbers looks like an easy task but we can optimize it. We are only creating all the numbers in order to find all the primes in between them. No even number except for the 2 can be prime. So we can skip all of them together. 
This will lead to less calculation when we filter the whole sequence:

```fsharp
let n : seq<int64> = seq {yield 2L; yield! Seq.initInfinite (fun i -> (int64 i * 2L) + 3L)} 
                     |> Seq.takeWhile (fun i -> int64 i < 2_000_000L)
```
(Note: the type **int64** has to be used because the numbers are going to exceed the normal int range)

### Create a primality test function

A number is prime if it is not divisible by any other number, 1 and itself excluded. So we can test if a number is prime or not by simply iterating through all the numbers from 1 to **x** (**x** beeing the number to test). However, due to the commutative law we only have to test all divisors until the square root of **x**. And because we are only getting uneven numbers, except for the 2, as in input we never have to test an even divisor since no even divisor can divide an uneven number. So we can raise the divisor by 2 every recursion, starting at 3, as long as we make sure the number we are testing is not a 2.

```fsharp
let isPrime (x : int64) : bool = 
    match x with
    | _ when 2L = x -> true   
    | _ ->
        let maxDiv = int64 (sqrt (float x)) 
        let rec f (d : int64) : bool = 
            if d > maxDiv then true
            else if x % d = 0L then false
            else f (d + 2L)
        f 3L
```

### Filter the sequence and sum it up

F# makes this step very easy. We can use two predefined functions.

```fsharp
Seq.filter (isPrime) n 
|> Seq.sum
|> printfn ("All prime numbers under 2 million summed : %i") 
```

Result
---

The result equals to 142913828922.



