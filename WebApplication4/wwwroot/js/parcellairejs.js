const currentUrl = window.location.href;
const AccidentID = currentUrl.substring(currentUrl.lastIndexOf('/') + 1)
const saveString = "accident_" + AccidentID + "_"
const hostName = window.location.protocol + "//" + window.location.host

initialisePageWithLocalStorage()

async function doRequest(dataRequest, url) {
    success_value = false
    await $.ajax({
        url: hostName + url,
        type: 'POST',
        data: dataRequest,
        success: function (data) {
            if (data === "Success")
                success_value = true
        }
    });
    return success_value
}

async function saveVictim() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        VictimLastname: localStorage.getItem(saveString + "LastnameOfVictim"),
        VictimFirstname: localStorage.getItem(saveString + "FirstnameOfVictim"),
        ExternalFirmName: localStorage.getItem(saveString + "externalFirm"),
        ExternalFirmChecked: localStorage.getItem(saveString + "externalCheck")
    }
    if (await doRequest(data, '/Accidents/SaveVictimAjax/')) {
        //localStorage.removeItem(saveString + "nameOfVictim")
        //localStorage.removeItem(saveString + "externalFirm")
        //localStorage.removeItem(saveString + "externalCheck")
    } else {
        console.log("raté")
    }
}

async function saveTestimony() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        wasPresent: localStorage.getItem(saveString + "WasPresent"),
        testimony: localStorage.getItem(saveString + "testimonyAccident")
    }

    if (await doRequest(data, '/Accidents/SaveTestimonyAjax/')) {
        //localStorage.removeItem(saveString + "WasPresent")
        //localStorage.removeItem(saveString + "testimonyAccident")
    } else {
        console.log("raté")
    }
}

async function saveReaction() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        reaction: localStorage.getItem(saveString + "reaction")
    }

    if (await doRequest(data, '/Accidents/saveReactionAjax/')) {
        //localStorage.removeItem(saveString + "Reaction")
    } else {
        console.log("raté")
    }
}

async function saveAccident() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        accidentDateTime: localStorage.getItem(saveString + "AccidentDateTime"),
        lieuID: localStorage.getItem(saveString + "viewBagLocationID"),
        detailLieu: localStorage.getItem(saveString + "LocationDetail")
    }

    if (await doRequest(data, '/Accidents/SaveAccidentAjax/')) {
        //localStorage.removeItem(saveString + "AccidentDateTime")
        //localStorage.removeItem(saveString + "viewBagLocationID")
        //localStorage.removeItem(saveString + "LocationDetail")
    } else {
        console.log("raté")
    }
}

async function saveVictimActivity() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        usualActivity: localStorage.getItem(saveString + "UsualFunction"),
        activity: localStorage.getItem(saveString + "victimActivity"),
    }
    if (await doRequest(data, '/Accidents/SaveVictimActivityAjax/')) {
        //localStorage.removeItem(saveString + "UsualFunction")
        //localStorage.removeItem(saveString + "victimActivity")
    } else {
        console.log("raté")
    }
}

async function saveWorkStopped() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        workPaused: localStorage.getItem(saveString + "workStopped"),
        workPausedDT: localStorage.getItem(saveString + "DateTimeWorkStopped"),
        workResumed: localStorage.getItem(saveString + "workResumed"),
        workResumedDT: localStorage.getItem(saveString + "DateTimeWorkResumed"),
    }
    if (await doRequest(data, '/Accidents/SaveVictimPauseAjax/')) {
        //localStorage.removeItem(saveString + "workStopped")
        //localStorage.removeItem(saveString + "DateTimeWorkStopped")
        //localStorage.removeItem(saveString + "workResumed")
        //localStorage.removeItem(saveString + "DateTimeWorkResumed")
    } else {
        console.log("raté")
    }
}

async function saveProtections() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        protectionsVictim: JSON.parse(localStorage.getItem(saveString + "protection")),
    }
    if (await doRequest(data, '/Accidents/SaveVictimProtectionsAjax/')) {
        localStorage.setItem(saveString + "protectionsaved", false)
    } else {
        console.log("raté")
    }
}

async function saveDeviations() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        deviations: JSON.parse(localStorage.getItem(saveString + "deviation")),
    }
    if (await doRequest(data, '/Accidents/SaveDeviationsAjax/')) {
        localStorage.setItem(saveString + "deviationsaved", false)
    } else {
        console.log("raté")
    }
}

