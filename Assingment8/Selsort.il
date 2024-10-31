.class private auto ansi beforefieldinit Selsort
       extends [mscorlib]System.Object
{

  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,                // i
             int32 V_1,                     // least
             int32 V_2,                     // j
             int32 V_3)                     // tmp
    IL_0000:  ldc.i4.0                      // 0
    IL_0001:  stloc.0                       // i = 0
    IL_0002:  br.s       IL_0032            // goto IL_0032

    IL_0004:  ldloc.0                       // i
    IL_0005:  stloc.1                       // least = i   
    IL_0006:  ldloc.0                       // i
    IL_0007:  ldc.i4.1                      // 1
    IL_0008:  add                           // i+1
    IL_0009:  stloc.2                       // j = i+1
    IL_000a:  br.s       IL_001a            // goto IL_001a 

    IL_000c:  ldarg.0                       // arr
    IL_000d:  ldloc.2                       // j
    IL_000e:  ldelem.i4                     // arr[j]
    IL_000f:  ldarg.0                       // arr
    IL_0010:  ldloc.1                       // least
    IL_0011:  ldelem.i4                     // arr[least]
    IL_0012:  bge.s      IL_0016            // if arr[j] > arr[least] goto IL_0016

    IL_0014:  ldloc.2                       // j
    IL_0015:  stloc.1                       // least = j
    IL_0016:  ldloc.2                       // j
    IL_0017:  ldc.i4.1                      // 1
    IL_0018:  add                           // j+1
    IL_0019:  stloc.2                       // j = j+1
    IL_001a:  ldloc.2                       // j
    IL_001b:  ldarg.0                       // arr
    IL_001c:  ldlen                         // arr.Length
    IL_001d:  conv.i4                       // cast len to i32
    IL_001e:  blt.s      IL_000c            // if j < arr.Length goto IL_000c

    IL_0020:  ldarg.0                       // arr
    IL_0021:  ldloc.0                       // i
    IL_0022:  ldelem.i4                     // arr[i] 
    IL_0023:  stloc.3                       // tmp = arr[i]
    IL_0024:  ldarg.0                       // arr
    IL_0025:  ldloc.0                       // i
    IL_0026:  ldarg.0                       // arr
    IL_0027:  ldloc.1                       // least
    IL_0028:  ldelem.i4                     // arr[least]
    IL_0029:  stelem.i4                     // arr[i] = arr[least]
    IL_002a:  ldarg.0                       // arr
    IL_002b:  ldloc.1                       // least
    IL_002c:  ldloc.3                       // tmp
    IL_002d:  stelem.i4                     // arr[least] = tmp
    IL_002e:  ldloc.0                       // i
    IL_002f:  ldc.i4.1                      // 1
    IL_0030:  add                           // i + 1
    IL_0031:  stloc.0                       // i = i + 1
    IL_0032:  ldloc.0                       // load i
    IL_0033:  ldarg.0                       // load arr
    IL_0034:  ldlen                         // arr.Length
    IL_0035:  conv.i4                       // cast len
    IL_0036:  blt.s      IL_0004            //  if i < len goto IL_0004

    IL_0038:  ret
  } // end of method Selsort::SelectionSort
} // end of class Selsort


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
