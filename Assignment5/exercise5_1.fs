module Assignment4.exercise5_1

//Exercise 5.1.A
let rec merge (pairOfLists: int list*int list) : int list =
    match pairOfLists with
    | [], [] -> []
    | [], y::ys -> y::merge ([], ys)
    | x::xs, [] -> x::merge (xs, [])
    | x::xs, y::ys when x<=y -> x::merge(xs, y::ys)
    | x::xs, y::ys when y<x -> y::merge(x::xs, ys)