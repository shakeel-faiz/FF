# How to create OGG file using FFmpeg?

In this blog, we will show you how to create an OGG file using FFmpeg. The commands shared in this blog will give you an idea of how to convert any audio file into OGG.

## What is OGG?

OGG is an open-source audio file format that uses efficient compression to deliver high-quality sound with smaller file sizes. It is often paired with Vorbis compression to provide better audio quality than MP3 at similar sizes. OGG is free to use without licensing restrictions.

## What is FFmpeg?

FFmpeg is a free, open-source software that handles multimedia files, allowing users to convert, record, and stream audio and video. It supports a wide range of formats, including MP4, AVI, and MP3. FFmpeg is commonly used for tasks like video conversion and editing.

## How to convert Audio to OGG file format using FFmpeg?

1. **Install FFmpeg.**

**Windows**: Download the FFmpeg Windows version from FFmpeg.org and follow the instructions to set it up.

**macOS**: Install FFmpeg using Homebrew by running:

```
brew install ffmpeg
```

**Linux**: Most Linux distributions support FFmpeg. Install it using:

```
sudo apt install ffmpeg
```

2. **Run the Conversion Command.** This way, you can create OGG file from any Audio.

Once FFmpeg is installed, open your terminal (or command prompt) and navigate to the directory containing the audio file you want to convert. Use the following command to create an OGG file:

```
ffmpeg -i inputfile.mp3 outputfile.ogg
```

-   **inputfile.mp3**: Replace this with the name of the file you want to convert. FFmpeg accepts many file formats, so you could use an MP3, WAV, or even a video file.
-   **outputfile.ogg**: Replace this with the desired name of your new OGG file.

**Example**

If you have a file named `song.mp3` that you want to convert to `song.ogg`, the command would look like this:

```
ffmpeg -i song.mp3 song.ogg
```

2. **Adjust the Audio Bitrate.** This is optional.

If you want to control the quality of the output OGG file, you can specify a bitrate. Bitrate refers to the amount of data encoded per second of audio and affects both file size and sound quality. A higher bitrate results in better sound but larger files.

For example, to set the audio bitrate to 192 kbps, use this command:

```
ffmpeg -i inputfile.mp3 -b:a 192k outputfile.ogg
```

## Conclusion

By using the commands given in this blog, you can convert any audio file into an OGG file. We hope you find this article helpful and that it meets your expectations.

