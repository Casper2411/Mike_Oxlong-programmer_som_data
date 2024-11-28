Compiling and loading the micro-SML compiler (MicroSML/README.TXT)
------------------------------------------------------------------

A. Building the micro-SML command line compiler microsmlc:
```bash
fslex --unicode FunLex.fsl && \
  fsyacc --module FunPar FunPar.fsy && \
  dotnet build Assignment12.fsproj
```

Compiling the test program test01.sml:
```bash
dotnet run ./MicroSml/test01.sml
```
Compiling the test program with tail call and other optimizations:
```bash
dotnet run -opt ./MicroSml/test01.sml
```
Compiling AND evaluating the program with the evaluator in
HigherFun.fs:
```bash
dotnet run -eval ./MicroSml/test01.sml
```

Compiling AND output intermediate AST's
```bash
dotnet run -verbose ./MicroSml/test01.sml
```

The command line parameters can be combined.

C. Building the virtual machine

  The virtual machine is in the Visual Studio Project MsmlVM.

  On Unix / Mac:
  Go to directory MsmlVM/src where you find the C file msmlmachine.c
    
```bash
gcc -Wall msmlmachine.c -o msmlmachine
```

  On Windows:
    You can use the Visual Studio 2019 solution MsmlVM.sln and
    compile for 32 or 64 bit.

Running the compiled test program on Mac:

```bash
./MsmlVM/src/msmlmachine ./MicroSml/test01.out
```

The command line parameter -trace will write trace information on
stdout. The parameter -silent will supress garbage collection output
etc.

D. To replace the continuation based compiler with the simpler forward
compiler, simply replace Contcomp.fs with Comp.fs in the
microsmlc.fsproj file.
