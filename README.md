# __*Sigil-Of-Flames*__
### __*By: Derek Villars and Marc Larkin*__

## __*Setup/Installation Requirements:*__

## __*Gameplay Instructions*__
##### __Setup phase__
  1. Player one enters their name
  2. Player two enters their name
  3. Player one selects five units to add to their unit list
  4. Player two selects five units to add to their unit list

##### __Combat phase__
  1. Player one selects a unit from his team
    - each unit has a type, statistics, and weapons. All of which contribute to the outcome of a battle.
  2. Player one selects a unit from the opposing team to attack
    - the enemy unit also has a type, statistics, and weapon.
  3. The game calculates the combat between the two units.
    - ex. `Damage = (Attack – enemy Defense) x Critical coefficient.`
  4. Player one's turn ends, it is now player two's turn
    - start from 1 and do the same.

## __*Specifications:*__

##### __Players__
1. verify the table is empty
  + yes, yes
- reads name input
  + __input:__ Nils
  + __Output:__ Nils
- Saves name to player table
  + __input:__ Nils
  + __Output:__ Name saves to database
- Automatically assign a number to a player
  + __input:__ Nils
  + __Output:__ Nils

##### __Units__
1. verify the table is empty
  + yes, yes
- Add weapon to database; return weapon
1. Add weapon and return weapon stats
  + __input:__ Sword
  + __Output:__ DMG#, CRT#, TRI_S#, ...
- Add weapon and return a list of weapons
  + __input:__ Sword
  + __Output:__ Sword, Axe, Bow

##### __Weapons__
1. verify the table is empty
  + yes, yes
1. Add weapon and return weapon stats
  + __input:__ Sword
  + __Output:__ DMG#, CRT#, TRI_S#, ...
- Call weapon stat and return its value
  + "STR"
  + "25"
- Add weapon and return a list of weapons
  + __input:__ Sword
  + __Output:__ Sword, Axe, Bow


##### __Players_Units__
1. verify the table is empty
  + yes, yes
1. Add weapon and return weapon stats
  + __input:__ Sword
  + __Output:__ DMG#, CRT#, TRI_S#, ...
- Assign a unit to a player and return a list of units assigned to that player
  + __input:__ Paladin
  + __Output:__ Paladin, General, Knight

##### __Units_Weapons__
1. verify the table is empty
  + yes, yes

- Call weapon stat and return its value
  + "STR"
  + "25"
- Add unit and return unit stats
  + __input:__ Sword
  + __Output:__ HP#, STR#, SKL#, ...




## __*Example Tables:*__

![A picture of our table layout](/img/Table_layouts.png)


## __*Support and Contact:*__
If you have any questions for me or have any problems, please email at derekvillars@yahoo.com or larkimarc@gmail.com.

Copyright (c) 2017 __Derek Villars__ and __Marc Larkin__
