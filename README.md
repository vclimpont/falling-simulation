# Falling simulation

This project is a programming exercise that simulate the falling behaviour of a parachutist on earth.

The idea is to maximize the safety by finding in which order the parachutists must dive and the range between each dive based on their mass.
The algorithm uses acceleration and speed calculation functions to determine the current location of a parachutist on each frame.

These functions take into account :
* the wind direction and force
* frictions intensity
* gravity on earth
* the current position of the plane on dive
* the mass of the parachutist

Then the program allows to save position, speed and acceleration variables into a text file to read them as curves in a graphical software.
