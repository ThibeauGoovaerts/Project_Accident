let armLeft = document.querySelector('.armLeft');
let armRight = document.querySelector('.armRight');

armLeft.addEventListener('mouseover', (e) => {
    armLeft.style.filter = "opacity(100%)";
    armRight.style.filter = "opacity(100%)";
})

armRight.addEventListener('mouseover', (e) => {
    armLeft.style.filter = "opacity(100%)";
    armRight.style.filter = "opacity(100%)";
})

armLeft.addEventListener('mouseout', (e) => {
    armLeft.style.filter = "opacity(30%)";
    armRight.style.filter = "opacity(30%)";
})

armRight.addEventListener('mouseout', (e) => {
    armLeft.style.filter = "opacity(30%)";
    armRight.style.filter = "opacity(30%)";
})


document.getElementById('switchFrontBackBody').addEventListener('click', () => {
    el = document.getElementById('switchFrontBackBody')

    if (el.checked) {
        document.querySelector('.chest').style.display = "none";
        document.querySelector('.back').style.display = "block";
    } else {
        document.querySelector('.chest').style.display = "block";
        document.querySelector('.back').style.display = "none";
    }
})

function clickItemLesionSeat(clicked_id, startZero, idDivClicked) {
    let details = document.getElementsByClassName("childElBody");
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
    if (document.getElementById(idDivClicked).classList.contains('clicked-human-body-part')) {
        document.getElementById(idDivClicked).classList.remove('clicked-human-body-part')
        newStyle = "none";
    } else {
        document.getElementById(idDivClicked).classList.add('clicked-human-body-part')
        newStyle = "block";
    }
    for (let i = 0; i < tab.length; i++) {
        tab[i].style.display = newStyle;
    }
}