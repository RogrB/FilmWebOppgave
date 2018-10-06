
function stemPåFilm(stemme) {
    var filmID = $("#filmIDSpan").html();
    $.ajax({
    url: '/Film/StemPåFilm/?FilmID=' + filmID + "&stemme=" + stemme,
    type: 'GET',
    dataType: 'json',
    contentType: "application/json;charset=utf-8",
    success: function (data) {
         if (data === "OK") {
            console.log("Stemme registrert");
            location.reload();
        }
        else if (data === "Feil innlogging") {
            stemmeFeedback("innlogging");
        }
        else {
            stemmeFeedback("Feil");
        }
    },
    error: function (x, y, z) {
        console.log("Feilet API kall for å stemme på film");
    }
    });
}

function stemmeFeedback(resultat) {
    var output = "";
    if (resultat === "innlogging") {
        output += "<div class='alert alert-danger alert-dismissible fade in'>";
        output += '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>';
        output += "<a href='/Film/Loginn'>Logg inn</a> for å stemme</div>";
    }
    else {
        output += "<div class='alert alert-danger alert-dismissible fade in'>";
        output += '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>';
        output += "Kunne ikke stemme</div>";
    }

    $("#stemmeFeedback").html(output);
}

function stjerneDisplay(antall) {
    var output = "";
    for (var i = 1; i <= antall; i++) {
        output += '<img src="../Content/images/gullstjerne.png" alt="Gi vurdering" width="25" id="stjerne' + i + '" onmouseout="clearStjerner()" onclick="stemPåFilm(' + i + ')" />';
    }
    var resterende = 6 - antall;
    for (var j = 1; j <= resterende; j++) {
        output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne' + i + '" onmouseover="stjerneDisplay(' + i + ');" onmouseout="clearStjerner()" />';
    }
    $("#stjerner").html(output);
}

function clearStjerner() {
    var output = "";
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne1" onmouseover="stjerneDisplay(1);" onmouseout="clearStjerner()" />';
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne2" onmouseover="stjerneDisplay(2);" onmouseout="clearStjerner()" />';
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne3" onmouseover="stjerneDisplay(3);" onmouseout="clearStjerner()" />';
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne4" onmouseover="stjerneDisplay(4);" onmouseout="clearStjerner()" />';
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne5" onmouseover="stjerneDisplay(5);" onmouseout="clearStjerner()" />';
    output += '<img src="../Content/images/nullstjerne.png" alt="Gi vurdering" width="25" id="stjerne6" onmouseover="stjerneDisplay(6);" onmouseout="clearStjerner()" />';
    $("#stjerner").html(output);
}
