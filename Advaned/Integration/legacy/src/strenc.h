#pragma once

__declspec(dllimport) long HashOfBuffer(const char* buf, int size);

__declspec(dllimport) int EncodeString(const char* src, int size, char* dst);

