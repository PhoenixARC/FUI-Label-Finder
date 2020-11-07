# FUI-Label-Finder
Minecraft .fui tool
So starting out, the FUI always contains this as it's 'magic', with a varying value in the middle, in this case it's `6B 34`:
```01 49 55 46 00 00 00 00 6B 34 00 00```
or in plaintext:
```.IUF....k4..```
following this is always the original filename, usually the same filename with .swf in place of .fui;
```01 49 55 46 00 00 00 00 6B 34 00 00 41 6E 76 69 6C 4D 65 6E 75 37 32 30 2E 73 77 66```
```.IUF....k4..AnvilMenu720.swf```
Then, at exactly `0x00000050` is what appears to be the start of another segment, which is unclear as to their purpose;
```0E 00 00 00 15 00 00 00 00 00 00 00 00 00 00 00```
At the end of every FUI is where References and uncompressed images are held, which appear in `.png` format and always start with the magic:
```89 50 4E 47```
```‰PNG```
but also always end in the same signature:
```49 45 4E 44 AE 42 60 82```
```IEND®B`‚```
this allows for images to be extracted or replaced with ease, since they are uncompressed and easily readable.
The references are spaced out between every 4 lines, which leaves 3 lines of buffer space between the start of one reference and the next, always read as .SWF in place of .FUI
as it stands, it appears that the name of the images inside the .fui, if not the default, will always be in reverse order going up from the images, so the first image you see going down will be the first label going up.

since the FUI seems to contain the original file name but also plaintext labels(check those out in FUI_JPEXS), it would appear that the data isn't encrypted, simply read differently, normal SWF files are/were encrypted using ZLIB compression, this level of compression obviously isn't there since the raw text isn't visible in encrypted SWFs, so my own theory is that the FUIs are a proprietary format made by decompressing the SWF and extracting it's resources, then proceeding to add them to the FUI without encryption
