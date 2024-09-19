// Implementation file for parser generated by fsyacc
module ExprPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "ExprPar.fsy"

  (* File Expr/ExprPar.fsy
     Parser specification for the simple expression language.
   *)

  open Absyn

# 14 "ExprPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | END
  | IN
  | LET
  | PLUS
  | MINUS
  | TIMES
  | DIVIDE
  | EQ
  | IF
  | THEN
  | ELSE
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_END
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIVIDE
    | TOKEN_EQ
    | TOKEN_IF
    | TOKEN_THEN
    | TOKEN_ELSE
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | END  -> 3 
  | IN  -> 4 
  | LET  -> 5 
  | PLUS  -> 6 
  | MINUS  -> 7 
  | TIMES  -> 8 
  | DIVIDE  -> 9 
  | EQ  -> 10 
  | IF  -> 11 
  | THEN  -> 12 
  | ELSE  -> 13 
  | NAME _ -> 14 
  | CSTINT _ -> 15 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_END 
  | 4 -> TOKEN_IN 
  | 5 -> TOKEN_LET 
  | 6 -> TOKEN_PLUS 
  | 7 -> TOKEN_MINUS 
  | 8 -> TOKEN_TIMES 
  | 9 -> TOKEN_DIVIDE 
  | 10 -> TOKEN_EQ 
  | 11 -> TOKEN_IF 
  | 12 -> TOKEN_THEN 
  | 13 -> TOKEN_ELSE 
  | 14 -> TOKEN_NAME 
  | 15 -> TOKEN_CSTINT 
  | 18 -> TOKEN_end_of_input
  | 16 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 18 
let _fsyacc_tagOfErrorTerminal = 16

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | END  -> "END" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIVIDE  -> "DIVIDE" 
  | EQ  -> "EQ" 
  | IF  -> "IF" 
  | THEN  -> "THEN" 
  | ELSE  -> "ELSE" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;10us;65535us;0us;2us;6us;7us;8us;9us;10us;11us;14us;15us;19us;20us;21us;22us;27us;24us;28us;25us;29us;26us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;4us;1us;8us;9us;10us;1us;1us;1us;2us;1us;3us;1us;4us;4us;4us;8us;9us;10us;1us;4us;4us;4us;8us;9us;10us;1us;4us;4us;4us;8us;9us;10us;1us;5us;1us;5us;1us;6us;4us;6us;8us;9us;10us;1us;6us;1us;7us;1us;7us;1us;7us;4us;7us;8us;9us;10us;1us;7us;4us;7us;8us;9us;10us;1us;7us;4us;8us;8us;9us;10us;4us;8us;9us;9us;10us;4us;8us;9us;10us;10us;1us;8us;1us;9us;1us;10us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;9us;11us;13us;15us;17us;22us;24us;29us;31us;36us;38us;40us;42us;47us;49us;51us;53us;55us;60us;62us;67us;69us;74us;79us;84us;86us;88us;|]
let _fsyacc_action_rows = 30
let _fsyacc_actionTableElements = [|6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;0us;49152us;4us;32768us;0us;3us;6us;28us;7us;29us;8us;27us;0us;16385us;0us;16386us;0us;16387us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;4us;32768us;6us;28us;7us;29us;8us;27us;12us;8us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;4us;32768us;6us;28us;7us;29us;8us;27us;13us;10us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;3us;16388us;6us;28us;7us;29us;8us;27us;1us;32768us;15us;13us;0us;16389us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;4us;32768us;2us;16us;6us;28us;7us;29us;8us;27us;0us;16390us;1us;32768us;14us;18us;1us;32768us;10us;19us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;4us;32768us;4us;21us;6us;28us;7us;29us;8us;27us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;4us;32768us;3us;23us;6us;28us;7us;29us;8us;27us;0us;16391us;3us;16392us;6us;28us;7us;29us;8us;27us;3us;16393us;6us;28us;7us;29us;8us;27us;3us;16394us;6us;28us;7us;29us;8us;27us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;6us;32768us;1us;14us;5us;17us;7us;12us;11us;6us;14us;4us;15us;5us;|]
let _fsyacc_actionTableRowOffsets = [|0us;7us;8us;13us;14us;15us;16us;23us;28us;35us;40us;47us;51us;53us;54us;61us;66us;67us;69us;71us;78us;83us;90us;95us;96us;100us;104us;108us;115us;122us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;1us;6us;2us;3us;7us;3us;3us;3us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;16386us;16387us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16389us;65535us;65535us;16390us;65535us;65535us;65535us;65535us;65535us;65535us;16391us;65535us;65535us;65535us;65535us;65535us;65535us;|]
let _fsyacc_reductions = lazy [|
# 171 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 180 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 24 "ExprPar.fsy"
                                                               _1                
                   )
# 24 "ExprPar.fsy"
                 : Absyn.expr));
# 191 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "ExprPar.fsy"
                                                               Var _1            
                   )
# 28 "ExprPar.fsy"
                 : 'gentype_Expr));
# 202 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 29 "ExprPar.fsy"
                                                               CstI _1           
                   )
# 29 "ExprPar.fsy"
                 : 'gentype_Expr));
# 213 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Expr in
            let _4 = parseState.GetInput(4) :?> 'gentype_Expr in
            let _6 = parseState.GetInput(6) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 30 "ExprPar.fsy"
                                                               If(_2, _4, _6)    
                   )
# 30 "ExprPar.fsy"
                 : 'gentype_Expr));
# 226 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "ExprPar.fsy"
                                                               CstI (- _2)       
                   )
# 31 "ExprPar.fsy"
                 : 'gentype_Expr));
# 237 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "ExprPar.fsy"
                                                               _2                
                   )
# 32 "ExprPar.fsy"
                 : 'gentype_Expr));
# 248 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> 'gentype_Expr in
            let _6 = parseState.GetInput(6) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "ExprPar.fsy"
                                                               Let(_2, _4, _6)   
                   )
# 33 "ExprPar.fsy"
                 : 'gentype_Expr));
# 261 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "ExprPar.fsy"
                                                               Prim("*", _1, _3) 
                   )
# 34 "ExprPar.fsy"
                 : 'gentype_Expr));
# 273 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "ExprPar.fsy"
                                                               Prim("+", _1, _3) 
                   )
# 35 "ExprPar.fsy"
                 : 'gentype_Expr));
# 285 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "ExprPar.fsy"
                                                               Prim("-", _1, _3) 
                   )
# 36 "ExprPar.fsy"
                 : 'gentype_Expr));
|]
# 298 "ExprPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 19;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _
