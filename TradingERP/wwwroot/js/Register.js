
$(document).ready(function () {
    var typeVal = $("#RgmType").val();
    
    if (typeVal == "Liz") {
        $("#dealerDiv").hide();
        $("#RateDiv").hide();
        $("#TotalDiv").show();
    }
    else {
        $("#dealerDiv").show();
        $("#RateDiv").show();
        $("#TotalDiv").show();
    }
    $("#RgmType").change(function () {
        
        $("#RgmRate1").val("0");
        $("#RgmTotal1").val("0");
        var typeVal = $("#RgmType").val();
        
        if (typeVal == "Liz") {
            $("#dealerDiv").hide();
            $("#RateDiv").hide();
            $("#TotalDiv").show();
        }
        else {
            $("#dealerDiv").show();
            $("#RateDiv").show();
            $("#TotalDiv").show();
        }
    });
   
    $("#RgmQty").blur(function () {
       
        var qty = $("#RgmQty").val();
        var rate = $("#RgmRate").val();
        var rate1 = $("#RgmRate1").val();
        var typeVal = $("#RgmType").val();
        if (qty == undefined || qty == "" || rate == undefined || rate == "") {
            $("#RgmTotal").val("0");
            $("#RgmTotal1").val("0");
        }
        else {
            try {
                var total = parseFloat(qty) * parseFloat(rate);
                total = total.toFixed(2);
                $("#RgmTotal").val(total);
                if (typeVal == "Dealer") {
                    var total1 = parseFloat(qty) * parseFloat(rate1);
                    total1 = total1.toFixed(2);
                    $("#RgmTotal1").val(total1);
                }
            }
            catch (e) {
                $("#RgmTotal").val("0");
                $("#RgmTotal1").val("0");
            }
        }
    });

    $("#RgmRate").blur(function () {
        
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
    });

    $("#RgmRate1").blur(function () {
        
        var typeVal = $("#RgmType").val();
        if (typeVal == "Dealer") {
            var qty = $("#RgmQty").val();
            var rate = $("#RgmRate1").val();
            if (qty == undefined || qty == "" || rate == undefined || rate == "") {
                $("#RgmTotal1").val("0");
            }
            else {
                try {
                    var total = parseFloat(qty) * parseFloat(rate);
                    total = total.toFixed(2);
                    $("#RgmTotal1").val(total);
                }
                catch (e) {
                    $("#RgmTotal1").val("0");
                }
            }
        }
    });

    

});


  

