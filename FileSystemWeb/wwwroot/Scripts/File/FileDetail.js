function GetUserDetail(fiUserId) {
    var loData = new Object();
    loData.userId = fiUserId;
    loadMyRequest(msGetUserDetail, "GET", loData, GetUserDetailSuccess, GetUserDetailError)

}

function GetUserDetailSuccess() { }
function GetUserDetailError() { }

function GetFileDetail(fiFileId) {
    var loData = new Object();
    loData.fileId = fiFileId;
    loadMyRequest(msGetFileDetail, "GET", loData, GetFileDetailSuccess, GetFileDetailError)

}

function GetFileDetailSuccess() { }
function GetFileDetailError() { }