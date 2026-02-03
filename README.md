# Starforge Outpost

Unity prototype foundation for a sci-fi base-building game built around data-driven ScriptableObjects, modular systems, and a complete UI flow.

## Folder Structure

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── GameState.cs
│   │   ├── SceneLoader.cs
│   │   └── InputManager.cs
│   │
│   ├── Grid/
│   │   └── GridSystem.cs
│   │
│   ├── Buildings/
│   │   ├── BuildingBase.cs
│   │   ├── BuildingPlacer.cs
│   │   ├── ResourceGenerator.cs
│   │   └── CraftingStation.cs
│   │
│   ├── Crafting/
│   │   ├── CraftingSystem.cs
│   │   ├── CraftingRecipe.cs
│   │   └── CraftCustomization.cs
│   │
│   ├── Inventory/
│   │   └── InventorySystem.cs
│   │
│   ├── Data/
│   │   ├── BuildingDataSO.cs
│   │   ├── ItemDataSO.cs
│   │   ├── RecipeDataSO.cs
│   │   └── ResourceAmount.cs
│   │
│   └── UI/
│       ├── MainMenuUI.cs
│       ├── PauseMenuUI.cs
│       ├── EndScreenUI.cs
│       ├── BuildMenuUI.cs
│       ├── CraftingUI.cs
│       └── InventoryUI.cs
│
├── ScriptableObjects/
│   ├── Buildings/
│   ├── Items/
│   └── Recipes/
│
├── Prefabs/
│   ├── Buildings/
│   └── UI/
│
├── Scenes/
│   ├── MainMenu.unity
│   └── Game.unity
```

## System Overview

### ScriptableObjects
- `BuildingDataSO` defines building size, cost, resource generation, and crafting recipes.
- `ItemDataSO` defines resources and craftable items (including default color).
- `RecipeDataSO` defines crafting inputs, outputs, craft time, and color presets.
- ScriptableObject assets are authored in the Unity editor and stored under `Assets/ScriptableObjects/` (see the README there for starter asset suggestions).

### Core Systems
- `GameManager` controls game state, pause, and game over.
- `SceneLoader` handles menu-to-game navigation.
- `GridSystem` validates grid placement.
- `BuildingPlacer` checks inventory costs, validates placement, and spawns buildings.
- `ResourceGenerator` produces resources over time for generator buildings.
- `CraftingSystem` consumes resources, waits craft time, then adds crafted items.
- `CraftCustomization` applies color data to crafted item instances.

### UI Flow
- `MainMenuUI`, `PauseMenuUI`, `EndScreenUI` handle menu navigation.
- `BuildMenuUI` selects building data for placement.
- `CraftingUI` selects recipes and colors before crafting.
- `InventoryUI` displays resource counts.

## How Systems Connect
- `BuildingPlacer` reads `BuildingDataSO` and `InventorySystem` to place buildings on the `GridSystem`.
- Resource buildings add items to `InventorySystem` via `ResourceGenerator`.
- `CraftingStation` exposes recipes, while `CraftingSystem` checks inventory, crafts, and saves customized item data.
- UI scripts send commands to `SceneLoader`, `GameManager`, `BuildingPlacer`, and `CraftingStation` without direct gameplay logic.
