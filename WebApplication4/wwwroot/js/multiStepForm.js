var currentTab = 0; // Current tab is set to be the first tab (0)
var tabCheckbox = [1,4,5,6,7,8,9,10]

const currentUrlMulti = window.location.href;
const AccidentIDMulti = currentUrlMulti.substring(currentUrlMulti.lastIndexOf('/') + 1)
const saveStringMulti = "accident_" + AccidentIDMulti + "_"
const hostNameMulti = window.location.protocol + "//" + window.location.host

if (localStorage.getItem(saveStringMulti + "ActualPage") != null) {
    currentTab = parseInt(localStorage.getItem(saveStringMulti + "ActualPage"));
}
showTab(currentTab); // Display the current tab
putOriginalColorsBack();

document.getElementById("home").href = hostNameMulti
//document.getElementsByClassName("screenResume")

function showTab(n) {
    localStorage.setItem(saveStringMulti + "ActualPage", n)
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        resumeIsup()
        //To get the last page, we need to submit the form
        if (n == x.length - 1) {
            document.getElementById("nextBtn").innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" fill="currentColor" class="bi bi-check" viewBox="0 0 16 16">' +
                '<path d="M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"/>' +
                '</svg>'
        } else {
            document.getElementById("nextBtn").innerHTML = '<svg xmlns = "http://www.w3.org/2000/svg" width = "64" height = "64" fill = "currentColor" class="bi bi-arrow-right-circle" viewBox = "0 0 16 16" >' +
                '<path fill-rule="evenodd" d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8zm15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H4.5z" />' +
                '</svg >'
        }
        document.getElementById("prevBtn").style.display = "inline";
    }
    // ... and run a function that displays the correct step indicator:
    fixStepIndicator(n)
}
function necessaryVerification(page) {
    elements = page.getElementsByClassName('necessaryField')    
    nbIncompleted = 0;
    for (i = 0; i < elements.length; i++) {        
        element = elements[i]

        switch (element.type) {
            case "text":
                if (element.value === "" || element.value == null) {
                    nbIncompleted++
                }
                break;
            case "datetime-local":
                if (element.value === "0001-01-01T00:00") {
                    nbIncompleted++
                }
                break;
            case "number":
                if (element.value == 0 || element.value == null || element.value == -1) {
                    nbIncompleted++
                }
                break;
            case "checkbox":
                    if (tabCheckbox.includes(currentTab)) {
                        nbIncompleted++
                    }
                break;
            case "range":
                if (element.value == -1) {
                    nbIncompleted++
                }
                break;
            case "textarea":
                if (element.value === "" || element.value == null) {
                    nbIncompleted++
                }
                break;
            default:
                break;
        }
                
    } 
    return nbIncompleted
}

function showPage(className) {
    x = document.getElementsByClassName("tab")
    x[currentTab].style.display = "none"
    oldPageClasse = x[currentTab].classList[1]
    oldPage = document.getElementsByClassName(oldPageClasse)
    oldPage[0].classList.remove("bg-primary")
    resIncompleted = necessaryVerification(x[currentTab])
    if (resIncompleted == 0) {
        oldPage[0].classList.add("bg-success")
        localStorage.setItem(saveStringMulti + "ColorAriane" + currentTab, "bg-success")
    } else if (resIncompleted != x[currentTab].getElementsByClassName('necessaryField').length) {
        oldPage[0].classList.add("bg-danger")
        localStorage.setItem(saveStringMulti + "ColorAriane" + currentTab, "bg-danger")
    } else if (tabCheckbox.includes(currentTab) && resIncompleted == 1) {
        oldPage[0].classList.add("bg-danger")
        localStorage.setItem(saveStringMulti + "ColorAriane" + currentTab, "bg-danger")
    }

    pageToShow = document.getElementsByClassName(className)
    pageToShow[1].style.display = "block"
    for (i = 0; i < x.length; i++) {
        if (x[i].style.display == "block") {
            currentTab = i
        }
    }
    showTab(currentTab)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Hide the current tab:
    x[currentTab].style.display = "none";

    oldPageClasse = x[currentTab].classList[1]
    oldPage = document.getElementsByClassName(oldPageClasse)
    oldPage[0].classList.remove("bg-primary")  
    resIncompleted = necessaryVerification(x[currentTab])
    if (resIncompleted == 0) {
        oldPage[0].classList.add("bg-success")
        localStorage.setItem(saveStringMulti + "ColorAriane" + currentTab, "bg-success")
    } else if (resIncompleted != x[currentTab].getElementsByClassName('necessaryField').length) {
        localStorage.setItem(saveStringMulti + "ColorAriane" + currentTab, "bg-danger")
        oldPage[0].classList.add("bg-danger")
    }
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
    if (currentTab >= x.length) {
        //...the form gets submitted:
        $("#formCreate").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].classList.remove("bg-primary");
    }
    //... and adds the "active" class to the current step:
    x[n].classList.remove("bg-success"); 
    x[n].classList.remove("bg-danger");
    x[n].classList.add("bg-primary");
}

function changeIsNecessary(tab) {
    for (i = 0; i < tab.length; i++) {
        x = document.getElementById(tab[i])
        if (x.classList.contains("necessaryField")) {
            x.classList.remove("necessaryField")
        } else {
            x.classList.add("necessaryField")
        }        
    }
}
function changeIsNecessaryCheckoxList(className) {
    x = document.getElementsByClassName(className)
    nbChecked = 0
    for (i = 0; i < x.length; i++) {
        if (x[i].checked == true) nbChecked++
    }
    if (nbChecked == 0) {        
        for (i = 0; i < x.length; i++) {
            x[i].classList.add("necessaryField")
        }
    } else {
        for (i = 0; i < x.length; i++) {
            x[i].classList.remove("necessaryField")
        }        
    }
}

function putOriginalColorsBack() {
    var x = document.getElementsByClassName("step");
    for (i = 0; i < document.getElementsByClassName('tab').length; i++) {
        color = localStorage.getItem(saveStringMulti + "ColorAriane" + i)
        if (color != null)
            x[i].classList.add(color)
    }
}

function resumeIsup() {
    var x = document.getElementsByClassName("step")
    var nbFinished = 0
    var nbPages = x.length
    for (i = 0; i < nbPages; i++) {
        if (x[i].classList.contains("bg-success")) {
            nbFinished++
        }
        if (currentTab == x.length - 1) {
            if (!(nbFinished == x.length)) {
                document.getElementById("nextBtn").disabled = true;
            } else {
                document.getElementById("nextBtn").disabled = false;
            }
        } else {
            document.getElementById("nextBtn").disabled = false;
        }
    }
}