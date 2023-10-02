## What is a CS file?

A .CS file in the context of CLEO (short for CLEO Library) typically refers to a custom script file used in the Grand Theft Auto (GTA) series of video games. CLEO is a popular modding framework that allows players to create and add custom scripts to GTA games, enabling them to modify gameplay, add new features, and enhance the overall gaming experience.

## Overview of CS file

Here is a basic overview of what a .cs file in CLEO might contain:

1.  **Script Code**: A .cs file contains script code written in the CLEO scripting language. This scripting language is specific to CLEO and is used to define the behavior of custom scripts within the game. The code can be written using a text editor, and it typically follows a specific syntax.
    
2.  **Modifications**: CLEO scripts can make various modifications to the game, such as changing the behavior of in-game objects, creating custom missions, adding new vehicles, weapons, and more. The possibilities are extensive and depend on the creativity and programming skills of the script author.
    
3.  **Triggers**: CLEO scripts often include triggers that determine when and how the custom script should run. These triggers can be based on in-game events, player actions, or specific conditions.
    
4.  **Variables and Functions**: CLEO scripts can use variables to store and manipulate data, as well as functions to encapsulate and reuse code. These variables and functions are used to control the behavior of the script.

## Example of CS file

Here is a simple example of a CLEO .cs script that changes the weather in the game:

```
{$CLEO .cs}

03A4: name_thread 'WEATHER'

:WEATHER_LOOP
    // Change the weather to sunny
    0085: 0@ = 11 // Weather ID for sunny weather
    00D8: mission_cleanup
    0051: return 0@ // Exit the script

// Add more code and conditions as needed
```

## CLEO Library

The **CLEO Library**, often referred to simply as "CLEO," is a popular and powerful modding framework for the Grand Theft Auto (GTA) series of video games. It allows players and modders to create and add custom scripts to GTA games, enabling them to modify gameplay, add new features, and enhance the overall gaming experience. CLEO is particularly well-known for its flexibility and ease of use in the GTA modding community.

Here are some key features and aspects of the CLEO Library:

1.  **Scripting Language**: CLEO introduces its scripting language, which is specific to the modding framework. The scripting language is designed to be relatively easy to understand and work with, making it accessible to both novice and experienced modders.
    
2.  **Custom Scripts**: With CLEO, you can create custom scripts that can perform a wide range of functions within the game world. These scripts can change in-game behavior, add new missions, introduce new vehicles or weapons, alter game physics, and much more.
    
3.  **Triggers and Events**: CLEO scripts can be triggered by various in-game events, player actions, or specific conditions. This allows modders to create dynamic and interactive content within the game.
    
4.  **Support for Multiple GTA Versions**: CLEO has versions tailored to different GTA games, including GTA III, GTA Vice City, GTA San Andreas, GTA IV, and others. This means that modders can create and share their custom scripts for different GTA titles.

## How to open CS file?

To open and view the contents of a CLEO .cs (Custom Script) file, you can use a text editor or code editor of your choice. Common choices include:

-   **Notepad**: A simple text editor that comes pre-installed with Windows.
-   **Notepad++**: A more feature-rich text editor designed for coding and scripting.
-   **Visual Studio Code**: A popular, free, and highly extensible code editor.
-   **Sublime Text**: Another code editor known for its speed and versatility.
-   **Atom**: An open-source code editor developed by GitHub.

## References
* [CLEO library](https://cleo.li/)
