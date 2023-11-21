const currentUrl = window.location.href;
const ReportID = currentUrl.substring(currentUrl.lastIndexOf('/') + 1)
const saveString = "report_" + ReportID + "_"
const hostName = window.location.protocol + "//" + window.location.host
onLaunch()


function onLaunch() {
    if (localStorage.getItem(saveString + "WasPresent") != null) {
        if (localStorage.getItem(saveString + "WasPresent") === "false") {
            document.getElementById('WasPresent').click()
        }
    }
    if (localStorage.getItem(saveString + "testimony")) {
        document.getElementById('testimonyAccident').value = localStorage.getItem(saveString + "testimony");
    }
}

function saveLocallyTestimonyTest() {
    let value = document.getElementById('testimonyAccident').value;
    let saveValue = saveString + "testimony"
    localStorage.setItem(saveValue, value)
    if (value.length % 7 == 0 && value.length > 0) {
        saveTestimony();
    }
}

function SaveLocallyWasPresent() {
    let value = document.getElementById('WasPresent').checked;
    let saveValue = saveString + "WasPresent"
    localStorage.setItem(saveValue, value)
}

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

async function saveTestimony() {
    const form = $('#__AjaxAntiForgeryForm');
    const token = $('input[name="__RequestVerificationToken"]', form).val();
    data = {
        __RequestVerificationToken: token,
        idReport: ReportID,
        wasPresent: localStorage.getItem(saveString + "WasPresent"),
        testimony: localStorage.getItem(saveString + "testimony")
    }

    if (await doRequest(data, '/Accidents/SaveTestimonyAjaxWithTestimony/')) {
        console.log("OK")
    } else {
        console.log("raté")
    }
}