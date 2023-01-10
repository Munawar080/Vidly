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
                data: "name",
                render: function (data, type, movie) {
                    return "<a href='/movie/edit/" + movie.id + "'>"
                            + movie.name + "</a>"
                }
            },
            { data: "genre.name" },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn link js-delete' data-customer-id= " + data + ">Delete</button>"
                }
            }
        ]
    });

    $("#movies").on("click", ".js-delete", function () {
        // reference $this in the button scope
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete movie?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/movie/" + button.attr("data-customer-id"), 
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                })
            }
        })
    })

})