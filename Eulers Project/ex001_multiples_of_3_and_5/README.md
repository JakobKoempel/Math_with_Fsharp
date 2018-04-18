# Multiples of 3 and 5

This project contains the solution for the problem number 001.
The task is to find all multiples of 3 and 5 under 1000 and add them up.

Solution
---
```fsharp
open System

List.init 1000 (fun i -> i) |> List.filter (fun i -> i % 3 = 0 || i % 5 = 0) |> List.sum |> printfn("%i")

Console.ReadKey () |> ignore
```
Walkthrough
---
In the beginning, a list containing all numbers from 0 to 1000 is created (1000 is excluded).
```fsharp
List.init 1000 (fun i -> i)
```
This list is then passed to a function which filters out all the numbers that cannot be divided by 3 or 5.
```fsharp
List.init 1000 (fun i -> i) |> List.filter (fun i -> i % 3 = 0 || i % 5 = 0) 
```
The resulting list only contains numbers that are divisible by 3 or 5.
Now all of these numbers in the list are summed up and printed out.
```fsharp
List.init 1000 (fun i -> i) |> List.filter (fun i -> i % 3 = 0 || i % 5 = 0) |> List.sum |> printfn("%i")
```
Result
---
The result is 233168