async function saveAgents() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        agentMateriels: JSON.parse(localStorage.getItem(saveString + "agent")),
    }
    if (await doRequest(data, '/Accidents/SaveAgentMaterielAjax/')) {
        localStorage.setItem(saveString + "agentsaved", false)
    } else {
        console.log("raté")
    }
}

async function saveSeats() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        seats: JSON.parse(localStorage.getItem(saveString + "seat")),
    }
    if (await doRequest(data, '/Accidents/SaveLesionSeatAjax/')) {
        localStorage.setItem(saveString + "seatsaved", false)
    } else {
        console.log("raté")
    }
}

async function saveNatures() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        natures: JSON.parse(localStorage.getItem(saveString + "nature")),
    }
    if (await doRequest(data, '/Accidents/SaveLesionNaturesAjax/')) {
        localStorage.setItem(saveString + "naturesaved", false)
    } else {
        console.log("raté")
    }
}

async function saveCauses() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        causes: JSON.parse(localStorage.getItem(saveString + "cause")),
    }
    if (await doRequest(data, '/Accidents/SaveCausesAjax/')) {
        localStorage.setItem(saveString + "causesaved", false)
    } else {
        console.log("raté")
    }
}

async function SaveDirectMesuresAjax() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        directMesures: JSON.parse(localStorage.getItem(saveString + "mesureDirect")),
    }
    if (await doRequest(data, '/Accidents/SaveDirectMesuresAjax/')) {
        localStorage.setItem(saveString + "mesureDirectsaved", false)
    } else {
        console.log("raté")
    }
}

async function SaveProposedMesuresAjax() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        proposedMesures: JSON.parse(localStorage.getItem(saveString + "mesureProp")),
    }
    if (await doRequest(data, '/Accidents/SaveProposedMesuresAjax/')) {
        localStorage.setItem(saveString + "mesurePropsaved", false)
    } else {
        console.log("raté")
    }
}

async function saveProbability() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();

    data = {
        __RequestVerificationToken: token,
        idAccident: AccidentID,
        probability: localStorage.getItem(saveString + "Probability"),
        gravity: localStorage.getItem(saveString + "Gravity"),
    }
    if (await doRequest(data, '/Accidents/SaveProbabilityAjax/')) {
        //localStorage.removeItem(saveString + "Probability")
        //localStorage.removeItem(saveString + "Gravity")
    } else {
        console.log("raté")
    }
}

function saveLocally(idEl) {
    const el = document.getElementById(idEl)
    if (el == null)
        return

    const saveStringStorage = saveString + idEl

    switch (el.tagName) {
        case "INPUT":
            switch (el.type) {
                case "checkbox":
                    localStorage.setItem(saveStringStorage, el.checked);
                    break
                default:
                    localStorage.setItem(saveStringStorage, el.value);
                    break
            }
            break
        case "TEXTAREA":
            localStorage.setItem(saveStringStorage, el.value);
            break
    }
    decideToSaveDB();
}

function saveLocallyCustom(idEl, whatItem) {
    const el = document.getElementById(idEl)
    if (el == null)
        return

    const saveStringStorage = saveString + whatItem
    array = JSON.parse(localStorage.getItem(saveStringStorage));
    if (array == null) {
        array = new Array();
    }
    if (el.checked) {
        if (!array.includes(idEl))
            array.push(idEl);
    }
    else {
        array.splice(array.indexOf(idEl), 1)
    }
    localStorage.setItem(saveStringStorage, JSON.stringify(array));
    localStorage.setItem(saveStringStorage + "saved", true);
    decideToSaveDB
}

