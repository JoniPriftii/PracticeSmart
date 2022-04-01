function DisplayModalStacked(url, modalNr, data) {
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        success: function (result) {
            $("#myGlobalModalStacked" + modalNr).find(".modal-content").html(result);
            $("#myGlobalModalStacked" + modalNr).modal('show');
        },
        error: function (request, status, error) {
            alert("Failed to load! Please contact the Administrator!");
        },

        traditional: true
    });
}
