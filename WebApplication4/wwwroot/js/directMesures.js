function changeMesureVisibility() {
    let element = document.getElementById("mesureInput");
    let checkbox = document.getElementById("mesureAppliqueeAutre");

    if (checkbox.checked) {
        element.classList.remove("invisible");
    } else {
        element.classList.add("invisible");
    }
}