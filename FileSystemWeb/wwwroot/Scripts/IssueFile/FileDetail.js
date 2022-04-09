function GetUserDetail() {
    var loData = new Object();
    loData.userId = $('#ddUser').val();
    loadMyRequest(msGetUserDetail, "GET", loData, GetUserDetailSuccess, GetUserDetailError)

}

function GetUserDetailSuccess() {}
function GetUserDetailError() { }

function GetFileDetail() {
    var loData = new Object();
    loData.fileId = $('#ddFileName').val();
    loadMyRequest(msGetFileDetail, "GET", loData, GetFileDetailSuccess, GetFileDetailError)

}

function GetFileDetailSuccess() { }
function GetFileDetailError() { }