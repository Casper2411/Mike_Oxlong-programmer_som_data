(* File Fun/ParseAndRun.fs *)

module ParseAndRun

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

let ex1 = "let add x = let f y = x+y in f end in add 2 5 end" |> fromString |> run;;
let ex2 = "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end" |> fromString |> run;;
let e3 = "let add x = let f y = x+y in f end
              in let addtwo = add 2
                 in let x = 77 in addtwo 5 end
              end end"
         |> fromString |> run;;
let e4 = "let add x = let f y = x+y in f end
            in add 2 end"
         |> fromString |> run;;
