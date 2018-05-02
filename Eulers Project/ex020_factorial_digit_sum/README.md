# Factorial digit sum

In this problem the task was to find the sum of the digits in the number 100!.

Solution
---

```fsharp
let rec factorial (n : bigint) : bigint =
        if n = 0I then 1I
        else n * factorial (n - 1I) 

string (factorial 100I)
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i")
```

Walkthrough
---

Before we can sum the digits up, we have to wirte a function which return factorials. 

```fsharp
let rec factorial (n : bigint) : bigint =
        if n = 0I then 1I
        else n * factorial (n - 1I) 
```

After creating the number with the value of 100!, we only have to sum all the digits up. In order to do so, 
we can convert the bigint number into a string. Because in F# strings are also char sequences, we can run the function 'Seq.fold' 
with the converted number as a parameter to add up all digits. 

```fsharp
string (factorial 100I)
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i")
```
(Note: before adding the digits together, the chars have to be converted into integers)

Result
---

The result equals 648.

