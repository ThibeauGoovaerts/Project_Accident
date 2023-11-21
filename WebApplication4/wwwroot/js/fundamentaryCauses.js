function changeOrganisationVisibility() {
    let element = document.getElementById("organisationInput");
    let checkbox = document.getElementById("fundamentaryCausesOther");

    if (checkbox.checked) {
        element.classList.remove("invisible");
    } else {
        element.classList.add("invisible");
    }
}