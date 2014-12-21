# maplewookie


A mass maplestory character generator and renderer written in C# using v104 GD files

![Frontend](http://i.imgur.com/1AdHJgB.png)

![Thumbnails](http://i.imgur.com/o5VHvuU.png)

### Supported elements

- Body/Head/Arm
- Hats
- Face accessory
- Eye accessory
- Top
- Pants
- Shoes
- Gloves

### Requirements

- Maplestory v104 GDs ([download](https://drive.google.com/file/d/0B1BJqPPfhZhdRjNLUFpjbWgxWVk/view?usp=sharing "link"))

### Usage

1. Get the latest version from [this page](https://github.com/oxysoft/maplewookie/releases)
2. The app will automatically create `C:\maplewookie\` and `C:\maplewookie\output` on the initial launch
3. Extract your gd folder to `C:\maplewookie\gd`
4. Generated sprites will be created in `C:\maplewookie\output\`

### Todo

- Support for the rest of the equipments
- Background image in the preview pane
- Make a dumper program for the GD
- Store all the data/pictures into nx and/or json files
- Read the item pool at runtime rather than having the ids in static arrays