function decideToSaveDB() {
    if ((localStorage.getItem(saveString + "LastnameOfVictim") && localStorage.getItem(saveString + "FirstnameOfVictim") && localStorage.getItem(saveString + "externalCheck") == "false") || (localStorage.getItem(saveString + "LastnameOfVictim") && localStorage.getItem(saveString + "FirstnameOfVictim") && localStorage.getItem(saveString + "externalFirm") && localStorage.getItem(saveString + "externalCheck"))) {
        saveVictim()
    }
    if (localStorage.getItem(saveString + "AccidentDateTime") && localStorage.getItem(saveString + "viewBagLocationID") && localStorage.getItem(saveString + "LocationDetail")) {
        saveAccident()
    }
    if (localStorage.getItem(saveString + "WasPresent") && localStorage.getItem(saveString + "testimonyAccident")) {
        saveTestimony()
    }
    if (localStorage.getItem(saveString + "reaction")) {
        saveReaction()
    }
    if (localStorage.getItem(saveString + "victimActivity")) {
        saveVictimActivity()
    }
    if (localStorage.getItem(saveString + "Probability") && localStorage.getItem(saveString + "Gravity")) {
        saveProbability()
    }
    if (localStorage.getItem(saveString + "workStopped") && localStorage.getItem(saveString + "DateTimeWorkStopped") && localStorage.getItem(saveString + "workResumed") && localStorage.getItem(saveString + "DateTimeWorkResumed")) {
        saveWorkStopped()
    }
    if (document.getElementById('tabProtections').style.display === "none" && localStorage.getItem(saveString + "protection") && localStorage.getItem(saveString + "protectionsaved")) {
        saveProtections()
    }
    if (document.getElementById('tabDeviation').style.display === "none" && localStorage.getItem(saveString + "deviation") && localStorage.getItem(saveString + "deviationsaved")) {
        saveDeviations()
    }
    if (document.getElementById('tabAgentMateriel').style.display === "none" && localStorage.getItem(saveString + "agent") && localStorage.getItem(saveString + "agentsaved")) {
        saveAgents()
    }
    if (document.getElementById('tabCauses').style.display === "none" && localStorage.getItem(saveString + "cause") && localStorage.getItem(saveString + "causesaved")) {
        saveCauses()
    }
    if (document.getElementById('tabMesures').style.display === "none" && localStorage.getItem(saveString + "mesureDirect") && localStorage.getItem(saveString + "mesureDirectsaved")) {
        SaveDirectMesuresAjax()
    }
    if (document.getElementById('tabMesures').style.display === "none" && localStorage.getItem(saveString + "mesureProp") && localStorage.getItem(saveString + "mesurePropsaved")) {
        SaveProposedMesuresAjax()
    }
    if (document.getElementById('screenSeat').style.display === "none" && localStorage.getItem(saveString + "seat") && localStorage.getItem(saveString + "seatsaved")) {
        saveSeats()
    }
    if (document.getElementById('screenNature').style.display === "none" && localStorage.getItem(saveString + "nature") && localStorage.getItem(saveString + "naturesaved")) {
        saveNatures()
    }
}

function putValueBackLocallyArrays() {
    const allDifferentArrays = ["protection", "deviation", "agent", "cause", "mesureDirect", "mesureProp", "nature", "seat"]
    for (k = 0; k < allDifferentArrays.length; k++) {
        let saveStringStorage = saveString + allDifferentArrays[k];
        let array = JSON.parse(localStorage.getItem(saveStringStorage));
        if (array != null) {
            for (j = 0; j < array.length; j++) {
                document.getElementById(array[j]).click();
                document.getElementById(array[j]).parentElement.style.display = "block";
            }
        } 
    }
}

function initialisePageWithLocalStorage() {
    const allDifferentInputs = ["LastnameOfVictim", "FirstnameOfVictim", "externalCheck", "externalFirm", "AccidentDateTime", "viewBagLocationID", "testimonyAccident",
        "LocationDetail", "WasPresent", "reaction", "UsualFunction", "victimActivity", "workStopped",
        "DateTimeWorkStopped", "workResumed", "DateTimeWorkResumed", "Probability", "Gravity"]

    if (localStorage.getItem(saveString + "Probability") != null)
        document.getElementById("probabId").innerHTML = "Probabilité d'occurence: " + localStorage.getItem(saveString + "Probability") + "%";
    if (localStorage.getItem(saveString + "Gravity") != null)
        document.getElementById("gravitId").innerHTML = "Gravité des pertes: " + localStorage.getItem(saveString + "Gravity") + "%";

    for (i = 0; i < allDifferentInputs.length; i++) {
        if (localStorage.getItem(saveString + allDifferentInputs[i]) != null) {
            el = document.getElementById(allDifferentInputs[i])
            switch (el.tagName) {
                case "INPUT":
                    switch (el.type) {
                        case "checkbox":
                            el.checked = localStorage.getItem(saveString + allDifferentInputs[i])
                            break
                        default:
                            el.value = localStorage.getItem(saveString + allDifferentInputs[i])
                            break
                    }
                    break
                case "TEXTAREA":
                    el.value = localStorage.getItem(saveString + allDifferentInputs[i])
                    break
            }
        }
    }
    putValueBackLocallyArrays()
}