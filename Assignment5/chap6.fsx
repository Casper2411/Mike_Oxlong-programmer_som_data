
(* Section 6.2.2 *)
(* Does not work because we can't generalize type for x as it depends on type of y. *)
let g y =
  let f x = x=y
  f 1 && f false
g 2

(* Works *)
let g y =
  let f x = true
  f 1 && f false
g 2

(* Type Inference *)
#r "./FsLexYacc/FsLexYacc.Runtime.dll"
#load "Util.fs"
#load "Absyn.fs"
#load "FunPar.fs"
#load "FunLex.fs"
#load "Parse.fs"
#load "TypeInference.fs"
#load "ParseAndType.fs"

open ParseAndType;;
inferType (fromString "let f x = 1 in f 7 + f false end");;
inferType (fromString "let id x = x in id end");;

// Slide 3
inferType (fromString "let f x = 1 in f 2 + f true end");;

// Slide 5
inferType (fromString "let twice g = let app y = g (g y) in app end in twice end");;
inferType (fromString "let mul2 y = 2 * y in mul2 end");;
inferType (fromString "let twice g = let app y = g (g y) in app end in let mul2 y = 2 * y in twice mul2 11 end end");;

// Slide 7
inferType (fromString "let f g = g 7 + g false in f end");; // Type error - parameter not polymorphic
inferType (fromString "let h x = if true then 22 else h 7 + h false in h end");; // Type error - function h not polymorphic in own body.

// Slide 8
inferType (fromString "let f x = f f in f end");; // Type error - non circular

// Slide 9
inferType (fromString "let f x = let g y = if x = y then 11 else 22 in g false end in f 42 end");; // Type error - enclosing scope

// Slide 10
inferType (fromString "let f x = 1 in f f end");;
inferType (fromString "let f g = g g in f end");;
inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;

// Slide 13
inferType (fromString "let x = 1 in x < 2 end");;
inferType (fromString "let f x = 1 in f 2 + f false end");;
inferType (fromString "let f x = 1 in f f end");;
// Slide 24
slowTypeInferenceExample()


//Exercise 6.5
// Part 1
// Type is 'int'
inferType (fromString "let f x = 1 in f f end");;

// Type could not be inferred
// f is expecting an argument but gets none?
inferType (fromString "let f g = g g in f end");;

// Type is 'bool'
inferType (fromString "
           let f x =
                let g y = y
                in g false end
           in f 42 end");;

// Type could not be inferred - why? 
inferType (fromString "
           let f x =
                let g y = if true then y else x
                in g false in
           f 42 end");;

// Type is 'bool' 
inferType (fromString "
           let f x =
                let g y = if true then y else x
                in g false end
           in f true end");;


// Part 2
// (bool -> bool)
inferType (fromString "let f x = if x then true else false in f end");;

// (int -> int)
inferType (fromString "let f x = x+x in f end");;

// (int -> (int -> int))
inferType (fromString "
           let f x =
                let g y = y+x
                in g end
           in f end");;

// ’a -> ’b -> ’a
inferType (fromString "
           let f x =
                let g y = x
                in g end
           in f end");;


inferType (fromString "
           let f x =
                let g y = y
                in g end
           in f end");;

inferType (fromString "let f = 42 in f end");;




