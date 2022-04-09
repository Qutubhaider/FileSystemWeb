function GetUserDetail() {
    var loData = new Object();
    loData.userId = $('#ddUser').val();
    loadMyRequest(msGetUserDetail, "GET", loData, GetUserDetailSuccess, GetUserDetailError)

}

function GetUserDetailSuccess() {
    $('#txtFirstName').val(fresponse.data.stFirstName);
    $('#txtLastName').val(fresponse.data.stLastName);
    $('#txtEmail').val(fresponse.data.stEmail);
    $('#txtMobile').val(fresponse.data.stMobile);
    if (fresponse.data.inRole == Role.DeskOP) {
        $('#txtUserType').val('Desk Operator');
    }
    else if (fresponse.data.inRole == Role.DeskAdmin) {
        $('#txtUserType').val('Department Admin');
    }
    else if (fresponse.data.inRole == Role.StoreOP) {
        $('#txtUserType').val('Store Operator');
    }
    }
function GetUserDetailError() { }

function GetFileDetail() {
    var loData = new Object();
    loData.fileId = $('#ddFileName').val();
    loadMyRequest(msGetFileDetail, "GET", loData, GetFileDetailSuccess, GetFileDetailError)

}

function GetFileDetailSuccess() { }
function GetFileDetailError() { }