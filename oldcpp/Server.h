// Server.h : Declaration of the CServer

#pragma once
#include "resource.h"       // main symbols

// IServer
[
	object,
	uuid("BF9726C2-6D09-4858-812D-63FBBE18CC5B"),
	dual,	helpstring("IServer Interface"),
	pointer_default(unique)
]
__interface IServer : IDispatch
{
};



// CServer

[
	coclass,
	threading("apartment"),
	vi_progid("AddMapServer.Server"),
	progid("AddMapServer.Server.1"),
	version(1.0),
	uuid("BA904655-62A4-46AE-BDA0-3325765E78A5"),
	helpstring("Server Class")
]
class ATL_NO_VTABLE CServer : 
	public IServer,							//Where CServer inherits the IServer and ICommand interfaces
	public ICommand
{
public:
	CServer()
	{
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease() 
	{
	}

public:
	inline HRESULT check_fail(HRESULT hr);

	// ICommand Methods
public:
	STDMETHOD(get_Enabled)(VARIANT_BOOL * Enabled);

	STDMETHOD(get_Checked)(VARIANT_BOOL * Checked);
	
	STDMETHOD(get_Name)(BSTR * Name);
	
	STDMETHOD(get_Caption)(BSTR * Caption);

	STDMETHOD(get_Tooltip)(BSTR * Tooltip);

	STDMETHOD(get_Message)(BSTR * Message);

	STDMETHOD(get_HelpFile)(BSTR * HelpFile);

	STDMETHOD(get_HelpContextID)(long * helpID);

	STDMETHOD(get_Bitmap)(OLE_HANDLE * Bitmap);

	STDMETHOD(get_Category)(BSTR * categoryName);
	
	STDMETHOD(OnCreate)(LPDISPATCH hook);

	STDMETHOD(OnClick)();


private:
	IHookHelperPtr m_ipHookHelper;		//Acts as the hook between .net and ArcMap
};

