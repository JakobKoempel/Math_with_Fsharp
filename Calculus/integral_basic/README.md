# Integrals in F#

In this project I estimate the integral of a given function using F#.
An integral is the area in an interval between the graph of a function and the x-axis. The area can be estimated drawing of rectangles between the graph and x-axis and adding up the area. 

![integral estimation](https://user-images.githubusercontent.com/38069530/39575182-e9b68e32-4ed9-11e8-9541-1a5c71b968f2.gif)

By decreasing the width and increasing the amount of rectangles the accuracy increases.

Code
---

```fsharp
let g (x : float) = x ** 3. * 2. + 5.

let integral (f : float -> float) (a : float) (b : float) (stepwidth : float) : float =
    let rec loop (x : float) (acc : float) : float =
        if x < b then
            loop (x + stepwidth) (acc + f x * stepwidth) 
        else acc
    loop a 0.

printfn("%f") <| integral g 0. 1. 0.000001
```

Walkthrough
---

First, I created an examplary mathematical function to calculate an integral with.

```fsharp
let g (x : float) = x ** 3. * 2. + 5.
```

Now. let's get to the integral function. It takes four arguments: the function, it should caculate an integral with, two limits that define the interval and the stepwidth. The stepwidth describes the widths of the rectangles. The function then iterates through the x values from a to b, calculates the area of the rectangles and sums them up.

```fsharp
let integral (f : float -> float) (a : float) (b : float) (stepwidth : float) : float =
    let rec loop (x : float) (acc : float) : float =
        if x < b then
            loop (x + stepwidth) (acc + f x * stepwidth) 
        else acc
    loop a 0.
```
