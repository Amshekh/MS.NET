#pragma once

#ifdef _EXPORT
#define INVESTENTRY __declspec(dllexport) 
#else
#define INVESTENTRY __declspec(dllimport) 
#endif

typedef struct{
	long id;
	double amount;
	long period;
}FixedDeposit;

typedef float (__stdcall *Scheme)(double, long);

INVESTENTRY int __stdcall InitFixedDeposit(double, long, FixedDeposit*);

INVESTENTRY double __stdcall GetMaturityValue(FixedDeposit*, Scheme);











