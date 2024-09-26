```bash
fslex  --unicode FunLex.fsl && fsyacc --module FunPar FunPar.fsy && fsharpi -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs Util.fs FunPar.fs FunLex.fs HigherFun.fs TypeInference.fs Parse.fs Fun.fs ParseAndRun.fs ParseAndRunHigher.fs ParseAndType.fs 
```