#define UNICODE
#define _WIN32_WINNT 0x0400
#include "plugin.h"
#include <string>
#include <iostream>
#pragma comment(lib, "ole32")
#pragma comment(lib, "oleaut32")

using namespace std;

wstring DeviceInput(VOID)
{
	wstring text;

	wcout << L"INPUT: ";
	getline(wcin, text);

	return text;
}

LONG ProcessInput(const CLSID& clsidPlugin, const wstring& strText)
{
	LONG status = 0;

	CoInitialize(NULL);
	
	IHandleInput* pHandler = NULL;
	HRESULT hr = CoCreateInstance(clsidPlugin, NULL, CLSCTX_INPROC_SERVER, __uuidof(IHandleInput), reinterpret_cast<LPVOID*>(&pHandler));
	if(SUCCEEDED(hr))
	{
		BSTR bstrInput = SysAllocString(strText.c_str());
		
		hr = pHandler->Action(bstrInput, &status);
		if(FAILED(hr)) status = hr;		
		
		SysFreeString(bstrInput);
		pHandler->Release();
	}
	else
		status = -1;

	CoUninitialize();

	return status;
}

VOID DeviceOutput(LONG status)
{
	wcout << L"OUTPUT: " << status << endl;
}


int wmain(int argc, WCHAR* argv[])
{
	if(argc < 2)
		return wcout << L"USAGE: " << argv[0] << L" Plugin-Name" << endl, 0;

	CLSID clsid;
	if(FAILED(CLSIDFromProgID(argv[1], &clsid)))
		return wcout << L"ERROR: Invalid Plugin-Name" << endl, -1;


	wstring text = DeviceInput();
	LONG status = ProcessInput(clsid, text);
	DeviceOutput(status);

}

/*
midl /h plugin.h appplugin.idl
cl /EHsc pluginapp.cpp
*/
