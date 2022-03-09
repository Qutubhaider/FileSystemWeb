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

    /*if ($("#ddDistrict").length > 0) {
        $("#ddDistrict").empty();
        $("#ddDistrict").append("<option value='" + "" + "'>" + "Select District" + "</option>");
    }

    if ($("#ddBlock").length > 0) {
        $("#ddBlock").empty();
        $("#ddBlock").append("<option value='" + "" + "'>" + "Select Block" + "</option>");
    }

    if ($("#ddVillageWard").length > 0) {
        $("#ddVillageWard").empty();
        $("#ddVillageWard").append("<option value='" + "" + "'>" + "Select Village" + "</option>");

    }*/
    loadMyRequest(msGetDivisionDropDown, "GET", loData, function (response) {
        //console.log(response); 

        $("#ddDivision").append("<option value='" + "" + "'>" + "Select Division" + "</option>");
        response.data.forEach(d => $("#ddDivision").append("<option value='" + d.id + "'>" + d.value + "</option>"));
        if (flgIsEdit)
            $("#ddDivision").val($("#inDivisionId").val());
    }, function () { });
}