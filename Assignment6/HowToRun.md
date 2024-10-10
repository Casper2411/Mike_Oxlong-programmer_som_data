```bash
fslex  --unicode CLex.fsl && fsyacc --module CPar CPar.fsy && fsharpi -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ContComp.fs MicroCC.fs ParseAndComp.fs ParseAndContComp.fs Interp.fs ParseAndRun.fs 
```