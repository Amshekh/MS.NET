.386
.model flat

.code

_BoxVolume	proc	public

	push	ebp
	mov	ebp, esp
	
	push	ebx
	mov	ebx, [ebp+20]
	add	ebx, ebx
	mov	eax, [ebp+8]
	sub	eax, ebx
	mov	edx, [ebp+12]
	sub	edx, ebx
	mul	edx
	mov	ecx, [ebp+16]
	sub	ecx, ebx
	mul	ecx
	pop	ebx

	leave
	ret

_BoxVolume	endp

_BoxVolume@16	proc	public

	push	ebp
	mov	ebp, esp
	
	push	ebx
	mov	ebx, [ebp+20]
	add	ebx, ebx
	mov	eax, [ebp+8]
	sub	eax, ebx
	mov	edx, [ebp+12]
	sub	edx, ebx
	mul	edx
	mov	ecx, [ebp+16]
	sub	ecx, ebx
	mul	ecx
	pop	ebx

	leave
	ret	16

_BoxVolume@16	endp

@BoxVolume@16	proc	public

	push	ebp
	mov	ebp, esp
	
	push	ebx
	mov	ebx, [ebp+12]
	add	ebx, ebx
	mov	eax, [ebp+8]
	sub	eax, ebx
	sub	edx, ebx
	mul	edx
	sub	ecx, ebx
	mul	ecx
	pop	ebx

	leave
	ret	8

@BoxVolume@16	endp

end

















