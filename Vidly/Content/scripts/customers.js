
$(document).ready(function () {

    // render the datatable
    $("#customer").DataTable({
        // call ajax
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function(data, type, customers) {
                    return "<a href='/customers/edit/ " + customer.id + "'>"
                            + customers.name + "</a>"
                }
            },
            {
                data: "name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn link js-delete' data-customer-id= "+ id +">Delete</button>"
                }
            }



        ]
    });

    // delete the targeted customer |---filter---|
    $("#customer").on("click", " .js-delete", function () {

        // reference $this in the button scope
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete customer?", function (result) {
            if (result) {
                // call api via ajax
                $.ajax({
                    // get the id of customer to delete
                    url: "/api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        // tracing from child to parent to remove row from table
                        button.parents("tr").remove();
                    }
                })
            }
        })
    })
})