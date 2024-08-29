(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

    let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

    let emptyenv = []; (* the empty environment *)

    let rec lookup env x =
        match env with 
        | []        -> failwith (x + " not found")
        | (y, v)::r -> if x=y then v else lookup r x;;

    let cvalue = lookup env "c";;


    (* Object language expressions with variables *)

    type expr = 
      | CstI of int
      | Var of string
      | Prim of string * expr * expr
      // Exercise 1.1 (iv) Add 'if' datatype
      | If of expr * expr * expr;;

    let e1 = CstI 17;;

    let e2 = Prim("+", CstI 3, Var "a");;

    let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;
    
    // Exercise 1.1 (ii), added example expressions
    let e4 = Prim("max", e1, e2);;
    let e5 = Prim("min", e1, e2);;
    let e6 = Prim("==", e1, CstI 17);;
    let e7 = Prim("==", e1, CstI 4);;
    
    //Exercise 1.1 (V), added if statement
    let e8 = If(Var "a", CstI 11, CstI 22);;

    (* Evaluation within an environment *)

    let rec eval e (env : (string * int) list) : int =
        match e with
        | CstI i            -> i
        | Var x             -> lookup env x 
        | Prim("+", e1, e2) -> eval e1 env + eval e2 env
        | Prim("*", e1, e2) -> eval e1 env * eval e2 env
        | Prim("-", e1, e2) -> eval e1 env - eval e2 env
        // Exercise 1.1 (i), added max, min, and ==
        | Prim("max", e1, e2) ->
            let eval1 = eval e1 env
            let eval2 = eval e2 env
            if eval1 > eval2 then eval1 else eval2
        | Prim("min", e1, e2) ->
            let eval1 = eval e1 env
            let eval2 = eval e2 env
            if eval1 < eval2 then eval1 else eval2
        | Prim("==", e1, e2) ->
            if (eval e1 env) = (eval e2 env) then 1 else 0
        | Prim _            -> failwith "unknown primitive";;
        
    // Exercise 1.1 (iii) Eval function rewritten 
    let rec eval2 e (env : (string * int) list) : int =
        match e with
        | CstI i            -> i
        | Var x             -> lookup env x
        | Prim(ope, e1, e2) ->
            let i1 = eval2 e1 env
            let i2 = eval2 e2 env
            match ope with
                | "+" -> i1 + i2
                | "*" -> i1 * i2
                | "-" -> i1 - i2
                | "max" -> if i1 > i2 then i1 else i2
                | "min" -> if i1 < i2 then i1 else i2
                | "==" -> if i1 = i2 then 1 else 0
                | _ -> failwith "unknown operator"
        | If(e1, e2, e3) ->
            let i1 = eval2 e1 env
            if i1 <> 0 then eval2 e2 env else eval2 e3 env;; 

    let e1v  = eval e1 env;;
    let e2v1 = eval e2 env;;
    let e2v2 = eval e2 [("a", 314)];;
    let e3v  = eval e3 env;;
    
    // Exercise 1.1 (ii), added evaluations of examples
    let e4v = eval e4 env;;
    let e5v = eval e5 env;;
    let e6v = eval e6 env;;
    let e7v = eval e7 env;;
    
    //Exercise 1.1 (V), test of if statement
    
    let e8v = eval2 e8 env;;
    
    //Exercise 1.2 (i), aexpr datatype
    type aexpr =
        | CstI of int
        | Var of string
        | Add of aexpr*aexpr
        | Mul of aexpr*aexpr
        | Sub of aexpr*aexpr;;
    
    // Exercise 1.2 (ii)
    // v - (w + z)
    // Sub(Var "v", Add(Var "w", Var "z"))
    
    // 2 * (v - (w + z))
    // Mul(CstI 2, (Sub(Var "v", Add(Var "w", Var "z")))
    
    // x + y + z + v
    // Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))
    
    // Exercise 1.2 (iii) Format function
    let rec fmt (a:aexpr) :string =
        match a with
        | CstI i -> string i 
        | Var s -> s
        | Add(aexpr1, aexpr2) -> "(" + fmt aexpr1 + " + " + fmt aexpr2 + ")"
        | Mul(aexpr1, aexpr2) -> "(" + fmt aexpr1 + " * " + fmt aexpr2 + ")"
        | Sub(aexpr1, aexpr2) -> "(" + fmt aexpr1 + " - " + fmt aexpr2 + ")";;
        
    // Exercise 1.2 (iv) simplify function
    let simplify (a:aexpr) :aexpr =
        match a with
        | Add(CstI 0, aexpr2) -> aexpr2
        | Add(aexpr1, CstI 0) -> aexpr1
        | Sub(aexpr1, CstI 0) -> aexpr1
        | Mul(CstI 1, aexpr2) -> aexpr2
        | Mul(aexpr1, CstI 1) -> aexpr1
        | Mul(CstI 0, _) -> CstI 0
        | Mul(_, CstI 0) -> CstI 0
        | Sub(aexpr1, aexpr2) when aexpr1=aexpr2 -> CstI 0
        | _ -> a;;
      
    // Exercise 1.2 (v) differentiate function   
    let rec differentiate (a:aexpr) x =
        match a with
        | CstI _ -> CstI 0
        | Var v when v=x -> CstI 1
        | Var _ -> CstI 0
        | Add(aexpr1, aexpr2) -> Add(differentiate aexpr1 x, differentiate aexpr2 x)
        | Mul(aexpr1, aexpr2) -> Add(Mul(differentiate aexpr1 x, aexpr2), Mul(differentiate aexpr2 x, aexpr1))
        | Sub(aexpr1, aexpr2) -> Sub(differentiate aexpr1 x, differentiate aexpr2 x);;
        
