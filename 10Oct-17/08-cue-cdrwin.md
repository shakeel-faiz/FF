## What is a CUE file?

A **.CUE** file, also known as a **CDRWIN Cue Sheet**, is a plain text file that contains information about the tracks and layout of an audio CD or a disc image, typically in the BIN or ISO format. These files are often used to describe the structure and contents of a disc, allowing CD burning software or virtual drive software to accurately reproduce the original disc.

## Example of CUE file

Here is an example of what a ".cue" file might look like:

```
PERFORMER "Artist Name"
TITLE "Album Title"
FILE "DiscImage.bin" BINARY
  TRACK 01 AUDIO
    TITLE "Track 1 Title"
    PERFORMER "Artist Name"
    INDEX 01 00:00:00
  TRACK 02 AUDIO
    TITLE "Track 2 Title"
    PERFORMER "Artist Name"
    INDEX 01 03:45:21
  TRACK 03 AUDIO
    TITLE "Track 3 Title"
    PERFORMER "Artist Name"
    INDEX 01 07:28:17
  TRACK 04 AUDIO
    TITLE "Track 4 Title"
    PERFORMER "Artist Name"
    INDEX 01 12:15:40
  (Additional tracks go here...)
```
