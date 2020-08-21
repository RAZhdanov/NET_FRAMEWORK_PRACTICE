
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.7.2558.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern /*23000001*/ mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly /*20000001*/ ConsoleApp1
{
  .custom /*0C000001:0A000001*/ instance void [mscorlib/*23000001*/]System.Runtime.CompilerServices.CompilationRelaxationsAttribute/*01000001*/::.ctor(int32) /* 0A000001 */ = ( 01 00 08 00 00 00 00 00 ) 
  .custom /*0C000002:0A000002*/ instance void [mscorlib/*23000001*/]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute/*01000002*/::.ctor() /* 0A000002 */ = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                                                                          63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom /*0C000003:0A000003*/ instance void [mscorlib/*23000001*/]System.Diagnostics.DebuggableAttribute/*01000003*/::.ctor(valuetype [mscorlib/*23000001*/]System.Diagnostics.DebuggableAttribute/*01000003*//DebuggingModes/*01000004*/) /* 0A000003 */ = ( 01 00 07 01 00 00 00 00 ) 

  .custom /*0C000004:0A000004*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyTitleAttribute/*01000005*/::.ctor(string) /* 0A000004 */ = ( 01 00 0B 43 6F 6E 73 6F 6C 65 41 70 70 31 00 00 ) // ...ConsoleApp1..
  .custom /*0C000005:0A000005*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyDescriptionAttribute/*01000006*/::.ctor(string) /* 0A000005 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000006:0A000006*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyConfigurationAttribute/*01000007*/::.ctor(string) /* 0A000006 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000007:0A000007*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyCompanyAttribute/*01000008*/::.ctor(string) /* 0A000007 */ = ( 01 00 00 00 00 ) 
  .custom /*0C000008:0A000008*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyProductAttribute/*01000009*/::.ctor(string) /* 0A000008 */ = ( 01 00 0B 43 6F 6E 73 6F 6C 65 41 70 70 31 00 00 ) // ...ConsoleApp1..
  .custom /*0C000009:0A000009*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyCopyrightAttribute/*0100000A*/::.ctor(string) /* 0A000009 */ = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                                                                               20 32 30 31 38 00 00 )                            //  2018..
  .custom /*0C00000A:0A00000A*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyTrademarkAttribute/*0100000B*/::.ctor(string) /* 0A00000A */ = ( 01 00 00 00 00 ) 
  .custom /*0C00000B:0A00000B*/ instance void [mscorlib/*23000001*/]System.Runtime.InteropServices.ComVisibleAttribute/*0100000C*/::.ctor(bool) /* 0A00000B */ = ( 01 00 00 00 00 ) 
  .custom /*0C00000C:0A00000C*/ instance void [mscorlib/*23000001*/]System.Runtime.InteropServices.GuidAttribute/*0100000D*/::.ctor(string) /* 0A00000C */ = ( 01 00 24 35 31 62 65 33 62 35 63 2D 63 37 32 38   // ..$51be3b5c-c728
                                                                                                                                                               2D 34 37 36 62 2D 38 36 65 33 2D 33 30 62 31 35   // -476b-86e3-30b15
                                                                                                                                                               66 39 35 38 64 34 66 00 00 )                      // f958d4f..
  .custom /*0C00000D:0A00000D*/ instance void [mscorlib/*23000001*/]System.Reflection.AssemblyFileVersionAttribute/*0100000E*/::.ctor(string) /* 0A00000D */ = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom /*0C00000E:0A00000E*/ instance void [mscorlib/*23000001*/]System.Runtime.Versioning.TargetFrameworkAttribute/*0100000F*/::.ctor(string) /* 0A00000E */ = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                                                                                     2C 56 65 72 73 69 6F 6E 3D 76 34 2E 36 2E 31 01   // ,Version=v4.6.1.
                                                                                                                                                                     00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                                                                                     70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                                                                                     61 6D 65 77 6F 72 6B 20 34 2E 36 2E 31 )          // amework 4.6.1
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module ConsoleApp1.exe
// MVID: {D76519A9-F900-4475-A624-2901300285F0}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x06A40000


// =============== CLASS MEMBERS DECLARATION ===================

.class /*02000002*/ private auto ansi beforefieldinit ConsoleApp1.Program
       extends [mscorlib/*23000001*/]System.Object/*01000010*/
{
  .method /*06000001*/ private hidebysig static 
          void  Main(string[] args) cil managed
  // SIG: 00 01 01 1D 0E
  {
    .entrypoint
    // Method begins at RVA 0x2050
    // Code size       19 (0x13)
    .maxstack  8
    .language '{3F5162F8-07C6-11D3-9053-00C04FA302A1}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
// Source File 'E:\Visual Studio\Projects\University\.NET Framework practice\Homework\DictionaryProject\ConsoleApp1\Program.cs' 
    .line 13,13 : 9,10 'E:\\Visual Studio\\Projects\\University\\.NET Framework practice\\Homework\\DictionaryProject\\ConsoleApp1\\Program.cs'
//000013:         {
    IL_0000:  /* 00   |                  */ nop
    .line 14,14 : 13,36 ''
//000014:             Console.WriteLine("1");
    IL_0001:  /* 72   | (70)000001       */ ldstr      "0" /* 70000001 */
    IL_0006:  /* 28   | (0A)00000F       */ call       void [mscorlib/*23000001*/]System.Console/*01000011*/::WriteLine(string) /* 0A00000F */
    IL_000b:  /* 00   |                  */ nop
    .line 15,15 : 13,31 ''
//000015:             Console.ReadKey();
    IL_000c:  /* 28   | (0A)000010       */ call       valuetype [mscorlib/*23000001*/]System.ConsoleKeyInfo/*01000012*/ [mscorlib/*23000001*/]System.Console/*01000011*/::ReadKey() /* 0A000010 */
    IL_0011:  /* 26   |                  */ pop
    .line 16,16 : 9,10 ''
//000016:         }
    IL_0012:  /* 2A   |                  */ ret
  } // end of method Program::Main

  .method /*06000002*/ public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x2064
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  /* 02   |                  */ ldarg.0
    IL_0001:  /* 28   | (0A)000011       */ call       instance void [mscorlib/*23000001*/]System.Object/*01000010*/::.ctor() /* 0A000011 */
    IL_0006:  /* 00   |                  */ nop
    IL_0007:  /* 2A   |                  */ ret
  } // end of method Program::.ctor

} // end of class ConsoleApp1.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file E:\Visual Studio\Projects\University\.NET Framework practice\Homework\DictionaryProject\ConsoleApp1\bin\Debug\Crack\ConsoleApp1.res
