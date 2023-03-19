$(function () {

    $("#SupplierForm").submit(function (e) {
        e.preventDefault();
        if (ValidateForm()) {
            Show()
            $.post($(this).attr("action"),
                $(this).serialize(),
                function (data) {
                    if (!data.valid) {
                        $('#btnFailModal').click();
                        $('#FailMessage').text(data.message);
                    }
                    else {
                        $('#btnSuccessModal').click();
                        $('#successMessage').text(data.message);
                    }
                    Hide()
                });
        }
    });
    LoadSuppliers();
});
$("#TelephoneNo").keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message
        // $("#errmsg").html("Digits Only").show().fadeOut("slow");
        $('#errorTelephoneNo').text('Only number are allowed');
        $("#TelephoneNo").css('border-color', 'red');
        return false;
    }
    else {
        $('#errorTelephoneNo').text('');
        $("#TelephoneNo").css('border-color', '');
    }
});
function LoadSuppliers() {
    if ($.fn.DataTable.isDataTable('#tblSuppliers')) {
        dataTable.destroy();
    }

    var dataTable = $("#tblSuppliers").DataTable({
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
                },
                {
                    data: 'code', "width": "20%"
                },
                {
                    data: null,
                    "render": function (data, type, full, meta) {

                        return '<div class="text-center"><a onclick="UpdateSupplier(\'' + full["id"] + '\')" class="btn btn-success btn-sm text-white" style="cursor:pointer;" data-toggle="tooltip" data-placement="top" title="Edit Supplier"><i class="far fa-edit"></i></a></div>';

                    }, "width": "40%"
                }
            ],
    });
}
function ValidateForm() {
    var valid = true
    if ($('#Name').val() == "") {
        $('#Name').css('border-color', 'red');
        $('#Name').focus();
        $('#errorName').text('Supplier Name Required');
        valid = false;
    }
    else {
        $('#Name').css('border-color', '');
        $('#errorName').text('');
    }
    if ($('#TelephoneNo').val() == "") {
        $('#TelephoneNo').css('border-color', 'red');
        $('#TelephoneNo').focus();
        $('#errorTelephoneNo').text('Telephone Number Required');
        valid = false;
    }
    else {
        $('#TelephoneNo').css('border-color', '');
        $('#errorTelephoneNo').text('');
    }
    if ($('#Code').val() == "") {
        $('#Code').css('border-color', 'red');
        $('#Code').focus();
        $('#errorCode').text('Code Required');
        valid = false;
    }
    else {
        $('#Code').css('border-color', '');
        $('#errorCode').text('');
    }

    return valid;
}
function UpdateSupplier(id) {


    $.ajax({
        type: 'Get',
        url: '/Supplier/GetSupplierById',
        dataType: 'json',
        data: { "Id": id },
        beforeSend: function () {
            $('#busyModal').modal('show');
        },
        success: function (data) {

            if (data != null) {
                ResetSupplierModal();
                $('#SupplierId').val(data.data.id);
                $('#Name').val(data.data.name);
                $('#TelephoneNo').val(data.data.telephoneNo);
                $('#Code').val(data.data.code);
                $('#SupplierModalCenter').modal('show');

            }
        },
        complete: function () {
            Hide();
        },
        error: function (ex) {
            $.alert({
                title: 'Error!',
                content: 'Failed',
            });
        }
    });

}
function CloseModalSuccess() {
    window.location.href = '/Supplier/ManageSuppliers';
}
$("#btnNew").click(function () {
    ResetSupplierModal();
});
function CloseModalFail() {
    $('#FailMessage').modal('hide');
}
function Show() {

    $('#busyModal').modal('show').on('shown', function () {
        $('body').css('overflow', 'hidden');
    }).on('hidden', function () {
        $('body').css('overflow', 'auto');
    });
}
function Hide() {
    $('#busyModal').modal('hide');
}
function ResetSupplierModal() {
    $('#Id').val(0);
    $('#Name').val("");
    $('#TelephoneNo').val("");
    $('#Code').val("");
}