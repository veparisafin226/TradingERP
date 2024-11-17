
$(document).ready(function () {
    
    $("#RgmType").change(function () {
        $("#RgmQty").val("0");
        $("#RgmRate").val("0");
        $("#RgmTotal").val("0");
        var typeVal = $("#RgmType").val();
        if (typeVal == "Liz") {
            $("#dealerDiv").hide();
            $("#QtyDiv").show();
            $("#RateDiv").show();
            $("#TotalDiv").show();
        }
        else {
            $("#dealerDiv").show();
            $("#QtyDiv").hide();
            $("#RateDiv").show();
            $("#TotalDiv").show();
        }
    });
   
    $("#RgmQty").blur(function () {
        var typeVal = $("#RgmType").val();
        if (typeVal == "Liz") {
            var qty = $("#RgmQty").val();
            var rate = $("#RgmRate").val();
            if (qty == undefined || qty == "" || rate == undefined || rate == "") {
                $("#RgmTotal").val("0");
            }
            else {
                try {
                    var total = parseFloat(qty) * parseFloat(rate);
                    total = total.toFixed(2);
                    $("#RgmTotal").val(total);
                }
                catch (e) {
                    $("#RgmTotal").val("0");
                }
            }
        }
    });

    $("#RgmRate").blur(function () {
        var typeVal = $("#RgmType").val();
        if (typeVal == "Liz") {
            var qty = $("#RgmQty").val();
            var rate = $("#RgmRate").val();
            if (qty == undefined || qty == "" || rate == undefined || rate == "") {
                $("#RgmTotal").val("0");
            }
            else {
                try {
                    var total = parseFloat(qty) * parseFloat(rate);
                    total = total.toFixed(2);
                    $("#RgmTotal").val(total);
                }
                catch (e) {
                    $("#RgmTotal").val("0");
                }
            }
        }
    });

});
