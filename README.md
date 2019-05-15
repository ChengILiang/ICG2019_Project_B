---
title: 'Interactive Computer Graphics - Project B Report'
disqus: hackmd
---

Project B: Witch-Soup Game (Report)
===
Interactive Computer Graphics 2019

**Group 5
Leader: 鄭翊良
Members: 蔡松霖、陳冠廷**


---
:::warning
*This game takes place in a magical world where magic exists. What you experience is the process of a modern witch making the potion out of some magical objects like frog, snail, lego figure, weed and elephant. Please try to make a potion of your own too!*

:::
> *Ha Ha Ha~~~ Hoo Hoo Hoo~* 
> [name=蔡松霖 :heart_eyes_cat:]
> *Best game of the year!*
> [name=鄭翊良 :+1:]
> *Please catch the frog*
> [name=陳冠廷 :frog:]
[color=#e26c61]


---


## Table of Contents

[TOC]



## Structure

Uses `jib_motion`、`control` script to control the rotation and movement of jib and trolley/hook. We use `FlyingHook` script to simulate the grabbing process of hook (object detection, joining object, releasing object). We use `PrimitiveGenerator` script to set color when grabbing a sphere or box, and set them with random color when initiating. We use `rope` script to simulate the swinging motion of the rope. We use `collision_detection` script to randomly assign a color to the particle system when an object collides. We use the `frog_jump `script to randomly assign a direction for the frog object to jump towards. We also use a `FreeCameraEntity` to control the camera movement.

Functions
---

### Tower/Jib/Hook Model, Control & Motion Behavior
We use the model provided on the class as our tower/jib/hook model. `LeftArrow` and `RightArrow` can rotate the jib counterclockwise and clockwise, `UpArrow` and `DownArrow` can move the trolley forward and backwards.

![Fig1](https://i.imgur.com/ViTX0BX.png)
**Fig 1. the initiation of a witch-soup game**

### Grabbing Process
We shot a ray from the center of the hook to determine whether an object is beneath the hook that is within a certain range. `Space` key can attach or detach the object with a joint. `[` and `]` key can create or delete a section of the rope.
![Fig2](https://i.imgur.com/JW99afu.gif)
**Fig 2. the frog wants to escape, but we catch it.**




Extra Credits
---
### Color Assign
We assign random color to the initiated spheres and boxes. Also, we assign a box collider to the particle system that will randomly change the start color of the particle system when collision occurs. Hence, once an object is thrown into the bowl, the color of the particle system will change to a random color.

Color of spheres and boxes will change to yellow when the object is within grabbing range of the hook, will change to red when grabbed, will reassign to the origin color after detaching.

### Frog and Weed/Elephant Motion
The frog model will first randomly pick a point within a certain range, rotate the current axis towards the assigned point. The frog will then assign to an impulse force when it is on the ground for two times. The process will be repeated throughout the game.

Weed and elephant are assigned to a rotate script that will constantly rotate the gameObject.

### Camera Control
You can control the camera with `W`,`A`,`S`,`D` to move the camera horizontally with respect to the mouse position, `Q`, `E` to move the camera upwards or downwards.

## Work Division
**Project Design, Planning, Report:** All
**Motion, Control, Color Assign:** 冠廷
**Grabbing Process, Camera Control:** 翊良
**Rope Simulation, Joint design:** 松霖

## Reference - Rope Motion
* [Swinging rope simulation using Verlet integration](https://www.habrador.com/tutorials/rope/3-another-simplified-rope/)
With the above reference script the rope simulation works well without using joints. We then added function to create or delete sections of the rope, so that the hook can be able to go up and down.

## Appendix and FAQ

:::info
Thank you for your watching. Please Like and welcome to leave a comment! :kissing_heart:
:::

###### tags: `Interactive Computer Graphics` `ICG` `crane simulation`
