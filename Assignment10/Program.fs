module Assignment10.Program

open Exercises
open Icon

printfn "Exercise 11.1"
printfn "%A" (len [2; 5; 7])
printfn "%A" (lenc [2; 5; 7] id)
printfn "%A" (lenc [2; 5; 7] (fun x -> 2*x))
printfn "%A" (leni [2; 5; 7] 0)

printfn ""
printfn "Exercise 11.2"
printfn "%A" (rev [2; 5; 7])
printfn "%A" (revc [2; 5; 7] id)
printfn "%A" (revi [2; 5; 7] [])

printfn ""
printfn "Exercise 11.3"
printfn "%A" (prod [2; 5; 7])
printfn "%A" (prodc [2; 5; 7] id)

printfn ""
printfn "Exercise 11.4"
printfn "%A" (prodco [2; 5; 7; 0] id)
printfn "%A" (prodi [2; 5; 7; 0] 1)

printfn ""
printfn "Exercise 11.8"
run ex118i1
printfn ""
run ex118i2
//run ex9