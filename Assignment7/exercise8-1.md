# ex3.c
```fsharp
LDARGS; CALL (1, "L1"); STOP;                                                                   -> void main()
Label "L1"; 
    INCSP 1; GETBP; CSTI 1; ADD; CSTI 0; STI; INCSP -1; GOTO "L3";                              -> int i;i = 0;
Label "L2"; 
    GETBP; CSTI 1; ADD; LDI; PRINTI;                                                            -> print i;
    INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; -> i = i+1;
Label "L3"; 
    GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0          -> while (i < n)
```
# ex5.c
```fsharp
LDARGS; CALL (1, "L1"); STOP;                                                                                           -> void main(int n)
Label "L1"; 
    INCSP 1; GETBP; CSTI 1; ADD; GETBP; CSTI 0; ADD; LDI; STI;                                                          -> int r; r = n;
        INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI; GETBP; CSTI 2; ADD; 
            CALL (2, "L2");                                                                                             -> square(n, &r);
            INCSP -1; GETBP; CSTI 2; ADD; LDI; PRINTI;                                                                  -> print r;
    INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI;                                                                -> print r;
        INCSP -1; INCSP -1; RET 0; 
Label "L2";                                                                                                             -> square(int i, int *rp)
    GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0;             -> *rp = i * i;
    RET 1                                                                                                               -> implicit return
```
