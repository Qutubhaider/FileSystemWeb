function GetUserDetail(fiUserId) {
    alert(fiUserId);
    var loData = new Object();
    loData.userId = fiUserId;
    loadMyRequest(msGetUserDetail, "GET", loData, GetUserDetailSuccess, GetUserDetailError)

}

function GetUserDetailSuccess(fresponse) {
    $('#txtFirstName').val(fresponse.data.stFirstName);
    $('#txtLastName').val(fresponse.data.stLastName);
    $('#txtEmail').val(fresponse.data.stEmail);
    $('#txtMobile').val(fresponse.data.stMobile);
    $('#txtUserType').val(fresponse.data.inRole);
}
function GetUserDetailError() { }

function GetFileDetail(fiFileId) {
    var loData = new Object();
    loData.fileId = fiFileId;
    loadMyRequest(msGetFileDetail, "GET", loData, GetFileDetailSuccess, GetFileDetailError)

}

function GetFileDetailSuccess() { }
function GetFileDetailError() { }

