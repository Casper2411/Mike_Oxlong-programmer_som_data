```bash
fslex  --unicode CLex.fsl && fsyacc --module CPar CPar.fsy && fsharpi -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs MicroCC.fs ParseAndComp.fs ParseAndContComp.fs ParseAndRun.fs 
```