function closeRightSideNav() {
    document.getElementById("rightSideNavModal").style.display = "none";
}


function openRightSideNavModal(id, url) {

    // Open modal overlay
    openModalOverlay();

    var isRightSideNavModalHidden = document.getElementById('rightSideNavModal').hidden;

    if (isRightSideNavModalHidden) {
        document.getElementById('rightSideNavModal').hidden = false;
    }


    document.getElementById('rightIFrame').src = url;

    //if (id === 1) {
    //    document.getElementById('rightIFrame').src = url;
    //}
    //else if (id === 2) {
    //    document.getElementById('rightIFrame').src = url;
    //}
    //else if (id === 3) {
    //    document.getElementById('rightIFrame').src = url;
    //}
}


function openModalOverlay() {
    document.getElementById("rightSideNavModal").style.display = "none";

    setTimeout(function () {
        document.getElementById("rightSideNavModal").style.display = "block";
    }, 3000);
}

function closeModalOverlay() {
    document.getElementById("rightSideNavModal").style.display = "none";
}


function closeMaximizeModalOverlay() {

    // Close modal overlay
    closeModalOverlay();

    // Close right side navigation bar
    closeRightSideNav();
}