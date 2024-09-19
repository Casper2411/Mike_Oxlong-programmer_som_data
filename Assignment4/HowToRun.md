```bash
fslex --unicode FunLex.fsl && fsyacc --module FunPar FunPar.fsy && fsharpi -r /Users/albert/RiderProjects/ProgramsAsDataCodeE2024/fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs
```