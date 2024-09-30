### What is an SVS file?

An **SVS file** (Slide and Viewable Storage) is a digital slide image file commonly created by **Aperio ScanScope** slide scanners. Designed for the medical and research fields, SVS files store a series of **TIFF images** that represent various views of a specimen slide.

Key characteristics of SVS files include:

1.  **Multi-Resolution Storage**: SVS files contain multiple images at different resolutions. This structure allows for efficient viewing, enabling users to zoom in on high-resolution details or navigate using lower-resolution images.
    
2.  **Baseline Image**: The first image in an SVS file is the baseline specimen image saved at full resolution. This image is tiled, typically using a tile size of **240 x 240 pixels**.
    
3.  **Thumbnail Image**: The second image is a thumbnail, usually sized at **1024 x 768 pixels**. This smaller image provides a quick overview for easier navigation.
    
4.  **Pyramid Images**: Following the baseline and thumbnail images, SVS files may include additional pyramid images saved at various resolutions, facilitating smooth zooming and panning.
    
5.  **Slide Label Image**: Many SVS files also contain a slide label image that identifies the physical slide the file was created from. This helps link the digital images with their corresponding physical specimens, ensuring accurate analysis.
    
6.  **Metadata**: SVS files can store extensive metadata about the specimen, such as identification numbers, staining methods, and other pertinent details that enhance analysis and research.
    
## How to open an SVS file

Opening SVS files requires specialized software designed for handling digital slide images. Here are some commonly used applications that can open SVS files:

1.  **Aperio ImageScope**: This software is specifically designed for viewing SVS files and provides various tools for annotation, measurement, and analysis of digital slides. It’s widely used in clinical and research settings.
    
2.  **QuPath**: An open-source software for bioimage analysis that supports SVS files. QuPath offers powerful tools for image analysis and visualization, making it a popular choice among researchers.
    
3.  **OpenSlide**: This library allows developers to access SVS files programmatically. It also includes various viewer applications for opening SVS images.
    
4.  **PathViewer**: A user-friendly application that supports the viewing of SVS files, PathViewer allows for easy navigation and examination of digital slides.
    
5.  **ImageJ/Fiji**: These powerful image analysis tools can open SVS files with the appropriate plugins. They are commonly used in research for processing and analyzing scientific images.
