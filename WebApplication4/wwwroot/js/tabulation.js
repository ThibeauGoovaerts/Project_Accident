const formCreate = document.getElementById('formCreate');
const allTabs = formCreate.getElementsByClassName('tab');

function getTabInFocus() {
    for (i = 0; i < allTabs.length; i++)
        if (allTabs[i].style.display === "block")
            return i
}

function isHidden(el) {
    return (el.offsetParent === null)
}

function setFocus(el) {
    el.focus();
}

document.addEventListener('keydown', function (event) {
    if (event.keyCode == 39) {
        event.preventDefault();
        elements_to_focus = Array.from(allTabs[getTabInFocus()].getElementsByClassName('tabulation_needed'))
        if (getTabInFocus() == 0) {
            elements_to_focus.push(document.getElementById('nextBtn'))
        } else {
            elements_to_focus.push(document.getElementById('prevBtn'))
            elements_to_focus.push(document.getElementById('nextBtn'))
        }
        elementInFocus = document.activeElement;
        if (!elements_to_focus.includes(elementInFocus))
            setFocus(elements_to_focus[0])
        else {
            newIndex = elements_to_focus.indexOf(elementInFocus) + 1
            if (newIndex < elements_to_focus.length)
                if (isHidden(elements_to_focus[newIndex]) || elements_to_focus[newIndex].parentElement.classList.contains('invisible')) {
                    while ((isHidden(elements_to_focus[newIndex]) || elements_to_focus[newIndex].parentElement.classList.contains('invisible')) && newIndex < elements_to_focus.length)
                        newIndex += 1
                    if (newIndex < elements_to_focus.length)
                        elements_to_focus[newIndex].focus();
                }
            if (newIndex < elements_to_focus.length)
                setFocus(elements_to_focus[newIndex])
            else
                setFocus(elements_to_focus[0])
        }
    } else if (event.keyCode == 37) {
        event.preventDefault();
        elements_to_focus = Array.from(allTabs[getTabInFocus()].getElementsByClassName('tabulation_needed'))
        if (getTabInFocus() == 0) {
            elements_to_focus.push(document.getElementById('nextBtn'))
        } else {
            elements_to_focus.push(document.getElementById('prevBtn'))
            elements_to_focus.push(document.getElementById('nextBtn'))
        }
        elementInFocus = document.activeElement;
        if (!elements_to_focus.includes(elementInFocus))
            elements_to_focus[0].focus();
        else {
            newIndex = elements_to_focus.indexOf(elementInFocus) - 1
            if (newIndex >= 0)
                if (isHidden(elements_to_focus[newIndex]) || elements_to_focus[newIndex].parentElement.classList.contains('invisible')) {
                    while ((isHidden(elements_to_focus[newIndex]) || elements_to_focus[newIndex].parentElement.classList.contains('invisible')) && newIndex >= 0)
                        newIndex -= 1
                    if (newIndex < elements_to_focus.length)
                        elements_to_focus[newIndex].focus();
                }
            if (newIndex >= 0)
                setFocus(elements_to_focus[newIndex])
            else {
                setFocus(elements_to_focus[elements_to_focus.length-1])
            }
        }
    }
});