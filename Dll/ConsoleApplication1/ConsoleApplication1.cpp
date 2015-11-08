// ConsoleApplication1.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"

void init() {
MessageBox(NULL,L"Your System 0wn3d BY anT!-Tr0J4n", L"anT!-Tr0J4n",0x00000003);
}
 
BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		 init();break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}
