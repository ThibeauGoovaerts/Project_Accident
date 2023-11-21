var tabCheckboxChosed = []

function noneChosen(className) {
    x = document.getElementsByClassName(className)
    
    if (x[0].checked == false) {
        for (i = 1; i < x.length; i++) {
            if (tabCheckboxChosed.includes(i)) {
                x[i].checked = true
            }
        }
    } else {
        for (i = 1; i < x.length; i++) {
            if (x[i].checked == true) {
                if (!tabCheckboxChosed.includes(i)) {
                    tabCheckboxChosed.push(i)
                }                
                x[i].checked = false
            } else {
                if (tabCheckboxChosed.includes(i)) {
                    var index = tabCheckboxChosed.indexOf(i)
                    tabCheckboxChosed.splice(index, 1)
                }
            }            
        }
    }
}

function someChosen() {
    document.getElementById('protection_aucune').checked = false;
    x = document.getElementsByClassName("check-protections")
    if (x[0].checked == true)
        for (i = 1; i < x.length; i++) {
            if (tabCheckboxChosed.includes(i)) {
                x[i].checked = true
            }
        }
}