function startTime() {
    var today = new Date();

    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();

    // format as am / pm
    var ampm = h >= 12 ? 'PM' : 'AM';
    h = h % 12;
    h = h ? h : 12;

    m = m < 10 ? '0' + m : m;
    s = s < 10 ? '0' + s : s;

    document.getElementById("timerText").innerHTML = h + ":" + m + ":" + s + " " + ampm;
    var t = setTimeout(startTime, 500);

    // Current date time
    currentDateTime();
}

function currentDateTime() {
    var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

    var today = new Date();

    var month = today.getMonth();
    var day = today.getDay();
    var date = today.getDate();
    var year = today.getFullYear();

    document.getElementById("currentDateTime").innerHTML = dayNames[day] + ", " + date + " " + monthNames[month] + " " + year;
}