Once loaded, in the Scene View, select the BG_Camera object
Drag this to move around the world. 

Fixes:

Corrected asset scaling issue. all assets drawn at correct scale relative to each other now. This is an issue of max texture import
size (current assets must be imported at 8k for correct pixel resolution) and also needing the pixel perfect camera component to properly 
set the DPI and reference resolution for the camera.

Features:

-Layer based parallax scrolling in the X/Y direction. Level of parallax user adjustable in component.
-Dynamic skybox color. Trigger color changes to skybox to create eg area transitions, day/night cycles, etc.
-Screen space god rays. Custom post processing effect that takes main light rotation into account to simulate god rays.
Features simulated occlusion for added sense of depth.
-Particle systems to simulate gently falling leaves, fireflies


If you drag the camera in Play mode through the scene and follow the path of the skybox triggers (cloud icons),
you will see the skybox/godray transition effect.

Sorry I don't have something controllable in game, but I did not have time to write a character controller 
and set up collision for this, I hope that is alright!

Thank you for your consideration, I hope you enjoy the result!