##3D UI Assignment 3

Yi Wang (yw2580)

2014/4/5

## Introduction
I used Vofuria, Unity 3D, to create this augment reality application. Most functions are made through collision detection, since I've no idea how to implement gesture recongnition. Mainly my models are for cars, initially there're 4 different cars on the ground imagine target, all downloaded from unity asset store. In addition, to make toolbar visualizable, I take two swords models one as selection toolbar, other as function toolbar, details will be given following.

## Title
Argumented Reality for Cars 

## Mobile Platform

Android

OS version:
	4.2.2	
Device name:
	Samsung Galaxy S3

## Files Hierarchy
./

	Images for Imagine Target:
		Workspace.jpg
		Ground.jpg
		Toolbar_Front.jpg
		Toolbar_Back.jpg
	Assets, Models:
		Download from asset store
	Scripts: ./Assets/Script

| Script name | Brief explanation |
| ------------- | -------------:|
| BaseTrackableEventHandler.cs | Ground Imagine Target script |
| CameraBehavior.cs | ARCamera control, GUI control |
| ObjManage.cs | Creation and Deletion, for Toolbar_back side |
| otherTrackableEventHandler.cs | Workspace Imagine Target script |
| Selection.cs | Car behavior control, like collision detection, turn on/off circle | 
| Stable.cs | Just keep the collider on the workspace stable | 
| ToolbarBehavior.cs | Toolbar_Front side behavior control |
| WorkSpaceManage.cs | Workspace behavior management |
| ToolbarTrackableEventHandler.cs | Toolbar Imagine Target control script |

## Asset sources
	From Unity Asset stores

## Missing features
	None


## How to run	

Open Assets/car.unity:

	1. Deploy to Android/iOS(properly configured)
	2. Directly run it from within Unity 3D IDE

## Design

# 1.Selection
Selection is made possible by using Toolbar_front touches the car on the ground (precisions hard to guarantee).
	
Deselection is made possible by touching the same car again, using same Toolbar_front.
# 2.Translation 
Iterative translation is made possible by touching the GUI button(*select On/Off*) on the screen, then user can use the Toolbar_front to control the selected car in three axises. The direction and distance that a user moves the Toolbar_front will be directed reflected on the movement of the selected car.

# 3.Rotate
Iterative translation is made possible by touching the GUI button(*rotate On/Off*), then user is able to use the Toolbar_front to rotate the selected car in three axises. The rotation that a user moves the Toolbar_front will be directed reflected on the rotation of the selected car.

Particularly, you have to be cautious when rotating. Because once the Toolbar_Front side is lost track of ARcamera, rotation will stop.

# 4.Scale
Iterative scale is made possible by touching the GUI button(*scale on/off*), differences from the two manipulations above is I used a count to record the position changes of Toolbar_front in **X** axis, every 50 frames. If the difference is positive, then selected car will zoom out 0.1 times. Otherwise, the selected car will zoom in 0.1 times.

# 5.Coordinate system
I implemented two different methods of coordinate system, but based both on camera's coordinate system. In other words, if coordinate system mode is turned on, then the selected car will remain motionless from the screen no matter how user changes the ground imagine target. Once coordinate system mode is turned off, selected car will be back into the ground target. Both the transfers are seamless.

You can try it out by:

	1. Set GUI button on the screen(*coordinate system On/Off*)
	2. Use Toolbar_Back side to touch the mirror of the selected car on the workspace imagine target, to realize this function
# 6.Workspace

Workspace provides another way for controling the selected car, the mirrored car is exactly same as the selected car but 5 times the size.

You can try translation, rotation, scaling as before, but the change made on the mirrored car is 1/5 times compared to original car except scaling.

You have to set the GUI button(*workspace On/Off*) on the screen to let workspace take effect or not.

# 7.Creation

Creation is made possible by using Toolbar_front side touching the mirrored car on the workspace(if any), a copy of this car, size of the original selected car, will be put right above the center of ground imagine target.

For proportion reason(not all car are of the same size), sometimes cars will overlap with others.

# 8.Deletion
Deletion is made possible by using Toolbar_Back side touching a car model, then a car will be destroied.

# Additional 

Selecting more than one car at a time is not supported.

Precisions are not guaranteed, so if you run into situations like losing sight of the selected car in the screen, just type the reset GUI button to reset the selected car in its first position and orientation.

# Video Links
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/p-iVYBz61Fo/0.jpg)](http://www.youtube.com/watch?v=p-iVYBz61Fo)

## Bugs 

RigidBody Bug:
	Because collision requires both objects have 'RigidBody' physical property, if toolbar colliders with objects many times, toolbar maybe out of sight.

Create car Bug:
	When touching the mirrored car on the workspace using Toolbar_Front side, the new cars created right above the ground imagine targe will overlap, like only one car is there. But if you look into the debug informations, my program successfully created multiple cars, their positions cannot be properly set.

Rotation Bug:
	You have to be cautious when rotating. Because once the Toolbar_Front side is lost track of ARcamera, rotation will stop


