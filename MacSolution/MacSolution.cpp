#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#include <stdio.h>
#include <tchar.h>
#include <Windows.h>
#include <Iphlpapi.h>
#include <Assert.h>
#pragma comment(lib, "iphlpapi.lib")

// Prints the MAC address stored in a 6 byte array to stdout
static void PrintMACaddress(unsigned char MACData[])
{
    printf("MAC Address: %02X-%02X-%02X-%02X-%02X-%02X\n",
        MACData[0], MACData[1], MACData[2], MACData[3], MACData[4], MACData[5]);
}

// Fetches the MAC address and prints it
static void GetMACaddress(void)
{
    IP_ADAPTER_INFO AdapterInfo[16];			// Allocate information for up to 16 NICs
    DWORD dwBufLen = sizeof(AdapterInfo);		// Save the memory size of buffer

    DWORD dwStatus = GetAdaptersInfo(			// Call GetAdapterInfo
        AdapterInfo,							// [out] buffer to receive data
        &dwBufLen);								// [in] size of receive data buffer
    assert(dwStatus == ERROR_SUCCESS);			// Verify return value is valid, no buffer overflow

    PIP_ADAPTER_INFO pAdapterInfo = AdapterInfo;// Contains pointer to current adapter info
    do {
        PrintMACaddress(pAdapterInfo->Address);	// Print MAC address
        pAdapterInfo = pAdapterInfo->Next;		// Progress through linked list
    } while (pAdapterInfo);						// Terminate if last adapter
}


int main(int argc, char* argv[])
{
    GetMACaddress();							

    return 0;
}
