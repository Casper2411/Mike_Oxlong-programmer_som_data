(* File Fun/ParseAndRun.fs *)

module ParseAndRun

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

// Exercise 4.2

//Compute the sum of the numbers from 1000 down to 1. Do this by defining a function sum n that computes the
//sum n+(n−1)+···+2+1. (Use straight- forward summation, no clever tricks.)
let exSum =
    run (fromString "let sum n = if n = 1 then 1 else n + sum (n - 1) in sum 1000 end")



//Compute the number 3^8, that is, 3 raised to the power 8. Again, use a recursive function.
let exPower38 =
    run (fromString "let power n = if n = 0 then 1 else 3 * power (n-1) in power 8 end")



//Compute 3^0 + 3^1 + ··· + 3^10 + 3^11, using a recursive function (or two, if you prefer).
let exPower311 =
    run (
        fromString
            "let rightPower x = if x = 0 then 1 else 3 * rightPower (x-1) in let power y = if y = 0 then rightPower 0 else rightPower y + (power (y-1)) in power 11 end"
    )
(*
Dette er opklarenende tekst til hvordan funktionen virker, så den er mere letlæselig:
run (fromString "let rightPower x = 
                        if x = 0 then 1 
                        else 3 * rightPower (x-1) 
                in let power y = 
                        if y = 0 then rightPower 0
                        else rightPower y + (power (y-1))
                in power 11 end")
*)



//Compute 1^8 + 2^8 + · · · + 10^8 , again using a recursive function (or two).
let exPower108 =
    run (
        fromString
            "let power8 n = n * n * n * n * n * n * n * n in let power y = if y = 1 then then power8 1 else rightPower y + (power (y-1)) in power 10 end"
    )
(*
Dette er opklarenende tekst til hvordan funktionen virker, så den er mere letlæselig:
run (fromString "let power8 n = 
                        n * n * n * n * n * n * n * n
                in let power y = 
                        if y = 1 then then power8 1
                        else rightPower y + (power (y-1))
                in power 10 end")
*)
