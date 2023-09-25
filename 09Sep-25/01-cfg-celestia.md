## What is a CFG file?

A Celestia configuration file is a plain text file used by Celestia, a 3D universe simulation program. These files are vital for customizing how Celestia behaves, what celestial objects are displayed, and how the program appears. However, editing these files requires careful attention because improper changes can disrupt Celestia's loading process, preventing it from running correctly.

## Celestia

Celestia is a free, open-source 3D astronomy simulation software that allows users to explore and visualize the universe in a highly realistic and interactive manner. It was developed by Chris Laurel and was first released in the early 2000s. Celestia is available for Windows, macOS, and Linux operating systems.

Key features and aspects of Celestia include:

- **Realistic 3D Visualization:** Celestia provides a detailed and accurate representation of our solar system, as well as stars, galaxies, and other celestial objects. It uses high-quality 3D models and textures to create a visually immersive experience.

- **Extensive Celestial Database:** The software comes with a vast built-in database of known celestial objects, including stars, planets, moons, asteroids, comets, and spacecraft. Users can easily locate and explore these objects.

- **Scientific Accuracy:** While Celestia is a visualization tool, it aims to represent celestial objects and phenomena as accurately as possible, based on available scientific data.

## Celestia configuration file

Here is a basic overview of what you can do with a Celestia configuration file:

1. **Setting Your Location**: You can specify your location on Earth using latitude, longitude, and altitude parameters. This allows Celestia to accurately display the night sky from your position.

```
Location "My Location"
{
    Latitude 40.7128
    Longitude -74.0060
    Altitude 0
}
```

2. **Customizing Your Viewing Options:** You can adjust various viewing options such as field of view, time settings, and rendering preferences.

```
Viewpoint
{
    Location "My Location"
    Follow "Earth"
    Eye [0.0 0.0 0.0]
    Center [0.0 0.0 0.0]
    Up [0.0 1.0 0.0]
    Fov 45
}

Time
{
    Date "2023-09-25T12:00:00.000Z"
    Clock "Now"
}

Rendering
{
    Atmosphere false
    Stars 7
    Planetshine 0.25
}

```

3. **Loading Celestial Objects:** You can add celestial objects such as stars, planets, asteroids, spacecraft, and more to your simulation. Each object is defined in the configuration file with its properties.

```
Star "Sun"
{
    RA 0
    Dec 0
    Distance 0
    AppMag -26.74
    SpectralType "G2V"
}

Planet "Earth"
{
    Parent "Sol"
    Texture "earth.jpg"
    Radius 6371
    EllipticalOrbit
    {
        Period 365.25
        SemiMajorAxis 149.6e6
        Eccentricity 0.017
        Inclination 0
        AscendingNode 0
        ArgOfPericenter 102.94
        MeanAnomaly 100.464
    }
}
```

4. **Defining Spaceships:** You can create your own fictional spacecraft or use real ones by specifying their parameters like position, orientation, and 3D models.

```
Spacecraft "Voyager 1"
{
    Parent "Sol"
    Class "spacecraft"
    Mesh "voyager.3ds"
    Radius 0.01
    EllipticalOrbit
    {
        Period 30700
        SemiMajorAxis 1.08e11
        Eccentricity 0.044
        Inclination 3.4
        AscendingNode 49.0
        ArgOfPericenter 44.0
        MeanAnomaly 35.0
    }
}
```
