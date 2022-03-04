var dataTable;

$(document).ready(function () {
    dataTable = $('#load_DT_data').DataTable({
        "ajax": {
            "url": "books/getbooks",
            "type" : "GET",
            "datatype" : "json"
        },
        "columns": [
            { "data" : "title" },
            { "data" : "author" },
            { "data": "isbn" },
            { "data": "unitprice" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="Books/CreateBook?id=${data}" class="btn btn-success">
                        <i class="bi bi-pen-fill"></i> Update
                    </a>

                    <a class="btn btn-danger" onclick=Delete(${data})>
                        <i class="bi bi-trash3-fill"></i> Remove
                    </a>    
                     `
                }
            }
        ],
        "lanague": {
            "emptyTable" : "No Data Available"
        },
        "width" : "100%"
    });
});

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                "url": `Books/Delete/${id}`,
                "type": "DELETE",
                "datatype": "json",
                success: function (data) {
                    if (data.success) {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: data.message,
                            showConfirmButton: false,
                            timer: 1500
                        })
                        dataTable.ajax.reload();
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: data.message,
                        })
                    }
                }
            })
        }
    })
}