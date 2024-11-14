module Assignment10.Exercises

open Icon

// ex 11.1
let rec len xs =
    match xs with
    | [] -> 0
    | _::xr -> 1 + len xr

let rec lenc xs cont =
    match xs with
    | [] -> cont 0
    | _::xr ->
        lenc xr (fun next -> 1 + cont next)

let rec leni xs acc =
    match xs with
    | [] -> acc
    | _::xr -> leni xr (acc+1)

// ex 11.2
let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x]
    
let rec revc xs cont =
    match xs with
    | [] -> cont []
    | x::xr -> revc xr (fun next -> next@[x] |> cont)
       
let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xr -> revi xr (x::acc)
       
// ex 11.3
let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x*prod xr

let rec prodc xs cont =
    match xs with
    | [] -> cont 1
    | x::xr -> prodc xr (fun next -> x*next |> cont)
    
// ex 11.4
let rec prodco xs cont =
    match xs with
    | [] -> cont 1
    | x::_ when x = 0 -> 0
    | x::xr -> prodco xr (fun next -> x*next |> cont)

let rec prodi xs acc =
    match xs with
    | [] -> acc
    | x::_ when x = 0 -> 0
    | x::xr -> prodi xr (x*acc)


// ex 11.8 i
let ex118i1 = Every(Write(Prim("+", Prim("*", CstI 2, FromTo(1, 4)), CstI 1)))
let ex118i2 = Every(Write(Prim("+", Prim("*", CstI 10, FromTo(2, 4)), FromTo(1, 2))))

// ex 11.8 ii
let ex118ii = Write(Prim("<", CstI 50, Prim("*", CstI 7, FromTo(1, 100))))

// ex 11.8 iii
let ex118iiiSqr = Every(Write(Prim1("sqr", FromTo(3, 6))))
let ex118iiiEven = Every(Write(Prim1("even", FromTo(1, 7))))


// ex 11.8 iv
let ex118iv = Write(Multiples(CstI 3))
let ex118iv2 = Write(Multiples(FromTo(3, 5)))

