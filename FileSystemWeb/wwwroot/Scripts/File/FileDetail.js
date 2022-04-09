﻿function GetUserDetail(fiUserId) {
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
    $('#txtAddress').val(fresponse.data.stAddress);
}
function GetUserDetailError() { }

function GetFileDetail(fiFileId) {
    var loData = new Object();
    loData.fileId = fiFileId;
    loadMyRequest(msGetFileDetail, "GET", loData, GetFileDetailSuccess, GetFileDetailError)

}

function GetFileDetailSuccess(fresponse) {
    $('#txtFileName').val(fresponse.data.stFileName);
    $('#txtEmpoloyeeName').val(fresponse.data.stEmployeeName);
    $('#txtEmployeeNumber').val(fresponse.data.stEmployeeNumber);
    $('#txtPFNumber').val(fresponse.data.stPFNumber);
    $('#txtMobile').val(fresponse.data.stMobile);
    $('#txtPPONumber').val(fresponse.data.stPPONumber);

}
function GetFileDetailError() { }

