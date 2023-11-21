function clickItemMesure(clicked_id, startZero) {
    let details = document.getElementsByClassName("childEl");
    tab = []
    tabChecked = []
    if (startZero == "True") {
        clicked_id = clicked_id - 1
    }
    for (let i = 0; i < details.length; i++) {
        if (Math.floor(details[i].classList[1] / 10) == clicked_id) {
            tab.push(details[i])
        }
        if (details[i].getElementsByTagName("input")[0].checked) {
            tabChecked.push(details[i])
        }
    }
    if (tab[0].style.display == "none") {
        newStyle = "block";
    } else {
        newStyle = "none";
    }
    for (let i = 0; i < tab.length; i++) {
        tab[i].style.display = newStyle;
    }
    for (let i = 0; i < tabChecked.length; i++) {
        tabChecked[i].style.display = "block";
    }
}
