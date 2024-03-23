# LöveFusion Game Packager

LöveFusion is a tool designed to streamline the process of packaging games made with Löve2d framework. This tool simplifies the packaging process by remembering path locations, making it easier for developers to package their games consistently. Users can use their own custom icon to personalize the presentation of their packaged game executables.

## Features

- **Path Location Memory**: The tool remembers the path locations used for packaging, reducing the need for developers to repeatedly specify the same paths.
- **Simplified Packaging Process**: With the stored path locations, packaging games becomes a more straightforward and efficient task.
- **User-Friendly Interface**: The program offers a simple and intuitive interface, making it accessible to developers of all skill levels.

## Usage

1. **Launch the Program**: Run the executable file to launch the Löve2d Game Packager.
2. **Set Path Locations**: On the main interface, specify the required path locations for packaging your game.
3. **Optional: Set Game Name**: If desired, you can specify a custom name for your game by entering it in the "Game Name" field. If left blank, the tool will use the folder name of your game directory.
4. **Optional: Specify Bin Location**: You can optionally specify the location of the bin folder for FFI by clicking the "Browse" button next to the "Bin Folder" field and selecting the folder.
5. **Choose an Icon (Optional)**: You can optionally set an icon for your game by clicking the "Browse" button next to the "Icon File" field and selecting an icon file.
6. **Package Your Game**: Once the path locations are set you can package your game with the click of a button.
7. **Copying Bin Files**: The tool automatically copies the necessary bin files and folders to the bin output path to support FFI when the game is fused.
8. **Repeat as Needed**: The tool will remember the specified path locations for future use, simplifying the packaging process for subsequent games.

## Requirements

- Windows operating system (compatibility with other platforms may be added in future updates)
- Löve2d framework installed on your system
- Basic knowledge of packaging games with Löve2d

## Installation

1. Download the latest release from the Releases section of this repository.
2. Extract the downloaded ZIP file to a location of your choice.
3. Run the executable file to launch the program.

## Contributing

Contributions to the Löve2d Game Packager are welcome! If you encounter any issues, have suggestions for improvements, or would like to contribute code, please feel free to submit a pull request or open an issue on GitHub.

## License

This project is licensed under the [MIT License](LICENSE).

