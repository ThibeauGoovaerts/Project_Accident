give_image_clicker_effect()

var clickGeneral = 0
var cpt = 0
var mouseOver = 0

let elements = document.getElementsByClassName("parking_class");
// Quand on survole un element de parking il faut que les trois parties s'allument
for (let i = 0; i < elements.length; i++) {
    elements[i].addEventListener('mouseover', (event) => {
        // quand on survole, on mets un show sur les trois
        let classes = document.getElementsByClassName("parking_class");

        for (let i = 0; i < classes.length; i++) {
            classes[i].classList.add('show');
        }
    });

    elements[i].addEventListener('mouseout', (event) => {
        let classes = document.getElementsByClassName("parking_class");
        // quand on quitte avec la souris, on efface le show des trois parties
        for (let i = 0; i < classes.length; i++) {
            classes[i].classList.remove('show');
        }
    });
}
let allImageSnippets = document.getElementsByClassName("highlight-region");
for (let i = 0; i < allImageSnippets.length; i++) {
    // The css makes the snippet light up, the js will cancel out the background image
    allImageSnippets[i].addEventListener('mouseover', (event) => {
        let imageClass = document.getElementsByClassName("bg-image")[0];
        if (imageClass != undefined) {
            imageClass.classList.remove('bg-image');
            imageClass.classList.add('dissolve');
        }
    });

    //The css will fade out the snippet, the js will bring the background image back
    allImageSnippets[i].addEventListener('mouseout', (event) => {
        let imageClass = document.getElementsByClassName("dissolve")[0];
        if (imageClass != undefined) {
            imageClass.classList.remove('dissolve');
            imageClass.classList.add('bg-image');
        }
    });
}

function clickedOnElement(event) {
    if (document.getElementsByClassName('clicked-highlight-region').length > 0) {
        return;
    }
    let allImageSnippets = document.getElementsByClassName("highlight-region");
    // We copy the element in a new variable, because we are going to change his class and since
    // <allImageSnippets> is dependant on the class of the item, we need to copy it in a new variable

    el = event.target
    // For the same reason, we make a copy of the entire array
    copy_tab = [...allImageSnippets]
    // In case our element is undefined, the function can just return
    if (el == undefined) {
        return
    }
    // When a snippet is clicked, we put it's id in the input field that is needed in the controller
    document.getElementById("viewBagLocationID").value = el.classList[0];
    // We save the value locally
    saveLocally('viewBagLocationID')

    // We loop through all the snippets and remove the 'highlight-region' class that made them glow up 
    // on hover and gove them another class to recognize them when we want to refresh the map
    for (let j = 0; j < copy_tab.length; j++) {
        copy_tab[j].classList.add('non-clicked-highlight-region')
        copy_tab[j].classList.remove('highlight-region')
        // We add a click event to the snippet that will re-initialise the map when clicked
        // so that when a snippet is clicked, the user can refresh the map by clicking anywhere on the map
        copy_tab[j].removeEventListener('click', reinitialise_map, true)
        copy_tab[j].addEventListener('click', reinitialise_map, true);
    }

    // For the parking, we do the same loop action as for the other snippets, we remove the parking_class class 
    // and add a new class to be able to find them again when the map is refreshed
    parkingNonSelect = document.getElementsByClassName('parking_class')
    copy_tab = [...parkingNonSelect]
    for (let j = 0; j < copy_tab.length; j++) {
        copy_tab[j].classList.add('non-clicked-parking-class')
        copy_tab[j].classList.remove('parking_class')
    }

    // The snippet that was clicked will recieve a new class meaning it needs to stay lit up
    el.classList.add('clicked-highlight-region')
    // We remove the general class that we added to all snippets before
    el.classList.remove('non-clicked-highlight-region')

    // We get the background image in a variable and change its class to 
    // bg - image - clicked so our css can fade it out
    let imageClass = document.getElementsByClassName("dissolve")[0];
    if (imageClass == undefined) {
        imageClass = document.getElementsByClassName("bg-image")[0];
    }
    if (imageClass == undefined) {
        imageClass = document.getElementsByClassName("bg-image-clicked")[0];
    }

    imageClass.classList.remove('dissolve');
    imageClass.classList.remove('bg-image');
    imageClass.classList.add('bg-image-clicked');
    // We add an eventListener to out background map, so when clicked it will refresh the map
    if (clickGeneral == 0) {
        imageClass.addEventListener('click', reinitialise_map, true)
        clickGeneral++;
    }
}

function give_image_clicker_effect() {
    // To give the highlight effect to the image, we get all the elements that need to be highlighted in an array
    let allImageSnippets = document.getElementsByClassName("highlight-region");
    // We then add three functions to all these, the mouseover, the mouseout and the clicked
    for (let i = 0; i < allImageSnippets.length; i++) {        
        cpt = i
        // When we click on a snippet, the background image will stay faded out and the other snippets won't light up on hover
        // The selected snippet will stay lit up
        allImageSnippets[i].removeEventListener('click', clickedOnElement, true);
        allImageSnippets[i].addEventListener('click', clickedOnElement, true);
    }
    //mouseOver++;
}

// Function to refresh the map, this means de-highligt the selected area, and make all areas clickable again
function reinitialise_map() {
    // We get the background image that is clicked, if this is undefined, it means the function has been called out of context
    el = document.getElementsByClassName('bg-image-clicked')[0]
    if (el != undefined) {
        // We change the background image back to non-clicked
        el.classList.add('bg-image')
        el.classList.remove('bg-image-clicked')

        // We reassemble all snippets in an array and copy them to make the array non dependant
        // from the class name since we modify the classname
        // We modify the classnames to make the snippets clickable again
        let nonClickedHighlight = document.getElementsByClassName('non-clicked-highlight-region')
        copy_tab = [...nonClickedHighlight]
        for (let i = 0; i < copy_tab.length; i++) {
            copy_tab[i].classList.add('highlight-region')
            copy_tab[i].classList.remove('non-clicked-highlight-region')
        }

        // We reassemble all parking-snippets in an array and copy them to make the array non dependant
        // from the class name since we modify the classname
        // We modify the classnames to make the parking areas clickable again
        parking_els = document.getElementsByClassName('non-clicked-parking-class')
        copy_tab = [...parking_els]
        for (let i = 0; i < copy_tab.length; i++) {
            copy_tab[i].classList.add('parking_class')
            copy_tab[i].classList.remove('non-clicked-parking-class')
        }

        // We de flash the selected snippet and prepare it to be selected again
        document.getElementsByClassName('clicked-highlight-region')[0].classList.add('highlight-region')
        document.getElementsByClassName('clicked-highlight-region')[0].classList.remove('clicked-highlight-region')
        // We add the eventListeners again to all our snippets
        give_image_clicker_effect()
    }
}