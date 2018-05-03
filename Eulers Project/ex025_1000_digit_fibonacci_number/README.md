# Digit fibonacci number

In the 25th problem the task is to find a fibonacci number which is 1000 digits long.

Solution
---

```fsharp
let fibonacci : bigint seq =
    let rec loop a b = seq {yield a ; yield! loop b (a + b)}
    Seq.append [0I] (loop 1I 1I)

fibonacci
|> Seq.findIndex (fun i -> Seq.length (string i) = 1000)
|> printfn("%A")
```

Walkthrough
---

First we have to create an infinite sequence that contains all the fibonacci numbers. But instead of starting to fill the first element in the sequence with fibonacci numbers, I added a zero in front of the sequence. Because otherwise the element at the index **0** in the sequence would be the **1st** fibonacci number.

```fsharp
let fibonacci : bigint seq =
    let rec loop a b = seq {yield a ; yield! loop b (a + b)}
    Seq.append [0I] (loop 1I 1I)
```

Now, I can get the index of the element which is 1000 digits long. For this, I convert the elements into a string, so I can use the 'Seq.length' methode to get the amount of digits.

```fsharp
fibonacci
|> Seq.findIndex (fun i -> Seq.length (string i) = 1000)
|> printfn("%A")
```

Result
---

The result equals 1366.
