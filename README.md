2D Space shooter where you mine gold from space rocks and avoid enemy ships

Gameplay elements:

Ship movement -
 - always moving forward
 - turn left/right
 - boost/slow down)
Lazer rotates to point at mouse cursor
Gain gold resource by mining rocks and killing enemies
Avoid enemy bullets
Spend gold on ship upgrades -
 - More boost
 - tighter turn
 - stronger laser
 - etc.


Programming approaches:

Trigonometry for ship movement and ship/laser rotation
Enemies (and rocks?) use game states to control AI -
 - Move across screen until close enough to player
 - Follow player and shoot at them
 - Turn and move away if too close
Enemies and rocks use polymorphism to derive multiple types
Object pooling for rocks and enemies
Laser using raycasting