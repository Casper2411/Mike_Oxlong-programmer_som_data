```bash
fslex  --unicode CLex.fsl && fsyacc --module CPar CPar.fsy && fsharpi -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ContComp.fs MicroCC.fs ParseAndComp.fs ParseAndContComp.fs Interp.fs ParseAndRun.fs
```

Casper's alernative that works for him:
(uses .NET Core SDK, instead of relying on mono)

```bash
fslex  --unicode CLex.fsl && fsyacc --module CPar CPar.fsy && dotnet fsi -r ./FsLexYacc/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ContComp.fs MicroCC.fs ParseAndComp.fs ParseAndContComp.fs Interp.fs ParseAndRun.fs
```
