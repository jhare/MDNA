/******************************************************************************
* Developer: Eddie Kotowski   
* Filename: Server.cpp
* Description: This program adds mapservers as layers.
*
*
******************************************************************************/

// Server.cpp : Implementation of CServer

#include "stdafx.h"
#include "Server.h"
 

// CServer
HRESULT CServer::check_fail(HRESULT hr)
{
	if(FAILED(hr))
	{
		MessageBox(0, "Unexpected Function Error!" , "Error!", MB_OK);
		return hr;
	}
}
	



//ICommand method definitions(Attributes for a button)
STDMETHODIMP CServer::get_Enabled(VARIANT_BOOL *Enabled)
{
	if(Enabled == NULL)
		return E_POINTER;

	*Enabled = VARIANT_TRUE;
	return S_OK;
}

STDMETHODIMP CServer::get_Checked(VARIANT_BOOL *Checked)
{
	return E_NOTIMPL;
}

STDMETHODIMP CServer::get_Name(BSTR *Name)
{
	if(Name == NULL)
		return E_POINTER;

	*Name = ::SysAllocString(L"Add Map Server");
	return S_OK;
}

STDMETHODIMP CServer::get_Caption(BSTR *Caption)
{
	if(Caption == NULL)
		return E_POINTER;

	*Caption = ::SysAllocString(L"Add Map Server as Layer");
	return S_OK;
}

STDMETHODIMP CServer::get_Tooltip(BSTR *Tooltip)
{
	if(Tooltip == NULL)
		return E_POINTER;

	*Tooltip = ::SysAllocString(L"Add Map Server");
	return S_OK;
}

STDMETHODIMP CServer::get_Message(BSTR *Message)
{
	return E_NOTIMPL;
}

STDMETHODIMP CServer::get_HelpFile(BSTR *HelpFile)
{
	return E_NOTIMPL;
}

STDMETHODIMP CServer::get_HelpContextID(long *helpID)
{
	return E_NOTIMPL;
}

STDMETHODIMP CServer::get_Bitmap(OLE_HANDLE *Bitmap)
{
	return E_NOTIMPL;
}

STDMETHODIMP CServer::get_Category(BSTR *categoryName)
{
	if(categoryName == NULL)
		return E_POINTER;

	*categoryName = ::SysAllocString(L"Add Map Server as Layer");
	return S_OK;
}

STDMETHODIMP CServer::OnCreate(IDispatch *hook)
{
	m_ipHookHelper.CreateInstance(CLSID_HookHelper);
	HRESULT hr = m_ipHookHelper->putref_Hook(hook);
	
	return hr;
}

STDMETHODIMP CServer::OnClick()
{
	/*
	Parser my_parse;
	my_parse.Loadfile("D:/Visual Studio Projects/Add Map Server/Test_XML.xml");
	my_parse.XML_Parse2();
	my_parse.URL_ArcIms();
	int max = my_parse.Get_Layer_Size();
	std::vector<BSTR> bIMS (max);
	std::vector<BSTR> bService (max);

	for(int i = 0; i < max; ++i)
	{
		bIMS[i] = A2BSTR(my_parse.Get_IMS(i).c_str());	//A2BSTR converts the C_String to a BSTR
		bService[i] = A2BSTR(my_parse.Get_MapService(i).c_str()); 
	}
*/
	HRESULT hr;
	IMapPtr ipMap;
	IActiveViewPtr ipActiveView;
	IAGSServerConnectionFactoryPtr ipAGSServerConnectionFactory;
	IPropertySet2Ptr ipProps;
	IAGSServerConnectionPtr ipAGSConnection;
	IAGSEnumServerObjectNamePtr ipEnumSOName;
	IAGSServerObjectNamePtr ipSOName;
	INamePtr ipName;
	IMapServerPtr ipMapServer;
	IMapServerLayerPtr ipMSLayer;
	IIMSConnectionPtr ipIMSConnection;
	IIMSMapLayerPtr ipIMSMapLayer;
	IWorkspaceFactoryPtr ipWorkspaceFactory;
	IWorkspacePtr ipWorkspace;
	IEnvelopePtr ipEnvelope;
	ISpatialReferencePtr ipSpatialReference;
   
	bool bFlag = true;
	int max = 1;
	
	//BSTR bIMS[] = {L"http://ims.cr.usgs.gov"};
	//BSTR bService[] = {L"USGS_EDC_Ortho_Urban"};
	BSTR bIMS[] = {L"http://datamil.delaware.gov"};
	BSTR bService[] = {L"datamil_tnm"};

	//Vector of Interfaces to allow mulitiple layers to be added
	std::vector<IIMSServiceDescriptionPtr> ipIMSService (max); 

	for(int i = 0; i < max; ++i)
	{
		bFlag = true;
		ipIMSService[i].CreateInstance(CLSID_IMSServiceName);
	    ipIMSMapLayer.CreateInstance(CLSID_IMSMapLayer);
		ipEnvelope.CreateInstance(CLSID_Envelope);
		ipSpatialReference.CreateInstance(CLSID_GeographicCoordinateSystem);
      
		//acMapService equals 0 which represents an ArcIMS image service
		hr = ipIMSService[i]->put_ServiceType(acMapService);
	    check_fail(hr);
      
		//URL of the IMS server
		hr = ipIMSService[i]->put_URL(bIMS[i]);
		check_fail(hr);
	
		//Name of the image service
		hr = ipIMSService[i]->put_Name(bService[i]);
		check_fail(hr);
		
		/*//Check if there is a duplicate service
		for(int j = 0; j < i; ++j)
		{
			if(my_parse.Get_IMS(i) == my_parse.Get_IMS(j) && my_parse.Get_MapService(i) == my_parse.Get_MapService(j))
			{
					bFlag = false;
					break;
			}
		}
		*/
		if(ipIMSService[i] != 0 && bFlag == true)
		{
		   //Connect to the IMS service
			hr = ipIMSMapLayer->ConnectToService(ipIMSService[i]);
		
			//ipLayer represents an ipIMSMapLayer
			ILayerPtr ipLayer(ipIMSMapLayer);

		   if(SUCCEEDED(hr))
  		   {
				hr = m_ipHookHelper->get_FocusMap(&ipMap);
				check_fail(hr);
				ipActiveView = ipMap;
				hr = ipMap->AddLayer(ipLayer);
				check_fail(hr);
				
				//This puts the coordinates into an Envelope to be able to Clip your map to the
				//designated size.
				hr = ipEnvelope->PutCoords(-75.734992, 38.915523, -75.38826, 39.195487);
				check_fail(hr);
				
				//This is where the actual Clipping of the layer happens
				hr = ipMap->put_ClipGeometry(ipEnvelope);
				check_fail(hr);
				
				ipActiveView->Refresh();
        	}

		//Clean up on each run through
		ipIMSService[i] = 0;
		}
	}

	//Final Clean up by Explicity calling Release()
	ipEnvelope = 0;
	ipActiveView = 0;
	ipMap = 0;
	ipIMSMapLayer = 0;
	
	return S_OK;
}