(* Programming language concepts for software developers, 2012-02-17 *)

(* Evaluation, checking, and compilation of object language expressions *)
(* Stack machines for expression evaluation                             *)

(* Object language expressions with variable bindings and nested scope *)

module Intcomp1

type expr =
    | CstI of int
    | Var of string
    (*Exercise 2.1 - changed Let to new format*)
    | Let of (string * expr) list * expr
    | Prim of string * expr * expr

(* Some closed expressions: *)

let ex = Let([ "x1", Prim("+", Var "x1", CstI 7) ], Prim("+", Var "x1", CstI 8))
let e1 = Let([ "z", CstI 17 ], Prim("+", Var "z", Var "z"))

let e2 =
    Let([ "z", CstI 17 ], Prim("+", Let([ "z", CstI 22 ], Prim("*", CstI 100, Var "z")), Var "z"))

let e3 = Let([ "z", Prim("-", CstI 5, CstI 4) ], Prim("*", CstI 100, Var "z"))

let e4 =
    Prim("+", Prim("+", CstI 20, Let([ "z", CstI 17 ], Prim("+", Var "z", CstI 2))), CstI 30)

let e5 = Prim("*", CstI 2, Let([ "x", CstI 3 ], Prim("+", Var "x", CstI 4)))


let freex = Let([ "y", CstI 6 ], Prim("+", Var "x", CstI 3))

(* ---------------------------------------------------------------------- *)

(* Evaluation of expressions with variables and bindings *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    (*Exercise 2.1 - revised to take the new format of Let*)
    | Let(bindings, ebody) ->
        let env1 =
            (env, bindings)
            ||> List.fold (fun env (x, erhs) ->
                let xval = eval erhs env
                (x, xval) :: env)

        eval ebody env1
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _ -> failwith "unknown primitive"

let run e = eval e []


(* ---------------------------------------------------------------------- *)

(* Closedness *)

// let mem x vs = List.exists (fun y -> x=y) vs;;

let rec mem x vs =
    match vs with
    | [] -> false
    | v :: vr -> x = v || mem x vr

(* ---------------------------------------------------------------------- *)

(* Free variables *)

(* Operations on sets, represented as lists.  Simple but inefficient;
   one could use binary trees, hashtables or splaytrees for
   efficiency.  *)

(* union(xs, ys) is the set of all elements in xs or ys, without duplicates *)

let rec union (xs, ys) =
    match xs with
    | [] -> ys
    | x :: xr -> if mem x ys then union (xr, ys) else x :: union (xr, ys)

(* minus xs ys  is the set of all elements in xs but not in ys *)

let rec minus (xs, ys) =
    match xs with
    | [] -> []
    | x :: xr -> if mem x ys then minus (xr, ys) else x :: minus (xr, ys)

(* Find all variables that occur free in expression e *)

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x -> [ x ]
    (*Exercise 2.2 - revised to take the new format of Let*)
    | Let(bindings, ebody) ->
        ([], bindings)
        ||> List.fold (fun acc (x, erhs) -> acc @ union (freevars erhs, minus (freevars ebody, [ x ])))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)

(* Alternative definition of closed *)

let closed2 e = (freevars e = [])


(* ---------------------------------------------------------------------- *)

(* Compilation to target expressions with numerical indexes instead of
   symbolic variable names.  *)

type texpr = (* target expressions *)
    | TCstI of int
    | TVar of int (* index into runtime environment *)
    | TLet of texpr * texpr (* erhs and ebody                 *)
    | TPrim of string * texpr * texpr

(* Map variable name to variable index at compile-time *)

let rec getindex vs x =
    match vs with
    | [] -> failwith "Variable not found"
    | y :: yr -> if x = y then 0 else 1 + getindex yr x

(* Compiling from expr to texpr *)

let eksempel = Let([ "x", CstI 2; "y", CstI 6 ], Prim("*", Var "x", Var "y"))
let env = [ "x"; "y" ]

let rec tcomp (e: expr) (cenv: string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x -> TVar(getindex cenv x)
    (*Exercise 2.3 - revised to work for work for the extended expr language*)
    | Let(bindings, ebody) ->
        let rec inner xs env acc =
            match xs with
            | [] -> acc
            | (x, binding) :: xs ->
                let tmp = x :: env
                inner xs tmp (TLet(tcomp binding env, acc))

        let initialAcc = tcomp ebody cenv
        inner bindings cenv initialAcc
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)

(* Evaluation of target expressions with variable indexes.  The
   run-time environment renv is a list of variable values (ints).  *)

let rec teval (e: texpr) (renv: int list) : int =
    match e with
    | TCstI i -> i
    | TVar n -> List.item n renv
    | TLet(erhs, ebody) ->
        let xval = teval erhs renv
        let renv1 = xval :: renv
        teval ebody renv1
    | TPrim("+", e1, e2) -> teval e1 renv + teval e2 renv
    | TPrim("*", e1, e2) -> teval e1 renv * teval e2 renv
    | TPrim("-", e1, e2) -> teval e1 renv - teval e2 renv
    | TPrim _ -> failwith "unknown primitive"

(* Correctness: eval e []  equals  teval (tcomp e []) [] *)
