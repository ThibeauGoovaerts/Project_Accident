/*
    Generic function when we click on a categorie, it will show the detail on the right side of the screen, 
    the function relies on the code of the detail and the id of the categorie.
    The function takes two parameters, the id in the database of the item that is clicked and the fact that the series starts at zero.
    For the function to work, the code of the detail should be the second class parameter in it's div
    The code that is put as commentary can be uncommented to decheck the checkboxes when the categorie is dechecked, if the client would want this option
 */

function clickItemDeviation(parentID, clicked_id, startZero) {
    // We get all the divs from the page with the details in an array
    let details = document.getElementsByClassName("childElDeviation");

    // if the id of the code starts with a 00 in the database, the startZero parameter should be true, 
    // we will first substract 1 from the id to be able to compare the id and the code
    if (startZero == "True") {
        clicked_id = clicked_id - 1
    }

    // We loop over all the details and divide them into two arrays, the ones that belong to the categorie that is clicked, 
    // and the ones that are clicked(possibly from another categorie) (only if we need to decheck them, see header)
    tab = []
    //tabChecked = []
    for (let i = 0; i < details.length; i++) {
        // we do a whole division with the code of the details to compare to the id of the categorie, 
        // this gets rid of the subcategorie of the detail
        id_to_compare = Math.floor(details[i].classList[1] / 10)
        // if the 'id_to_compare' is still bigger then 10 (only in the case of the materiel agent, 
        // since there are more then 10 details per categorie) we re-do a whole division to get the id of the categorie
        if (id_to_compare >= 10) {
            id_to_compare = Math.floor(id_to_compare / 10)
        }

        if (id_to_compare == clicked_id) {
            tab.push(details[i])
        }
        /*
        if (details[i].getElementsByTagName("input")[0].checked) {
            tabChecked.push(details[i])
        }*/
    }

    // We loop through all the tabs to change their view, is they were not visible, they will be,
    // if they are visible and not checked, they dissapear
    for (let i = 0; i < tab.length; i++) {
        if (document.getElementById(parentID).checked)
            tab[i].style.display = "block";
        else if (!tab[i].getElementsByTagName('input')[0].checked)
            tab[i].style.display = "none";
        else
            tab[i].style.display = "block";
    }

    // If the toggle button is off and we click a categorie, we re execute the searchbar function to filter the categories
    if (!document.getElementById('showAllParentsDeviations').checked) {
        SearchBarInAdd('listDeviations', 'searchBarDeviation')
    }

    /*tabChecked_copy = [...tabChecked]
    for (let i = 0; i < tabChecked_copy.length; i++) {
        tabChecked_copy[i].getElementsByTagName('input')[0].checked = false;
    }*/
}

/*
    This function will search what is typed in the searchbar in the categories and in the details, 
    if there is nothing in the searchbar, the default behaviour of the page will continue.
    The function takes as parameter the id of the list it applies to and the id of the searchbar itself.
 */
function SearchBarInAddDeviation(idList, idSearchBar) {
    let input, filter, a, i, txtValue;
    input = document.getElementById(idSearchBar);
    // filter will be what we typed in the searchbar
    filter = input.value.toUpperCase();
    // we normalize the filter so that no accents are takes into account
    filter = filter.normalize("NFD").replace(/\p{Diacritic}/gu, "")

    // We get an array with all the categories
    let listPossession = $("#" + idList),
        li = listPossession.children();

    // We loop through all the categories
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("label")[0]; // a will contain the label for each categorie
        txtValue = a.innerText;
        txtValue = txtValue.normalize("NFD").replace(/\p{Diacritic}/gu, "") // txtValue will contain the normalized value of the label

        // if the filter is empty, we will either show all the categories, either hide them all, depending on the state of the client toggle-button
        if (filter === "") {
            if (document.getElementById('showAllParentsDeviations').checked) {
                li[i].style.display = "";
            } else { // we verify if the categorie-label has been checked, if so it does not dissapear
                if (li[i].getElementsByTagName("input")[0].checked) {
                    li[i].style.display = "";
                } else {
                    li[i].style.display = "none";
                }
            }
        } else {
            // if the filter contains a value, we will compare it with the value of the label, if there is an occurence, we display the label
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else { // if there is no occurence in the label of our filter we verify if the categorie-label has been checked, if so it does not dissapear
                if (li[i].getElementsByTagName("input")[0].checked) {
                    li[i].style.display = "";
                } else {
                    li[i].style.display = "none";
                }
            }
        }
    }

    // we get an array with all the details
    let detail = $("#" + 'listDeviationDetails'),
        listDetails = detail.children();

    // we loop through all the details
    for (i = 0; i < listDetails.length; i++) {
        a = listDetails[i].getElementsByTagName("label")[0];
        txtValue = a.innerText;
        txtValue = txtValue.normalize("NFD").replace(/\p{Diacritic}/gu, "") // txtValue will contain the normalized value of the details label

        // if the filter is empty, all the details that have not been checked will dissapear
        if (filter === "") {
            if (listDetails[i].getElementsByTagName("input")[0].checked) {
                listDetails[i].getElementsByTagName('div')[0].style.display = "block";
            } else {
                listDetails[i].getElementsByTagName('div')[0].style.display = "none";
            }
        } else { // if the filter contains a value, we will compare it with the value of the label, if there is an occurence, we display the detail and it's categorie
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                listDetails[i].getElementsByTagName('div')[0].style.display = "block";

                // we get the categorie by comparing the id and the code from the detail
                id_to_compare = Math.floor(listDetails[i].classList[0] / 10)
                if (id_to_compare >= 10) {
                    id_to_compare = Math.floor(id_to_compare / 10)
                }
                // We display the categorie
                document.getElementsByClassName('deviationID' + id_to_compare)[0].style.display = "";
            } else {
                // if there is no occurence of the filter in the detail, we verify if the detail has been checked, if not we stop displaying it
                if (listDetails[i].getElementsByTagName("input")[0].checked) {
                    listDetails[i].getElementsByTagName('div')[0].style.display = "block";
                } else {
                    listDetails[i].getElementsByTagName('div')[0].style.display = "none";
                }
            }
        }
    }
}

/**
 * The function clickReactDetail will react to the click on a detail, if the click checks the detail, 
 * the function will also check the categorie in case the user did not do this himself.
 * if the detail is deseleceted then we hide the detail if the categorie is not selected.
 * */
function clickReactDetailDeviation(categorieID, detailID) {
    if (document.getElementById(detailID).getElementsByTagName('input')[0].checked) {
        document.getElementById(categorieID).checked = true;
    } else {
        if (!document.getElementById(categorieID).checked) {
            document.getElementsByClassName(detailID)[0].style.display = 'none'
        }
    }
}


/*
    The function to show all categories in the left column, it can also be used to hide all categories in the right column.
    The categories that are checked will also stay visible and stay checked.
 */
document.getElementById('showAllParentsDeviations').addEventListener('click', () => {

    // the slider element
    el = document.getElementById('showAllParentsDeviations')

    //All the categories
    child_els = $("#" + 'listDeviations').children();

    if (el.checked) {
        //Display all the categories
        for (let i = 0; i < child_els.length; i++) {
            child_els[i].style.display = ""
        }
    } else {
        //Hide all categories unless if they are checked, if we would like to hide them, uncomment the commented code and vise versa in the if statement
        for (let i = 0; i < child_els.length; i++) {
            child_els[i].style.display = "none"
            if (child_els[i].getElementsByTagName('input')[0].checked) {
                child_els[i].style.display = ""
                //child_els[i].getElementsByTagName('input')[0].click();
            }
        }
    }
})