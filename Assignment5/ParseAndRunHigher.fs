(* File Fun/ParseAndRunHigher.fs *)

module ParseAndRunHigher

open HigherFun;;

let fromString = Parse.fromString;;

let eval = HigherFun.eval;;

let run e = eval e [];;

(* Examples of higher-order programs, in concrete syntax *)

(*First 4 examples are from exercise 6.1*)
let ex1 = "let add x = let f y = x+y in f end in add 2 5 end" |> fromString |> run;;
let ex2 = "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end" |> fromString |> run;;
let ex3 = "let add x = let f y = x+y in f end
              in let addtwo = add 2
                 in let x = 77 in addtwo 5 end
              end end"
         |> fromString |> run;;
//The reason that ex3 still returns 7 as the result, is because the variable x is enclosed in the
//function 'add', and it therefore has nothing to do with the x that is defined later in the 'let x = 77' part. 

let ex4 = "let add x = let f y = x+y in f end
            in add 2 end"
         |> fromString |> run;;
//Running this example returns a closure and not the result of the evaluation, because the function has not been given
//the parameter 'y' yet. 

let ex5 = 
    Parse.fromString 
     @"let tw g = let app x = g (g x) in app end 
       in let mul3 x = 3 * x 
       in let quad = tw mul3 
       in quad 7 end end end";;

let ex6 = 
    Parse.fromString 
     @"let tw g = let app x = g (g x) in app end 
       in let mul3 x = 3 * x 
       in let quad = tw mul3 
       in quad end end end";;

let ex7 = 
    Parse.fromString 
     @"let rep n = 
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let tw = rep 2 
       in let quad = tw mul3 
       in quad 7 end end end end";;

let ex8 = 
    Parse.fromString 
     @"let rep n =
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let twototen = rep 10 mul3 
       in twototen 7 end end end";;

let ex9 = 
    Parse.fromString 
     @"let rep n = 
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let twototen = (rep 10) mul3 
       in twototen 7 end end end";;
