# maplewookie


A mass maplestory character generator and renderer written in C# using v104 GD files

![Examples](http://i.imgur.com/o5VHvuU.png)

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

- Visual studio 2013
- Maplestory v104 GDs ([link](https://drive.google.com/file/d/0B1BJqPPfhZhdRjNLUFpjbWgxWVk/view?usp=sharing "link"))

### Usage

1. `git clone` this repository
2. In `Character.cs`, set your gd path
3. In `Form1.cs => Generate()`, Adjust the loop to choose the amount of characters to generate
4. Make sure `C:\output\` exists; An exception will be thrown if not
5. Run the program and the generation will start automatically.

### Todo

- A nice front end for non technical users
- Make a dumper program for the GD
- Store all the data/pictures into nx and/or json files
- Read the item pool at runtime rather than having the ids in static arrays