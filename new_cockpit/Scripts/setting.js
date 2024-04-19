function saveDashboard() {

    var li = document.getElementById("setDashboard").getElementsByTagName("li");

    var listSetDashboard = new Array();
    for (var i = 0; i < li.length; i++) {
        listSetDashboard.push(li[i].innerText);
    }

    console.log("listSetDashboard", listSetDashboard);
}

function saveApplication() {

    var li = document.getElementById("setApplication").getElementsByTagName("li");

    var listSetApplication = new Array();
    for (var i = 0; i < li.length; i++) {
        listSetApplication.push(li[i].innerText);
    }

    console.log("listSetApplication", listSetApplication);
}