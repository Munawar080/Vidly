$(document).ready(function () {

    var table = $("#movies").DataTable({
        // call  api/movie via ajax
        ajax: {
            url: "/api/movie",
            dataSrc: ""
        },

        //datatable columns
        columns: [
            {
                data: "name"
            },
            { data: "genre.name" }
        ]
    });

})