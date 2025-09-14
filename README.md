# Culinary Alchemy

By: Benjamin Blas Maristany, Diego Medina Molina

## Overview

Culinary Alchemy is a parody game inspired by “Little Alchemy” themed around food and cultural dishes. Players will start with only a few ingredients. Over time, they can combine them to discover new ingredients and perhaps cook them into delicious Latin American dishes.

## Player Interactivity

We have implemented Drag And Drop functionality to Culinary Alchemy. Players can scroll down their inventory of ingredients on the right side of the screen, then click and drag ingredients from it and drop them onto the play area. When dropping an ingredient on nothing, the ingredient will be placed where it was dropped. Players can also click ad drag ingredients that are on the play area, which will both move the ingredient to its new location and remove it from its previous one.

## Alchemy Rules

Just like Little Alchemy, players of Culinary Alchemy can only progress upon success. A player will know they **succeed** when the elements that they choose to combine turn into a new element, which is then added to their inventory. If the players try to combine two elements, but they do not react, they have **failed** to create a new ingredient.

### Validity Check

The ingredients themselves detect when they are trying to be combined. If they detect that the player placed dropped one on the other, then they will start trying to combine with each other. The first step is to verify that the combination is valid with the `Registry` (explained in Item Storage section). Only when the check succeeds then the PlayfieldElement actually creates the ingredient GameObject. This check is crucial to ensure we keep players within the bounds of the game we have developed.

## Item Storage Handling

Culinary Alchemy creates a new instance of each ingredient as the game progresses. Prior to an ingredient or dish's discovery, it does not exist in the files as a game object. Instead, the game has the `Registry`, which holds the lists of **all** valid recipes, ingredients, and ingredient image paths as uniquely-identifiable (and lightweight) string data. This data is primarily retrieved from parsing two text files when the game is initialized using `CSVLoader`, keeping the setup process lightweight as well. This Registry is what is referenced for validity (success) when creating a new ingredient.

### Dynamic Creation of GameObjects 

The player's inventory (`InventoryUI`) handles the initialization of the actual ingredient GameObjects when the player succeeds in a combination. Only when the validity check with the `Registry` passes, a GameObject for the new ingredient is instantiated as an `ElementUI`, which is the permanent ingredient object that is kept in the player's inventory for quick access. The object is created from the strings in the `Registry` and the image retrieved from the stored image path. When the player drags and drops an ingredient onto the play area, a `PlayfieldElement` object is created, which is the temporary representation of the ingredient on the play area that will be combined with other ingredients and attempt combination. Each `ElementUI` created persists forever, while `PlayfieldElement` objects will be regularly deleted when the player is interacting with them. There is also a Clear All button to eliminate all `PlayfieldElement` objects and clear the play area.

## Resources

All our sprites are images found online searching on the following websites:

* https://creazilla.com
* https://www.flaticon.com
* https://commons.wikimedia.org/
* https://pngtree.com
* https://www3.gobiernodecanarias.org/medusa/wiki/images/d/d7/Arroz-con-leche.png