
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
                data: "name",
                render: function(data, type, customers) {
                    return "<a href='/customers/edit/" + customer.id + "'>"
                            + customers.name + "</a>"
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn link js-delete' data-customer-id= "+ data +">Delete</button>"
                }
            }



        ]
    });

    // delete the targeted customer |---filter---|
    $("#customer").on("click", ".js-delete", function () {

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
                        // tracing from child to parent to remove row from table and
                        //delete the table row internally when deleting
                        table.row(button.parents("tr")).remove().draw();
                        
                    }
                })
            }
        })
    })
})