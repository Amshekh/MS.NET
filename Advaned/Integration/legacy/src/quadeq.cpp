#define _WIN32_WINNT 0x0400
#define UNICODE
#include "../quadeq.h"
#include <math.h>

#pragma comment(lib, "advapi32")
#pragma comment(lib, "ole32")

LONG g_nLockCount;
HINSTANCE g_hModule;

VOID LockModule()
{
	InterlockedIncrement(&g_nLockCount);
}

VOID UnlockModule()
{
	InterlockedDecrement(&g_nLockCount);
}

class QuadraticEquation : public IEquation
{
public:
	QuadraticEquation()
	{
		m_nRefCount = 1;
		LockModule();
	}

	// IUnknown Members

	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID* ppvObj)
	{
		if(riid == IID_IEquation || riid == IID_IUnknown)
			*ppvObj = static_cast<IEquation*>(this);
		else
			return *ppvObj = NULL, E_NOINTERFACE;

		AddRef();
		
		return S_OK;
	}

	ULONG __stdcall AddRef()
	{
		return ++m_nRefCount;
	}

	ULONG __stdcall Release()
	{
		if(--m_nRefCount == 0)
			return delete this, 0;
		return m_nRefCount;
	}

	// IEquation members

	HRESULT __stdcall HasRealRoots(double a, double b, double c, int* result)
	{
		*result = b * b < 4 * a * c ? 0 : 2;

		return S_OK;
	}

	HRESULT __stdcall Solve(double a, double b, double c, double* root1, double* root2)
	{
		double d = b * b - 4 * a * c;
	
		if(d < 0) return E_FAIL;

		*root1 = (-b + sqrt(d)) / (2 * a);
		*root2 = (-b - sqrt(d)) / (2 * a);

		return S_OK;
	}


	~QuadraticEquation()
	{
		UnlockModule();
	}	
private:
	LONG m_nRefCount;
};

class QuadraticEquationClassObject : public IClassFactory
{
public:
	QuadraticEquationClassObject()
	{
		m_nRefCount = 1;
		LockModule();
	}

	// IUnknown members

	HRESULT __stdcall QueryInterface(REFIID riid, LPVOID* ppvObj)
	{
		if(riid == IID_IClassFactory)
			*ppvObj = static_cast<IClassFactory*>(this);
		else if(riid == IID_IUnknown)
			*ppvObj = static_cast<IUnknown*>(this);
		else
			return *ppvObj = NULL, E_NOINTERFACE;

		AddRef();
		
		return S_OK;
	}

	ULONG __stdcall AddRef()
	{
		return ++m_nRefCount;
	}

	ULONG __stdcall Release()
	{
		if(--m_nRefCount == 0)
			return delete this, 0;
		return m_nRefCount;
	}

	// IClassFactory members

	HRESULT __stdcall CreateInstance(IUnknown* pUnkOuter, REFIID riid, LPVOID* ppvObj)
	{
		if(pUnkOuter)
			return CLASS_E_NOAGGREGATION;
		
		QuadraticEquation* pObject = new QuadraticEquation;
		HRESULT hr = pObject->QueryInterface(riid, ppvObj);
		
		pObject->Release();

		return hr;
	}

	HRESULT __stdcall LockServer(BOOL bLock)
	{
		bLock ? LockModule() : UnlockModule();

		return S_OK;
	}

	~QuadraticEquationClassObject()
	{
		UnlockModule();
	}
private:
	LONG m_nRefCount;
};

// Called by CoGetClassObject
HRESULT __stdcall DllGetClassObject(REFCLSID clsid, REFIID riid, LPVOID* ppvObj)
{
	if(clsid != CLSID_QuadraticEquation)
		return CLASS_E_CLASSNOTAVAILABLE;

	QuadraticEquationClassObject* pFactory = new QuadraticEquationClassObject;
	HRESULT hr = pFactory->QueryInterface(riid, ppvObj);

	pFactory->Release();

	return hr;
}

// Called by CoUninitialize
HRESULT __stdcall DllCanUnloadNow()
{
	return g_nLockCount ? S_FALSE : S_OK;
}

HRESULT __stdcall DllRegisterServer()
{
	WCHAR clsid[39];
	WCHAR path[MAX_PATH + 1];
	int n = GetModuleFileName(g_hModule, path, MAX_PATH + 1);
	HKEY hKey1, hKey2, hKey3;

	StringFromGUID2(CLSID_QuadraticEquation, clsid, 39);

	RegOpenKey(HKEY_CLASSES_ROOT, L"CLSID", &hKey1);
	RegCreateKey(hKey1, clsid, &hKey2);
	RegCreateKey(hKey2, L"InprocServer32", &hKey3);
	RegSetValueEx(hKey3, NULL, 0, REG_SZ, reinterpret_cast<LPBYTE>(path), 2 * (n + 1));
	RegSetValueEx(hKey3, L"ThreadingModel", 0, REG_SZ, reinterpret_cast<LPBYTE>(L"Apartment"), 20);

	RegCloseKey(hKey3);
	RegCloseKey(hKey2);
	RegCloseKey(hKey1);

	return S_OK;
}

HRESULT __stdcall DllUnregisterServer()
{
	WCHAR clsid[39];
	HKEY hKey1, hKey2;

	StringFromGUID2(CLSID_QuadraticEquation, clsid, 39);

	RegOpenKey(HKEY_CLASSES_ROOT, L"CLSID", &hKey1);
	RegOpenKey(hKey1, clsid, &hKey2);
	RegDeleteKey(hKey2, L"InprocServer32");
	RegCloseKey(hKey2);
	RegDeleteKey(hKey1, clsid);

	return S_OK;
}

BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	if(dwReason == DLL_PROCESS_ATTACH)
	{
		g_hModule = hInstance;
		DisableThreadLibraryCalls(hInstance);
	}
	
	return TRUE;
}













