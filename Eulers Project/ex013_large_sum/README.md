# Large sum

The task in the 13th problem was to work out the first ten digits of the sum of hundred given 50-digit numbers. It would take up to much space to write out all of them in the ReadMe but the numbers are stored in the text file named 'Series.txt'.

Solution
---

```fsharp
open System.IO
open System.Numerics

File.ReadAllLines "Series.txt" 
|> Seq.sumBy (fun i -> BigInteger.Parse i) 
|> string
|> Seq.take 10
|> Seq.fold (fun acc i -> acc + string i) ""
|> printfn("%s") 
```

Walkthrough
---

At first, we have to read the text file. Therefore we have to open System.IO. Now we can create a string sequence which contains every line of the text file.

```fsharp
open System.IO

File.ReadAllLines "Series.txt" 
```

Then we can cast all of the elements in the sequence to the type bigint and sum them up.

```fsharp
open System.IO
open System.Numerics

File.ReadAllLines "Series.txt" 
|> Seq.sumBy (fun i -> BigInteger.Parse i) 
```

All the numbers are now added up. We now only have to get the first 10 digits. Therefore we an convert the bigint into a string and take the first 10 elements of the string. 

```fsharp
open System.IO
open System.Numerics

File.ReadAllLines "Series.txt" 
|> Seq.sumBy (fun i -> BigInteger.Parse i) 
|> string
|> Seq.take 10
```

This gives us a char sequence. We can convert the char sequence into a string again by using a 'Seq.fold' function and print out the result.

```fsharp
open System.IO
open System.Numerics

File.ReadAllLines "Series.txt" 
|> Seq.sumBy (fun i -> BigInteger.Parse i) 
|> string
|> Seq.take 10
|> Seq.fold (fun acc i -> acc + string i) ""
|> printfn("%s") 
```

Result
---

The result equals to 5537376230.
