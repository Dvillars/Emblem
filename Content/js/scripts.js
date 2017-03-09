
$("...")
$("...").click(function(){
  this.getElementByName("")
}

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

$(function() {

)};

// $('.dropdown-button').dropdown({
//     inDuration: 300,
//     outDuration: 225,
//     constrainWidth: false, // Does not change width of dropdown to that of the activator
//     hover: true, // Activate on hover
//     gutter: 0, // Spacing from edge
//     belowOrigin: false, // Displays dropdown below the button
//     alignment: 'left', // Displays dropdown with edge aligned to the left of button
//     stopPropagation: false // Stops event propagation
//   }
// );
