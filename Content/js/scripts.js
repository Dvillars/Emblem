

// enter the speed number to get a valid result
function doubleHit(p1Speed, p2Speed) {
  var result;
  if (p1Speed - p2Speed >= 4) {
    result = 'p1';
  } else if (p1Speed - p2Speed <= -4) {
    result = 'p2';
  } else {
    result = "null";
  }

  return result;
}
//-------------------------------------------------------------------------|----------------------------------------
function p1Swing (strMag, wepDamage, p1WepType, wepStrong, wepWeak, effect, phyical, resistance, p2WepType, unitType) {
  var triBonus;
  if (wepStrong == p2WepType && wepStrong != "null") {
    triBonus = 1;
  } else if (wepWeak == p2WepType && wepWeak != "null") {
    triBonus = -1;
  } else (
    triBonus = 0;
  )

  var coefficient;
  if (effect == unitType && effect != "null") {
    coefficient = 2;
  } else {
    coefficient = 1;
  }

  var attack = strMag + ((wepDamage + triBonus) * coefficient)

  var defense;
  if (p1WepType == "sword" || p1WepType == "axe" || p1WepType == "spear" || p1WepType == "bow") {
    defense = phyical;
  } else if (p1WepType == "anima" || p1WepType == "dark" || p1WepType == "light") {
    defense = resistance;
  }

  var damage = attack - defense;

  return damage;
}

//   -------------------------------------------------------|-----------
function accuracy(wepHit, skill, p1Luck, wepStrong, wepWeak, p2WepType, speed, p2Luck) {
  var triBonus;
  if (wepStrong == p2WepType && wepStrong != "null") {
    triBonus = 15;
  } else if (wepWeak == p2WepType && wepWeak != "null") {
    triBonus = -15;
  } else (
    triBonus = 0;
  )

  var accuracy = wepHit + (skill * 2) + (p1Luck / 2) + triBonus;
  var avoid = (speed * 3) + p1Luck;
  var battle = accuracy - avoid;
  return battle;
}
//----------------------------------|-----------
function critical(unitType, wepCrit, skill, luck) {
  var bonus;
  if (p1WepType == "swordmaster" || p1WepType == "berserker") {
    bonus = 15;
  } else {
    bonus = 0;
  }
  var rate = wepCrit + (skill / 2) + bonus;
  var critical = rate - luck;
  return critical;
}

var hitchance =



//Variables to store Unit One information
var attackerUnitName = "";
var attackerUnitType = "";
var attackerUnitHitpoints = 0;
var attackerUnitStrength = 0;
var attackerUnitSkill = 0;
var attackerUnitSpeed = 0;
var attackerUnitLuck = 0;
var attackerUnitDefense = 0;
var attackerUnitResistance = 0;
//Variables to store Unit One weapon information
var attackerWeaponName = 0;
var attackerWeaponType = 0;
var attackerWeaponRange = 0;
var attackerWeaponDamage = 0;
var attackerWeaponHit = 0;
var attackerWeaponCrit = 0;
var attackerWeaponTriStrong = 0;
var attackerWeaponWeak = 0;
var attackerWeaponEffect = 0;
//Variables to store Unit Two information
var defenderUnitName = "";
var defenderUnitType = "";
var defenderUnitHitpoints = 0;
var defenderUnitStrength = 0;
var defenderUnitSkill = 0;
var defenderUnitSpeed = 0;
var defenderUnitLuck = 0;
var defenderUnitDefense = 0;
var defenderUnitResistance = 0;
//Variables to store Unit Two weapon information
var defenderWeaponName = 0;
var defenderWeaponType = 0;
var defenderWeaponRange = 0;
var defenderWeaponDamage = 0;
var defenderWeaponHit = 0;
var defenderWeaponCrit = 0;
var defenderWeaponTriStrong = 0;
var defenderWeaponWeak = 0;
var defenderWeaponEffect = 0;
$(function() {

if (attackerUnitName === ""){
    $("div").click(function() {
        //Get unit information
        attackerUnitName = this.children[0].innerHTML;
        attackerUnitType = this.children[1].innerHTML;
        attackerUnitHitpoints = this.children[3].value;
        attackerUnitStrength = this.children[4].value;
        attackerUnitSkill = this.children[5].value;
        attackerUnitSpeed = this.children[6].value;
        attackerUnitLuck = this.children[7].value;
        attackerUnitDefense = this.children[8].value;
        attackerUnitResistance = this.children[9].value;
        //Get weapon information
        attackerWeaponName = this.children[10].value;
        attackerWeaponType = this.children[11].value;
        attackerWeaponRange = this.children[12].value;
        attackerWeaponDamage = this.children[13].value;
        attackerWeaponHit = this.children[14].value;
        attackerWeaponCrit = this.children[15].value;
        attackerWeaponTriStrong = this.children[16].value;
        attackerWeaponTriWeak = this.children[17].value;
        attackerWeaponEffect = this.children[18].value;

    }} else {
        $("div").click(function() {
        defenderUnitName = this.children[0].innerHTML;
        defenderUnitType = this.children[1].innerHTML;
        defenderUnitHitpoints = this.children[3].value;
        defenderUnitStrength = this.children[4].value;
        defenderUnitSkill = this.children[5].value;
        defenderUnitSpeed = this.children[6].value;
        defenderUnitLuck = this.children[7].value;
        defenderUnitDefense = this.children[8].value;
        defenderUnitResistance = this.children[9].value;
        //Get weapon information
        defenderWeaponName = this.children[10].value;
        defenderWeaponType = this.children[11].value;
        defenderWeaponRange = this.children[12].value;
        defenderWeaponDamage = this.children[13].value;
        defenderWeaponHit = this.children[14].value;
        defenderWeaponCrit = this.children[15].value;
        defenderWeaponTriStrong = this.children[16].value;
        defenderWeaponTriWeak = this.children[17].value;
        defenderWeaponEffect = this.children[18].value;
    }

    });
});
