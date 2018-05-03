# Power digit sum

In this problem the task was to find the sum of all digits of the number 2 ** 1000.

Solution
---

```fsharp
string (1I <<< 1000) 
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i") 
```

Walkthrough
---

First, we have to create the number 2 ** 1000. We could do this using the 'BigInteger.Pow' method. However, we also can use byte-shifting.
Since 2 ** 1000 equals a one with onethousands zeros in the base-2 system, we can create the number by directly using the base-2 system.

```fsharp
1I <<< 1000
```

In order to get the digits out of the bigint number we cast it into a string. Since a string is char sequence, we can pipe it into the 'Seq.fold' methode, cast every char into an int and sum them all up.

```fsharp
string (1I <<< 1000) 
|> Seq.fold (fun acc i -> acc + int i - int '0') 0
|> printfn("%i")
```

Result
----

Now we can print out the result. It equals 1366.
