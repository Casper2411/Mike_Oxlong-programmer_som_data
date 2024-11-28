Compiling and loading the micro-SML compiler (MicroSML/README.TXT)
------------------------------------------------------------------

Archive microsml.zip contains the files used below

A. Building the micro-SML command line compiler microsmlc:
```bash
fslex --unicode FunLex.fsl && \
  fsyacc --module FunPar FunPar.fsy && \
  fsharpc -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs TypeInference.fs HigherFun.fs Machine.fs Contcomp.fs ParseTypeAndRun.fs MicroSMLC.fs -o microsmlc.exe
```
   
Compiling the test program test.sml:
```bash
microsmlc.exe test.sml
```
Compiling the test program with tail call and other optimizations:
```bash
microsmlc.exe -opt test.sml
```
Compiling AND evaluating the program with the evaluator in HigherFun.fs:
```bash
microsmlc.exe -eval test.sml
```
Compiling AND output intermediate AST's
```bash
microsmlc.exe -verbose test.sml
```
The command line parameters can be combined.


B. Building the virtual machine
```bash
gcc -m32 -Wall msmlmachine.c -o msmlmachine
```

Running the compiled test program:
```bash
./msmlmachine test.out
```
The command line parameter -trace will write trace information on stdout.  The parameter -silent will suppress garbage collection output etc.

C. To replace the continuation based compiler with the simpler forward
   compiler, simply replace Contcomp.fs with Comp.fs above.
