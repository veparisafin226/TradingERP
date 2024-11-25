$(document).ready(function () {
    loadParty();
    loadSite();
    loadVehicleNo();
    loadItem();
    loadDealer();
    loadLiz();
});


function loadParty(id) {
    
    $.ajax({
        url: '/Partial/PartyList',
        type: 'GET',
        success: function (data) {
            
            
            if (id != undefined) {
                $("#RgmParty").html(data);
                $("#RgmParty").val(id);
                $("#RgmParty").html(data).selectpicker('refresh');
            }
            else {
                $("#RgmParty").html(data).selectpicker('refresh');
            }
            
        }
    });
}




$("#addParty").click(function () {
    $("#partyModal").modal("show");
});

$("#btnAddParty").click(function () {
    $("#cstmLoader").show();
    var prtName = $("#prtName").val();
    var prtContact = $("#prtContact").val();
    var prtCity = $("#prtCity").val();
    if (prtName.trim().length == 0) {
        $("#prtNameMsg").html("Please enter name");
    }
    else {
        $("#prtNameMsg").html("");
        $.ajax({
            url: '/Partial/AddParty',
            type: 'POST',
            data: { PRTName: prtName, PRTContact: prtContact, PRTCity: prtCity },
            success: function (response) {
                if (response == "Success") {
                    loadParty(prtName);
                }

                else {
                    alert("Error Occurred");
                }
                $("#partyModal").modal("hide");
                $("#cstmLoader").hide();
            }
        });
    }
});


function loadSite() {

    $.ajax({
        url: '/Partial/SiteList',
        type: 'GET',
        success: function (data) {
            $("#RgmSite").html(data);
            $("#RgmSite").html(data).selectpicker('refresh');
        }
    });
}




$("#addSite").click(function () {
    $("#siteModal").modal("show");
});

$("#btnAddSite").click(function () {
    $("#cstmSiteLoader").show();
    var stmName = $("#stmName").val();
    var stmAddress = $("#stmAddress").val();
    
    if (stmName.trim().length == 0) {
        $("#stmNameMsg").html("Please enter name");
    }
    else {
        $("#stmNameMsg").html("");
        $.ajax({
            url: '/Partial/AddSite',
            type: 'POST',
            data: { STMName: stmName, STMAddress: stmAddress },
            success: function (response) {
                if (response == "Success") {
                    loadSite();
                }

                else {
                    alert("Error Occurred");
                }
                $("#siteModal").modal("hide");
                $("#cstmSiteLoader").hide();
            }
        });
    }
});

function loadVehicleNo() {

    $.ajax({
        url: '/Partial/VNList',
        type: 'GET',
        success: function (data) {
            $("#RgmVehicleNo").html(data);
            $("#RgmVehicleNo").html(data).selectpicker('refresh');
        }
    });
}




$("#addVn").click(function () {
    $("#VnModal").modal("show");
});

$("#btnAddVn").click(function () {
    $("#cstmVnLoader").show();
    var vnmNo = $("#vnmNo").val();

    if (vnmNo.trim().length == 0) {
        $("#vnmNoMsg").html("Please enter no");
    }
    else {
        $("#vnmNoMsg").html("");
        $.ajax({
            url: '/Partial/AddVehicleNo',
            type: 'POST',
            data: { VNMNo: vnmNo },
            success: function (response) {
                if (response == "Success") {
                    loadVehicleNo();
                }

                else {
                    alert("Error Occurred");
                }
                $("#VnModal").modal("hide");
                $("#cstmVnLoader").hide();
            }
        });
    }
});

function loadItem() {

    $.ajax({
        url: '/Partial/ItemList',
        type: 'GET',
        success: function (data) {
            $("#RgmItem").html(data);
            $("#RgmItem").html(data).selectpicker('refresh');
        }
    });
}




$("#addItem").click(function () {
    $("#itemModal").modal("show");
});

