var isCustomSortingProcessing = false;
var previousValues = {};
var comboNames = [];
function SetSortingUnit(combo, rbl, comboName) {
    var unitFieldName = combo.GetValue();
    if ((combo.GetSelectedIndex() == -1 || combo.GetSelectedIndex() == 0) && clientHiddenField.Contains(comboName)) {
        if (previousValues[comboName] != null && previousValues[comboName] != "") //value was already cleared
            clientHiddenField.Set(comboName, new Object({ Order: rbl.GetValue(), FieldName: unitFieldName, ClearSort: previousValues[comboName] }));
    }
    else if (clientHiddenField.Contains(comboName)) { //editing existing combo
        //check if there were sorting for the same field in any previous combos  and clear it 
        for (var i = 0; i < comboNames.length; i++) {
            var item = clientHiddenField.Get(comboNames[i])

            if (item != null && item.ClearSort == unitFieldName) {
                clientHiddenField.Remove(comboNames[i]);
            }
        }
        clientHiddenField.Set(comboName, new Object({ Order: rbl.GetValue(), FieldName: unitFieldName }));
    }
    else { // new combo
        clientHiddenField.Add(comboName, new Object({ Order: rbl.GetValue(), FieldName: unitFieldName }));
    }
    previousValues[comboName] = combo.GetValue();
}
function OnInit(s, e, comboName) {
    comboNames.push(comboName);
    previousValues[comboName] = s.GetValue();
}