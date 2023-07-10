@echo off


ml /nologo /c src\box4c.asm > nul
lib /nologo  /out:box.lib box4c.obj
del box4c.obj

cl /nologo /LD src\strenc.c > nul
del strenc.lib strenc.obj strenc.exp

cl /nologo /LD src\invest.c > nul
del invest.lib invest.obj invest.exp

midl /nologo src\quadeq.idl > nul 2> nul
rc  src\quadeq.rc > nul
cl /nologo /LD src\quadeq.cpp quadeq_i.c src\comexp.def src\quadeq.RES > nul
del quadeq.obj quadeq_i.obj quadeq_i.c quadeq_p.c quadeq.h dlldata.c
del  src\quadeq.RES quadeq.lib quadeq.tlb quadeq.exp
rundll32 quadeq.dll,DllRegisterServer

midl /nologo /h src\plugin.h src\appplugin.idl > nul 2> nul
cl /nologo /EHsc src\pluginapp.cpp > nul
del pluginapp.obj appplugin_i.c


