$(function () {
    LoadSuppliers();
});
function LoadSuppliers() {
    if ($.fn.DataTable.isDataTable('#tblSupplierSearch')) {
        dataTable.destroy();
    }

    var dataTable = $("#tblSupplierSearch").DataTable({
        "bPaginate": true,
        "bLengthChange": false,
        "bFilter": true,
        "dom": "Bfrtip",
        "bInfo": false,
        "paging": true,
        "bAutoWidth": false,
        "ajax": {
            "url": "/Supplier/GetAllSupliers",
            "type": "GET",
            "datatype": "json"
        },
        "columns":
            [
                {
                    data: 'name', "width": "20%"
                },
                {
                    data: 'telephoneNo', "width": "20%"
                }
            ],
    });
}