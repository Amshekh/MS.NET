__declspec(dllexport) long HashOfBuffer(const char* buf, int size)
{
	long h = 0;
	int i;
	
	for(i = 0; i < size; i++)
		h = buf[i] + (h << 6) + (h << 16) - h;
	
	return h;
}

__declspec(dllexport) int EncodeString(const char* src, int size, char* dst)
{
	int i;
	
	for(i = 0; i < size; i++)
		dst[i] = src[i] ^ '#';
	
	return i; 
}
















