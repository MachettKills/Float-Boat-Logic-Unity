# Float-Boat-Logic-Unity

3D Sailing &amp; Water Buoyancy Physics (Unity)

A physics-based 3D ship controller built from scratch in Unity using C#. This project focuses on realistic water buoyancy and boat handling without relying on mesh colliders for the water surface.

Technical Features:

 - Script-Based Buoyancy: Uses custom Archimedes' principle logic to calculate and apply upward forces (`Rigidbody.AddForce`) based on the ship's position relative to the water level.
 - Physics-Driven Movement: Ship acceleration, coasting, and turning are handled entirely through torque and forces, providing realistic inertia and weight simulation.
 - Clean Code Architecture: Input detection is decoupled from physics calculations, following clean programming principles for Unity.

Tech Stack:

 - Engine: Unity
 - Language: C# (.NET)
 - Physics: Rigidbody, Forces, and Torque vectors

How it Works?

Instead of using standard colliders, the `AguaPhysics` script calculates the submersion depth of the vessel and applies dynamic forces to simulate realistic floating, tilting, and rocking effects on the waves
