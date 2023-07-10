#define _EXPORT
#include "invest.h"
#include <time.h>
#include <math.h>


int __stdcall InitFixedDeposit(double amount, long period, FixedDeposit* fd)
{
	static int nxtid;
	
	if(nxtid == 0) nxtid = time(0) % 1000000;
	
	fd->id = nxtid++;
	fd->amount = amount;
	fd->period = period;
	
	return 1;
}

double __stdcall GetMaturityValue(FixedDeposit* fd, Scheme policy)
{
	float r = policy ? policy(fd->amount, fd->period) : 8.0f;
	
	return fd->amount * pow(1 + r / 100, fd->period);
}


















