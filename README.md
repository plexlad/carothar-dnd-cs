# Carothar D&D Manager

### Reference is not complete but can still be used

You should have a basic knowledge in D&D stats to use the Logic library.
+ indicates that it is a method.

## Logic Library Reference
- PlayerStats: Class with D&D character info
    - String Based Info
        - int Version: Your players version
        - string PlayerName: Your name
        - string Name: Your characters name
        - string Descripton
        - string Alignment
        - string Height
        - string Meta: Meta data that can be used for ease with the database. Can
    be used for anything from serialized json to coninued character data. Cannot
    be used by the user.
    - Standard Info
        - int Level: The total level of your character, multiclassing included.
        - Race Race
        - int InitiativeBonus
        - int Speed: Stored as an integer in feet
        - ObservableCollection<ClassInfoEntry> ClassInfo: A list of tuple
        information that shows Class, Level, HitDice, 
        has events to notice changes.
    - Number Based Stats (standard D&D stuff)
        - int HP: Current health points
        - int TotalHP
        - int AC: Armor class
        - int Proficiency: Private set because it should automatically set.
    - Main Beefy Stats (This includes the normal proficiencies under stats)
        - STR (AbilityBase)
        - DEX (AbilityBase)
        - CON (AbilityBase)
        - INT (AbilityBase)
        - WIS (AbilityBase)
        - CHA (AbilityBase)
- ClassInfoEntry: 
    - Class Class
    - int Level
    - Dice HitDice
    - int TotalHitDice
    - int HitDiceAmount
- AbilityBase: Base class with profieciencies added
    - int Value: The base of the ability (1-20)
    - int Modifier: The modifier based on the value
    - bool SavingThrow: If proficient in SavingThrow
- Skill: The individual proficiencies
- Enums: Enumerations that contain type definitions 
    - Class
    - Dice: Dice have an integer value that is equal to the amount of sides on them.
    - Race
    - Backgrounds
- Defaults: Class with a set of default characters 
    - HumanFighter: Human fighter named Steve

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/h3Mc9z4G)
