# Health System Unity 3D (Dark Souls-like) 
## This tutorial is based on how to create a health system that functions very similarly to the well-known game, Dark Souls. Whenever the player takes damage, you'll see another colour health bar which simply indicates that you've taken damage, rather than simply the health bar going down.

1. Create a new scene in Unity, or if you already have a scene, open that up. 
2. Right click the hierarchy, hover over UI, and select Canvas.
3. Select 2D at the top of your scene to get a better view of the canvas, then click Canvas in the hierachy, right click then create empty object and name it Health Bar.

![image](https://github.com/user-attachments/assets/35cf82a1-b575-4482-a8b5-29ede84bb9f6)

4. You then modify its scale and re-size it and re-shape it to how you'd like, then select Health Bar in the hierachy, right click, hover over UI and click image and re-name this to Background.
5. Then, on the right you want to adjust the anchor presets by click on the stretch anchor button then hold the alt key and select the anchor on the bottom right.

![image](https://github.com/user-attachments/assets/3f28e73e-a873-4ed7-bba4-e8d2e455a517)

6. Then on the image component of the background object, we're going to change the colour, I chose a dark red colour for mine.
7. Next, we're going to make another UI image, so again, right click the hierarchy -> UI -> Image and name this Fill. Make sure this UI Image is above background but is still a child to the Health Bar object on the hierarchy.
