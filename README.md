# ChestSystem
Chest system like Clash Royal as a part of Unity Advance Mat1 assignment

### Description
It is a 2D chest system like Clash Royal, Where player can spawn chests using Coins, unlock them via Queue, <br> 
Unlock them Immidiately using Gems, and Collect them after unlocking.

### Gameplay Video
[Chest System Gameplay Video](https://youtu.be/8ekAFPptKDQ)

## Patterns Used
- Service Locator - Used to hold all the services required in a Level
- Generic Singleton - Used to create Service locator as a singleton
- Observer - Used to crate Popup system like All Slots Are Full, Not enough resourses, Queue is full
- State machine - Used to generate Finite State Machine for Chest
- MVC - Used to create Chest Slot behaviour
- Object Pooling - Used to store and retrieve chest objects in the scene

### Functionalities
- Player can spawn only 4 Chest (Changable)
- Player can Queue only 2 Chest (Changable)
- Chest is spawned randomly out of 4 types (Changable)
- Reward of a chest is Random depending upon the type of Chest (Reward range is Changable)
- Player can unlock  any chest immidiately at any time using Gems
- Number of Gems required to Unlock a chest immidiately depends on the remaining time of a chest
- Pop up comes when <br> 1) player tries to spawn more than 4 Chests at a time, or <br> 2) Tries to Queue more than 2 Chests, or <br> 3) Does not have enough resuorces to perform an action (Like Spawn chest or Unlock Immidiately).

### Screenshots
![ChestSystem1](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/f5a1c3a0-943c-4716-9e65-ae4eb9ab030d)

![ChestSystem2](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/15d02c10-49bd-4ea3-98d9-d069fee5425c)

![ChestSystem3](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/5a99f429-5d17-4aed-9af3-c54dbd2d76d8)

![ChestSystem4](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/ea6301ef-b85e-4338-962d-48d6cea694e2)

![ChestSystem5](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/40765777-9db8-48be-9f47-24913a785ce1)

![ChestSystem6](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/82107929-7f2b-4478-8279-b6b18b3725c5)

![ChestSystem7](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/2546183e-1366-4c1c-8608-ceb159b0f70e)

![ChestSystem8](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/a9ac8209-5cb0-4944-8546-81ddb3e9a6e6)

![ChestSystem9](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/c1cce3b1-aaaf-487d-a6df-e7eed2f5eeb4)

![ChestSystem10](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/aecd215f-a33f-4237-8f0c-e512f6f23ba4)

![ChestSystem11](https://github.com/SiddharthVarde22/ChestSystem_Mat1/assets/118422811/842be2fb-ba21-4618-8944-8092e002d761)

