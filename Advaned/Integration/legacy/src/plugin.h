

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Tue Apr 24 09:25:10 2012
 */
/* Compiler settings for src\appplugin.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __plugin_h__
#define __plugin_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IHandleInput_FWD_DEFINED__
#define __IHandleInput_FWD_DEFINED__
typedef interface IHandleInput IHandleInput;
#endif 	/* __IHandleInput_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __AppPlugin_LIBRARY_DEFINED__
#define __AppPlugin_LIBRARY_DEFINED__

/* library AppPlugin */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_AppPlugin;

#ifndef __IHandleInput_INTERFACE_DEFINED__
#define __IHandleInput_INTERFACE_DEFINED__

/* interface IHandleInput */
/* [oleautomation][object][uuid] */ 


EXTERN_C const IID IID_IHandleInput;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("89BCFE25-8C89-4F12-9D8F-2254144BA553")
    IHandleInput : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Action( 
            /* [in] */ BSTR input,
            /* [retval][out] */ LONG *result) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IHandleInputVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IHandleInput * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IHandleInput * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IHandleInput * This);
        
        HRESULT ( STDMETHODCALLTYPE *Action )( 
            IHandleInput * This,
            /* [in] */ BSTR input,
            /* [retval][out] */ LONG *result);
        
        END_INTERFACE
    } IHandleInputVtbl;

    interface IHandleInput
    {
        CONST_VTBL struct IHandleInputVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IHandleInput_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IHandleInput_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IHandleInput_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IHandleInput_Action(This,input,result)	\
    ( (This)->lpVtbl -> Action(This,input,result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IHandleInput_INTERFACE_DEFINED__ */

#endif /* __AppPlugin_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


