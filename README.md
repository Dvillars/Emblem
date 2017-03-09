# __*Sigil-Of-Flames*__
### __*By: Derek Villars and Marc Larkin*__

## Description
Fire Emblem is a turn-based strategy game.  


 Here we have attempted to recreate the combat system to allow two players to go head to head with a handful of their favorite characters from the first US installment of the Fire Emblem.

## Setup/Installation Requirements
* Requires DNU, DNX, MSSQL, SSMS, and Mono

#### Create Databases

* Clone to local machine
* In SSMS:
 1. press `ctrl + O`
 2. navigate to the `Emblem` folder you cloned
 3. Select `EmblemDatabaseRebuild.sql`
 4. After you've opened the .sql file, click the `! execute` button to rebuild the database.
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

***

## Specifications

### Units Class
================================  
1. verify the table is empty
  + Nice
- Add unit to database; return unit
  + __input:__ General
  + __Output:__ General
1. Call unit and return unit stats
    + __input:__ General
    + __Output:__ hp, str, def, ...
- Call unit stat and return its value
    + __input:__"hp"
    + __Output:__"21"

### Weapons class
================================
1. verify the table is empty
  + Nice
1. Add weapon and return weapon
  + __input:__ Sword
  + __Output:__ Sword
1. Call weapon and return weapon stats
  + __input:__ Sword
  + __Output:__ DMG#, CRT#, TRI_S#, ...
- Call weapon stat and return its value
  + __input:__"DMG"
  + __Output:__"15"
- Add weapon and return a list of weapons in the weapons table
  + __input:__ Sword
  + __Output:__ Sword, Axe, Bow

### Players class
================================
1. verify the table is empty
  + Nice
- reads name input
  + __input:__ Nils
  + __Output:__ Nils
- Saves name to player table
  + __input:__ Nils
  + __Output:__ Name saves to database
- Automatically assign a number to a player
  + __input:__ Marc
  + __Output:__ id = 1

### players_units
=========================================  
1. verify the table is empty
  + Nice
- Assign a unit to a player and return a list of units assigned to that player
  + __input:__ Paladin, "Marc"
  + __Output:__ Paladin, General, Knight
***
### User Interface
===================================  
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


## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS

***

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Marc Larkin_** and **_Derek Villars_**


![A picture of our table layout](/Content/img/Table_layouts.png)

[A link to combat calculation](https://serenesforest.net/blazing-sword/miscellaneous/calculations/)


## __*Support and Contact:*__
If you have any questions for me or have any problems, please email at derekvillars@yahoo.com or larkimarc@gmail.com.

Copyright © 2017 __Derek Villars__ and __Marc Larkin__
