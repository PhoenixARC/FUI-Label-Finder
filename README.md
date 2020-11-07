# FUI-Label-Finder
Minecraft .fui tool
So starting out, the FUI always contains this as it's 'magic', with a varying value in the middle, in this case it's `6B 34`:<br />
```01 49 55 46 00 00 00 00 6B 34 00 00```<br />
or in plaintext:<br />
```.IUF....k4..```<br />
following this is always the original filename, usually the same filename with .swf in place of .fui;<br />
```01 49 55 46 00 00 00 00 6B 34 00 00 41 6E 76 69 6C 4D 65 6E 75 37 32 30 2E 73 77 66```<br />
```.IUF....k4..AnvilMenu720.swf```<br />
Then, at exactly `0x00000050` is what appears to be the start of another segment, which is unclear as to their purpose;<br />
```0E 00 00 00 15 00 00 00 00 00 00 00 00 00 00 00```<br />
At the end of every FUI is where References and uncompressed images are held, which appear in `.png` format and always start with the magic:<br />
```89 50 4E 47```<br />
```‰PNG```<br />
but also always end in the same signature:<br />
```49 45 4E 44 AE 42 60 82```<br />
```IEND®B`‚```<br />
this allows for images to be extracted or replaced with ease, since they are uncompressed and easily readable.<br />
The references are spaced out between every 4 lines, which leaves 3 lines of buffer space between the start of one reference and the next, always read as .SWF in place of .FUI<br />
as it stands, it appears that the name of the images inside the .fui, if not the default, will always be in reverse order going up from the images, so the first image you see<br /> going down will be the first label going up.<br />

since the FUI seems to contain the original file name but also plaintext labels(check those out in FUI_JPEXS), it would appear that the data isn't encrypted, simply read <br />differently, normal SWF files are/were encrypted using ZLIB compression, this level of compression obviously isn't there since the raw text isn't visible in encrypted SWFs, so<br /> my own theory is that the FUIs are a proprietary format made by decompressing the SWF and extracting it's resources, then proceeding to add them to the FUI without encryption<br />
