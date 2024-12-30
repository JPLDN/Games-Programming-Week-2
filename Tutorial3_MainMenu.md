# Main Menu System 
## This tutorial shows how to make a Main Menu system with a Play, Options anc Quit button in Unity 3d, as well as another section with a back button after clicking options.

1. Create a new scene in Unity 3d and then right click the mouse button in the Hierachy, select UI, then click "Button - textMeshPro"
2. Move around the button with the move tool and place it where you'd like it to be. You can also adjust the button itself in the Rect Transform component, adjusting the scale and position more accurately.

### Now we're going to make so that, whenever your mouse hovers over the button, the opacity drops, and when you actually click the button, the opacity is now 100% and hard.

3. On the button, go to the button component, for normal colour, on the A section, make sure that's set to 0. For Highlighted colour, you can choose what colour you want for the RGB sections, and make sure the A section is set to 77. For Pressed colour, again, adjust the colours to your liking for RGB's section, and this time the A section should be 123.
Lastly, for Selected Colour, you adjust RGB colours to your liking and then set section A to 255. 

![image](https://github.com/user-attachments/assets/61264aea-fad6-4ab4-bb9f-27a0f3c838d7)

This is what it should look like once you're finished with the button.

4. Next on the Text object, which should be inside the button on the hierachy, change the text to "Play" and underneath it somewhere, select "Enable Auto Sizing" then change the colour (towards the top of the textMeshPro component) to white.
5. Re-name the Button on the hierachy to PlayButton, then duplicate this object twice and re-name the 2 buttons to OptionsButton and QuitButton. Then update the text for both the OptionsButton and QuitButton in the TextMeshPro component, and of course change them to "Options" and "Quit" for their respective buttons.

![image](https://github.com/user-attachments/assets/286a7fbf-1c0d-4e4b-b3c7-0059a7c43b31)

6. Create an Empty game object in the hierarchy, right click it and select create empty, re-name this empty object to MainMenu, then select the 3 objects and drop onto the Main Menu so that the 3 buttons become a children object to MainMenu, which becomes a parent. Make sure the MainMenu object is a child to the Canvas.

![image](https://github.com/user-attachments/assets/b603cf5e-d00e-471e-93ac-5248265f9c5c)


It should look like this.