$("#btnAddItem").click(function () {
    $("#cstmItemLoader").show();
    var itmName = $("#itmName").val();

    if (itmName.trim().length == 0) {
        $("#itmMsg").html("Please enter name");
    }
    else {
        $("#itmMsg").html("");
        $.ajax({
            url: '/Partial/AddItem',
            type: 'POST',
            data: { ITMName: itmName },
            success: function (response) {
                if (response == "Success") {
                    loadItem();
                }

                else {
                    alert("Error Occurred");
                }
                $("#itemModal").modal("hide");
                $("#cstmItemLoader").hide();
            }
        });
    }
});

function loadDealer() {

    $.ajax({
        url: '/Partial/DealerList',
        type: 'GET',
        success: function (data) {
            console.log(data);
            $("#RgmDealer").html(data);
            $("#RgmDealer").html(data).selectpicker('refresh');
        }
    });
}




$("#addDealer").click(function () {
    $("#dealerModal").modal("show");
});

$("#btnAddDealer").click(function () {
    $("#cstmDealerLoader").show();
    var dlrName = $("#dlrName").val();
    var dlrContact = $("#dlrContact").val();
    var dlrCity = $("#dlrCity").val();

    if (dlrName.trim().length == 0) {
        $("#dlrNameMsg").html("Please enter name");
    }
    else if (dlrContact.trim().length == 0){
        $("#dlrContactMsg").html("Please enter contact no");
    }
    else {
        $("#dlrNameMsg").html("");
        $("#dlrContactMsg").html("");
        $.ajax({
            url: '/Partial/AddDealer',
            type: 'POST',
            data: { DLRName: dlrName, DLRContact: dlrContact, DLRCity: dlrCity },
            success: function (response) {
                if (response == "Success") {
                    loadDealer();
                }

                else {
                    alert("Error Occurred");
                }
                $("#dealerModal").modal("hide");
                $("#cstmDealerLoader").hide();
            }
        });
    }
});


function loadLiz() {

    $.ajax({
        url: '/Partial/LizList',
        type: 'GET',
        success: function (data) {
            $("#RgmLiz").html(data);
            $("#RgmLiz").html(data).selectpicker('refresh');
        }
    });
}




$("#addLiz").click(function () {
    $("#lizModal").modal("show");
});

$("#btnAddLiz").click(function () {
    $("#cstmLizLoader").show();
    var lzmName = $("#lzmName").val();
    var lzmContact = $("#lzmContact").val();
    var lzmCity = $("#lzmCity").val();

    if (lzmName.trim().length == 0) {
        $("#lzmNameMsg").html("Please enter name");
    }
    else if (lzmContact.trim().length == 0) {
        $("#lzmContactMsg").html("Please enter contact no");
    }
    else {
        $("#lzmNameMsg").html("");
        $("#lzmContactMsg").html("");
        $.ajax({
            url: '/Partial/AddLiz',
            type: 'POST',
            data: { LzmName: lzmName, LzmContact: lzmContact, LzmCity: lzmCity },
            success: function (response) {
                if (response == "Success") {
                    loadLiz();
                }

                else {
                    alert("Error Occurred");
                }
                $("#lizModal").modal("hide");
                $("#cstmLizLoader").hide();
            }
        });
    }
});


function loadPump() {

    $.ajax({
        url: '/Partial/PumpList',
        type: 'GET',
        success: function (data) {
            $("#RgmSite").html(data);
            $("#RgmSite").html(data).selectpicker('refresh');
        }
    });
}




$("#addSite").click(function () {
    $("#siteModal").modal("show");
});

$("#btnAddSite").click(function () {
    $("#cstmSiteLoader").show();
    var stmName = $("#stmName").val();
    var stmAddress = $("#stmAddress").val();

    if (stmName.trim().length == 0) {
        $("#stmNameMsg").html("Please enter name");
    }
    else {
        $("#stmNameMsg").html("");
        $.ajax({
            url: '/Partial/AddSite',
            type: 'POST',
            data: { STMName: stmName, STMAddress: stmAddress },
            success: function (response) {
                if (response == "Success") {
                    loadSite();
                }

                else {
                    alert("Error Occurred");
                }
                $("#siteModal").modal("hide");
                $("#cstmSiteLoader").hide();
            }
        });
    }
});
