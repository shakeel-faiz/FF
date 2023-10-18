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

## CDRWIN Cue Sheet

CDRWIN Cue Sheet is a specific variation of the ".cue" file format used by the CDRWIN software. CDRWIN is a CD/DVD burning and authoring software, and its ".cue" sheets are designed for use with this software. These ".cue" sheets contain information necessary for CDRWIN to accurately create or burn a CD or DVD.

Here are some key details specific to CDRWIN Cue Sheets:

1.  **Unique to CDRWIN**: CDRWIN's ".cue" sheets are a proprietary format specific to the CDRWIN software. While they share similarities with standard ".cue" files, they are tailored to work with CDRWIN's features and settings.
    
2.  **User-Friendly Interface**: CDRWIN provides an easy-to-use interface for creating and editing its ".cue" sheets. Users can add or modify the information about tracks, indexes, gaps, and other parameters in a user-friendly manner.
    
3.  **Compatible Disc Types**: CDRWIN Cue Sheets are used primarily for creating various types of CDs and DVDs, including data discs, audio CDs, mixed-mode discs, and more. The format allows users to specify the type and content of the disc they wish to create.
    
4.  **Control Over Disc Layout**: CDRWIN Cue Sheets provide detailed control over the layout and structure of the disc, including track order, pause/gap settings, and any other specific preferences the user may have.
    
5.  **ISO and BIN Support**: CDRWIN can work with both ISO and BIN disc image formats. The ".cue" sheet specifies which image file is used for the disc, ensuring proper synchronization between the cues and the image.
    
6.  **Burning and Ripping**: These ".cue" sheets are crucial when burning discs or ripping tracks from discs using CDRWIN. They help ensure that the final product matches the intended layout and content.
    
7.  **Backup and Restoration**: CDRWIN users often create ".cue" sheets when making backups of their CDs or DVDs. These sheets can later be used to restore the disc's content, including track layout and timing.

## How to open CUE file?

CDRWIN Cue Sheets are specifically designed for the CDRWIN software, so they are typically meant to be opened and used within CDRWIN.

Programs that open or reference CUE files

- CDRWIN
- Smart Projects IsoBuster
- EZB Systems UltraISO

## References
* [CDRWIN](https://en.wikipedia.org/wiki/CDRWIN)
