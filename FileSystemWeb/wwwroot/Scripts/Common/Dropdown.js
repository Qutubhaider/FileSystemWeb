function OnZoneChange(flgIsEdit = false) {
    var loData = new Object();
    if (flgIsEdit) {
        var liZoneId = $('#inZoneId').val();
    }
    else {
        var liZoneId = $('#ddZone').val();
    }
    loData.fiZoneId = liZoneId;

    if ($("#ddDivision").length > 0) {
        $("#ddDivision").empty();
        $("#ddDivision").append("<option value='" + "" + "'>" + "Select Division" + "</option>");
    }
    if ($("#ddDesk").length > 0) {
        $("#ddDesk").empty();
        $("#ddDesk").append("<option value='" + "" + "'>" + "Select Desk" + "</option>");
    }
    loadMyRequest(msGetDivisionDropDown, "GET", loData, function (response) {
        $("#ddDivision").append("<option value='" + "" + "'>" + "Select Division" + "</option>");
        response.data.forEach(d => $("#ddDivision").append("<option value='" + d.id + "'>" + d.value + "</option>"));
        if (flgIsEdit)
            $("#ddDivision").val($("#inDivisionId").val());
    }, function () { });
}

function OnDivisionChange(flgIsEdit = false) {
    var loData = new Object();
    if (flgIsEdit) {
        var liDivisionId = $('#inDivisionId').val();
    }
    else {
        var liDivisionId = $('#ddDivision').val();
    }

    loData.fiDivisionId = liDivisionId;
    if ($("#ddDesk").length > 0) {
        $("#ddDesk").empty();
        $("#ddDesk").append("<option value='" + "" + "'>" + "Select District" + "</option>");
    }
    loadMyRequest(msGetDeskDropDown, "GET", loData, function (response) {
        //console.log(response);
        $("#ddDesk").empty();
        $("#ddDesk").append("<option value='" + "" + "'>" + "Select District" + "</option>");
        response.data.forEach(d => $("#ddDesk").append("<option value='" + d.id + "'>" + d.value + "</option>"));
        if (flgIsEdit)
            $("#ddDesk").val($("#inDeskid").val());
    }, function () { });
}