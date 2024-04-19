function searchDashboard() {
    var input, filter, ul, li, a, i, txtValue;

    input = document.getElementById("inputDashboard");
    filter = input.value.toUpperCase();

    ul = document.getElementById("list-displayed-dashboard");
    li = ul.getElementsByTagName("li");

    for (i = 0; i < li.length; i++) {
        a = li[i];
        txtValue = a.textContent || a.innerText;

        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function searchApplication() {
    var input, filter, ul, li, a, i, txtValue;

    input = document.getElementById("inputApplication");
    filter = input.value.toUpperCase();

    ul = document.getElementById("list-displayed-application");
    li = ul.getElementsByTagName("li");

    for (i = 0; i < li.length; i++) {
        a = li[i];
        txtValue = a.textContent || a.innerText;

        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}