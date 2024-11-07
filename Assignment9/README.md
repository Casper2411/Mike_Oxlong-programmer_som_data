Compiling and loading the list-C evaluator and parser (file ListC/README)
-------------------------------------------------------------------------

Archive listc.zip contains the files used below.

Building the list-C command line compiler listcc:
```bash
fslex --unicode CLex.fsl &&
fsyacc --module CPar CPar.fsy &&
fsharpc -r  ./FsLexYacc/FsLexYacc.Runtime.dll \
    Absyn.fs    \
    CPar.fs     \
    CLex.fs     \
    Parse.fs    \
    Machine.fs  \
    Comp.fs     \
    ListCC.fs   \
    -o listcc.exe
```

Using the list-C command line compiler to compile program ex30.lc
to listmachine code (in file ex30.out):
```bash
listcc.exe ./LCProgs/ex30.lc
```
or
```bash
mono listcc.exe ./LCProgs/ex30.lc   
```
Compiling the list machine, and using it to execute the code in ex30.out:

```bash
gcc -Wall listmachine.c -o listmachine
```
or, if necessary, force gcc to use 32 bit integers:
```bash
gcc -m32 -Wall listmachine.c -o listmachine
```
```bash
./listmachine ./LCProgs/ex30.out 8
```
       

