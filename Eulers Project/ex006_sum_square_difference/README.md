# Sum square difference

This project contains the solution for the sixth Eulers Project problem. The task is to find the difference between the sum of the suares of the first one hundred natural numbers and the squared sum of the first one hundred natural numbers. 

Solution
---
```fsharp
let n = Seq.init 100 ((+) 1)

(n |> Seq.fold (fun acc i -> acc + i * i) 0) - pown (n |> Seq.sum) 2 |> abs
|> printfn "%i"
```
Walkthrough
---
The first step is to initialize a sequence which contains all natural numbers from 1 to 100 (including 100).
```fsharp
let n = Seq.init 100 ((+) 1)
```
After this the sequence is passed into a function that takes every element in the sequence to the power of 2 and adds all the elements up.
```fsharp
n |> Seq.fold (fun acc i -> acc + i * i) 0
```
Then a second value is created by adding up all natural numbers until 100 and squaring the sum afterwards.
```fsharp
pown (n |> Seq.sum) 2
```
Then the difference of those two values is taken.
In the final solution both of these steps are done in one line.
```fsharp
(n |> Seq.fold (fun acc i -> acc + i * i) 0) - pown (n |> Seq.sum) 2 
```
Finally, the absolute value of the difference is taken in case the first number is smaller than the second.
Then the result is printed out.
```
(n |> Seq.fold (fun acc i -> acc + i * i) 0) - pown (n |> Seq.sum) 2 |> abs
|> printfn "%i"
```
Result
---
The result equals to 25164150.
