
$(document).ready(function () {

    // render the datatable
    var table = $("#customer").DataTable({
        // call ajax
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },

        //datatable columns
        columns: [
            {
                data: "name"
            },
            {
                data: "membershipType.name"
            }



        ]
    });
})